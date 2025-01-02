using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Astred.GraphLib;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class ExternalDep
{
    private static void Main()
    {
        Console.WriteLine("Hello World!");
        string projectpath = @"C:\Users\t-skothapall\code\RustTranslation\samples\sample\.astred.project.json";
        // string repopath = @"C:\Users\t-skothapall\AppData\Local\Temp\2ri12m0r.nge\%REPO%\samples\sample\";
        
        List <string> TranslationScope = [@"C:\Users\t-skothapall\code\RustTranslation\samples\sample\main.c"];

        var graph = CodeGraph.Build(CodeGraph.LoadProject(projectpath));
        // var graph = CodeGraph.BuildFromDigest(digestpath);
        // graph.PrintGraph(includeAst:false, showRelations:true);
        List <BlockRelationType> inward_relation_types = [
                BlockRelationType.CalledBy,
                BlockRelationType.OverriddenBy,
                BlockRelationType.BaseTypeOf,
                BlockRelationType.InstantiatedBy,
                BlockRelationType.DeclaredBy,
                BlockRelationType.AccessedBy,
                BlockRelationType.TypeFor,
                BlockRelationType.Member,
                BlockRelationType.ExpandedBy,
            ];
        Dictionary<Block, HashSet<Block>> ExternalDeps = new();
        // int max_int  = 50;
        // int i = 0;
        foreach (var file in graph.GetFileBlocks()){
            Console.WriteLine(file.Name);
            if (!TranslationScope.Contains(file.Name)) continue;
            
            // for the files in translation scope
            // check the blocks which point to the ones not in translation scope
            foreach (var block in file.FindDescendants())
            {
                Console.WriteLine(block);
                var relations = block.AllRelatedBlocks;
                foreach (var relation in relations)
                {
                    
                    Console.WriteLine("------ {0} ******* {1}", relation.Item1, relation.Item2);

                    if ( !inward_relation_types.Contains(relation.Item1) && 
                        !TranslationScope.Contains(relation.Item2.GetFileBlock().Name))
                    {
                        Block ExtDepBlock = relation.Item2;
                        if (!ExternalDeps.ContainsKey(block)){
                            
                            ExternalDeps[block] = new HashSet<Block>();
                        }
                        ExternalDeps[block].Add(ExtDepBlock);
                    }
                }
            }
            break;

            
        }

    }
    // astred.project.json file --> builds the codegraph (or symbolic graph?)
    // gets the list of all external dependencies and prints them to the user
}
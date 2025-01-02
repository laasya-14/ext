using System;
using Astred.GraphLib;

public class ExternalDep
{
    private static void Main()
    {
        Console.WriteLine("Hello World!");
        string digestpath = @"C:\Users\t-skothapall\code\RustTranslation\samples\sample\.astred.digest.zip";
        var codegraph = CodeGraph.BuildFromDigest(digestpath);
        codegraph.PrintGraph(includeAst:false, showRelations:true);

    }
    // astred.project.json file --> builds the codegraph (or symbolic graph?)
    // gets the list of all external dependencies and prints them to the user
}
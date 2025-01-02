# Astred Change Log

# Release 1.4.1

- Added the optional parameter `projectRoot` to the following methods in the C# API: `CreateProjectFromPaths` and `CreateProjectWithLanguage`, and in the Python API: `create_project_from_paths` and `create_project_with_language`. This parameter allows you to specify the root directory of the project being parsed.
- Added new methods: `SymNode.FindDescendants`, `SymNode.FindNodeAndDescendants`, `SymNode.FindTopDescendants`, `SymNode.IsDescendantOf`, `SymNode.IsAncestorOf`, `SymNode.IsSiblingOf`.

# Release 1.4.0

- Improved compatibility of preprocessor expansion of `__VA_ARGS__` with MSVC traditional mode.
- Added `ImportedBy` and `Imports` relations for C and C++ `#include#` files.
- Optimized Edits algorithm to reduce execution and processing power needed to calculate diffs.
- Added `Calls` and `CalledBy` relations between `InvocationBlock` and `DeclarationBlock` when the function definition is part of the project.
- Added `BlockImport` for import statements in TypeScript.
- Fixed bug when astred printed blocks with long lines of text caused an assertion to fail.
- Fixed a bug when astred was executed on WSL and didn't find the dlls.
- Introduce `AstNodeRoot` as the root node in the multi-file AST.
- Removed `AstToken.ROOT`, `AstToken.FILE`, and `AstToken.FILES`.
- First release of new C/C++ preprocessor.
- Create first-class `AstNodeError` class.
- Collect text and column when preprocessor fails on a line.
- Remove deprecated `AstNode.link`.
- Added `AstFile.UpdateCache` and `Astfile.UpdateFilesInCache` APIs that refreshes the cache of loaded files that have changed on disk.
- Fixed a bug when reading the digest where files could not be found when the astred project path had a relative path to it from the %REPO%.
- Added symbolic paths information to the digest.
- Added `ReturnTypes` property to `BlockFunction`, which returns the blocks corresponding to the return type(s), if they exist.

# Release 1.3.1

- Added support for user-defined literal operators in the C++ preprocessor.
- Added support for Microsoft-specific numeric literal suffixes (e.g., `i8`, `ui8`, `i16`, `ui16`, `i32`, `ui32`, `i64`, `ui64`) in C.

# Release 1.3.0

- Initial release of the Line Based editing API. Usage samples available at [C# Samples](samples\c-sharp\edits\README.md)
- Initial release of Symbolic Graph API.
- Reduce memory allocations for symbols and Symbolic Graph nodes.
- Improve efficiency of block relations in the Code Graph.
- Added `BlockRelationType.None`.
- Set `isConstructor` and `isDestructor` properties on `BlockFunction` objects for C++ and C#.
- Fixed bug on the digest showing an error when specifying a project file name in the command line.
- Improve parsing time of large C/C++ code bases by caching preprocessor operations.
- Renamed `SagNode*` to `SymNode*` and renamed `.Sag` to `.SymGraph`.
- Added `BlockConcept` for concept definitions in C++.

# Release 1.2.0

- Fixed bug in Python when having inheritance and reference the class with import from.
- Stopped creating `BlockVariable` for function pointer parameters in C/C++.
- Added `Qualifies` and `QualifiedBy` relations.
- Added support for statement expressions and `typeof` expressions in C/C++.
- Implemented operation caching the C/C++ preprocessor to reduce parsing overheads.
- Added `-tojson file.pdb` option that creates a json file with the source link and source files data from a pdb file.
- Added `IsAbstract`, `IsConstructor`, `IsDestructor`, `Parameters`, `Modifiers`, `TypeParameters`, `ReturnType`, `Signature` and `Attributes` properties to `BlockDeclaration`.
- Added documentation tags with code examples in `BlockRelationType` enumeration.
- Resolved an issue in C# using directives that caused symbols to appear in multiple scopes..
- Started creating `BlockVariable` for lambda function parameters in C#.
- Removed `Accesses` and `AccessedBy` relations between the same `Block`.
- Set C++ type parameters in `BlockFunction` and `BlockDeclaration`.
- Implemented `Qualifies` and `QualifiedBy` for Python.
- All `BlockVariable` inside `BlockEnum` in Rust are now encapsulated by a `BlockField`. 
- Added corpus tests for the Symbolic Graph.
- Renamed `Block.ResetIdsCount` to `Block.ResetIdBase`. In Python, `Block.reset_ids_count` was renamed to `Block.reset_id_base`.
- Turn `AstFile.Hash` into a first class `AstFileHash` object in `AstFileIdentifier` class. 
- Add hash-based caching into `AstFile` caching infrastructure.
- Added `Member` and `MemberOf` relations for class members in Python.
- Added `CodeGraph.FindFromPath` function.
- Added `SagNode.FindUsedByThis` and `SagNode.FindUsingThis`.
- Stability improvements for built-in/primitive types.

# Release 1.1.0

- Streamline memory usage of `astred` `-bljson` option.
- Correcting handling of `\"` characters in `tracebld` command lines.
- Fixed a bug in Rust where block creation would fail if match value did not have a valid identifier.
- Updated Astred-core pip package documentation.
- Improved accuracy of Expands/ExpandedBy relationships for C and C++.
- Added Imports/ImportedBy relationship for `#include`, etc.
- Renamed `BlockStatement` properties `condition` to `Condition` and `control` to `Control`.
- Explose `BlockAssignment` property `RightAst`.
- Track origin points for AST nodes and Code Graph blocks--not yet exposed to API.
- Fixed name collisions in C/C++ `typedef` definitions.
- Added `BlockFunction` for accessor declarations in C#.
- Removed `BlockType` property from `AstNodeBase` and instead added a reference to the linked `Block` if any. 
- Added support for Macros 2.0 in Rust.
- Added support for using Markdown instead of Text for Corpus files.
- Added support for multi-file Corpus tests, including support for embedded `.astred.project.json` files.
- Added `CREDITS.md` file to thank external contributors.
- Fixed a bug in Python when no `__init__.py` file is in the package.
- Fixed bugs in Rust that caused the graph build to fail.

# Release 1.0.4

- Added specific type definitions for pointers and arrays in C.
- Fixed a bug in C and C++ where members of `typedef struct` were not being bound correctly.
- Added `fenv_access`, `float_control`, `fp_contract` and `clang` to the list of C/C++ known pragmas.
- Added support for using `__stdcall` in typedefs in C/C++.
- Enabled calling destructors with qualified identifiers in C++.
- Added support for for invoking template operators in C++.
- Added support for calling functions with dependent types as arguments in C++.
- Added support for calling C# generic methods from the Python package. New Python methods: `Block.find_top_descendants_t`, `Block.find_related_blocks_by_relation_t`, `Block.find_children_t` and `Block.find_descendants_t`.
- Added option to build and install the Python package locally.

# Release 1.0.3

- Rename `DependencyGraph` to `CodeGraph` and `DependencyGraphBuilder` to `CodeGraphBuilder`.
- Fixed a bug in Python where the `self` parameter was not bound to the correct symbol.
- Added `BlockStatement` for macro invocations in Rust, including the respective `Expands` and `ExpandedBy` relations.
- Refactored C/C++ `Expands` and `ExpandedBy` relations to only include the statement originating the expansion and the macros involved.
- Fixed a bug in the preprocessor that caused incorrect processing of macro definitions following a multi-line comment.
- Fixed a bug in type inference for `char` literals in C++.

# Release 1.0.2

- Restored `astred.exe` ability to select language by file extension when no `-lang:{lang}` option is provided.
- Exposed the `XAst` class to the Python package.
- In the Python package, `Block.all_related_blocks` and `Block.all_related_blocks_set` are now fields.
- Fixed a bug in `Block.FindDescendants(List<BlockFilterAction> filters)` and `Block.FindBlockAndDescendants(List<BlockFilterAction> filters)`

# Release 1.0.1

- Summary of significant changes in this release:
  - First release of the new Python `Astred-core` PIP package.
  - Improved Python parser. These may cause temporary regressions, bug reports encouraged!
  - Added python-specific documentation. To open the documentation in a browser, run `astred -python` (with `Astred.Tools` installed).
  - Significant renames across the entire C# and Python to match common naming conventions for each of C# and Python.
  - Significant improvements in the C/C++ preprocessor, especially for macro-expansion corner cases.
  - Replaced `astred.exe` `-ext:{ext}` with `-lang:{lang}`, for example `astred -lang:c++`.
- Added two samples to `c-sharp` and `python` folder: `block-symbols` and `function-properties`.
- Added support for namespace aliasing in C++.
- Added support in C preprocessor for `#pragma function(...)`.
- Removed support for `.astred.preproc.json` files from Astred.  Legacy `.astred.preproc.json` files can be converted to a `.astred.project.json` file using `AstProj`.
- Added `-python` option to Astred.Tools to open the Astred pip package documentation.
- Added `AstNodeBase.FindDescendants` method overload that filters nodes using `AstField`, `AstToken` and `AstCategory`.
- Renamed `Block.GetRelatedBlocksByRelation` to `Block.FindRelatedBlocksByRelation`.
- Renamed `Block.GetRelatedBlockSet` to `Block.FindRelatedBlockSet`.
- Renamed `Block.GetContainingFunction` to `Block.FindContainingFunction`.
- Renamed `Block.GetContainingCompound` to `Block.FindContainingCompound`.
- Renamed `Block.GetRelationTo` to `Block.FindRelationTo`.
- Renamed `Block.FindChildBlocks` to `Block.FindChildren`.
- Renamed `Block.FindDescendantBlocks` to `Block.FindDescendants`.
- Renamed `Block.FindBlockAndDescendantBlocks` to `Block.FindBlockAndDescendants`.
- Renamed `Block.FindTopDescendantBlocks` to `Block.FindTopDescendants`.
- Renamed `Block.FindAncestorBlocks` to `Block.FindAncestors`.
- Renamed `Block.FindFirstAncestorBlock` to `Block.FindFirstAncestor`.
- Renamed `Block.FindRecursiveRelations` to `Block.FindRecursiveRelatedBlocksByRelation`.
- Renamed `Block.FindRecursiveRelations` to `Block.FindRecursiveRelatedBlocksByRelations`.
- Renamed `DependencyGraph.GetTopBlocks` to `DependencyGraph.FindTopBlocks`.
- Renamed `AstNodeBase.AllInteriors` to `AstNodeBase.FindAllInteriors`.
- Renamed `AstNodeBase.FirstChildCode` to `AstNodeBase.FindChildCode`.
- Renamed `AstNodeBase.FirstChild` to `AstNodeBase.FindChild`.
- Renamed `AstNodeBase.FirstChildPosition` to `AstNodeBase.FindChildPosition`.
- Renamed `AstNodeBase.GetIdentifiersForChildren` to `AstNodeBase.FindIdentifiersForChildren`.
- Renamed `AstNodeBase.GetChildrenWithIdentifiers` to `AstNodeBase.FindChildrenWithIdentifiers`.
- Renamed `AstNodeBase.GetIdentifierFor` to `AstNodeBase.FindIdentifierFor`.
- Renamed `AstNodeBase.GetIdentifierFor` to `AstNodeBase.FindIdentifierFor`.
- Renamed `BlockFunction.abstract` to `BlockFunciton.IsAbstract`.
- Renamed `BlockFunction.constructor` to `BlockFunciton.IsConstructor`.
- Renamed `BlockFunction.destructor` to `BlockFunciton.IsDestructor`.
- Renamed `BlockClass.abstract` to `BlockClass.IsAbstract`.
- Renamed `BlockClass.constructor` to `BlockClass.IsConstructor`.
- Renamed `BlockClass.destructor` to `BlockClass.IsDestructor`.
- Renamed `DependencyGraph.Build` to `DependencyGraph.BuildWithPaths`.
- Added `Block.GetTopMostSymbols` and `Block.FindRelationsInDescendants` methods.
- Added `Block.FindDescendantBlocks` and `Block.FindBlockAndDescendantBlocks` overloads that take a list of `BlockFilterAction`.
- All properties in C# have been renamed to follow PascalCasing. All fields have been renamed to follow camelCasing.
- Refactored the Python parser. Note: This update may have introduced new bugs.
- Fixed a bug where a `BlockVariable` was incorrectly created for an operator cast in C++.
- Fixed a bug in Rust where `-block` would fail if match value did not have an `AstSymbol`.
- Fixed a bug in C/C++ where an include statement preceded by a comment was not being parsed correctly.

# Release 0.6.0

- All occurences of `blocktype` in the code have been renamed `blockType`. 
- Adding `FindDescendants`, `FindLeafNodes`, `GetFirstLeafNode` and `GetLastLeafNode` APIs in `AstNodeBase`.
- Adding `FindFirstAncestorBlock` and `GroupBlocksByFileBlock` APIs in `Block`.
- In `Block`, the `relations` parameter of functions `PrintBlock`, `PrintTree` renamed to `showRelations`.
- In `Block`, the `color` parameter of function `PrintBlock` renamed to `showColor`.
- In `DependencyGraph`, the `relations` parameter of function `PrinGraph` renamed to `showRelations`.
- In `Block`, the `sliced` parameter of functions `PrintTree` renamed to `printSliced`.

# Release 0.5.20

- Robustness improvements to digest creation and processing.
- Move Astred command-line `-bljson` to a separate module to improve graph re-use.
- Adding `IsSiblingOf`, `GetLineCount`, `SetSliceState` and `SetSliceStateAll` helper APIs to `Block`.
- All occurences of `descendent` in the code have been renamed `descendant` for consistency.
- In `Block`, `slice` was renamed to `sliceState`.
- In `Block`, the `comments` parameter of functions `GetText`, `AppendAllTextTo`, `GetSliceText`, `AppendSliceTextTo` and `UpdateSliceSet` renamed to `showComments`.
- In `Block`, the `number` parameter of functions `GetText`, `AppendAllTextTo`, `GetSliceText` and `AppendSliceTextTo` renamed to `showLines`.
- In `Block`, the `descendents` parameter of functions `SliceInherit`, `SliceInclude`, `SliceExclude` renamed to `setDescendants`.
- In `Block`, renaming `SliceSet` function to `UpdateSliceSet`.
- Fixed a bug where template function declarations were not correctly linked to their definitions in C++.
- Fixed the creation of duplicated `BlockTypedef` entries in C and C++.

# Release 0.5.19

- Updated Typescript parser to add `BlockAttributes` to its `BlockFunction` type parent.
- Updated C++ parser to add `BlockAttributes` when creating a `BlockFunction` type parent.
- Update to Javascript parser to include `expression_statement` block.
- Added support for `__ptr32` and `__ptr64` type qualifiers in C and C++.
- Added two methods to get block relations of the current block and its descendants recursively.
- Updated `BlockFunction` to expose method annotations in C, C#, Java and Python parsers.
- Updated all parsers to use all `BlockFunction` properties e.g. signature, modifiers, return type etc.
- Added a HeaderComment property in `BlockFunction` class to get the comments located above the method defintion.
- Updated Rust parser to use properties in `BlockFunction` type.
- Fixed bug when creating `BlockAssignment` that was missing access relations.
- Digest can load from an unzipped digest.
- Digest now includes git metadata of the parsed repo.
- API to load the `DependencyGraph` from a zipped or unzipped digest.
- Fixed digest not serializing correctly `.astred.digest.json` file.
- Created API to compare two AST's and show the diff between them. Nodes are marked with the editStatus flag after the comparison.
- Significant improvements in TraceBld processing of I/O through memory-mapped files, for example by `link` and `rustc`

# Release 0.5.18

- `AstFile.AppendLinesTo` no longer adds an unwanted line number on the last line when slicing.

# Release 0.5.17

- Improved processing of TraceBld files in AstProj for creating Rust projects.

# Release 0.5.16

- Renamed AstProj option for including unfound source files from `-ignore` to `-keepall`.
- Fix AstProj regression that caused `@rsp` command-line file processing to fail.
- AstProj correctly parses more complex `rustc` command-lines.
- Fixed null dereference bug in which AstProj when no units are created.
- Added `BlockAssignment` type for Assignment expressions.

# Release 0.5.15

- Correct error in TraceBld argument logging introduced with 0.5.14.

# Release 0.5.14

- Improve TraceBld support for extremely large command-line arguments (encountered between `cargo` and `rustc`).

# Release 0.5.13

- Creates blocks for macros in Rust.
- Fixed duplicated blocks bug.

# Release 0.5.12

- Statement blocks and empty statements now *always* result in `BlockStatement`s in the dependency graph, even if the they are nested. 

# Release 0.5.11

- AST nodes for C function returning a function pointer is now a function.
- Diagnostic message that digest is written is no longer logged as an error.
- Moved many functions from Astred to built-ins to Astred modules--particularly slicing examples.

# Release 0.5.10

- Fixed bug related to  the parsing of C/C++ header files.
- Added support for generating blocks from C/C++ header files.
- Improvments in AstProj for identifying `.rs` files used by `rustc` and C and C++ files used by `*gcc` or `*g++`.
- Fixed error in C and C# preprocessors when `'` crosses end-of-line boundaries.
- Removed ignoring `cl` commands that generate `.pch` files.

# Release 0.5.9

- Support for C++ alias declarations.
- Improved the creation of `Expands` and `ExpandedBy` relationships for C/C++.

# Release 0.5.8

- Ignore CL invocations with `/Yc[file]` option instead of `/Fp[file]`.
- Support for C++ alias declarations.
- Improved the creation of `Expands` and `ExpandedBy` relationships for C/C++.

# Release 0.5.7

- Fix error in handling of \r\r\n in C preprocessor. 

# Release 0.5.6

- Astproj validates paths when creating a project. Enabled by default. Disable with `-ignore`.
- Improve loading of plug-in modules.
- Astproj now drops `.pch` files and emits warnings when it drops `.i` and `.pch` files.
- Added exception and assert logging when collecting debug digests.
- Corrected error in digest collection that cause the same file to be collected multiple times if it was access with different casing.

# Release 0.5.5

- Update dependency on OpenTelemetry to 1.9.0 and Azure.Monitor.OpenTelemetry.Exporter to 1.3.0.

# Release 0.5.4

- TraceBld for prefix match now matches fully qualified paths using slash (`/`) instead backslash (`\`).
- Improved Astproj processing of CL commmand-line options, and error reporting on unknown command-line options.

# Release 0.5.3 

- Test release to validate pipeline improvements. No user-visible changes.

# Release 0.5.2

- Improved robustness of digest creating by minimizing parsing and processing as much as possible.
- Corrected language classification error in AstProj (mismatching between C and C++).

# Release 0.5.1

- Fixed preprocessor error when a macro call is literally the last character in a file.
- Fixed qualified type binding in C++.
- Added test files for every supported language to sample packages.
- Updated README.md, samples/README.md, samples/c-sharp/README.md, and samples/python/README.md
- Added -o:{file} option to astproj, this option gives the user the ability to specify the resulting project filename
- Compatibility improvements to TraceBld.
- Remove extra submodules from tree-sitter-yaml submodule.
- Added support for using declarations, anonymous structs, and anonymous unions in C++.
- Fixed bugs in Javascript parser and moved it to M3.
- Added control type for statement blocks to the Python wrapper.
- Added block creation for structs in `typedef struct` expressions in C++.

# Release 0.5.0

- Feature release of recent parser improvements:
  - Added Javascript (M2) and YAML (M1) parsers.
  - C and C++ parsers now add Block and Symbol information from parsed headers. Users will notice longer C and C++ parsing times. We will work on performance in future releases.
  - C/C++ preprocessor now adds `Expands` and `ExpandedBy` relationships between macros and statements.
  - Various bug/usability fixes in C, C++, and Rust grammars and preprocessors.
- Feature release of recent project file improvements:
    - Project files now usable from Python API. 
    - `astproj` and `tracebld` support tracing for Cygwin projects, gcc, and rustc.

# Release 0.4.9

- Fix errors in Go parser.
- Implemented `Expands` and `ExpandedBy` relationships between macro and statement blocks for C and C++.

# Release 0.4.8

- Test release to validate pipeline improvements. No user-visible changes.

# Release 0.4.7

- Improvements to documentation and placement of [CONTRIBUTING.md](CONTRIBUTING.md).

# Release 0.4.6

- Fix bug C preprocessor concatenation logic.
- Improve handling in astproj for gcc and forked cywgin processes.

# Release 0.4.5

- Improved support in tracebld for Cygwin processes in builds.

# Release 0.4.4

- Fix error in CI pipeline that excluded tracebld.exe from Astred.Tools.

# Release 0.4.3

- Correct broken AstPoint behavior which broke slicing. Removed encoding entirely from AstPoint.

# Release 0.4.2

- Added support for parsing symbols from C and C++ header files. Previously Astred only supported parsing for preprocessor commands from header files.
- Changed C C++ parser to accept comma operator inside `decltype` expressions.
- TraceBld now collects arguments and environment variables passed between Cygwin processes.
- Astproj now has rudimentary support for processing GCC command lines.
- Created Accessed/AccessedBy relation for function pointers.
- Fixed parsing of unnamed reference parameters in C++.
- Significant robustness improvements in `tracebld` and `astproj`.  
- Added `tracebld` support for Cygwin unix-style processes on Windows.
- Added initial `astproj` support for parsing GCC command lines.
- Correct simplification of `.` path names in Astproj. #967
- Digest .zip file creation and parsing from digests supported
- Project files' paths are referenced to the current repo directory. 
- Improved error and warning messages from AstProj.
- Added support for rustc to AstProj.

# Release 0.4.1

- AstPoint.row and AstPoint.column have both been widened to 32 bits--no more errors for columns over 2048 or lines over 2,097,152.
- Fix error in path construction for "astred -project:project.json ..." 
- Added full Rust support for generics.

# Release 0.3.11

- Added check and warning if Astred.Core is used without Astred.Tools installed.

# Release 0.3.10

- Remove trailing slash and backslash characters from include paths in `tracebld`. 
- Fixed `tracebld` error which caused @response files to lose their first character.
- Improvements to reduce race conditions in flushing pipelines in `tracebld`.

# Release 0.3.9

- Test release to validate pipeline improvements. No user-visible changes.

# Release 0.3.8

- Test release to validate pipeline improvements. No user-visible changes.

# Release 0.3.7

- Test release to validate pipeline improvements. No user-visible changes.

# Release 0.3.6

- Add missing *.runtimeconfigs.json files for secondary tools packaged in Astred.Tools.

# Release 0.3.5
- Add `-version` to Astred command line to dump version and locations of key Astred components.
- Add `[external] [args]` option to Astred command line to run secondary tools packaged in Astred.Tools.

# Release 0.3.4

- Fixed handling of fully qualified class names in C++.
- C++ template functions overloads supported.
- Correct embedded path bug in TraceBld.
- Added version information to Astred assemblies.

# Release 0.3.3

- Corrected location of Doxygen documentation distributed with Astred.Tools.  Now resides in docs/html, not docs/html/html.
- Command to install add Astred feed to nuget and dotnet: `dotnet nuget add source https://pkgs.dev.azure.com/FoSSE/_packaging/FoSSE/nuget/v3/index.json`
- Command to install Astred.Tools: `dotnet tool install --global Astred.Tools`
- Command to uninstall Asted.Tools: `dotnet tool uninstall --global Astred.Tools`

# Release 0.3.2

- Deprecated OS+Architecture specific nuget packages. We now release only the multi-system Astred.Core, with support for Windows, Linux, and Mac OSX and for x64 and Arm64.
- Initial release of Astred.Tool dotnet tools package.
- Astred.Core can now locate the system-specific Tree-sitter DLLs either from the co-located runtimes/os-arch/native tree or from the runtimes/os-arch/native tree co-located with Astred.Tools.
- Begin packaging Doxygen documentation for Astred in Astred.Tools package.

# Release 0.3.1

- Fixed an issue in C# where enum bindings across multiple files were not binding correctly.
- Corrected a problem in C# where enum bindings were not binding as expected within a binary operator.
- Added more types to move Java parser to M3 level.
- Moving Go parsing to M2.
- Blocks type definitions completed in Java and corpus test coverage at 93.3% for M3.
- Added support for symbolic binding in field initializers for C++.
- Fixed a bug affecting the TypeFor/TypeOf relationship in C++ types with modifiers.
- Enhanced symbolic information for template classes in C++.
- Improved parsing of range-based for loops in C++.
- Fixed class/constructor type symbol bug in C++.
- Rust support for type inference in generic structs and functions, and partial support for generic impl
- Added Rust type definitions

# Release 0.3.0

- Added support for project files (.astred.project.json)--documents source files and environment such as predefined macros and include paths.
- Added -project:file option to astred.exe to load a project.
- Added astproj tool to create projects--either for tracebld logs or from command-line parameters.
- Added GraphProject, GraphFile, and GraphContext classes to describe a multi-file project.
- Added GraphLanguage enum to specify the language of a source file.
- Enhanced parsing for function overloads in C++.
- Introduced invocation blocks for property access in C#.
- Implemented blocks for enum members in C#.
- Fixed a bug related to binding functions with identical names in both local namespace and external imports in C#.
- Adding more type_declaration parsing for binding symbols in Java.
- Adding support for underscore pattern declarations in Java.
- Implemented blocks for statements and basic declarations in blocks in Java parser.
- Added template function and template class declaration parsing.
- Protocol Buffers (protobufs) parser introduced and upgraded to M2.
- Adding support of array declarations in type patterns expressions in Java.
- Adding support for do, try-catch-finally, break, continue in Java.
- Updated corpus tests in Java to include unused tokens. The coverage now is 93%.
- Added support for COBOL `EXEC` statements and improved `comment_entry` lexing.
- Fixed a bug in C++ where a base class and its derived classes, despite being defined in different namespaces, shared the same name, leading to unexpected behavior.

# Release 0.2.16

- Added Python samples for using the pip package.
- Added array types support to Astred parser of Java language.
- Fixed DPX.cpp parsing bug.
- Added Rust slice patterns and typed self.

# Release 0.2.15

- Added AstCursor object for sequentially accessing all of the nodes in an AST.
- Added GraphLanguage enum, to override selection of parser for a file.
- Add exeception catching in parsers. Any exceptions thrown during parsing will be converted to BlockError blocks in the dependency graph.
- Added block creation for lambda expressions in C++.
- Inferred type for variables declared as `auto` in C++.
- Bound function return types to the function's trailing return types, if available, in C++.

# Release 0.2.14

- Added Text parser (.txt) for supporting plain text files.  M2.

# Release 0.2.13

- C++ function overloads supported

# Release 0.2.12

- C# parser upgraded to M4.
- Added `./CHANGELOG.md` to repo and `Astred.CHANGELOG.md` to NuGet packages.
- Missing tree-sitter-ini.dll added to package.

# Release 0.2.11

- Added `BlockValue` class and `BlockType.Value` enum for accessing values in configuration languages.
- Ini parser (for .ini) introduced and upgraded to M1.
- Improvements to documentation for using and modifying Astred.

# Release 0.2.10

- Include `Astred.README.md` in deployed Nuget packages.
- Include `Astred.AstLib.xml` in deployed Nuget packages, enabling inline documentation for users.
- Inline debugging information into `Astred.*.dll` assemblies and add
  [SourceLink](https://learn.microsoft.com/en-us/dotnet/standard/library-guidance/sourcelink)
  information to improve debugging for users without needed a local copy of the Astred repo.
- Added `README.md` for TraceBld.
- Moved telemetry collection from `Astred.exe` to the Astred.Core package to measure number of lines
  of code parsed by Astred.  Added dependency on OpenTelemetery for measurement.

# Release 0.2.9

- Added BlockFilterAction to Python wrapper.
- Updates to `.csprojs` files for Astred C# Samples to demonstrate how to use the OS-agnostic
  Astred.Core NuGet package.
- Improvements to C# overloading and name mangling.

# Release 0.2.8

- Minor edits to Astred C# Samples.

# Release 0.2.7

- Moved `README.md` for developers working *on* Astred to `src/README.md`
- Simplified `.\READMME.md` to focus on the needs of Astred users.
- Fixed error in Python package naming.

# Release 0.2.6

- Test release to validate pipeline improvements. No user-visible changes.

# Release 0.2.5

- Test release to validate pipeline improvements. No user-visible changes.

# Release 0.2.4

- Test release to validate pipeline improvements. No user-visible changes.

# Release 0.2.3

- Test release to validate pipeline improvements. To evaluate symbol release formats.

# Release 0.2.2

- First OS-agnostic release of Astred.Core. We now release 5 Astred.Core packages:
  - `Astred.Core` package including native Tree-sitter DLLs with support for `win-x64`,
    `linux-x64`, `osx-x64`, and `osx-arm64`.
  - `Astred.Core.win-x64` package Windows.
  - `Astred.Core.linux-x64` package Linux.
  - `Astred.Core.osx-x64` package for Mac OS-X with X64 processors.
  - `Astred.Core.osx-arm64` package for Mac OS-X with ARM64 processors.
- Upgraded our release process to use Nuget 6.x.
- Added SourceLink information for C# binaries.
- Added version resources and version numbers to Windows `tree-sitter-*` DLLs.

# Release 0.2.1

- Added `README.md` and icon to Nuget package.
- New C# samples for building and slicing dependency graph using Astred.Core NuGet package.  See `./samples`.
- Change in preview package numbering ot `.major.minor.patch-preview.build`
- Improved symbolic linking for C# generic methods and classes

using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;
using MessagePack;
using MessagePack.Internal;
using UnityEngine.Scripting;

[assembly: InternalsVisibleTo("Pug.Tests")]
[assembly: GeneratedAssemblyMessagePackResolver(typeof(GeneratedMessagePackResolver), 3, 1)]
[assembly: AlwaysLinkAssembly]
[assembly: AssemblyVersion("0.0.0.0")]

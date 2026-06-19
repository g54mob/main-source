using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;
using Unity.Entities;
using Unity.Properties;

[assembly: GeneratePropertyBagsForTypesQualifiedWith(typeof(ISharedComponentData), TypeGenerationOptions.Default)]
[assembly: GeneratePropertyBagsForTypesQualifiedWith(typeof(IComponentData), TypeGenerationOptions.ReferenceType)]
[assembly: AssemblyVersion("0.0.0.0")]

using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;
using Pug.ECS.Components.Generated;
using Unity.Entities;
using Unity.Jobs;
using Unity.NetCode;
using UnityEngine.Scripting;

[assembly: RegisterGenericComponentType(typeof(InputBufferData<ClientInputData>))]
[assembly: RegisterGenericSystemType(typeof(ApplyCurrentInputBufferElementToInputDataSystem<ClientInputData, ClientInputDataEventHelper>))]
[assembly: RegisterGenericSystemType(typeof(CopyInputToCommandBufferSystem<ClientInputData, ClientInputDataEventHelper>))]
[assembly: RegisterGenericJobType(typeof(ApplyInputDataFromBufferJob<ClientInputData, ClientInputDataEventHelper>))]
[assembly: RegisterGenericJobType(typeof(CopyInputToBufferJob<ClientInputData, ClientInputDataEventHelper>))]
[assembly: AlwaysLinkAssembly]
[assembly: AssemblyVersion("0.0.0.0")]

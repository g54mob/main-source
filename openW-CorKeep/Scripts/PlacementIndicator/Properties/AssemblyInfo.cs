using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using FixedTickInterpolation;
using PlacementIndicator;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine.Scripting;

[assembly: RegisterGenericSystemType(typeof(FixedTickInterpolationSwapSystem<PlacementIndicatorInterpolatedStateCD, PlacementIndicatorInterpolatedValueCD, PlacementIndicatorCurrentStateCD>))]
[assembly: RegisterGenericJobType(typeof(FixedTickInterpolationSwapSystem<PlacementIndicatorInterpolatedStateCD, PlacementIndicatorInterpolatedValueCD, PlacementIndicatorCurrentStateCD>.SwapInterpolatedJob))]
[assembly: RegisterGenericSystemType(typeof(FixedTickInterpolationSmoothingSystem<PlacementIndicatorInterpolatedStateCD, PlacementIndicatorInterpolatedValueCD, PlacementIndicatorCurrentStateCD>))]
[assembly: RegisterGenericJobType(typeof(FixedTickInterpolationSmoothingSystem<PlacementIndicatorInterpolatedStateCD, PlacementIndicatorInterpolatedValueCD, PlacementIndicatorCurrentStateCD>.SmoothJob))]
[assembly: AlwaysLinkAssembly]
[assembly: AssemblyVersion("0.0.0.0")]

using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AmbulanceRoute
	{
		public AmbulanceConfig.Type RouteType = AmbulanceConfig.Type.Road;

		public SharedInstance<AmbulanceEmergencyLocation> Destination;

		public List<Vector2> Junctions;
	}
}

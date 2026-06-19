using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20.UI
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CoordinateRetrieverConfig
	{
		public Sprite Map;

		public GameObject ControlPointPrefab;

		public SharedInstance<AmbulanceRoute> Route;
	}
}

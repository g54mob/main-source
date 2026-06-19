using FullInspector;
using UnityEngine;

namespace TH20
{
	public class PlayerAmbulanceDepartmentDefinition : AmbulanceDepartmentDefinition
	{
		public SharedInstance<PlayerFoundationDefinition> PlayerFoundationDefinition;

		public GameObject AmbulanceStatusUIPrefab;
	}
}

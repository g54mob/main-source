using FullInspector;
using UnityEngine;

namespace TH20
{
	public class AmbulanceDepartmentDefinition
	{
		public SharedInstance<AmbulanceConfig>[] AmbulanceConfigs;

		public Vector2 Location;

		public SharedInstance<AmbulanceRoute>[] RoutesFromDepartment;
	}
}

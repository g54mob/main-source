using UnityEngine;

namespace EasyRoads3Dv3
{
	public class ERPrefabInstance : MonoBehaviour
	{
		public SideObject so;

		public ERSORoadExt soData;

		public double id;

		public ERModularRoad roadScript;

		public bool buildFlag;

		public bool locked = false;
	}
}

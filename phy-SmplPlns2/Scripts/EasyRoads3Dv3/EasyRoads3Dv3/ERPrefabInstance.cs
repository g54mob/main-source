using UnityEngine;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class ERPrefabInstance : MonoBehaviour
	{
		public SideObject so;

		public GameObject prefab;

		public ERSORoadExt soData;

		public double id;

		public ERModularRoad roadScript;

		public bool buildFlag;

		public bool locked = false;

		public bool child = false;

		public int sectionIndex = -1;

		public void Copy(ERPrefabInstance source)
		{
			if (source != null)
			{
				so = source.so;
				prefab = source.prefab;
				soData = source.soData;
				roadScript = source.roadScript;
				buildFlag = source.buildFlag;
				locked = source.locked;
				child = source.child;
				sectionIndex = source.sectionIndex;
			}
		}
	}
}

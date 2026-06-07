using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	[HelpURL("https://www.easyroads3d.com/v3/html/side_objects.html")]
	public class ERSideObjectSection : MonoBehaviour
	{
		public ERModularRoad road;

		public int sectionListIndex = 0;

		public int sectionIndex = 0;

		public double soId = 0.0;

		public SideObject so = null;

		public int leftright = 0;

		public bool mirrored;

		[HideInInspector]
		public List<float> distances = new List<float>();

		[HideInInspector]
		public List<Vector3> points = new List<Vector3>();

		public void Copy(ERSideObjectSection source)
		{
			road = source.road;
			sectionListIndex = source.sectionListIndex;
			sectionIndex = source.sectionIndex;
			soId = source.soId;
			leftright = source.leftright;
			mirrored = source.mirrored;
		}

		public void SetSideObject(ERModularBase scr)
		{
			for (int i = 0; i < scr.QOQDQOOQDDQOOQ.Count; i++)
			{
				if (scr.QOQDQOOQDDQOOQ[i].id == soId)
				{
					so = scr.QOQDQOOQDDQOOQ[i];
					break;
				}
			}
		}
	}
}

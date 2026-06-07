using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DV.Localization.Debug
{
	public class BookletPlacer : MonoBehaviour
	{
		public GameObject[] spots;

		public GameObject[] booklets;

		public void Arrange()
		{
			for (int i = 0; i < booklets.Length; i++)
			{
				booklets[i].transform.SetPositionAndRotation(spots[i].transform.position, spots[i].transform.rotation);
			}
		}

		public void OrderSpots()
		{
			IEnumerable<GameObject> source = from s in spots.ToList()
				where Local(s.transform.position).z > 0f
				select s;
			IEnumerable<GameObject> source2 = from s in spots.ToList()
				where Local(s.transform.position).z < 0f
				select s;
			source = (from s in source
				orderby Local(s.transform.position).y, Local(s.transform.position).x
				select s).ToList();
			source2 = (from s in source2
				orderby Local(s.transform.position).y, Local(s.transform.position).x
				select s).ToList();
			spots = source.Concat(source2).ToArray();
			Vector3 Local(Vector3 pos)
			{
				return base.transform.InverseTransformPoint(pos);
			}
		}
	}
}

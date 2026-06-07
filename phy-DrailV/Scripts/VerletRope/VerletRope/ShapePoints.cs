using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VerletRope
{
	public class ShapePoints : MonoBehaviour
	{
		public int crossSectionNumPoints = 8;

		public float diameter = 0.05f;

		private void Start()
		{
			DumpData();
		}

		[ContextMenu("Dump data")]
		private void DumpData()
		{
			IEnumerable<string> values = from p in GeneratePoints()
				select $"            new float3({p.x:#.000}f, {p.y:#.000}f, 0),";
			Debug.Log(string.Join("\n", values));
		}

		private Vector3[] GeneratePoints()
		{
			Vector3[] array = new Vector3[crossSectionNumPoints + 1];
			for (int i = 0; i < array.Length; i++)
			{
				float num = (float)i / (float)(array.Length - 1);
				Vector3 vector = Vector3.up * diameter * 0.5f;
				array[i] = Quaternion.Euler(0f, 0f, -360f * num) * vector;
			}
			return array;
		}
	}
}

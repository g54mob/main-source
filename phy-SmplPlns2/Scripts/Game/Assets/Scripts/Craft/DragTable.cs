using Assets.Scripts.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class DragTable
	{
		public float[] Values = new float[6];

		public float CalculateDragCoefficientTimesArea(PartDrag drag)
		{
			float[] drag2 = drag.GetDrag();
			return ((Values[0] > 0f) ? (Values[0] * drag2[0]) : 0f) + ((Values[1] > 0f) ? (Values[1] * drag2[1]) : 0f) + ((Values[2] > 0f) ? (Values[2] * drag2[2]) : 0f) + ((Values[3] > 0f) ? (Values[3] * drag2[3]) : 0f) + ((Values[4] > 0f) ? (Values[4] * drag2[4]) : 0f) + ((Values[5] > 0f) ? (Values[5] * drag2[5]) : 0f);
		}

		public float CalculateExposedArea(PartDrag drag)
		{
			float num = 0f;
			for (int i = 0; i < 6; i++)
			{
				if (Values[i] > 0f)
				{
					num += Values[i] * drag.GetArea((PartDrag.DragDirection)i);
				}
			}
			return num;
		}

		public void Clear()
		{
			for (int i = 0; i < 6; i++)
			{
				Values[i] = 0f;
			}
		}

		public void SetValuesFromVector(Vector3 v)
		{
			Values[0] = Mathf.Sign(v.z) * v.z * v.z;
			Values[1] = (0f - Mathf.Sign(v.z)) * v.z * v.z;
			Values[4] = (0f - Mathf.Sign(v.x)) * v.x * v.x;
			Values[5] = Mathf.Sign(v.x) * v.x * v.x;
			Values[2] = Mathf.Sign(v.y) * v.y * v.y;
			Values[3] = (0f - Mathf.Sign(v.y)) * v.y * v.y;
		}
	}
}

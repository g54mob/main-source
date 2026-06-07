using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class OCCCDCDQDC : MonoBehaviour
	{
		public static void OCODODDOQO(ERSideWalk sw, ref List<Vector3> vecs, Vector3 startVec, int rows, int closedVecCountStart, int closedVecCountEnd, int startEnd)
		{
			float num = 2f;
			float num2 = Random.Range(sw.minEnd, sw.maxEnd);
			if (num2 == 1f)
			{
				return;
			}
			if (startEnd == 0)
			{
				for (int i = 0; i < vecs.Count; i += rows)
				{
					float num3 = Vector3.Distance(startVec, vecs[i]);
					if (num3 < 2f)
					{
						float t = num3 / 2f;
						for (int j = 0; j < rows; j++)
						{
							Vector3 value = vecs[i + j];
							value.y = Mathf.Lerp(value.y * num2, value.y, t);
							vecs[i + j] = value;
						}
						continue;
					}
					break;
				}
			}
			for (int k = closedVecCountStart; k < closedVecCountEnd; k++)
			{
				Vector3 value2 = vecs[k];
				value2.y *= num2;
				vecs[k] = value2;
			}
		}
	}
}

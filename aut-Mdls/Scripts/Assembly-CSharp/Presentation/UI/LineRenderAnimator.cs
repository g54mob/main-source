using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Presentation.UI
{
	public class LineRenderAnimator
	{
		public IEnumerator AnimateLoop(LineRenderer lineRenderer, float movementPerTick = 0.002f)
		{
			while (true)
			{
				List<GradientColorKey> list = RemoveFirstAndLastColorKey(lineRenderer.colorGradient);
				float num = 0f;
				float num2 = 1f;
				int highestIndex = list.Count - 1;
				int lowestIndex = 0;
				for (int i = 0; i < list.Count; i++)
				{
					GradientColorKey value = list[i];
					float num3 = value.time + movementPerTick;
					if (num3 > 1f)
					{
						num3 -= 1f;
					}
					value.time = num3;
					list[i] = value;
					if (num3 < num2)
					{
						num2 = num3;
						lowestIndex = i;
					}
					if (num3 > num)
					{
						num = num3;
						highestIndex = i;
					}
				}
				Color intersectionColor = GetIntersectionColor(list, lowestIndex, highestIndex);
				list.Insert(0, new GradientColorKey(intersectionColor, 0f));
				list.Add(new GradientColorKey(intersectionColor, 1f));
				Gradient colorGradient = lineRenderer.colorGradient;
				colorGradient.colorKeys = list.ToArray();
				lineRenderer.colorGradient = colorGradient;
				yield return null;
			}
		}

		public Gradient AddInitialCopy(Gradient incomingGradient)
		{
			List<GradientColorKey> list = new List<GradientColorKey>(incomingGradient.colorKeys);
			Color color = list[0].color;
			list.Insert(0, new GradientColorKey(color, 0f));
			return new Gradient
			{
				colorKeys = list.ToArray()
			};
		}

		public Color GetIntersectionColor(List<GradientColorKey> incomingKeys, int lowestIndex, int highestIndex)
		{
			Color color = incomingKeys[lowestIndex].color;
			Color color2 = incomingKeys[highestIndex].color;
			float num = 1f - (incomingKeys[highestIndex].time - incomingKeys[lowestIndex].time);
			float t = (1f - incomingKeys[highestIndex].time) / num;
			return Color.Lerp(color2, color, t);
		}

		public List<GradientColorKey> RemoveFirstAndLastColorKey(Gradient incomingGradient)
		{
			List<GradientColorKey> list = new List<GradientColorKey>(incomingGradient.colorKeys);
			list.RemoveAt(list.Count - 1);
			list.RemoveAt(0);
			return list;
		}
	}
}

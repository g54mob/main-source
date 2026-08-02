using System.Collections.Generic;
using UnityEngine;

namespace Rowlan.Yapp
{
	public class InterpolateExt : Interpolate
	{
		public static IEnumerable<Vector3> NewBezier(EaseType easeType, ControlPoint[] nodes, int slices)
		{
			Vector3[] array = new Vector3[nodes.Length];
			for (int i = 0; i < nodes.Length; i++)
			{
				array[i] = nodes[i].position;
			}
			return Interpolate.NewBezier(Interpolate.Ease(easeType), array, slices);
		}

		public static IEnumerable<Vector3> NewCatmullRom(ControlPoint[] nodes, int slices, bool loop)
		{
			return Interpolate.NewCatmullRom<ControlPoint>(nodes, ControlPointDotPosition, slices, loop);
		}

		private static Vector3 ControlPointDotPosition(ControlPoint controlPoint)
		{
			return controlPoint.position;
		}
	}
}

using UnityEngine;

namespace WaveHarmonic.Crest
{
	internal static class BoundsHelper
	{
		internal static void DebugDraw(this Bounds b)
		{
			float x = b.min.x;
			float y = b.min.y;
			float z = b.min.z;
			float x2 = b.max.x;
			float y2 = b.max.y;
			float z2 = b.max.z;
			Debug.DrawLine(new Vector3(x, y, z), new Vector3(x, y, z2));
			Debug.DrawLine(new Vector3(x, y, z), new Vector3(x2, y, z));
			Debug.DrawLine(new Vector3(x2, y, z2), new Vector3(x, y, z2));
			Debug.DrawLine(new Vector3(x2, y, z2), new Vector3(x2, y, z));
			Debug.DrawLine(new Vector3(x, y2, z), new Vector3(x, y2, z2));
			Debug.DrawLine(new Vector3(x, y2, z), new Vector3(x2, y2, z));
			Debug.DrawLine(new Vector3(x2, y2, z2), new Vector3(x, y2, z2));
			Debug.DrawLine(new Vector3(x2, y2, z2), new Vector3(x2, y2, z));
			Debug.DrawLine(new Vector3(x2, y2, z2), new Vector3(x2, y, z2));
			Debug.DrawLine(new Vector3(x, y, z), new Vector3(x, y2, z));
			Debug.DrawLine(new Vector3(x2, y, z), new Vector3(x2, y2, z));
			Debug.DrawLine(new Vector3(x, y2, z2), new Vector3(x, y, z2));
		}
	}
}

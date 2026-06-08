using System;
using UnityEngine;

namespace GRP
{
	public class HandleBuildContext
	{
		public float dis;

		public float startValue;

		public Vector3 startPosition;

		public Vector3 direction;

		public PartHandle partHandle;

		public AxisHandle handle;

		public static HandleBuildContext current;

		public static void Build(PartHandle partHandle, AxisHandle handle, Func<HandleBuildOptions> getOp, bool dontUndo = false)
		{
		}
	}
}

using System;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class UMAUVAttachedItemBlendshapeAdjuster
	{
		public string BlendshapeName;

		public string RaceName;

		public Vector3 newOffset;

		public Vector3 newOrientation;

		public UMAUVAttachedItemBlendshapeAdjuster(string blendshapeName, string raceName, Vector3 newOffset, Vector3 newOrientation)
		{
		}

		public UMAUVAttachedItemBlendshapeAdjuster(UMAUVAttachedItemBlendshapeAdjuster src)
		{
		}
	}
}

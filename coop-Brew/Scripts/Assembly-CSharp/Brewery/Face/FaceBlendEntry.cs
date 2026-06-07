using System;
using UnityEngine;

namespace Brewery.Face
{
	[Serializable]
	public struct FaceBlendEntry
	{
		public string blendshape;

		[Range(0f, 1f)]
		public float weight;
	}
}

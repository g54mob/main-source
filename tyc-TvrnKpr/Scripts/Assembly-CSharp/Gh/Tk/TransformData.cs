using System;
using UnityEngine;

namespace Gh.Tk
{
	[Serializable]
	public struct TransformData
	{
		public Vector3 position;

		public Quaternion rotation;

		public Vector3 localScale;
	}
}

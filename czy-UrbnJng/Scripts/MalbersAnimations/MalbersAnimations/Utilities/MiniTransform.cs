using System;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[Serializable]
	public class MiniTransform
	{
		public string name = "bone";

		public Vector3 Position;

		public Vector3 Scale;

		public MiniTransform(string n, Vector3 p, Vector3 s)
		{
			name = n;
			Position = p;
			Scale = s;
		}
	}
}

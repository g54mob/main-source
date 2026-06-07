using System;
using UnityEngine;

namespace AwesomeTechnologies
{
	[Serializable]
	public class Node
	{
		public bool Selected;

		public Vector3 Position;

		public bool OverrideWidth;

		public float CustomWidth = 2f;

		public bool Active = true;
	}
}

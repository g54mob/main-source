using System;
using UnityEngine;

namespace TinyGiantStudio.Text
{
	[Serializable]
	public class Character
	{
		public char character;

		public GameObject prefab;

		public Mesh meshPrefab;

		public int glyphIndex;

		public float spacing;

		public int leftSideBearing;

		public Vector3 offset;

		public float xOffset;

		public float yOffset;

		public float zOffset;
	}
}

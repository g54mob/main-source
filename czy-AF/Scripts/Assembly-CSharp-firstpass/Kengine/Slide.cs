using System;
using UnityEngine;

namespace Kengine
{
	[Serializable]
	public class Slide
	{
		public string title;

		public Texture2D image;

		public float time = 1f;

		public Color color = Color.black;

		public bool skip = true;
	}
}

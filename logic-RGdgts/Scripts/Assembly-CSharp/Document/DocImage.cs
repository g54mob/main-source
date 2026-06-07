using System;
using UnityEngine;

namespace Document
{
	[Serializable]
	public struct DocImage
	{
		public Sprite image;

		public string imagePath;

		public DocElementPosition position;

		public DocumentElementsColor color;

		public bool createObject;
	}
}

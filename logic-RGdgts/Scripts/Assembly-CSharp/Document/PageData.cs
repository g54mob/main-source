using System;
using System.Collections.Generic;
using UnityEngine;

namespace Document
{
	[Serializable]
	public class PageData
	{
		public int pageNumber;

		public DocImage background;

		public List<DocText> texts;

		public List<DocImage> images;

		public Vector4 bordersTBLR;

		public void Init(int pageNumber, List<DocText> texts, List<DocImage> images, Vector4 bordersTBLR, DocImage background)
		{
		}
	}
}

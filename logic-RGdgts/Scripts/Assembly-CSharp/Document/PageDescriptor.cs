using System;
using UnityEngine;

namespace Document
{
	[Serializable]
	public struct PageDescriptor
	{
		public string pageName;

		public GameObject pageLayoutPrefab;

		public PageData pageData;

		public PageDescriptor(GameObject pageLayoutPrefab, PageData pageData, string pageName)
		{
			this.pageName = null;
			this.pageLayoutPrefab = null;
			this.pageData = null;
		}
	}
}

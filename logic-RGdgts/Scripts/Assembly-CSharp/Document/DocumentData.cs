using System.Collections.Generic;
using UnityEngine;

namespace Document
{
	[CreateAssetMenu]
	public class DocumentData : ScriptableObject
	{
		public Vector2 pageSize;

		public int pagesCount;

		public List<PageDescriptor> pages;
	}
}

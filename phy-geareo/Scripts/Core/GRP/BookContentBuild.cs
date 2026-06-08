using System;
using UnityEngine;

namespace GRP
{
	public class BookContentBuild
	{
		public BookPaperContent prefab;

		public Texture texture;

		public int position;

		public bool canceled;

		public Action<BookContentBuild> onResult;

		public void HandleResult(Texture texture)
		{
		}
	}
}

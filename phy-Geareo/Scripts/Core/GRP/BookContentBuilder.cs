using System.Collections.Generic;
using Rhizomatic.Pooling;
using UnityEngine;

namespace GRP
{
	[RequireComponent(typeof(ObjectPool))]
	public class BookContentBuilder : MonoBehaviour
	{
		public Transform container;

		public Texture loadingTexture;

		public Vector2Int textureSize;

		private List<BookContentBuild> queue;

		private BookPaperContent currentContent;

		private BookContentBuild waitingBuild;

		private Dictionary<BookPaperContent, Texture> textures;

		private ObjectPool pool;

		private void Awake()
		{
		}

		private void LateUpdate()
		{
		}

		public BookContentBuild Build(BookPaperContent contentPrefab, int position)
		{
			return null;
		}

		public void Cancel(BookContentBuild build)
		{
		}
	}
}

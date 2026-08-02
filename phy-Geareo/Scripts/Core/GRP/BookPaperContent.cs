using Rhizomatic.Pooling;
using Rhizomatic.UI;
using UnityEngine;

namespace GRP
{
	public class BookPaperContent : PoolObject
	{
		public Camera camera;

		public TextAdapter[] pageNumbers;

		private BookContentBuilder builder;

		public RenderTexture renderTexture { get; private set; }

		public void Setup(BookContentBuilder builder, BookContentBuild build)
		{
		}
	}
}

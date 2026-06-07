using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Spine
{
	public class Atlas : IEnumerable<AtlasRegion>, IEnumerable
	{
		private readonly List<AtlasPage> pages;

		private List<AtlasRegion> regions;

		private TextureLoader textureLoader;

		public List<AtlasRegion> Regions => null;

		public List<AtlasPage> Pages => null;

		public IEnumerator<AtlasRegion> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public Atlas(List<AtlasPage> pages, List<AtlasRegion> regions)
		{
		}

		public Atlas(TextReader reader, string imagesDir, TextureLoader textureLoader)
		{
		}

		private static int ReadEntry(string[] entry, string line)
		{
			return 0;
		}

		public void FlipV()
		{
		}

		public AtlasRegion FindRegion(string name)
		{
			return null;
		}

		public void Dispose()
		{
		}
	}
}

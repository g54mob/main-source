namespace Spine
{
	public class AtlasPage
	{
		public string name;

		public int width;

		public int height;

		public Format format;

		public TextureFilter minFilter;

		public TextureFilter magFilter;

		public TextureWrap uWrap;

		public TextureWrap vWrap;

		public bool pma;

		public object rendererObject;

		public AtlasPage Clone()
		{
			return null;
		}
	}
}

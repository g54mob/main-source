namespace VampireSurvivors.Framework
{
	public struct SpriteAnimationData
	{
		public string SpriteNameStart;

		public int StartFrame;

		public int EndFrame;

		public string Texture;

		public SpriteAnimationData(string spriteNameStart, int startFrame, int endFrame, string texture)
		{
			SpriteNameStart = null;
			StartFrame = 0;
			EndFrame = 0;
			Texture = null;
		}
	}
}

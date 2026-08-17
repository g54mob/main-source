namespace VampireSurvivors.Framework;

public struct SpriteAnimationData
{
	public string SpriteNameStart;

	public int StartFrame;

	public int EndFrame;

	public string Texture;

	public SpriteAnimationData(string spriteNameStart, int startFrame, int endFrame, string texture)
	{
		SpriteNameStart = spriteNameStart;
		string texture2 = default(string);
		Texture = texture2;
		StartFrame = startFrame;
		EndFrame = endFrame;
	}
}

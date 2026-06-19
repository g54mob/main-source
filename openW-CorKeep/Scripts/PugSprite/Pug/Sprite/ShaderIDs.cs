using UnityEngine;

namespace Pug.Sprite
{
	public static class ShaderIDs
	{
		public static int GradientMapAtlas = Shader.PropertyToID("_GradientMapAtlas");

		public static int TransformAnimationTexture = Shader.PropertyToID("_TransformAnimationTexture");

		public static int SpriteTexture = Shader.PropertyToID("_SpriteTexture");

		public static int TransformAnimationTime = Shader.PropertyToID("_TransformAnimationTime");
	}
}

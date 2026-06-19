using System.Collections.Generic;
using UnityEngine;

namespace Pug.Sprite
{
	public class TransformAnimation : ScriptableDataBlock
	{
		public struct RuntimeData
		{
			public int index;

			public float duration;
		}

		private const int TEXTURE_WIDTH = 1024;

		public AnimationCurve scaleX = AnimationCurve.Constant(0f, 1f, 1f);

		public AnimationCurve scaleY = AnimationCurve.Constant(0f, 1f, 1f);

		public AnimationCurve rotation = AnimationCurve.Constant(0f, 1f, 0f);

		public float defaultDuration = 1f;

		private static Texture2D s_transformAnimationTexture;

		private static Dictionary<int, RuntimeData> s_lookup;

		public static void BuildAtlas(IReadOnlyList<TransformAnimation> transformAnimations)
		{
			if (transformAnimations == null || transformAnimations.Count < 1)
			{
				return;
			}
			if (s_transformAnimationTexture == null || s_transformAnimationTexture.height != transformAnimations.Count)
			{
				if (s_transformAnimationTexture != null)
				{
					Object.Destroy(s_transformAnimationTexture);
				}
				s_transformAnimationTexture = new Texture2D(1024, transformAnimations.Count, TextureFormat.RGBAHalf, mipChain: false, linear: true);
			}
			if (s_lookup == null)
			{
				s_lookup = new Dictionary<int, RuntimeData>();
			}
			else
			{
				s_lookup.Clear();
			}
			Color[] array = new Color[1024 * transformAnimations.Count];
			for (int i = 0; i < transformAnimations.Count; i++)
			{
				TransformAnimation transformAnimation = transformAnimations[i];
				if (transformAnimation == null)
				{
					Debug.LogError("Null entry in transform animation list!");
					continue;
				}
				for (int j = 0; j < 1024; j++)
				{
					float time = (float)j / 1023f;
					float r = transformAnimation.scaleX.Evaluate(time);
					float g = transformAnimation.scaleY.Evaluate(time);
					float b = transformAnimation.rotation.Evaluate(time);
					array[j + i * 1024] = new Color(r, g, b, 0f);
				}
				int key = SpriteAsset.StringToHash(transformAnimation.name);
				if (!s_lookup.ContainsKey(key))
				{
					s_lookup.Add(key, new RuntimeData
					{
						index = i,
						duration = transformAnimation.defaultDuration
					});
				}
			}
			s_transformAnimationTexture.SetPixels(array);
			s_transformAnimationTexture.Apply();
			UpdateShaderParameters();
		}

		public static bool TryGet(int hash, out RuntimeData result)
		{
			result = new RuntimeData
			{
				index = -1
			};
			if (s_lookup == null)
			{
				return false;
			}
			if (s_lookup == null)
			{
				return false;
			}
			return s_lookup.TryGetValue(hash, out result);
		}

		public static void UpdateShaderParameters()
		{
			if (s_transformAnimationTexture != null)
			{
				Shader.SetGlobalTexture(ShaderIDs.TransformAnimationTexture, s_transformAnimationTexture);
			}
		}
	}
}

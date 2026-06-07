using Unity.Mathematics;
using UnityEngine;

namespace VampireSurvivors.Framework.Phaser
{
	public class BitmapText : GameMonoBehaviour
	{
		private TextMesh _textRenderer;

		public float _originX;

		public float _originY;

		public TextMesh TextRenderer => null;

		private void Start()
		{
		}

		public void InternalForceInit()
		{
		}

		public BitmapText setName(string newName)
		{
			return null;
		}

		public BitmapText SetText(string text)
		{
			return null;
		}

		public BitmapText SetAlpha(float alpha)
		{
			return null;
		}

		public BitmapText SetColor(Color color)
		{
			return null;
		}

		public BitmapText SetTint(uint tint)
		{
			return null;
		}

		public BitmapText SetFontSize(int fontSize)
		{
			return null;
		}

		public BitmapText SetDepth(int depth)
		{
			return null;
		}

		public BitmapText SetFont(string fontPath)
		{
			return null;
		}

		public BitmapText setOrigin(float2 origin)
		{
			return null;
		}

		public BitmapText setOrigin(float originX = 0.5f, float? originY = null)
		{
			return null;
		}

		public BitmapText SetTextAlignments(TextAlignment textAlignment, TextAnchor textAnchor)
		{
			return null;
		}

		public void destroy()
		{
		}

		private void EnsureTextRenderer()
		{
		}
	}
}

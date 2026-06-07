using TMPro;
using Unity.Mathematics;
using UnityEngine;

namespace VampireSurvivors.Framework.Phaser
{
	public class PhaserText : GameMonoBehaviour
	{
		private TextMeshPro _textRenderer;

		public float _originX;

		public float _originY;

		public TextMeshPro TextRenderer => null;

		private void Start()
		{
		}

		public void InternalForceInit()
		{
		}

		public PhaserText SetText(string text)
		{
			return null;
		}

		public PhaserText UpdateDisplaySize()
		{
			return null;
		}

		public PhaserText SetAlpha(float alpha)
		{
			return null;
		}

		public PhaserText SetColor(Color color)
		{
			return null;
		}

		public PhaserText SetTint(uint tint)
		{
			return null;
		}

		public PhaserText SetFont(string fontPath)
		{
			return null;
		}

		public PhaserText SetFontSize(float fontSize)
		{
			return null;
		}

		public PhaserText SetDepth(int depth)
		{
			return null;
		}

		public PhaserText setOrigin(float2 origin)
		{
			return null;
		}

		public PhaserText setOrigin(float originX = 0.5f, float? originY = null)
		{
			return null;
		}

		public PhaserText SetTextAlignments(HorizontalAlignmentOptions x, VerticalAlignmentOptions y)
		{
			return null;
		}

		public PhaserText setName(string newName)
		{
			return null;
		}

		public PhaserText setVisible(bool visible)
		{
			return null;
		}

		public void destroy()
		{
		}

		private void EnsureTextRenderer()
		{
		}

		private void AssignDefaultFont()
		{
		}
	}
}

using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace VampireSurvivors.UI
{
	public class PixelateEffect : MonoBehaviour
	{
		[SerializeField]
		private Renderer2DData _forwardRendererData;

		private Material _pixelizer;

		private static readonly int CellSizeX;

		private static readonly int CellSizeY;

		private static readonly int PixelSize;

		private static readonly int TexSize;

		public Tween Pixelate(float startSize, float endSize, float duration = 1f, bool disableWhenFinished = true)
		{
			return null;
		}
	}
}

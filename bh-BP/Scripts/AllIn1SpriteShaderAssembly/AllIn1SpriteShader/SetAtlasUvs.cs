using UnityEngine;
using UnityEngine.UI;

namespace AllIn1SpriteShader
{
	public class SetAtlasUvs : MonoBehaviour
	{
		[SerializeField]
		private bool updateEveryFrame;

		private Renderer render;

		private SpriteRenderer spriteRender;

		private Image uiImage;

		private bool isUI;

		private readonly int minXuv;

		private readonly int maxXuv;

		private readonly int minYuv;

		private readonly int maxYuv;

		private readonly int xScale;

		private readonly int yScale;

		private void Start()
		{
		}

		private void Reset()
		{
		}

		public void Setup()
		{
		}

		public void GetAndSetUVs()
		{
		}

		public void ResetAtlasUvs()
		{
		}

		public void UpdateEveryFrame(bool everyFrame)
		{
		}

		private bool GetRendererReferencesIfNeeded()
		{
			return false;
		}
	}
}

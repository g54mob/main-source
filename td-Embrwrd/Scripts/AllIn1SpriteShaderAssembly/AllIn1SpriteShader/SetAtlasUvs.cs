using UnityEngine;
using UnityEngine.UI;

namespace AllIn1SpriteShader
{
	[ExecuteInEditMode]
	public class SetAtlasUvs : MonoBehaviour
	{
		[SerializeField]
		private bool updateEveryFrame;

		[Tooltip("If using a Sprite Renderer it will use the material property instead of sharedMaterial")]
		[SerializeField]
		private bool useMaterialInstanceIfPossible;

		private Renderer render;

		private SpriteRenderer spriteRender;

		private Image uiImage;

		private bool isUI;

		private readonly int minXuv;

		private readonly int maxXuv;

		private readonly int minYuv;

		private readonly int maxYuv;

		private void Start()
		{
		}

		private void Reset()
		{
		}

		private void Setup()
		{
		}

		private void LateUpdate()
		{
		}

		public bool GetAndSetUVs()
		{
			return false;
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

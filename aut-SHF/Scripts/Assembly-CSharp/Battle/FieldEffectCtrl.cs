using Libs;
using UnityEngine;

namespace Battle
{
	public class FieldEffectCtrl : SingletonMonoBehaviour<FieldEffectCtrl>
	{
		[SerializeField]
		private SpriteRenderer mapFrame;

		[SerializeField]
		private SpriteRenderer mapCenter;

		public ParticleSystem battleParticle;

		public ParticleSystem battleParticlesOutSide;

		public float particleDeray;

		[Label("ページアニメーター")]
		[SerializeField]
		private Animator magicBookAnimator;

		[SerializeField]
		private Renderer pageRenderer;

		private readonly int PAGE_BASE_MAP;

		[SerializeField]
		private SpriteRenderer _mapEffectSprite;

		[SerializeField]
		private Vector2 _mapEffectAdjustment;

		private ParticleSystem.ShapeModule _battleParticleShape;

		private ParticleSystem.ShapeModule _battleParticleOutShape;

		private static readonly string BOOK_OPEN;

		private static readonly string BOOK_STOP;

		private static readonly string BOOK_CLOSE;

		private void Awake()
		{
		}

		public void EffectPause()
		{
		}

		public void EffectPlay()
		{
		}

		public void AdjustmentMapEffect()
		{
		}

		public void OpenPage()
		{
		}

		public void SetPageTexture(RenderTexture value)
		{
		}

		public void StopTurnPage()
		{
		}

		public void CloseBook()
		{
		}

		public void ResetCloseBook()
		{
		}
	}
}

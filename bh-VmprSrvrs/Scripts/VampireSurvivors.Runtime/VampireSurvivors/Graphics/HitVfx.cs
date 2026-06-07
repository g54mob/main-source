using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace VampireSurvivors.Graphics
{
	public class HitVfx : GameMonoBehaviour
	{
		[FormerlySerializedAs("Hit")]
		[SerializeField]
		private SpriteRenderer _Hit;

		[FormerlySerializedAs("Impact")]
		[SerializeField]
		private SpriteRenderer _Impact;

		private Vector3 _baseHitScale;

		private Vector3 _baseImpactScale;

		private Vector3 _targetHitScale;

		private Vector3 _targetImpactScale;

		private Transform _hitTransform;

		private Transform _impactTransform;

		private Vector3 _targetRotation;

		private HitVFXData _data;

		private Sequence _tweens;

		private bool _tweensInitialised;

		private Sprite _defaultHitSprite;

		private Sprite _defaultImpactSprite;

		private Tween _doTween1;

		private Tween _doTween2;

		private Tween _doTween3;

		public void Awake()
		{
		}

		private void CacheDefaultSprites()
		{
		}

		private void Start()
		{
		}

		public void Play(Vector2 pos, HitVFXData data)
		{
		}

		private void SetData()
		{
		}

		private void PlayAnim()
		{
		}

		private void Despawn()
		{
		}
	}
}

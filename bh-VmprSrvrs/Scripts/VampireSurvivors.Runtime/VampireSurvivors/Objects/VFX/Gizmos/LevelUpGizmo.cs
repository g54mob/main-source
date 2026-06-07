using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.VFX.Gizmos
{
	public class LevelUpGizmo : PoolableMonoBehaviour
	{
		[SerializeField]
		private Transform _TextParent;

		[SerializeField]
		private SpriteRenderer _Blur;

		[HideInInspector]
		public float _YOffset;

		private ParticleEmitterManager _particleEmitterManager;

		private ParticleSystem _pfxEmitter;

		private VampireSurvivors.Objects.Characters.CharacterController _activePlayer;

		private bool _hasSetupEmitter;

		private bool _defaultBlurPositionSet;

		private Vector3 _blurDefaultLocalPosition;

		private Vector2 PlayerPos => default(Vector2);

		private void Update()
		{
		}

		public void Init(VampireSurvivors.Objects.Characters.CharacterController activePlayer)
		{
		}

		private void SetupEmitter()
		{
		}

		public void Play()
		{
		}

		private void AnimateLevelUpText()
		{
		}

		private MultiTargetTween AnimateBlur()
		{
			return null;
		}

		private void Despawn()
		{
		}
	}
}

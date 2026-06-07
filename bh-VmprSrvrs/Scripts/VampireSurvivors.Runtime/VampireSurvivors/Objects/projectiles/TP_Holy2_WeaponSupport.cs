using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Holy2_WeaponSupport : MonoBehaviour
	{
		[SerializeField]
		private Transform _pivotTransform;

		[SerializeField]
		private Transform _meshTransform;

		[SerializeField]
		private MeshRenderer _mesh;

		private static readonly int _InputColor;

		private static readonly int _AlphaMul;

		private Tween rotTween;

		private Sequence _windSequence;

		private Timer sanct1Timer;

		private Timer sanct2Timer;

		private bool canTrigger;

		private Timer retriggerTimer;

		private ParticleSystem _glitchEmitter;

		private Timer sanct3Timer;

		private TP_Holy2_Weapon _trueWeapon;

		public void Initialize()
		{
		}

		public void Trigger()
		{
		}

		private void CastComplete()
		{
		}

		private void DoSanctuaryEffect()
		{
		}

		private void RosaryDamage()
		{
		}

		private void MakeEmitters()
		{
		}

		public void SetVisible(bool visible)
		{
		}
	}
}

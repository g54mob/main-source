using Coherence.Toolkit;
using DG.Tweening;
using UnityEngine;

namespace VampireSurvivors.Objects.Items
{
	public class PickupMoongate : PickupGuarded
	{
		private SpriteRenderer _glow;

		private float _colorValue;

		private Tween _glowTween;

		private ParticleSystem _pfx;

		private PickupMoongate _linkedGate;

		private bool _canTeleport;

		private bool _canTeleportLocally;

		private const float TriggerDelay = 20000f;

		[Sync]
		public bool CanTeleport
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool CanTeleportLocally
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Sync]
		public GameObject Link
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override void Awake()
		{
		}

		public override void InternalUpdate()
		{
		}

		public void LinkTo(PickupMoongate moongate)
		{
		}

		public override void UpdateDepth()
		{
		}

		protected override void OnRecycle()
		{
		}

		private void UpdateGlowColor()
		{
		}

		public override void GetTaken()
		{
		}

		public override void GetOnlineTaken()
		{
		}

		private bool CheckCanTakeTeleport()
		{
			return false;
		}

		private void TempDisableTeleport()
		{
		}

		private void GenerateParticleSystem()
		{
		}
	}
}

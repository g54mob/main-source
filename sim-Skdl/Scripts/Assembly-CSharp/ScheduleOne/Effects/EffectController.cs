using FishNet.Object;
using UnityEngine;

namespace ScheduleOne.Effects
{
	public abstract class EffectController : NetworkBehaviour
	{
		protected float _distanceToPlayerNormalised;

		protected float _enclosureBlend;

		protected Vector3 _playerPosition;

		protected Vector3 _anchoredPosition;

		private bool NetworkInitialize___EarlyScheduleOne_002EEffects_002EEffectControllerAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002EEffects_002EEffectControllerAssembly_002DCSharp_002Edll_Excuted;

		public bool IsActive { get; protected set; }

		public abstract void Activate();

		public abstract void Deactivate();

		public virtual void UpdateProperties(Vector3 anchorPosition, Vector3 playerPosition, float sqrDistanceToPlayer, float enclosureBlend)
		{
		}

		public virtual void NetworkInitialize___Early()
		{
		}

		public virtual void NetworkInitialize__Late()
		{
		}

		public override void NetworkInitializeIfDisabled()
		{
		}

		public virtual void Awake()
		{
		}
	}
}

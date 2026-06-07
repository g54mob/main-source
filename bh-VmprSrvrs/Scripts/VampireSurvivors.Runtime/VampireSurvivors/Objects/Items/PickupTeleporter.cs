using System;
using System.Runtime.CompilerServices;
using Coherence.Toolkit;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Items
{
	public class PickupTeleporter : PickupGuarded
	{
		[Sync]
		[OnValueSynced("OnGateIndexChanged")]
		public int GateIndex;

		private bool _canTeleport;

		private bool _canTeleportLocally;

		private string _teleporterKey;

		private float _destinationX;

		private float _destinationY;

		private Tween _glowTween;

		private PickupTeleporter _link;

		protected PhaserSprite _door;

		protected bool _hasDoorAnimation;

		[Sync]
		public float _triggerDelay;

		private bool _teleporting;

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

		[Sync]
		public bool IsAstralSecretDoor { get; set; }

		[Sync]
		public string TeleporterKey
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public event Action<VampireSurvivors.Objects.Characters.CharacterController> OnTeleportStartedAction
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action OnTeleportFinishedAction
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<VampireSurvivors.Objects.Characters.CharacterController> OnPlayersTeleported
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected virtual void OnDrawGizmos()
		{
		}

		public override void SetData(ItemType itemType)
		{
		}

		public void SetTeleportKey(string teleportKey)
		{
		}

		protected override void OnUpdate()
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

		protected override void TrackItemPickup(bool trackRunPickup = true)
		{
		}

		public override void Despawn()
		{
		}

		public void ActuallyDespawn()
		{
		}

		public void LinkTo(PickupTeleporter gate)
		{
		}

		public void Disable()
		{
		}

		public void ForceDestination(float x, float y)
		{
		}

		protected virtual void OnGateIndexChanged(int oldValue, int newValue)
		{
		}

		protected override void OnRecycle()
		{
		}

		protected virtual void GenerateSpritesAndAnims()
		{
		}

		protected virtual void DoTeleportAnimation()
		{
		}

		private void OnTweenYoyo()
		{
		}

		public override void DisposeAsTaken()
		{
		}

		public void CleanUpCallbacks()
		{
		}

		private void StartTeleport()
		{
		}

		protected void DoTeleport()
		{
		}

		private float2 SecretCheck(float2 destinationPos, out bool secretFound)
		{
			secretFound = default(bool);
			return default(float2);
		}

		protected void OnTeleportFinished()
		{
		}

		private void CheckForWeapons(float2 destinationPos)
		{
		}
	}
}

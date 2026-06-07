using System.Collections.Generic;
using ModApi;
using ModApi.Audio;
using ModApi.Craft.Parts;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class FairingScript : PartModifierScript<FairingData>, IFlightUpdate, IGameLoopItem
	{
		private bool _disconnect;

		private bool _jettisonNextFrame;

		public GameObject LeftCollider => Utilities.FindFirstGameObjectMyselfOrChildren("Collider-2", base.gameObject);

		public GameObject LeftSide => Utilities.FindFirstGameObjectMyselfOrChildren("Mesh-2", base.gameObject);

		public GameObject RightCollider => Utilities.FindFirstGameObjectMyselfOrChildren("Collider-1", base.gameObject);

		public GameObject RightSide => Utilities.FindFirstGameObjectMyselfOrChildren("Mesh-1", base.gameObject);

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			if (_jettisonNextFrame)
			{
				InitiateJettison();
			}
		}

		public void GetConnectedFairings(PartData part, List<FairingData> fairings, bool includeBase)
		{
			foreach (PartConnection partConnection in base.PartScript.Data.PartConnections)
			{
				PartData otherPart = partConnection.GetOtherPart(base.PartScript.Data);
				if (otherPart != part)
				{
					FairingData modifier = otherPart.GetModifier<FairingData>();
					if (modifier != null && !partConnection.IsDestroyed && !modifier.Part.IsDestroyed && !modifier.Jettisoned && (includeBase || !modifier.FairingBase))
					{
						fairings.Add(modifier);
						modifier.Script.GetConnectedFairings(base.PartScript.Data, fairings, includeBase);
					}
				}
			}
		}

		public override void OnActivated()
		{
			base.OnActivated();
			if (base.Data.FairingBase && !base.Data.Jettisoned)
			{
				_jettisonNextFrame = true;
			}
		}

		public override bool OnCollision(IPartFlightCollision partCollision)
		{
			if ((partCollision.Impulse > base.PartScript.Data.Config.CollisionDisconnectImpulse || (base.PartScript.Data.Config.CollisionDisconnectVelocity > 0f && partCollision.NormalVelocity > base.PartScript.Data.Config.CollisionDisconnectVelocity && partCollision.IsGroundCollision)) && !_disconnect)
			{
				_disconnect = true;
				FairingScript fairingBase = GetFairingBase();
				if (fairingBase != null)
				{
					fairingBase._jettisonNextFrame = true;
				}
			}
			return true;
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
		}

		private FairingDebrisScript CreateFairingDebris(Vector3 direction)
		{
			GameObject obj = new GameObject("Fairing-Debris");
			obj.layer = 30;
			obj.transform.rotation = base.transform.rotation;
			FairingDebrisScript fairingDebrisScript = obj.AddComponent<FairingDebrisScript>();
			fairingDebrisScript.Initialize(base.PartScript.CraftScript, direction);
			return fairingDebrisScript;
		}

		private FairingScript GetFairingBase()
		{
			List<FairingData> list = new List<FairingData>();
			list.Add(base.Data);
			GetConnectedFairings(base.PartScript.Data, list, includeBase: true);
			foreach (FairingData item in list)
			{
				if (item.FairingBase)
				{
					return item.Script;
				}
			}
			return null;
		}

		private void InitiateJettison()
		{
			base.Data.Jettisoned = true;
			_jettisonNextFrame = false;
			List<FairingData> list = new List<FairingData>();
			list.Add(base.Data);
			GetConnectedFairings(base.PartScript.Data, list, includeBase: false);
			if (list.Count <= 0)
			{
				return;
			}
			FairingDebrisScript fairingDebrisScript = CreateFairingDebris(-base.transform.right);
			FairingDebrisScript fairingDebrisScript2 = CreateFairingDebris(base.transform.right);
			foreach (FairingData item in list)
			{
				fairingDebrisScript.AddFairing(item.Script);
				fairingDebrisScript2.AddFairing(item.Script);
				item.Jettisoned = true;
			}
			_ = base.PartScript.CraftScript.GravityForce;
			Vector3 velocity = base.PartScript.BodyScript.RigidBody.velocity;
			Vector3 forward = base.PartScript.Transform.forward;
			fairingDebrisScript.Jettison(velocity, forward * 0.25f * base.Data.JettisonSpin, 10f * base.Data.JettisonVelocity);
			fairingDebrisScript2.Jettison(velocity, forward * -0.25f * base.Data.JettisonSpin, 10f * base.Data.JettisonVelocity);
			foreach (FairingData item2 in list)
			{
				item2.Part.PartScript.BodyScript.OnPartMassChanged();
				item2.Part.PartScript.BodyScript.QueuePartGroupForDestruction(item2.Part.PartScript.PartGroup);
			}
			base.PartScript.CraftScript.InitiateDragRecalculation();
			Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Flight.FairingSeparation, base.transform.position, userInterfaceSound: false);
		}
	}
}

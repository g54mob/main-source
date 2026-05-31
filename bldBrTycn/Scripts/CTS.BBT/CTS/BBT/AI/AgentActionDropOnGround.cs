using System.Collections;
using CTS.AI;
using CTS.Core;
using UnityEngine;

namespace CTS.BBT.AI
{
	internal sealed class AgentActionDropOnGround : AgentAction<Agent>
	{
		private Vector3 _dropPosition;

		private MoveTarget _moveTarget;

		public AgentActionDropOnGround(Vector3 p_dropPosition)
		{
			_dropPosition = p_dropPosition;
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			return agentRef.ObjectHolding.IsCurrentlyHolding;
		}

		public override void OnStart()
		{
		}

		public override IEnumerator WaitForRoutine()
		{
			_moveTarget = MoveTarget.CreateNew(_dropPosition, Quaternion.identity, AgentPath.EDestinationType.LookAtDistance);
			yield return MoveToTarget(_moveTarget);
			if (base.ActionAgent.ObjectHolding.GetHeldObject<Item>().TryGetComponent<BodyBag>(out var component))
			{
				MonoSingleton<SoundManager>.Instance.PlayAudioAsset(component.AudioAsset);
			}
			Debug.Log("Use with Sewer to see if the sound play Two Times");
		}

		public override IEnumerator ActionRoutine()
		{
			yield return new WaitForSeconds(1f);
			Item heldObject = base.ActionAgent.ObjectHolding.GetHeldObject<Item>();
			if ((bool)heldObject)
			{
				Vector3 vector = base.ActionAgent.transform.position - _dropPosition;
				heldObject.transform.SetPositionAndRotation(_dropPosition, Quaternion.LookRotation(vector.normalized));
				heldObject.gameObject.SetActive(value: true);
				base.ActionAgent.ObjectHolding.DropObject();
				base.ActionAgent.ProceduralAnimator.DisableGrab();
			}
		}

		protected override void OnStopped()
		{
			MoveTarget.Clear(ref _moveTarget);
		}

		public override void OnCancel()
		{
		}
	}
}

using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class AgentPanicSpreader : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private Customer _customer;

		[SerializeField]
		private float _checkRadius;

		[SerializeField]
		private LayerMask _layerMask;

		private static NamedLayerMask _lineCastMask = new NamedLayerMask("Wall");

		private bool _panicking => _customer.ContextualFSM.CurrentStateEquals<ContextualStatePanicking>();

		private void Update()
		{
			if (!_panicking)
			{
				return;
			}
			Collider[] array = PhysicsAllocation.Get(5);
			int num;
			using (new TemporaryColliderEnable(_customer.Selection.Collider, isEnabled: false))
			{
				num = Physics.OverlapSphereNonAlloc(base.transform.position + Vector3.one, _checkRadius, array, _layerMask, QueryTriggerInteraction.Ignore);
			}
			if (num <= 0)
			{
				return;
			}
			Vector3 position = _customer.transform.position;
			for (int i = 0; i < num; i++)
			{
				Customer componentInParent = array[i].GetComponentInParent<Customer>();
				if (!(componentInParent == null) && !(componentInParent == _customer) && !componentInParent.IsVampire && componentInParent.Tags.HasTag(EAgentTag.IsInside) && componentInParent.ContextualFSM.CurrentStateEquals<ContextualStateNormal>() && !componentInParent.ControllingVampire && !componentInParent.Cooldowns.IsOnCooldown(BBTAgentTags.Oblivious))
				{
					Vector3 position2 = componentInParent.transform.position;
					if (!(position2.y - position.y > 1.5f) && !Physics.Linecast(position + Vector3.up, position2 + Vector3.up, _lineCastMask, QueryTriggerInteraction.Ignore))
					{
						componentInParent.ActionPlayer.CurrentAction?.CancelAction("");
						componentInParent.ActionPlayer.ClearActionQueue();
						componentInParent.ContextualFSM.SetStatePanicking();
					}
				}
			}
		}
	}
}

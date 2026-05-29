using UnityEngine;

namespace CTS.BBT.AI
{
	public class CustomerEntranceTrigger : MonoBehaviour
	{
		private void OnTriggerEnter(Collider other)
		{
			if (other.transform.parent.parent.TryGetComponent<Customer>(out var component) && component.ActionPlayer.HasAnyActionOfType<AgentActionLeave>())
			{
				component.SetLeaveBarTag();
				component.Selection.Selectable = false;
				CustomerManager.RemoveCustomer(component);
			}
		}
	}
}

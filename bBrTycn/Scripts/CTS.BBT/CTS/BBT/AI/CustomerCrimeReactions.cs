using CTS.Core;
using UnityEngine;

namespace CTS.BBT.AI
{
	public class CustomerCrimeReactions : CTSBehaviour
	{
		[SerializeField]
		private Customer _customer;

		[SerializeField]
		private CrimeWitness _crimeWitness;

		private static StringKey _actionKey = "AI_Action_Alert";

		protected override void OnAwake()
		{
			if (!_customer)
			{
				_customer = GetComponentInParent<Customer>();
			}
			if (!_crimeWitness)
			{
				_crimeWitness = GetComponent<CrimeWitness>();
			}
		}

		protected override void OnEnabled()
		{
			if ((bool)_customer)
			{
				_crimeWitness.CrimeDetected += OnCrimeDetected;
			}
		}

		protected override void OnDisabled()
		{
			if ((bool)_customer)
			{
				_crimeWitness.CrimeDetected -= OnCrimeDetected;
			}
		}

		private void OnCrimeDetected(Crime p_crimeDetected)
		{
			if (!_customer.Business.IsLocked && !_customer.ActionPlayer.HasAnyActionOfType<CustomerActionAlert>() && !_customer.ActionPlayer.HasAnyActionOfType<AgentActionLeave>() && !_customer.ContextualFSM.CurrentStateEquals<ContextualStatePanicking>())
			{
				CustomerActionAlert customerActionAlert = (CustomerActionAlert)_customer.ActionList.InstantiateAction(_actionKey);
				customerActionAlert.SetTarget(p_crimeDetected);
				_customer.ActionPlayer.ForceAction(customerActionAlert, EActionPriority.Forced);
			}
		}
	}
}

using System;
using CTS.BBT.AI;

namespace CTS
{
	public class HumanStyleInfluence : StyleInfluence<ESubSpecies, HumanStyleInfluence>
	{
		public static event Action<HumanStyleInfluence> StylesInfluenceChanged;

		protected override void OnDisabled()
		{
			CustomerManager.OnCustomerEnterBar -= OnCustomerAdded;
			CustomerManager.OnCustomerLeavesBar -= OnCustomerRemoved;
			base.StyleInfluences.Clear();
		}

		protected override void OnEnabled()
		{
			foreach (Customer humans in CustomerManager.HumansList)
			{
				OnCustomerAdded(humans);
			}
			CustomerManager.OnCustomerEnterBar += OnCustomerAdded;
			CustomerManager.OnCustomerLeavesBar += OnCustomerRemoved;
		}

		private void OnCustomerRemoved(Customer customer)
		{
			if (!customer.IsVampire)
			{
				ESubSpecies type = customer.SpawnParameters.Type;
				if (type != 0)
				{
					RemoveInfluence(type, 1f);
					HumanStyleInfluence.StylesInfluenceChanged?.Invoke(this);
				}
			}
		}

		private void OnCustomerAdded(Customer customer)
		{
			if (!customer.IsVampire)
			{
				ESubSpecies type = customer.SpawnParameters.Type;
				if (type != 0)
				{
					AddInfluence(type, 1f);
					HumanStyleInfluence.StylesInfluenceChanged?.Invoke(this);
				}
			}
		}

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}
	}
}

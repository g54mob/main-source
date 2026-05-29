using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	public class SituationnalBarks_Customer : SituationnalBarks
	{
		[SerializeField]
		private SituationlBarkSO _getDrink;

		private void Start()
		{
			if (!TryGetComponent<Agent>(out var component) || !(component is Customer customer))
			{
				Object.Destroy(this);
			}
			else if ((customer.IsHuman && GetType() == typeof(SituationnalBarks_CustomerVampire)) || (!customer.IsHuman && GetType() == typeof(SituationnalBarks_CustomerHuman)))
			{
				Object.Destroy(this);
			}
			else if (this != null)
			{
				customer.SetBarks(this);
			}
		}

		public virtual void Getdrink()
		{
			CalLSO(_getDrink);
		}
	}
}

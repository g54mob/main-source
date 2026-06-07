using System.Collections.Generic;
using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class StallStand : Stand
	{
		[Header("Stall interactables")]
		[SerializeField]
		private StallInteractable[] m_stallInteractables;

		[Header("Sale")]
		[SerializeField]
		private bool m_selling;

		public override EStandType Type => EStandType.STALL;

		public override int LocationCount => 1;

		public override bool IsLocationRelevant(int locationIndex)
		{
			if (m_selling)
			{
				StallInteractable[] stallInteractables = m_stallInteractables;
				for (int i = 0; i < stallInteractables.Length; i++)
				{
					if (stallInteractables[i].HasAProduct(out var _))
					{
						return true;
					}
				}
			}
			return false;
		}

		public IEnumerable<StallInteractable> GetStallInteractables()
		{
			StallInteractable[] stallInteractables = m_stallInteractables;
			for (int i = 0; i < stallInteractables.Length; i++)
			{
				yield return stallInteractables[i];
			}
		}

		public IEnumerable<StallInteractable> GetStallInteractablesWithProduct()
		{
			StallInteractable[] stallInteractables = m_stallInteractables;
			foreach (StallInteractable stallInteractable in stallInteractables)
			{
				if (stallInteractable.HasABuyableProduct())
				{
					yield return stallInteractable;
				}
			}
		}
	}
}

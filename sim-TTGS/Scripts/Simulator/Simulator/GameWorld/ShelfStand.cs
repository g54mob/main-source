using System.Collections.Generic;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class ShelfStand : Stand
	{
		[Header("Shelf")]
		[SerializeField]
		private List<ShelfInteractable> m_shelfInteractables;

		public override EStandType Type => EStandType.SHELF;

		public override int LocationCount => m_shelfInteractables.Count;

		public override bool IsLocationRelevant(int locationIndex)
		{
			return m_shelfInteractables[locationIndex].HasProducts;
		}

		public List<ShelfInteractable> GetValidShelfInteractables()
		{
			List<ShelfInteractable> list = new List<ShelfInteractable>();
			foreach (ShelfInteractable shelfInteractable in m_shelfInteractables)
			{
				if (shelfInteractable.HasProducts)
				{
					list.Add(shelfInteractable);
				}
			}
			return list;
		}

		public IEnumerable<ShelfInteractable> GetAllShelfInteractables()
		{
			return m_shelfInteractables;
		}

		public List<ShelfInteractable> GetUsableShelfInteractablesForCharacter(Character character)
		{
			List<ShelfInteractable> list = new List<ShelfInteractable>();
			foreach (ShelfInteractable shelfInteractable in m_shelfInteractables)
			{
				if (shelfInteractable.CanMainInteract(character))
				{
					list.Add(shelfInteractable);
				}
			}
			return list;
		}
	}
}

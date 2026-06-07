using System.Collections.Generic;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class ReserveShelfStand : Stand
	{
		[Header("Shelf")]
		[SerializeField]
		private List<ReserveShelfInteractable> m_shelfInteractables;

		public override EStandType Type => EStandType.RESERVE_SHELF;

		public override int LocationCount => m_shelfInteractables.Count;

		public override bool IsLocationRelevant(int locationIndex)
		{
			return m_shelfInteractables[locationIndex].Box != null;
		}

		public List<ReserveShelfInteractable> GetValidShelfInteractables()
		{
			List<ReserveShelfInteractable> list = new List<ReserveShelfInteractable>();
			foreach (ReserveShelfInteractable shelfInteractable in m_shelfInteractables)
			{
				if (shelfInteractable.Box != null)
				{
					list.Add(shelfInteractable);
				}
			}
			return list;
		}

		public IEnumerable<ReserveShelfInteractable> GetAllShelfInteractables()
		{
			return m_shelfInteractables;
		}

		public List<ReserveShelfInteractable> GetUsableShelfInteractablesForCharacter(Character character)
		{
			List<ReserveShelfInteractable> list = new List<ReserveShelfInteractable>();
			foreach (ReserveShelfInteractable shelfInteractable in m_shelfInteractables)
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

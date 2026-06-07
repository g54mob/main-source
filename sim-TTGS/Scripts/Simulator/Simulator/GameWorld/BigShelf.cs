using System.Collections.Generic;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class BigShelf : Shelf
	{
		[SerializeField]
		private ShelfStand m_standLeftCenter;

		[SerializeField]
		private ShelfStand m_standRightCenter;

		public override IEnumerable<ShelfInteractable> GetAllShelfInteractables()
		{
			foreach (ShelfInteractable allShelfInteractable in base.GetAllShelfInteractables())
			{
				yield return allShelfInteractable;
			}
			if ((bool)m_standLeftCenter)
			{
				foreach (ShelfInteractable allShelfInteractable2 in m_standLeftCenter.GetAllShelfInteractables())
				{
					yield return allShelfInteractable2;
				}
			}
			if (!m_standRightCenter)
			{
				yield break;
			}
			foreach (ShelfInteractable allShelfInteractable3 in m_standRightCenter.GetAllShelfInteractables())
			{
				yield return allShelfInteractable3;
			}
		}

		public override IEnumerable<ShelfInteractable> GetAllUsableShelfInteractablesForCharacter(Character character)
		{
			foreach (ShelfInteractable item in base.GetAllUsableShelfInteractablesForCharacter(character))
			{
				yield return item;
			}
			if ((bool)m_standLeftCenter)
			{
				foreach (ShelfInteractable item2 in m_standLeftCenter.GetUsableShelfInteractablesForCharacter(character))
				{
					yield return item2;
				}
			}
			if (!m_standRightCenter)
			{
				yield break;
			}
			foreach (ShelfInteractable item3 in m_standRightCenter.GetUsableShelfInteractablesForCharacter(character))
			{
				yield return item3;
			}
		}

		public override void OnStartMoveBy(FurnitureMover mover)
		{
			base.OnStartMoveBy(mover);
			if ((bool)m_standLeftCenter)
			{
				m_standLeftCenter.SetActive(active: false);
			}
			if ((bool)m_standRightCenter)
			{
				m_standRightCenter.SetActive(active: false);
			}
		}

		protected override void OnStopMove()
		{
			base.OnStopMove();
			if ((bool)m_standLeftCenter)
			{
				m_standLeftCenter.SetActive(active: true);
			}
			if ((bool)m_standRightCenter)
			{
				m_standRightCenter.SetActive(active: true);
			}
		}
	}
}

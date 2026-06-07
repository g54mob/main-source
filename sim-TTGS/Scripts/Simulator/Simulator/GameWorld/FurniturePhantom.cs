using System.Collections.Generic;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class FurniturePhantom : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private Furniture m_furniture;

		[SerializeField]
		private EFurnitureType m_type;

		[Header("Elements")]
		[SerializeField]
		private List<FurnitureSpaceChecker> m_elements;

		public bool PositionValid { get; private set; }

		private void OnEnable()
		{
			Furniture.MoveAny += OnMoveAny;
		}

		private void OnDisable()
		{
			Furniture.MoveAny -= OnMoveAny;
		}

		public bool SpaceCheck(int layerMask)
		{
			bool flag = true;
			foreach (FurnitureSpaceChecker element in m_elements)
			{
				if (element != null && !element.SpaceCheck(layerMask))
				{
					flag = false;
				}
			}
			PositionValid = flag;
			return flag;
		}

		public void ForceSpaceCheckResult(bool result)
		{
			PositionValid = result;
			foreach (FurnitureSpaceChecker element in m_elements)
			{
				if (element != null)
				{
					element.SetSpaceCheckVisual(result);
				}
			}
		}

		public Bounds GetBounds()
		{
			Bounds bounds = m_elements[0].GetBounds();
			for (int i = 0; i < m_elements.Count; i++)
			{
				if (m_elements[i] != null)
				{
					bounds.Encapsulate(m_elements[i].GetBounds());
				}
			}
			return bounds;
		}

		protected virtual void OnMoveAny(Furniture furniture, bool move)
		{
			if (m_furniture != null && m_furniture == furniture)
			{
				foreach (FurnitureSpaceChecker element in m_elements)
				{
					if (element != null)
					{
						element.SetActive(move, phantom: true, FurnitureSettings.ValidPhantomMaterial);
					}
				}
				PositionValid = move;
				return;
			}
			bool active = move && furniture.Type == m_type;
			foreach (FurnitureSpaceChecker element2 in m_elements)
			{
				if (element2 != null)
				{
					element2.SetActive(active, phantom: false, FurnitureSettings.SpaceIndicatorMaterial);
				}
			}
		}
	}
}

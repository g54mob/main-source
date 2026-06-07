using System;
using Simulator;
using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class PaintingTableWorkshop : Workshop
	{
		[Header("Painting Stand")]
		[SerializeField]
		private PaintingTableStand m_stand;

		public event Action UsedByPlayer;

		public override void OnControlledBy(Controller controller)
		{
			base.OnControlledBy(controller);
			if (controller.IsPlayer && m_stand.OccupiedPlacesCount > 0)
			{
				m_stand.MoveCurrentUser();
			}
		}

		protected override void OnControlledByPlayerPostBlend()
		{
			base.OnControlledByPlayerPostBlend();
			this.UsedByPlayer?.Invoke();
			Collection_HUDPopupModule.Closed += OnCollectionClosed;
			Tutorial.TryShow(TutorialSettings.Painting, OpenPaintingCollection);
			static void OpenPaintingCollection()
			{
				Collection.Open(ECollectionMode.PAINTING);
			}
		}

		public override void OnUncontrolledBy(Controller controller)
		{
			base.OnUncontrolledBy(controller);
			m_stand.OnWorkshopUnoccupied();
			if (controller.IsPlayer)
			{
				Collection_HUDPopupModule.Closed -= OnCollectionClosed;
			}
		}

		protected override bool CanQuitWorkshop()
		{
			return true;
		}

		private void OnCollectionClosed()
		{
			QuitWorkshop();
		}
	}
}

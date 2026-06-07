using System.Collections.Generic;
using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class WargameStand : Stand
	{
		[Header("Workshop")]
		[SerializeField]
		private WargameWorkshop m_workshop;

		[Header("Stand")]
		[SerializeField]
		private WargameStand m_otherStand;

		public int FurnitureLevel { get; private set; }

		public override EStandType Type => EStandType.WARGAME;

		public override int LocationCount => 1;

		public WargameStand OtherStand => m_otherStand;

		public override bool IsLocationRelevant(int locationIndex)
		{
			return true;
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			Furniture furniture = m_furniture;
			int furnitureLevel = ((furniture is PaintingTable paintingTable) ? paintingTable.Level : ((!(furniture is WargameTable wargameTable)) ? FurnitureLevel : wargameTable.Level));
			FurnitureLevel = furnitureLevel;
		}

		public override bool CanAccess(IStandUser user)
		{
			if (!base.IsActive)
			{
				return false;
			}
			return HasAvailablePlace();
		}

		public void MoveCurrentUser()
		{
			foreach (IStandUser currentUser in GetCurrentUsers())
			{
				if (currentUser != null)
				{
					AskToQuitStand(currentUser, completed: false);
				}
			}
		}

		public void OnWorkshopUnoccupied()
		{
			if (PopFirstInLine(out var user))
			{
				GiveFirstAvailablePlace(user);
			}
		}

		protected override bool HasAvailablePlace()
		{
			if (!m_workshop.IsControlled)
			{
				return base.HasAvailablePlace();
			}
			return false;
		}

		private bool TryGetCurrentClient(out TabletopClientBehaviour behaviour)
		{
			if (m_usersAtStand.Count > 0)
			{
				behaviour = m_usersAtStand[0] as TabletopClientBehaviour;
				return behaviour != null;
			}
			behaviour = null;
			return false;
		}

		private bool TryGetIncomingClient(out TabletopClientBehaviour behaviour)
		{
			foreach (KeyValuePair<IStandUser, int> occupiedPlace in m_occupiedPlaces)
			{
				occupiedPlace.Deconstruct(out var key, out var _);
				if (key is TabletopClientBehaviour tabletopClientBehaviour)
				{
					behaviour = tabletopClientBehaviour;
					return true;
				}
			}
			behaviour = null;
			return false;
		}

		public bool CanJoinOtherClient()
		{
			if (base.FreePlacesCount > 0)
			{
				return m_otherStand.OccupiedPlacesCount > 0;
			}
			return false;
		}

		public bool TryGetOtherClient(out TabletopClientBehaviour otherClient)
		{
			return m_otherStand.TryGetCurrentClient(out otherClient);
		}

		public bool TryGetOtherIncomingClient(out TabletopClientBehaviour otherClient)
		{
			return m_otherStand.TryGetIncomingClient(out otherClient);
		}

		public bool IsFacingPlayer()
		{
			if (m_otherStand.m_workshop.IsControlled)
			{
				return m_otherStand.m_workshop.Controller.IsPlayer;
			}
			return false;
		}
	}
}

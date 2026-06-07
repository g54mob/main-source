using Simulator;
using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class PaintingTableStand : Stand
	{
		[Header("Workshop")]
		[SerializeField]
		private PaintingTableWorkshop m_workshop;

		[Header("Client Animations")]
		[SerializeField]
		private GameObject m_miniatureToPaint;

		[SerializeField]
		private GrabbableData.Anchor m_miniatureAnchorWomen;

		[SerializeField]
		private GrabbableData.Anchor m_miniatureAnchorMen;

		[Space(10f)]
		[SerializeField]
		private GameObject m_paintbrush;

		[SerializeField]
		private GrabbableData.Anchor m_paintbrushAnchorWomen;

		[SerializeField]
		private GrabbableData.Anchor m_paintbrushAnchorMen;

		public int FurnitureLevel { get; private set; }

		public override EStandType Type => EStandType.PAINTING;

		public override int LocationCount => 1;

		public override bool IsLocationRelevant(int locationIndex)
		{
			return true;
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			if ((bool)m_miniatureToPaint)
			{
				m_miniatureToPaint.SetActive(value: false);
			}
			if ((bool)m_paintbrush)
			{
				m_paintbrush.SetActive(value: false);
			}
			if (m_furniture is PaintingTable paintingTable)
			{
				FurnitureLevel = paintingTable.Level;
			}
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

		protected override void OnArrivedAtStand(IStandUser user)
		{
			base.OnArrivedAtStand(user);
			if (user is AIBehaviour aIBehaviour)
			{
				if (m_miniatureToPaint != null)
				{
					m_miniatureToPaint.SetActive(value: true);
					m_miniatureToPaint.transform.Anchor(aIBehaviour.Character.LeftHand);
					GrabbableData.Anchor anchor = (aIBehaviour.Character.IsMan ? m_miniatureAnchorMen : m_miniatureAnchorWomen);
					m_miniatureToPaint.transform.SetLocalPositionAndRotation(anchor.LocalPosition, anchor.LocalRotation);
				}
				if (m_paintbrush != null)
				{
					m_paintbrush.SetActive(value: true);
					m_paintbrush.transform.Anchor(aIBehaviour.Character.RightHand);
					GrabbableData.Anchor anchor2 = (aIBehaviour.Character.IsMan ? m_paintbrushAnchorMen : m_paintbrushAnchorWomen);
					m_paintbrush.transform.SetLocalPositionAndRotation(anchor2.LocalPosition, anchor2.LocalRotation);
				}
			}
		}

		protected override void OnUserQuitPlace(IStandUser user, int placeIndex)
		{
			base.OnUserQuitPlace(user, placeIndex);
			if (m_miniatureToPaint != null)
			{
				m_miniatureToPaint.SetActive(value: false);
				m_miniatureToPaint.transform.Anchor(base.transform);
			}
			if (m_paintbrush != null)
			{
				m_paintbrush.SetActive(value: false);
				m_paintbrush.transform.Anchor(base.transform);
			}
		}
	}
}

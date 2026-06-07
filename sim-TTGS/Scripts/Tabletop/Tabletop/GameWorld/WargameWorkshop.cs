using System;
using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class WargameWorkshop : Workshop
	{
		[Header("Wargame Stand")]
		[SerializeField]
		private WargameStand m_stand;

		[Header("Opponent Spawn")]
		[SerializeField]
		private Transform m_opponentSpawnPoint;

		[Header("Dice Anchors")]
		[SerializeField]
		private Transform m_throwOrigin;

		[SerializeField]
		private Transform[] m_playerFreeDicesAnchors;

		[Space(5f)]
		[SerializeField]
		private GameObject m_playerDiceAnchorsContainer;

		[SerializeField]
		private WargameDiceAnchor[] m_playerDiceAnchors;

		[Space(10f)]
		[SerializeField]
		private GameObject m_opponentDiceAnchorsContainer;

		[SerializeField]
		private WargameDiceAnchor[] m_opponentDiceAnchors;

		[Header("Miniature Anchors")]
		[SerializeField]
		private Transform[] m_playerMiniatureAnchors;

		[SerializeField]
		private Transform[] m_opponentMiniatureAnchors;

		private TabletopClientBehaviour m_opponentToWaitFor;

		public static WargameWorkshop CurrentlyUsed { get; private set; }

		public event Action UsedByPlayer;

		protected override void OnEnable()
		{
			base.OnEnable();
			m_playerDiceAnchorsContainer.SetActive(value: false);
			m_opponentDiceAnchorsContainer.SetActive(value: false);
		}

		public Transform GetThrowOrigin()
		{
			return m_throwOrigin;
		}

		public Transform GetPlayerFreeDiceAnchor(int index)
		{
			if (m_playerFreeDicesAnchors.IsIndexValid(index))
			{
				return m_playerFreeDicesAnchors[index];
			}
			return null;
		}

		public WargameDiceAnchor[] GetPlayerDiceAnchors()
		{
			return m_playerDiceAnchors;
		}

		public WargameDiceAnchor[] GetOpponentDiceAnchors()
		{
			return m_opponentDiceAnchors;
		}

		public Transform GetPlayerMiniatureAnchor(int index)
		{
			if (m_playerMiniatureAnchors.IsIndexValid(index))
			{
				return m_playerMiniatureAnchors[index];
			}
			return null;
		}

		public Transform GetOpponentMiniatureAnchor(int index)
		{
			if (m_opponentMiniatureAnchors.IsIndexValid(index))
			{
				return m_opponentMiniatureAnchors[index];
			}
			return null;
		}

		protected override bool CanQuitWorkshop()
		{
			return true;
		}

		public void ShowDiceAnchors()
		{
			m_playerDiceAnchorsContainer.SetActive(value: true);
			m_opponentDiceAnchorsContainer.SetActive(value: true);
		}

		public void OnWargameStarting()
		{
		}

		public void OnWargameComplete(bool quit)
		{
			m_playerDiceAnchorsContainer.SetActive(value: false);
			m_opponentDiceAnchorsContainer.SetActive(value: false);
			if (quit)
			{
				QuitWorkshop();
			}
		}

		private void OnWargameSquadChoiceComplete()
		{
			TabletopClientBehaviour otherClient;
			TabletopClientBehaviour otherClient2;
			if (!TabletopWorld.WargameManager.IsActive)
			{
				QuitWorkshop();
			}
			else if (m_stand.TryGetOtherClient(out otherClient))
			{
				otherClient.JoinedOnWargameByPlayer();
			}
			else if (m_stand.TryGetOtherIncomingClient(out otherClient2) || TabletopWorld.TabletopClientManager.SpawnWargameOpponent(m_opponentSpawnPoint, out otherClient2))
			{
				WaitForOpponent(otherClient2);
			}
		}

		private void WaitForOpponent(TabletopClientBehaviour client)
		{
			if (!(client == null))
			{
				m_opponentToWaitFor = client;
				m_opponentToWaitFor.JoinPlayerOnWargame(m_stand.OtherStand);
				m_opponentToWaitFor.ArrivedAtStand += OnClientArriveAtWargameStand;
				WargameManager.WargameCompleted += OnWargameCompleted;
			}
		}

		private void OnWargameCompleted()
		{
			WargameManager.WargameCompleted -= OnWargameCompleted;
			if (m_opponentToWaitFor != null)
			{
				m_opponentToWaitFor.ArrivedAtStand -= OnClientArriveAtWargameStand;
				m_opponentToWaitFor = null;
			}
		}

		private void OnClientArriveAtWargameStand(IStandUser user)
		{
			WargameManager.WargameCompleted -= OnWargameCompleted;
			if (m_opponentToWaitFor != null)
			{
				m_opponentToWaitFor.ArrivedAtStand -= OnClientArriveAtWargameStand;
				m_opponentToWaitFor = null;
			}
			Time.timeScale = 0f;
		}

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
			Collection_HUDPopupModule.Closed += OnWargameSquadChoiceComplete;
			CurrentlyUsed = this;
			Tutorial.TryShow(WargameSettings.SquadTutorialData, OpenSquadSelection);
			static void OpenSquadSelection()
			{
				Collection.Open(ECollectionMode.SQUAD_SELECTION);
			}
		}

		public override void OnUncontrolledBy(Controller controller)
		{
			base.OnUncontrolledBy(controller);
			m_stand.OnWorkshopUnoccupied();
			if (controller.IsPlayer)
			{
				Collection_HUDPopupModule.Closed -= OnWargameSquadChoiceComplete;
			}
		}
	}
}

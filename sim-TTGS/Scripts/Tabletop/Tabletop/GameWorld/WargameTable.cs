using System.Collections.Generic;
using Simulator;
using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class WargameTable : GroundFurniture
	{
		[Header("Wargame")]
		[SerializeField]
		[Range(1f, 5f)]
		private int m_level;

		[Header("References")]
		[SerializeField]
		private List<Stand> m_stands;

		[SerializeField]
		private List<WargameWorkshop> m_workshops;

		public int Level => m_level;

		public static int CurrentlyUsedLevel { get; private set; }

		protected override void OnEnable()
		{
			base.OnEnable();
			foreach (WargameWorkshop workshop in m_workshops)
			{
				workshop.UsedByPlayer += OnUsedByPlayer;
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			foreach (WargameWorkshop workshop in m_workshops)
			{
				workshop.UsedByPlayer -= OnUsedByPlayer;
			}
		}

		public override void Init(int gameID, Vector3 position, EFurnitureOrientation orientation, bool addScore = false)
		{
			base.Init(gameID, position, orientation, addScore);
			switch (m_level)
			{
			case 2:
				ESteamAchievement.GAME_TABLE_LVL2.Trigger();
				break;
			case 3:
				ESteamAchievement.GAME_TABLE_LVL3.Trigger();
				break;
			}
		}

		public override void OnStartMoveBy(FurnitureMover mover)
		{
			base.OnStartMoveBy(mover);
			foreach (Stand stand in m_stands)
			{
				if (stand != null)
				{
					stand.SetActive(active: false);
				}
			}
		}

		protected override void OnStopMove()
		{
			base.OnStopMove();
			foreach (Stand stand in m_stands)
			{
				if (stand != null)
				{
					stand.SetActive(active: true);
				}
			}
		}

		private void OnUsedByPlayer()
		{
			CurrentlyUsedLevel = m_level;
		}

		protected override bool HasAssociatedWorkshop()
		{
			return true;
		}

		protected override bool TryGetAssociatedWorkshop(out Workshop workshop)
		{
			for (int i = 0; i < m_stands.Count; i++)
			{
				if (m_stands[i] != null && !m_stands[i].IsUsed() && m_workshops.IsIndexValid(i) && m_workshops[i] != null)
				{
					workshop = m_workshops[i];
					return true;
				}
			}
			for (int j = 0; j < m_workshops.Count; j++)
			{
				if (m_workshops[j] != null)
				{
					workshop = m_workshops[j];
					return true;
				}
			}
			workshop = null;
			return false;
		}
	}
}

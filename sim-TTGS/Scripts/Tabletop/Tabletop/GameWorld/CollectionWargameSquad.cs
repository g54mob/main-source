using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tabletop.GameWorld
{
	[Serializable]
	public struct CollectionWargameSquad
	{
		[SerializeField]
		private bool m_exists;

		[SerializeField]
		private bool m_valid;

		[SerializeField]
		private string m_name;

		[SerializeField]
		private ELicense m_license;

		[SerializeField]
		private List<EMiniatureArmy> m_armies;

		[SerializeField]
		private int[] m_miniatures;

		[SerializeField]
		private int m_victories;

		[SerializeField]
		private int m_defeats;

		public bool Exists => m_exists;

		public bool Valid => m_valid;

		public string Name
		{
			get
			{
				return m_name;
			}
			set
			{
				m_name = value;
			}
		}

		public ELicense License => m_license;

		public List<EMiniatureArmy> Armies => m_armies;

		public int Victories => m_victories;

		public int Defeats => m_defeats;

		public int GamesPlayed => m_victories + m_defeats;

		public float VictoryRate
		{
			get
			{
				if (m_victories <= 0)
				{
					return 0f;
				}
				return (float)m_victories / (float)GamesPlayed;
			}
		}

		private CollectionWargameSquad(string name, ELicense license, List<EMiniatureArmy> armies, int[] squad, int victories, int defeats)
		{
			m_exists = true;
			m_name = name;
			m_license = license;
			m_armies = ((armies != null) ? new List<EMiniatureArmy>(armies) : null);
			m_miniatures = squad;
			m_victories = victories;
			m_defeats = defeats;
			m_valid = true;
			for (int i = 0; i < squad.Length; i++)
			{
				if (squad[i] <= 0)
				{
					m_valid = false;
				}
			}
		}

		public CollectionWargameSquad(CollectionWargameSquad other, ELicense license, List<EMiniatureArmy> armies, int[] squad)
		{
			m_exists = true;
			m_name = other.Name;
			m_license = license;
			m_armies = ((armies != null) ? new List<EMiniatureArmy>(armies) : null);
			m_miniatures = squad;
			m_victories = other.Victories;
			m_defeats = other.Defeats;
			m_valid = true;
			for (int i = 0; i < squad.Length; i++)
			{
				if (squad[i] <= 0)
				{
					m_valid = false;
				}
			}
		}

		public CollectionWargameSquad(CollectionWargameSquad other, bool victory)
		{
			m_exists = other.m_exists;
			m_name = other.Name;
			m_license = other.License;
			m_armies = ((other.Armies != null) ? new List<EMiniatureArmy>(other.Armies) : null);
			m_miniatures = new int[WargameSettings.SquadSize];
			if (other.m_miniatures != null)
			{
				other.m_miniatures.CopyTo(m_miniatures, 0);
			}
			m_victories = other.Victories + (victory ? 1 : 0);
			m_defeats = other.Defeats + ((!victory) ? 1 : 0);
			m_valid = true;
			for (int i = 0; i < m_miniatures.Length; i++)
			{
				if (m_miniatures[i] <= 0)
				{
					m_valid = false;
				}
			}
		}

		public static CollectionWargameSquad CreateNew()
		{
			return new CollectionWargameSquad("New Squad", ELicense.FWB, null, new int[WargameSettings.SquadSize], 0, 0);
		}

		public int GetMiniatureUID(int index)
		{
			if (m_miniatures.IsIndexValid(index))
			{
				return m_miniatures[index];
			}
			return 0;
		}

		public IEnumerable<int> GetMiniatures()
		{
			for (int i = 0; i < WargameSettings.SquadSize; i++)
			{
				if (m_miniatures.IsIndexValid(i))
				{
					yield return m_miniatures[i];
				}
				else
				{
					yield return 0;
				}
			}
		}
	}
}

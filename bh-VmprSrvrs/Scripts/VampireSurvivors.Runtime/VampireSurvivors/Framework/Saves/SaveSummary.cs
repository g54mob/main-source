using System;
using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.Saves
{
	public class SaveSummary
	{
		private string _timestamp;

		public PlayerOptionsData Pod { get; set; }

		public byte[] Data { get; set; }

		public string Timestamp
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DateTime RawDateTime { get; private set; }

		public int _totalGold { get; set; }

		public CharacterType _selectedCharacter { get; set; }

		public StageType _selectedStage { get; set; }

		public int _unlockedCharacters { get; set; }

		public int _achievements { get; set; }
	}
}

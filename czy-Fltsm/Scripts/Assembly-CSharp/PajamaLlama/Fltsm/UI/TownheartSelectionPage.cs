using UnityEngine;

namespace PajamaLlama.Fltsm.UI
{
	public class TownheartSelectionPage : GameSetupPage
	{
		[Header("Placeable Toggle")]
		[SerializeField]
		private TownheartToggle[] _toggles;

		public override bool Activate()
		{
			if (_toggles.IsNullOrEmpty())
			{
				return false;
			}
			int num = 0;
			TownheartToggle[] toggles = _toggles;
			for (int i = 0; i < toggles.Length; i++)
			{
				if (toggles[i].Activate())
				{
					num++;
				}
			}
			base.IsCompleted = true;
			bool flag = num > 1;
			base.gameObject.SetActive(flag);
			return flag;
		}

		public override GameSetup Apply(GameSetup gameSetup)
		{
			TownheartToggle[] toggles = _toggles;
			foreach (TownheartToggle townheartToggle in toggles)
			{
				if (townheartToggle.isOn)
				{
					gameSetup.TownheartProperties = townheartToggle.TownheartProperties;
					break;
				}
			}
			return gameSetup;
		}
	}
}

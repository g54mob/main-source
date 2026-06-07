using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class AgentPreferencePanel : AbsAgentPanel
	{
		[SerializeField]
		private Image _vampirePrefImage;

		[SerializeField]
		private TMP_Text _bloodPrefText;

		[SerializeField]
		private TMP_Text _rightZoneText;

		[SerializeField]
		private Image _humanPrefPicto;

		public override void ClearAgentInfo()
		{
			_rightZoneText.text = "";
		}

		public override void SetAgentInfo()
		{
			if (base._agent is Customer)
			{
				if (((Customer)base._agent).IsVampire)
				{
					SetVampireInfo();
				}
				else
				{
					SetHumanInfo();
				}
			}
		}

		private void SetVampireInfo()
		{
			_bloodPrefText.text = "-";
			UpdatePreferences();
		}

		private void SetHumanInfo()
		{
			_bloodPrefText.text = base._agent.Cast<Customer>().BloodQuality.ToString();
			UpdatePreferences();
		}

		private void UpdatePreferences()
		{
			string drinks = "";
			if (base._agent is Customer customer)
			{
				AddLikedDrinks(customer.SpawnParameters.DrinksLiked, "Likes");
				AddLikedDrinks(customer.SpawnParameters.DrinksHate, "Dislikes");
			}
			_rightZoneText.text = drinks;
			void AddLikedDrinks(DrinkSO[] drinkArray, string header)
			{
				for (int i = 0; i < drinkArray.Length; i++)
				{
					if (i == 0)
					{
						drinks = drinks + header + ":\n";
					}
					drinks = drinks + "- " + drinkArray[i].Name + "\n";
				}
			}
		}
	}
}

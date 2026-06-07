using System;
using TMPro;
using UnityEngine;

namespace VampireSurvivors.App.UI.Twitch
{
	public class TwitchLevelUpOption : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _OptionText;

		private Action _callback;

		public TextMeshProUGUI OptionText => null;

		private void Awake()
		{
		}

		public void SetOptionCallback(Action callback)
		{
		}

		public void TriggerCallback()
		{
		}
	}
}

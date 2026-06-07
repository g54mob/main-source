using System;
using Dhs5.Utility.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator.CustomSettings
{
	[Serializable]
	public class UI_TogglePlayerPrefBoolOptions : UI_BasePlayerPrefMemberOptions<PlayerPrefBool>
	{
		[SerializeField]
		private Toggle m_toggle;

		public event Action<bool> OnValueChanged
		{
			add
			{
				playerPrefMember.OnValueChanged += value;
			}
			remove
			{
				playerPrefMember.OnValueChanged -= value;
			}
		}

		public override void Awake()
		{
		}

		public override void OnEnable()
		{
			SelectCurrentValue();
			m_toggle.onValueChanged.AddListener(OnToggleValueChange_SetValue);
		}

		public override void OnDisable()
		{
			m_toggle.onValueChanged.RemoveListener(OnToggleValueChange_SetValue);
		}

		public override void SelectCurrentValue()
		{
			m_toggle.SetIsOnWithoutNotify(playerPrefMember.Value);
		}

		private void OnToggleValueChange_SetValue(bool value)
		{
			playerPrefMember.Value = value;
		}
	}
}

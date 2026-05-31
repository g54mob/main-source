using System;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class CustomerNavigationPanel : MonoBehaviour
	{
		[SerializeField]
		private Button _infoButton;

		[SerializeField]
		private Button _diaryButton;

		private AgentPanelGroup.showMode _showData;

		public AgentPanelGroup.showMode showData
		{
			get
			{
				return _showData;
			}
			set
			{
				_showData = value;
				this.onShowButtonChanged?.Invoke(_showData);
			}
		}

		public event Action<AgentPanelGroup.showMode> onShowButtonChanged;

		private void Awake()
		{
			_showData = AgentPanelGroup.showMode.Info;
			_infoButton.interactable = false;
		}
	}
}

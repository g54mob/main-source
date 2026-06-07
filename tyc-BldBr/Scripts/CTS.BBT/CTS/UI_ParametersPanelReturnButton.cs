using System;
using System.Collections.Generic;
using CTS.UI;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_ParametersPanelReturnButton : MonoBehaviour
	{
		[SerializeField]
		private List<CanvasGroupController> _listToHide;

		private Button _thisButton;

		public static UI_ParametersPanelReturnButton Instance { get; private set; }

		public event Action ClosePanel;

		private void Awake()
		{
			Instance = this;
			_thisButton = GetComponent<Button>();
			_thisButton.onClick.AddListener(delegate
			{
				CloseTheParametersPanel();
			});
		}

		public void CloseTheParametersPanel()
		{
			foreach (CanvasGroupController item in _listToHide)
			{
				item.QuickHide();
			}
			this.ClosePanel?.Invoke();
		}
	}
}

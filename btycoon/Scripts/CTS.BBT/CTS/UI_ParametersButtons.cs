using System.Collections.Generic;
using CTS.Core;
using CTS.UI;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_ParametersButtons : MonoBehaviour
	{
		[SerializeField]
		private List<InterfaceButton> _interfaceButtonToHide = new List<InterfaceButton>();

		[SerializeField]
		private List<CanvasGroupController> _canvasToHide = new List<CanvasGroupController>();

		private Button _thisButton;

		protected void Awake()
		{
			_thisButton = GetComponent<Button>();
			_thisButton.onClick.AddListener(OnClick);
		}

		private void Start()
		{
			UI_ParametersPanelReturnButton.Instance.ClosePanel += ClosePanel;
		}

		private void OnDestroy()
		{
			UI_ParametersPanelReturnButton.Instance.ClosePanel -= ClosePanel;
		}

		private void ClosePanel()
		{
			foreach (InterfaceButton item in _interfaceButtonToHide)
			{
				item.QuickShow();
			}
			foreach (CanvasGroupController item2 in _canvasToHide)
			{
				item2.QuickShow();
			}
		}

		private void OnClick()
		{
			MonoSingleton<OptionsMenu>.Instance.OnClickButton();
			foreach (InterfaceButton item in _interfaceButtonToHide)
			{
				item.QuickHide();
			}
			foreach (CanvasGroupController item2 in _canvasToHide)
			{
				item2.QuickHide();
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		private void Toggle()
		{
			if (_canvasToHide[0].IsShown)
			{
				foreach (InterfaceButton item in _interfaceButtonToHide)
				{
					item.QuickHide();
				}
				{
					foreach (CanvasGroupController item2 in _canvasToHide)
					{
						item2.QuickHide();
					}
					return;
				}
			}
			foreach (InterfaceButton item3 in _interfaceButtonToHide)
			{
				item3.QuickShow();
			}
			foreach (CanvasGroupController item4 in _canvasToHide)
			{
				item4.QuickShow();
			}
		}
	}
}

using CTS.Core;
using CTS.UI;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace CTS
{
	public class UI_CreditsManager : MonoBehaviour
	{
		[Foldout("Dev")]
		[SerializeField]
		private GameObject _creditsPanel;

		[Foldout("Dev")]
		[SerializeField]
		private TMP_Text _buttonCredits;

		[Foldout("Dev")]
		[SerializeField]
		private CanvasGroupController _canvasMenuGroupController;

		[Foldout("Dev")]
		[SerializeField]
		private CanvasGroupController _creditGroupController;

		[SerializeField]
		private InputActionReference _leavePanel;

		private Button _creditButton;

		private LockToggle _canvasToggle = new LockToggle();

		private void Awake()
		{
			UI_CreditButton.ClickButton += UI_CreditButton_ClickButton;
			if (_creditsPanel.activeSelf)
			{
				_creditsPanel.SetActive(value: false);
			}
			if (_creditButton != null)
			{
				_creditButton = _buttonCredits.gameObject.GetComponentInParent<Button>();
			}
			_canvasToggle.Set(_canvasMenuGroupController);
			_creditGroupController.CanvasShowned += CreditCanvasShowned;
			_leavePanel.action.performed += LeavePanel;
		}

		private void LeavePanel(InputAction.CallbackContext obj)
		{
			CloseCreditsPanel();
		}

		private void UI_CreditButton_ClickButton()
		{
			MenuCanvasShowned(obj: false);
		}

		private void OnDestroy()
		{
			UI_CreditButton.ClickButton -= UI_CreditButton_ClickButton;
			_creditGroupController.CanvasShowned -= CreditCanvasShowned;
			_leavePanel.action.performed -= LeavePanel;
		}

		private void CreditCanvasShowned(bool obj)
		{
			if (!obj)
			{
				_canvasToggle.Unlock();
				_creditsPanel.SetActive(value: false);
				_canvasMenuGroupController.CanvasShowned -= MenuCanvasShowned;
			}
		}

		public void Lock()
		{
			_canvasToggle.Lock();
		}

		public void SubscribeMenuAction()
		{
			EventSystem.current.SetSelectedGameObject(null);
			_canvasMenuGroupController.CanvasShowned += MenuCanvasShowned;
		}

		private void MenuCanvasShowned(bool obj)
		{
			if (!obj)
			{
				_creditsPanel.SetActive(value: true);
				_creditGroupController.QuickShow();
			}
		}

		public void CloseCreditsPanel()
		{
			_creditGroupController.QuickHide();
		}

		public GameObject PanelCredit()
		{
			return _creditsPanel;
		}
	}
}

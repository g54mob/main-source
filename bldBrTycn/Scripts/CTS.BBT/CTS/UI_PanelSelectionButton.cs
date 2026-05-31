using System;
using System.Collections;
using CTS.UI;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CTS
{
	public class UI_PanelSelectionButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private Toggle _toggle;

		[SerializeField]
		private GameObject _panelPrefab;

		[SerializeField]
		private GameObject _backGroundText;

		[SerializeField]
		private CanvasGroupController _canvasGroupController;

		[InfoBox("You can't spawn new panels if you don't assign a parent", EInfoBoxType.Normal)]
		[SerializeField]
		private Transform _panelParent;

		public GameObject AttachedPanel;

		[SerializeField]
		private TMP_Text _toggleTextDisplay;

		[SerializeField]
		private string _toggleText;

		[SerializeField]
		private bool _canBeInteractiveInPublicBuild;

		private Coroutine _changePanel;

		[field: SerializeField]
		public OptionsMenu.NameOfPanel ENameOfPanel { get; private set; }

		public static event Action<UI_PanelSelectionButton> OnPanelSelected;

		private void Awake()
		{
			UI_ParametersPanelReturnButton.Instance.ClosePanel += DisableThePanel;
			UI_ParametersButtonsReturnToTheMenu.ReturnToMainMenu += DisableThePanel;
		}

		private void Start()
		{
			_canvasGroupController.QuickHide();
			if (_canBeInteractiveInPublicBuild)
			{
				_toggle.interactable = true;
			}
		}

		private void OnDestroy()
		{
			UI_ParametersPanelReturnButton.Instance.ClosePanel -= DisableThePanel;
			UI_ParametersButtonsReturnToTheMenu.ReturnToMainMenu -= DisableThePanel;
		}

		private void DisableThePanel()
		{
			_toggle.isOn = false;
		}

		[Button("Destroy Panel and Button", EButtonEnableMode.Always)]
		private void DestroyPanel()
		{
			UnityEngine.Object.DestroyImmediate(AttachedPanel);
			UnityEngine.Object.DestroyImmediate(base.gameObject);
		}

		private IEnumerator ChangingThePanel()
		{
			_canvasGroupController.QuickHide();
			yield return new WaitForSecondsRealtime(0.25f);
			if (_toggle.isOn)
			{
				_canvasGroupController.QuickShow();
			}
			AttachedPanel.SetActive(_toggle.isOn);
			UI_PanelSelectionButton.OnPanelSelected?.Invoke(this);
		}

		public void SwitchToPanel()
		{
			Debug.Log(AttachedPanel);
			if (_canvasGroupController.IsHidden)
			{
				AttachedPanel.SetActive(_toggle.isOn);
				_canvasGroupController.QuickShow();
			}
			else if (_canvasGroupController.IsShown)
			{
				StartCoroutine(ChangingThePanel());
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}
	}
}

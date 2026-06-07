using System;
using System.Collections.Generic;
using Data.Variables;
using Events;
using NaughtyAttributes;
using Presentation.Locators;
using Presentation.UI.Menus;
using Presentation.UI.Menus.MenuEvents;
using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HeatmapUI : UIMenu
{
	[Serializable]
	private struct QuitHeatmapInput
	{
		public InputActionReference QuitInput;

		public bool GoBack;
	}

	[Header("UI refs")]
	[SerializeField]
	private Button _heatmapButton;

	[FormerlySerializedAs("heatmapOnLocaKey")]
	[SerializeField]
	[LocaKey]
	private string _heatmapOnLocaKey;

	[FormerlySerializedAs("heatmapOffLocaKey")]
	[SerializeField]
	[LocaKey]
	private string _heatmapOffLocaKey;

	[Header("Events refs")]
	[SerializeField]
	private ShowUIMenuEvent _showUIMenuEvent;

	[SerializeField]
	private ShowUIMenuEvent _willShowUIMenuEvent;

	[SerializeField]
	private BaseEvent _selectToolButtonPressedEvent;

	[Header("Locators")]
	[SerializeField]
	private UIMenuLocator _heatmapMenuLocator;

	[SerializeField]
	private UIMenuManagerLocator _uiMenuManagerLocator;

	[Header("Other Refs")]
	[SerializeField]
	private List<QuitHeatmapInput> _quitHeatmapInputRefs = new List<QuitHeatmapInput>();

	[SerializeField]
	private BoolVariableSO _operatorInteriorUIIsOpen;

	[SerializeField]
	private List<GoBackSourceSO> _ignoredSources = new List<GoBackSourceSO>();

	[SerializeField]
	private GoBackSourceSO _heatmapUIGoBackSource;

	[SerializeField]
	private BoolVariableSO _heatmapIsOn;

	[SerializeField]
	private Canvas _heatmapCanvas;

	[SerializeField]
	[EnumFlags]
	private AbstractUIMenuData.ToggleTypes _uiToggles;

	[SerializeField]
	private List<UniversalRendererData> _postProcessRef;

	private List<ScriptableRendererFeature> _heatmapPostProcess;

	private void Awake()
	{
		_heatmapButton.onClick.AddListener(OnHeatmapButtonClicked);
		foreach (QuitHeatmapInput quitHeatmapInputRef in _quitHeatmapInputRefs)
		{
			if (quitHeatmapInputRef.GoBack)
			{
				quitHeatmapInputRef.QuitInput.action.performed += OnQuitHeatmapActionPerformed;
			}
			else
			{
				quitHeatmapInputRef.QuitInput.action.performed += OnQuitHeatmapNoBackActionPerformed;
			}
		}
		_willShowUIMenuEvent.Register(OnWillShowUIMenu);
		GetHeatmapPostProcess();
		_heatmapIsOn.SetValue(value: false);
		_heatmapCanvas.enabled = false;
		foreach (ScriptableRendererFeature item in _heatmapPostProcess)
		{
			item.SetActive(active: false);
		}
	}

	private void OnWillShowUIMenu(AbstractUIMenuData obj)
	{
		TryToggleHeatmap(toggle: false);
	}

	private void GetHeatmapPostProcess()
	{
		_heatmapPostProcess = new List<ScriptableRendererFeature>();
		foreach (UniversalRendererData item in _postProcessRef)
		{
			foreach (ScriptableRendererFeature rendererFeature in item.rendererFeatures)
			{
				if (rendererFeature != null && rendererFeature.name == "Heatmap Postprocess")
				{
					_heatmapPostProcess.Add(rendererFeature);
				}
			}
		}
	}

	private void OnDestroy()
	{
		_heatmapButton.onClick.RemoveListener(OnHeatmapButtonClicked);
		foreach (QuitHeatmapInput quitHeatmapInputRef in _quitHeatmapInputRefs)
		{
			if (quitHeatmapInputRef.GoBack)
			{
				quitHeatmapInputRef.QuitInput.action.performed -= OnQuitHeatmapActionPerformed;
			}
			else
			{
				quitHeatmapInputRef.QuitInput.action.performed -= OnQuitHeatmapNoBackActionPerformed;
			}
		}
		_willShowUIMenuEvent.UnRegister(OnWillShowUIMenu);
		foreach (ScriptableRendererFeature item in _heatmapPostProcess)
		{
			item.SetActive(active: false);
		}
	}

	private void OnQuitHeatmapNoBackActionPerformed(InputAction.CallbackContext obj)
	{
		TryToggleHeatmap(toggle: false, goBack: false);
	}

	private void OnQuitHeatmapActionPerformed(InputAction.CallbackContext obj)
	{
		TryToggleHeatmap(toggle: false);
	}

	private void OnHeatmapButtonClicked()
	{
		TryToggleHeatmap(!_heatmapIsOn.Value);
	}

	private void TryToggleHeatmap(bool toggle, bool goBack = true)
	{
		if (toggle == _heatmapIsOn.Value)
		{
			return;
		}
		if (toggle)
		{
			if (CanToggleHeatmap())
			{
				_uiMenuManagerLocator.UIMenuManager.CloseAllOpenMenus();
				_showUIMenuEvent.Fire(new UIPageMenuData(_heatmapMenuLocator.UIMenu, _uiToggles, _ignoredSources));
				ToggleHeatmap(toggle);
			}
		}
		else
		{
			if (goBack)
			{
				TriggerMenuGoBack();
			}
			ToggleHeatmap(toggle);
		}
	}

	private void ToggleHeatmap(bool toggle)
	{
		if (toggle)
		{
			_selectToolButtonPressedEvent.Fire();
		}
		_heatmapIsOn.SetValue(toggle);
		_heatmapCanvas.enabled = toggle;
		foreach (ScriptableRendererFeature item in _heatmapPostProcess)
		{
			item.SetActive(toggle);
		}
	}

	private void TriggerMenuGoBack()
	{
		_uiMenuManagerLocator.UIMenuManager.GoBack(_heatmapUIGoBackSource);
	}

	private bool CanToggleHeatmap()
	{
		if (!_operatorInteriorUIIsOpen.Value)
		{
			return _uiMenuManagerLocator.UIMenuManager.IsCurrentlyShowingOnlyFactoryPanels();
		}
		return false;
	}

	public override void ShowMenu(AbstractUIMenuData menuData)
	{
	}

	public override void HideMenu()
	{
	}
}

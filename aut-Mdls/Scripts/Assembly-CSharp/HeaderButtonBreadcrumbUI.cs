#define ENABLE_DEBUG_WARNINGS
using Data.Variables;
using UI.Breadcrumbs;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class HeaderButtonBreadcrumbUI : BreadcrumbUI
{
	[Header("Header")]
	[SerializeField]
	private Button _button;

	[SerializeField]
	private BreadcrumbStateSO _isNewBreadcrumbState;

	[SerializeField]
	private BoolVariableSO _lockedMenuVariable;

	private string BreadcrumbId => BreadcrumbUtilities.UnlockedMenuBreadcrumbId(_lockedMenuVariable);

	private void Start()
	{
		SetBreadcrumbId(BreadcrumbId);
		_button.onClick.AddListener(OnButtonClicked);
	}

	private void OnDestroy()
	{
		_button.onClick.RemoveListener(OnButtonClicked);
	}

	private void OnButtonClicked()
	{
		_breadcrumbsPersistentSO.RemoveBreadcrumbState(BreadcrumbId, _isNewBreadcrumbState);
	}

	private void OnValidate()
	{
		if (_lockedMenuVariable == null)
		{
			this.LogWarning("_lockedMenuVariable is not set", "OnValidate", 37);
			_listenType = ListenType.WaitToBeSet;
		}
		else
		{
			SetBreadcrumbId(BreadcrumbId);
		}
	}
}

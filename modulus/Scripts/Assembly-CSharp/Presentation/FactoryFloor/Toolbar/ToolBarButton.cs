using System;
using Data.SaveData.PersistentSOs;
using UI.Breadcrumbs;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.Toolbar
{
	public abstract class ToolBarButton : MonoBehaviour
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private GameObject _selectedOutline;

		[SerializeField]
		private OperatorBarButton _operatorButton;

		[Header("Breadcrumb")]
		[SerializeField]
		private BreadcrumbsPersistentSO _breadcrumbsPersistentSO;

		[SerializeField]
		private BreadcrumbUI _breadcrumbUI;

		[SerializeField]
		private BreadcrumbStateSO _clearBreadcrumbStateOnClick;

		public Button Button => _button;

		public abstract bool IsSelected { get; }

		public abstract string BreadcrumbId { get; }

		public event Action<ToolBarButton> Pressed;

		protected virtual void Awake()
		{
			_button.onClick.AddListener(ButtonPressed);
		}

		private void Start()
		{
			if (_breadcrumbsPersistentSO != null && !string.IsNullOrEmpty(BreadcrumbId))
			{
				_breadcrumbUI.SetBreadcrumbId(BreadcrumbId);
			}
		}

		public virtual void Init(OperatorBarButtonSO data, BuildMode buildMode)
		{
			if (_breadcrumbsPersistentSO != null && !string.IsNullOrEmpty(BreadcrumbId))
			{
				_breadcrumbsPersistentSO.SetBreadcrumbTags(BreadcrumbId, BreadcrumbUtilities.BuildBarTabToTag(buildMode, -1));
			}
		}

		protected virtual void OnDestroy()
		{
			_button.onClick.RemoveListener(ButtonPressed);
		}

		protected virtual void ButtonPressed()
		{
			this.Pressed?.Invoke(this);
			if (_operatorButton != null)
			{
				_operatorButton.SetSelected(value: true);
			}
			if (_breadcrumbsPersistentSO != null && !string.IsNullOrEmpty(BreadcrumbId))
			{
				_breadcrumbsPersistentSO.RemoveBreadcrumbState(BreadcrumbId, _clearBreadcrumbStateOnClick);
			}
		}

		public virtual void Selected()
		{
			_selectedOutline.SetActive(value: true);
		}

		public virtual void DeSelected()
		{
			_selectedOutline.SetActive(value: false);
		}
	}
}

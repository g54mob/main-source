using System;
using CTS.BBT;
using CTS.Core;
using CTS.UI;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_WorkerMgr_PriorityToggle : CTSBehaviour
	{
		[SerializeField]
		private Image _iconContainer;

		[SerializeField]
		[Inject(false)]
		private CTSToggle _toggle;

		private ChoreCategoryData _categoryData;

		public ChoreCategory Category => _categoryData.Category;

		public event Action<ChoreCategory, bool> ToggleChanged;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_toggle.onValueChanged.AddListener(OnToggleChanged);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_toggle.onValueChanged.RemoveListener(OnToggleChanged);
		}

		private void OnToggleChanged(bool isOn)
		{
			this.ToggleChanged?.Invoke(_categoryData.Category, isOn);
		}

		public void SetPriority(ChoreCategoryData data)
		{
			_categoryData = data;
			_iconContainer.overrideSprite = _categoryData.Icon;
			GetComponentInChildren<ToolTipsShower>(includeInactive: true).SetTootipsInfo(_categoryData.Name, _categoryData.Description, _toggle.gameObject);
		}

		public void SetInteractable(bool value)
		{
			_toggle.interactable = value;
		}

		public void SetDisplay(bool isShown)
		{
			_toggle.gameObject.SetActive(isShown);
		}

		public void SetValue(bool isOn)
		{
			_toggle.isOn = isOn;
		}
	}
}

using System;
using Data.FactoryFloor.Resources;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.OperatorUIs.OperatorPanelUIs.Spawner
{
	public class NonShapeResourceDataButton : MonoBehaviour
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private GameObject _selectedUI;

		[SerializeField]
		private SettableResourceImage _originalResourceImage;

		private Action<NonShapeResourceDataSO> _onButtonClicked;

		private NonShapeResourceDataSO _resourceData;

		private void Awake()
		{
			_button.onClick.AddListener(OnButtonClick);
		}

		public void Initalize(Action<NonShapeResourceDataSO> onButtonClicked)
		{
			_onButtonClicked = onButtonClicked;
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveListener(OnButtonClick);
		}

		private void OnButtonClick()
		{
			_onButtonClicked(_resourceData);
		}

		public void SetResourceData(NonShapeResourceDataSO resourceData)
		{
			_originalResourceImage.SetResourceData(resourceData);
			_resourceData = resourceData;
		}

		public void SetIsSelected(bool selected)
		{
			_selectedUI.SetActive(selected);
		}
	}
}

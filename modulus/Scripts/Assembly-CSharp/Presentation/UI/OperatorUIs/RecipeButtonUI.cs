using System;
using Data.FactoryFloor.Resources;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.OperatorUIs
{
	public class RecipeButtonUI : MonoBehaviour
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private Image _image;

		[SerializeField]
		private TextInfoPanelContent _infoPanel;

		private int _recipeIndex;

		public Action<int> OnClickAction;

		private void Awake()
		{
			_button.onClick.AddListener(OnButtonClicked);
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveListener(OnButtonClicked);
		}

		public void Build(NonShapeResourceDataSO resourceDataSO, int recipeIndex)
		{
			if (!(resourceDataSO == null))
			{
				_image.sprite = resourceDataSO.Sprite;
				_infoPanel.UpdateContent(resourceDataSO.NameLocaKey);
				_recipeIndex = recipeIndex;
			}
		}

		private void OnButtonClicked()
		{
			OnClickAction(_recipeIndex);
		}
	}
}

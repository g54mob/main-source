using System;
using System.Collections.Generic;
using I2.Loc;
using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class ContentCarouselItem : MonoBehaviour
	{
		public Action<ContentCarouselMenu.Data> OnSelected;

		[SerializeField]
		private Sprite[] _tipIcons;

		[SerializeField]
		private Image _image;

		[SerializeField]
		private Localize _title;

		[SerializeField]
		private Localize _body;

		[SerializeField]
		private DynamicButton _button;

		[SerializeField]
		private CanvasGroup _canvasGroup;

		[SerializeField]
		private GameObject _buttonShading;

		[SerializeField]
		private GameObject _buttonBorder;

		private ContentCarouselMenu.DataInstance _dataInstance;

		public CanvasGroup CanvasGroup => _canvasGroup;

		public void Setup(ContentCarouselMenu.DataInstance dataInstance, List<string> tipsList, int forceTipIconIndex = -1)
		{
			_dataInstance = dataInstance;
			ContentCarouselMenu.Data data = dataInstance.Data;
			if (data?.DLCItem != null)
			{
				_title.SetTerm(data.DLCItem.Name.Term);
				_body.SetTerm(data.DLCItem.Description.Term);
				GameObjectUtils.SetActive(_image.gameObject, data.DLCItem.PromotionImage != null);
				GameObjectUtils.SetActive(_buttonShading, isActive: true);
				GameObjectUtils.SetActive(_buttonBorder, isActive: true);
				_image.overrideSprite = data.DLCItem.PromotionImage;
			}
			else if (data?.ContentDefinition != null)
			{
				_title.SetTerm(data.ContentDefinition.TitleTerm);
				_body.SetTerm(data.ContentDefinition.DescriptionTerm);
				bool flag = data.ContentDefinition.PromotionImages != null && data.ContentDefinition.PromotionImages.Count > 0;
				GameObjectUtils.SetActive(_image.gameObject, flag);
				GameObjectUtils.SetActive(_buttonShading, !data.ContentDefinition.ClickUrl.IsNullOrEmpty());
				GameObjectUtils.SetActive(_buttonBorder, !data.ContentDefinition.ClickUrl.IsNullOrEmpty());
				if (flag)
				{
					int num = forceTipIconIndex;
					if (num < 0 || num >= data.ContentDefinition.PromotionImages.Count)
					{
						num = dataInstance.Count % data.ContentDefinition.PromotionImages.Count;
					}
					_image.overrideSprite = data.ContentDefinition.PromotionImages[num];
				}
			}
			else
			{
				Sprite overrideSprite = null;
				bool flag2 = _tipIcons != null && _tipIcons.Length != 0;
				if (flag2)
				{
					overrideSprite = _tipIcons.RandomItem();
				}
				_title.SetTerm("Frontend/DidYouKnow_Name");
				_body.SetTerm(tipsList.RandomItem());
				GameObjectUtils.SetActive(_image.gameObject, flag2);
				GameObjectUtils.SetActive(_buttonShading, isActive: false);
				GameObjectUtils.SetActive(_buttonBorder, isActive: false);
				_image.overrideSprite = overrideSprite;
			}
		}

		private void OnEnable()
		{
			_button.onPrimaryDown.AddListener(OnPressed);
		}

		private void OnDisable()
		{
			_button.onPrimaryDown.RemoveListener(OnPressed);
		}

		public void SetInteractable(bool interactable)
		{
			_button.interactable = interactable;
		}

		private void OnPressed()
		{
			OnSelected.InvokeSafe(_dataInstance?.Data);
		}
	}
}

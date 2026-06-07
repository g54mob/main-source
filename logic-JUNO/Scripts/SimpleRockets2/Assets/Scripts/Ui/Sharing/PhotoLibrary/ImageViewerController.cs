using System;
using ModApi;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.Sharing.PhotoLibrary
{
	public class ImageViewerController : XmlLayoutController
	{
		private PhotoListItemScript _currentItem;

		private XmlElement _details;

		private XmlElement _detailsDate;

		private XmlElement _detailsDescription;

		private XmlElement _detailsLocation;

		private RawImage _image;

		private RectTransform _imageContainer;

		private XmlElement _indexText;

		private PhotoListItemScript[] _items;

		private XmlElement _panel;

		private PhotoLibraryDialogScript _photoLibraryDialog;

		private Action _selectPhotoAction;

		private XmlElement _selectPhotoButton;

		private XmlElement _sharePhotoButton;

		public bool IsOpen { get; private set; }

		public void Close(bool immediate = false)
		{
			_photoLibraryDialog.SelectedItem = _currentItem;
			IsOpen = false;
			if (immediate)
			{
				_panel.Visible = false;
				_panel.gameObject.SetActive(value: false);
			}
			else
			{
				_panel.Hide();
			}
			_currentItem = null;
			_items = null;
		}

		public void EnablePhotoSelectButton(Action selectPhotoAction)
		{
			_selectPhotoAction = selectPhotoAction;
			_selectPhotoButton.SetAndApplyAttribute("active", "true");
		}

		public void Initialize(PhotoLibraryDialogScript photoLibraryDialog)
		{
			_photoLibraryDialog = photoLibraryDialog;
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			base.LayoutRebuilt(parseResult);
			_panel = base.xmlLayout.GetElementById("panel");
			if (Application.isPlaying)
			{
				_panel.SetAndApplyAttribute("active", "false");
			}
			_image = base.xmlLayout.GetElementById<RawImage>("image");
			_indexText = base.xmlLayout.GetElementById("index-text");
			_imageContainer = base.xmlLayout.GetElementById("image-container").rectTransform;
			_details = base.xmlLayout.GetElementById("details");
			_detailsLocation = base.xmlLayout.GetElementById("details-location");
			_detailsDate = base.xmlLayout.GetElementById("details-date");
			_detailsDescription = base.xmlLayout.GetElementById("details-description");
			_selectPhotoButton = base.xmlLayout.GetElementById("select-photo-button");
			_sharePhotoButton = base.xmlLayout.GetElementById("share-photo-button");
			if (Game.Instance.Device.IsMobileRuntime)
			{
				_sharePhotoButton.SetActive(active: true);
			}
		}

		public void Open()
		{
			IsOpen = true;
			_panel.Show();
			_items = _photoLibraryDialog.GetItems();
			SetPhoto(_photoLibraryDialog.SelectedItem);
		}

		protected virtual void Update()
		{
			if (IsOpen)
			{
				if (UnityEngine.Input.GetKeyDown(KeyCode.RightArrow))
				{
					OnNextClicked();
				}
				else if (UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow))
				{
					OnPreviousClicked();
				}
			}
		}

		private int FindIndexOfItem(PhotoListItemScript photoListItem)
		{
			int result = 0;
			for (int i = 0; i < _items.Length; i++)
			{
				if (photoListItem == _items[i])
				{
					result = i;
				}
			}
			return result;
		}

		private void OnCloseButtonClicked()
		{
			Close();
		}

		private void OnDetailsButtonClicked(XmlElement element)
		{
			element.ToggleClass("toggled");
			if (element.HasClass("toggled"))
			{
				_details.Show();
			}
			else
			{
				_details.Hide();
			}
		}

		private void OnNextClicked()
		{
			int num = FindIndexOfItem(_currentItem);
			num = ((num < _items.Length - 1) ? (num + 1) : 0);
			SetPhoto(_items[num]);
		}

		private void OnPreviousClicked()
		{
			int num = FindIndexOfItem(_currentItem);
			num = ((num <= 0) ? (_items.Length - 1) : (num - 1));
			SetPhoto(_items[num]);
		}

		private void OnSelectPhotoClicked()
		{
			Close(immediate: true);
			_selectPhotoAction();
		}

		private void OnSharePhotoClicked()
		{
			Debug.Log("Sharing photo: " + _currentItem.ItemModel.Photo.Path);
			NativeShare nativeShare = new NativeShare();
			nativeShare.AddFile(_currentItem.ItemModel.Photo.Path);
			nativeShare.Share();
		}

		private void SetImageSize(Texture2D texture)
		{
			float width = _imageContainer.rect.width;
			float num = Mathf.Min(b: _imageContainer.rect.height / (float)texture.height, a: width / (float)texture.width);
			int num2 = (int)((float)texture.width * num);
			int num3 = (int)((float)texture.height * num);
			XmlElement component = _image.GetComponent<XmlElement>();
			component.SetAttribute("width", $"{num2}");
			component.SetAttribute("height", $"{num3}");
			component.ApplyAttributes();
		}

		private void SetPhoto(PhotoListItemScript photoListItem)
		{
			_currentItem = photoListItem;
			int num = FindIndexOfItem(photoListItem);
			_indexText.SetText($"{num + 1}/{_items.Length}");
			try
			{
				Texture2D texture2D = photoListItem.ItemModel.LoadTexture(markNonReadable: true);
				SetImageSize(texture2D);
				_image.texture = texture2D;
			}
			catch (Exception message)
			{
				Debug.LogError(message);
				_image.texture = null;
			}
			UpdateDetails(photoListItem.ItemModel.Photo);
		}

		private void UpdateDetails(IPhoto photo)
		{
			_detailsLocation.SetText(photo.Location);
			string text = Utilities.RelativeDate(DateTime.UtcNow, photo.DateTaken);
			_detailsDate.SetText(text);
			_detailsDescription.SetText(photo.Description);
		}
	}
}

using System;
using ModApi;
using TMPro;
using UI.Xml;

namespace Assets.Scripts.Ui.Sharing.PhotoLibrary
{
	public class DetailsPanel
	{
		private XmlElement _albumDetails;

		private XmlElement _detailsAlbumCount;

		private XmlElement _detailsAlbumSize;

		private XmlElement _detailsPanel;

		private XmlElement _detailsPhotoDate;

		private TMP_InputField _detailsPhotoDescription;

		private XmlElement _detailsPhotoDimensions;

		private XmlElement _detailsPhotoLocation;

		private XmlElement _detailsPhotoSize;

		private PhotoLibraryDialogScript _dialog;

		private PhotoListItemScript _item;

		private XmlElement _itemsPanel;

		private XmlElement _photoDetails;

		public bool Visible
		{
			get
			{
				return _detailsPanel.Visible;
			}
			set
			{
				if (value)
				{
					_itemsPanel.AddClass("details-open");
					_detailsPanel.Show();
					OnSelectedItemChanged(_dialog.SelectedItem);
				}
				else
				{
					_itemsPanel.RemoveClass("details-open");
					_detailsPanel.Hide();
				}
			}
		}

		public DetailsPanel(PhotoLibraryDialogScript dialog, XmlLayout xmlLayout)
		{
			_dialog = dialog;
			_itemsPanel = xmlLayout.GetElementById("items-panel");
			_detailsPanel = xmlLayout.GetElementById("details-panel");
			_photoDetails = xmlLayout.GetElementById("photo-details");
			_albumDetails = xmlLayout.GetElementById("album-details");
			_detailsPhotoLocation = xmlLayout.GetElementById("details-photo-location");
			_detailsPhotoDate = xmlLayout.GetElementById("details-photo-date");
			_detailsPhotoSize = xmlLayout.GetElementById("details-photo-size");
			_detailsPhotoDimensions = xmlLayout.GetElementById("details-photo-dimensions");
			_detailsPhotoDescription = xmlLayout.GetElementById<TMP_InputField>("details-photo-description");
			_detailsPhotoDescription.onEndEdit.AddListener(delegate
			{
				SaveDescription();
			});
			_detailsAlbumCount = xmlLayout.GetElementById("details-album-count");
			_detailsAlbumSize = xmlLayout.GetElementById("details-album-size");
		}

		public void OnSelectedItemChanged(PhotoListItemScript item)
		{
			if (_item != item)
			{
				SaveDescription();
				_item = item;
			}
			if (item != null)
			{
				if (item.ItemModel.Photo != null)
				{
					_photoDetails.Show();
					_albumDetails.Hide();
					UpdatePhotoDetails(item.ItemModel.Photo);
				}
				else
				{
					_photoDetails.Hide();
					_albumDetails.Show();
					UpdateAlbumDetails(item.ItemModel.Album);
				}
			}
			else
			{
				_photoDetails.Hide();
				_albumDetails.Hide();
			}
		}

		private void SaveDescription()
		{
			if (_item?.ItemModel?.Photo != null && _item.ItemModel.Photo.Description != _detailsPhotoDescription.text)
			{
				_item.ItemModel.Photo.Description = _detailsPhotoDescription.text;
				_dialog.SavePhotoLibrary();
			}
		}

		private void UpdateAlbumDetails(IAlbum album)
		{
			_detailsAlbumCount.SetText(album.Photos.Count.ToString());
			int num = 0;
			foreach (IPhoto photo in album.Photos)
			{
				num += photo.SizeInBytes;
			}
			_detailsAlbumSize.SetText(Utilities.FormatMemorySize(num));
		}

		private void UpdatePhotoDetails(IPhoto photo)
		{
			_detailsPhotoLocation.SetText(photo.Location);
			string text = Utilities.RelativeDate(DateTime.UtcNow, photo.DateTaken);
			_detailsPhotoDate.SetText(text);
			string value = photo.DateTaken.ToLocalTime().ToShortDateString();
			_detailsPhotoDate.SetAndApplyAttribute("tooltip", value);
			_detailsPhotoSize.SetText(Utilities.FormatMemorySize(photo.SizeInBytes));
			_detailsPhotoDimensions.SetText(photo.Dimensions);
			_detailsPhotoDescription.text = photo.Description;
		}
	}
}

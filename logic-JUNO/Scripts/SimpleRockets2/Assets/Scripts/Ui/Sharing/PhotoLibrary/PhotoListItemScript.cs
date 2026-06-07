using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.Sharing.PhotoLibrary
{
	public class PhotoListItemScript : MonoBehaviour
	{
		private bool _bulkSelected;

		private PhotoLibraryDialogScript _dialog;

		private bool _loaded;

		private bool _selected;

		public bool BulkSelected
		{
			get
			{
				return _bulkSelected;
			}
			set
			{
				if (_bulkSelected != value)
				{
					_bulkSelected = value;
					if (_bulkSelected && !XmlElement.HasClass("photo-item-bulk-selected"))
					{
						XmlElement.AddClass("photo-item-bulk-selected");
					}
					else if (!_bulkSelected && XmlElement.HasClass("photo-item-bulk-selected"))
					{
						XmlElement.RemoveClass("photo-item-bulk-selected");
					}
				}
			}
		}

		public PhotoItemModel ItemModel { get; private set; }

		public RawImage RawImage { get; private set; }

		public bool Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				if (_selected != value)
				{
					_selected = value;
					if (_selected && !XmlElement.HasClass("photo-item-selected"))
					{
						XmlElement.AddClass("photo-item-selected");
					}
					else if (!_selected && XmlElement.HasClass("photo-item-selected"))
					{
						XmlElement.RemoveClass("photo-item-selected");
					}
				}
			}
		}

		public XmlElement XmlElement { get; private set; }

		public void Initialize(XmlElement element, PhotoItemModel itemModel, PhotoLibraryDialogScript dialog)
		{
			_dialog = dialog;
			XmlElement = element;
			ItemModel = itemModel;
			RawImage = element.GetElementByInternalId<RawImage>("image");
			if (ItemModel.IsAlbum)
			{
				UpdateAlbumText();
			}
		}

		public void LoadThumbnail()
		{
			Texture2D texture2D = ItemModel.LoadThumbnailTexture();
			if (texture2D != null)
			{
				RawImage.texture = texture2D;
				RawImage.color = Color.white;
			}
			else if (ItemModel.IsAlbum)
			{
				RawImage.GetComponent<XmlElement>().AddClass("default-album-thumbnail");
			}
		}

		public void UpdateAlbumText()
		{
			XmlElement.GetElementByInternalId<TextMeshProUGUI>("text").text = ItemModel.Album.Name;
		}

		protected virtual void Update()
		{
			if (!_loaded && _dialog.IsItemVisibleInScrollView(GetComponent<RectTransform>()))
			{
				_loaded = true;
				_dialog.QueueThumbnailLoad(this);
			}
		}
	}
}

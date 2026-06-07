using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Packages.SocialPlatforms.Achievements;
using Assets.Scripts.Input;
using Assets.Scripts.Ui.Sharing.Screenshot;
using ModApi;
using ModApi.Ui;
using SFB;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.Sharing.PhotoLibrary
{
	public class PhotoLibraryDialogScript : DialogScript
	{
		public enum PhotoLibraryDialogFilter
		{
			None = 0,
			SquarePhotosOnly = 1
		}

		public enum PhotoLibraryDialogMode
		{
			Normal = 0,
			SelectPhoto = 1,
			ViewOnly = 2
		}

		private enum BulkAction
		{
			None = 0,
			Move = 1,
			Delete = 2,
			FinishMove = 3
		}

		private static string _lastBrowseDirectory;

		private XmlElement _backButtonPanel;

		private XmlElement _bottomPanel;

		private BulkAction _bulkAction;

		private XmlElement _bulkActionButtonText;

		private XmlElement _bulkActionPanel;

		private TextMeshProUGUI _bulkActionText;

		private List<IPhoto> _bulkMovePhotos = new List<IPhoto>();

		private XmlElement _contextMenuToggleButton;

		private IAlbum _currentAlbum;

		private DetailsPanel _details;

		private PhotoLibraryDialogFilter _filter;

		private XmlElement _headerText;

		private ImageViewerController _imageViewer;

		private XmlElement _itemContextMenu;

		private Queue<PhotoItemModel> _itemQueue = new Queue<PhotoItemModel>();

		private XmlElement _itemsParent;

		private XmlElement _panel;

		private XmlElement _quickDetails;

		private IPhotoLibrary _photoLibrary;

		private bool _saveRequired;

		private ScreenshotDialogScript _screenshotDialog;

		private ScrollRect _scrollRect;

		private PhotoListItemScript _selectedItem;

		private XmlElement _selectPhotoButton;

		private XmlElement _statusMessagePanel;

		private XmlElement _templateAlbum;

		private XmlElement _templatePhoto;

		private Queue<PhotoListItemScript> _thumbnailQueue = new Queue<PhotoListItemScript>();

		public PhotoLibraryDialogFilter Filter
		{
			get
			{
				return _filter;
			}
			set
			{
				if (_filter != value)
				{
					_filter = value;
					if (_currentAlbum != null)
					{
						ViewAlbumPhotos(_currentAlbum);
					}
				}
			}
		}

		public Action<PhotoLibraryDialogScript, PhotoItemModel> OnPhotoSelected { get; set; }

		public PhotoListItemScript SelectedItem
		{
			get
			{
				return _selectedItem;
			}
			set
			{
				if (_selectedItem != value)
				{
					if (_selectedItem != null)
					{
						_selectedItem.Selected = false;
					}
					_selectedItem = value;
					if (_selectedItem != null)
					{
						_selectedItem.Selected = true;
					}
					_details.OnSelectedItemChanged(SelectedItem);
					UpdateContextMenu();
					UpdateQuickDetails();
					if (_selectedItem?.ItemModel?.Photo != null && SupportsFeature(PhotoLibraryFeature.SelectPhoto))
					{
						_selectPhotoButton.Show();
					}
					else
					{
						_selectPhotoButton.Hide();
					}
				}
			}
		}

		public static PhotoLibraryDialogScript Create(Transform parent, PhotoLibraryDialogMode mode = PhotoLibraryDialogMode.Normal)
		{
			string photoLibraryPath = Game.Instance.GameStateManager.GetPhotoLibraryPath(Game.Instance.GameState.Id);
			if (!Directory.Exists(photoLibraryPath))
			{
				photoLibraryPath = Utilities.CombinePaths(Game.PersistentDataPath, "UserData/PhotoLibrary/");
			}
			return Game.Instance.UserInterface.CreateDialog("Ui/Xml/Sharing/PhotoLibraryDialog", parent, delegate(PhotoLibraryDialogScript d, IXmlLayoutController c)
			{
				PhotoLibraryData photoLibraryData = new PhotoLibraryData(photoLibraryPath);
				if (mode == PhotoLibraryDialogMode.Normal)
				{
					photoLibraryData.SupportedFeatures |= PhotoLibraryFeature.AddScreenshot;
				}
				else if (mode == PhotoLibraryDialogMode.SelectPhoto)
				{
					photoLibraryData.SupportedFeatures |= (PhotoLibraryFeature)12;
				}
				else
				{
					_ = mode;
					_ = 2;
				}
				d._photoLibrary = photoLibraryData;
				d.OnLayoutRebuilt((XmlLayout)c.XmlLayout);
			}, delegate
			{
			});
		}

		public static PhotoLibraryDialogScript Create(Transform parent, IPhotoLibrary photoLibrary)
		{
			return Game.Instance.UserInterface.CreateDialog("Ui/Xml/Sharing/PhotoLibraryDialog", parent, delegate(PhotoLibraryDialogScript d, IXmlLayoutController c)
			{
				d._photoLibrary = photoLibrary;
				d.OnLayoutRebuilt((XmlLayout)c.XmlLayout);
			}, delegate
			{
			});
		}

		public override void Close()
		{
			base.Close();
			if (_saveRequired)
			{
				SavePhotoLibrary(immediate: true);
			}
			if (_screenshotDialog != null)
			{
				_screenshotDialog.Close();
			}
			base.gameObject.SetActive(value: false);
			UnityEngine.Object.Destroy(base.gameObject);
		}

		public PhotoListItemScript CreateItem(PhotoItemModel itemModel, XmlElement template)
		{
			XmlElement xmlElement = UiUtilities.CloneTemplate(template, _itemsParent);
			PhotoListItemScript photoListItemScript = xmlElement.gameObject.AddComponent<PhotoListItemScript>();
			photoListItemScript.Initialize(xmlElement, itemModel, this);
			return photoListItemScript;
		}

		public PhotoListItemScript[] GetItems()
		{
			return _itemsParent.GetComponentsInChildren<PhotoListItemScript>(includeInactive: true);
		}

		public void Hide()
		{
			if (_saveRequired)
			{
				SavePhotoLibrary(immediate: true);
			}
			Game.Instance.UserInterface.UnregisterDialog(this);
			base.gameObject.SetActive(value: false);
		}

		public bool IsItemVisibleInScrollView(RectTransform item)
		{
			RectTransform component = _scrollRect.GetComponent<RectTransform>();
			float num = Mathf.Abs(item.localPosition.y + _scrollRect.content.localPosition.y);
			float num2 = 75f;
			if (num >= 0f - num2)
			{
				return num < component.rect.height + num2;
			}
			return false;
		}

		public void OnToggleDetailsPanel(XmlElement element)
		{
			_details.Visible = !_details.Visible;
			if (_details.Visible)
			{
				element.AddClass("btn-primary");
			}
			else
			{
				element.RemoveClass("btn-primary");
			}
		}

		public void QueueThumbnailLoad(PhotoListItemScript photoListItemScript)
		{
			_thumbnailQueue.Enqueue(photoListItemScript);
		}

		public void SavePhotoLibrary(bool immediate = false)
		{
			if (immediate)
			{
				_saveRequired = false;
				_photoLibrary.Save();
			}
			else
			{
				_saveRequired = true;
			}
		}

		public void Show()
		{
			Game.Instance.UserInterface.RegisterDialog(this);
			base.gameObject.SetActive(value: true);
		}

		protected override void Start()
		{
			base.Start();
			if (SupportsFeature(PhotoLibraryFeature.SelectPhoto))
			{
				_imageViewer.EnablePhotoSelectButton(delegate
				{
					OnSelectPhotoClicked();
				});
			}
			_panel.Show();
			IAlbum album = null;
			foreach (IAlbum album2 in _photoLibrary.Albums)
			{
				if (_photoLibrary.LastSelectedAlbumName == album2.Name)
				{
					album = album2;
					break;
				}
			}
			if (album != null)
			{
				ViewAlbumPhotos(album);
			}
			else
			{
				ViewAlbums();
			}
		}

		protected virtual void Update()
		{
			ProcessQueues();
			if (Game.Instance.UserInterface.ActiveDialog != this)
			{
				return;
			}
			if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
			{
				if (_imageViewer.IsOpen)
				{
					_imageViewer.Close();
				}
				else if (_bulkAction != BulkAction.None)
				{
					OnCancelBulkAction();
				}
				else if (_currentAlbum != null)
				{
					OnBackButtonClicked();
				}
				else
				{
					Close();
				}
			}
			else if ((UnityEngine.Input.GetKeyDown(KeyCode.C) || DebugInput.GetKeyDown(KeyCode.G)) && (UnityEngine.Input.GetKey(KeyCode.LeftControl) || UnityEngine.Input.GetKey(KeyCode.LeftMeta)))
			{
				switch (ImageClipboardUtility.CopyImageToClipboard(SelectedItem.ItemModel.Photo.Path))
				{
				case ImageClipboardUtility.CopyImageResult.Succeeded:
					ShowStatusMessage("Copied image to clipboard.");
					break;
				case ImageClipboardUtility.CopyImageResult.Failed:
					ShowStatusMessage("Could not copy image to clipboard.");
					break;
				}
			}
		}

		private void AddFile(string path)
		{
			IAlbum album = SelectedItem?.ItemModel?.Album;
			IPhoto photo = _photoLibrary.AddFileToAlbum(path, album);
			if (photo?.Album != null)
			{
				ViewAlbumPhotos(photo.Album);
			}
			else
			{
				ViewAlbums();
			}
		}

		private void ClearItems()
		{
			SelectedItem = null;
			_thumbnailQueue.Clear();
			_itemQueue.Clear();
			PhotoListItemScript[] items = GetItems();
			foreach (PhotoListItemScript item in items)
			{
				DeleteItem(item);
			}
		}

		private void CreateAlbumConfirmed(ModApi.Ui.InputDialogScript dialog)
		{
			if (!string.IsNullOrWhiteSpace(dialog.InputText))
			{
				IAlbum album = _photoLibrary.CreateAlbum(dialog.InputText);
				SavePhotoLibrary();
				ViewAlbumPhotos(album);
				dialog.Close();
			}
		}

		private IEnumerator DeleteAlbumAsync(IAlbum album, PhotoListItemScript albumItem)
		{
			ShowStatusMessage("Deleting album...");
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			try
			{
				_photoLibrary.DeleteAlbum(album);
				SavePhotoLibrary(immediate: true);
				SelectedItem = null;
				DeleteItem(albumItem);
				ShowStatusMessage($"Deleted album '{album.Name}'");
			}
			catch (Exception ex)
			{
				Game.Instance.UserInterface.CreateMessageDialog().MessageText = "Could not delete album: " + ex.Message;
				Debug.LogError(ex);
			}
		}

		private void DeleteItem(PhotoListItemScript item)
		{
			_itemsParent.RemoveChildElement(item.XmlElement, destroyChild: true);
		}

		private void EndBulkAction(bool deselectItems)
		{
			_bulkAction = BulkAction.None;
			_bottomPanel.Show();
			_bulkActionPanel.Hide();
			if (deselectItems)
			{
				PhotoListItemScript[] items = GetItems();
				for (int i = 0; i < items.Length; i++)
				{
					items[i].BulkSelected = false;
				}
			}
			UpdateContextMenu();
		}

		private IEnumerator ExecuteBulkActionAsync()
		{
			if (_bulkAction == BulkAction.Delete)
			{
				ShowStatusMessage("Deleting photos...");
			}
			else if (_bulkAction == BulkAction.FinishMove)
			{
				ShowStatusMessage("Moving photos...");
			}
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			if (_bulkAction == BulkAction.Delete)
			{
				PhotoListItemScript[] items = GetItems();
				int num = 0;
				PhotoListItemScript[] array = items;
				foreach (PhotoListItemScript photoListItemScript in array)
				{
					if (photoListItemScript.BulkSelected)
					{
						_photoLibrary.DeletePhoto(photoListItemScript.ItemModel.Photo);
						DeleteItem(photoListItemScript);
						num++;
					}
				}
				if (num > 0)
				{
					SavePhotoLibrary(immediate: true);
					EndBulkAction(deselectItems: false);
					ShowStatusMessage(string.Format("Deleted {0} photo{1}", num, (num != 1) ? "s" : string.Empty));
				}
				else
				{
					ShowStatusMessage("Please select at least one photo to delete.");
				}
			}
			else if (_bulkAction == BulkAction.Move)
			{
				_bulkMovePhotos.Clear();
				PhotoListItemScript[] array = GetItems();
				foreach (PhotoListItemScript photoListItemScript2 in array)
				{
					if (photoListItemScript2.BulkSelected)
					{
						_bulkMovePhotos.Add(photoListItemScript2.ItemModel.Photo);
					}
				}
				if (_bulkMovePhotos.Count > 0)
				{
					ViewAlbums();
					_bulkAction = BulkAction.FinishMove;
					UpdateBulkActionText();
				}
				else
				{
					ShowStatusMessage("Please select at least one photo to move.");
				}
			}
			else
			{
				if (_bulkAction != BulkAction.FinishMove)
				{
					yield break;
				}
				if (SelectedItem == null || !SelectedItem.ItemModel.IsAlbum)
				{
					ShowStatusMessage("Please select an album above.");
					yield break;
				}
				IAlbum album = SelectedItem.ItemModel.Album;
				foreach (IPhoto bulkMovePhoto in _bulkMovePhotos)
				{
					bulkMovePhoto.Move(album);
				}
				SavePhotoLibrary();
				EndBulkAction(deselectItems: false);
				if (_bulkMovePhotos.Count > 0)
				{
					ShowStatusMessage(string.Format("Moved {0} photo{1} to album '{2}'", _bulkMovePhotos.Count, (_bulkMovePhotos.Count == 1) ? string.Empty : "s", album.Name));
				}
			}
		}

		private void OnAddScreenshotClicked()
		{
			AlbumData album = null;
			if (_currentAlbum != null)
			{
				album = _currentAlbum as AlbumData;
			}
			else if (SelectedItem != null)
			{
				album = SelectedItem.ItemModel.Album as AlbumData;
			}
			if (album != null)
			{
				if (_screenshotDialog == null)
				{
					_screenshotDialog = ScreenshotDialogScript.Create(null);
				}
				_panel.Hide();
				_screenshotDialog.Activate();
				_screenshotDialog.OnScreenshotComplete = delegate(Texture2D x)
				{
					OnScreenshotComplete(x, album);
				};
			}
			else
			{
				ShowStatusMessage("Please select an album and then click the Add Photo button again");
			}
		}

		private void OnBackButtonClicked()
		{
			if (_bulkAction != BulkAction.None)
			{
				EndBulkAction(deselectItems: true);
			}
			ViewAlbums();
		}

		private void OnBrowseClicked()
		{
			if (_lastBrowseDirectory == null)
			{
				_lastBrowseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
			}
			ExtensionFilter[] extensions = new ExtensionFilter[1]
			{
				new ExtensionFilter("Image", "png", "jpg", "jpeg")
			};
			StandaloneFileBrowser.OpenFilePanelAsync("Choose image", _lastBrowseDirectory, extensions, multiselect: false, delegate(string[] paths)
			{
				if (paths.Length != 0)
				{
					string path = paths[0];
					_lastBrowseDirectory = Directory.GetDirectoryRoot(path);
					AddFile(path);
				}
			});
		}

		private void OnCancelBulkAction()
		{
			EndBulkAction(deselectItems: true);
		}

		private void OnCloseButtonClicked()
		{
			Close();
		}

		private void OnContextMenuButtonClicked()
		{
			_itemContextMenu.ToggleVisibility();
		}

		private void OnCreateAlbumClicked()
		{
			_itemContextMenu.Hide();
			ModApi.Ui.InputDialogScript inputDialogScript = Game.Instance.UserInterface.CreateInputDialog();
			inputDialogScript.MessageText = "Create Album";
			inputDialogScript.InputPlaceholderText = "Album Name";
			inputDialogScript.MaxLength = 25;
			inputDialogScript.OkayClicked += delegate(ModApi.Ui.InputDialogScript d)
			{
				CreateAlbumConfirmed(d);
			};
		}

		private void OnDeleteAlbumClicked()
		{
			_itemContextMenu.Hide();
			PhotoListItemScript selectedItem = SelectedItem;
			IAlbum album = SelectedItem.ItemModel.Album;
			ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.MessageText = $"Confirm that you wish to delete album '{album.Name}'. All photos in the album will be deleted.";
			messageDialogScript.UseDangerButtonStyle = true;
			messageDialogScript.OkayButtonText = "DELETE";
			messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript d)
			{
				d.Close();
				StartCoroutine(DeleteAlbumAsync(album, selectedItem));
			};
		}

		private void OnDeletePhotosClicked()
		{
			_itemContextMenu.Hide();
			StartBulkAction(BulkAction.Delete);
		}

		private void OnExecuteBulkAction()
		{
			StartCoroutine(ExecuteBulkActionAsync());
		}

		private void OnItemClicked(XmlElement element)
		{
			PhotoListItemScript component = element.GetComponent<PhotoListItemScript>();
			if (!(component != null))
			{
				return;
			}
			if (_bulkAction == BulkAction.None)
			{
				if (SelectedItem == component)
				{
					if (SelectedItem.ItemModel.IsAlbum)
					{
						ViewAlbumPhotos(SelectedItem.ItemModel.Album);
					}
					else
					{
						_imageViewer.Open();
					}
				}
				else
				{
					SelectedItem = component;
				}
			}
			else
			{
				if (_bulkAction == BulkAction.FinishMove)
				{
					SelectedItem = component;
				}
				else
				{
					component.BulkSelected = !component.BulkSelected;
				}
				UpdateBulkActionText();
			}
		}

		private void OnLayoutRebuilt(XmlLayout xmlLayout)
		{
			_panel = xmlLayout.GetElementById("panel");
			_quickDetails = xmlLayout.GetElementById("quick-details");
			_templatePhoto = xmlLayout.GetElementById("template-photo");
			_templateAlbum = xmlLayout.GetElementById("template-album");
			_scrollRect = xmlLayout.GetElementById<ScrollRect>("items-scroll-view");
			_itemsParent = xmlLayout.GetElementById("items-parent");
			_backButtonPanel = xmlLayout.GetElementById("back-button-panel");
			_headerText = xmlLayout.GetElementById("header-text");
			_itemContextMenu = xmlLayout.GetElementById("item-context-menu");
			XmlElement elementById = xmlLayout.GetElementById("details-toggle-button");
			_contextMenuToggleButton = xmlLayout.GetElementById("context-menu-toggle-button");
			_statusMessagePanel = xmlLayout.GetElementById("status-message-panel");
			_bulkActionPanel = xmlLayout.GetElementById("bulk-action-panel");
			_bulkActionText = xmlLayout.GetElementById<TextMeshProUGUI>("bulk-action-text");
			_bottomPanel = xmlLayout.GetElementById("bottom-panel");
			_bulkActionButtonText = xmlLayout.GetElementById("bulk-action-button-text");
			_selectPhotoButton = xmlLayout.GetElementById("select-photo-button");
			_imageViewer = xmlLayout.GetComponentInChildren<ImageViewerController>();
			_imageViewer.Initialize(this);
			_details = new DetailsPanel(this, xmlLayout);
			if (!SupportsFeature(PhotoLibraryFeature.AddScreenshot))
			{
				xmlLayout.GetElementById("take-photo-button").SetActive(active: false);
			}
			if (!SupportsFeature(PhotoLibraryFeature.Browse))
			{
				xmlLayout.GetElementById("browse-photo-button").SetActive(active: false);
			}
			_contextMenuToggleButton.SetActive(SupportsFeature(PhotoLibraryFeature.ContextMenu));
			elementById.SetActive(SupportsFeature(PhotoLibraryFeature.DetailsPanel));
			_panel.SetAttribute("active", "false");
		}

		private void OnMovePhotosClicked()
		{
			_itemContextMenu.Hide();
			StartBulkAction(BulkAction.Move);
		}

		private void OnRenameAlbumClicked()
		{
			_itemContextMenu.Hide();
			PhotoListItemScript selectedItem = SelectedItem;
			IAlbum album = SelectedItem.ItemModel.Album;
			if (album != null)
			{
				ModApi.Ui.InputDialogScript inputDialogScript = Game.Instance.UserInterface.CreateInputDialog();
				inputDialogScript.MessageText = "Rename Album";
				inputDialogScript.InputText = album.Name;
				inputDialogScript.MaxLength = 25;
				inputDialogScript.OkayClicked += delegate(ModApi.Ui.InputDialogScript d)
				{
					RenameAlbumConfirmed(d, selectedItem, album);
				};
			}
		}

		private void OnScreenshotComplete(Texture2D screenshot, AlbumData album)
		{
			_screenshotDialog.Deactivate();
			_panel.Show();
			if (screenshot != null)
			{
				IPhoto photo = _photoLibrary.CreateNewPhoto(screenshot, album);
				SavePhotoLibrary(immediate: true);
				if (_currentAlbum == album)
				{
					PhotoItemModel photoItemModel = new PhotoItemModel();
					photoItemModel.Photo = photo;
					PhotoListItemScript photoListItemScript = CreateItem(photoItemModel, _templatePhoto);
					photoListItemScript.transform.SetSiblingIndex(0);
					ScrollToTop();
					SelectedItem = photoListItemScript;
				}
				UnityEngine.Object.Destroy(screenshot);
				ShowStatusMessage($"Added photo to album '{album.Name}'");
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.PhotoLibraryTakePicture);
			}
		}

		private void OnSelectPhotoClicked()
		{
			OnPhotoSelected(this, SelectedItem.ItemModel);
		}

		private void OnSetAlbumCoverClicked()
		{
			_itemContextMenu.Hide();
			if (SelectedItem != null)
			{
				SelectedItem.ItemModel.Photo.Album.SetThumbnailPhoto(SelectedItem.ItemModel.Photo);
				SavePhotoLibrary();
				ShowStatusMessage("Updated Album Cover");
			}
		}

		private bool PhotoMatchesFilter(IPhoto photo)
		{
			if (Filter == PhotoLibraryDialogFilter.SquarePhotosOnly)
			{
				string[] array = photo.Dimensions.Split(new char[1] { 'x' });
				if (array.Length == 2)
				{
					return array[0] == array[1];
				}
				return false;
			}
			return true;
		}

		private void ProcessQueues()
		{
			if (_thumbnailQueue.Count > 0)
			{
				_thumbnailQueue.Dequeue().LoadThumbnail();
			}
			if (_itemQueue.Count > 0)
			{
				PhotoItemModel photoItemModel = _itemQueue.Dequeue();
				if (photoItemModel.IsAlbum)
				{
					CreateItem(photoItemModel, _templateAlbum);
				}
				else
				{
					CreateItem(photoItemModel, _templatePhoto);
				}
			}
		}

		private void RenameAlbumConfirmed(ModApi.Ui.InputDialogScript dialog, PhotoListItemScript selectedItem, IAlbum album)
		{
			if (dialog.InputText == album.Name)
			{
				dialog.Close();
				return;
			}
			try
			{
				string newName = dialog.InputText;
				if (!_photoLibrary.Albums.Any((IAlbum x) => x.Name == newName))
				{
					album.Name = newName;
					SavePhotoLibrary();
					selectedItem.UpdateAlbumText();
					dialog.Close();
					ShowStatusMessage($"Renamed album to '{newName}'");
					return;
				}
				throw new Exception($"Another album already has the name '{newName}'.");
			}
			catch (Exception ex)
			{
				Game.Instance.UserInterface.CreateMessageDialog().MessageText = "Could not rename album: " + ex.Message;
				Debug.LogError(ex);
			}
		}

		private void ScrollToTop()
		{
			Vector2 anchoredPosition = _scrollRect.content.anchoredPosition;
			anchoredPosition.y = 0f;
			_scrollRect.content.anchoredPosition = anchoredPosition;
		}

		private void ShowStatusMessage(string message)
		{
			_statusMessagePanel.Show();
			_statusMessagePanel.GetComponentInChildren<TextMeshProUGUI>().text = message;
			XmlLayoutTimer.DelayedCall(3f, delegate
			{
				_statusMessagePanel.Hide();
			}, this);
		}

		private void StartBulkAction(BulkAction bulkAction)
		{
			_bulkAction = bulkAction;
			if (SelectedItem != null)
			{
				SelectedItem.BulkSelected = true;
				SelectedItem = null;
			}
			UpdateBulkActionText();
			_bottomPanel.Hide();
			_bulkActionPanel.Show();
			UpdateContextMenu();
		}

		private bool SupportsFeature(PhotoLibraryFeature feature)
		{
			return (_photoLibrary.SupportedFeatures & feature) > PhotoLibraryFeature.None;
		}

		private void UpdateBulkActionText()
		{
			if (_bulkAction == BulkAction.FinishMove)
			{
				if (SelectedItem != null)
				{
					int count = _bulkMovePhotos.Count;
					string arg = SelectedItem.ItemModel.Album.Name;
					_bulkActionText.text = string.Format("Move {0} photo{1} to album '{2}'", count, (count == 1) ? string.Empty : "s", arg);
				}
				else
				{
					_bulkActionText.text = "Where would you like to move the photos?";
				}
			}
			else
			{
				int num = (from x in GetItems()
					where x.BulkSelected
					select x).Count();
				_bulkActionText.text = string.Format("{0} photo{1} selected", num, (num == 1) ? string.Empty : "s");
			}
			string value = ((_bulkAction == BulkAction.Move) ? "CHOOSE ALBUM" : ((_bulkAction != BulkAction.FinishMove) ? "DELETE" : "MOVE"));
			_bulkActionButtonText.SetAndApplyAttribute("text", value);
		}

		private void UpdateContextMenu()
		{
			_itemContextMenu.Hide();
			if (_bulkAction == BulkAction.None)
			{
				if (SupportsFeature(PhotoLibraryFeature.ContextMenu))
				{
					_contextMenuToggleButton.Show();
				}
			}
			else
			{
				_contextMenuToggleButton.Hide();
			}
			foreach (XmlElement item in _itemContextMenu.GetChildElementsWithClass("context-menu-button"))
			{
				bool active = true;
				if (_currentAlbum == null && item.HasClass("photo-only"))
				{
					active = false;
				}
				else if (_currentAlbum != null && item.HasClass("album-only"))
				{
					active = false;
				}
				if (SelectedItem == null && item.HasClass("requires-selection"))
				{
					active = false;
				}
				item.gameObject.SetActive(active);
			}
		}

		private void UpdateQuickDetails()
		{
			if (SelectedItem?.ItemModel?.Photo != null)
			{
				_quickDetails.SetActive(active: true);
				IPhoto photo = SelectedItem.ItemModel.Photo;
				_quickDetails.GetElementByInternalId<TextMeshProUGUI>("text").text = photo.FileName + "\n" + photo.Dimensions;
			}
			else
			{
				_quickDetails.SetActive(active: false);
			}
		}

		private void ViewAlbumPhotos(IAlbum album)
		{
			ClearItems();
			_photoLibrary.LastSelectedAlbumName = album.Name;
			_currentAlbum = album;
			_headerText.SetText(album.Name);
			_backButtonPanel.Show();
			foreach (IPhoto item in album.Photos.OrderByDescending((IPhoto x) => x.DateTaken).ToList())
			{
				if (PhotoMatchesFilter(item))
				{
					PhotoItemModel photoItemModel = new PhotoItemModel();
					photoItemModel.Photo = item as PhotoData;
					_itemQueue.Enqueue(photoItemModel);
				}
			}
			UpdateContextMenu();
			ScrollToTop();
		}

		private void ViewAlbums()
		{
			ClearItems();
			_photoLibrary.LastSelectedAlbumName = null;
			_currentAlbum = null;
			_headerText.SetText("Albums");
			_backButtonPanel.Hide();
			foreach (IAlbum item in _photoLibrary.Albums.OrderBy((IAlbum x) => x.Name).ToList())
			{
				PhotoItemModel photoItemModel = new PhotoItemModel();
				photoItemModel.Album = item;
				_itemQueue.Enqueue(photoItemModel);
			}
			UpdateContextMenu();
			ScrollToTop();
		}
	}
}

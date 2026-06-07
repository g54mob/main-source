using System.Collections.Generic;
using Assets.Scripts.Ui.Sharing.PhotoLibrary;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.Sharing.Screenshot
{
	public class ScreenshotListController : XmlLayoutController
	{
		private const string _PreventTakeScreenshotClass = "prevent-take";

		private Transform _dialogTransform;

		private int _numOptionalScreenshots;

		private PhotoLibraryDialogScript _photoLibraryDialog;

		private RawImage _primaryThumbnail;

		private XmlElement _primaryThumbnailDeleteButton;

		private ScreenshotDialogScript _screenshotDialog;

		private XmlElement _thumbnailActions;

		private XmlElement _thumbnailTemplate;

		private XmlElement _verticalLayout;

		public bool HasPrimaryThumbnail => _primaryThumbnail.texture != null;

		public int MasOptionalScreenshots { get; private set; }

		public bool PreventTakeScreenshot
		{
			get
			{
				return _verticalLayout.HasClass("prevent-take");
			}
			set
			{
				bool flag = _verticalLayout.HasClass("prevent-take");
				if (value && !flag)
				{
					_verticalLayout.AddClass("prevent-take");
				}
				else if (!value && flag)
				{
					_verticalLayout.RemoveClass("prevent-take");
				}
			}
		}

		public bool ValidChecksums { get; private set; } = true;

		public IEnumerable<Texture2D> GetTextures()
		{
			RawImage[] componentsInChildren = GetComponentsInChildren<RawImage>();
			List<Texture2D> list = new List<Texture2D>();
			RawImage[] array = componentsInChildren;
			foreach (RawImage rawImage in array)
			{
				list.Add(rawImage.texture as Texture2D);
			}
			return list;
		}

		public void Initialize(Transform dialogTransform, int maxOptionalScreenshots)
		{
			_dialogTransform = dialogTransform;
			MasOptionalScreenshots = maxOptionalScreenshots;
			_screenshotDialog = ScreenshotDialogScript.Create(null);
			_screenshotDialog.gameObject.SetActive(value: false);
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			base.LayoutRebuilt(parseResult);
			_primaryThumbnail = base.xmlLayout.GetElementById<RawImage>("primary-thumbnail");
			_primaryThumbnailDeleteButton = base.xmlLayout.GetElementById("primary-thumbnail-delete-button");
			_thumbnailTemplate = base.xmlLayout.GetElementById("thumbnail-template");
			_thumbnailActions = base.xmlLayout.GetElementById("thumbnail-actions");
			_verticalLayout = base.xmlLayout.GetElementById("vertical-layout");
		}

		public void OnDialogClosed()
		{
			if (_photoLibraryDialog != null)
			{
				_photoLibraryDialog.Close();
			}
			if (_screenshotDialog != null)
			{
				_screenshotDialog.Close();
			}
		}

		private void LoadPhotoCommon(bool thumbnail)
		{
			_dialogTransform.gameObject.SetActive(value: false);
			if (_photoLibraryDialog == null)
			{
				_photoLibraryDialog = PhotoLibraryDialogScript.Create(_dialogTransform.parent, PhotoLibraryDialogScript.PhotoLibraryDialogMode.SelectPhoto);
				_photoLibraryDialog.Closed += delegate
				{
					_dialogTransform.gameObject.SetActive(value: true);
					_photoLibraryDialog = null;
				};
			}
			else
			{
				_photoLibraryDialog.Show();
			}
			_photoLibraryDialog.OnPhotoSelected = delegate(PhotoLibraryDialogScript dialog, PhotoItemModel photoItem)
			{
				_photoLibraryDialog.Hide();
				_dialogTransform.gameObject.SetActive(value: true);
				Texture2D texture = photoItem.LoadTexture(markNonReadable: false, validateChecksum: true);
				OnScreenshotComplete(texture, thumbnail, photoItem.HasValidChecksum.Value);
			};
			_photoLibraryDialog.Filter = (thumbnail ? PhotoLibraryDialogScript.PhotoLibraryDialogFilter.SquarePhotosOnly : PhotoLibraryDialogScript.PhotoLibraryDialogFilter.None);
		}

		private void OnLoadPhotoClicked()
		{
			LoadPhotoCommon(thumbnail: false);
		}

		private void OnLoadThumbnail()
		{
			LoadPhotoCommon(thumbnail: true);
		}

		private void OnNewPhotoClicked()
		{
			_screenshotDialog.RequireSquareOrientation = false;
			_screenshotDialog.Activate();
			_screenshotDialog.OnScreenshotComplete = delegate(Texture2D x)
			{
				_screenshotDialog.Deactivate();
				OnScreenshotComplete(x, primaryThumbnail: false, validChecksum: true);
			};
			_dialogTransform.gameObject.SetActive(value: false);
		}

		private void OnScreenshotComplete(Texture2D texture, bool primaryThumbnail, bool validChecksum)
		{
			_dialogTransform.gameObject.SetActive(value: true);
			if (texture != null)
			{
				if (primaryThumbnail)
				{
					UpdateTexture(_primaryThumbnail, texture);
					_primaryThumbnailDeleteButton.Show();
				}
				else
				{
					XmlElement xmlElement = UiUtilities.CloneTemplate(_thumbnailTemplate, _verticalLayout);
					xmlElement.transform.SetSiblingIndex(_thumbnailActions.transform.GetSiblingIndex() - 1);
					RawImage elementByInternalId = xmlElement.GetElementByInternalId<RawImage>("raw-image");
					UpdateTexture(elementByInternalId, texture);
					_numOptionalScreenshots++;
				}
			}
			ValidChecksums &= validChecksum;
			UpdateScreenshotActionsVisibility();
		}

		private void OnScreenshotDeleteClicked(XmlElement xmlElement)
		{
			Transform parent = xmlElement.transform.parent;
			RawImage componentInChildren = parent.GetComponentInChildren<RawImage>(includeInactive: true);
			if (componentInChildren == _primaryThumbnail)
			{
				componentInChildren.gameObject.SetActive(value: false);
				Object.Destroy(componentInChildren.texture);
				componentInChildren.texture = null;
				_primaryThumbnailDeleteButton.Hide();
			}
			else
			{
				Object.Destroy(parent.gameObject);
				_numOptionalScreenshots--;
			}
			UpdateScreenshotActionsVisibility();
		}

		private void OnTakeThumbnail()
		{
			_screenshotDialog.RequireSquareOrientation = true;
			_screenshotDialog.Activate();
			_screenshotDialog.OnScreenshotComplete = delegate(Texture2D x)
			{
				_screenshotDialog.Deactivate();
				OnScreenshotComplete(x, primaryThumbnail: true, validChecksum: true);
			};
			_dialogTransform.gameObject.SetActive(value: false);
		}

		private void UpdateScreenshotActionsVisibility()
		{
			if (_numOptionalScreenshots >= MasOptionalScreenshots)
			{
				_thumbnailActions.Hide();
			}
			else
			{
				_thumbnailActions.Show();
			}
		}

		private void UpdateTexture(RawImage rawImage, Texture2D texture)
		{
			rawImage.texture = texture;
			rawImage.gameObject.SetActive(value: true);
			float num = (float)texture.width / (float)texture.height;
			if (num > 1f)
			{
				rawImage.transform.localScale = new Vector3(1f, 1f / num, 1f);
			}
			else
			{
				rawImage.transform.localScale = new Vector3(1f * num, 1f, 1f);
			}
		}
	}
}

using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	public class PhotoGalleryManager : MonoBehaviour
	{
		[Serializable]
		public class PhotoItem
		{
			public string title = "Title";

			public string description = "Description";

			public Sprite photo;

			[HideInInspector]
			public bool isCustom;

			[HideInInspector]
			public PhotoGalleryPreset preset;
		}

		public List<PhotoItem> photoItems = new List<PhotoItem>();

		private PhotoGalleryPreset currentPreset;

		[SerializeField]
		private GameObject pictureLibraryPreset;

		[SerializeField]
		private Transform pictureLibraryParent;

		[SerializeField]
		private Image imageViewer;

		[SerializeField]
		private TextMeshProUGUI viewerTitle;

		[SerializeField]
		private TextMeshProUGUI viewerDescription;

		[SerializeField]
		private ButtonManager nextButton;

		[SerializeField]
		private ButtonManager previousButton;

		[SerializeField]
		private WindowPanelManager panelManager;

		public bool allowArrowNavigation = true;

		public string viewerPanelName = "Viewer";

		private bool bypassArrowKeys;

		private void Awake()
		{
			Initialize();
		}

		private void Update()
		{
			if (allowArrowNavigation && !(panelManager.panels[panelManager.currentPanelIndex].panelName != viewerPanelName) && !(currentPreset == null))
			{
				if (Keyboard.current.leftArrowKey.wasPressedThisFrame && currentPreset.photoIndex > 0)
				{
					PrevAction();
				}
				else if (Keyboard.current.rightArrowKey.wasPressedThisFrame && currentPreset.photoIndex < photoItems.Count - 1)
				{
					NextAction();
				}
			}
		}

		public void Initialize()
		{
			foreach (Transform item in pictureLibraryParent)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			for (int i = 0; i < photoItems.Count; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(pictureLibraryPreset, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject.transform.SetParent(pictureLibraryParent, worldPositionStays: false);
				gameObject.gameObject.name = photoItems[i].title;
				PhotoGalleryPreset preset = gameObject.GetComponent<PhotoGalleryPreset>();
				preset.photoIndex = i;
				preset.manager = this;
				preset.photoTitle = photoItems[i].title;
				preset.titleText.text = photoItems[i].title;
				preset.descriptionText.text = photoItems[i].description;
				preset.photoImage.sprite = photoItems[i].photo;
				photoItems[i].preset = preset;
				if (preset.photoImage.sprite.texture.height > preset.photoImage.sprite.texture.width)
				{
					preset.aspectRatioFitter.aspectRatio = 0.5f;
				}
				else
				{
					preset.aspectRatioFitter.aspectRatio = 1.8f;
				}
				gameObject.GetComponent<ButtonManager>().onClick.AddListener(delegate
				{
					OpenPhoto(preset.photoIndex);
				});
			}
			if (nextButton != null && previousButton != null)
			{
				nextButton.onClick.RemoveAllListeners();
				previousButton.onClick.RemoveAllListeners();
				nextButton.onClick.AddListener(NextAction);
				previousButton.onClick.AddListener(PrevAction);
			}
		}

		public void OpenPhoto(int index)
		{
			currentPreset = photoItems[index].preset;
			imageViewer.sprite = photoItems[index].photo;
			viewerTitle.text = photoItems[index].title;
			viewerDescription.text = photoItems[index].description;
			bypassArrowKeys = false;
			CheckForButtonStates();
			panelManager.OpenPanel(viewerPanelName);
		}

		public void OpenPhoto(string photoTitle)
		{
			for (int i = 0; i < photoItems.Count; i++)
			{
				if (photoItems[i].title == photoTitle)
				{
					OpenPhoto(i);
					break;
				}
			}
		}

		public void OpenPhoto(Sprite photo, string title, string description)
		{
			imageViewer.sprite = photo;
			viewerTitle.text = title;
			viewerDescription.text = description;
			panelManager.OpenPanel(viewerPanelName);
			bypassArrowKeys = true;
			CheckForButtonStates();
		}

		public void DeletePhoto(int index)
		{
			UnityEngine.Object.Destroy(photoItems[index].preset.gameObject);
			photoItems.RemoveAt(index);
			panelManager.OpenFirstPanel();
		}

		public void DeletePhoto(string photoTitle)
		{
			for (int i = 0; i < photoItems.Count; i++)
			{
				if (photoItems[i].title == photoTitle)
				{
					DeletePhoto(i);
					break;
				}
			}
		}

		public void CreatePhoto(Sprite photo, string title, string description)
		{
			GameObject obj = UnityEngine.Object.Instantiate(pictureLibraryPreset, new Vector3(0f, 0f, 0f), Quaternion.identity);
			obj.transform.SetParent(pictureLibraryParent, worldPositionStays: false);
			obj.gameObject.name = title;
			PhotoGalleryPreset component = obj.GetComponent<PhotoGalleryPreset>();
			component.manager = this;
			component.photoTitle = title;
			component.titleText.text = title;
			component.descriptionText.text = description;
			component.photoImage.sprite = photo;
			if (component.photoImage.sprite.texture.height > component.photoImage.sprite.texture.width)
			{
				component.aspectRatioFitter.aspectRatio = 0.5f;
			}
			else
			{
				component.aspectRatioFitter.aspectRatio = 1.8f;
			}
			obj.GetComponent<ButtonManager>().onClick.AddListener(delegate
			{
				OpenPhoto(photo, title, description);
			});
		}

		public void CheckForButtonStates()
		{
			if (nextButton == null || previousButton == null)
			{
				return;
			}
			if (bypassArrowKeys)
			{
				nextButton.gameObject.SetActive(value: false);
				previousButton.gameObject.SetActive(value: false);
				return;
			}
			if (!bypassArrowKeys)
			{
				nextButton.gameObject.SetActive(value: false);
				previousButton.gameObject.SetActive(value: false);
			}
			if (photoItems.Count == 1)
			{
				nextButton.gameObject.SetActive(value: false);
				previousButton.gameObject.SetActive(value: false);
				return;
			}
			if (currentPreset.photoIndex == 0)
			{
				previousButton.gameObject.SetActive(value: false);
			}
			else
			{
				previousButton.gameObject.SetActive(value: true);
			}
			if (currentPreset.photoIndex == photoItems.Count - 1)
			{
				nextButton.gameObject.SetActive(value: false);
			}
			else
			{
				nextButton.gameObject.SetActive(value: true);
			}
		}

		private void NextAction()
		{
			pictureLibraryParent.GetChild(currentPreset.photoIndex + 1).GetComponent<ButtonManager>().onClick.Invoke();
		}

		private void PrevAction()
		{
			pictureLibraryParent.GetChild(currentPreset.photoIndex - 1).GetComponent<ButtonManager>().onClick.Invoke();
		}
	}
}

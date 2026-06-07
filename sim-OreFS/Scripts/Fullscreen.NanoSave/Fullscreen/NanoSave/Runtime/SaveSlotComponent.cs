using System.Collections;
using System.IO;
using System.Linq;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Common.UnityUI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Fullscreen.NanoSave.Runtime
{
	[AddComponentMenu("Fullscreen/Save Slot Component")]
	public class SaveSlotComponent : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private TextReference saveSlotTitle;

		[SerializeField]
		private TextReference saveSlotLocation;

		[SerializeField]
		private TextReference saveSlotProgression;

		[SerializeField]
		private TextReference saveSlotTotalPlaytime;

		[SerializeField]
		private TextReference characterLevel;

		[SerializeField]
		private TextReference saveSlotTime;

		[SerializeField]
		private TextReference saveSlotVersion;

		[SerializeField]
		private TextReference saveSlotNumberDisplay;

		[SerializeField]
		private PropertyGetGameObject saveSlotScreenshot;

		[HideInInspector]
		[SerializeField]
		private NanoSave storage;

		[HideInInspector]
		public SaveSlotLoaderUI loaderUI;

		[HideInInspector]
		public string slotNumber;

		private RectTransform rectTransform;

		private ScrollRect scrollRect;

		private RectTransform viewportTransform;

		private bool isScreenshotLoaded;

		private string screenshotPath;

		private Texture2D loadedTexture;

		public void Initialize(SaveSlotLoaderUI loader)
		{
			loaderUI = loader;
			rectTransform = GetComponent<RectTransform>();
			scrollRect = GetComponentInParent<ScrollRect>();
			if (scrollRect != null)
			{
				viewportTransform = scrollRect.viewport;
				scrollRect.onValueChanged.AddListener(OnScrollChanged);
			}
		}

		public void SetSlotNumber(string number)
		{
			slotNumber = number;
			UpdateDisplay();
		}

		public string GetSlotNumber()
		{
			return slotNumber;
		}

		private void UpdateDisplay()
		{
			if (storage != null && saveSlotTitle != null && saveSlotLocation != null && saveSlotProgression != null && saveSlotTotalPlaytime != null && characterLevel != null && saveSlotTime != null && saveSlotScreenshot != null && saveSlotNumberDisplay != null)
			{
				var (text, text2, text3, text4, text5, text6, _) = storage.GetMetaDataForSlot(slotNumber);
				saveSlotTitle.Text = (string.IsNullOrEmpty(text) ? "Empty Slot" : text);
				saveSlotLocation.Text = (string.IsNullOrEmpty(text3) ? "Unknown Location" : text3);
				saveSlotProgression.Text = (string.IsNullOrEmpty(text4) ? "0%" : text4);
				saveSlotTotalPlaytime.Text = (string.IsNullOrEmpty(text5) ? "0h 0m" : text5);
				characterLevel.Text = (string.IsNullOrEmpty(text6) ? "Level 1" : text6);
				saveSlotTime.Text = (string.IsNullOrEmpty(text2) ? "No Save Data" : text2);
				saveSlotNumberDisplay.Text = $"Save {int.Parse(slotNumber)}";
				string text7 = Directory.GetDirectories(Path.Combine(Application.persistentDataPath, "Saves")).FirstOrDefault((string path) => Path.GetFileName(path).EndsWith(slotNumber));
				if (!string.IsNullOrEmpty(text7))
				{
					screenshotPath = Path.Combine(text7, "Screenshot.png");
				}
				else
				{
					screenshotPath = null;
				}
				isScreenshotLoaded = false;
				StartCoroutine(CheckVisibilityNextFrame());
			}
		}

		private IEnumerator CheckVisibilityNextFrame()
		{
			yield return null;
			TryLoadScreenshotIfVisible();
		}

		private void TryLoadScreenshotIfVisible()
		{
			if (!isScreenshotLoaded && !string.IsNullOrEmpty(screenshotPath) && !(scrollRect == null) && !(viewportTransform == null) && IsFullyVisibleInScrollView())
			{
				StartCoroutine(LoadScreenshot(screenshotPath));
				isScreenshotLoaded = true;
			}
		}

		private bool IsFullyVisibleInScrollView()
		{
			if (rectTransform == null || viewportTransform == null)
			{
				return false;
			}
			Vector3[] array = new Vector3[4];
			Vector3[] array2 = new Vector3[4];
			rectTransform.GetWorldCorners(array);
			viewportTransform.GetWorldCorners(array2);
			float y = array[1].y;
			float y2 = array[3].y;
			float y3 = array2[1].y;
			float y4 = array2[3].y;
			if (y > y4)
			{
				return y2 < y3;
			}
			return false;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (loaderUI != null)
			{
				loaderUI.CurrentHoverSaveSlot = this;
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (loaderUI != null && loaderUI.CurrentHoverSaveSlot == this)
			{
				loaderUI.CurrentHoverSaveSlot = null;
			}
		}

		private IEnumerator LoadScreenshot(string path)
		{
			if (!File.Exists(path))
			{
				yield return null;
				if (!File.Exists(path))
				{
					Debug.LogWarning("Screenshot file not found at: " + path);
					yield break;
				}
			}
			byte[] data;
			using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				using BinaryReader binaryReader = new BinaryReader(fileStream);
				data = binaryReader.ReadBytes((int)fileStream.Length);
			}
			if (loadedTexture == null)
			{
				loadedTexture = new Texture2D(2, 2, TextureFormat.RGBA32, mipChain: false);
			}
			if (loadedTexture.LoadImage(data))
			{
				loadedTexture.Apply();
				GameObject gameObject = saveSlotScreenshot.Get(base.gameObject);
				if (gameObject != null)
				{
					Image component = gameObject.GetComponent<Image>();
					if (component != null)
					{
						if (component.sprite != null)
						{
							Object.Destroy(component.sprite.texture);
						}
						component.sprite = Sprite.Create(loadedTexture, new Rect(0f, 0f, loadedTexture.width, loadedTexture.height), new Vector2(0.5f, 0.5f));
						component.color = Color.white;
					}
				}
			}
			yield return null;
		}

		private void OnScrollChanged(Vector2 value)
		{
			TryLoadScreenshotIfVisible();
		}

		private void OnDestroy()
		{
			if (scrollRect != null)
			{
				scrollRect.onValueChanged.RemoveListener(OnScrollChanged);
			}
			if (loadedTexture != null)
			{
				Object.Destroy(loadedTexture);
			}
		}
	}
}

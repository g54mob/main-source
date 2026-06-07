using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DV.UIFramework
{
	public class PopupManager : NullCheckingMonoBehaviour
	{
		public Func<Popup, bool> TryOpenPopupCallback = (Popup _) => true;

		public Canvas popupTargetCanvas;

		public Color blockerColor = Color.clear;

		private Popup activePopup;

		private GameObject clickBlocker;

		public Popup ActivePopup => activePopup;

		public Popup NextPopup { get; private set; }

		public event Action<Popup> PopupChanged;

		public bool CanShowPopup()
		{
			return activePopup == null;
		}

		public void CloseActivePopup()
		{
			if (!(activePopup == null))
			{
				activePopup.RequestClose(PopupClosedByAction.Abortion, "");
			}
		}

		public Popup ShowPopup(Popup popupPrefab, PopupLocalizationKeys locKeys = default(PopupLocalizationKeys), Dictionary<string, string> locParams = null, bool keepLiteralData = false)
		{
			if (popupPrefab == null)
			{
				Debug.LogError("Given popup is null");
				return null;
			}
			if (!CanShowPopup())
			{
				Debug.LogError("Popup cannot be shown at this time (use `CanShowPopup` before calling this method)");
				return null;
			}
			if (popupTargetCanvas == null)
			{
				Debug.LogError("popupTargetCanvas is not assigned");
				return null;
			}
			NextPopup = popupPrefab;
			if (!TryOpenPopupCallback(popupPrefab))
			{
				Debug.LogWarning("Can't open popup!");
				NextPopup = null;
				return null;
			}
			NextPopup = null;
			if (EventSystem.current != null && !EventSystem.current.alreadySelecting)
			{
				EventSystem.current.SetSelectedGameObject(null);
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(popupPrefab.gameObject, popupTargetCanvas.transform);
			activePopup = gameObject.GetComponent<Popup>();
			activePopup.Closed += OnPopupClosed;
			activePopup.SetLocalizationData(locKeys, locParams, keepLiteralData);
			UnityEngine.Object.Destroy(null);
			if ((bool)clickBlocker)
			{
				UnityEngine.Object.Destroy(clickBlocker);
			}
			clickBlocker = CreateClickBlocker(gameObject, blockerColor);
			this.PopupChanged?.Invoke(activePopup);
			return activePopup;
		}

		public UniTask<PopupResult> ShowPopupAsync(Popup popupPrefab, out Popup createdPopupInstance, PopupLocalizationKeys locKeys = default(PopupLocalizationKeys), Dictionary<string, string> locParams = null)
		{
			createdPopupInstance = ShowPopup(popupPrefab, locKeys, locParams);
			UniTaskCompletionSource<PopupResult> utcs = new UniTaskCompletionSource<PopupResult>();
			createdPopupInstance.Closed += delegate(PopupResult result)
			{
				Debug.Log($"Popup '{result.popup.name}' closed by {result.closedBy}, data: {result.data}");
				if (result.closedBy == PopupClosedByAction.Abortion)
				{
					utcs.TrySetCanceled();
				}
				else
				{
					utcs.TrySetResult(result);
				}
			};
			return utcs.Task;
		}

		private void OnPopupClosed(PopupResult result)
		{
			activePopup.Closed -= OnPopupClosed;
			UnityEngine.Object.Destroy(activePopup.gameObject);
			activePopup = null;
			UnityEngine.Object.Destroy(clickBlocker);
			clickBlocker = null;
			this.PopupChanged?.Invoke(null);
		}

		private void OnDisable()
		{
			CloseActivePopup();
		}

		protected static GameObject CreateClickBlocker(GameObject popupInstance, Color blockerColor)
		{
			GameObject gameObject = GetNewBlocker();
			RectTransform mainRT = gameObject.transform as RectTransform;
			mainRT.anchorMin = Vector3.zero;
			mainRT.anchorMax = Vector3.one;
			mainRT.sizeDelta = Vector2.zero;
			mainRT.offsetMin = new Vector2(-2000f, -2000f);
			mainRT.offsetMax = new Vector2(2000f, 2000f);
			AddChildBlocker(new Vector2(0f, 0f), new Vector2(0f, 1f), 2000f, new Vector2(4000f, 0f), Quaternion.Euler(0f, 90f, 0f));
			AddChildBlocker(new Vector2(1f, 0f), new Vector2(1f, 1f), 2000f, new Vector2(4000f, 0f), Quaternion.Euler(0f, 90f, 0f));
			AddChildBlocker(new Vector2(0f, 0f), new Vector2(1f, 0f), 2000f, new Vector2(0f, 4000f), Quaternion.Euler(90f, 0f, 0f));
			AddChildBlocker(new Vector2(0f, 1f), new Vector2(1f, 1f), 2000f, new Vector2(0f, 4000f), Quaternion.Euler(90f, 0f, 0f));
			AddChildBlocker(new Vector2(0f, 0f), new Vector2(1f, 1f), 4000f, new Vector2(0f, 0f), Quaternion.Euler(0f, 0f, 0f));
			return gameObject;
			void AddChildBlocker(Vector2 anchorMin, Vector2 anchorMax, float offset, Vector2 sizeDelta, Quaternion localRotation)
			{
				GameObject obj = GetNewBlocker();
				obj.transform.SetParent(mainRT);
				RectTransform obj2 = obj.transform as RectTransform;
				obj2.anchorMin = anchorMin;
				obj2.anchorMax = anchorMax;
				obj2.sizeDelta = sizeDelta;
				obj2.anchoredPosition3D = Vector3.back * offset;
				obj2.localRotation = localRotation;
			}
			GameObject GetNewBlocker()
			{
				GameObject obj = new GameObject("[Popup click blocker]");
				RectTransform rectTransform = obj.AddComponent<RectTransform>();
				rectTransform.SetParent(popupInstance.transform.parent, worldPositionStays: false);
				rectTransform.SetSiblingIndex(popupInstance.transform.GetSiblingIndex());
				Image image = obj.AddComponent<Image>();
				image.color = blockerColor;
				image.maskable = false;
				image.raycastTarget = true;
				obj.GetComponent<CanvasRenderer>().cullTransparentMesh = true;
				return obj;
			}
		}
	}
}

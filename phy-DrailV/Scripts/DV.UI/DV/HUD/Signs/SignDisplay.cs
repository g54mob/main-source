using System.Collections.Generic;
using DV.Common;
using DV.UI;
using DV.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace DV.HUD.Signs
{
	public class SignDisplay : MonoBehaviour
	{
		public RectTransform contentRoot;

		private RectTransform rect;

		private Canvas canvas;

		private CanvasScaler scaler;

		private Dictionary<GameObject, Queue<GameObject>> prefabPoolDictionary = new Dictionary<GameObject, Queue<GameObject>>();

		private Dictionary<GameObject, GameObject> objectToPoolKeyDictionary = new Dictionary<GameObject, GameObject>();

		private void Awake()
		{
			canvas = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.mainCanvas;
			scaler = canvas.GetComponent<CanvasScaler>();
			rect = GetComponent<RectTransform>();
			if (!contentRoot)
			{
				Debug.LogError("contentRoot is not assigned!");
				contentRoot = rect;
			}
			base.gameObject.SetActive(value: false);
			contentRoot.gameObject.SetActive(value: false);
		}

		private void LateUpdate()
		{
			rect.anchoredPosition = Input.mousePosition / canvas.transform.localScale.y;
			rect.anchoredPosition -= new Vector2(((canvas.transform as RectTransform).sizeDelta.x - scaler.referenceResolution.x) * 0.5f, 0f);
		}

		private void ReturnToQueue(GameObject instance)
		{
			if (objectToPoolKeyDictionary.TryGetValue(instance, out var value))
			{
				objectToPoolKeyDictionary.Remove(instance);
				if (prefabPoolDictionary.TryGetValue(value, out var value2))
				{
					instance.SetActive(value: false);
					instance.transform.SetParent(base.transform, worldPositionStays: false);
					value2.Enqueue(instance);
				}
				else
				{
					Debug.LogError("Tried to return object to pool but its pool has been deleted. Destroying...");
					Object.Destroy(instance);
				}
			}
			else
			{
				Debug.LogError("Tried to return object to pool but don't know where it belongs. Destroying...");
				Object.Destroy(instance);
			}
		}

		private GameObject GetPrefabInstance(GameObject prefab)
		{
			if (!prefabPoolDictionary.TryGetValue(prefab, out var value))
			{
				value = new Queue<GameObject>();
				prefabPoolDictionary.Add(prefab, value);
			}
			if (value.Count == 0)
			{
				GameObject gameObject = Object.Instantiate(prefab);
				gameObject.SetActive(value: false);
				value.Enqueue(gameObject);
			}
			GameObject gameObject2 = value.Dequeue();
			gameObject2.SetActive(value: true);
			objectToPoolKeyDictionary[gameObject2] = prefab;
			return gameObject2;
		}

		public void UpdateSigns(List<SignDisplayInstance> signs)
		{
			for (int num = contentRoot.childCount - 1; num >= 0; num--)
			{
				ReturnToQueue(contentRoot.GetChild(num).gameObject);
			}
			if (signs != null)
			{
				foreach (SignDisplayInstance sign in signs)
				{
					GameObject prefabInstance = GetPrefabInstance(sign.prefab);
					prefabInstance.transform.SetParent(contentRoot, worldPositionStays: false);
					ASignDisplayElement component = prefabInstance.GetComponent<ASignDisplayElement>();
					if (!string.IsNullOrEmpty(sign.text))
					{
						component.SetText(sign.text);
					}
				}
			}
			base.gameObject.SetActive(signs != null);
			contentRoot.gameObject.SetActive(signs != null);
		}
	}
}

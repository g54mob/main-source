using Assets.Scripts.Flight.UI;
using CurvedUI;
using Jundroo.Common.Events;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.GuiNew
{
	public class XrUiScript : MonoBehaviour
	{
		[SerializeField]
		private GameObject _messagePrefab;

		[SerializeField]
		private TextMeshProUGUI _timeText;

		public void SetTimeText(string s)
		{
			if (!_timeText.gameObject.activeInHierarchy)
			{
				_timeText.transform.parent.gameObject.SetActive(value: true);
			}
			_timeText.text = s;
		}

		public IFadingMessage ShowMessage(MessageManager.Message message)
		{
			GameObject obj = Object.Instantiate(_messagePrefab);
			obj.SetActive(value: true);
			obj.transform.SetParent(_messagePrefab.transform.parent, worldPositionStays: false);
			obj.transform.localPosition = _messagePrefab.transform.localPosition;
			obj.transform.localScale = Vector3.one;
			obj.transform.localRotation = Quaternion.identity;
			FadingMessageScriptXr component = obj.GetComponent<FadingMessageScriptXr>();
			component.ShowMessage(message);
			return component;
		}

		protected virtual void Awake()
		{
			UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate(int? x)
			{
				if (x == 0)
				{
					CurvedUIRaycaster componentInChildren = GetComponentInChildren<CurvedUIRaycaster>();
					if (componentInChildren != null)
					{
						componentInChildren.enabled = false;
						componentInChildren.enabled = true;
					}
				}
			}, 5);
			CurvedUIInputModule.Instance.RaycastLayerMask = 1 << base.gameObject.layer;
			_messagePrefab.SetActive(value: false);
		}
	}
}

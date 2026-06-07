using System;
using Assets.Nimbatus.Scripts.Controls.Keybinds;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Dragging;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.Cursor
{
	public class NimbatusCursor : MonoBehaviour
	{
		private static NimbatusCursor _instance;

		private GameObject _item;

		private Vector3 _offset;

		private bool _offsetSet;

		private Transform _transform;

		public Camera UiCamera;

		public Texture2D NormalCursor;

		public Texture2D ConnectCursor;

		public Texture2D ReplaceCursor;

		private Texture2D _currentCursor;

		public static void ShowConnectCursor()
		{
			UnityEngine.Cursor.SetCursor(_instance.ConnectCursor, new Vector2(16f, 16f), CursorMode.Auto);
			_instance._currentCursor = _instance.ConnectCursor;
		}

		public static void ShowNormalCursor()
		{
			UnityEngine.Cursor.SetCursor(_instance.NormalCursor, new Vector2(3f, 6f), CursorMode.Auto);
			_instance._currentCursor = _instance.NormalCursor;
		}

		public static void ShowReplaceCursor()
		{
			UnityEngine.Cursor.SetCursor(_instance.ReplaceCursor, new Vector2(16f, 16f), CursorMode.Auto);
			_instance._currentCursor = _instance.ReplaceCursor;
		}

		public void Awake()
		{
			_instance = this;
			ShowNormalCursor();
		}

		public void OnDestroy()
		{
			_instance = null;
		}

		public void Start()
		{
			_transform = base.transform;
			if (UiCamera == null)
			{
				UiCamera = NGUITools.FindCameraForLayer(base.gameObject.layer);
			}
		}

		public void Update()
		{
			if (_item != null)
			{
				Vector3 mousePosition = Input.mousePosition;
				Vector3 vector;
				if (UiCamera != null)
				{
					mousePosition.x = Mathf.Clamp01(mousePosition.x / (float)Screen.width);
					mousePosition.y = Mathf.Clamp01(mousePosition.y / (float)Screen.height);
					vector = UiCamera.ViewportToWorldPoint(mousePosition);
				}
				else
				{
					mousePosition.x -= (float)Screen.width * 0.5f;
					mousePosition.y -= (float)Screen.height * 0.5f;
					vector = mousePosition;
				}
				if (!_offsetSet)
				{
					DronePart component = _item.GetComponent<DronePart>();
					if (component != null)
					{
						if (!component.IgnoreOffset)
						{
							_offset = _item.transform.position - vector;
							_offset.z = 0f;
						}
						component.IgnoreOffset = false;
					}
					_offsetSet = true;
				}
				vector += _offset;
				if (RuntimeGlobals.RunningMode == ERunningMode.DroneCustomization)
				{
					double num = Math.Round(vector.x, MidpointRounding.AwayFromZero);
					double num2 = Math.Round(vector.y, MidpointRounding.AwayFromZero);
					vector.x = (float)num;
					vector.y = (float)num2;
				}
				_transform.position = new Vector3(vector.x, vector.y, -200f);
				_item.transform.position = _transform.position;
			}
			if (DragAndDropHelper.DraggedItem == null && _currentCursor != NormalCursor)
			{
				ShowNormalCursor();
			}
			if (RuntimeGlobals.RunningMode == ERunningMode.DroneCustomization && (_currentCursor == ConnectCursor || _currentCursor == ReplaceCursor))
			{
				if (BaseSingleton<KeybindManager>.Instance.GetKey(EKeybinding.ReplaceDronePart))
				{
					ShowReplaceCursor();
				}
				else
				{
					ShowConnectCursor();
				}
			}
		}

		public static void Clear()
		{
			Set(null);
		}

		public static void Set(GameObject item)
		{
			if (_instance != null)
			{
				_instance._item = item;
				_instance._offset = Vector3.zero;
				_instance._offsetSet = false;
				_instance.Update();
			}
		}
	}
}

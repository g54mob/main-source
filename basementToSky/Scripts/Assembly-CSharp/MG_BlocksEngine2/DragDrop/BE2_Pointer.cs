using MG_BlocksEngine2.Core;
using UnityEngine;

namespace MG_BlocksEngine2.DragDrop
{
	public class BE2_Pointer : MonoBehaviour
	{
		private Transform _transform;

		private Vector3 _mousePos;

		private static BE2_Pointer _instance;

		public static BE2_Pointer Instance
		{
			get
			{
				if (!_instance)
				{
					_instance = Object.FindObjectOfType<BE2_Pointer>();
				}
				return _instance;
			}
			set
			{
				_instance = value;
			}
		}

		private void Awake()
		{
			_transform = base.transform;
		}

		public void OnUpdate()
		{
			UpdatePointerPosition();
		}

		public void UpdatePointerPosition()
		{
			_mousePos = BE2_InputManager.Instance.CanvasPointerPosition;
			_transform.position = new Vector3(_mousePos.x, _mousePos.y, _transform.position.z);
			_transform.localPosition = new Vector3(_transform.localPosition.x, _transform.localPosition.y, 0f);
			_transform.localEulerAngles = Vector3.zero;
		}
	}
}

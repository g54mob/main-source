using MG_BlocksEngine2.Block;
using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.Environment;
using MG_BlocksEngine2.UI;
using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.DragDrop
{
	public class BE2_DragSelectionBlock : MonoBehaviour, I_BE2_Drag
	{
		private RectTransform _rectTransform;

		private BE2_UI_SelectionBlock _uiSelectionBlock;

		private ScrollRect _scrollRect;

		private Transform _transform;

		private Vector3 _envScale = Vector3.one;

		private BE2_DragDropManager _dragDropManager => BE2_DragDropManager.Instance;

		public Transform Transform
		{
			get
			{
				if (!_transform)
				{
					return base.transform;
				}
				return _transform;
			}
		}

		public Vector2 RayPoint => _rectTransform.position;

		public I_BE2_Block Block => null;

		private void Awake()
		{
			_transform = base.transform;
			_rectTransform = GetComponent<RectTransform>();
			_uiSelectionBlock = GetComponent<BE2_UI_SelectionBlock>();
			_scrollRect = GetComponentInParent<ScrollRect>();
		}

		public void OnPointerDown()
		{
			_envScale = BE2_ExecutionManager.Instance.ProgrammingEnvsList.Find((I_BE2_ProgrammingEnv x) => x.Visible).Transform.localScale;
		}

		public void OnRightPointerDownOrHold()
		{
		}

		public void OnDragStart()
		{
		}

		public void OnDrag()
		{
			_scrollRect.StopMovement();
			_scrollRect.enabled = false;
			GameObject obj = Object.Instantiate(_uiSelectionBlock.prefabBlock);
			obj.name = _uiSelectionBlock.prefabBlock.name;
			I_BE2_Block component = obj.GetComponent<I_BE2_Block>();
			component.Drag.Transform.SetParent(_dragDropManager.DraggedObjectsTransform, worldPositionStays: true);
			obj.GetComponent<I_BE2_BlocksStack>();
			obj.transform.localScale = _envScale;
			obj.transform.position = base.transform.position;
			_dragDropManager.CurrentDrag = component.Drag;
			component.Drag.OnPointerDown();
			component.Drag.OnDrag();
			component.Transform.localEulerAngles = Vector3.zero;
		}

		public void OnPointerUp()
		{
		}
	}
}

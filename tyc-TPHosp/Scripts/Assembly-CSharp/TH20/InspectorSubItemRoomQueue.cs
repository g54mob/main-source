using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class InspectorSubItemRoomQueue : InspectorSubItem
	{
		[SerializeField]
		private ScrollRect _scroller;

		[SerializeField]
		private GameObject _rowPrefab;

		[SerializeField]
		private Sprite _backing1;

		[SerializeField]
		private Sprite _backing2;

		[SerializeField]
		private float _spacing = 4f;

		[SerializeField]
		private float _edgeScrollSpeedMin;

		[SerializeField]
		private float _edgeScrollSpeedMax = 10f;

		[SerializeField]
		private float _edgeScrollDistance = 160f;

		private Level _level;

		private Room _room;

		private InspectorMenu _inspectorMenu;

		private InspectorRoomQueueRow _rowBeingDragged;

		private Vector2 _dragOffset;

		private int _dragNewIndex = -1;

		private readonly List<InspectorRoomQueueRow> _rows = new List<InspectorRoomQueueRow>();

		public void Setup(Level level, Room room, InspectorMenu inspectorMenu)
		{
			_level = level;
			_room = room;
			_inspectorMenu = inspectorMenu;
			_scroller.normalizedPosition = new Vector2(0f, 1f);
		}

		protected void OnDestroy()
		{
			foreach (InspectorRoomQueueRow row in _rows)
			{
				Object.Destroy(row);
			}
			_rowBeingDragged = null;
			_rows.Clear();
		}

		private void Update()
		{
			if (_room == null || _level.CursorManager.IsModeActive<CursorMovePatientToQueue>())
			{
				return;
			}
			int count = _room.Queue.Count;
			while (count > _rows.Count)
			{
				InspectorRoomQueueRow component = Object.Instantiate(_rowPrefab, _scroller.content, worldPositionStays: false).GetComponent<InspectorRoomQueueRow>();
				_rows.Add(component);
			}
			if (_rowBeingDragged != null)
			{
				if (!_room.Queue.Contains(_rowBeingDragged.Character))
				{
					_dragNewIndex = -1;
					_rowBeingDragged = null;
				}
				else
				{
					Vector3 vector = _scroller.viewport.InverseTransformPoint(_level.InputManager.GetMousePos());
					bool flag = vector.y > _scroller.viewport.rect.height * 0.5f;
					bool flag2 = vector.y < (0f - _scroller.viewport.rect.height) * 0.5f + 35f;
					if (vector.x < (0f - _scroller.viewport.rect.width) * 0.5f - 150f && _rowBeingDragged.Character is Patient)
					{
						CursorMovePatientToQueue newMode = new CursorMovePatientToQueue(_level, _rowBeingDragged.Character as Patient);
						_level.CursorManager.PushMode(newMode);
						_rowBeingDragged = null;
						_inspectorMenu.CloseAndRestoreGeneralNotifications();
					}
					if (flag)
					{
						float t = Mathf.Max(vector.y - _scroller.viewport.rect.height * 0.5f, 0f) / _edgeScrollDistance;
						float b = _scroller.content.anchoredPosition.y - Mathf.Lerp(_edgeScrollSpeedMin, _edgeScrollSpeedMax, t);
						b = Mathf.Max(0f, b);
						_scroller.content.anchoredPosition = new Vector2(0f, b);
					}
					if (flag2)
					{
						float t2 = Mathf.Abs(Mathf.Min(vector.y + _scroller.viewport.rect.height * 0.5f, 0f) / _edgeScrollDistance);
						float b2 = _scroller.content.anchoredPosition.y + Mathf.Lerp(_edgeScrollSpeedMin, _edgeScrollSpeedMax, t2);
						b2 = Mathf.Min(_scroller.content.rect.height - _scroller.viewport.rect.height, b2);
						_scroller.content.anchoredPosition = new Vector2(0f, b2);
					}
					OnQueueItemDrag(_level.InputManager.GetMousePos());
				}
			}
			int num = 0;
			for (int i = 0; i < _rows.Count; i++)
			{
				InspectorRoomQueueRow inspectorRoomQueueRow = _rows[i];
				if (i >= count)
				{
					GameObjectUtils.SetActive(inspectorRoomQueueRow.gameObject, isActive: false);
					continue;
				}
				GameObjectUtils.SetActive(inspectorRoomQueueRow.gameObject, isActive: true);
				if (inspectorRoomQueueRow != _rowBeingDragged)
				{
					inspectorRoomQueueRow.Setup(this, _room.Queue[i], (_rowBeingDragged != null) ? _backing1 : ((i % 2 == 0) ? _backing1 : _backing2));
					inspectorRoomQueueRow.transform.localPosition = new Vector2(0f, GetRowYPositionInScroller(num));
					num++;
				}
				else
				{
					inspectorRoomQueueRow.Setup(this, _room.Queue[i], _backing2);
				}
			}
			float y = Mathf.Abs(GetRowYPositionInScroller(num));
			_scroller.content.sizeDelta = new Vector2(_scroller.content.sizeDelta.x, y);
		}

		public void OnQueueItemDragBegin(InspectorRoomQueueRow draggable, Vector2 offset)
		{
			if (_room.QueueLength > 0)
			{
				_rowBeingDragged = draggable;
				_dragOffset = offset;
				_dragNewIndex = draggable.Character.GetQueuePosition();
			}
		}

		public void OnQueueItemDrag(Vector2 currentDragPosition)
		{
			if (!(_rowBeingDragged == null))
			{
				_rowBeingDragged.transform.SetAsLastSibling();
				Vector3 vector = _scroller.content.InverseTransformPoint(currentDragPosition);
				float b = 0f - _scroller.content.anchoredPosition.y;
				float b2 = 0f - _scroller.content.anchoredPosition.y - _scroller.viewport.rect.height + 70f;
				float a = vector.y - _dragOffset.y;
				a = Mathf.Min(a, b);
				a = Mathf.Max(a, b2);
				float x = Mathf.InverseLerp((0f - _scroller.viewport.rect.width) * 0.5f, (0f - _scroller.viewport.rect.width) * 0.5f - 150f, vector.x) * -15f;
				_rowBeingDragged.transform.localPosition = new Vector3(x, a, 0f);
				_dragNewIndex = GetQueuePositionFromScreenPosition();
			}
		}

		public void OnQueueItemDragEnd()
		{
			if (!(_rowBeingDragged == null))
			{
				if (_rowBeingDragged.Character.GetQueuePosition() != _dragNewIndex)
				{
					_room.AddToQueue(_rowBeingDragged.Character, _dragNewIndex);
				}
				_rowBeingDragged = null;
				_dragNewIndex = -1;
			}
		}

		private int GetQueuePositionFromScreenPosition()
		{
			if (_rows.Count < 1)
			{
				return 0;
			}
			if (_rowBeingDragged == null)
			{
				return 0;
			}
			RectTransform rectTransform = (RectTransform)_rowBeingDragged.transform;
			float num = rectTransform.localPosition.y - rectTransform.sizeDelta.y * 0.5f;
			float y = ((RectTransform)_rows[0].transform).sizeDelta.y;
			for (int i = 0; i < _room.QueueLength && _rows.Count > i; i++)
			{
				if ((0f - y - _spacing) * (float)(i + 1) < num)
				{
					return i;
				}
			}
			return _room.QueueLength - 1;
		}

		private float GetRowYPositionInScroller(int index)
		{
			float num = 0f - _spacing;
			if (_rows.Count < 1)
			{
				return num;
			}
			float y = ((RectTransform)_rows[0].transform).sizeDelta.y;
			num -= (_spacing + y) * (float)index;
			if (_rowBeingDragged != null && index >= _dragNewIndex)
			{
				num -= _spacing + y;
			}
			return num;
		}
	}
}

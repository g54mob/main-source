using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace InputControl
{
	public class CursorUIBase : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		protected GameObject _cursor;

		[SerializeField]
		protected bool _fixScale;

		[SerializeField]
		protected bool _isSelectProcessOnlyGamePad;

		public UnityEvent OnSelect;

		public UnityEvent OnDeselect;

		public UnityEvent OnOnlyPadSelect;

		public UnityEvent OnOnlyPadDeselect;

		[FormerlySerializedAs("isEnable")]
		public bool IsInteractive;

		private bool isSelected;

		private Vector3? _defaultSize;

		public bool IsSelected => false;

		public bool IsEnable => false;

		private void Awake()
		{
		}

		protected void Select(bool isPad = false)
		{
		}

		protected virtual void SelectExtendProcess()
		{
		}

		protected virtual void PadSelectExtendProcess()
		{
		}

		protected virtual void Deselect(bool isPad = false)
		{
		}

		protected virtual void DeselectExtendProcess()
		{
		}

		protected virtual void PadDeselectExtendProcess()
		{
		}

		public void SetSelect(bool value, bool isPad = true)
		{
		}

		public virtual void OnDecide()
		{
		}

		public virtual void OnSwitch()
		{
		}

		public virtual void OnCancel()
		{
		}

		private void ToggleCursor(bool activate)
		{
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public virtual void OnPointerExit(PointerEventData eventData)
		{
		}
	}
}

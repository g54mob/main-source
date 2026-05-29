using System.Collections.Generic;
using UnityEngine;

namespace CTS
{
	public abstract class UIObject : MonoBehaviour
	{
		[SerializeField]
		private List<UIObject> _linkedObjects = new List<UIObject>();

		public bool IsHierarchyActive { get; private set; } = true;

		public bool IsActive { get; private set; }

		protected virtual void Awake()
		{
			IsActive = GetAwakeActive();
		}

		protected virtual void Start()
		{
			HierarchyBroadcast(IsActive);
		}

		protected virtual bool GetAwakeActive()
		{
			return base.enabled;
		}

		public void SetActive(bool p_state)
		{
			if (p_state != IsActive)
			{
				IsActive = p_state;
				if (IsHierarchyActive)
				{
					SendEvents(p_state);
				}
				HierarchyBroadcast(p_state);
			}
		}

		private void SetHierarchyActive(bool p_state)
		{
			if (p_state != IsHierarchyActive)
			{
				IsHierarchyActive = p_state;
				if (IsActive)
				{
					SendEvents(p_state);
				}
				HierarchyBroadcast(p_state);
			}
		}

		private void SendEvents(bool p_state)
		{
			if (p_state)
			{
				OnUIEnabled();
			}
			else
			{
				OnUIDisabled();
			}
		}

		private void HierarchyBroadcast(bool p_state)
		{
			foreach (UIObject linkedObject in _linkedObjects)
			{
				if (linkedObject.IsActive)
				{
					linkedObject.SetHierarchyActive(p_state);
				}
			}
		}

		protected void AddChildUI(UIObject p_uiObject)
		{
			_linkedObjects.Add(p_uiObject);
			p_uiObject.SetHierarchyActive(IsActive);
		}

		protected void RemoveLink(UIObject p_uiObject)
		{
			_linkedObjects.Remove(p_uiObject);
		}

		public void ToggleState()
		{
			SetActive(!IsActive);
		}

		private void OnEnable()
		{
			if (IsActive && IsHierarchyActive)
			{
				OnUIEnabled();
			}
		}

		private void OnDisable()
		{
			if (IsActive && IsHierarchyActive)
			{
				OnUIDisabled();
			}
		}

		protected abstract void OnUIEnabled();

		protected abstract void OnUIDisabled();
	}
}

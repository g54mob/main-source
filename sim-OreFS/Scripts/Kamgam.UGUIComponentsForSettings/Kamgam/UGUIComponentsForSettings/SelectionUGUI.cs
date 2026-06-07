using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Kamgam.UGUIComponentsForSettings
{
	public class SelectionUGUI : MonoBehaviour
	{
		[FormerlySerializedAs("SelectionEventListneners")]
		public SelectionEventListener[] SelectionEventListeners;

		[Tooltip("Will be active while it is selected.")]
		public GameObject Selected;

		[Tooltip("Enable if you do not want the selected highlight to show up if coming from the mouse.")]
		public bool IgnoreSelectionsFromMouse = true;

		protected float m_lastMouseUseTime;

		public void Start()
		{
			ConnectToListeners();
			if (Selected != null && FindFirstActiveListener() != null)
			{
				Selected.SetActive(FindFirstActiveListener().IsSelected);
			}
		}

		protected SelectionEventListener FindFirstActiveListener()
		{
			SelectionEventListener[] selectionEventListeners = SelectionEventListeners;
			foreach (SelectionEventListener selectionEventListener in selectionEventListeners)
			{
				if (selectionEventListener != null && selectionEventListener.enabled && selectionEventListener.gameObject.activeInHierarchy)
				{
					return selectionEventListener;
				}
			}
			return null;
		}

		public void ConnectToListeners()
		{
			SelectionEventListener[] selectionEventListeners = SelectionEventListeners;
			foreach (SelectionEventListener selectionEventListener in selectionEventListeners)
			{
				if (!(selectionEventListener == null))
				{
					selectionEventListener.OnSelectionChanged = (SelectionEventListener.OnSelectionChangedDelegate)Delegate.Combine(selectionEventListener.OnSelectionChanged, new SelectionEventListener.OnSelectionChangedDelegate(onSelectionChanged));
				}
			}
		}

		public void DisconnectFromListeners()
		{
			SelectionEventListener[] selectionEventListeners = SelectionEventListeners;
			foreach (SelectionEventListener selectionEventListener in selectionEventListeners)
			{
				if (!(selectionEventListener == null))
				{
					selectionEventListener.OnSelectionChanged = (SelectionEventListener.OnSelectionChangedDelegate)Delegate.Remove(selectionEventListener.OnSelectionChanged, new SelectionEventListener.OnSelectionChangedDelegate(onSelectionChanged));
				}
			}
		}

		protected void onSelectionChanged(bool isSelected)
		{
			updateLastMouseUseTime();
			if (Selected != null && (!isSelected || !mouseUsed(IgnoreSelectionsFromMouse)))
			{
				Selected.SetActive(isSelected);
			}
		}

		protected bool mouseUsed(bool ignore)
		{
			if (!ignore)
			{
				return false;
			}
			return mouseWasRecentlyUsed();
		}

		protected void updateLastMouseUseTime()
		{
			if (InputUtils.LeftMouse())
			{
				m_lastMouseUseTime = Time.realtimeSinceStartup;
			}
		}

		protected bool mouseWasRecentlyUsed(float maxDelay = 0.3f)
		{
			if (InputUtils.LeftMouse())
			{
				return true;
			}
			return Time.realtimeSinceStartup - m_lastMouseUseTime < maxDelay;
		}
	}
}

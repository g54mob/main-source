using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI
{
	public class BasePopup : MonoBehaviour
	{
		protected List<GameObject> _spawned;

		protected string _ID;

		protected GameObject _previouslySelected;

		private bool _refreshLayouts;

		private Action _onClose;

		public virtual void Show()
		{
		}

		public virtual void Hide()
		{
		}

		public void BaseInit(string id)
		{
		}

		public void AddOnCloseCallback(Action cb)
		{
		}

		protected void SetNavigationUp(Selectable origin, Selectable target = null)
		{
		}

		protected void SetNavigationDown(Selectable origin, Selectable target = null)
		{
		}

		protected void SetNavigationLeft(Selectable origin, Selectable target = null)
		{
		}

		protected void SetNavigationRight(Selectable origin, Selectable target = null)
		{
		}

		protected void SetNavigationMode(Selectable origin, Navigation.Mode mode)
		{
		}

		protected void ClearNavigationUp(Selectable origin)
		{
		}

		protected void ClearNavigationDown(Selectable origin)
		{
		}

		protected void ClearNavigationLeft(Selectable origin)
		{
		}

		protected void ClearNavigationRight(Selectable origin)
		{
		}

		private void LateUpdate()
		{
		}

		protected void RefreshFormatting()
		{
		}
	}
}

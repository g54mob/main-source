using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Dorfromantik
{
	[RequireComponent(typeof(EventSystem))]
	public class UiSelectionManager : Singleton<UiSelectionManager>
	{
		private EventSystem eventSystem;

		private Selectable currentSelectable;

		public event Action<Selectable> OnDeselect;

		public event Action<Selectable> OnSelect;

		protected override void Awake()
		{
			base.Awake();
			eventSystem = GetComponent<EventSystem>();
		}

		private void Update()
		{
			if (!eventSystem.currentSelectedGameObject)
			{
				return;
			}
			Selectable component = eventSystem.currentSelectedGameObject.GetComponent<Selectable>();
			if (component != currentSelectable)
			{
				if ((bool)currentSelectable)
				{
					this.OnDeselect?.Invoke(currentSelectable);
				}
				currentSelectable = component;
				if ((bool)currentSelectable)
				{
					this.OnSelect?.Invoke(currentSelectable);
				}
			}
		}
	}
}

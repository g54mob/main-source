using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Kamgam.UGUIComponentsForSettings
{
	[RequireComponent(typeof(Selectable))]
	public class SelectionLingerer : MonoBehaviour
	{
		protected Selectable selectable;

		protected bool _selectableIsInteractable;

		public Selectable Selectable
		{
			get
			{
				if (selectable == null)
				{
					selectable = GetComponent<Selectable>();
				}
				return selectable;
			}
		}

		public void OnEnable()
		{
			if (!(Selectable == null))
			{
				_selectableIsInteractable = Selectable.interactable;
			}
		}

		public void Update()
		{
			if (!(Selectable == null) && _selectableIsInteractable != Selectable.interactable)
			{
				_selectableIsInteractable = Selectable.interactable;
				if (!_selectableIsInteractable && EventSystem.current != null && EventSystem.current.currentSelectedGameObject == null)
				{
					SelectionUtils.SetSelected(Selectable.gameObject);
				}
			}
		}
	}
}

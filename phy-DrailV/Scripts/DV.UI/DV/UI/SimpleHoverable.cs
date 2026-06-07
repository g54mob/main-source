using DV.UIFramework;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DV.UI
{
	public class SimpleHoverable : MonoBehaviour, IHoverable, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[Tooltip("Whether hover effects (e.g. sounds) should be added. This should only be enabled if there isn't another component that already does this (e.g. SliderDV)")]
		[SerializeField]
		private bool addEffects;

		public bool IsInteractable { get; private set; } = true;

		public bool IsHovered { get; protected set; }

		public bool IsMouseOvered { get; protected set; }

		public event HoverChangedDelegate HoverChanged;

		public event HoverChangedDelegate MouseOverChanged;

		public event InteractabilityChangedDelegate InteractabilityChanged;

		public GameObject GetGameObject()
		{
			return base.gameObject;
		}

		private void Awake()
		{
			if (addEffects)
			{
				new HoverableEvents(this, null, null, null);
			}
		}

		public void ToggleInteractable(bool newInteractable)
		{
			IsInteractable = newInteractable;
		}

		public void Hover()
		{
			if (!IsMouseOvered)
			{
				IsMouseOvered = true;
				this.MouseOverChanged?.Invoke(this);
			}
			if (!IsHovered)
			{
				IsHovered = true;
				this.HoverChanged?.Invoke(this);
			}
		}

		public void Unhover()
		{
			if (IsMouseOvered)
			{
				IsMouseOvered = false;
				this.MouseOverChanged?.Invoke(this);
			}
			if (IsHovered)
			{
				IsHovered = false;
				this.HoverChanged?.Invoke(this);
			}
		}

		private void OnDisable()
		{
			Unhover();
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			Hover();
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			Unhover();
		}
	}
}

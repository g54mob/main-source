using System;
using Restory.Data.Outline;
using Restory.Gameplay.Common;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Restory.Gameplay.Equipment
{
	public class ClickableTrigger : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
	{
		[SerializeField]
		private OutlinableAdapter outlinableAdapter;

		[SerializeField]
		private Collider triggerCollider;

		public event Action OnClick;

		public event Action OnPointerEntered;

		public event Action OnPointerExited;

		private void OnDisable()
		{
			outlinableAdapter.IsActive = false;
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			this.OnClick?.Invoke();
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			outlinableAdapter.IsActive = true;
			this.OnPointerEntered?.Invoke();
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			outlinableAdapter.IsActive = false;
			this.OnPointerExited?.Invoke();
		}

		public void Toggle(bool enabled)
		{
			triggerCollider.enabled = enabled;
		}

		public void SetOutlinePreset(OutlineSettingsPreset preset)
		{
			outlinableAdapter.OverridePreset = preset;
		}

		public void ResetOutlinePreset()
		{
			outlinableAdapter.OverridePreset = null;
		}
	}
}

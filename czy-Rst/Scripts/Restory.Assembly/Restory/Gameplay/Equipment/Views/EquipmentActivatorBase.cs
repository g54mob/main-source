using Restory.Gameplay.Tooltips;
using UnityEngine;

namespace Restory.Gameplay.Equipment.Views
{
	public abstract class EquipmentActivatorBase : MonoBehaviour
	{
		[SerializeField]
		private TooltipIndicator tooltipIndicator;

		public bool IsActivated { get; protected set; }

		public virtual void RestoreState(bool isActivated)
		{
			IsActivated = isActivated;
		}

		public virtual void Activate()
		{
			IsActivated = true;
		}

		public virtual void ToggleIndicator(bool isActive)
		{
			tooltipIndicator.gameObject.SetActive(isActive);
		}
	}
}

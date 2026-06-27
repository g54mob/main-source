using Restory.Gameplay.DetectableObjects;
using UnityEngine;

namespace Restory.Gameplay.Equipment
{
	public class BicycleInteractiveStoreItem : MonoBehaviour, IDetectableObject
	{
		[SerializeField]
		private ClickableTrigger clickableTrigger;

		public bool CanBeDetected
		{
			set
			{
				clickableTrigger.enabled = value;
			}
		}

		public ClickableTrigger Trigger => clickableTrigger;
	}
}

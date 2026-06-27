using Restory.Gameplay.DetectableObjects;
using Restory.Gameplay.Equipment.PersonalComputers;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment
{
	public class PcKeyboardInteractiveWorkplaceItem : MonoBehaviour, IDetectableObject
	{
		[SerializeField]
		private ClickableTrigger clickableTrigger;

		private PcInteractiveWorkplaceItem pcInteractiveWorkplaceItem;

		public bool CanBeDetected
		{
			set
			{
				clickableTrigger.enabled = value;
			}
		}

		public ClickableTrigger Trigger => clickableTrigger;

		[Inject]
		private void Construct(PcInteractiveWorkplaceItem pcInteractiveWorkplaceItem)
		{
			this.pcInteractiveWorkplaceItem = pcInteractiveWorkplaceItem;
		}

		private void OnEnable()
		{
			clickableTrigger.OnClick += ResolveTriggerClick;
		}

		private void OnDisable()
		{
			clickableTrigger.OnClick -= ResolveTriggerClick;
		}

		private void ResolveTriggerClick()
		{
			if (!(pcInteractiveWorkplaceItem != null))
			{
				return;
			}
			if (pcInteractiveWorkplaceItem.IsInternetOn)
			{
				if (!pcInteractiveWorkplaceItem.IsOn)
				{
					pcInteractiveWorkplaceItem.IsOn = true;
				}
				pcInteractiveWorkplaceItem.TryOpenWindowsXP();
			}
			else
			{
				pcInteractiveWorkplaceItem.IsOn = !pcInteractiveWorkplaceItem.IsOn;
			}
		}
	}
}

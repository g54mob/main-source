using Restory.Gameplay.Effects;
using UnityEngine;

namespace Restory.Gameplay.Equipment.Views
{
	public class NotebookActivator : EquipmentActivatorBase
	{
		[SerializeField]
		private NotepadInteractiveWorkplaceItem notepadInteractiveWorkplaceItem;

		[SerializeField]
		private ClickableTrigger clickTrigger;

		[SerializeField]
		private GameObject notebookModel;

		[SerializeField]
		private BounceEffect bounceEffect;

		public override void RestoreState(bool isActivated)
		{
			ToggleNotebookObjects(isActivated);
		}

		public override void Activate()
		{
			ToggleNotebookObjects(isActivated: true);
			bounceEffect.PlayBounce();
		}

		private void ToggleNotebookObjects(bool isActivated)
		{
			base.IsActivated = isActivated;
			notepadInteractiveWorkplaceItem.IsActive = isActivated;
			clickTrigger.gameObject.SetActive(isActivated);
			notebookModel.gameObject.SetActive(isActivated);
		}
	}
}

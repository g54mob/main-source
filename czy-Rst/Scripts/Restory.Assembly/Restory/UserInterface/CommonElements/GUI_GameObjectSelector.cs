using Restory.EventSystems;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface.CommonElements
{
	public class GUI_GameObjectSelector : MonoBehaviour
	{
		[SerializeField]
		private GameObject target;

		[SerializeField]
		protected bool selectOnEnable = true;

		private ActiveSelectionService activeSelectionService;

		[Inject]
		private void Construct(ActiveSelectionService activeSelectionService)
		{
			this.activeSelectionService = activeSelectionService;
			if (base.isActiveAndEnabled)
			{
				Select();
			}
		}

		protected virtual void OnEnable()
		{
			if (selectOnEnable)
			{
				Select();
			}
		}

		public virtual void Select()
		{
			if (activeSelectionService != null)
			{
				activeSelectionService.Select(target);
			}
		}
	}
}

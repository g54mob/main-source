using UnityEngine;

namespace Restory.Gameplay.Workplace
{
	public class WorkplaceRugSwitcher : MonoBehaviour
	{
		[SerializeField]
		private GameObject mainModel;

		[SerializeField]
		private GameObject competitionModel;

		private void Awake()
		{
			SwitchRug(shouldUseMainRug: true);
		}

		public void SwitchRug(bool shouldUseMainRug)
		{
			if (shouldUseMainRug)
			{
				mainModel.SetActive(value: true);
				competitionModel.SetActive(value: false);
			}
			else
			{
				mainModel.SetActive(value: false);
				competitionModel.SetActive(value: true);
			}
		}
	}
}

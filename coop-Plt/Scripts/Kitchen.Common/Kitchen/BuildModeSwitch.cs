using UnityEngine;

namespace Kitchen
{
	public class BuildModeSwitch : MonoBehaviour
	{
		public GameObject ItemMode;

		public GameObject ApplianceMode;

		private bool IsPrepTime;

		private bool IsUpdated;

		private void Update()
		{
			bool isPreparationTime = GameInfo.IsPreparationTime;
			if (!IsUpdated || IsPrepTime != isPreparationTime)
			{
				SetPrepTime(isPreparationTime);
				IsPrepTime = isPreparationTime;
				IsUpdated = true;
			}
		}

		public void SetPrepTime(bool is_prep_time)
		{
			if (ItemMode != null)
			{
				ItemMode.SetActive(!is_prep_time);
			}
			if (ApplianceMode != null)
			{
				ApplianceMode.SetActive(is_prep_time);
			}
		}
	}
}

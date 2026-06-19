using Items.Box;
using UnityEngine;

namespace Player.TutorialHelpers
{
	public class PlayerFinderTutorialHelper : BaseTutorialHelper
	{
		[SerializeField]
		private RaycasterInfo _raycasterInfo;

		private void Update()
		{
			if (_raycasterInfo.Hit.transform != null && (bool)_raycasterInfo.Hit.transform.GetComponent<TutorialTableItemBox>())
			{
				EmitStep("findTable");
			}
		}
	}
}

using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts
{
	public class NavigateToMissionControlPage : MonoBehaviour
	{
		public EMissionControlPage Page;

		public void OnClick()
		{
			MissionControlNavigator.Instance.NavigateTowards(Page);
		}
	}
}

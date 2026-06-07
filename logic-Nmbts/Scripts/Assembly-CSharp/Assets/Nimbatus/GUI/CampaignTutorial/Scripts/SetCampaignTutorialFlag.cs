using Assets.Nimbatus.GUI.DroneSelection.Scripts;
using Assets.Nimbatus.Scripts.Campaign;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.CampaignTutorial.Scripts
{
	public class SetCampaignTutorialFlag : MonoBehaviour
	{
		public string Id;

		public bool To = true;

		public void OnClick()
		{
			LaunchDrone component = GetComponent<LaunchDrone>();
			if (!(component != null) || component.IsReady)
			{
				SerializableMonobehaviour<CampaignTutorialManager, CampaignTutorialSaveData>.Instance.SetFlag(Id, To);
			}
		}
	}
}

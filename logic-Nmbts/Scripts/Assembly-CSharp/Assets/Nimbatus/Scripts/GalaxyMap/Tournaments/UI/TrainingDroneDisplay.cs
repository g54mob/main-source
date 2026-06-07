using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using I2.Loc;
using Steamworks;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI
{
	public class TrainingDroneDisplay : MonoBehaviour
	{
		public UITexture Texture;

		public UILabel DroneName;

		public UILabel AuthorName;

		private TrainingDrone _drone;

		public void Init(TrainingDrone drone)
		{
			_drone = drone;
			DroneData droneData = drone.DroneData;
			int score = drone.Score;
			if (droneData == null)
			{
				return;
			}
			Texture.gameObject.SetActive(true);
			Texture.mainTexture = droneData.Image;
			DroneName.text = LabelHelper.Blue + droneData.DroneName;
			AuthorName.text = LocalizationManager.GetTermTranslation("Tournaments/AiDrone");
			if (!SteamManager.Initialized)
			{
				return;
			}
			ulong userId = droneData.UserId;
			if (userId != 0)
			{
				string friendPersonaName = SteamFriends.GetFriendPersonaName(new CSteamID(userId));
				if (score > 0)
				{
					AuthorName.text = LabelHelper.White + LocalizationManager.GetTermTranslation("Tournaments/BuiltBy") + " " + LabelHelper.DarkOrange + friendPersonaName;
					UILabel authorName = AuthorName;
					authorName.text = authorName.text + LabelHelper.NewLine + LabelHelper.White + LocalizationManager.GetTermTranslation("Tournaments/TournamentWins") + " " + LabelHelper.DarkOrange + score;
				}
			}
		}

		public void OnClick()
		{
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ResetActiveDrone();
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.SetActiveDrone(_drone.DroneData, 1);
			GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.IsInTraining = true;
			NimbatusSceneManager.LoadScene("TournamentTrainingScene");
		}
	}
}

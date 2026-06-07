using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Steamworks;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.SumoArena
{
	public class ReadOnlyDroneDisplay : MonoBehaviour
	{
		public UITexture Texture;

		public UILabel DroneName;

		public UILabel AuthorName;

		public void Start()
		{
			Init(null, 0, false, false);
		}

		public void Init(DroneData droneInfo, int score, bool showAuthor, bool showScore)
		{
			if (droneInfo == null)
			{
				return;
			}
			Texture.gameObject.SetActive(true);
			Texture.mainTexture = droneInfo.Image;
			DroneName.text = LabelHelper.Blue + droneInfo.DroneName;
			if (SteamManager.Initialized)
			{
				ulong userId = droneInfo.UserId;
				if (userId != 0)
				{
					AuthorName.text = "";
					if (showAuthor)
					{
						string friendPersonaName = SteamFriends.GetFriendPersonaName(new CSteamID(userId));
						AuthorName.text = LabelHelper.White + "Built by " + LabelHelper.DarkOrange + friendPersonaName;
					}
					if (showScore)
					{
						UILabel authorName = AuthorName;
						authorName.text = authorName.text + LabelHelper.NewLine + LabelHelper.White + "Tournament Wins: " + LabelHelper.DarkOrange + score;
					}
				}
				else
				{
					AuthorName.text = "AI Drone";
				}
			}
			else
			{
				AuthorName.text = "AI Drone";
			}
		}
	}
}

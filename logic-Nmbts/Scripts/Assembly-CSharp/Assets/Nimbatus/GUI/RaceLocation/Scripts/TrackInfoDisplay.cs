using Assets.Nimbatus.Scripts.GalaxyMap.Race;
using Assets.Nimbatus.Scripts.Leaderboards;
using UnityEngine;

namespace Assets.Nimbatus.GUI.RaceLocation.Scripts
{
	public class TrackInfoDisplay : MonoBehaviour
	{
		public UILabel NameLabel;

		public UILabel DescriptionLabel;

		public UITexture PreviewImage;

		public UITexture LogoImage;

		public DisplayLeaderBoard LeaderBoardDisplay;

		public SelectTrackButton StartButton;

		public SelectTrackButton StartAutonomousButton;

		public void Init(RaceTrack track)
		{
			NameLabel.text = track.Name.GetTranslation();
			NameLabel.color = track.Color;
			DescriptionLabel.text = track.Description.GetTranslation();
			PreviewImage.mainTexture = track.PreviewImage;
			PreviewImage.color = track.Color;
			LogoImage.mainTexture = track.Logo;
			StartButton.Init(track);
			StartAutonomousButton.Init(track);
			LeaderBoardDisplay.Init(track.Leaderboard, track.AutonomousLeaderboard);
		}
	}
}

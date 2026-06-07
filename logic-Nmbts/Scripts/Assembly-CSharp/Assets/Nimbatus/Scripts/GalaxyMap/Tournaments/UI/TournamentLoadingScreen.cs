using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI
{
	public class TournamentLoadingScreen : TournamentScreen
	{
		public UILabel LoadingLabel;

		public UITexture LoadingImage;

		public override void Init()
		{
		}

		public void Update()
		{
			if (!(LoadingImage == null))
			{
				LoadingImage.transform.Rotate(Vector3.forward, -60f * Time.deltaTime);
			}
		}

		public void UpdateText(string text)
		{
			LoadingLabel.text = text;
		}
	}
}

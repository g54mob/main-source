using UnityEngine;

namespace Assets.Nimbatus.GUI.RaceLocation.Scripts
{
	public class TrackSelectorArrow : MonoBehaviour
	{
		public FillUpTrackList FillUpTrackList;

		public bool Up;

		public void OnClick()
		{
			FillUpTrackList.ChangeIndex(Up);
		}

		public void Update()
		{
			if (Up && Input.GetKeyDown(KeyCode.RightArrow))
			{
				OnClick();
			}
			else if (!Up && Input.GetKeyDown(KeyCode.LeftArrow))
			{
				OnClick();
			}
		}
	}
}

using UnityEngine;

namespace Assets.Nimbatus.GUI.RaceLocation.Scripts
{
	public class TrackIndicator : MonoBehaviour
	{
		public UITexture DotTexture;

		public Color SelectedColor;

		public Color NotSelectedColor;

		private FillUpTrackList _trackList;

		private int _index;

		public void Init(int index, FillUpTrackList trackList)
		{
			_trackList = trackList;
			_index = index;
		}

		public void Update()
		{
			if (_index == _trackList.SelectedIndex)
			{
				DotTexture.color = SelectedColor;
			}
			else
			{
				DotTexture.color = NotSelectedColor;
			}
		}

		public void OnClick()
		{
			_trackList.ChangeIndexTo(_index);
		}
	}
}

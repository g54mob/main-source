using Assets.Nimbatus.Scripts.GalaxyMap.Race;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.RaceLocation.Scripts
{
	public class FillUpTrackList : MonoBehaviour
	{
		public TrackInfoDisplay Display;

		public UIGrid IndicatorGrid;

		public TrackIndicator IndicatorPrefab;

		[HideInInspector]
		public int SelectedIndex { get; private set; }

		public void Start()
		{
			if (BaseSingleton<RaceTrackManager>.Instance.SelectedTrack != null)
			{
				SelectedIndex = BaseSingleton<RaceTrackManager>.Instance.RaceTracks.IndexOf(BaseSingleton<RaceTrackManager>.Instance.SelectedTrack);
			}
			DoUpdate();
			for (int i = 0; i < BaseSingleton<RaceTrackManager>.Instance.RaceTracks.Count; i++)
			{
				TrackIndicator trackIndicator = Object.Instantiate(IndicatorPrefab);
				trackIndicator.transform.position = IndicatorGrid.transform.position;
				trackIndicator.transform.parent = IndicatorGrid.transform;
				trackIndicator.transform.localScale = IndicatorPrefab.transform.localScale;
				trackIndicator.Init(i, this);
			}
			IndicatorGrid.Reposition();
		}

		public void ChangeIndex(bool up)
		{
			if (up)
			{
				if (SelectedIndex + 1 < BaseSingleton<RaceTrackManager>.Instance.RaceTracks.Count)
				{
					SelectedIndex++;
				}
				else
				{
					SelectedIndex = 0;
				}
			}
			else if (SelectedIndex - 1 >= 0)
			{
				SelectedIndex--;
			}
			else
			{
				SelectedIndex = BaseSingleton<RaceTrackManager>.Instance.RaceTracks.Count - 1;
			}
			DoUpdate();
		}

		public void ChangeIndexTo(int index)
		{
			SelectedIndex = index;
			DoUpdate();
		}

		private void DoUpdate()
		{
			BaseSingleton<RaceTrackManager>.Instance.SelectTrack(BaseSingleton<RaceTrackManager>.Instance.RaceTracks[SelectedIndex]);
			Display.Init(BaseSingleton<RaceTrackManager>.Instance.SelectedTrack);
		}
	}
}

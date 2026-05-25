using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class EndGameTimeline : MonoBehaviour
{
	public PlayableDirector Director;

	private void Start()
	{
		if (EndOfGameController.IsBadEnding)
		{
			ToggleTrackGroup("Bad Ending", isActive: true);
			ToggleTrackGroup("Good Ending", isActive: false);
			ToggleTrackGroup("Extended Ending", isActive: false);
		}
		else
		{
			ToggleTrackGroup("Bad Ending", isActive: false);
			ToggleTrackGroup("Good Ending", isActive: true);
			ToggleTrackGroup("Extended Ending", CharDisplay.HasHat);
		}
		Director.RebuildGraph();
		Director.Evaluate();
	}

	public void ToggleTrackGroup(string groupName, bool isActive)
	{
		TimelineAsset timelineAsset = GetComponent<PlayableDirector>().playableAsset as TimelineAsset;
		if (!(timelineAsset == null))
		{
			GroupTrack groupTrack = timelineAsset.GetRootTracks().OfType<GroupTrack>().FirstOrDefault((GroupTrack g) => g.name == groupName);
			if (groupTrack != null)
			{
				groupTrack.muted = !isActive;
			}
		}
	}
}

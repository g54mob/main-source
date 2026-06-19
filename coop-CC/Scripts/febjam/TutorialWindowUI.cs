using Aggro.Core;
using UnityEngine.Video;

public class TutorialWindowUI : AggroManagerBase<TutorialWindowUI>
{
	public EaseUI easeUI;

	public VideoPlayer videoPlayer;

	public InputIconTextHandler textHandler;

	protected override void OnUpdatePresentationEarly()
	{
		easeUI.show = false;
	}

	public void SetVisibleThisFrame()
	{
		easeUI.show = true;
	}
}

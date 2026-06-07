using System.Collections.Generic;
using UnityEngine.UI;

public class LEManualView : BaseGUIView
{
	public const string CloseButtonEvent = "LEManualView.CloseButtonEvent";

	private Button closeButton;

	private List<VideoPlayerFixer> videoPlayers;

	public override void Initialize()
	{
		closeButton = mainPanel.transform.FindComponent<Button>("CloseButton", isRecursively: true);
		closeButton.onClick.AddListener(delegate
		{
			NotifyChange("LEManualView.CloseButtonEvent");
		});
		videoPlayers = new List<VideoPlayerFixer>();
		mainPanel.GetComponentsInChildren(includeInactive: true, videoPlayers);
	}

	public override void SetVisibility(bool isVisible)
	{
		base.SetVisibility(isVisible);
		for (int i = 0; i < videoPlayers.Count; i++)
		{
			if (videoPlayers[i].gameObject.activeInHierarchy)
			{
				if (isVisible)
				{
					videoPlayers[i].PlayVideo();
				}
				else
				{
					videoPlayers[i].StopVideo();
				}
			}
		}
	}
}

using UnityEngine;

[RequireComponent(typeof(TooltipPanelBase))]
public class TooltipAudioEffect : UIAudioEffectBase
{
	[SerializeField]
	private AudioClip showUpClip;

	private TooltipPanelBase tooltipPanel;

	public AudioClip ShowUpClip
	{
		set
		{
			showUpClip = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		tooltipPanel = GetComponent<TooltipPanelBase>();
		tooltipPanel.OnTooltipDisplayedEvent += OnTooltipDisplayedHandler;
	}

	private void OnTooltipDisplayedHandler()
	{
		if (showUpClip != null)
		{
			PlayAudio(showUpClip);
		}
	}
}

using TMPro;
using UnityEngine;

public class FullscreenPanelContainer : PanelContainer
{
	[Header("Fullscreen")]
	[SerializeField]
	private TextMeshProUGUI _title;

	public override bool Open(PanelID id, IPanelContext context = null)
	{
		if (base.Open(id, context))
		{
			_title.text = base.OpenPanel.Title;
			return true;
		}
		return false;
	}
}

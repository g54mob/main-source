using UnityEngine;
using UnityEngine.UI;

public class GemUI : UIListElement
{
	[SerializeField]
	private Image gemImage;

	[SerializeField]
	private TooltipComponent_detailedText tooltip;

	private GemData gemData;

	public GemData GemData
	{
		get
		{
			return gemData;
		}
		protected set
		{
			gemData = value;
		}
	}

	public override void LoadData()
	{
		if (base.Data != null)
		{
			GemData = base.Data as GemData;
			SetGem(GemData);
		}
		else
		{
			SetGem(null);
		}
	}

	public virtual void SetGem(GemData gemData)
	{
		if ((bool)gemData)
		{
			GemData = gemData;
			gemImage.gameObject.SetActive(value: true);
			gemImage.sprite = gemData.Icon;
			tooltip.HeaderText = GemData.DisplayName;
			tooltip.BodyText = GemData.Description;
		}
		else
		{
			GemData = null;
			gemImage.gameObject.SetActive(value: false);
		}
	}
}

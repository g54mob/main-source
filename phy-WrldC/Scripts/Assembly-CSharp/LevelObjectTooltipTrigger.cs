using UnityEngine;

public class LevelObjectTooltipTrigger : TooltipTriggerBase
{
	private LevelObjectTooltipPanel levelObjectTooltipPanel;

	public CustomLevelObjectsModel CustomLevelObjectsModel { get; set; }

	protected override void Update()
	{
		if (tooltipPanel == null && GameManager.Exist)
		{
			tooltipPanel = GameManager.Instance.GUIManager.LevelObjectTooltipPanel;
		}
		if (levelObjectTooltipPanel == null && tooltipPanel != null && tooltipPanel is LevelObjectTooltipPanel)
		{
			levelObjectTooltipPanel = tooltipPanel as LevelObjectTooltipPanel;
		}
		base.Update();
	}

	protected override void SetTooltipPanelContent()
	{
		if (CustomLevelObjectsModel != null)
		{
			string text = CustomLevelObjectsModel.Name;
			string text2 = CustomLevelObjectsModel.Name;
			string description = CustomLevelObjectsModel.Description;
			if (CustomLevelObjectsModel.Origin == CustomLevelObjectsModel.OriginEnum.Part)
			{
				text2 = LanguagesManager.Instance.GetText("leveleditor.object.name." + text, text);
				description = LanguagesManager.Instance.GetText("leveleditor.object.description." + text, text);
			}
			string scale = "";
			if (CustomLevelObjectsModel.LastLevelObjectScale != Vector3.one)
			{
				Vector3 lastLevelObjectScale = CustomLevelObjectsModel.LastLevelObjectScale;
				scale = "(" + lastLevelObjectScale.x + " x " + lastLevelObjectScale.y + " x " + lastLevelObjectScale.z + ")";
			}
			levelObjectTooltipPanel.SetLevelObjectInfos(text2, description, scale);
		}
	}
}

using System.Collections;
using UnityEngine;

public class LEPropertiesController : BaseController<LEPropertiesView>
{
	private LevelEditorToolsModel levelEditorToolsModel;

	public LEPropertiesController(LEPropertiesView view, LevelEditorToolsModel levelEditorToolsModel)
		: base(view)
	{
		this.levelEditorToolsModel = levelEditorToolsModel;
	}

	public void Initialize()
	{
		GUIManager.Instance.LETopButtonsController.LevelEditorToolsController.view.SetLevelPropertiesToggleValue(view.IsVisible);
		view.SetHandSnapStepInputValue(levelEditorToolsModel.HandSnapStep);
		view.SetMoveSnapStepInputValue(levelEditorToolsModel.MoveSnapStep);
		view.SetRotationSnapStepInputValue(levelEditorToolsModel.RotationSnapStep);
		view.SetScaleSnapStepInputValue(levelEditorToolsModel.ScaleSnapStep);
	}

	public void UpdateAfterLoadLevelModel()
	{
		view.SetGroundHeightSliderValue(LevelEditorManager.Instance.GetGroundHeight());
		view.SetFailureZoneHeightSliderValue(LevelEditorManager.Instance.GetFailureZoneHeight());
		LevelEditorManager.Instance.SetFailureZoneVisibility(view.GetFailureZoneToggleValue());
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "LEPropertiesView.GroundHeightSliderEvent":
		{
			float groundHeight = (float)data[0];
			LevelEditorManager.Instance.SetGroundHeight(groundHeight);
			break;
		}
		case "LEPropertiesView.FailureZoneHeightSliderEvent":
		{
			float failureZoneHeight = (float)data[0];
			LevelEditorManager.Instance.SetFailureZoneHeight(failureZoneHeight);
			break;
		}
		case "LEPropertiesView.FailureZoneToggleEvent":
		{
			bool failureZoneVisibility = (bool)data[0];
			LevelEditorManager.Instance.SetFailureZoneVisibility(failureZoneVisibility);
			break;
		}
		case "LEPropertiesView.HandSnapStepInputEvent":
		{
			string valueStr = (string)data[0];
			levelEditorToolsModel.HandSnapStep = GetSnapStepValueFromString(valueStr, levelEditorToolsModel.HandSnapStep);
			break;
		}
		case "LEPropertiesView.MoveSnapStepInputEvent":
		{
			string valueStr = (string)data[0];
			levelEditorToolsModel.MoveSnapStep = GetSnapStepValueFromString(valueStr, levelEditorToolsModel.MoveSnapStep);
			break;
		}
		case "LEPropertiesView.RotationSnapStepInputEvent":
		{
			string valueStr = (string)data[0];
			levelEditorToolsModel.RotationSnapStep = GetSnapStepValueFromString(valueStr, levelEditorToolsModel.RotationSnapStep);
			break;
		}
		case "LEPropertiesView.ScaleSnapStepInputEvent":
		{
			string valueStr = (string)data[0];
			levelEditorToolsModel.ScaleSnapStep = GetSnapStepValueFromString(valueStr, levelEditorToolsModel.ScaleSnapStep);
			break;
		}
		case "LEPropertiesView.CloseButtonEvent":
			GameManager.Instance.StartCoroutine(HideViewAfterFrame());
			break;
		}
		IEnumerator HideViewAfterFrame()
		{
			yield return new WaitForEndOfFrame();
			view.SetVisibility(isVisible: false);
			GUIManager.Instance.LETopButtonsController.LevelEditorToolsController.view.SetLevelPropertiesToggleValue(isSelected: false);
		}
	}

	private float GetSnapStepValueFromString(string valueStr, float defaultValue)
	{
		if (float.TryParse(valueStr, out var result) && result > 0f)
		{
			return result;
		}
		return defaultValue;
	}
}

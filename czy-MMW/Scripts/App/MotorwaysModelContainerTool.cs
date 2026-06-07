using System.Collections.Generic;
using Factory;

public class MotorwaysModelContainerTool : BaseInGameDevTool<MotorwaysModelContainerTool, MotorwaysDevToolCommand>, IReleasedFromScopeHandler
{
	protected ToolModelType toolModelType;

	protected List<IInGameModelDevTool> toolsForModel = new List<IInGameModelDevTool>();

	public void RegisterNewTool(IInGameModelDevTool newTool)
	{
		toolsForModel.Add(newTool);
	}

	public void RemoveTool(IInGameModelDevTool oldTool)
	{
		toolsForModel.Remove(oldTool);
	}

	public void OnReleasedFromScope(IScope scope)
	{
		foreach (IInGameModelDevTool item in toolsForModel)
		{
			scope.Release(item);
		}
		toolsForModel.Clear();
	}

	public MotorwaysModelContainerTool SetModelType(ToolModelType newToolModelType)
	{
		toolModelType = newToolModelType;
		SetEditorDisplayName(toolModelType.ToString() + " Inspector");
		switch (toolModelType)
		{
		case ToolModelType.Destination:
			SetEditorIconPath("Assets/Art/UI/InGameBuilding/SPR_UI_Temp_InGameBuilding_00.png");
			break;
		case ToolModelType.House:
			SetEditorIconPath("Assets/Art/UI/SPR_UI_Button_home.png");
			break;
		case ToolModelType.Unknown:
			SetEditorIconPath("Assets/Art/UI/Menus/Options/SPR_UI_MenuX.png");
			break;
		}
		return this;
	}

	public List<IInGameModelDevTool> GetToolsForModel()
	{
		return toolsForModel;
	}

	protected override void OnActivation()
	{
		foreach (IInGameModelDevTool item in toolsForModel)
		{
			item.OnModelActivation();
		}
	}

	public override void OnToolDeselected()
	{
		foreach (IInGameModelDevTool item in toolsForModel)
		{
			item.OnToolDeselected();
		}
	}

	public override void OnToolSelected()
	{
		foreach (IInGameModelDevTool item in toolsForModel)
		{
			item.OnToolSelected();
		}
	}

	public override void Tick(TimeInterval timeInterval, float stepAlpha, out bool activatedThisTick)
	{
		bool flag = false;
		foreach (IInGameModelDevTool item in toolsForModel)
		{
			item.Tick(timeInterval, stepAlpha, out var activatedThisTick2);
			flag = flag || activatedThisTick2;
		}
		activatedThisTick = flag;
	}

	public override void Reset()
	{
		base.Reset();
		toolModelType = ToolModelType.Unknown;
		toolsForModel.Clear();
	}

	public override void DrawEditorTool()
	{
	}
}

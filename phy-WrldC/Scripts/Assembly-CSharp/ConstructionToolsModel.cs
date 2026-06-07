using UnityEngine;

public class ConstructionToolsModel : BaseModel
{
	public const string UndoCommandEvent = "ConstructionToolsModel.UndoCommandEvent";

	public const string RedoCommandEvent = "ConstructionToolsModel.RedoCommandEvent";

	public const string ConstructionCommandsChangedEvent = "ConstructionToolsModel.ConstructionCommandsChangedEvent";

	public const string ConnectorGridSizeChangedEvent = "ConstructionToolsModel.ConnectorGridSizeChangedEvent";

	public const string ConnectionTypeChangedEvent = "ConstructionToolsModel.ConnectionTypeChangedEvent";

	public const string MovingToolChangedEvent = "ConstructionToolsModel.MovingToolChangedEvent";

	public const string GizmosVisibilityEvent = "ConstructionToolsModel.GizmosVisibilityEvent";

	public const string MassCenterVisibilityEvent = "ConstructionToolsModel.MassCenterVisibilityEvent";

	public const string AutoFocusChangedEvent = "ConstructionToolsModel.AutoFocusChangedEvent";

	public const string AutoConnectionsChangedEvent = "ConstructionToolsModel.AutoConnectionsChangedEvent";

	public const int MaxConnectorGridSize = 6;

	private int connectorGridSize;

	private bool isMovingToolEnabled;

	private bool isHingeJointConnection;

	private bool isGizmosVisible;

	private bool isMassCenterVisible;

	private bool isAutoFocusActivated;

	private bool isAutoConnectionsActivated;

	public int ConnectorGridSize
	{
		get
		{
			return connectorGridSize;
		}
		set
		{
			int num = Mathf.Clamp(value, 1, 6);
			if (connectorGridSize != num)
			{
				connectorGridSize = num;
				NotifyChange("ConstructionToolsModel.ConnectorGridSizeChangedEvent", connectorGridSize);
			}
		}
	}

	public bool IsMovingToolEnabled
	{
		get
		{
			return isMovingToolEnabled;
		}
		set
		{
			isMovingToolEnabled = value;
			NotifyChange("ConstructionToolsModel.MovingToolChangedEvent", isMovingToolEnabled);
		}
	}

	public bool IsHingeJointConnection
	{
		get
		{
			return isHingeJointConnection;
		}
		set
		{
			isHingeJointConnection = value;
			NotifyChange("ConstructionToolsModel.ConnectionTypeChangedEvent", isHingeJointConnection);
		}
	}

	public bool IsGizmosVisible
	{
		get
		{
			return isGizmosVisible;
		}
		set
		{
			isGizmosVisible = value;
			NotifyChange("ConstructionToolsModel.GizmosVisibilityEvent", isGizmosVisible);
		}
	}

	public bool IsMassCenterVisible
	{
		get
		{
			return isMassCenterVisible;
		}
		set
		{
			isMassCenterVisible = value;
			NotifyChange("ConstructionToolsModel.MassCenterVisibilityEvent", isMassCenterVisible);
		}
	}

	public bool IsAutoFocusActivated
	{
		get
		{
			return isAutoFocusActivated;
		}
		set
		{
			isAutoFocusActivated = value;
			NotifyChange("ConstructionToolsModel.AutoFocusChangedEvent", isAutoFocusActivated);
		}
	}

	public bool IsAutoConnectionsActivated
	{
		get
		{
			return isAutoConnectionsActivated;
		}
		set
		{
			isAutoConnectionsActivated = value;
			NotifyChange("ConstructionToolsModel.AutoConnectionsChangedEvent", isAutoConnectionsActivated);
		}
	}

	public ConstructionToolsModel(ConstructionCommandsModel constructionCommandsModel)
	{
		connectorGridSize = 1;
		isMovingToolEnabled = false;
		isHingeJointConnection = false;
		isGizmosVisible = true;
		isMassCenterVisible = false;
		isAutoFocusActivated = true;
		isAutoConnectionsActivated = true;
		constructionCommandsModel.NotifyChangeEvent += ConstructionCommandsModelChangeHandler;
	}

	private void ConstructionCommandsModelChangeHandler(string eventName, object[] data)
	{
		switch (eventName)
		{
		case "ConstructionCommandsModel.CommandExecutedEvent":
		case "CommandManagerModel.CommandRevertedEvent":
		case "CommandManagerModel.LastRevertedCommandExecutedEvent":
		case "CommandManagerModel.ClearedAllCommandsEvent":
		{
			int num = (int)data[0];
			int num2 = (int)data[1];
			NotifyChange("ConstructionToolsModel.ConstructionCommandsChangedEvent", num, num2);
			break;
		}
		}
	}

	public void UndoCommand()
	{
		NotifyChange("ConstructionToolsModel.UndoCommandEvent");
	}

	public void RedoCommand()
	{
		NotifyChange("ConstructionToolsModel.RedoCommandEvent");
	}
}

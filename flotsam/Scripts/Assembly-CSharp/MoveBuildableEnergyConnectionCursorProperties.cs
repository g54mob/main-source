using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Cursor Properties/Move Buildable Energy Connection")]
public class MoveBuildableEnergyConnectionCursorProperties : EnergyGridConnectCursorProperties
{
	private MoveBuildableCursorProperties _moveBuildableCursorProperties;

	public void Activate(MoveBuildableCursorProperties moveBuildableCursorProperties)
	{
		Activate();
		_moveBuildableCursorProperties = moveBuildableCursorProperties;
	}

	protected override void Connect(EnergyGridConnector other, CursorManager cursor)
	{
		if (!(other == null) && !(other == _component) && _componentsInRadius.Contains(other) && _component.CanConnect() && other.CanConnect() && !_component.IsConnected(other))
		{
			EnergyGrid.Connect(_component, other);
			if (other.CanConnect())
			{
				DisableHighlights();
				_component = other;
				Activate();
			}
			else
			{
				_moveBuildableCursorProperties.DeactivateEnergyConnection();
			}
		}
	}
}

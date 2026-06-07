using UnityEngine;

public class MagneticConnectorModule : Module
{
	public enum Commands
	{
		ProcessButtonPress = 1,
		UpdateVisuals = 2
	}

	public class MagneticConnector_EventData : EventData
	{
		public bool IsConnected;

		public MagneticConnector_EventData()
		{
		}

		public MagneticConnector_EventData(bool isConnected)
		{
		}
	}

	public Transform movingTransform;

	public float movingDistance;

	private bool isPressed;

	private ModuleProperty buttonStateProperty;

	private ModuleProperty isConnectedStateProperty;

	private ModuleProperty attachedConnectorProperty;

	public bool isConnected => false;

	protected override void OnSetupFinished()
	{
	}

	public override void OnGadgetDeserialized()
	{
	}

	protected override void OnUnsolder()
	{
	}

	protected override void ExecuteCommand(int commandId)
	{
	}

	public bool TryConnection()
	{
		return false;
	}

	protected override void UpdateVisuals()
	{
	}

	public override void OnTurnOn()
	{
	}

	public void OnInteractionDown()
	{
	}

	public void OnInteractionUp()
	{
	}

	public override void OnPreTickUpdate(TickLoop tickLoop)
	{
	}

	public void SetIsConnected(MagneticConnectorModule attachedTo)
	{
	}
}

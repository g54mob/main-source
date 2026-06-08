public class TransporterReceiver : RoomItem
{
	private bool _isResponding;

	private bool delayTakeOffline;

	private bool delayBringOnline;

	public override string ItemName
	{
		get
		{
			return "Transport Receiver";
		}
	}

	public bool IsResponding
	{
		get
		{
			return _isResponding;
		}
		set
		{
			_isResponding = value;
			if (value)
			{
				SetActive();
			}
			else
			{
				SetInactive();
			}
		}
	}

	public bool IsOffline { get; private set; }

	protected override HelpTextTypeEnum _helpTextType
	{
		get
		{
			return HelpTextTypeEnum.Receiver;
		}
	}

	protected override bool _shouldShowHelpTextByDefault
	{
		get
		{
			return false;
		}
	}

	public override void Start()
	{
		base.Start();
		Reset();
		droneUIObject.AddInfoCommand("transport");
		droneUIObject.Visible = false;
	}

	public void Reset()
	{
		_isResponding = false;
	}

	public void TakeOffline()
	{
		if (droneUIObject != null)
		{
			droneUIObject.Deactivated = true;
			droneUIObject.Visible = false;
		}
		else
		{
			delayTakeOffline = true;
		}
		IsResponding = false;
		IsOffline = true;
	}

	public void BringOnline()
	{
		if (droneUIObject != null)
		{
			droneUIObject.Deactivated = false;
			droneUIObject.Visible = true;
		}
		else
		{
			delayBringOnline = true;
		}
		IsResponding = true;
		IsOffline = false;
		base.roomLocation.RefreshOnRoomStatusChange();
	}

	public void RefreshIcon()
	{
		if (GlobalSettings.cameraMode == CameraMode.Schematic && droneUIObject != null)
		{
			droneUIObject.RevealOnSchematic();
		}
	}

	private new void Update()
	{
		if (!GlobalSettings.IsGamePaused)
		{
			if (delayBringOnline && droneUIObject != null)
			{
				BringOnline();
				delayBringOnline = false;
			}
			else if (delayTakeOffline && droneUIObject != null)
			{
				TakeOffline();
				delayTakeOffline = false;
			}
		}
	}
}

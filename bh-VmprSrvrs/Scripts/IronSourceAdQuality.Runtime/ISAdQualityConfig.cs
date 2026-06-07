public class ISAdQualityConfig
{
	private string userId;

	private bool userIdSet;

	private bool testMode;

	private ISAdQualityInitCallback adQualityInitCallback;

	private ISAdQualityLogLevel logLevel;

	private string initializationSource;

	private bool coppa;

	private ISAdQualityDeviceIdType deviceIdType;

	public string UserId
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	internal bool UserIdSet => false;

	public bool TestMode
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public ISAdQualityLogLevel LogLevel
	{
		get
		{
			return default(ISAdQualityLogLevel);
		}
		set
		{
		}
	}

	public ISAdQualityInitCallback AdQualityInitCallback
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public string InitializationSource
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool Coppa
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public ISAdQualityDeviceIdType DeviceIdType
	{
		get
		{
			return default(ISAdQualityDeviceIdType);
		}
		set
		{
		}
	}
}

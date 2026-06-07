public class PassiveBuzzerTool : PinBasedMobileTool
{
	public static PassiveBuzzerTool inst;

	private int type;

	public override void Awake()
	{
	}

	public static void IPC_BeginCreate(int t)
	{
	}

	private void _IPC_BeginCreate(int t)
	{
	}

	public static void IPC_UpdateProperty(int t)
	{
	}

	private Buzzer GetBuzzer()
	{
		return null;
	}

	public override void CancelEdit()
	{
	}

	public override void LoadEdit(BaseComponent comp)
	{
	}

	private void IPC_ApplyChanges()
	{
	}

	private void IPC_CancelEdit()
	{
	}

	public void BeginCreate(int t)
	{
	}

	public override void CompleteCreate()
	{
	}
}

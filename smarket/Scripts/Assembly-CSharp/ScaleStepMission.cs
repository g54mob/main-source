public class ScaleStepMission
{
	private int m_CurrentTask;

	private MissionTask[] m_Tasks;

	private bool m_HasBegun;

	public bool HasBegun => false;

	public bool HasEnded { get; private set; }

	public ScaleStepMission(params MissionTask[] tasks)
	{
	}

	public void Begin()
	{
	}

	public void End()
	{
	}

	public void Update()
	{
	}

	private void InitializeState()
	{
	}

	private void NextState()
	{
	}
}

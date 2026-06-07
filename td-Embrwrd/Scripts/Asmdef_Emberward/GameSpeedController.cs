public class GameSpeedController : Singleton<GameSpeedController>
{
	private bool isInBattle;

	private float systemGameSpeed;

	private float battleModeGameSpeed;

	private float cinematicSpeed;

	private float basicGameSpeed;

	private float debugGameSpeed;

	private bool isEventRegistered;

	public bool IsInBattle => false;

	public float SystemGameSpeed => 0f;

	public float BattleModeGameSpeed => 0f;

	public float CinematicSpeed => 0f;

	public float BasicGameSpeed => 0f;

	public float DebugGameSpeed => 0f;

	protected override void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}

	private void OnRequestModifySystemGameSpeed(float value)
	{
	}

	private void OnRequestModifyBattleGameSpeed(float value)
	{
	}

	private void OnRequestModifyBasicGameSpeed(float value)
	{
	}

	private void OnRequestModifyCinematicSpeed(float value)
	{
	}

	private void OnRequestModifyDebugGameSpeed(float value)
	{
	}

	private void OnBattleStart()
	{
	}

	private void OnBattleEnd()
	{
	}

	private void UpdateTotalSpeed()
	{
	}
}

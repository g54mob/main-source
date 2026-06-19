using FMODUnity;
using OUSystems.Basics.Effects;
using UnityEngine;

public class CreditsScreenHandler : MonoBehaviour
{
	public CreditsContainer CreditsContainer;

	public SimpleFillBar ProgressBar;

	public GameObject ProgressBarContainer;

	public ShakeReceiver HoldShakeReciever;

	public float HoldShakePerProgress;

	public bool Held;

	public float Progress;

	public float HoldTime;

	public bool Completed;

	public float FadeInDuration;

	public float FadeOutDuration;

	public EventReference SkipSound;

	public const string FinishGameAchievementID = "gamecomplete";

	public void Start()
	{
	}

	public void HoldStart()
	{
	}

	public void HoldEnd()
	{
	}

	public void OnEscape()
	{
	}

	private void Update()
	{
	}

	public void OnEnd()
	{
	}

	public void ExitToMainMenu()
	{
	}
}

using UnityEngine;

public class LvlVFXMgr : MonoBehaviour
{
	public static LvlVFXMgr I;

	[NamedArray(typeof(TrailPartType))]
	public BabyBallsSharedParticles[] TrailParticles;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnGameSpeedChanged()
	{
	}
}

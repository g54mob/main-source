using System.Collections;
using DV.Utils;
using UnityEngine;

public class TutorialBoundsPlayerChecker : SingletonBehaviour<TutorialBoundsPlayerChecker>
{
	public delegate void PlayerWithinTutorialBoundsChangedDelegate(bool withinBounds);

	private const float CHECK_DELAY = 3f;

	private BoxCollider[] tutorialBounds;

	private Coroutine checkCoro;

	public bool playerWithinBounds = true;

	[InspectorButton("StartChecking", true, true)]
	public bool startChecking;

	[InspectorButton("StopChecking", true, true)]
	public bool stopChecking;

	public event PlayerWithinTutorialBoundsChangedDelegate PlayerWithinTutorialBoundsChanged;

	protected override void Initialize()
	{
		base.Initialize();
		tutorialBounds = GetComponentsInChildren<BoxCollider>();
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		if (!UnloadWatcher.isUnloading)
		{
			StopChecking();
		}
	}

	public void StartChecking()
	{
		if (checkCoro != null)
		{
			SingletonBehaviour<CoroutineManager>.Instance.Stop(checkCoro);
		}
		checkCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(CheckDelayed());
	}

	public void StopChecking()
	{
		if (checkCoro != null)
		{
			SingletonBehaviour<CoroutineManager>.Instance.Stop(checkCoro);
		}
		checkCoro = null;
	}

	private IEnumerator CheckDelayed()
	{
		while (true)
		{
			yield return WaitFor.Seconds(3f);
			bool flag = IsWithinBounds();
			if (playerWithinBounds != flag)
			{
				playerWithinBounds = flag;
				this.PlayerWithinTutorialBoundsChanged?.Invoke(playerWithinBounds);
			}
		}
	}

	public bool IsWithinBounds()
	{
		Vector3 position = PlayerManager.PlayerTransform.position;
		bool result = false;
		BoxCollider[] array = tutorialBounds;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].ClosestPoint(position) == position)
			{
				result = true;
				break;
			}
		}
		return result;
	}
}

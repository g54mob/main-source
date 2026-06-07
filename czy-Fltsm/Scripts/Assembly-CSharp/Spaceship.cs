using System.Collections;
using FMODUnity;
using PajamaLlama.Extensions;
using PajamaLlama.Utilities;
using UnityEngine;

public class Spaceship : SceneBehaviour, IUIFlagsProvider
{
	[SerializeField]
	private QuestProperties _questProperties;

	[SerializeField]
	private Vector3 _acceleration;

	[SerializeField]
	private float _distance = 50f;

	[SerializeField]
	private float _disableDelay = 15f;

	[SerializeField]
	private ParticleSystem _engineParticles;

	[SerializeField]
	private ParticleSystem _smokeParticles;

	[SerializeField]
	private PanelContainerFlags _uiFlags = PanelContainerFlags.BlockDPadInput;

	[Header("FMOD")]
	[SerializeField]
	private EventReference _stringerEventReference;

	[SerializeField]
	private EventReference _rocketEventReference;

	[SerializeField]
	private FMODEventEmitter _rocketEventEmitter;

	public PanelContainerFlags Flags => _uiFlags;

	public bool BlockCancel => false;

	public bool BlockArchitectMode => true;

	private void OnEnable()
	{
		if (StoryManager.IsQuestCompleted(_questProperties))
		{
			base.gameObject.SetActive(value: false);
		}
		else
		{
			GameEventDispatcher.AddListener(GameEventType.LaunchSpaceship, OnLaunchSpaceship);
		}
	}

	private void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.LaunchSpaceship, OnLaunchSpaceship);
	}

	private IEnumerator LaunchRoutine()
	{
		Vector3 velocity = Vector3.zero;
		_smokeParticles?.Play(withChildren: true);
		_engineParticles?.Play(withChildren: true);
		if ((bool)_rocketEventEmitter)
		{
			_rocketEventEmitter.Emit(_rocketEventReference);
		}
		else
		{
			AudioManager.PlayOneShot(_rocketEventReference);
		}
		yield return new WaitForSeconds(_smokeParticles.main.duration);
		Vector3 startPosition = base.transform.position;
		Vector3 position = startPosition;
		AudioManager.PlayOneShot(_stringerEventReference);
		while ((position - startPosition).magnitude < _distance)
		{
			float unscaledDeltaTime = GameSpeedManager.UnscaledDeltaTime;
			velocity += _acceleration * unscaledDeltaTime;
			position += velocity * unscaledDeltaTime;
			base.transform.position = position;
			yield return null;
		}
		GameEventDispatcher.Dispatch(GameEventType.LaunchedSpaceship);
		float time = 0f;
		while (time < _disableDelay)
		{
			float unscaledDeltaTime2 = GameSpeedManager.UnscaledDeltaTime;
			time += unscaledDeltaTime2;
			position += velocity * unscaledDeltaTime2;
			base.transform.position = position;
			yield return null;
		}
	}

	private void OnLaunchSpaceship(GameEvent gameEvent)
	{
		GameEventDispatcher.RemoveListener(GameEventType.LaunchSpaceship, OnLaunchSpaceship);
		UIManager.AddFlagsProvider(this);
		PLCoroutine.Start(LaunchRoutine(), this).Completed.AddListener(OnLaunchRoutineCompleted);
	}

	private void OnLaunchRoutineCompleted(PLCoroutine coroutine, bool stopped)
	{
		UIManager.RemoveFlagsProvider(this);
		base.gameObject.SetActive(value: false);
		base.transform.Reset();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Achievements/Modules Active Achievement")]
public class ModulesActiveAchievement : AchievementBase
{
	[Header("Modules Active Achievement")]
	[SerializeField]
	private ModuleProperties _module;

	[SerializeField]
	private int _count;

	[SerializeField]
	[Tooltip("The amount of buildable that will be evaluated per frame.")]
	private int _evaluateStepSize = 10;

	private Coroutine _coroutine;

	private bool _reevaluate;

	protected override void Initialize()
	{
		_coroutine = CoroutineMotor.StartRoutine(Evaluate());
		GameEventDispatcher.AddListener(GameEventType.ModuleActivated, OnModuleActivated);
		GameEventDispatcher.AddListener(GameEventType.BuildableSalvaged, OnBuildableSalvaged);
	}

	public override void Uninitialize()
	{
		_coroutine = null;
		GameEventDispatcher.RemoveListener(GameEventType.ModuleActivated, OnModuleActivated);
		GameEventDispatcher.AddListener(GameEventType.BuildableSalvaged, OnBuildableSalvaged);
	}

	private IEnumerator Evaluate()
	{
		List<Buildable> buildables = Community.PlayerCommunity.Buildables;
		int count = 0;
		int yieldIndex = ((_evaluateStepSize <= 0) ? buildables.Count : _evaluateStepSize);
		for (int i = 0; i < buildables.Count; i++)
		{
			if (buildables[i].HasActiveModule(_module))
			{
				count++;
			}
			if (i == yieldIndex)
			{
				yieldIndex += _evaluateStepSize;
				yield return null;
			}
		}
		if (count >= _count && UnlockAchievement())
		{
			Uninitialize();
		}
		else if (_reevaluate)
		{
			_reevaluate = false;
			_coroutine = CoroutineMotor.StartRoutine(Evaluate());
		}
		else
		{
			_coroutine = null;
		}
	}

	private void OnModuleActivated(GameEvent gameEvent)
	{
		if (gameEvent is BuildableEvent buildableEvent && !(buildableEvent.ModuleProperties != _module))
		{
			if (_coroutine == null)
			{
				_coroutine = CoroutineMotor.StartRoutine(Evaluate());
			}
			else
			{
				_reevaluate = true;
			}
		}
	}

	private void OnBuildableSalvaged(GameEvent gameEvent)
	{
		if (_coroutine != null)
		{
			CoroutineMotor.StopRoutine(_coroutine);
			_coroutine = CoroutineMotor.StartRoutine(Evaluate());
			_reevaluate = false;
		}
	}
}

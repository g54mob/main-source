using PajamaLlama.Generic;
using UnityEngine;

public class RandomAnimationBehaviour : StateMachineBehaviour
{
	[SerializeField]
	[MinMaxRangeFloat(0f, 60f)]
	private RangedFloat _randomTimeInterval = new RangedFloat(10f, 20f);

	[SerializeField]
	[MinMaxRangeInt(0, 10)]
	private RangedInt _randomAnimationParameterInterval;

	[Space]
	[SerializeField]
	private string _randomAnimationParameterName = "Deviation";

	[SerializeField]
	private int _defaultParameter;

	private float _maxTimer;

	private float _timer;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		_maxTimer = _randomTimeInterval.ReturnRandom();
	}

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetInteger(_randomAnimationParameterName, _defaultParameter);
	}

	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		_timer += Time.unscaledDeltaTime;
		if (_timer >= _maxTimer)
		{
			_timer = 0f;
			animator.SetInteger(_randomAnimationParameterName, _randomAnimationParameterInterval.ReturnRandom());
		}
	}
}

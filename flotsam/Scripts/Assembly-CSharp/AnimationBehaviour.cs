using PajamaLlama.Debugs;
using UnityEngine;

public class AnimationBehaviour : StateMachineBehaviour
{
	[Header("Random Animations")]
	[Tooltip("The amount of random animations the randomizer can choose from.")]
	[SerializeField]
	private int _randomAnimationRange;

	[Tooltip("Time in seconds to wait before animation can be randomized. Don't set too low or you'll get random animation changes and twitches.")]
	[SerializeField]
	private float _timeBeforeRandomizing = 5f;

	[Header("Particle Systems")]
	[Tooltip("Prefab of the particle system to play.")]
	[SerializeField]
	private GameObject _particlePrefab;

	[Tooltip("If true, particle will only play one time. Else it will loop itself until it's destroyed/stopped.")]
	[SerializeField]
	private bool _playParticleOnce;

	[Tooltip("After this amount of seconds, the particle object will be destroyed. If 0 the particle will not be destroyed.")]
	[SerializeField]
	private float _particleLifetime = 3f;

	[Tooltip("Attach particle system to parent object so it follows its movement.")]
	[SerializeField]
	private bool _attachToParent = true;

	private AnimationTools _animationTools;

	private MeshAnimator _meshAnimator;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (_animationTools == null)
		{
			_animationTools = animator.GetComponent<AnimationTools>();
		}
		if (_meshAnimator == null)
		{
			_meshAnimator = animator.gameObject.GetComponentInParent<MeshAnimator>();
		}
		if (_meshAnimator.LastStateHash != stateInfo.shortNameHash)
		{
			_meshAnimator.ParticleAlreadyPlayed = false;
		}
		_meshAnimator.LastStateHash = stateInfo.shortNameHash;
		if (_particlePrefab == null)
		{
			if ((bool)_meshAnimator.ParticlePlaying)
			{
				Object.Destroy(_meshAnimator.ParticlePlaying);
			}
		}
		else if (_playParticleOnce)
		{
			if (!_meshAnimator.ParticleAlreadyPlayed)
			{
				Debugger.Log("Play particle one time - " + _particlePrefab.name, null, 3);
				SpawnParticleSystem(animator);
				_meshAnimator.ParticleAlreadyPlayed = true;
			}
		}
		else
		{
			SpawnParticleSystem(animator);
		}
	}

	public void SpawnParticleSystem(Animator animator)
	{
		GameObject gameObject = Object.Instantiate(_particlePrefab);
		if (_attachToParent)
		{
			gameObject.transform.SetParent(animator.gameObject.transform);
		}
		gameObject.transform.position = animator.gameObject.transform.position;
		_meshAnimator.ParticlePlaying = gameObject;
		if (_particleLifetime > 0f)
		{
			Object.Destroy(gameObject, _particleLifetime);
		}
	}

	private void RandomizeAnimation(Animator animator)
	{
		if (_randomAnimationRange > 0 && _meshAnimator.RandomAnimationEnabled)
		{
			_meshAnimator.StartAnimationCounter(_timeBeforeRandomizing);
		}
		int value = Random.Range(1, _randomAnimationRange + 1);
		animator.SetInteger("RandomID", value);
	}
}

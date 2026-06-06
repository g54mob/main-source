using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorGameObjectToggler : MonoBehaviour
{
	[Serializable]
	internal struct AnimationGameObjectToggle
	{
		[Tooltip("The state name that will trigger the disabling / enabling of the gameobjects.")]
		public string AnimationStateName;

		[Tooltip("The state name that will trigger the disabling / enabling of the gameobjects.")]
		public GameObject[] GameObjects;

		[Tooltip("State to set the gameobjects to when entering the animation state.")]
		public bool OnEnter;

		[Tooltip("State to set the gameobjects to when exiting the animation state.")]
		public bool OnExit;

		public void ToggleGameObjects(bool enter)
		{
			for (int i = 0; i < GameObjects.Length; i++)
			{
				GameObjects[i].SetActive(enter ? OnEnter : OnExit);
			}
		}
	}

	[SerializeField]
	[Tooltip("Array of all the animation gameobjects to toggle.")]
	private AnimationGameObjectToggle[] _animationGameObjectToggles;

	[SerializeField]
	[Tooltip("Layer index of the layer to check animation states for.")]
	private int _layerIndex;

	private Animator _animator;

	private AnimatorStateInfo _cachedAnimatorStateInfo;

	private AnimatorStateInfo _currentAnimatorStateInfo;

	private void Awake()
	{
		_animator = GetComponent<Animator>();
	}

	private void Update()
	{
		_cachedAnimatorStateInfo = _animator.GetCurrentAnimatorStateInfo(_layerIndex);
		if (_cachedAnimatorStateInfo.fullPathHash != _currentAnimatorStateInfo.fullPathHash)
		{
			HandleStateChange(_currentAnimatorStateInfo, enter: false);
			HandleStateChange(_cachedAnimatorStateInfo, enter: true);
			_currentAnimatorStateInfo = _cachedAnimatorStateInfo;
		}
	}

	private void HandleStateChange(AnimatorStateInfo stateInfo, bool enter)
	{
		for (int i = 0; i < _animationGameObjectToggles.Length; i++)
		{
			AnimationGameObjectToggle animationGameObjectToggle = _animationGameObjectToggles[i];
			if (stateInfo.IsName(animationGameObjectToggle.AnimationStateName))
			{
				animationGameObjectToggle.ToggleGameObjects(enter);
			}
		}
	}
}

using UnityEngine;

namespace CTS
{
	public class FurnitureAnimation : MonoBehaviour
	{
		[SerializeField]
		private AnimationClip _awakeClip;

		[SerializeField]
		private AnimationClip _spawnClip;

		private Animation _animation;

		private void Awake()
		{
			_animation = GetComponent<Animation>();
			if (!_animation)
			{
				_animation = base.gameObject.AddComponent<Animation>();
			}
			if (!_animation.GetClip(_awakeClip.name))
			{
				_animation.AddClip(_awakeClip, _awakeClip.name);
			}
			if (!_animation.GetClip(_spawnClip.name))
			{
				_animation.AddClip(_spawnClip, _spawnClip.name);
			}
			_animation.Play(_awakeClip.name);
		}

		private void OnEnable()
		{
			StopAllCoroutines();
			StartCoroutine(_animation.Play(_spawnClip.name, useTimeScale: false));
		}

		private void OnDisable()
		{
			_animation.Play(_awakeClip.name);
		}
	}
}

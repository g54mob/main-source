using System;
using System.Collections;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	public class VFXAnimation : MonoRoutine
	{
		[SerializeField]
		private AnimationClip _animationClip;

		[SerializeField]
		private AnimationClip _stopAnimationClip;

		[SerializeField]
		private GameObject[] _prefabReferences;

		[SerializeField]
		private bool _spawnInWorldSpace;

		[SerializeField]
		private bool _playInWorldSpace;

		[SerializeField]
		private bool _disableOnEnd;

		private Animation _animation;

		private RoomObject _parentRoomData;

		public float AnimationSpeed
		{
			get
			{
				IEnumerator enumerator = _animation.GetEnumerator();
				try
				{
					if (enumerator.MoveNext())
					{
						return ((AnimationState)enumerator.Current).speed;
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
				return 1f;
			}
			set
			{
				foreach (AnimationState item in _animation)
				{
					item.speed = value;
				}
			}
		}

		private void Awake()
		{
			_animation = GetComponent<Animation>();
			_parentRoomData = GetComponent<RoomObject>();
		}

		protected override IEnumerator Routine()
		{
			if ((bool)_animationClip)
			{
				if (_playInWorldSpace)
				{
					base.transform.SetParent(null);
				}
				string text = _animationClip.name;
				if (!_animation.GetClip(text))
				{
					_animation.AddClip(_animationClip, text);
				}
				_animation.Play(text);
				yield return Coroutines.WaitForSeconds(_animationClip.length);
				if (_disableOnEnd)
				{
					base.gameObject.SetActive(value: false);
				}
			}
		}

		public void SpawnPrefab(int p_index)
		{
			if (_prefabReferences.Length != 0)
			{
				int num = p_index.ClampIndex(_prefabReferences);
				GameObject gameObject = UnityEngine.Object.Instantiate(_prefabReferences[num], base.transform);
				if (!gameObject.activeSelf)
				{
					gameObject.gameObject.SetActive(value: true);
				}
				if (_spawnInWorldSpace)
				{
					gameObject.transform.SetParent(null);
				}
				if ((bool)_parentRoomData && gameObject.TryGetComponent<RoomObject>(out var component))
				{
					component.CurrentRoom = _parentRoomData.CurrentRoom;
				}
			}
		}

		public void Kill()
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		protected override void OnStop()
		{
			string text = _stopAnimationClip.name;
			if (!_animation.GetClip(text))
			{
				_animation.AddClip(_stopAnimationClip, text);
			}
			_animation.CrossFade(text, 0.1f);
		}
	}
}

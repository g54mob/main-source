using System.Collections;
using CTS.BBT;
using CTS.Core;
using CTS.Core.Utilities;
using DG.Tweening;
using UnityEngine;

namespace CTS
{
	public class GridDoor : MonoBehaviour
	{
		[Header("Speed Effect")]
		[SerializeField]
		[Space(10f)]
		private float _speedEffect;

		[Header("Audio Settings")]
		[SerializeField]
		[Space(10f)]
		private AudioSource _audioSource;

		[SerializeField]
		private SoundAsset _doorSounds;

		[Header("Link Settings")]
		[SerializeField]
		[Space(10f)]
		private Renderer[] _doors;

		[SerializeField]
		private Door _leftDoorRef;

		[SerializeField]
		private Door _rightDoorRef;

		private Material _leftDoor;

		private Material _rightDoor;

		private static readonly int SHCloseValue = Shader.PropertyToID("_Close_value");

		private Coroutine _leftRoutine;

		private Coroutine _rightRoutine;

		private void Awake()
		{
			_leftDoor = _doors[0].material;
			_rightDoor = _doors[1].material;
		}

		private void OnEnable()
		{
			LevelParameters.OnBarOpenedStatusChanged += OnBarOpen;
			_leftDoorRef.OnDoorOpen += OnLeftDoorOpen;
			_rightDoorRef.OnDoorOpen += OnRightDoorOpen;
		}

		private void OnDisable()
		{
			LevelParameters.OnBarOpenedStatusChanged -= OnBarOpen;
			_leftDoorRef.OnDoorOpen -= OnLeftDoorOpen;
			_rightDoorRef.OnDoorOpen -= OnRightDoorOpen;
		}

		private void OnBarOpen(bool value)
		{
			if (value)
			{
				SetDoorOpen(_leftDoorRef, _leftDoor, value: true);
				SetDoorOpen(_rightDoorRef, _rightDoor, value: true);
				return;
			}
			if (!_leftDoorRef.Open)
			{
				SetDoorOpen(_leftDoorRef, _leftDoor, value: false);
			}
			if (!_rightDoorRef.Open)
			{
				SetDoorOpen(_rightDoorRef, _rightDoor, value: false);
			}
		}

		private void OnLeftDoorOpen(bool value)
		{
			if (!CTSSingleton<LevelParameters>.Instance.IsOpen)
			{
				SetDoorOpen(_leftDoorRef, _leftDoor, value);
			}
		}

		private void OnRightDoorOpen(bool value)
		{
			if (!CTSSingleton<LevelParameters>.Instance.IsOpen)
			{
				SetDoorOpen(_rightDoorRef, _rightDoor, value);
			}
		}

		private void PlaySound(int index)
		{
			_audioSource.clip = _doorSounds.AudioClips[index];
			_audioSource.priority = _doorSounds.Priority;
			_audioSource.pitch = _doorSounds.PitchRange.RandomInRange();
			_audioSource.volume = _doorSounds.PitchRange.RandomInRange();
			_audioSource.Play();
		}

		private void SetDoorOpen(Door doorRef, Material mat, bool value)
		{
			if (doorRef == _leftDoorRef)
			{
				DoOpen(ref _leftRoutine);
			}
			else
			{
				DoOpen(ref _rightRoutine);
			}
			void DoOpen(ref Coroutine routine)
			{
				if (!value)
				{
					if (routine == null)
					{
						mat.DOFloat(1f, SHCloseValue, _speedEffect);
						PlaySound(1);
					}
				}
				else
				{
					if (routine != null)
					{
						StopCoroutine(routine);
					}
					else
					{
						PlaySound(0);
					}
					routine = StartCoroutine(Opening(doorRef, mat));
				}
			}
		}

		private IEnumerator Opening(Door doorRef, Material mat)
		{
			yield return mat.DOFloat(0f, SHCloseValue, _speedEffect).WaitForCompletion();
			yield return new WaitForSeconds(2f);
			if (doorRef == _leftDoorRef)
			{
				_leftRoutine = null;
			}
			else
			{
				_rightRoutine = null;
			}
			if (!doorRef.Open && !CTSSingleton<LevelParameters>.Instance.IsOpen)
			{
				SetDoorOpen(doorRef, mat, value: false);
			}
		}
	}
}

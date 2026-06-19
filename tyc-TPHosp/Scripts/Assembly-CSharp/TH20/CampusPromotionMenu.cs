using System;
using System.Collections;
using TH20.UI;
using UnityEngine;

namespace TH20
{
	public class CampusPromotionMenu : RectTransformAnimator
	{
		[SerializeField]
		private RectTransform _animationRoot;

		[SerializeField]
		private float _rootStartX;

		[SerializeField]
		private float _rootTargetX;

		[SerializeField]
		private float _rootBounceX;

		[SerializeField]
		private float _rootAnimStartDelay;

		[SerializeField]
		private float _rootAnimBounceTime;

		[SerializeField]
		private float _rootAnimEndTime;

		[SerializeField]
		private RectTransform[] _characterTransforms;

		[SerializeField]
		private float[] _characterMovementAngles;

		[SerializeField]
		private float _characterMovementDistance;

		[SerializeField]
		private RectTransform _mainButton;

		[SerializeField]
		private float _buttonEnterAngle;

		[SerializeField]
		private float _buttonMovementDistance;

		[SerializeField]
		private float _buttonShakeAngle;

		[SerializeField]
		private float _animSpeed;

		[SerializeField]
		[Range(0f, 1f)]
		private float _characterAnimOverlap;

		[SerializeField]
		private float _shakeSpeed;

		[SerializeField]
		private float _startDelay;

		[SerializeField]
		private float _buttonShowDelay;

		[SerializeField]
		private float _shakeRepeatDelay;

		[SerializeField]
		private DynamicButton _menuOpenButton;

		private Vector3[] _characterSpawnPoints;

		public Action OnOpenMenu;

		protected override void Awake()
		{
			base.Awake();
			_characterSpawnPoints = new Vector3[_characterTransforms.Length];
			for (int i = 0; i < _characterTransforms.Length; i++)
			{
				_characterSpawnPoints[i] = _characterTransforms[i].localPosition;
			}
		}

		private void Start()
		{
			_menuOpenButton.onPrimaryDown.AddListener(OnOpenMenuPressed);
		}

		private void OnEnable()
		{
			StopAllCoroutines();
			ResetCharacterTransforms();
			for (int i = 0; i < _characterTransforms.Length; i++)
			{
				MoveCharacterTransform(i, -1f);
			}
			_mainButton.localPosition = Vector3.up * _buttonMovementDistance;
			_mainButton.localRotation = Quaternion.Euler(0f, 0f, _buttonEnterAngle);
			_mainButton.parent.SetAsFirstSibling();
			StartCoroutine(OpeningAnimation());
			if (GetComponent<RectTransform>().anchoredPosition.x == _rootTargetX)
			{
				StartCoroutine(SlideIn());
			}
		}

		private void ResetCharacterTransforms()
		{
			for (int i = 0; i < _characterTransforms.Length; i++)
			{
				_characterTransforms[i].localPosition = _characterSpawnPoints[i];
			}
		}

		private void MoveCharacterTransform(int index, float distance)
		{
			_characterTransforms[index].localPosition += new Vector3(_characterMovementDistance * Mathf.Sin(_characterMovementAngles[index] * ((float)Math.PI / 180f)), _characterMovementDistance * Mathf.Cos(_characterMovementAngles[index] * ((float)Math.PI / 180f)), 0f) * distance;
		}

		private IEnumerator OpeningAnimation()
		{
			yield return new WaitForSecondsRealtime(_startDelay);
			TweenAnimationStatus status = new TweenAnimationStatus
			{
				Progress = 1f
			};
			for (int i = 0; i < _characterTransforms.Length; i++)
			{
				status = Animate(EasingsUtils.Functions.BackEaseInOut, _characterTransforms[i], _characterSpawnPoints[i], Quaternion.identity, 1f / _animSpeed);
				while (status.Progress < 1f - _characterAnimOverlap)
				{
					yield return _frameWait;
				}
			}
			yield return new WaitForSecondsRealtime(_buttonShowDelay);
			status = Animate(EasingsUtils.Functions.BackEaseInOut, _mainButton, Vector3.zero, Quaternion.identity, 1f / _animSpeed);
			while (!status.Finished)
			{
				yield return _frameWait;
			}
			StartCoroutine(IdleShakeAnimation());
		}

		private IEnumerator IdleShakeAnimation()
		{
			_mainButton.parent.SetAsLastSibling();
			WaitForSecondsRealtime shakeWait = new WaitForSecondsRealtime(_shakeRepeatDelay);
			while (true)
			{
				yield return shakeWait;
				TweenAnimationStatus status = Animate(EasingsUtils.Functions.QuadraticEaseInOut, _mainButton, Vector3.zero, Quaternion.Euler(0f, 0f, _buttonShakeAngle), 1f / _shakeSpeed);
				while (!status.Finished)
				{
					yield return _frameWait;
				}
				status = Animate(EasingsUtils.Functions.QuadraticEaseInOut, _mainButton, Vector3.zero, Quaternion.Euler(0f, 0f, 0f - _buttonShakeAngle), 2f / _shakeSpeed);
				while (!status.Finished)
				{
					yield return _frameWait;
				}
				status = Animate(EasingsUtils.Functions.QuadraticEaseInOut, _mainButton, Vector3.zero, Quaternion.identity, 1f / _shakeSpeed);
				while (!status.Finished)
				{
					yield return _frameWait;
				}
				_mainButton.localRotation = Quaternion.identity;
			}
		}

		private IEnumerator SlideIn()
		{
			_animationRoot.anchoredPosition = new Vector2(_rootStartX - _rootTargetX, _animationRoot.anchoredPosition.y);
			yield return new WaitForSecondsRealtime(_rootAnimStartDelay);
			TweenAnimationStatus status = Animate(EasingsUtils.Functions.QuadraticEaseInOut, _animationRoot, new Vector3(_rootBounceX - _rootTargetX, _animationRoot.anchoredPosition.y, 0f), Quaternion.identity, _rootAnimBounceTime, replaceExisting: false, AnimationSpace.Anchored);
			while (!status.Finished)
			{
				yield return _frameWait;
			}
			status = Animate(EasingsUtils.Functions.QuadraticEaseInOut, _animationRoot, new Vector3(0f, _animationRoot.anchoredPosition.y, 0f), Quaternion.identity, _rootAnimEndTime, replaceExisting: false, AnimationSpace.Anchored);
			while (!status.Finished)
			{
				yield return _frameWait;
			}
		}

		private void OnDestroy()
		{
			_menuOpenButton.onPrimaryDown.RemoveListener(OnOpenMenuPressed);
		}

		private void OnOpenMenuPressed()
		{
			OnOpenMenu.InvokeSafe();
		}
	}
}

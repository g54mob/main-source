using System;
using System.Collections;
using System.Collections.Generic;
using CTS.Core;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class MapSelection : MonoBehaviour
	{
		private struct LightData
		{
			public Light light;

			public float initialIntensity;

			public LightData(Light light, float initialIntensity)
			{
				this.light = light;
				this.initialIntensity = initialIntensity;
			}
		}

		private Vector3 _pos1;

		private Vector3 _pos2;

		private bool _isSelected;

		private Animator _animator;

		[SerializeField]
		private bool _needAnim;

		[SerializeField]
		private GameObject _visual;

		[SerializeField]
		private Transform _panelPopUp;

		[SerializeField]
		private Vector3 _RotateForCamera;

		[SerializeField]
		private Vector3 _offsetVectorPlacement;

		private Quaternion _rotateBase;

		private readonly List<LightData> _lightDataList = new List<LightData>();

		[SerializeField]
		private GameObject _lightingParent;

		[SerializeField]
		[Foldout("Sound")]
		private AudioAsset _zoomSound;

		[SerializeField]
		[Foldout("Sound")]
		private AudioAsset _unzoomSound;

		[SerializeField]
		[Foldout("Sound")]
		private AudioAsset _hoverSound;

		[SerializeField]
		[Foldout("Sound")]
		private AudioAsset _exitHoverSound;

		[SerializeField]
		[Foldout("VFX Apparition")]
		private ParticleSystem _particleSystem;

		[SerializeField]
		[Foldout("VFX Apparition")]
		private float _timeDelayAfterLoadingScreen;

		[SerializeField]
		[Foldout("VFX Apparition")]
		private AnimationClip _apparitionClip;

		[SerializeField]
		[Foldout("Sound")]
		private AudioAsset _fallOfPiece;

		private bool _canBeSelected = true;

		[field: SerializeField]
		public MapInfoSO MapInfo { get; private set; }

		public ManagerMapSelection ManagerScript { get; private set; }

		[field: SerializeField]
		public AudioAsset ZoneAmbiance { get; private set; }

		public bool CanBeSelected()
		{
			return _canBeSelected;
		}

		public bool IsSelected()
		{
			return _isSelected;
		}

		[Button(null, EButtonEnableMode.Always)]
		public void WinStars()
		{
			MapInfo.SetScoreInProfile(1);
		}

		private void ActiveVFX()
		{
			_particleSystem.Play();
			MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_fallOfPiece);
		}

		private void Awake()
		{
			ManagerMapSelection.StartMap = (Action<ManagerMapSelection>)Delegate.Combine(ManagerMapSelection.StartMap, new Action<ManagerMapSelection>(Subscribe));
			_animator = GetComponent<Animator>();
			_pos1 = base.transform.position;
			_rotateBase = base.transform.rotation;
			if (CTSSingleton<ProfileManager>.TryGetInstance(out var outInstance) && outInstance.CurrentProfile is CareerProfile careerProfile)
			{
				_canBeSelected = !careerProfile.IsLevelLocked(MapInfo);
				if (_canBeSelected)
				{
					if (!careerProfile.HasLevelBeenPlayedOnce(MapInfo) && _needAnim && !careerProfile.HasAnimLevelPlayed(MapInfo))
					{
						_visual.SetActive(value: false);
						LoadingScreen.EndLoadingScreen += ApparitionAnim;
						careerProfile.SetAnimPlayed(MapInfo, animPlayed: true);
					}
				}
				else
				{
					_visual.SetActive(value: false);
				}
			}
			InitializeLigth();
			LockSelectionOptionMenu.LockSelection = (Action)Delegate.Combine(LockSelectionOptionMenu.LockSelection, new Action(PauseMenu));
			LockSelectionOptionMenu.UnlockSelection = (Action)Delegate.Combine(LockSelectionOptionMenu.UnlockSelection, new Action(UnpauseMenu));
			UI_EndDemo.CloseEndScreen += UnpauseMenu;
			UI_EndDemo.OpenEndScreen += PauseMenu;
		}

		private void OnDestroy()
		{
			ManagerMapSelection.StartMap = (Action<ManagerMapSelection>)Delegate.Remove(ManagerMapSelection.StartMap, new Action<ManagerMapSelection>(Subscribe));
			LoadingScreen.EndLoadingScreen -= LaunchAnimApparition;
			LockSelectionOptionMenu.LockSelection = (Action)Delegate.Remove(LockSelectionOptionMenu.LockSelection, new Action(PauseMenu));
			LockSelectionOptionMenu.UnlockSelection = (Action)Delegate.Remove(LockSelectionOptionMenu.UnlockSelection, new Action(UnpauseMenu));
			UI_EndDemo.CloseEndScreen -= UnpauseMenu;
			UI_EndDemo.OpenEndScreen -= PauseMenu;
		}

		[Button(null, EButtonEnableMode.Always)]
		public void LaunchAnimApparition()
		{
			StartCoroutine(LaunchApparitionAnim());
		}

		public void ApparitionAnim()
		{
			StartCoroutine(LaunchApparitionAnim());
		}

		private IEnumerator LaunchApparitionAnim()
		{
			LoadingScreen.EndLoadingScreen -= ApparitionAnim;
			_canBeSelected = false;
			yield return new WaitForSecondsRealtime(_timeDelayAfterLoadingScreen);
			_visual.SetActive(value: true);
			_animator.SetTrigger("Discovery");
			yield return new WaitForSecondsRealtime(_apparitionClip.length);
			_canBeSelected = true;
		}

		public void Animgoing(bool Anim)
		{
			_canBeSelected = Anim;
		}

		private void UnpauseMenu()
		{
			_isSelected = false;
		}

		private void PauseMenu()
		{
			_isSelected = true;
		}

		private void Subscribe(ManagerMapSelection managerMapSelection)
		{
			ManagerScript = managerMapSelection;
		}

		private float SpeedToUseAnimation()
		{
			float length = _animator.GetCurrentAnimatorStateInfo(0).length;
			_ = _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
			return length / ManagerScript.TransitionTime;
		}

		public void Selection()
		{
			_animator.SetTrigger("Hover");
			_animator.ResetTrigger("UnHover");
			ManagerScript.ShowInfoCard(_panelPopUp, MapInfo);
			MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_hoverSound);
		}

		public void Deselection()
		{
			_animator.SetTrigger("UnHover");
			_animator.ResetTrigger("Hover");
			ManagerScript.HideInfoCard();
			MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_exitHoverSound);
		}

		public void UserClick()
		{
			ManagerScript.PosForTheFocus.localPosition += _offsetVectorPlacement;
			_pos2 = ManagerScript.PosForTheFocus.position;
			_animator.SetTrigger("Selection");
			_animator.ResetTrigger("Hover");
			_animator.ResetTrigger("UnHover");
			_isSelected = true;
			ManagerScript.SomethingSelected(_isSelected);
			if ((bool)ZoneAmbiance)
			{
				ManagerScript.ActiveAmbianceSound(ZoneAmbiance);
			}
			_animator.applyRootMotion = true;
			StartCoroutine(FocusObject(_pos2, ManagerScript.TransitionTime));
			MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_zoomSound);
		}

		public void ReturnToPos()
		{
			MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_unzoomSound);
			StopAllCoroutines();
			StartCoroutine(DisfocusObject(_pos1, ManagerScript.TransitionTime));
			ManagerScript.PosForTheFocus.localPosition -= _offsetVectorPlacement;
		}

		private void InitializeLigth()
		{
			Light[] componentsInChildren = _lightingParent.GetComponentsInChildren<Light>();
			foreach (Light light in componentsInChildren)
			{
				_lightDataList.Add(new LightData(light, light.intensity));
				light.intensity = 0f;
			}
		}

		private IEnumerator FocusObject(Vector3 end, float duration)
		{
			ManagerScript.FocusObject(duration);
			_animator.SetFloat("Speed", 1f);
			base.transform.DOKill();
			base.transform.DORotate(_RotateForCamera, duration).SetUpdate(isIndependentUpdate: true).SetEase(Ease.InOutCubic);
			base.transform.DOMoveX(end.x, duration).SetUpdate(isIndependentUpdate: true).SetEase(Ease.InOutCubic);
			base.transform.DOMoveZ(end.z, duration).SetUpdate(isIndependentUpdate: true).SetEase(Ease.InOutCubic);
			yield return base.transform.DOMoveY(end.y, duration).SetUpdate(isIndependentUpdate: true).SetEase(Ease.OutSine)
				.WaitForCompletion();
			_animator.SetBool("TurnAround", value: true);
			_lightingParent.SetActive(value: true);
			StartCoroutine(OnLight(duration, isForOnLight: true));
			ManagerScript.ActiveInformationMapCanvas(this, MapInfo);
		}

		private IEnumerator DisfocusObject(Vector3 end, float duration)
		{
			_animator.SetFloat("Speed", SpeedToUseAnimation());
			_animator.SetBool("TurnAround", value: false);
			ManagerScript.Disfocus(duration);
			ManagerScript.DesactiveInformationMap();
			StartCoroutine(OnLight(duration / 4f, isForOnLight: false));
			base.transform.DOKill();
			base.transform.DORotateQuaternion(_rotateBase, duration).SetUpdate(isIndependentUpdate: true).SetEase(Ease.InOutCubic);
			base.transform.DOMoveX(end.x, duration).SetUpdate(isIndependentUpdate: true).SetEase(Ease.InOutCubic);
			base.transform.DOMoveZ(end.z, duration).SetUpdate(isIndependentUpdate: true).SetEase(Ease.InOutCubic);
			yield return base.transform.DOMoveY(end.y, duration).SetUpdate(isIndependentUpdate: true).SetEase(Ease.InQuad)
				.WaitForCompletion();
			_isSelected = false;
			ManagerScript.SomethingSelected(_isSelected);
			_animator.applyRootMotion = false;
			_animator.ResetTrigger("Selection");
			_animator.ResetTrigger("Deselection");
		}

		private IEnumerator LerpBetweenPos(Vector3 start, Vector3 end, float duration, Quaternion startRotate, Quaternion endRotate)
		{
			float time = 0f;
			while (time < duration)
			{
				float t = ManagerScript.TimeCurve.Evaluate(time / duration);
				base.transform.rotation = Quaternion.Lerp(startRotate, endRotate, t);
				base.transform.position = Vector3.Lerp(start, end, t);
				time += Time.deltaTime;
				yield return null;
			}
			base.transform.rotation = endRotate;
			base.transform.position = end;
		}

		private IEnumerator OnLight(float duration, bool isForOnLight)
		{
			float time = 0f;
			while (time < duration)
			{
				float t = time / duration;
				if (isForOnLight)
				{
					foreach (LightData lightData in _lightDataList)
					{
						lightData.light.intensity = Mathf.Lerp(0f, lightData.initialIntensity, t);
					}
				}
				else
				{
					foreach (LightData lightData2 in _lightDataList)
					{
						lightData2.light.intensity = Mathf.Lerp(lightData2.initialIntensity, 0f, t);
					}
				}
				time += Time.deltaTime;
				yield return null;
			}
		}
	}
}

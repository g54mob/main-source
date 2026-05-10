using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class CrystalFinder : MonoBehaviour, ISelectable, ISavable
{
	[SerializeField]
	private List<Cost> activationCost;

	[SerializeField]
	private GameObject crystalArrow;

	[SerializeField]
	private GameObject ring;

	[SerializeField]
	private GameObject smallCrystals;

	[SerializeField]
	private GameObject crystalStone;

	[SerializeField]
	private GameObject lightsContainer;

	[Header("Particle Systems")]
	[SerializeField]
	private ParticleSystem explosionPS;

	[SerializeField]
	private ParticleSystem crystalGlowPS;

	[SerializeField]
	private ParticleSystem crystalDisappear;

	[SerializeField]
	private ParticleSystem ringDisappear;

	[Header("Sounds")]
	[SerializeField]
	private AudioData activationSound;

	[SerializeField]
	private AudioData spinUpSound;

	[SerializeField]
	private AudioData explosionSound;

	private Vector3 crystalStoneStartPosition;

	private CrystalAltar trackedAltar;

	[Savable("trackedAltarPosition", true, false)]
	private Vector3 trackedAltarPosition = Vector3.zero;

	private Coroutine activationCoroutine;

	private float crystalsEmission = 10f;

	private float crystalStoneHeight = 0.1f;

	private float crystalStoneFloatingDistance = 0.05f;

	private float crystalStoneFloatingTime = 3f;

	private float crystalStoneRotationTime = 30f;

	private float ringScaleTime = 0.2f;

	private float ringFloatingTime = 3f;

	private float ringFloatingDistance = 0.05f;

	private float crystalArrowRotationTime = 5f;

	public List<Cost> ActivationCost => activationCost;

	public CrystalAltar TrackedAltar
	{
		get
		{
			return trackedAltar;
		}
		private set
		{
			trackedAltar = value;
			if ((bool)trackedAltar)
			{
				trackedAltar.IsBeingTracked = true;
				trackedAltar.onLootAltar += OnLootAltar;
				trackedAltarPosition = trackedAltar.transform.position;
			}
		}
	}

	public void ActivateCrystalFinder()
	{
		TrackedAltar = GetNearestAvailableCrystalAltar();
		if ((bool)TrackedAltar && LTFunctionLibrary.GetLTGameManager().PayCost(ActivationCost))
		{
			this.StartCoroutineCheckingVar(ActivationCoroutine(), ref activationCoroutine);
		}
	}

	public void DeactivateCrystalFinder()
	{
		crystalDisappear.transform.rotation = crystalArrow.transform.rotation;
		crystalDisappear.Play();
		ringDisappear.Play();
		DOTween.Kill(ring.transform);
		DOTween.Kill(crystalArrow.transform);
		ring.SetActive(value: false);
		crystalArrow.SetActive(value: false);
		Light[] componentsInChildren = lightsContainer.GetComponentsInChildren<Light>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].DOIntensity(0f, 1f);
		}
	}

	private IEnumerator ActivationCoroutine()
	{
		float num = 0.5f;
		float crystalsEmissionTime = 2f;
		float crystalStoneHeightTime = 3f;
		float crystalStoneSpeedUpTime = 4f;
		crystalStoneStartPosition = crystalStone.transform.position;
		AudioSystem.Instance.PlaySound3D(activationSound, base.transform.position, AudioSystem.EAudioMixerGroup.SFX, AudioRolloffMode.Custom, 1f, 50f, null, 0f, 0f, loop: false, num - 0.15f, AudioSystem.EAudioPriority.High);
		yield return new WaitForSeconds(num);
		smallCrystals.GetComponent<Renderer>().material.DOFloat(crystalsEmission, "_EmissionIntensity", crystalsEmissionTime).SetEase(Ease.OutSine);
		crystalStone.transform.DOMoveY(crystalStone.transform.position.y + crystalStoneHeight, crystalStoneHeightTime).SetEase(Ease.OutCubic);
		DOVirtual.DelayedCall(1.9f, delegate
		{
			AudioSystem.Instance.PlaySound3D(spinUpSound, crystalStone.transform.position, AudioSystem.EAudioMixerGroup.SFX, AudioRolloffMode.Custom, 1f, 50f, null, 0f, 0f, loop: false, 0f, AudioSystem.EAudioPriority.High);
		}, ignoreTimeScale: false);
		DOVirtual.DelayedCall(3.85f, delegate
		{
			AudioSystem.Instance.PlaySound3D(explosionSound, crystalStone.transform.position, AudioSystem.EAudioMixerGroup.SFX, AudioRolloffMode.Custom, 1f, 50f, null, 0f, 0f, loop: false, 0f, AudioSystem.EAudioPriority.High);
		}, ignoreTimeScale: false);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = crystalStone.transform.DORotate(Vector3.up * 360f * 4f, crystalStoneSpeedUpTime, RotateMode.WorldAxisAdd).SetEase(Ease.InQuart);
		tweenerCore.onComplete = (TweenCallback)Delegate.Combine(tweenerCore.onComplete, (TweenCallback)delegate
		{
			crystalStone.transform.DOMoveY(crystalStone.transform.position.y - crystalStoneFloatingDistance, crystalStoneFloatingTime).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
			crystalStone.transform.DORotate(Vector3.up * 360f, crystalStoneRotationTime, RotateMode.WorldAxisAdd).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
			ring.SetActive(value: true);
			ring.transform.localScale = Vector3.zero;
			ring.transform.DOScale(Vector3.one, ringScaleTime).SetEase(Ease.OutElastic);
			ring.transform.DOMoveY(ring.transform.position.y - ringFloatingDistance, ringFloatingTime).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo)
				.SetDelay(1.5f);
			Vector3 position = TrackedAltar.transform.position;
			position.y = crystalArrow.transform.position.y;
			crystalArrow.SetActive(value: true);
			crystalArrow.transform.localScale = Vector3.zero;
			crystalArrow.transform.rotation = Quaternion.LookRotation(position - crystalArrow.transform.position);
			crystalArrow.transform.DOScale(Vector3.one, ringScaleTime).SetEase(Ease.OutElastic).onComplete = delegate
			{
				crystalArrow.transform.DOMoveY(crystalArrow.transform.position.y - ringFloatingDistance, ringFloatingTime).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo)
					.SetDelay(3f);
				crystalArrow.transform.DOLocalRotate(Vector3.forward * 360f, crystalArrowRotationTime, RotateMode.LocalAxisAdd).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
				crystalGlowPS.Play();
			};
			explosionPS.Play();
			lightsContainer.SetActive(value: true);
		});
		activationCoroutine = null;
	}

	private IEnumerator LoadCrystalFinderCoroutine()
	{
		yield return null;
		TrackedAltar = LTFunctionLibrary.GetLTLevelController().Grid.GetGridCell(trackedAltarPosition).BuiltObject.GetComponent<CrystalAltar>();
		smallCrystals.GetComponent<Renderer>().material.SetFloat("_EmissionIntensity", crystalsEmission);
		crystalStone.transform.position = crystalStone.transform.position + Vector3.up * crystalStoneHeight;
		crystalStone.transform.DOMoveY(crystalStone.transform.position.y - crystalStoneFloatingDistance, crystalStoneFloatingTime).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
		crystalStone.transform.DORotate(Vector3.up * 360f, crystalStoneRotationTime, RotateMode.WorldAxisAdd).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
		if (!TrackedAltar.AlreadyUsed)
		{
			ring.SetActive(value: true);
			ring.transform.localScale = Vector3.zero;
			ring.transform.DOScale(Vector3.one, ringScaleTime).SetEase(Ease.OutElastic);
			ring.transform.DOMoveY(ring.transform.position.y - ringFloatingDistance, ringFloatingTime).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo)
				.SetDelay(1.5f);
			Vector3 position = TrackedAltar.transform.position;
			position.y = crystalArrow.transform.position.y;
			crystalArrow.SetActive(value: true);
			crystalArrow.transform.localScale = Vector3.one;
			crystalArrow.transform.rotation = Quaternion.LookRotation(position - crystalArrow.transform.position);
			crystalArrow.transform.DOMoveY(crystalArrow.transform.position.y - ringFloatingDistance, ringFloatingTime).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo)
				.SetDelay(3f);
			crystalArrow.transform.DOLocalRotate(Vector3.forward * 360f, crystalArrowRotationTime, RotateMode.LocalAxisAdd).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
			crystalGlowPS.Play();
			lightsContainer.SetActive(value: true);
		}
	}

	public CrystalAltar GetNearestAvailableCrystalAltar()
	{
		CrystalAltar result = null;
		float num = float.MaxValue;
		CrystalAltar[] crystalAltars = LTFunctionLibrary.GetLTLevelController().CrystalAltars;
		foreach (CrystalAltar crystalAltar in crystalAltars)
		{
			if (!crystalAltar.GetComponent<PlacementComponent>().IsVisible() && !crystalAltar.IsBeingTracked)
			{
				float sqrMagnitude = (crystalAltar.transform.position - base.transform.position).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					result = crystalAltar;
				}
			}
		}
		return result;
	}

	private void OnLootAltar()
	{
		DeactivateCrystalFinder();
	}

	public void Deselect()
	{
	}

	public void Select()
	{
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		if (hasLoadedSomething && (Vector3)data["trackedAltarPosition"] != Vector3.zero)
		{
			StartCoroutine(LoadCrystalFinderCoroutine());
		}
	}
}

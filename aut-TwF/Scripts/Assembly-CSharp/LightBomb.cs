using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using SmoothShakeFree;
using UnityEngine;

public class LightBomb : GameplayObject, ISelectable
{
	[Header("Explosion aniamtion")]
	[SerializeField]
	private GameObject bombObject;

	[SerializeField]
	private GameObject gearObject;

	[SerializeField]
	private Renderer crystalsRenderer;

	[SerializeField]
	private GameObject explosionVFX;

	[SerializeField]
	[Tooltip("Radio de base que ocupa el VFX, para tener en cuenta a la hora de escalarlo dependiendo del range de la bomba")]
	private float explosionVFXBaseRadius = 3f;

	[SerializeField]
	private SmoothShakeFreePreset shakePrset;

	[SerializeField]
	private AudioData explosionSound;

	[Header("UI")]
	[SerializeField]
	private ReachableSourceIndicator reachableSourceIndicatorPrefab;

	private List<ReachableSourceIndicator> reachableSourceIndicators;

	private float explosionRadius = 1f;

	private PlacementComponent placementComponent;

	private StatsComponent statsComponent;

	private Coroutine selectionCoroutine;

	private void Awake()
	{
		placementComponent = GetComponent<PlacementComponent>();
		statsComponent = GetComponent<StatsComponent>();
	}

	private void Start()
	{
		explosionRadius = statsComponent.GetStat(EStats.Range);
		UpdateExplosionRadius();
		if (placementComponent.IsPlaced)
		{
			OnPlace(placementComponent);
		}
		else
		{
			placementComponent.onPlace += OnPlace;
		}
	}

	private void OnPlace(PlacementComponent component)
	{
		UpdateExplosionRadius();
		StartCoroutine(ExplodeCoroutine());
	}

	public void Select()
	{
		reachableSourceIndicators = new List<ReachableSourceIndicator>();
		this.StartCoroutineCheckingVar(SelectionCoroutine(), ref selectionCoroutine);
	}

	public void Deselect()
	{
		this.StopCoroutineCheckingVar(ref selectionCoroutine);
		LTFunctionLibrary.GetLTGameManager().HideRangeIndicator();
		reachableSourceIndicators.ForEach(delegate(ReachableSourceIndicator x)
		{
			Object.Destroy(x.gameObject);
		});
	}

	private void UpdateExplosionRadius()
	{
		float num = statsComponent.GetStat(EStats.Range);
		if (!placementComponent.IsPlaced)
		{
			List<GameplayEffectData> gameplayEffectDatasToApplyToBuilding = LTFunctionLibrary.GetGameplayEffectDatasToApplyToBuilding(GetComponent<GameplayObject>().ObjectData);
			if (gameplayEffectDatasToApplyToBuilding != null)
			{
				foreach (GameplayEffectData item in gameplayEffectDatasToApplyToBuilding)
				{
					if (item is GE_StatModifierData)
					{
						GE_StatModifierData gE_StatModifierData = item as GE_StatModifierData;
						if (gE_StatModifierData.Stat == EStats.Range)
						{
							num += gE_StatModifierData.StatValue;
						}
					}
				}
			}
		}
		explosionRadius = num;
	}

	private IEnumerator SelectionCoroutine()
	{
		while (true)
		{
			LTFunctionLibrary.GetLTGameManager().ShowCircleRangeIndicator(placementComponent.GetCenter(), explosionRadius, 0f);
			if (!LTFunctionLibrary.GetFogOfWarController().IsPositionVisible(base.transform.position))
			{
				for (int num = reachableSourceIndicators.Count - 1; num >= 0; num--)
				{
					Object.Destroy(reachableSourceIndicators[num].gameObject);
					reachableSourceIndicators.RemoveAt(num);
				}
			}
			else
			{
				List<Collider> list = FunctionLibrary.OverlapSphereCheckingTag(placementComponent.GetCenter(), explosionRadius, LayerMask.GetMask("Gameplay"), "Source");
				for (int num2 = reachableSourceIndicators.Count - 1; num2 >= 0; num2--)
				{
					bool flag = false;
					foreach (Collider item in list)
					{
						if ((bool)reachableSourceIndicators[num2].Source && item.GetComponentInParent<Source>().gameObject == reachableSourceIndicators[num2].Source.gameObject)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						Object.Destroy(reachableSourceIndicators[num2].gameObject);
						reachableSourceIndicators.RemoveAt(num2);
					}
				}
				foreach (Collider item2 in list)
				{
					Source componentInParent = item2.GetComponentInParent<Source>();
					bool flag2 = false;
					foreach (ReachableSourceIndicator reachableSourceIndicator in reachableSourceIndicators)
					{
						if (reachableSourceIndicator.Source.gameObject == componentInParent.gameObject)
						{
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						ReachableSourceIndicator component = Object.Instantiate(reachableSourceIndicatorPrefab.gameObject, base.transform).GetComponent<ReachableSourceIndicator>();
						component.Setup(placementComponent, componentInParent);
						reachableSourceIndicators.Add(component);
					}
				}
			}
			yield return null;
		}
	}

	private IEnumerator ExplodeCoroutine()
	{
		float num = 1.5f;
		Material material = crystalsRenderer.material;
		float endValue = 40f;
		AudioSystem.Instance.PlaySound3D(explosionSound, base.transform.position, AudioSystem.EAudioMixerGroup.SFX, AudioRolloffMode.Custom, 1f, 50f, null, 0f, 0f, loop: false, 0f, AudioSystem.EAudioPriority.High);
		gearObject.transform.DORotate(new Vector3(0f, 500f, 0f), num, RotateMode.WorldAxisAdd).SetEase(Ease.InCubic);
		bombObject.transform.DOScale(new Vector3(0.95f, 0.95f, 0.95f), num * 0.5f).SetEase(Ease.OutSine);
		bombObject.transform.DOScale(new Vector3(1.1f, 1.05f, 1.1f), num * 0.5f).SetEase(Ease.InSine).SetDelay(num * 0.5f);
		Sequence sequence = DOTween.Sequence();
		int num2 = 3;
		float num3 = num * 0.5f;
		float delay = num * 0.5f;
		float duration = num3 / (float)num2;
		for (int i = 1; i <= num2; i++)
		{
			float num4 = (float)i / (float)num2 * 0.02f;
			sequence.Append(bombObject.transform.DOShakePosition(duration, new Vector3(1f, 0f, 1f) * num4, 30, 90f, snapping: false, fadeOut: false));
		}
		sequence.SetDelay(delay).Play();
		material.DOFloat(endValue, "_EmissionIntensity", num * 0.5f).SetEase(Ease.InSine).SetDelay(num * 0.5f);
		yield return new WaitForSeconds(num);
		Object.Instantiate(explosionVFX, base.transform.position, base.transform.rotation, null).transform.localScale = Vector3.one * (explosionRadius / explosionVFXBaseRadius);
		LTFunctionLibrary.GetLTPlayerController().ShakeCameraFromPosition(base.transform.position, 1f, shakePrset);
		DestroyNearbySources();
		placementComponent.Unplace();
		LTFunctionLibrary.GetPlayerData().RemovePlayerBuilding(this);
		Object.Destroy(base.gameObject);
	}

	private void DestroyNearbySources()
	{
		Collider[] array = Physics.OverlapSphere(placementComponent.GetCenter(), explosionRadius, LayerMask.GetMask("Gameplay"));
		for (int i = 0; i < array.Length; i++)
		{
			Source componentInParent = array[i].GetComponentInParent<Source>();
			if ((object)componentInParent != null && componentInParent.CompareTag("Source"))
			{
				componentInParent?.DestroySource();
			}
		}
	}
}

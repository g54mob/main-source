using System.Collections;
using DG.Tweening;
using SmoothShakeFree;
using UnityEngine;

public class Beacon_03 : ConeBeacon
{
	[Header("Activation animation")]
	[SerializeField]
	private GameObject coneAreaVFXPrefab;

	[SerializeField]
	private float revealAreaTime = 2.25f;

	[SerializeField]
	private float coneAreaVFXHeight;

	[SerializeField]
	private float coneAreaVFXTime = 3f;

	[SerializeField]
	private float coneEdgeWidthTime = 0.5f;

	[SerializeField]
	private ParticleSystem sparksPS;

	[SerializeField]
	private SmoothShakeFreePreset shakePrest;

	private Animator animator;

	private Coroutine revealAreaCoroutine;

	protected override void Awake()
	{
		base.Awake();
		animator = GetComponent<Animator>();
	}

	protected override void OnPlace(PlacementComponent component)
	{
		StartCoroutine(ActivationAnimationCoroutine());
	}

	private IEnumerator ActivationAnimationCoroutine()
	{
		yield return null;
		if (hasBeenActivated)
		{
			animator.Play("Idle");
			Object.Instantiate(fowAreaPrefab, placementComponent.GetCenter() + Vector3.up * 5f, base.transform.rotation, base.transform).GetComponent<MeshRenderer>().material.SetFloat("_Cutout", 0f);
			animator.cullingMode = AnimatorCullingMode.CullCompletely;
			FogOfWarController.instance.UpdateFogOfWar();
		}
		else
		{
			hasBeenActivated = true;
			animator.Play("WarmUp");
		}
	}

	public void RevealArea()
	{
		this.StartCoroutineCheckingVar(RevealAreaCoroutine(), ref revealAreaCoroutine);
	}

	private IEnumerator RevealAreaCoroutine()
	{
		float value = 0.95f;
		float endValue = 0f;
		float timer = 0f;
		Material material = Object.Instantiate(fowAreaPrefab, placementComponent.GetCenter() + Vector3.up * 5f, base.transform.rotation, base.transform).GetComponent<MeshRenderer>().material;
		material.SetFloat("_Cutout", value);
		FogOfWarController.instance.UpdateFogOfWar();
		GameObject obj = Object.Instantiate(coneAreaVFXPrefab, base.transform.position + Vector3.up * coneAreaVFXHeight, base.transform.rotation);
		Material material2 = obj.GetComponent<MeshRenderer>().material;
		material2.GetFloat("_EdgeWidth");
		material2.SetFloat("_MaxDistance", 18f);
		material2.SetFloat("_EdgePosition", 0f);
		material.DOFloat(endValue, "_Cutout", revealAreaTime).SetEase(Ease.OutCubic);
		material2.DOFloat(1f, "_EdgePosition", coneAreaVFXTime).SetEase(Ease.OutCubic);
		material2.DOFloat(0f, "_EdgeWidth", coneEdgeWidthTime).SetDelay(coneAreaVFXTime - coneEdgeWidthTime).SetEase(Ease.OutSine);
		Object.Destroy(obj.gameObject, coneAreaVFXTime);
		sparksPS.Play();
		LTFunctionLibrary.GetLTPlayerController().ShakeCameraFromPosition(base.transform.position, 1f, shakePrest);
		while (timer <= revealAreaTime)
		{
			timer += Time.deltaTime;
			FogOfWarController.instance.UpdateFogOfWar(importantUpdate: false);
			yield return null;
		}
		FogOfWarController.instance.UpdateFogOfWar();
		yield return new WaitForSeconds(5f);
		animator.cullingMode = AnimatorCullingMode.CullCompletely;
		revealAreaCoroutine = null;
	}
}

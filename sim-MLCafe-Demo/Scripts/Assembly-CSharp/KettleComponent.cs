using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class KettleComponent : MonoBehaviour
{
	[SerializeField]
	private AnomalyTag defaultTag;

	[SerializeField]
	private MeshRenderer renderer;

	[SerializeField]
	private float cooldownDuration = 180f;

	[SerializeField]
	private GameObject vfx;

	[SerializeField]
	private ParticleSystem[] vfxs;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private UnityEvent<float, float> OnCooldownUpdate = new UnityEvent<float, float>();

	[SerializeField]
	private bool showHeatBar = true;

	private float heatAlpha;

	private float cooldown;

	private bool isHeating;

	private float heatUpDuration;

	private float heatUpTime;

	private ItemComponent itemComponent;

	private void Start()
	{
		itemComponent = GetComponent<ItemComponent>();
		itemComponent.OnRefill.AddListener(ColdRefill);
		cooldownDuration = 60 * GameModeManager.GetGameModeValue<int>("gm_item_kettle_heat_duration");
	}

	private void Update()
	{
		if (AnomalyTag.HasTag(itemComponent.item.tag.anomalyFlags, "Cold") || itemComponent.item.amount <= 0)
		{
			ParticleSystem[] array = vfxs;
			foreach (ParticleSystem particleSystem in array)
			{
				if (particleSystem.isPlaying)
				{
					particleSystem.Stop();
				}
			}
			if (!isHeating)
			{
				renderer.material.SetFloat("_GradientColorOpacity", 0f);
			}
		}
		else
		{
			ParticleSystem[] array = vfxs;
			foreach (ParticleSystem particleSystem2 in array)
			{
				if (!particleSystem2.isPlaying)
				{
					particleSystem2.Play();
				}
			}
		}
		if (isHeating)
		{
			heatAlpha = Mathf.InverseLerp(heatUpDuration, 0f, heatUpTime);
			if (heatUpTime > 0f)
			{
				heatUpTime -= Time.deltaTime;
			}
			else
			{
				heatUpTime = 0f;
			}
		}
		else
		{
			if (cooldown <= 0f)
			{
				StopAllCoroutines();
				cooldown = 0f;
				heatAlpha = 0f;
				itemComponent.item.tag = defaultTag;
			}
			heatAlpha = Mathf.InverseLerp(0f, cooldownDuration, cooldown);
		}
		OnCooldownUpdate.Invoke(cooldown, cooldownDuration);
		renderer.material.SetFloat("_GradientColorOpacity", heatAlpha);
		if (!showHeatBar)
		{
			return;
		}
		if (!MouseCursorInteraction.IsLookingAtObject(base.gameObject))
		{
			if (!MouseCursorInteraction.HasObjectInFocusComponent<KettleComponent>() || !MouseCursorInteraction.IsAnyObjectInFocus())
			{
				ProgressbarManager.GetHeatProgressBar().HideForce();
			}
			return;
		}
		ProgressbarManager.GetHeatProgressBar().ShowForced(heatAlpha);
		ProgressbarManager.GetHeatProgressBar().UpdateBar(heatAlpha, useLimit: false);
		InteractionDisplayComponent component = GetComponent<InteractionDisplayComponent>();
		if (component != null)
		{
			component.UpdateDuration(cooldown, cooldownDuration);
		}
	}

	public void PlayFillAnimation(Transform kettleTarget)
	{
		base.transform.localRotation = Quaternion.Euler(0f, 70f, 0f);
		animator.SetTrigger("Fill");
		TweenerManager.TweenTimeAction("FillUpCoffee", 3f, delegate
		{
			base.transform.localRotation = Quaternion.identity;
		});
	}

	public void HeatUp(float duration)
	{
		isHeating = true;
		heatUpTime = duration;
		heatUpDuration = duration;
	}

	public void FinishHeatUp()
	{
		isHeating = false;
		cooldown = cooldownDuration;
		StartCoroutine(Cooldown());
		TutorialManager.TryCheckSectionChecklistOption("Kettle_HeatUp", TutorialManager.TutorialState.MakeCoffee);
	}

	private void ColdRefill()
	{
		TutorialManager.TryCheckSectionChecklistOption("Kettle_FillUp", TutorialManager.TutorialState.MakeCoffee);
		cooldown = 0f;
		heatAlpha = Mathf.InverseLerp(heatUpDuration, 0f, heatUpTime);
		itemComponent.item.tag = defaultTag;
		InteractionDisplayComponent component = GetComponent<InteractionDisplayComponent>();
		if (component != null)
		{
			component.UpdateDuration(0f, 0f);
			component.HideInfo();
		}
	}

	private IEnumerator Cooldown()
	{
		WaitForSeconds delay = new WaitForSeconds(0.1f);
		while (cooldown > 0f)
		{
			cooldown -= 0.1f;
			yield return delay;
		}
	}
}

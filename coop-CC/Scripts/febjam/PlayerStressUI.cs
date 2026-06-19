using System.Collections;
using Aggro.Core;
using Aggro.Core.Networking;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStressUI : EntityBehaviourBase
{
	[Header("Expressions")]
	public Image stressExpressionImage;

	public Sprite[] stressExpressions;

	[Header("Stress pips")]
	public Image[] stressPips;

	public Image stressExpressionBG;

	public Color stressColor = new Color(1f, 1f, 1f, 1f);

	public Color stressFullColor = new Color(1f, 1f, 1f, 1f);

	public Color blankColor = new Color(1f, 1f, 1f, 1f);

	public Color flashColor = new Color(1f, 1f, 1f, 1f);

	public float stressShakeStrength = 1f;

	public EasingFunction.Ease pipAddInEase = EasingFunction.Ease.Linear;

	public EasingFunction.Ease pipAddOutEase = EasingFunction.Ease.Linear;

	public float pipAddTime = 0.5f;

	public float pipAddStrength = 2f;

	public EasingFunction.Ease pipRemoveInEase = EasingFunction.Ease.Linear;

	public EasingFunction.Ease pipRemoveOutEase = EasingFunction.Ease.Linear;

	public float pipRemoveTime = 0.5f;

	public float pipRemoveStrength = 2f;

	public float pipInactiveScale = 0.8f;

	public float pipActiveScale = 1f;

	public float pipCrashoutScale = 1.5f;

	private PlayerStress playerStress;

	private Material[] pipMaterials;

	private bool[] isStressed;

	protected override void OnEntityCreated()
	{
		pipMaterials = new Material[stressPips.Length];
		for (int i = 0; i < stressPips.Length; i++)
		{
			pipMaterials[i] = Object.Instantiate(stressPips[i].material);
			stressPips[i].material = pipMaterials[i];
			Image[] componentsInChildren = stressPips[i].GetComponentsInChildren<Image>();
			for (int j = 0; j < componentsInChildren.Length; j++)
			{
				componentsInChildren[j].material = pipMaterials[i];
			}
			pipMaterials[i].SetFloat("_seed", Random.Range(0f, 50f));
			stressPips[i].transform.localScale = Vector3.one * pipInactiveScale;
		}
		isStressed = new bool[stressPips.Length];
	}

	protected override void OnUpdatePresentation()
	{
		if (GameUtil.TryGetLocalPlayer(out var player))
		{
			playerStress = player.GetObject<PlayerStress>();
			PlayerColorManager playerColorManager = player.GetObject<PlayerColorManager>();
			stressExpressionBG.color = playerColorManager.playerColors[playerColorManager.activePlayerColorIndex].color;
			if (playerStress.crashingOut && !NetworkAggroManagerBase<ShiftManager>.instance.isTransitioning)
			{
				AggroInputManager.VibrateForFrame(VibrateStrength.Medium);
			}
		}
	}

	protected override void OnEntityDestroyed()
	{
		Material[] array = pipMaterials;
		for (int i = 0; i < array.Length; i++)
		{
			Object.Destroy(array[i]);
		}
	}

	private IEnumerator PipAddAnimationCo(Image pip)
	{
		float time = 0f;
		while (time < pipAddTime)
		{
			float num = time / pipAddTime;
			if (num <= 0.5f)
			{
				float t = EasingFunction.Evaluate(pipAddInEase, num * 2f);
				pip.color = Color.Lerp(blankColor, flashColor, t);
			}
			else
			{
				float t = EasingFunction.Evaluate(pipAddOutEase, 1f - (num - 0.5f) * 2f);
				pip.color = Color.Lerp(stressColor, flashColor, t);
			}
			time += Time.deltaTime;
			yield return null;
		}
	}

	private IEnumerator PipRemoveAnimationCo(Image pip)
	{
		float time = 0f;
		while (time < pipRemoveTime)
		{
			float num = time / pipRemoveTime;
			if (num <= 0.5f)
			{
				float t = EasingFunction.Evaluate(pipRemoveInEase, num * 2f);
				pip.color = Color.Lerp(stressColor, flashColor, t);
			}
			else
			{
				float t = EasingFunction.Evaluate(pipRemoveOutEase, 1f - (num - 0.5f) * 2f);
				pip.color = Color.Lerp(blankColor, flashColor, t);
			}
			time += Time.deltaTime;
			yield return null;
		}
	}
}

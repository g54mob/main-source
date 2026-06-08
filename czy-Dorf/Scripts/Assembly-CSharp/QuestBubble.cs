using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class QuestBubble : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public QuestBubble _003C_003E4__this;

		public bool animate;

		internal void _003CFlip_003Eb__0()
		{
			_003C_003E4__this.frontSideContainer.SetActive(value: false);
			ShortcutExtensions.DOColor(_003C_003E4__this.bubbleRenderer.materials[1], _003C_003E4__this.questBubbleNormalColor, "_FrontCol", animate ? 0.1f : 0f);
		}
	}

	[SerializeField]
	private GameObject frontSideContainer;

	[SerializeField]
	private Transform[] frontSideConditionAnchors;

	[SerializeField]
	private GameObject followQuestHint;

	[SerializeField]
	private GameObject backSideContainer;

	[SerializeField]
	private Transform[] backSideConditionAnchors;

	[SerializeField]
	private Color questBubbleNormalColor;

	[SerializeField]
	private Color questBubbleFulfilledColor;

	[SerializeField]
	private Color questBubbleUnfulfillableColor;

	[SerializeField]
	private GameObject crown;

	[SerializeField]
	private QuestUiComponentLibrary questComponentLibrary;

	private MeshRenderer bubbleRenderer;

	[SerializeField]
	private List<QuestElementIcon> frontSideElementIcons;

	[SerializeField]
	private List<QuestElementIcon> backSideElementIcons;

	private bool isOnFrontSide = true;

	private bool isSetup;

	private Tween wiggleAnimation;

	private void Awake()
	{
		bubbleRenderer = GetComponentInChildren<MeshRenderer>();
	}

	public void Setup(Quest quest, Quest followQuest)
	{
		foreach (Transform item in frontSideConditionAnchors[0])
		{
			Object.Destroy(item.gameObject);
		}
		foreach (Transform item2 in backSideConditionAnchors[0])
		{
			Object.Destroy(item2.gameObject);
		}
		frontSideElementIcons.Clear();
		backSideElementIcons.Clear();
		for (int i = 0; i < quest.conditions.Count; i++)
		{
			SetupConditionLabel(quest.conditions[i], i, frontSide: true);
		}
		backSideContainer.SetActive(followQuest);
		followQuestHint.gameObject.SetActive(followQuest);
		followQuestHint.GetComponentInChildren<MeshRenderer>(includeInactive: true).sharedMaterial = frontSideElementIcons[0].SharedMaterial;
		if ((bool)followQuest && followQuest.displayType == QuestDisplayType.Bubble)
		{
			backSideElementIcons = new List<QuestElementIcon>();
			Color color = frontSideElementIcons[0].SharedMaterial.GetColor("_FrontCol");
			color.a = 1f;
			for (int j = 0; j < followQuest.conditions.Count; j++)
			{
				SetupConditionLabel(followQuest.conditions[j], j, frontSide: false).SetTextColor(color);
			}
			followQuestHint.GetComponentInChildren<MeshRenderer>(includeInactive: true).sharedMaterial = frontSideElementIcons[0].SharedMaterial;
			Material[] sharedMaterials = bubbleRenderer.sharedMaterials;
			sharedMaterials[0] = frontSideElementIcons[0].SharedMaterial;
			bubbleRenderer.sharedMaterials = sharedMaterials;
		}
		isSetup = true;
	}

	private QuestElementIcon SetupConditionLabel(QuestCondition questCondition, int conditionIndex, bool frontSide)
	{
		QuestElementIcon questElementIcon = questComponentLibrary.CreateElementIcon(questCondition);
		if (frontSide)
		{
			frontSideElementIcons.Add(questElementIcon);
		}
		else
		{
			backSideElementIcons.Add(questElementIcon);
		}
		questElementIcon.transform.SetParent(frontSide ? frontSideConditionAnchors[conditionIndex] : backSideConditionAnchors[conditionIndex], worldPositionStays: false);
		questElementIcon.Setup(questCondition);
		return questElementIcon;
	}

	public void SetRendererLayer(int targetLayer)
	{
		Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].gameObject.layer = targetLayer;
		}
	}

	public void UpdateConditionStatus(int conditionIndex, FulfillmentStatus conditionFulfilled, int currentCount, int targetCount)
	{
		if (frontSideElementIcons.Count <= conditionIndex)
		{
			Debug.LogError($"{base.name} has only {frontSideElementIcons.Count} front side icons, wants to update icon nr.{conditionIndex}", this);
		}
		QuestElementIcon questElementIcon = frontSideElementIcons[conditionIndex];
		questElementIcon.UpdateLabelText(currentCount);
		questElementIcon.SetFulfillmentState(conditionFulfilled);
	}

	public void UpdateBubbleColor(FulfillmentStatus status)
	{
		if ((bool)bubbleRenderer)
		{
			Color endValue = questBubbleNormalColor;
			switch (status)
			{
			case FulfillmentStatus.Fulfilled:
				endValue = questBubbleFulfilledColor;
				break;
			case FulfillmentStatus.Unfulfillable:
				endValue = questBubbleUnfulfillableColor;
				break;
			}
			if (isOnFrontSide)
			{
				ShortcutExtensions.DOColor(bubbleRenderer.materials[1], endValue, "_FrontCol", 0.1f);
			}
			else if (backSideElementIcons.Count > 0)
			{
				ShortcutExtensions.DOColor(backSideElementIcons[0].Material, endValue, "_FrontCol", 0.1f);
			}
		}
	}

	public void Flip(bool animate = true)
	{
		_003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass22_0();
		CS_0024_003C_003E8__locals7._003C_003E4__this = this;
		CS_0024_003C_003E8__locals7.animate = animate;
		isOnFrontSide = !isOnFrontSide;
		TweenSettingsExtensions.OnComplete(TweenSettingsExtensions.SetEase(ShortcutExtensions.DOLocalRotate(base.transform, new Vector3(0f, 180f, 0f), CS_0024_003C_003E8__locals7.animate ? 2f : 0f), Ease.OutElastic), delegate
		{
			CS_0024_003C_003E8__locals7._003C_003E4__this.frontSideContainer.SetActive(value: false);
			ShortcutExtensions.DOColor(CS_0024_003C_003E8__locals7._003C_003E4__this.bubbleRenderer.materials[1], CS_0024_003C_003E8__locals7._003C_003E4__this.questBubbleNormalColor, "_FrontCol", CS_0024_003C_003E8__locals7.animate ? 0.1f : 0f);
		});
	}

	public void SetSessionQuest(SessionQuest sessionQuest)
	{
		crown.SetActive(sessionQuest.CurrentState == RewardState.Hidden);
	}
}

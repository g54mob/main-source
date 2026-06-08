using System.Collections.Generic;
using UnityEngine;

public class TransitionSlideHintState : IHintState
{
	private Vector3 startPos = Vector3.zero;

	private Vector3 endPos = Vector3.zero;

	private Vector3 currentPos = Vector3.zero;

	private Vector3 direction = Vector3.zero;

	private float timeToDest;

	private float distPerSecond;

	private float attentionChangeSpeedPerSecond;

	private int attentionRingIdx;

	private float distTillEnd;

	private float ringSpeed;

	private bool transitionOff;

	private bool ignoreAttentionRings;

	private List<float> ringList;

	private bool overrideHintColor;

	private Color hintColorOverride = Color.white;

	public HintStateTypeEnum StateType
	{
		get
		{
			return HintStateTypeEnum.Transition;
		}
	}

	private TransitionSlideHintState()
	{
	}

	public TransitionSlideHintState(Vector3 startPos, Vector3 endPos, float timeToDest)
		: this(startPos, endPos, timeToDest, false, Color.white)
	{
	}

	public TransitionSlideHintState(Vector3 startPos, Vector3 endPos, float timeToDest, bool overrideHintColor, Color hintColorOverride)
	{
		this.startPos = startPos;
		this.endPos = endPos;
		this.timeToDest = timeToDest;
		this.overrideHintColor = overrideHintColor;
		this.hintColorOverride = hintColorOverride;
		ringSpeed = timeToDest / 6f;
		if (this.startPos.x < this.endPos.x)
		{
			transitionOff = true;
		}
		if (!transitionOff)
		{
			ringList = new List<float>();
			ringList.Add(1f);
			ringList.Add(1f);
			ringList.Add(1f);
			ringList.Add(1f);
			ringList.Add(1f);
			ringList.Add(1f);
		}
		currentPos = startPos;
	}

	public void Start()
	{
		if (HintManager.HintPanelGameObject != null)
		{
			HintManager.HintPanelGameObject.SetActive(true);
		}
		if (HintManager.HintAttentionObject == null)
		{
			ignoreAttentionRings = true;
		}
		if (!ignoreAttentionRings)
		{
			HintManager.HintAttentionObject.SetActive(false);
		}
		if (GalaxyMapManager.Instance != null)
		{
			RectTransform component = HintManager.HintPanelGameObject.GetComponent<RectTransform>();
			component.anchoredPosition = new Vector2(startPos.x, component.anchoredPosition.y);
		}
		else
		{
			HintManager.HintPanelGameObject.transform.position = startPos;
		}
		if (overrideHintColor)
		{
			HintManager.HintBorder.color = hintColorOverride;
			HintManager.HintText.color = hintColorOverride;
		}
		if (!ignoreAttentionRings)
		{
			HintManager.EnableAttention();
		}
		direction = endPos - startPos;
		direction.Normalize();
		distPerSecond = (distTillEnd = Vector3.Distance(startPos, endPos)) / timeToDest;
		if (!transitionOff)
		{
			attentionChangeSpeedPerSecond = ringSpeed;
			attentionRingIdx = 0;
		}
		if (startPos.x > endPos.x)
		{
			Color color = HintManager.HintText.color;
			color.a = 1f;
			HintManager.HintText.color = color;
			color = HintManager.HintBorder.color;
			color.a = 1f;
			HintManager.HintBorder.color = color;
		}
	}

	public bool Update()
	{
		float num = distPerSecond * Time.deltaTime;
		currentPos += direction * num;
		if (!transitionOff && !ignoreAttentionRings)
		{
			attentionChangeSpeedPerSecond -= Time.deltaTime;
			for (int i = 0; i <= attentionRingIdx; i++)
			{
				if (i < ringList.Count)
				{
					List<float> list2;
					List<float> list = (list2 = ringList);
					int index2;
					int index = (index2 = i);
					float num2 = list2[index2];
					list[index] = num2 - 0.04f;
					if (ringList[i] > 0f)
					{
						HintManager.SetRingAlpha(i, ringList[i]);
					}
					else
					{
						HintManager.SetRingAlpha(i, 0f);
					}
				}
			}
			if (attentionChangeSpeedPerSecond <= 0f)
			{
				attentionRingIdx++;
				HintManager.SetRingAlpha(attentionRingIdx, 1f);
				attentionChangeSpeedPerSecond = ringSpeed;
			}
		}
		float num3 = Vector3.Distance(currentPos, endPos);
		if (num3 > distTillEnd)
		{
			if (GalaxyMapManager.Instance != null)
			{
				RectTransform component = HintManager.HintPanelGameObject.GetComponent<RectTransform>();
				component.anchoredPosition = new Vector2(endPos.x, component.anchoredPosition.y);
			}
			else
			{
				HintManager.HintPanelGameObject.transform.position = endPos;
			}
			if (!transitionOff && !ignoreAttentionRings)
			{
				for (int j = 0; j < 6; j++)
				{
					HintManager.SetRingAlpha(j, 0f);
				}
			}
			return true;
		}
		if (GalaxyMapManager.Instance != null)
		{
			RectTransform component2 = HintManager.HintPanelGameObject.GetComponent<RectTransform>();
			component2.anchoredPosition = new Vector2(currentPos.x, component2.anchoredPosition.y);
		}
		else
		{
			HintManager.HintPanelGameObject.transform.position = currentPos;
		}
		distTillEnd = num3;
		return false;
	}

	public void Stop()
	{
		if (ringList == null)
		{
			return;
		}
		for (int i = 0; i <= attentionRingIdx; i++)
		{
			if (i < ringList.Count)
			{
				HintManager.SetRingAlpha(i, 0f);
			}
		}
	}
}

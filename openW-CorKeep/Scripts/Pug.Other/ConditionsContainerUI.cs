using System.Collections.Generic;
using Unity.Entities;
using Unity.NetCode;
using UnityEngine;

public class ConditionsContainerUI : MonoBehaviour
{
	public ConditionUI conditionUIPrefab;

	public GameObject container;

	private const int MAX_CONDITIONS = 18;

	private const int MAX_CONDITIONS_PER_ROW = 6;

	private List<ConditionUI> conditions = new List<ConditionUI>();

	private const int spacingPixelsX = 17;

	private const int spacingPixelsY = 17;

	private int activeAmountOfConditions;

	private void Awake()
	{
		Vector3 vector = new Vector3(0f, 0f, 0f);
		int num = 0;
		for (int i = 0; i < 18; i++)
		{
			ConditionUI conditionUI = Object.Instantiate(conditionUIPrefab, container.transform);
			conditions.Add(conditionUI);
			conditionUI.gameObject.SetActive(value: false);
			conditionUI.Init(this);
			conditionUI.transform.localPosition = vector * 0.0625f;
			num++;
			if (num == 6)
			{
				vector = new Vector3(0f, vector.y - 17f, 0f);
				num = 0;
			}
			else
			{
				vector += new Vector3(17f, 0f, 0f);
			}
		}
	}

	private void UpdateConditions()
	{
		PlayerController player = Manager.main.player;
		if (player == null || !player.entityExist)
		{
			return;
		}
		float fraction;
		NetworkTick currentTickOnClient = EntityUtility.GetCurrentTickOnClient(player.entity, player.world, out fraction);
		uint simulationTickRate = (uint)PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate;
		DynamicBuffer<ConditionsBuffer> dynamicBuffer = EntityUtility.GetConditions(player.entity, player.world);
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < dynamicBuffer.Length; i++)
		{
			Condition condition = dynamicBuffer.ElementAt(i).condition;
			if (Manager.ui.conditionsIconsTable.GetConditionInfo(condition.conditionData.conditionID).icon != null)
			{
				if (ConditionExtensions.GetStacks(condition.conditionData.conditionID, condition.conditionData.value) > 0)
				{
					num2++;
				}
				else
				{
					num++;
				}
			}
		}
		num2 = Mathf.Min(num2, 18);
		num = Mathf.Min(num, 18 - num2);
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		for (int j = 0; j < dynamicBuffer.Length; j++)
		{
			if (num3 >= 18)
			{
				break;
			}
			Condition condition2 = dynamicBuffer.ElementAt(j).condition;
			if (!(Manager.ui.conditionsIconsTable.GetConditionInfo(condition2.conditionData.conditionID).icon != null))
			{
				continue;
			}
			if (ConditionExtensions.GetStacks(condition2.conditionData.conditionID, condition2.conditionData.value) > 0)
			{
				if (num5 < num2)
				{
					UpdateCondition(num3, condition2, currentTickOnClient, fraction, simulationTickRate);
					num5++;
					num3++;
				}
			}
			else if (num4 < num)
			{
				UpdateCondition(num3, condition2, currentTickOnClient, fraction, simulationTickRate);
				num4++;
				num3++;
			}
		}
		if (Manager.saves.IsCreativeModeCharacter() && Manager.main.player != null && EntityUtility.IsComponentEnabled<GodModeCD>(player.entity, player.world) && num3 < 18)
		{
			UpdateCondition(num3, new Condition
			{
				conditionData = new ConditionData
				{
					conditionID = ConditionID.GodMode
				}
			}, currentTickOnClient, fraction, simulationTickRate);
			num3++;
		}
		activeAmountOfConditions = num3;
		for (int k = num3; k < conditions.Count; k++)
		{
			if (conditions[k].gameObject.activeSelf)
			{
				conditions[k].gameObject.SetActive(value: false);
			}
		}
	}

	private void UpdateCondition(int conditionIndex, Condition condition, NetworkTick currentTick, float tickFraction, uint tickRate)
	{
		conditions[conditionIndex].UpdateCondition(condition, currentTick, tickFraction, tickRate);
		if (!conditions[conditionIndex].gameObject.activeSelf)
		{
			conditions[conditionIndex].gameObject.SetActive(value: true);
		}
	}

	private void Update()
	{
		UpdateConditions();
	}

	public void LateUpdate()
	{
		container.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		if (Manager.main.player != null && Manager.main.player.guestMode)
		{
			container.SetActive(value: false);
			return;
		}
		container.SetActive(value: true);
		if ((bool)Manager.main.player)
		{
			float y = (Manager.main.player.ShouldShowManaBar() ? 4.875f : 5.5f);
			container.transform.localPosition = new Vector2(container.transform.localPosition.x, y);
		}
	}

	public float GetBottomPosition()
	{
		if (activeAmountOfConditions > 0 && conditions.Count >= activeAmountOfConditions)
		{
			return conditions[activeAmountOfConditions - 1].transform.position.y - 0.9375f;
		}
		return container.transform.position.y + 0.125f;
	}
}

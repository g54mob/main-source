using System;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
	public int secondsToAchiveGoal = 3;

	public Color outsideColor;

	public Color insideColor;

	public Color completedColor;

	private bool isBrainBlockInZone;

	private bool isGoalAchived;

	private float timer;

	private MeshRenderer targetObject;

	public bool IsTimerPaused { get; set; }

	public int ColorIndex { get; private set; }

	public event Action GoalAchivedEvent;

	private void Awake()
	{
		targetObject = GetComponentInChildren<MeshRenderer>();
		ResetTrigger();
	}

	private void Update()
	{
		if (isBrainBlockInZone && !isGoalAchived && !IsTimerPaused)
		{
			timer += Time.deltaTime;
			if (timer >= (float)secondsToAchiveGoal)
			{
				targetObject.material.color = completedColor;
				ColorIndex = 2;
				isGoalAchived = true;
				this.GoalAchivedEvent?.Invoke();
			}
		}
	}

	private void OnTriggerEnter(Collider colliderInfo)
	{
		if (IsAttackerBrainBlock(colliderInfo) && !isGoalAchived)
		{
			isBrainBlockInZone = true;
			timer = 0f;
			targetObject.material.color = insideColor;
			ColorIndex = 1;
		}
	}

	private void OnTriggerExit(Collider colliderInfo)
	{
		if (IsAttackerBrainBlock(colliderInfo) && !isGoalAchived)
		{
			isBrainBlockInZone = false;
			timer = 0f;
			targetObject.material.color = outsideColor;
			ColorIndex = 0;
		}
	}

	private bool IsAttackerBrainBlock(Collider colliderInfo)
	{
		if (!colliderInfo.CompareTag("Block"))
		{
			return false;
		}
		BlockView blockView = colliderInfo.gameObject.GetBlockView();
		if (blockView.Schematic.Type != "brain")
		{
			return false;
		}
		if (blockView.ParentCreationView.CreationRole != CreationView.CreationRoleState.Attacker)
		{
			return false;
		}
		return true;
	}

	public void ResetTrigger()
	{
		isBrainBlockInZone = false;
		isGoalAchived = false;
		timer = 0f;
		IsTimerPaused = false;
		if (targetObject != null)
		{
			targetObject.material.color = outsideColor;
		}
		ColorIndex = 0;
	}

	public void SetColorWithIndex(int index)
	{
		ColorIndex = index;
		switch (index)
		{
		case 0:
			targetObject.material.color = outsideColor;
			break;
		case 1:
			targetObject.material.color = insideColor;
			break;
		default:
			targetObject.material.color = completedColor;
			break;
		}
	}
}

using UnityEngine;

public class PrioritySystem : MonoBehaviour
{
	public PriorityButton[] priorities;

	[SerializeField]
	private RectTransform[] positions;

	[SerializeField]
	private WorkerAI rustyAI;

	public void UpdatePriorityListIn(WorkerAI workerScript, bool smoothMove)
	{
		workerScript.actions.Clear();
		for (int i = 0; i < priorities.Length; i++)
		{
			if (priorities[i].indexPosition == 0)
			{
				workerScript.actions.Add(priorities[i].priority);
			}
		}
		for (int j = 0; j < priorities.Length; j++)
		{
			if (priorities[j].indexPosition == 1)
			{
				workerScript.actions.Add(priorities[j].priority);
			}
		}
		for (int k = 0; k < priorities.Length; k++)
		{
			if (priorities[k].indexPosition == 2)
			{
				workerScript.actions.Add(priorities[k].priority);
			}
		}
		for (int l = 0; l < priorities.Length; l++)
		{
			if (priorities[l].indexPosition == 3)
			{
				workerScript.actions.Add(priorities[l].priority);
			}
		}
		for (int m = 0; m < priorities.Length; m++)
		{
			if (priorities[m].indexPosition == 4)
			{
				workerScript.actions.Add(priorities[m].priority);
			}
		}
		if (smoothMove)
		{
			for (int n = 0; n < priorities.Length; n++)
			{
				priorities[n].CancelMove();
				priorities[n].MoveTo(positions[priorities[n].indexPosition].anchoredPosition, 0.25f);
			}
		}
		else
		{
			for (int num = 0; num < priorities.Length; num++)
			{
				priorities[num].MoveTo(positions[priorities[num].indexPosition].anchoredPosition);
			}
		}
	}

	public void MoveUp(int currentIndex)
	{
		Debug.Log("Move up");
		if (currentIndex != 0)
		{
			PriorityButton priorityWithIndex = getPriorityWithIndex(currentIndex);
			PriorityButton priorityWithIndex2 = getPriorityWithIndex(currentIndex - 1);
			priorityWithIndex.indexPosition--;
			priorityWithIndex2.indexPosition++;
			UpdatePriorityListIn(rustyAI, smoothMove: true);
		}
	}

	public void MoveDown(int currentIndex)
	{
		Debug.Log("Move down " + currentIndex);
		if (currentIndex != 4)
		{
			PriorityButton priorityWithIndex = getPriorityWithIndex(currentIndex);
			PriorityButton priorityWithIndex2 = getPriorityWithIndex(currentIndex + 1);
			priorityWithIndex.indexPosition++;
			priorityWithIndex2.indexPosition--;
			UpdatePriorityListIn(rustyAI, smoothMove: true);
		}
	}

	private PriorityButton getPriorityWithIndex(int i)
	{
		for (int j = 0; j < priorities.Length; j++)
		{
			if (priorities[j].indexPosition == i)
			{
				return priorities[j];
			}
		}
		return null;
	}
}

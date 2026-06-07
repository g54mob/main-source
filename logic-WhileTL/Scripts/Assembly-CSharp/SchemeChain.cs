using System.Collections.Generic;
using App.Data;
using UnityEngine;

public class SchemeChain
{
	private List<float> outTimers = new List<float>();

	public List<Element> queue = new List<Element>();

	public bool move = true;

	private float timer;

	public int nextBlockId;

	public int nextResultId;

	private int nextSocketNum;

	public SchemeBlock parent;

	public bool activated;

	public void Init(int nextBlockId, int nextResultId, int nextSocketNum, SchemeBlock parent)
	{
		this.nextBlockId = nextBlockId;
		this.nextResultId = nextResultId;
		this.nextSocketNum = nextSocketNum;
		this.parent = parent;
	}

	public void SetElement(Element el)
	{
		queue.Add(el);
		activated = true;
		if (nextResultId != -1)
		{
			outTimers.Add(timer);
		}
		else
		{
			outTimers.Add(timer + Logic.GetChainTime());
		}
	}

	public bool IsActive()
	{
		move = true;
		if (nextResultId == -1)
		{
			if (nextBlockId == -1)
			{
				return false;
			}
			if (nextSocketNum == -1)
			{
				return false;
			}
			if (parent.main.blocks[nextBlockId].inSockets[nextSocketNum].isFull())
			{
				move = false;
			}
		}
		else if (parent.main.outSockets[nextResultId].isFull())
		{
			return false;
		}
		return move;
	}

	public float TryActive(float addTimer)
	{
		if (!activated)
		{
			return 1000f;
		}
		if (parent.main.KeyHash == parent.KeyHash)
		{
			return 1000f;
		}
		move = true;
		if (nextResultId == -1)
		{
			if (nextBlockId == -1)
			{
				return 1000f;
			}
			if (nextSocketNum == -1)
			{
				return 1000f;
			}
			if (parent.main.blocks[nextBlockId].inSockets[nextSocketNum].isFull())
			{
				move = false;
			}
		}
		else if (parent.main.outSockets[nextResultId].isFull())
		{
			return 1000f;
		}
		if (!move)
		{
			return 1000f;
		}
		float num = 1000f;
		timer += addTimer;
		for (int i = 0; i < outTimers.Count && outTimers[i] <= timer; i++)
		{
			if (nextResultId == -1)
			{
				if (parent.main.blocks[nextBlockId].inSockets[nextSocketNum].IsActive())
				{
					parent.main.blocks[nextBlockId].inSockets[nextSocketNum].SetElement(queue[i]);
					parent.activated = true;
					outTimers.RemoveAt(i);
					queue.RemoveAt(i);
					i--;
				}
			}
			else if (parent.main.outSockets[nextResultId].IsActive())
			{
				parent.main.outSockets[nextResultId].SetElement(queue[i]);
				parent.main.activated = true;
				outTimers.RemoveAt(i);
				queue.RemoveAt(i);
				i--;
			}
		}
		if (nextBlockId != -1 && parent.main.blocks[nextBlockId].inSockets[nextSocketNum].activated && parent.main.blocks[nextBlockId].KeyName == "REMOVE")
		{
			parent.main.blocks[nextBlockId].activated = queue.Count > 0;
		}
		if (outTimers.Count > 0)
		{
			num = Mathf.Min(outTimers[0] - timer, num);
		}
		return num;
	}
}

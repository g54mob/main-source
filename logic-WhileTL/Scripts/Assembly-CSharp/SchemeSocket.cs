using System.Collections.Generic;
using App.Data;
using UnityEngine;

public class SchemeSocket
{
	public List<Element> queue = new List<Element>();

	private List<Element> backQueue = new List<Element>();

	public SchemeChain chain;

	public bool marked;

	public bool activated;

	private int curSocketDepth = -1;

	private bool inSocket;

	private SchemeBlock parent;

	private float timer;

	public int nextSocketNum = -1;

	public int nextBlock = -1;

	public int nextResultNum = -1;

	public string type = "BASIC";

	public bool catcherSocket;

	public void Init(SchemeBlock parent)
	{
		queue = new List<Element>();
		chain = null;
		curSocketDepth = -1;
		if (nextBlock + nextResultNum != -2)
		{
			chain = new SchemeChain();
			chain.Init(nextBlock, nextResultNum, nextSocketNum, parent);
		}
	}

	public void SetMarked(bool state)
	{
		marked = state;
	}

	public bool isFull()
	{
		if (curSocketDepth == -1)
		{
			curSocketDepth = Logic.GetCurSocketDepth();
		}
		return queue.Count >= curSocketDepth;
	}

	public bool IsValid()
	{
		if (marked)
		{
			if (nextBlock < 0)
			{
				return nextResultNum >= 0;
			}
			return true;
		}
		return false;
	}

	public SchemeSocket(bool inSocket = false)
	{
		nextBlock = -1;
		nextResultNum = -1;
		nextSocketNum = -1;
		catcherSocket = false;
		type = "BASIC";
		this.inSocket = inSocket;
		curSocketDepth = -1;
	}

	public void Init(SchemeSocket sc, SchemeBlock parent)
	{
		this.parent = parent;
		nextBlock = sc.nextBlock;
		nextResultNum = sc.nextResultNum;
		nextSocketNum = sc.nextSocketNum;
		catcherSocket = sc.catcherSocket;
		type = sc.type;
		curSocketDepth = -1;
		Init(parent);
	}

	public bool IsActive()
	{
		if (queue.Count >= Logic.GetCurSocketDepth())
		{
			return false;
		}
		return true;
	}

	public float TryActive(float addTimer)
	{
		if (!activated)
		{
			return 1000f;
		}
		if (inSocket)
		{
			return 1000f;
		}
		if (parent.KeyHash == parent.main.KeyHash)
		{
			return 1000f;
		}
		if (chain == null)
		{
			return 1000f;
		}
		float num = 1000f;
		timer += addTimer;
		if (chain.IsActive() && queue.Count > 0 && timer > 0.02f)
		{
			timer -= 0.02f;
			chain.SetElement(queue[0]);
			queue.RemoveAt(0);
			if (queue.Count > 0)
			{
				num = Mathf.Min(0.02f, num);
			}
		}
		return Mathf.Min(num, chain.TryActive(addTimer));
	}

	public void SetElement(Element elem)
	{
		if (elem != null)
		{
			parent.activated = true;
			activated = true;
			queue.Add(elem);
		}
	}

	public void SetBackElement(Element elem)
	{
		if (elem != null)
		{
			backQueue.Add(elem);
		}
	}

	public Element GetBackElement()
	{
		if (backQueue.Count == 0)
		{
			return null;
		}
		Element result = backQueue[0];
		backQueue.RemoveAt(0);
		return result;
	}

	public Element GetElement()
	{
		if (queue.Count == 0)
		{
			return null;
		}
		Element result = queue[0];
		queue.RemoveAt(0);
		return result;
	}

	public void Clear()
	{
		queue.Clear();
		marked = false;
	}
}

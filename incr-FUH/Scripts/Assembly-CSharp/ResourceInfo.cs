using System.Collections.Generic;
using UnityEngine;

public class ResourceInfo
{
	public int TotalAmount;

	public int Amount;

	private Queue<(float timestamp, int amount)> _history = new Queue<(float, int)>();

	private int _historyTotal;

	private const float HISTORICAL_TIME = 15f;

	private const int MUL = 4;

	private const float CACHED_TIME = 2f;

	private float _lastCalculationTime = -2f;

	private int _lastCached;

	public void Reset()
	{
		TotalAmount = 0;
		Amount = 0;
		_history.Clear();
		_lastCached = 0;
	}

	public void ForceTo(int amount)
	{
		Reset();
		TotalAmount = amount;
		Amount = amount;
	}

	public void AddAmount(int amount)
	{
		float time = Time.time;
		if (amount > 0)
		{
			amount = amount;
			_history.Enqueue((time, amount));
			_historyTotal += amount;
			if (TotalAmount > 0)
			{
				if (TotalAmount + amount > 0)
				{
					TotalAmount += amount;
				}
			}
			else
			{
				TotalAmount += amount;
			}
		}
		Amount += amount;
		if (Amount > 9999999)
		{
			Amount = 9999999;
		}
		CleanHistory();
	}

	public int Get60SecAverage()
	{
		float time = Time.time;
		CleanHistory();
		if (time - _lastCalculationTime >= 2f)
		{
			_lastCached = _historyTotal * 4;
			_lastCalculationTime = time;
		}
		return _lastCached;
	}

	private void CleanHistory()
	{
		float time = Time.time;
		while (_history.Count > 0 && time - _history.Peek().timestamp > 15f)
		{
			_historyTotal -= _history.Dequeue().amount;
		}
	}
}

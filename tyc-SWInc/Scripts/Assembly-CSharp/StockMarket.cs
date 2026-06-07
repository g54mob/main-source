using System;
using System.Collections.Generic;
using SINetworking;
using UnityEngine;

[Serializable]
public class StockMarket
{
	public string Name;

	public float Value;

	public float Velocity;

	public float Acceleration;

	public float Factor;

	public float Range;

	public int TimeToChange;

	public float[] History = new float[24];

	public int NextHistory;

	private System.Random _rnd;

	public StockMarket()
	{
	}

	public StockMarket(string name, float range, float factor, float[] history)
	{
		Name = name;
		Range = range;
		Factor = factor;
		_rnd = new System.Random(UnityEngine.Random.Range(int.MinValue, int.MaxValue));
		History = history;
		Value = history[History.Length - 1];
	}

	public StockMarket(string name, float range, float factor)
	{
		Name = name;
		Value = 100f;
		Range = range;
		Factor = factor;
		_rnd = new System.Random(UnityEngine.Random.Range(int.MinValue, int.MaxValue));
		for (int i = 0; i < 24; i++)
		{
			Simulate(false, true);
		}
	}

	private float GetGauss()
	{
		return (Utilities.RandomGaussClamped(0.5f, Range, _rnd) - 0.5f) * 0.05f;
	}

	public void Simulate(bool metal, bool init = false)
	{
		float num = Value * 0.005f;
		Acceleration = Mathf.Clamp(Acceleration + Velocity, 0f - num, num);
		Value += Acceleration + GetGauss() * 30f;
		TimeToChange--;
		if (TimeToChange <= 0)
		{
			Velocity = GetGauss() * Factor;
			TimeToChange = _rnd.Next(2, 6);
			if (_rnd.Next(0, 3) == 0)
			{
				Velocity *= 10f;
			}
			else if (_rnd.Next(0, 10) == 0)
			{
				Velocity *= 50f;
			}
		}
		History[NextHistory] = Value;
		NextHistory = (NextHistory + 1) % History.Length;
		if (!init)
		{
			NetworkMessaging.SendUpdateStockMarket(Name, metal, Value, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
	}

	public void SetValue(float val)
	{
		Value = val;
		History[NextHistory] = Value;
		NextHistory = (NextHistory + 1) % History.Length;
	}

	public void SetData(List<float> output)
	{
		output.Clear();
		for (int i = 0; i < History.Length; i++)
		{
			output.Add(History[(NextHistory + i) % History.Length]);
		}
	}
}

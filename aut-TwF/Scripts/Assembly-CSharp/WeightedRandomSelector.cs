using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class WeightedRandomSelector<T>
{
	private enum ERandomSelectorMode
	{
		Default = 0,
		RoundRobin = 1,
		DecreasingProbabilities = 2
	}

	[Serializable]
	public class FWeightedElement
	{
		[SerializeField]
		private T element;

		[SerializeField]
		private float probability = 1f;

		private float currentProbability = 1f;

		public T Element => element;

		public float Probability => probability;

		public float CurrentProbability
		{
			get
			{
				return currentProbability;
			}
			set
			{
				currentProbability = value;
			}
		}
	}

	private const float DECREASING_PROBABILITY_FACTOR = 0.5f;

	[SerializeField]
	private List<FWeightedElement> elements;

	[SerializeField]
	private ERandomSelectorMode randomMode;

	public string Name => (Elements[0].Element as GameObject)?.name ?? "UNKNOWN";

	public List<FWeightedElement> Elements
	{
		get
		{
			return elements;
		}
		set
		{
			elements = value;
		}
	}

	public void ResetSelector()
	{
		if (Elements != null)
		{
			for (int i = 0; i < Elements.Count; i++)
			{
				Elements[i].CurrentProbability = Elements[i].Probability;
			}
		}
	}

	public T GetRandomElement()
	{
		return randomMode switch
		{
			ERandomSelectorMode.Default => GetRandomElement_default(), 
			ERandomSelectorMode.RoundRobin => GetRandomElement_roundRobin(), 
			ERandomSelectorMode.DecreasingProbabilities => GetRandomElement_decreasingProbabilities(), 
			_ => GetRandomElement_default(), 
		};
	}

	public T GetRandomElement_default()
	{
		float num = Elements.Sum((FWeightedElement x) => x.Probability);
		float num2 = UnityEngine.Random.value * num;
		float num3 = 0f;
		foreach (FWeightedElement element in Elements)
		{
			if (num2 <= element.Probability + num3)
			{
				return element.Element;
			}
			num3 += element.Probability;
		}
		return default(T);
	}

	public T GetRandomElement_roundRobin()
	{
		float num = Elements.Sum((FWeightedElement x) => Mathf.Max(x.CurrentProbability, 0f));
		if (num == 0f)
		{
			ResetSelector();
			num = Elements.Sum((FWeightedElement x) => x.CurrentProbability);
		}
		float num2 = UnityEngine.Random.value * num;
		float num3 = 0f;
		List<FWeightedElement> list = new List<FWeightedElement>();
		list.AddRange(Elements);
		list.Shuffle();
		foreach (FWeightedElement item in list)
		{
			if (num2 <= item.CurrentProbability + num3)
			{
				item.CurrentProbability = -1f;
				return item.Element;
			}
			num3 += Mathf.Max(item.CurrentProbability, 0f);
		}
		return default(T);
	}

	public T GetRandomElement_decreasingProbabilities()
	{
		float num = Elements.Sum((FWeightedElement x) => x.CurrentProbability);
		float num2 = UnityEngine.Random.value * num;
		float num3 = 0f;
		foreach (FWeightedElement element in Elements)
		{
			if (num2 <= element.CurrentProbability + num3)
			{
				element.CurrentProbability *= 0.5f;
				return element.Element;
			}
			num3 += element.CurrentProbability;
		}
		return default(T);
	}
}

using System;
using CTS.Core;
using CTS.Utilities;

namespace CTS
{
	public abstract class StyleInfluence<T, TSelf> : CTSSingleton<TSelf> where T : Enum where TSelf : CTSSingleton<TSelf>
	{
		public SerializableDictionary<T, float> StyleInfluences { get; private set; } = new SerializableDictionary<T, float>();

		public SerializableDictionary<T, float> NeighborhoodInfluence { get; private set; } = new SerializableDictionary<T, float>();

		protected void AddInfluence(T style, float value)
		{
			if (!StyleInfluences.ContainsKey(style))
			{
				StyleInfluences.Add(style, 0f);
			}
			float num = (NeighborhoodInfluence.ContainsKey(style) ? NeighborhoodInfluence[style] : 1f);
			StyleInfluences[style] += value * num;
		}

		protected void RemoveInfluence(T style, float value)
		{
			if (StyleInfluences.ContainsKey(style))
			{
				float num = (NeighborhoodInfluence.ContainsKey(style) ? NeighborhoodInfluence[style] : 1f);
				StyleInfluences[style] -= value * num;
				if (StyleInfluences[style] <= 0f)
				{
					StyleInfluences.Remove(style);
				}
			}
		}

		public T SelectStyle()
		{
			return StyleInfluences.DrawWeightedRandom();
		}
	}
}

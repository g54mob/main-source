using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	public class Phase
	{
		private struct Layer
		{
			public float value;

			public float weight;
		}

		[NonSerialized]
		private readonly List<Layer> m_Layers = new List<Layer>();

		public float Get(float source)
		{
			float num = source;
			for (int num2 = m_Layers.Count - 1; num2 >= 0; num2--)
			{
				Layer layer = m_Layers[num2];
				num = Mathf.Lerp(num, layer.value, layer.weight);
			}
			return num;
		}

		public void Add(float value, float weight)
		{
			m_Layers.Add(new Layer
			{
				value = value,
				weight = weight
			});
		}

		public void Reset()
		{
			m_Layers.Clear();
		}
	}
}

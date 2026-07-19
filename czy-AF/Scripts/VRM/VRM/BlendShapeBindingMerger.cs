using System;
using System.Collections.Generic;
using UnityEngine;

namespace VRM
{
	internal class BlendShapeBindingMerger
	{
		private class DictionaryKeyBlendShapeBindingComparer : IEqualityComparer<BlendShapeBinding>
		{
			public bool Equals(BlendShapeBinding x, BlendShapeBinding y)
			{
				if (x.RelativePath == y.RelativePath)
				{
					return x.Index == y.Index;
				}
				return false;
			}

			public int GetHashCode(BlendShapeBinding obj)
			{
				return obj.RelativePath.GetHashCode() + obj.Index;
			}
		}

		private static DictionaryKeyBlendShapeBindingComparer comparer = new DictionaryKeyBlendShapeBindingComparer();

		private Dictionary<BlendShapeBinding, float> m_blendShapeValueMap = new Dictionary<BlendShapeBinding, float>(comparer);

		private Dictionary<BlendShapeBinding, Action<float>> m_blendShapeSetterMap = new Dictionary<BlendShapeBinding, Action<float>>(comparer);

		public BlendShapeBindingMerger(Dictionary<BlendShapeKey, BlendShapeClip> clipMap, Transform root)
		{
			foreach (KeyValuePair<BlendShapeKey, BlendShapeClip> item in clipMap)
			{
				BlendShapeBinding[] values = item.Value.Values;
				for (int i = 0; i < values.Length; i++)
				{
					BlendShapeBinding binding = values[i];
					if (m_blendShapeSetterMap.ContainsKey(binding))
					{
						continue;
					}
					Transform transform = root.Find(binding.RelativePath);
					SkinnedMeshRenderer target = null;
					if (transform != null)
					{
						target = transform.GetComponent<SkinnedMeshRenderer>();
					}
					if (target != null)
					{
						if (binding.Index >= 0 && binding.Index < target.sharedMesh.blendShapeCount)
						{
							m_blendShapeSetterMap.Add(binding, delegate(float x)
							{
								target.SetBlendShapeWeight(binding.Index, x);
							});
						}
						else
						{
							Debug.LogWarningFormat("Invalid blendshape binding: {0}: {1}", target.name, binding);
						}
					}
					else
					{
						Debug.LogWarningFormat("SkinnedMeshRenderer: {0} not found", binding.RelativePath);
					}
				}
			}
		}

		public void ImmediatelySetValue(BlendShapeClip clip, float value)
		{
			BlendShapeBinding[] values = clip.Values;
			for (int i = 0; i < values.Length; i++)
			{
				BlendShapeBinding key = values[i];
				if (m_blendShapeSetterMap.TryGetValue(key, out var value2))
				{
					value2(key.Weight * value);
				}
			}
		}

		public void AccumulateValue(BlendShapeClip clip, float value)
		{
			BlendShapeBinding[] values = clip.Values;
			for (int i = 0; i < values.Length; i++)
			{
				BlendShapeBinding key = values[i];
				if (m_blendShapeValueMap.TryGetValue(key, out var value2))
				{
					float value3 = value2 + key.Weight * value;
					m_blendShapeValueMap[key] = Mathf.Clamp(value3, 0f, 100f);
				}
				else
				{
					m_blendShapeValueMap[key] = key.Weight * value;
				}
			}
		}

		public void Apply()
		{
			foreach (KeyValuePair<BlendShapeBinding, float> item in m_blendShapeValueMap)
			{
				if (m_blendShapeSetterMap.TryGetValue(item.Key, out var value))
				{
					value(item.Value);
				}
			}
			m_blendShapeValueMap.Clear();
		}
	}
}

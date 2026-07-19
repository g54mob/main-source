using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VRM
{
	internal class BlendShapeMerger
	{
		private Dictionary<BlendShapeKey, BlendShapeClip> m_clipMap;

		private Dictionary<BlendShapeKey, float> m_valueMap;

		private BlendShapeBindingMerger m_blendShapeBindingMerger;

		private MaterialValueBindingMerger m_materialValueBindingMerger;

		public BlendShapeMerger(IEnumerable<BlendShapeClip> clips, Transform root)
		{
			m_clipMap = clips.ToDictionary((BlendShapeClip x) => BlendShapeKey.CreateFromClip(x), (BlendShapeClip x) => x);
			m_valueMap = new Dictionary<BlendShapeKey, float>();
			m_blendShapeBindingMerger = new BlendShapeBindingMerger(m_clipMap, root);
			m_materialValueBindingMerger = new MaterialValueBindingMerger(m_clipMap, root);
		}

		public void Apply()
		{
			m_blendShapeBindingMerger.Apply();
			m_materialValueBindingMerger.Apply();
		}

		public void SetValues(IEnumerable<KeyValuePair<BlendShapeKey, float>> values)
		{
			foreach (KeyValuePair<BlendShapeKey, float> value in values)
			{
				AccumulateValue(value.Key, value.Value);
			}
			Apply();
		}

		public void AccumulateValue(BlendShapeKey key, float value)
		{
			m_valueMap[key] = value;
			if (m_clipMap.TryGetValue(key, out var value2))
			{
				if (value2.IsBinary)
				{
					value = Mathf.Round(value);
				}
				m_blendShapeBindingMerger.AccumulateValue(value2, value);
				m_materialValueBindingMerger.AccumulateValue(value2, value);
			}
		}

		public void ImmediatelySetValue(BlendShapeKey key, float value)
		{
			m_valueMap[key] = value;
			if (m_clipMap.TryGetValue(key, out var value2))
			{
				if (value2.IsBinary)
				{
					value = Mathf.Round(value);
				}
				m_blendShapeBindingMerger.ImmediatelySetValue(value2, value);
				m_materialValueBindingMerger.ImmediatelySetValue(value2, value);
			}
		}

		public void SetValue(BlendShapeKey key, float value, bool immediately)
		{
			if (immediately)
			{
				ImmediatelySetValue(key, value);
			}
			else
			{
				AccumulateValue(key, value);
			}
		}

		public float GetValue(BlendShapeKey key)
		{
			if (!m_valueMap.TryGetValue(key, out var value))
			{
				return 0f;
			}
			return value;
		}

		public void RestoreMaterialInitialValues(IEnumerable<BlendShapeClip> clips)
		{
			m_materialValueBindingMerger.RestoreMaterialInitialValues(clips);
		}
	}
}

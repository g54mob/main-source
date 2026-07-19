using System;
using System.Collections.Generic;
using UnityEngine;

namespace VRM
{
	[DisallowMultipleComponent]
	public class VRMBlendShapeProxy : MonoBehaviour, IVRMComponent
	{
		[SerializeField]
		public BlendShapeAvatar BlendShapeAvatar;

		private BlendShapeMerger m_merger;

		public void OnImported(VRMImporterContext context)
		{
			throw new NotImplementedException();
		}

		private void OnDestroy()
		{
			if (m_merger != null)
			{
				m_merger.RestoreMaterialInitialValues(BlendShapeAvatar.Clips);
			}
		}

		private void Start()
		{
			if (BlendShapeAvatar != null && m_merger == null)
			{
				m_merger = new BlendShapeMerger(BlendShapeAvatar.Clips, base.transform);
			}
		}

		public void ImmediatelySetValue(BlendShapeKey key, float value)
		{
			if (m_merger != null)
			{
				m_merger.ImmediatelySetValue(key, value);
			}
		}

		public void AccumulateValue(BlendShapeKey key, float value)
		{
			if (m_merger != null)
			{
				m_merger.AccumulateValue(key, value);
			}
		}

		public float GetValue(BlendShapeKey key)
		{
			if (m_merger == null)
			{
				return 0f;
			}
			return m_merger.GetValue(key);
		}

		public IEnumerable<KeyValuePair<BlendShapeKey, float>> GetValues()
		{
			if (m_merger == null || !(BlendShapeAvatar != null))
			{
				yield break;
			}
			foreach (BlendShapeClip clip in BlendShapeAvatar.Clips)
			{
				BlendShapeKey key = BlendShapeKey.CreateFromClip(clip);
				yield return new KeyValuePair<BlendShapeKey, float>(key, m_merger.GetValue(key));
			}
		}

		public void SetValues(IEnumerable<KeyValuePair<BlendShapeKey, float>> values)
		{
			if (m_merger != null)
			{
				m_merger.SetValues(values);
			}
		}

		public void Apply()
		{
			if (m_merger != null)
			{
				m_merger.Apply();
			}
		}
	}
}

using System;
using System.Linq;
using UniGLTF;
using UnityEngine;

namespace VRM
{
	[Obsolete("Use VRMBlendShapeProxy")]
	public class BlendShapeClipHandler
	{
		private BlendShapeClip m_clip;

		private SkinnedMeshRenderer[] m_renderers;

		[Obsolete("Use Clip")]
		public BlendShapeClip Cilp => Clip;

		public BlendShapeClip Clip => m_clip;

		public float LastValue { get; private set; }

		public BlendShapeClipHandler(BlendShapeClip clip, Transform transform)
		{
			m_clip = clip;
			if (m_clip != null && m_clip.Values != null && transform != null)
			{
				m_renderers = m_clip.Values.Select((BlendShapeBinding x) => transform.GetFromPath(x.RelativePath).GetComponent<SkinnedMeshRenderer>()).ToArray();
			}
		}

		public void Apply(float value)
		{
			LastValue = value;
			if (m_clip == null || m_renderers == null)
			{
				return;
			}
			for (int i = 0; i < m_clip.Values.Length; i++)
			{
				BlendShapeBinding blendShapeBinding = m_clip.Values[i];
				SkinnedMeshRenderer skinnedMeshRenderer = m_renderers[i];
				if (blendShapeBinding.Index >= 0 && blendShapeBinding.Index < skinnedMeshRenderer.sharedMesh.blendShapeCount)
				{
					skinnedMeshRenderer.SetBlendShapeWeight(blendShapeBinding.Index, blendShapeBinding.Weight * value);
				}
			}
		}
	}
}

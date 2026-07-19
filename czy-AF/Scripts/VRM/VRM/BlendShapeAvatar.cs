using System;
using System.Collections.Generic;
using System.Linq;
using UniGLTF;
using UnityEngine;

namespace VRM
{
	[CreateAssetMenu(menuName = "VRM/BlendShapeAvatar")]
	public class BlendShapeAvatar : ScriptableObject
	{
		[SerializeField]
		public List<BlendShapeClip> Clips = new List<BlendShapeClip>();

		public void RemoveNullClip()
		{
			if (Clips == null)
			{
				return;
			}
			for (int num = Clips.Count - 1; num >= 0; num--)
			{
				if (Clips[num] == null)
				{
					Clips.RemoveAt(num);
				}
			}
		}

		public void CreateDefaultPreset()
		{
			BlendShapePreset[] values = CacheEnum.GetValues<BlendShapePreset>();
			foreach (BlendShapePreset blendShapePreset in values)
			{
				if (blendShapePreset != BlendShapePreset.Unknown)
				{
					CreateDefaultPreset(blendShapePreset);
				}
			}
		}

		private void CreateDefaultPreset(BlendShapePreset preset)
		{
			BlendShapeClip blendShapeClip = null;
			foreach (BlendShapeClip clip in Clips)
			{
				if (clip.Preset == preset)
				{
					blendShapeClip = clip;
					break;
				}
			}
			if (!(blendShapeClip != null))
			{
				blendShapeClip = ScriptableObject.CreateInstance<BlendShapeClip>();
				blendShapeClip.name = preset.ToString();
				blendShapeClip.BlendShapeName = preset.ToString();
				blendShapeClip.Preset = preset;
				Clips.Add(blendShapeClip);
			}
		}

		public void SetClip(BlendShapeKey key, BlendShapeClip clip)
		{
			int num = -1;
			try
			{
				num = Clips.FindIndex((BlendShapeClip x) => key.Match(x));
			}
			catch (Exception)
			{
			}
			if (num == -1)
			{
				Clips.Add(clip);
			}
			else
			{
				Clips[num] = clip;
			}
		}

		public BlendShapeClip GetClip(BlendShapeKey key)
		{
			if (Clips == null)
			{
				return null;
			}
			return Clips.FirstOrDefault((BlendShapeClip x) => key.Match(x));
		}

		public BlendShapeClip GetClip(BlendShapePreset preset)
		{
			return GetClip(BlendShapeKey.CreateFromPreset(preset));
		}

		public BlendShapeClip GetClip(string name)
		{
			return GetClip(BlendShapeKey.CreateUnknown(name));
		}
	}
}

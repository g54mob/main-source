using System;
using System.Collections.Generic;

namespace VRM
{
	[Serializable]
	public readonly struct BlendShapeKey : IEquatable<BlendShapeKey>, IComparable<BlendShapeKey>
	{
		private static readonly Dictionary<BlendShapePreset, string> PresetNameCacheDictionary = new Dictionary<BlendShapePreset, string>();

		private static readonly string UnknownPresetPrefix = "Unknown_";

		public readonly BlendShapePreset Preset;

		private readonly string m_id;

		public string Name { get; }

		private BlendShapeKey(string name, BlendShapePreset preset)
		{
			Preset = preset;
			if (Preset != BlendShapePreset.Unknown)
			{
				if (PresetNameCacheDictionary.TryGetValue(Preset, out var value))
				{
					m_id = (Name = value);
					return;
				}
				m_id = (Name = Preset.ToString());
				PresetNameCacheDictionary.Add(Preset, Name);
			}
			else
			{
				Name = ((!string.IsNullOrEmpty(name)) ? name : "");
				m_id = UnknownPresetPrefix + Name;
			}
		}

		public static BlendShapeKey CreateFromPreset(BlendShapePreset preset)
		{
			return new BlendShapeKey("", preset);
		}

		public static BlendShapeKey CreateFromClip(BlendShapeClip clip)
		{
			if (clip == null)
			{
				return default(BlendShapeKey);
			}
			return new BlendShapeKey(clip.BlendShapeName, clip.Preset);
		}

		public static BlendShapeKey CreateUnknown(string name)
		{
			return new BlendShapeKey(name, BlendShapePreset.Unknown);
		}

		public override string ToString()
		{
			return m_id.Replace(UnknownPresetPrefix, "");
		}

		public bool Equals(BlendShapeKey other)
		{
			return m_id == other.m_id;
		}

		public override bool Equals(object obj)
		{
			if (obj is BlendShapeKey)
			{
				return Equals((BlendShapeKey)obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return m_id.GetHashCode();
		}

		public bool Match(BlendShapeClip clip)
		{
			return Equals(CreateFromClip(clip));
		}

		public int CompareTo(BlendShapeKey other)
		{
			if (Preset != other.Preset)
			{
				return Preset - other.Preset;
			}
			return 0;
		}
	}
}

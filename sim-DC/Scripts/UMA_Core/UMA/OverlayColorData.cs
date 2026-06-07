using System;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class OverlayColorData : IEquatable<OverlayColorData>
	{
		public static int currentinstance;

		[NonSerialized]
		public int instance;

		public static Color EmptyAdditive;

		public const string UNSHARED = "-";

		public string name;

		[ColorUsage(true, true)]
		public Color[] channelMask;

		public Color[] channelAdditiveMask;

		public UMAMaterialPropertyBlock PropertyBlock;

		public Color displayColor;

		public Color color
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public Color Add => default(Color);

		public int channelCount => 0;

		public bool IsASharedColor => false;

		public bool isValid => false;

		public bool HasColors => false;

		public bool HasPropertyBlock => false;

		public bool HasProperties => false;

		public bool isOnlyColors => false;

		public bool isOnlyProperties => false;

		public Color GetTint(int channel)
		{
			return default(Color);
		}

		public Color GetAdditive(int channel)
		{
			return default(Color);
		}

		public bool isDefault(int Channel)
		{
			return false;
		}

		public OverlayColorData()
		{
		}

		public OverlayColorData(int channels)
		{
		}

		public OverlayColorData Duplicate()
		{
			return null;
		}

		public bool HasName()
		{
			return false;
		}

		public static bool SameColor(Color color1, Color color2)
		{
			return false;
		}

		public static bool DifferentColor(Color color1, Color color2)
		{
			return false;
		}

		public static implicit operator bool(OverlayColorData obj)
		{
			return false;
		}

		public bool Equals(OverlayColorData other)
		{
			return false;
		}

		public override bool Equals(object other)
		{
			return false;
		}

		public static bool operator ==(OverlayColorData cd1, OverlayColorData cd2)
		{
			return false;
		}

		public static bool operator !=(OverlayColorData cd1, OverlayColorData cd2)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public void SetChannels(int channels)
		{
		}

		public void EnsureChannels(int channels)
		{
		}

		public void EnsureChannelsExact(int ChannelCount)
		{
		}

		public void AssignTo(OverlayColorData dest)
		{
		}

		public void AssignFrom(OverlayColorData src, bool CopyParmsOnly = false)
		{
		}
	}
}

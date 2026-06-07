using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class OverlayData : IEquatable<OverlayData>
	{
		public class ColorComponentAdjuster
		{
			public enum AdjustmentType
			{
				Absolute = 0,
				Adjust = 1,
				AbsoluteAdditive = 2,
				AdjustAdditive = 3,
				BlendFactor = 4
			}

			public int channel;

			public int colorComponent;

			public float adjustment;

			public AdjustmentType adjustmentType;

			public bool Additive => false;

			public ColorComponentAdjuster()
			{
			}

			public ColorComponentAdjuster(int channel, int colorComponent, float adjustment, AdjustmentType adjustmentType = AdjustmentType.Adjust)
			{
			}

			public ColorComponentAdjuster(ColorComponentAdjuster other)
			{
			}
		}

		public OverlayDataAsset asset;

		public Rect rect;

		public bool[] tiling;

		public int UVSet;

		public bool Supressed;

		[NonSerialized]
		public SlotData mergedFromSlot;

		public string[] tags;

		private const string proceduralSizeProperty = "$outputsize";

		public List<ColorComponentAdjuster> colorComponentAdjusters;

		private OverlayDataAsset.OverlayBlend[] blendOverrides;

		[NonSerialized]
		public OverlayColorData colorData;

		public bool instanceTransformed;

		public Vector2 Scale;

		public Vector2 Translate;

		[Range(0f, 360f)]
		public float Rotation;

		public bool isEmpty => false;

		public bool isProcedural => false;

		public string overlayName => null;

		public OverlayDataAsset.OverlayType overlayType => default(OverlayDataAsset.OverlayType);

		public Texture alphaMask => null;

		public Texture[] textureArray => null;

		public int ChannelCount => 0;

		public OverlayDataAsset.OverlayBlend[] textureBlendArray => null;

		public int pixelCount => 0;

		public Vector4 GetUV(float referenceWidth, float referenceHeight)
		{
			return default(Vector4);
		}

		public void SetOverlayBlendsLength(int count)
		{
		}

		public int GetOverlayBlendsLength()
		{
			return 0;
		}

		public void SetOverlayBlend(int ChannelNumber, OverlayDataAsset.OverlayBlend overlayBlend)
		{
		}

		public OverlayDataAsset.OverlayBlend GetOverlayBlend(int ChannelNumber)
		{
			return default(OverlayDataAsset.OverlayBlend);
		}

		public Texture GetTexture(int ChannelNumber)
		{
			return null;
		}

		public bool HasTag(string tag)
		{
			return false;
		}

		public OverlayData Duplicate()
		{
			return null;
		}

		protected OverlayData()
		{
		}

		public OverlayData(OverlayDataAsset asset)
		{
		}

		public void Validate()
		{
		}

		internal bool Validate(UMAMaterial targetMaterial, bool isBaseOverlay)
		{
			return false;
		}

		public float GetComponentAdjustmentsForChannel(float inColor, int channel, int component, bool additive = false)
		{
			return 0f;
		}

		public void SetColor(int channel, Color32 color)
		{
		}

		public Color32 GetColor(int channel)
		{
			return default(Color32);
		}

		public Color32 GetAdditive(int channel)
		{
			return default(Color32);
		}

		public void SetAdditive(int channel, Color32 color)
		{
		}

		public void CopyColors(OverlayData overlay)
		{
		}

		public void EnsureChannels(int channels)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool Equivalent(OverlayData overlay1, OverlayData overlay2)
		{
			return false;
		}

		public static bool EquivalentAssetAndUse(OverlayData overlay1, OverlayData overlay2)
		{
			return false;
		}

		public static implicit operator bool(OverlayData obj)
		{
			return false;
		}

		public bool Equals(OverlayData other)
		{
			return false;
		}

		public override bool Equals(object other)
		{
			return false;
		}

		public static bool operator ==(OverlayData overlay, OverlayData obj)
		{
			return false;
		}

		public static bool operator !=(OverlayData overlay, OverlayData obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public bool IsTextureTiled(int t)
		{
			return false;
		}

		public void SetTextureTiling(int t, bool v)
		{
		}
	}
}

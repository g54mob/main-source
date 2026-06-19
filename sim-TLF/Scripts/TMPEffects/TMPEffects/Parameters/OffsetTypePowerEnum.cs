using System;
using TMPEffects.CharacterData;
using TMPEffects.Components.Animator;
using TMPEffects.TMPAnimations;

namespace TMPEffects.Parameters
{
	[Serializable]
	public class OffsetTypePowerEnum : PowerEnum<TMPParameterTypes.OffsetType, TMPOffsetProvider>, IEquatable<OffsetTypePowerEnum>, ITMPOffsetProvider
	{
		public OffsetTypePowerEnum()
			: base(TMPParameterTypes.OffsetType.Index)
		{
		}

		public OffsetTypePowerEnum(TMPParameterTypes.OffsetType offsetType)
			: base(offsetType)
		{
		}

		public OffsetTypePowerEnum(TMPParameterTypes.OffsetType offsetType, TMPOffsetProvider customOffsetProvider)
			: base(offsetType, customOffsetProvider)
		{
		}

		public OffsetTypePowerEnum(TMPParameterTypes.OffsetType offsetType, TMPOffsetProvider customOffsetProvider, bool useCustom)
			: base(offsetType, customOffsetProvider, useCustom)
		{
		}

		public float GetOffset(CharData cData, ITMPSegmentData segmentData, IAnimatorDataProvider animatorData, bool ignoreAnimatorScaling = false)
		{
			if (!useCustom)
			{
				return TMPAnimationUtility.GetOffset(base.EnumValue, cData, segmentData, animatorData, ignoreAnimatorScaling);
			}
			if (base.Value == null)
			{
				return 0f;
			}
			return base.Value.GetOffset(cData, segmentData, animatorData, ignoreAnimatorScaling);
		}

		public void GetMinMaxOffset(out float min, out float max, ITMPSegmentData segmentData, IAnimatorDataProvider animatorData, bool ignoreAnimatorScaling = false)
		{
			if (!useCustom)
			{
				TMPAnimationUtility.GetMinMaxOffset(out min, out max, base.EnumValue, segmentData, animatorData, ignoreAnimatorScaling);
			}
			else if (base.Value == null)
			{
				min = 0f;
				max = 0f;
			}
			else
			{
				base.Value.GetMinMaxOffset(out min, out max, segmentData, animatorData, ignoreAnimatorScaling);
			}
		}

		public bool Equals(OffsetTypePowerEnum other)
		{
			if (other != null && other.EnumValue == base.EnumValue && other.UseCustom == base.UseCustom)
			{
				return other.Value == base.Value;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is OffsetTypePowerEnum other)
			{
				return Equals(other);
			}
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}

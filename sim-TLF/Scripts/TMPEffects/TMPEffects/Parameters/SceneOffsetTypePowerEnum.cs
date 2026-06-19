using System;
using TMPEffects.CharacterData;
using TMPEffects.Components.Animator;
using TMPEffects.TMPAnimations;

namespace TMPEffects.Parameters
{
	[Serializable]
	public class SceneOffsetTypePowerEnum : PowerEnum<TMPParameterTypes.OffsetType, TMPSceneOffsetProvider>, IEquatable<SceneOffsetTypePowerEnum>, ITMPOffsetProvider
	{
		public SceneOffsetTypePowerEnum()
			: base(TMPParameterTypes.OffsetType.Index)
		{
		}

		public SceneOffsetTypePowerEnum(TMPParameterTypes.OffsetType offsetType)
			: base(offsetType)
		{
		}

		public SceneOffsetTypePowerEnum(TMPParameterTypes.OffsetType offsetType, TMPSceneOffsetProvider customOffsetProvider)
			: base(offsetType, customOffsetProvider)
		{
		}

		public SceneOffsetTypePowerEnum(TMPParameterTypes.OffsetType offsetType, TMPSceneOffsetProvider customOffsetProvider, bool useCustom)
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

		public bool Equals(SceneOffsetTypePowerEnum other)
		{
			if (other != null && other.EnumValue == base.EnumValue && other.UseCustom == base.UseCustom)
			{
				return other.Value == base.Value;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is SceneOffsetTypePowerEnum other)
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

using System;
using TMPEffects.CharacterData;
using TMPEffects.Components.Animator;

namespace TMPEffects.Parameters
{
	[Serializable]
	public class OffsetTypePowerEnum : PowerEnum<TMPParameterTypes.OffsetType, TMPOffsetProvider>, IEquatable<OffsetTypePowerEnum>, ITMPOffsetProvider
	{
		public OffsetTypePowerEnum()
			: base((TMPParameterTypes.OffsetType)default(_00210), (TMPOffsetProvider)default(_00211), false)
		{
		}//IL_0019: Expected I4, but got O


		public OffsetTypePowerEnum(TMPParameterTypes.OffsetType offsetType)
			: base((TMPParameterTypes.OffsetType)default(_00210), (TMPOffsetProvider)default(_00211), false)
		{
		}//IL_0019: Expected I4, but got O


		public OffsetTypePowerEnum(TMPParameterTypes.OffsetType offsetType, TMPOffsetProvider customOffsetProvider)
			: base((TMPParameterTypes.OffsetType)default(_00210), (TMPOffsetProvider)default(_00211), false)
		{
		}//IL_0019: Expected I4, but got O


		public OffsetTypePowerEnum(TMPParameterTypes.OffsetType offsetType, TMPOffsetProvider customOffsetProvider, bool useCustom)
			: base((TMPParameterTypes.OffsetType)default(_00210), (TMPOffsetProvider)default(_00211), false)
		{
		}//IL_0019: Expected I4, but got O


		public float GetOffset(CharData cData, ITMPSegmentData segmentData, IAnimatorDataProvider animatorData, bool ignoreAnimatorScaling = false)
		{
			return 0f;
		}

		public void GetMinMaxOffset(out float min, out float max, ITMPSegmentData segmentData, IAnimatorDataProvider animatorData, bool ignoreAnimatorScaling = false)
		{
			min = default(float);
			max = default(float);
		}

		public bool Equals(OffsetTypePowerEnum other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}

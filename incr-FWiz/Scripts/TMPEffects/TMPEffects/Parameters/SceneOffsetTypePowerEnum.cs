using System;
using TMPEffects.CharacterData;
using TMPEffects.Components.Animator;

namespace TMPEffects.Parameters
{
	[Serializable]
	public class SceneOffsetTypePowerEnum : PowerEnum<TMPParameterTypes.OffsetType, TMPSceneOffsetProvider>, IEquatable<SceneOffsetTypePowerEnum>, ITMPOffsetProvider
	{
		public SceneOffsetTypePowerEnum()
			: base((TMPParameterTypes.OffsetType)default(_00210), (TMPSceneOffsetProvider)default(_00211), false)
		{
		}//IL_0019: Expected I4, but got O


		public SceneOffsetTypePowerEnum(TMPParameterTypes.OffsetType offsetType)
			: base((TMPParameterTypes.OffsetType)default(_00210), (TMPSceneOffsetProvider)default(_00211), false)
		{
		}//IL_0019: Expected I4, but got O


		public SceneOffsetTypePowerEnum(TMPParameterTypes.OffsetType offsetType, TMPSceneOffsetProvider customOffsetProvider)
			: base((TMPParameterTypes.OffsetType)default(_00210), (TMPSceneOffsetProvider)default(_00211), false)
		{
		}//IL_0019: Expected I4, but got O


		public SceneOffsetTypePowerEnum(TMPParameterTypes.OffsetType offsetType, TMPSceneOffsetProvider customOffsetProvider, bool useCustom)
			: base((TMPParameterTypes.OffsetType)default(_00210), (TMPSceneOffsetProvider)default(_00211), false)
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

		public bool Equals(SceneOffsetTypePowerEnum other)
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

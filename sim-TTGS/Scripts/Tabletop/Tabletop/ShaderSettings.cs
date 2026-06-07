using Dhs5.Utility.Settings;
using UnityEngine;

namespace Tabletop
{
	[Settings("Tabletop/Shaders", Scope.Project)]
	public class ShaderSettings : CustomSettings<ShaderSettings>
	{
		[Header("Bounce")]
		[SerializeField]
		private AnimationCurve m_bounceAnimationCurve;

		[SerializeField]
		private EnumValues<EBouncePresets, BounceData> m_bouncePresets;

		public static AnimationCurve BounceAnimationCurve => CustomSettings<ShaderSettings>.I.m_bounceAnimationCurve;

		public static BounceData GetBouncePreset(EBouncePresets bouncePresets)
		{
			return CustomSettings<ShaderSettings>.I.m_bouncePresets[bouncePresets];
		}
	}
}

using System.Linq;
using Assets.Scripts.Flight.Combat;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public class SeekerData
	{
		private const float MilesToMeters = 1610f;

		public static SeekerData[] DefaultSeekers { get; private set; } = new SeekerData[6]
		{
			new SeekerData(SeekerType.Unguided, WeaponFunction.MultiRole, 0f, TargetingStyle.None, 0f, 0f),
			new SeekerData(SeekerType.Infrared, WeaponFunction.AirToAir, 16100f, TargetingStyle.StandardLock, 15f, 60f),
			new SeekerData(SeekerType.SemiActiveRadar, WeaponFunction.AirToAir, 24150f, TargetingStyle.ContinuousLock, 15f, 60f),
			new SeekerData(SeekerType.ActiveRadar, WeaponFunction.AirToAir, 48300f, TargetingStyle.StandardLock, 5f, 25f),
			new SeekerData(SeekerType.Laser, WeaponFunction.AirToSurface, 16100f, TargetingStyle.StandardLock, 15f, 60f),
			new SeekerData(SeekerType.AntiRadiation, WeaponFunction.AirToSurface, 24150f, TargetingStyle.StandardLock, 15f, 60f)
		};

		public WeaponFunction Function { get; }

		public float LockTime { get; }

		public float MaxFOV { get; }

		public float MaxLockRange { get; }

		public float MaxRange { get; }

		public float MaxTargetAngle { get; }

		public float MinFOV { get; }

		public TargetingStyle Style { get; }

		public SeekerType Type { get; }

		public SeekerData(SeekerType type, WeaponFunction function, float maxLockRange, TargetingStyle style, float minFOV, float maxFOV)
		{
			Function = function;
			MaxLockRange = maxLockRange;
			Style = style;
			Type = type;
			MinFOV = minFOV;
			MaxFOV = maxFOV;
		}

		public static SeekerData GetSeeker(SeekerType seekerType)
		{
			SeekerData seekerData = DefaultSeekers.FirstOrDefault((SeekerData s) => s.Type == seekerType);
			if (seekerData == null)
			{
				seekerData = DefaultSeekers.First();
			}
			return seekerData;
		}
	}
}

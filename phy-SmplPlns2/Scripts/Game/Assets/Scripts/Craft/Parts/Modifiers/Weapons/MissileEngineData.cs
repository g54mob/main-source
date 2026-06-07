using System.Linq;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public class MissileEngineData
	{
		private static MissileEngineData[] _defaultEngines = new MissileEngineData[3]
		{
			new MissileEngineData(isThustVectoring: false, 0.05f, 1f, 1f, 30f, 2000f, 1500f, MissileEngineType.Solid),
			new MissileEngineData(isThustVectoring: true, 0.06f, 1f, 1f, 30f, 1750f, 1300f, MissileEngineType.ThrustVector),
			new MissileEngineData(isThustVectoring: false, 0.12f, 1.5f, 60f, 300f, 7500f, 500f, MissileEngineType.Jet)
		};

		public float BaseSize { get; private set; }

		public float DeltaV { get; private set; }

		public bool IsThrustVectoring { get; private set; }

		public float MassPercentage { get; private set; }

		public float MaxBurnTime { get; private set; }

		public float MaxSpeed { get; private set; }

		public float MinBurnTime { get; private set; }

		public MissileEngineType Type { get; private set; }

		public MissileEngineData(bool isThustVectoring, float massPercentage, float baseSize, float minBurnTime, float maxBurnTime, float deltaV, float maxSpeed, MissileEngineType type)
		{
			IsThrustVectoring = isThustVectoring;
			MassPercentage = massPercentage;
			BaseSize = baseSize;
			MinBurnTime = minBurnTime;
			MaxBurnTime = maxBurnTime;
			DeltaV = deltaV;
			MaxSpeed = maxSpeed;
			Type = type;
		}

		public static MissileEngineData GetEngineData(MissileEngineType engineType)
		{
			MissileEngineData missileEngineData = _defaultEngines.Where((MissileEngineData x) => x.Type == engineType).FirstOrDefault();
			if (missileEngineData == null)
			{
				missileEngineData = _defaultEngines.First();
			}
			return missileEngineData;
		}
	}
}

using JetBrains.Annotations;
using UnityEngine;
using VampireSurvivors.Data;
using Zenject;

namespace VampireSurvivors.Graphics
{
	[UsedImplicitly]
	public class VFXManager : IInitializable
	{
		[Inject]
		private SignalBus _signalBus;

		private static HitVFXData[] Config;

		private static Material[] VfxTypeMaterialsCache;

		public void Initialize()
		{
		}

		private static Sprite GetVfxSprite(string frameName)
		{
			return null;
		}

		public static HitVFXData GetData(HitVfxType vfxType)
		{
			return null;
		}

		public static Material GetMaterial(HitVfxType type)
		{
			return null;
		}

		private static void AddData(HitVfxType t, bool hasTintFill, string color, string hitFrameName, string impactFrameName, float duration, Shader baseSpriteShader)
		{
		}

		public static void SpawnImpactVFX(HitVfxType type, Vector2 worldPos)
		{
		}

		private static void TryCacheVfxHitMaterial(HitVfxType t, bool hasTintFill, HitVFXData dat, Shader baseSpriteShader)
		{
		}
	}
}

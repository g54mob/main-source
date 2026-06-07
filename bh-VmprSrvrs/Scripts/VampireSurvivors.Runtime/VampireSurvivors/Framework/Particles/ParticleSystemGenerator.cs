using UnityEngine;

namespace VampireSurvivors.Framework.Particles
{
	public static class ParticleSystemGenerator
	{
		public static ParticleSystem GenerateParticleSystem(ParticleSystemConfig config, Transform parent = null, string name = null, bool usePauseSystem = true)
		{
			return null;
		}

		public static GravityWell GenerateGravityWell(GravityWellConfig config, Transform parent = null, string name = null, bool usePauseSystem = true)
		{
			return null;
		}

		public static void SetupTimeline(Transform parent, GameObject gameObject, bool usePauseSystem = true)
		{
		}

		private static void ConfigureParticleSystem(ParticleSystem particleSystem, ParticleSystemConfig config)
		{
		}

		private static void ConfigureFrames(ParticleSystemConfig config, ParticleSystem.TextureSheetAnimationModule textureSheetAnimation)
		{
		}

		private static void ConfigureSpeed(ParticleSystemConfig config, ParticleSystem ps)
		{
		}

		private static void ConfigureAngle(ParticleSystemConfig config, ParticleSystem.ShapeModule shape)
		{
		}

		private static void ConfigureRotation(ParticleSystemConfig config, ParticleSystem.MainModule main)
		{
		}

		private static void ConfigureLifespan(ParticleSystemConfig config, ParticleSystem.MainModule main)
		{
		}

		private static void ConfigureScale(ParticleSystemConfig config, ParticleSystem.SizeOverLifetimeModule sizeOverLifetime, ParticleSystemRenderer psr, ParticleSystem.MainModule main, float sizeMult)
		{
		}

		private static void ConfigureAlpha(ParticleSystemConfig config, ParticleSystem.ColorOverLifetimeModule colorOverLifetime)
		{
		}

		private static void ConfigureQuantity(ParticleSystemConfig config, ParticleSystem.EmissionModule emission)
		{
		}

		private static void ConfigureOn(ParticleSystemConfig config, ParticleSystem.EmissionModule emission)
		{
		}

		private static void ConfigureGravity(ParticleSystemConfig config, ParticleSystem.MainModule main)
		{
		}

		private static void ConfigureTint(ParticleSystemConfig config, ParticleSystem.MainModule main)
		{
		}

		private static Color32 HexToColor(uint hexVal)
		{
			return default(Color32);
		}

		private static void ConfigureEmitZone(ParticleSystemConfig config, ParticleSystem particleSystem)
		{
		}

		private static void ConfigurePosition(ParticleSystemConfig config, ParticleSystem particleSystem)
		{
		}

		private static void UpdateCollisionBounds(ParticleSystemConfig config, ParticleSystem particleSystem)
		{
		}

		private static Material GetMaterial(BlendMode? blendMode)
		{
			return null;
		}

		private static void ConfigureGravityWell(GravityWell gravityWell, GravityWellConfig config)
		{
		}

		private static void ConfigureGravityWellPosition(GravityWellConfig config, GravityWell well)
		{
		}
	}
}

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Coffee.UIParticleInternal
{
	internal static class ParticleSystemExtensions
	{
		private static ParticleSystem.Particle[] s_TmpParticles;

		public static ParticleSystem.Particle[] GetParticleArray(int size)
		{
			return null;
		}

		public static void ValidateShape(this ParticleSystem self)
		{
		}

		public static bool CanBakeMesh(this ParticleSystemRenderer self)
		{
			return false;
		}

		public static ParticleSystemSimulationSpace GetActualSimulationSpace(this ParticleSystem self)
		{
			return default(ParticleSystemSimulationSpace);
		}

		public static bool IsLocalSpace(this ParticleSystem self)
		{
			return false;
		}

		public static bool IsWorldSpace(this ParticleSystem self)
		{
			return false;
		}

		public static void SortForRendering(this List<ParticleSystem> self, Transform transform, bool sortByMaterial)
		{
		}

		private static int GetIndex(IList<ParticleSystem> list, UnityEngine.Object ps)
		{
			return 0;
		}

		public static Texture2D GetTextureForSprite(this ParticleSystem self)
		{
			return null;
		}

		public static void Exec(this List<ParticleSystem> self, Action<ParticleSystem> action)
		{
		}

		public static ParticleSystem GetMainEmitter(this ParticleSystem self, List<ParticleSystem> list)
		{
			return null;
		}

		public static bool IsSubEmitterOf(this ParticleSystem self, ParticleSystem parent)
		{
			return false;
		}
	}
}

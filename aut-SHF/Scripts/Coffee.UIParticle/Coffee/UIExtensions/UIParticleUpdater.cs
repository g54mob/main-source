using System.Collections.Generic;
using UnityEngine;

namespace Coffee.UIExtensions
{
	internal static class UIParticleUpdater
	{
		private static readonly List<UIParticle> s_ActiveParticles;

		private static readonly List<UIParticleAttractor> s_ActiveAttractors;

		private static readonly HashSet<int> s_UpdatedGroupIds;

		private static int frameCount;

		public static int uiParticleCount => 0;

		public static void Register(UIParticle particle)
		{
		}

		public static void Unregister(UIParticle particle)
		{
		}

		public static void Register(UIParticleAttractor attractor)
		{
		}

		public static void Unregister(UIParticleAttractor attractor)
		{
		}

		[RuntimeInitializeOnLoadMethod]
		private static void InitializeOnLoad()
		{
		}

		private static void Refresh()
		{
		}

		public static void GetGroupedRenderers(int groupId, int index, List<UIParticleRenderer> results)
		{
		}

		internal static UIParticle GetPrimary(int groupId)
		{
			return null;
		}
	}
}

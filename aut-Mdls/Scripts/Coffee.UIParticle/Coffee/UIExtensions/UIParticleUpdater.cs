using System.Collections.Generic;
using Coffee.UIParticleInternal;
using UnityEngine;

namespace Coffee.UIExtensions
{
	internal static class UIParticleUpdater
	{
		private static readonly List<UIParticle> s_ActiveParticles = new List<UIParticle>();

		private static readonly List<UIParticleAttractor> s_ActiveAttractors = new List<UIParticleAttractor>();

		private static readonly HashSet<int> s_UpdatedGroupIds = new HashSet<int>();

		private static int s_FrameCount;

		public static int uiParticleCount => s_ActiveParticles.Count;

		public static void Register(UIParticle particle)
		{
			if ((bool)particle)
			{
				s_ActiveParticles.Add(particle);
			}
		}

		public static void Unregister(UIParticle particle)
		{
			if ((bool)particle)
			{
				s_ActiveParticles.Remove(particle);
			}
		}

		public static void Register(UIParticleAttractor attractor)
		{
			if ((bool)attractor)
			{
				s_ActiveAttractors.Add(attractor);
			}
		}

		public static void Unregister(UIParticleAttractor attractor)
		{
			if ((bool)attractor)
			{
				s_ActiveAttractors.Remove(attractor);
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void InitializeOnLoad()
		{
			UIExtraCallbacks.onAfterCanvasRebuild += Refresh;
		}

		private static void Refresh()
		{
			if (s_FrameCount == Time.frameCount)
			{
				return;
			}
			s_FrameCount = Time.frameCount;
			for (int i = 0; i < s_ActiveParticles.Count; i++)
			{
				UIParticle uIParticle = s_ActiveParticles[i];
				if ((bool)uIParticle && (bool)uIParticle.canvas && uIParticle.isPrimary && s_UpdatedGroupIds.Add(uIParticle.groupId))
				{
					uIParticle.UpdateTransformScale();
					uIParticle.UpdateRenderers();
				}
			}
			for (int j = 0; j < s_ActiveParticles.Count; j++)
			{
				UIParticle uIParticle2 = s_ActiveParticles[j];
				if ((bool)uIParticle2 && (bool)uIParticle2.canvas)
				{
					uIParticle2.UpdateTransformScale();
					if (!uIParticle2.useMeshSharing)
					{
						uIParticle2.UpdateRenderers();
					}
					else if (s_UpdatedGroupIds.Add(uIParticle2.groupId))
					{
						uIParticle2.UpdateRenderers();
					}
				}
			}
			s_UpdatedGroupIds.Clear();
			for (int k = 0; k < s_ActiveAttractors.Count; k++)
			{
				s_ActiveAttractors[k].Attract();
			}
		}

		public static void GetGroupedRenderers(int groupId, int index, List<UIParticleRenderer> results)
		{
			results.Clear();
			for (int i = 0; i < s_ActiveParticles.Count; i++)
			{
				UIParticle uIParticle = s_ActiveParticles[i];
				if (uIParticle.useMeshSharing && uIParticle.groupId == groupId)
				{
					results.Add(uIParticle.GetRenderer(index));
				}
			}
		}

		internal static UIParticle GetPrimary(int groupId)
		{
			UIParticle uIParticle = null;
			for (int i = 0; i < s_ActiveParticles.Count; i++)
			{
				UIParticle uIParticle2 = s_ActiveParticles[i];
				if (uIParticle2.useMeshSharing && uIParticle2.groupId == groupId)
				{
					if (uIParticle2.isPrimary)
					{
						return uIParticle2;
					}
					if (!uIParticle && uIParticle2.canSimulate)
					{
						uIParticle = uIParticle2;
					}
				}
			}
			return uIParticle;
		}
	}
}

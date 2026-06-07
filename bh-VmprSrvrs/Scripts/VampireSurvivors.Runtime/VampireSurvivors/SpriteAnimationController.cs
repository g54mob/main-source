using System.Collections.Generic;
using Unity.Profiling;
using VampireSurvivors.Graphics;

namespace VampireSurvivors
{
	public class SpriteAnimationController : GameMonoBehaviour
	{
		private static readonly HashSet<BaseSpriteAnimation> Animations;

		private static readonly HashSet<BaseSpriteAnimation> PendingAdd;

		private static readonly HashSet<BaseSpriteAnimation> PendingRemove;

		private static ProfilerMarker update;

		private static bool iterating;

		protected override void OnUpdate()
		{
		}

		public static void Add(BaseSpriteAnimation baseSpriteAnimation)
		{
		}

		public static void Remove(BaseSpriteAnimation baseSpriteAnimation)
		{
		}
	}
}

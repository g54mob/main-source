using System;
using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	[TraitRarityConfig(0.00049999997f, null)]
	[TraitNotValidWith(new Type[] { typeof(SqueamishTrait) })]
	public class ThisIsFineTrait : ActorTrait
	{
		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void OnComponentAdded(object sender, GameObjectX.GameObjectXEventArgs<AiComponent> e)
		{
		}

		protected ThisIsFineTrait()
		{
		}

		public ThisIsFineTrait(Actor owner)
		{
		}
	}
}

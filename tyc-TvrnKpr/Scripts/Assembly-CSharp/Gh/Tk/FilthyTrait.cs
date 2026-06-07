using System;
using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	[TraitRarityConfig(0.03f, "orc")]
	[TraitRarityConfig(0f, "elf")]
	[TraitRarityConfig(0.01f, null)]
	[TraitNotValidWith(new Type[] { typeof(DirtDodgerTrait) })]
	public class FilthyTrait : StaffTrait
	{
		[Preserve]
		private static void OnGameStarted()
		{
		}

		protected FilthyTrait()
		{
		}

		public FilthyTrait(Staff owner)
		{
		}

		private static void OnSleepingStatusChanged(object sender, Actor.ActorEventArgs<bool> e)
		{
		}

		private void DisableOutput()
		{
		}

		private void EnableOutput()
		{
		}

		public override void Init()
		{
		}

		public override void OnRemoving()
		{
		}
	}
}

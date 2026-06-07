using System;
using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	[TraitRarityConfig(0.03f, null)]
	[TraitNotValidWith(new Type[] { typeof(FearOfTheDarkTrait) })]
	public class NightOwlTrait : StaffTrait
	{
		[PersistenceOptIn]
		[PersistenceObjectReference]
		private HappinessStat _stat;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void HourChanged(object sender, EventArgs e)
		{
		}

		protected NightOwlTrait()
		{
		}

		public NightOwlTrait(Staff owner)
		{
		}

		public override void Init()
		{
		}

		public override void OnRemoving()
		{
		}

		private void StaffWorkingChanged(object sender, EventArgs e)
		{
		}

		private void UpdateValue()
		{
		}
	}
}

using System.Collections.Generic;

namespace Gh.Tk
{
	public class Insecticide : GameItemVisual
	{
		public static HashSet<Insecticide> AllInsecticides;

		private bool _currentOpenState;

		public string _openSoundLoop;

		public string _closedSoundLoop;

		public override void Start()
		{
		}

		public override void OnDestroy()
		{
		}

		public static Insecticide GetUnusedInsecticide()
		{
			return null;
		}

		public void SetOpenState(bool state)
		{
		}
	}
}

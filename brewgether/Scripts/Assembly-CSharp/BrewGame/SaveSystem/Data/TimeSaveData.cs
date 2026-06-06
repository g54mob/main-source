using System;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class TimeSaveData
	{
		public float normalizedTime;

		public int dayIndex;

		public float timeScale;
	}
}

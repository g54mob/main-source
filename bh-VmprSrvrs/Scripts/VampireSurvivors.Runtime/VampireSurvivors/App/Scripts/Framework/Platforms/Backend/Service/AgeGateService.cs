namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service
{
	public class AgeGateService
	{
		private readonly string _key;

		private readonly int _ageLimit;

		public bool IsOldEnough()
		{
			return false;
		}

		public bool IsOldEnough(int year, int month, int day)
		{
			return false;
		}
	}
}

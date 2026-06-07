namespace Gh.Tk
{
	public class AreaEffectRatingsProfile : IPersistable
	{
		public string Effect { get; set; }

		public float Minimum { get; set; }

		public float Maximum { get; set; }

		protected AreaEffectRatingsProfile()
		{
		}

		public AreaEffectRatingsProfile(string effect, float minimum, float maximum)
		{
		}
	}
}

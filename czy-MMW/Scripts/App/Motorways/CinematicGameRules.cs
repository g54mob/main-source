namespace Motorways
{
	public class CinematicGameRules : BackgroundGameRules
	{
		public override bool CanDestinationsOvercrowd => false;

		public override bool UseCamera()
		{
			return true;
		}
	}
}

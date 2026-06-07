using System.Collections.Generic;

namespace Gh.Tk
{
	public class BulletinBoardPaper : GameItemVisual
	{
		[PersistenceOptIn]
		public string PosterName;

		public string EnablePoster(IEnumerable<string> except)
		{
			return null;
		}
	}
}

using UnityEngine;

namespace Boxophobic.StyledGUI
{
	public class StyledBanner : PropertyAttribute
	{
		public float colorR;

		public float colorG;

		public float colorB;

		public string title;

		public string helpURL;

		public StyledBanner(string title)
		{
		}

		public StyledBanner(float colorR, float colorG, float colorB, string title)
		{
		}

		public StyledBanner(string title, string helpURL)
		{
		}

		public StyledBanner(float colorR, float colorG, float colorB, string title, string helpURL)
		{
		}

		public StyledBanner(string title, string subtitle, string helpURL)
		{
		}

		public StyledBanner(float colorR, float colorG, float colorB, string title, string subtitle, string helpURL)
		{
		}
	}
}

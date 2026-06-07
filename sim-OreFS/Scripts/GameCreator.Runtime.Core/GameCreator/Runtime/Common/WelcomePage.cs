using System;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class WelcomePage
	{
		public string image;

		public string color;

		public string[] steps;

		public WelcomePage()
		{
			image = string.Empty;
			color = string.Empty;
			steps = Array.Empty<string>();
		}

		public WelcomePage(string image, string color, params string[] steps)
			: this()
		{
			this.image = image;
			this.color = color;
			this.steps = new string[steps.Length];
			for (int i = 0; i < steps.Length; i++)
			{
				this.steps[i] = steps[i];
			}
		}

		public WelcomePage(WelcomePage page)
			: this()
		{
			image = page.image;
			color = page.color;
			steps = new string[page.steps.Length];
			for (int i = 0; i < page.steps.Length; i++)
			{
				steps[i] = page.steps[i];
			}
		}
	}
}

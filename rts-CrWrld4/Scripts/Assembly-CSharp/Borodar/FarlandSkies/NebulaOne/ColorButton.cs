using Borodar.FarlandSkies.Core.Demo;
using UnityEngine;

namespace Borodar.FarlandSkies.NebulaOne
{
	public class ColorButton : BaseColorButton
	{
		public enum ColorType
		{
			BackgroundColor = 0,
			StarsTint = 1,
			NebulaBackgroundTint = 2,
			NebulaBasementTint = 3,
			NebulaRipplesTint1 = 4,
			NebulaRipplesTint2 = 5
		}

		public ColorType SkyColorType;

		protected void Start()
		{
		}

		public override void ChangeColor(Color color)
		{
		}

		private void UpdateColorImage(Color color)
		{
		}
	}
}

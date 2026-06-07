using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Side-Scroller XY")]
	[Category("Side-Scroller/Side-Scroller XY")]
	[Image(typeof(IconSquareSolid), ColorTheme.Type.Red, typeof(OverlayArrowRight))]
	[Description("Freezes the character Z translation axis and allows to move around its plane")]
	public class AxonometrySideScrollXY : TAxonometry
	{
		public override void ProcessPosition(TUnitDriver driver, Vector3 position)
		{
			base.ProcessPosition(driver, position);
			driver.Transform.position = new Vector3(position.x, position.y, 0f);
		}

		public override Vector3 ProcessRotation(TUnitFacing facing, Vector3 direction)
		{
			if (!(direction.x >= 0f))
			{
				return Vector3.left;
			}
			return Vector3.right;
		}

		public override object Clone()
		{
			return new AxonometrySideScrollXY();
		}

		public override string ToString()
		{
			return "Side-Scroll XY";
		}
	}
}

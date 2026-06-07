using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Side-Scroller YZ")]
	[Category("Side-Scroller/Side-Scroller YZ")]
	[Image(typeof(IconSquareSolid), ColorTheme.Type.Green, typeof(OverlayArrowUp))]
	[Description("Freezes the character X translation axis and allows to move around its plane")]
	public class AxonometrySideScrollYZ : TAxonometry
	{
		public override void ProcessPosition(TUnitDriver driver, Vector3 position)
		{
			base.ProcessPosition(driver, position);
			driver.Transform.position = new Vector3(0f, position.y, position.z);
		}

		public override Vector3 ProcessRotation(TUnitFacing facing, Vector3 direction)
		{
			if (!(direction.z >= 0f))
			{
				return Vector3.back;
			}
			return Vector3.forward;
		}

		public override object Clone()
		{
			return new AxonometrySideScrollYZ();
		}

		public override string ToString()
		{
			return "Side-Scroll YZ";
		}
	}
}

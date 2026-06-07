using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Isometric Cardinal")]
	[Category("Isometric/Isometric Cardinal")]
	[Image(typeof(IconIsometric), ColorTheme.Type.Yellow, typeof(OverlayPlus))]
	[Description("Snaps the character direction in either up, down, right or left")]
	public class AxonometryIsometric4Cardinal : TAxonometry
	{
		private static readonly Vector3[] ISOMETRIC_DIRECTIONS = new Vector3[4]
		{
			new Vector2(1f, 0f),
			new Vector2(0f, 1f),
			new Vector2(-1f, 0f),
			new Vector2(0f, -1f)
		};

		public override Vector3 ProcessTranslation(TUnitDriver driver, Vector3 movement)
		{
			Vector2 vector = IsometricDirection(movement.XZ());
			return new Vector3(vector.x, movement.y, vector.y);
		}

		public override Vector3 ProcessRotation(TUnitFacing facing, Vector3 direction)
		{
			Vector2 vector = IsometricDirection(direction.XZ());
			return new Vector3(vector.x, direction.y, vector.y);
		}

		private Vector2 IsometricDirection(Vector2 direction)
		{
			float magnitude = direction.magnitude;
			if (magnitude <= float.Epsilon)
			{
				return direction;
			}
			float num = Mathf.Atan2(direction.y, direction.x);
			int num2 = (Mathf.RoundToInt(4f * num / (MathF.PI * 2f)) + 4) % 4;
			return ISOMETRIC_DIRECTIONS[num2].normalized * magnitude;
		}

		public override object Clone()
		{
			return new AxonometryIsometric4Cardinal();
		}

		public override string ToString()
		{
			return "4 Cardinal";
		}
	}
}

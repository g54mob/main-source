using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Isometric 8 Directions")]
	[Category("Isometric/Isometric 8 Directions")]
	[Image(typeof(IconIsometric), ColorTheme.Type.Yellow)]
	[Description("Snaps the character direction in multiples of 45 degrees")]
	public class AxonometryIsometric8Directions : TAxonometry
	{
		private static readonly Vector3[] ISOMETRIC_DIRECTIONS = new Vector3[8]
		{
			new Vector2(1f, 0f),
			new Vector2(1f, 1f),
			new Vector2(0f, 1f),
			new Vector2(-1f, 1f),
			new Vector2(-1f, 0f),
			new Vector2(-1f, -1f),
			new Vector2(0f, -1f),
			new Vector2(1f, -1f)
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
			int num2 = (Mathf.RoundToInt(8f * num / (MathF.PI * 2f)) + 8) % 8;
			return ISOMETRIC_DIRECTIONS[num2].normalized * magnitude;
		}

		public override object Clone()
		{
			return new AxonometryIsometric8Directions();
		}

		public override string ToString()
		{
			return "8 Directions";
		}
	}
}

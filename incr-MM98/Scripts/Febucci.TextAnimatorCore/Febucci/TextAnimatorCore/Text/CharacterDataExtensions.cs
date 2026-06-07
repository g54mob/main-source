using System;
using System.Runtime.CompilerServices;
using Febucci.Numbers;

namespace Febucci.TextAnimatorCore.Text
{
	public static class CharacterDataExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void MovePosition(this CharacterData character, Vector3 offset, bool isUpPositive)
		{
			if (!isUpPositive)
			{
				offset.Y *= -1f;
			}
			for (int i = 0; i < 4; i++)
			{
				ref Vector3 reference = ref character.current.positions[i];
				reference.X += offset.X * character.uniformIntensity;
				reference.Y += offset.Y * character.uniformIntensity;
				reference.Z += offset.Z * character.uniformIntensity;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void MovePosition(this CharacterData character, float offsetX, float offsetY, float offsetZ, bool isUpPositive)
		{
			if (!isUpPositive)
			{
				offsetY *= -1f;
			}
			for (int i = 0; i < 4; i++)
			{
				ref Vector3 reference = ref character.current.positions[i];
				reference.X += offsetX * character.uniformIntensity;
				reference.Y += offsetY * character.uniformIntensity;
				reference.Z += offsetZ * character.uniformIntensity;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPosition(this CharacterData character, Vector3 pos)
		{
			character.current.positions[0] = pos;
			character.current.positions[1] = pos;
			character.current.positions[2] = pos;
			character.current.positions[3] = pos;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RotateDegrees(this CharacterData character, float angleDegrees, bool isUpPositive)
		{
			character.RotateDegrees(angleDegrees, character.originalCenter, isUpPositive);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RotateDegrees(this CharacterData character, float angleDegrees, Vector3 pivot, bool isUpPositive)
		{
			if (!(Math.Abs(angleDegrees) < 0.001f))
			{
				float angleRad = (0f - angleDegrees) * (MathF.PI / 180f);
				character.RotateRadians(angleRad, pivot, isUpPositive);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RotateRadians(this CharacterData character, float angleRad, bool isUpPositive)
		{
			character.RotateRadians(angleRad, character.originalCenter, isUpPositive);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RotateRadians(this CharacterData character, float angleRad, Vector3 pivot, bool isUpPositive)
		{
			if (!isUpPositive)
			{
				angleRad = 0f - angleRad;
			}
			float num = (float)Math.Cos(angleRad);
			float num2 = (float)Math.Sin(angleRad);
			if (!pivot.ApproximatesTo(character.originalCenter))
			{
				float num3 = character.current.positions[2].X - character.current.positions[0].X;
				float num4 = character.current.positions[2].Y - character.current.positions[0].Y;
				pivot = new Vector3(character.originalCenter.X + pivot.X * num3, character.originalCenter.Y + pivot.Y * num4, character.originalCenter.Z + pivot.Z);
			}
			for (int i = 0; i < 4; i++)
			{
				ref Vector3 reference = ref character.current.positions[i];
				float num5 = reference.X - pivot.X;
				float num6 = reference.Y - pivot.Y;
				reference.X = pivot.X + num5 * num - num6 * num2;
				reference.Y = pivot.Y + num5 * num2 + num6 * num;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Scale(this CharacterData character, Vector3 scale)
		{
			character.Scale(scale, character.originalCenter);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void Scale(this CharacterData character, Vector3 scale, Vector3 pivot)
		{
			for (int i = 0; i < 4; i++)
			{
				ref Vector3 reference = ref character.current.positions[i];
				reference.X = pivot.X + (reference.X - pivot.X) * scale.X;
				reference.Y = pivot.Y + (reference.Y - pivot.Y) * scale.Y;
				reference.Z = pivot.Z + (reference.Z - pivot.Z) * scale.Z;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 GetCenter(this CharacterData character)
		{
			return new Vector3((character.current.positions[0].X + character.current.positions[2].X) * 0.5f, (character.current.positions[0].Y + character.current.positions[2].Y) * 0.5f, (character.current.positions[0].Z + character.current.positions[2].Z) * 0.5f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ShearHorizontally(this CharacterData character, float shearTop, float shearBottom)
		{
			shearBottom *= character.uniformIntensity;
			shearTop *= character.uniformIntensity;
			character.current.positions[0].X += shearBottom;
			character.current.positions[3].X += shearBottom;
			character.current.positions[1].X += shearTop;
			character.current.positions[2].X += shearTop;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ShearVertically(this CharacterData character, float shearLeft, float shearRight)
		{
			shearLeft *= character.uniformIntensity;
			shearRight *= character.uniformIntensity;
			character.current.positions[0].Y += shearLeft;
			character.current.positions[1].Y += shearLeft;
			character.current.positions[3].Y += shearRight;
			character.current.positions[2].Y += shearRight;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void LerpPositionTo(this CharacterData character, Vector3 target, float t)
		{
			float num = 1f - t;
			for (int i = 0; i < 4; i++)
			{
				ref Vector3 reference = ref character.current.positions[i];
				reference.X = reference.X * num + target.X * t;
				reference.Y = reference.Y * num + target.Y * t;
				reference.Z = reference.Z * num + target.Z * t;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetColor(this CharacterData character, Color32 color)
		{
			character.current.colors[0] = color;
			character.current.colors[1] = color;
			character.current.colors[2] = color;
			character.current.colors[3] = color;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void LerpColor(this CharacterData character, Color32 targetColor, float t)
		{
			for (int i = 0; i < 4; i++)
			{
				ref Color32 reference = ref character.current.colors[i];
				reference = Color32.LerpUnclamped(reference, targetColor, t);
			}
		}
	}
}

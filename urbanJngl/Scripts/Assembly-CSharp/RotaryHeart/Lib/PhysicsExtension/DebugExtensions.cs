using System;
using RotaryHeart.Lib.UnityGLDebug;
using UnityEngine;

namespace RotaryHeart.Lib.PhysicsExtension
{
	internal static class DebugExtensions
	{
		internal static void DebugSquare(Vector3 origin, Vector3 halfExtents, Color color, Quaternion orientation, float drawDuration = 0f, PreviewCondition preview = PreviewCondition.Editor, bool drawDepth = false)
		{
			Vector3 vector = orientation * Vector3.forward;
			Vector3 vector2 = orientation * Vector3.up;
			Vector3 vector3 = orientation * Vector3.right;
			Vector3 start = origin + vector3 * halfExtents.x + vector2 * halfExtents.y + vector * halfExtents.z;
			Vector3 vector4 = origin - vector3 * halfExtents.x + vector2 * halfExtents.y + vector * halfExtents.z;
			Vector3 vector5 = origin + vector3 * halfExtents.x - vector2 * halfExtents.y + vector * halfExtents.z;
			Vector3 end = origin - vector3 * halfExtents.x - vector2 * halfExtents.y + vector * halfExtents.z;
			bool flag = false;
			bool flag2 = false;
			switch (preview)
			{
			case PreviewCondition.Editor:
				flag = true;
				break;
			case PreviewCondition.Game:
				flag2 = true;
				break;
			case PreviewCondition.Both:
				flag = true;
				flag2 = true;
				break;
			}
			if (flag)
			{
				Debug.DrawLine(start, vector5, color, drawDuration, drawDepth);
				Debug.DrawLine(vector4, end, color, drawDuration, drawDepth);
				Debug.DrawLine(start, vector4, color, drawDuration, drawDepth);
				Debug.DrawLine(vector5, end, color, drawDuration, drawDepth);
			}
			if (flag2)
			{
				GLDebug.DrawLine(start, vector5, color, drawDuration, drawDepth);
				GLDebug.DrawLine(vector4, end, color, drawDuration, drawDepth);
				GLDebug.DrawLine(start, vector4, color, drawDuration, drawDepth);
				GLDebug.DrawLine(vector5, end, color, drawDuration, drawDepth);
			}
		}

		internal static void DebugBox(Vector3 origin, Vector3 halfExtents, Vector3 direction, float maxDistance, Color color, Quaternion orientation, Color endColor, bool drawBase = true, float drawDuration = 0f, PreviewCondition preview = PreviewCondition.Editor, bool drawDepth = false)
		{
			Vector3 vector = origin + direction * (float.IsPositiveInfinity(maxDistance) ? 1000000f : maxDistance);
			Vector3 vector2 = orientation * Vector3.forward;
			Vector3 vector3 = orientation * Vector3.up;
			Vector3 vector4 = orientation * Vector3.right;
			Vector3 start = vector + vector4 * halfExtents.x + vector3 * halfExtents.y - vector2 * halfExtents.z;
			Vector3 vector5 = vector - vector4 * halfExtents.x + vector3 * halfExtents.y - vector2 * halfExtents.z;
			Vector3 vector6 = vector + vector4 * halfExtents.x + vector3 * halfExtents.y + vector2 * halfExtents.z;
			Vector3 vector7 = vector - vector4 * halfExtents.x + vector3 * halfExtents.y + vector2 * halfExtents.z;
			Vector3 vector8 = vector + vector4 * halfExtents.x - vector3 * halfExtents.y - vector2 * halfExtents.z;
			Vector3 end = vector - vector4 * halfExtents.x - vector3 * halfExtents.y - vector2 * halfExtents.z;
			Vector3 vector9 = vector + vector4 * halfExtents.x - vector3 * halfExtents.y + vector2 * halfExtents.z;
			Vector3 vector10 = vector - vector4 * halfExtents.x - vector3 * halfExtents.y + vector2 * halfExtents.z;
			Vector3 vector11 = origin + vector4 * halfExtents.x + vector3 * halfExtents.y - vector2 * halfExtents.z;
			Vector3 vector12 = origin - vector4 * halfExtents.x + vector3 * halfExtents.y - vector2 * halfExtents.z;
			Vector3 vector13 = origin + vector4 * halfExtents.x + vector3 * halfExtents.y + vector2 * halfExtents.z;
			Vector3 vector14 = origin - vector4 * halfExtents.x + vector3 * halfExtents.y + vector2 * halfExtents.z;
			Vector3 vector15 = origin + vector4 * halfExtents.x - vector3 * halfExtents.y - vector2 * halfExtents.z;
			Vector3 end2 = origin - vector4 * halfExtents.x - vector3 * halfExtents.y - vector2 * halfExtents.z;
			Vector3 vector16 = origin + vector4 * halfExtents.x - vector3 * halfExtents.y + vector2 * halfExtents.z;
			Vector3 vector17 = origin - vector4 * halfExtents.x - vector3 * halfExtents.y + vector2 * halfExtents.z;
			bool flag = false;
			bool flag2 = false;
			switch (preview)
			{
			case PreviewCondition.Editor:
				flag = true;
				break;
			case PreviewCondition.Game:
				flag2 = true;
				break;
			case PreviewCondition.Both:
				flag = true;
				flag2 = true;
				break;
			}
			if (flag)
			{
				if (drawBase)
				{
					Debug.DrawLine(vector11, vector15, color, drawDuration, drawDepth);
					Debug.DrawLine(vector12, end2, color, drawDuration, drawDepth);
					Debug.DrawLine(vector13, vector16, color, drawDuration, drawDepth);
					Debug.DrawLine(vector14, vector17, color, drawDuration, drawDepth);
					Debug.DrawLine(vector11, vector12, color, drawDuration, drawDepth);
					Debug.DrawLine(vector11, vector13, color, drawDuration, drawDepth);
					Debug.DrawLine(vector13, vector14, color, drawDuration, drawDepth);
					Debug.DrawLine(vector14, vector12, color, drawDuration, drawDepth);
					Debug.DrawLine(vector15, end2, color, drawDuration, drawDepth);
					Debug.DrawLine(vector15, vector16, color, drawDuration, drawDepth);
					Debug.DrawLine(vector16, vector17, color, drawDuration, drawDepth);
					Debug.DrawLine(vector17, end2, color, drawDuration, drawDepth);
				}
				Debug.DrawLine(start, vector11, color, drawDuration, drawDepth);
				Debug.DrawLine(vector5, vector12, color, drawDuration, drawDepth);
				Debug.DrawLine(vector6, vector13, color, drawDuration, drawDepth);
				Debug.DrawLine(vector7, vector14, color, drawDuration, drawDepth);
				Debug.DrawLine(vector8, vector15, color, drawDuration, drawDepth);
				Debug.DrawLine(vector8, vector15, color, drawDuration, drawDepth);
				Debug.DrawLine(vector9, vector16, color, drawDuration, drawDepth);
				Debug.DrawLine(vector10, vector17, color, drawDuration, drawDepth);
				color = endColor;
				Debug.DrawLine(start, vector8, color, drawDuration, drawDepth);
				Debug.DrawLine(vector5, end, color, drawDuration, drawDepth);
				Debug.DrawLine(vector6, vector9, color, drawDuration, drawDepth);
				Debug.DrawLine(vector7, vector10, color, drawDuration, drawDepth);
				Debug.DrawLine(start, vector5, color, drawDuration, drawDepth);
				Debug.DrawLine(start, vector6, color, drawDuration, drawDepth);
				Debug.DrawLine(vector6, vector7, color, drawDuration, drawDepth);
				Debug.DrawLine(vector7, vector5, color, drawDuration, drawDepth);
				Debug.DrawLine(vector8, end, color, drawDuration, drawDepth);
				Debug.DrawLine(vector8, vector9, color, drawDuration, drawDepth);
				Debug.DrawLine(vector9, vector10, color, drawDuration, drawDepth);
				Debug.DrawLine(vector10, end, color, drawDuration, drawDepth);
			}
			if (flag2)
			{
				if (drawBase)
				{
					GLDebug.DrawLine(vector11, vector15, color, drawDuration, drawDepth);
					GLDebug.DrawLine(vector12, end2, color, drawDuration, drawDepth);
					GLDebug.DrawLine(vector13, vector16, color, drawDuration, drawDepth);
					GLDebug.DrawLine(vector14, vector17, color, drawDuration, drawDepth);
					GLDebug.DrawLine(vector11, vector12, color, drawDuration, drawDepth);
					GLDebug.DrawLine(vector11, vector13, color, drawDuration, drawDepth);
					GLDebug.DrawLine(vector13, vector14, color, drawDuration, drawDepth);
					GLDebug.DrawLine(vector14, vector12, color, drawDuration, drawDepth);
					GLDebug.DrawLine(vector15, end2, color, drawDuration, drawDepth);
					GLDebug.DrawLine(vector15, vector16, color, drawDuration, drawDepth);
					GLDebug.DrawLine(vector16, vector17, color, drawDuration, drawDepth);
					GLDebug.DrawLine(vector17, end2, color, drawDuration, drawDepth);
				}
				GLDebug.DrawLine(start, vector11, color, drawDuration, drawDepth);
				GLDebug.DrawLine(vector5, vector12, color, drawDuration, drawDepth);
				GLDebug.DrawLine(vector6, vector13, color, drawDuration, drawDepth);
				GLDebug.DrawLine(vector7, vector14, color, drawDuration, drawDepth);
				GLDebug.DrawLine(vector8, vector15, color, drawDuration, drawDepth);
				GLDebug.DrawLine(vector8, vector15, color, drawDuration, drawDepth);
				GLDebug.DrawLine(vector9, vector16, color, drawDuration, drawDepth);
				GLDebug.DrawLine(vector10, vector17, color, drawDuration, drawDepth);
				color = endColor;
				GLDebug.DrawLine(start, vector8, color, drawDuration, drawDepth);
				GLDebug.DrawLine(vector5, end, color, drawDuration, drawDepth);
				GLDebug.DrawLine(vector6, vector9, color, drawDuration, drawDepth);
				GLDebug.DrawLine(vector7, vector10, color, drawDuration, drawDepth);
				GLDebug.DrawLine(start, vector5, color, drawDuration, drawDepth);
				GLDebug.DrawLine(start, vector6, color, drawDuration, drawDepth);
				GLDebug.DrawLine(vector6, vector7, color, drawDuration, drawDepth);
				GLDebug.DrawLine(vector7, vector5, color, drawDuration, drawDepth);
				GLDebug.DrawLine(vector8, end, color, drawDuration, drawDepth);
				GLDebug.DrawLine(vector8, vector9, color, drawDuration, drawDepth);
				GLDebug.DrawLine(vector9, vector10, color, drawDuration, drawDepth);
				GLDebug.DrawLine(vector10, end, color, drawDuration, drawDepth);
			}
		}

		internal static void DebugBoxCast(Vector3 origin, Vector3 halfExtents, Vector3 direction, float maxDistance, Color color, Quaternion orientation, float drawDuration = 0f, CastDrawType drawType = CastDrawType.Minimal, PreviewCondition preview = PreviewCondition.Editor, bool drawDepth = false)
		{
			bool flag = false;
			bool flag2 = false;
			switch (preview)
			{
			case PreviewCondition.Editor:
				flag = true;
				break;
			case PreviewCondition.Game:
				flag2 = true;
				break;
			case PreviewCondition.Both:
				flag = true;
				flag2 = true;
				break;
			}
			if (flag)
			{
				if (drawType == CastDrawType.Minimal)
				{
					Debug.DrawLine(origin, origin + direction * maxDistance, color, drawDuration);
				}
				else
				{
					Vector3 vector = orientation * Vector3.forward;
					Vector3 vector2 = orientation * Vector3.up;
					Vector3 vector3 = orientation * Vector3.right;
					Vector3 vector4 = origin + vector3 * halfExtents.x + vector2 * halfExtents.y - vector * halfExtents.z;
					Vector3 vector5 = origin - vector3 * halfExtents.x + vector2 * halfExtents.y - vector * halfExtents.z;
					Vector3 vector6 = origin + vector3 * halfExtents.x + vector2 * halfExtents.y + vector * halfExtents.z;
					Vector3 vector7 = origin - vector3 * halfExtents.x + vector2 * halfExtents.y + vector * halfExtents.z;
					Vector3 vector8 = origin + vector3 * halfExtents.x - vector2 * halfExtents.y - vector * halfExtents.z;
					Vector3 vector9 = origin - vector3 * halfExtents.x - vector2 * halfExtents.y - vector * halfExtents.z;
					Vector3 vector10 = origin + vector3 * halfExtents.x - vector2 * halfExtents.y + vector * halfExtents.z;
					Vector3 vector11 = origin - vector3 * halfExtents.x - vector2 * halfExtents.y + vector * halfExtents.z;
					Debug.DrawLine(vector4, vector4 + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(vector5, vector5 + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(vector6, vector6 + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(vector7, vector7 + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(vector8, vector8 + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(vector9, vector9 + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(vector10, vector10 + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(vector11, vector11 + direction * maxDistance, color, drawDuration);
				}
			}
			if (flag2)
			{
				if (drawType == CastDrawType.Minimal)
				{
					GLDebug.DrawLine(origin, origin + direction * maxDistance, color, drawDuration, depthTest: true);
				}
				else
				{
					Vector3 vector12 = orientation * Vector3.forward;
					Vector3 vector13 = orientation * Vector3.up;
					Vector3 vector14 = orientation * Vector3.right;
					Vector3 vector15 = origin + vector14 * halfExtents.x + vector13 * halfExtents.y - vector12 * halfExtents.z;
					Vector3 vector16 = origin - vector14 * halfExtents.x + vector13 * halfExtents.y - vector12 * halfExtents.z;
					Vector3 vector17 = origin + vector14 * halfExtents.x + vector13 * halfExtents.y + vector12 * halfExtents.z;
					Vector3 vector18 = origin - vector14 * halfExtents.x + vector13 * halfExtents.y + vector12 * halfExtents.z;
					Vector3 vector19 = origin + vector14 * halfExtents.x - vector13 * halfExtents.y - vector12 * halfExtents.z;
					Vector3 vector20 = origin - vector14 * halfExtents.x - vector13 * halfExtents.y - vector12 * halfExtents.z;
					Vector3 vector21 = origin + vector14 * halfExtents.x - vector13 * halfExtents.y + vector12 * halfExtents.z;
					Vector3 vector22 = origin - vector14 * halfExtents.x - vector13 * halfExtents.y + vector12 * halfExtents.z;
					GLDebug.DrawLine(vector15, vector15 + direction * maxDistance, color, drawDuration);
					GLDebug.DrawLine(vector16, vector16 + direction * maxDistance, color, drawDuration);
					GLDebug.DrawLine(vector17, vector17 + direction * maxDistance, color, drawDuration);
					GLDebug.DrawLine(vector18, vector18 + direction * maxDistance, color, drawDuration);
					GLDebug.DrawLine(vector19, vector19 + direction * maxDistance, color, drawDuration);
					GLDebug.DrawLine(vector20, vector20 + direction * maxDistance, color, drawDuration);
					GLDebug.DrawLine(vector21, vector21 + direction * maxDistance, color, drawDuration);
					GLDebug.DrawLine(vector22, vector22 + direction * maxDistance, color, drawDuration);
				}
			}
			DebugBox(origin, halfExtents, Physics.M_castColor, orientation, drawDuration, preview, drawDepth);
			DebugBox(origin + direction * maxDistance, halfExtents, color, orientation, drawDuration, preview, drawDepth);
		}

		internal static void DebugBox(Vector3 origin, Vector3 halfExtents, Color color, Quaternion orientation, float drawDuration = 0f, PreviewCondition preview = PreviewCondition.Editor, bool drawDepth = false)
		{
			Vector3 vector = orientation * Vector3.forward;
			Vector3 vector2 = orientation * Vector3.up;
			Vector3 vector3 = orientation * Vector3.right;
			Vector3 start = origin + vector3 * halfExtents.x + vector2 * halfExtents.y - vector * halfExtents.z;
			Vector3 vector4 = origin - vector3 * halfExtents.x + vector2 * halfExtents.y - vector * halfExtents.z;
			Vector3 vector5 = origin + vector3 * halfExtents.x + vector2 * halfExtents.y + vector * halfExtents.z;
			Vector3 vector6 = origin - vector3 * halfExtents.x + vector2 * halfExtents.y + vector * halfExtents.z;
			Vector3 vector7 = origin + vector3 * halfExtents.x - vector2 * halfExtents.y - vector * halfExtents.z;
			Vector3 end = origin - vector3 * halfExtents.x - vector2 * halfExtents.y - vector * halfExtents.z;
			Vector3 vector8 = origin + vector3 * halfExtents.x - vector2 * halfExtents.y + vector * halfExtents.z;
			Vector3 vector9 = origin - vector3 * halfExtents.x - vector2 * halfExtents.y + vector * halfExtents.z;
			bool flag = false;
			bool flag2 = false;
			switch (preview)
			{
			case PreviewCondition.Editor:
				flag = true;
				break;
			case PreviewCondition.Game:
				flag2 = true;
				break;
			case PreviewCondition.Both:
				flag = true;
				flag2 = true;
				break;
			}
			if (flag)
			{
				Debug.DrawLine(start, vector7, color, drawDuration, drawDepth);
				Debug.DrawLine(vector4, end, color, drawDuration, drawDepth);
				Debug.DrawLine(vector5, vector8, color, drawDuration, drawDepth);
				Debug.DrawLine(vector6, vector9, color, drawDuration, drawDepth);
				Debug.DrawLine(start, vector4, color, drawDuration, drawDepth);
				Debug.DrawLine(start, vector5, color, drawDuration, drawDepth);
				Debug.DrawLine(vector5, vector6, color, drawDuration, drawDepth);
				Debug.DrawLine(vector6, vector4, color, drawDuration, drawDepth);
				Debug.DrawLine(vector7, end, color, drawDuration, drawDepth);
				Debug.DrawLine(vector7, vector8, color, drawDuration, drawDepth);
				Debug.DrawLine(vector8, vector9, color, drawDuration, drawDepth);
				Debug.DrawLine(vector9, end, color, drawDuration, drawDepth);
			}
			if (flag2)
			{
				GLDebug.DrawLine(start, vector7, color, drawDuration, drawDepth);
				GLDebug.DrawLine(vector4, end, color, drawDuration, drawDepth);
				GLDebug.DrawLine(vector5, vector8, color, drawDuration, drawDepth);
				GLDebug.DrawLine(vector6, vector9, color, drawDuration, drawDepth);
				GLDebug.DrawLine(start, vector4, color, drawDuration, drawDepth);
				GLDebug.DrawLine(start, vector5, color, drawDuration, drawDepth);
				GLDebug.DrawLine(vector5, vector6, color, drawDuration, drawDepth);
				GLDebug.DrawLine(vector6, vector4, color, drawDuration, drawDepth);
				GLDebug.DrawLine(vector7, end, color, drawDuration, drawDepth);
				GLDebug.DrawLine(vector7, vector8, color, drawDuration, drawDepth);
				GLDebug.DrawLine(vector8, vector9, color, drawDuration, drawDepth);
				GLDebug.DrawLine(vector9, end, color, drawDuration, drawDepth);
			}
		}

		internal static void DebugOneSidedCapsuleCast(Vector3 baseSphere, Vector3 endSphere, Vector3 direction, float maxDistance, Color color, float radius = 1f, float drawDuration = 0f, CastDrawType drawType = CastDrawType.Minimal, PreviewCondition preview = PreviewCondition.Editor, bool drawDepth = false)
		{
			bool flag = false;
			bool flag2 = false;
			switch (preview)
			{
			case PreviewCondition.Editor:
				flag = true;
				break;
			case PreviewCondition.Game:
				flag2 = true;
				break;
			case PreviewCondition.Both:
				flag = true;
				flag2 = true;
				break;
			}
			Vector3 vector = (baseSphere + endSphere) / 2f;
			DebugOneSidedCapsule(baseSphere, endSphere, Physics.M_castColor, radius, colorizeBase: true, drawDuration, preview, drawDepth);
			if (flag)
			{
				if (drawType == CastDrawType.Minimal)
				{
					Debug.DrawLine(vector, vector + direction * maxDistance, color, drawDuration);
				}
				else
				{
					Vector3 vector2 = (endSphere - baseSphere).normalized;
					if (vector2 == Vector3.zero)
					{
						vector2 = Vector3.up;
					}
					Vector3 rhs = Vector3.Slerp(vector2, -vector2, 0.5f);
					Vector3 normalized = Vector3.Cross(vector2, rhs).normalized;
					Debug.DrawLine(baseSphere + normalized * radius, baseSphere + normalized * radius + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(endSphere + normalized * radius, endSphere + normalized * radius + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(baseSphere - normalized * radius, baseSphere - normalized * radius + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(endSphere - normalized * radius, endSphere - normalized * radius + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(endSphere + vector2 * radius, endSphere + vector2 * radius + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(baseSphere - vector2 * radius, baseSphere - vector2 * radius + direction * maxDistance, color, drawDuration);
				}
			}
			if (flag2)
			{
				if (drawType == CastDrawType.Minimal)
				{
					GLDebug.DrawLine(vector, vector + direction * maxDistance, color, drawDuration, depthTest: true);
				}
				else
				{
					Vector3 vector3 = (endSphere - baseSphere).normalized;
					if (vector3 == Vector3.zero)
					{
						vector3 = Vector3.up;
					}
					Vector3 rhs2 = Vector3.Slerp(vector3, -vector3, 0.5f);
					Vector3 normalized2 = Vector3.Cross(vector3, rhs2).normalized;
					GLDebug.DrawLine(baseSphere + normalized2 * radius, baseSphere + normalized2 * radius + direction * maxDistance, color, drawDuration);
					GLDebug.DrawLine(endSphere + normalized2 * radius, endSphere + normalized2 * radius + direction * maxDistance, color, drawDuration);
					GLDebug.DrawLine(baseSphere - normalized2 * radius, baseSphere - normalized2 * radius + direction * maxDistance, color, drawDuration);
					GLDebug.DrawLine(endSphere - normalized2 * radius, endSphere - normalized2 * radius + direction * maxDistance, color, drawDuration);
					GLDebug.DrawLine(endSphere + vector3 * radius, endSphere + vector3 * radius + direction * maxDistance, color, drawDuration);
					GLDebug.DrawLine(baseSphere - vector3 * radius, baseSphere - vector3 * radius + direction * maxDistance, color, drawDuration);
				}
			}
			DebugOneSidedCapsule(baseSphere + direction * maxDistance, endSphere + direction * maxDistance, color, radius, colorizeBase: true, drawDuration, preview, drawDepth);
		}

		internal static void DebugOneSidedCapsule(Vector3 baseSphere, Vector3 endSphere, Color color, float radius = 1f, bool colorizeBase = false, float drawDuration = 0f, PreviewCondition preview = PreviewCondition.Editor, bool drawDepth = false)
		{
			Vector3 vector = (endSphere - baseSphere).normalized * radius;
			if (vector == Vector3.zero)
			{
				vector = Vector3.up;
			}
			Vector3 rhs = Vector3.Slerp(vector, -vector, 0.5f);
			Vector3 vector2 = Vector3.Cross(vector, rhs).normalized * radius;
			bool flag = false;
			bool flag2 = false;
			switch (preview)
			{
			case PreviewCondition.Editor:
				flag = true;
				break;
			case PreviewCondition.Game:
				flag2 = true;
				break;
			case PreviewCondition.Both:
				flag = true;
				flag2 = true;
				break;
			}
			if (flag)
			{
				Debug.DrawLine(baseSphere + vector2, endSphere + vector2, color, drawDuration, drawDepth);
				Debug.DrawLine(baseSphere - vector2, endSphere - vector2, color, drawDuration, drawDepth);
				for (int i = 1; i < 26; i++)
				{
					Debug.DrawLine(Vector3.Slerp(vector2, -vector, (float)i / 25f) + baseSphere, Vector3.Slerp(vector2, -vector, (float)(i - 1) / 25f) + baseSphere, colorizeBase ? color : Color.red, drawDuration, drawDepth);
					Debug.DrawLine(Vector3.Slerp(-vector2, -vector, (float)i / 25f) + baseSphere, Vector3.Slerp(-vector2, -vector, (float)(i - 1) / 25f) + baseSphere, colorizeBase ? color : Color.red, drawDuration, drawDepth);
					Debug.DrawLine(Vector3.Slerp(vector2, vector, (float)i / 25f) + endSphere, Vector3.Slerp(vector2, vector, (float)(i - 1) / 25f) + endSphere, color, drawDuration, drawDepth);
					Debug.DrawLine(Vector3.Slerp(-vector2, vector, (float)i / 25f) + endSphere, Vector3.Slerp(-vector2, vector, (float)(i - 1) / 25f) + endSphere, color, drawDuration, drawDepth);
				}
			}
			if (flag2)
			{
				GLDebug.DrawLine(baseSphere + vector2, endSphere + vector2, color, drawDuration, drawDepth);
				GLDebug.DrawLine(baseSphere - vector2, endSphere - vector2, color, drawDuration, drawDepth);
				for (int j = 1; j < 26; j++)
				{
					GLDebug.DrawLine(Vector3.Slerp(vector2, -vector, (float)j / 25f) + baseSphere, Vector3.Slerp(vector2, -vector, (float)(j - 1) / 25f) + baseSphere, colorizeBase ? color : Color.red, drawDuration, drawDepth);
					GLDebug.DrawLine(Vector3.Slerp(-vector2, -vector, (float)j / 25f) + baseSphere, Vector3.Slerp(-vector2, -vector, (float)(j - 1) / 25f) + baseSphere, colorizeBase ? color : Color.red, drawDuration, drawDepth);
					GLDebug.DrawLine(Vector3.Slerp(vector2, vector, (float)j / 25f) + endSphere, Vector3.Slerp(vector2, vector, (float)(j - 1) / 25f) + endSphere, color, drawDuration, drawDepth);
					GLDebug.DrawLine(Vector3.Slerp(-vector2, vector, (float)j / 25f) + endSphere, Vector3.Slerp(-vector2, vector, (float)(j - 1) / 25f) + endSphere, color, drawDuration, drawDepth);
				}
			}
		}

		internal static void DebugCapsuleCast(Vector3 baseSphere, Vector3 endSphere, Vector3 direction, float maxDistance, Color color, float radius = 1f, float drawDuration = 0f, CastDrawType drawType = CastDrawType.Minimal, PreviewCondition preview = PreviewCondition.Editor, bool drawDepth = false)
		{
			bool flag = false;
			bool flag2 = false;
			switch (preview)
			{
			case PreviewCondition.Editor:
				flag = true;
				break;
			case PreviewCondition.Game:
				flag2 = true;
				break;
			case PreviewCondition.Both:
				flag = true;
				flag2 = true;
				break;
			}
			Vector3 vector = (baseSphere + endSphere) / 2f;
			DebugCapsule(baseSphere, endSphere, Physics.M_castColor, radius, colorizeBase: true, drawDuration, preview, drawDepth);
			if (flag)
			{
				if (drawType == CastDrawType.Minimal)
				{
					Debug.DrawLine(vector, vector + direction * maxDistance, color, drawDuration);
				}
				else
				{
					Vector3 vector2 = (endSphere - baseSphere).normalized;
					if (vector2 == Vector3.zero)
					{
						vector2 = Vector3.up;
					}
					Vector3 vector3 = Vector3.Slerp(vector2, -vector2, 0.5f);
					Vector3 normalized = Vector3.Cross(vector2, vector3).normalized;
					Debug.DrawLine(baseSphere + normalized * radius, baseSphere + normalized * radius + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(endSphere + normalized * radius, endSphere + normalized * radius + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(baseSphere - normalized * radius, baseSphere - normalized * radius + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(endSphere - normalized * radius, endSphere - normalized * radius + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(baseSphere + vector3 * radius, baseSphere + vector3 * radius + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(endSphere + vector3 * radius, endSphere + vector3 * radius + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(baseSphere - vector3 * radius, baseSphere - vector3 * radius + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(endSphere - vector3 * radius, endSphere - vector3 * radius + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(endSphere + vector2 * radius, endSphere + vector2 * radius + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(baseSphere - vector2 * radius, baseSphere - vector2 * radius + direction * maxDistance, color, drawDuration);
				}
			}
			if (flag2)
			{
				if (drawType == CastDrawType.Minimal)
				{
					GLDebug.DrawLine(vector, vector + direction * maxDistance, color, drawDuration, depthTest: true);
				}
				else
				{
					Vector3 vector4 = (endSphere - baseSphere).normalized;
					if (vector4 == Vector3.zero)
					{
						vector4 = Vector3.up;
					}
					Vector3 vector5 = Vector3.Slerp(vector4, -vector4, 0.5f);
					Vector3 normalized2 = Vector3.Cross(vector4, vector5).normalized;
					GLDebug.DrawLine(baseSphere + normalized2 * radius, baseSphere + normalized2 * radius + direction * maxDistance, color, drawDuration);
					GLDebug.DrawLine(endSphere + normalized2 * radius, endSphere + normalized2 * radius + direction * maxDistance, color, drawDuration);
					GLDebug.DrawLine(baseSphere - normalized2 * radius, baseSphere - normalized2 * radius + direction * maxDistance, color, drawDuration);
					GLDebug.DrawLine(endSphere - normalized2 * radius, endSphere - normalized2 * radius + direction * maxDistance, color, drawDuration);
					GLDebug.DrawLine(baseSphere + vector5 * radius, baseSphere + vector5 * radius + direction * maxDistance, color, drawDuration);
					GLDebug.DrawLine(endSphere + vector5 * radius, endSphere + vector5 * radius + direction * maxDistance, color, drawDuration);
					GLDebug.DrawLine(baseSphere - vector5 * radius, baseSphere - vector5 * radius + direction * maxDistance, color, drawDuration);
					GLDebug.DrawLine(endSphere - vector5 * radius, endSphere - vector5 * radius + direction * maxDistance, color, drawDuration);
					GLDebug.DrawLine(endSphere + vector4 * radius, endSphere + vector4 * radius + direction * maxDistance, color, drawDuration);
					GLDebug.DrawLine(baseSphere - vector4 * radius, baseSphere - vector4 * radius + direction * maxDistance, color, drawDuration);
				}
			}
			DebugCapsule(baseSphere + direction * maxDistance, endSphere + direction * maxDistance, color, radius, colorizeBase: true, drawDuration, preview, drawDepth);
		}

		internal static void DebugCapsule(Vector3 baseSphere, Vector3 endSphere, Color color, float radius = 1f, bool colorizeBase = true, float drawDuration = 0f, PreviewCondition preview = PreviewCondition.Editor, bool drawDepth = false)
		{
			Vector3 vector = (endSphere - baseSphere).normalized * radius;
			if (vector == Vector3.zero)
			{
				vector = Vector3.up;
			}
			Vector3 vector2 = Vector3.Slerp(vector, -vector, 0.5f);
			Vector3 vector3 = Vector3.Cross(vector, vector2).normalized * radius;
			DebugCircle(baseSphere, vector, colorizeBase ? color : Color.red, radius, drawDuration, preview, drawDepth);
			DebugCircle(endSphere, -vector, color, radius, drawDuration, preview, drawDepth);
			bool flag = false;
			bool flag2 = false;
			switch (preview)
			{
			case PreviewCondition.Editor:
				flag = true;
				break;
			case PreviewCondition.Game:
				flag2 = true;
				break;
			case PreviewCondition.Both:
				flag = true;
				flag2 = true;
				break;
			}
			if (flag)
			{
				Debug.DrawLine(baseSphere + vector3, endSphere + vector3, color, drawDuration, drawDepth);
				Debug.DrawLine(baseSphere - vector3, endSphere - vector3, color, drawDuration, drawDepth);
				Debug.DrawLine(baseSphere + vector2, endSphere + vector2, color, drawDuration, drawDepth);
				Debug.DrawLine(baseSphere - vector2, endSphere - vector2, color, drawDuration, drawDepth);
				for (int i = 1; i < 26; i++)
				{
					Debug.DrawLine(Vector3.Slerp(vector3, vector, (float)i / 25f) + endSphere, Vector3.Slerp(vector3, vector, (float)(i - 1) / 25f) + endSphere, color, drawDuration, drawDepth);
					Debug.DrawLine(Vector3.Slerp(-vector3, vector, (float)i / 25f) + endSphere, Vector3.Slerp(-vector3, vector, (float)(i - 1) / 25f) + endSphere, color, drawDuration, drawDepth);
					Debug.DrawLine(Vector3.Slerp(vector2, vector, (float)i / 25f) + endSphere, Vector3.Slerp(vector2, vector, (float)(i - 1) / 25f) + endSphere, color, drawDuration, drawDepth);
					Debug.DrawLine(Vector3.Slerp(-vector2, vector, (float)i / 25f) + endSphere, Vector3.Slerp(-vector2, vector, (float)(i - 1) / 25f) + endSphere, color, drawDuration, drawDepth);
					Debug.DrawLine(Vector3.Slerp(vector3, -vector, (float)i / 25f) + baseSphere, Vector3.Slerp(vector3, -vector, (float)(i - 1) / 25f) + baseSphere, colorizeBase ? color : Color.red, drawDuration, drawDepth);
					Debug.DrawLine(Vector3.Slerp(-vector3, -vector, (float)i / 25f) + baseSphere, Vector3.Slerp(-vector3, -vector, (float)(i - 1) / 25f) + baseSphere, colorizeBase ? color : Color.red, drawDuration, drawDepth);
					Debug.DrawLine(Vector3.Slerp(vector2, -vector, (float)i / 25f) + baseSphere, Vector3.Slerp(vector2, -vector, (float)(i - 1) / 25f) + baseSphere, colorizeBase ? color : Color.red, drawDuration, drawDepth);
					Debug.DrawLine(Vector3.Slerp(-vector2, -vector, (float)i / 25f) + baseSphere, Vector3.Slerp(-vector2, -vector, (float)(i - 1) / 25f) + baseSphere, colorizeBase ? color : Color.red, drawDuration, drawDepth);
				}
			}
			if (flag2)
			{
				GLDebug.DrawLine(baseSphere + vector3, endSphere + vector3, color, drawDuration, drawDepth);
				GLDebug.DrawLine(baseSphere - vector3, endSphere - vector3, color, drawDuration, drawDepth);
				GLDebug.DrawLine(baseSphere + vector2, endSphere + vector2, color, drawDuration, drawDepth);
				GLDebug.DrawLine(baseSphere - vector2, endSphere - vector2, color, drawDuration, drawDepth);
				for (int j = 1; j < 26; j++)
				{
					GLDebug.DrawLine(Vector3.Slerp(vector3, vector, (float)j / 25f) + endSphere, Vector3.Slerp(vector3, vector, (float)(j - 1) / 25f) + endSphere, color, drawDuration, drawDepth);
					GLDebug.DrawLine(Vector3.Slerp(-vector3, vector, (float)j / 25f) + endSphere, Vector3.Slerp(-vector3, vector, (float)(j - 1) / 25f) + endSphere, color, drawDuration, drawDepth);
					GLDebug.DrawLine(Vector3.Slerp(vector2, vector, (float)j / 25f) + endSphere, Vector3.Slerp(vector2, vector, (float)(j - 1) / 25f) + endSphere, color, drawDuration, drawDepth);
					GLDebug.DrawLine(Vector3.Slerp(-vector2, vector, (float)j / 25f) + endSphere, Vector3.Slerp(-vector2, vector, (float)(j - 1) / 25f) + endSphere, color, drawDuration, drawDepth);
					GLDebug.DrawLine(Vector3.Slerp(vector3, -vector, (float)j / 25f) + baseSphere, Vector3.Slerp(vector3, -vector, (float)(j - 1) / 25f) + baseSphere, colorizeBase ? color : Color.red, drawDuration, drawDepth);
					GLDebug.DrawLine(Vector3.Slerp(-vector3, -vector, (float)j / 25f) + baseSphere, Vector3.Slerp(-vector3, -vector, (float)(j - 1) / 25f) + baseSphere, colorizeBase ? color : Color.red, drawDuration, drawDepth);
					GLDebug.DrawLine(Vector3.Slerp(vector2, -vector, (float)j / 25f) + baseSphere, Vector3.Slerp(vector2, -vector, (float)(j - 1) / 25f) + baseSphere, colorizeBase ? color : Color.red, drawDuration, drawDepth);
					GLDebug.DrawLine(Vector3.Slerp(-vector2, -vector, (float)j / 25f) + baseSphere, Vector3.Slerp(-vector2, -vector, (float)(j - 1) / 25f) + baseSphere, colorizeBase ? color : Color.red, drawDuration, drawDepth);
				}
			}
		}

		internal static void DebugCircleCast(Vector3 origin, Vector3 direction, float maxDistance, Color color, float radius, float drawDuration, CastDrawType drawType, PreviewCondition preview, bool drawDepth)
		{
			bool flag = false;
			bool flag2 = false;
			switch (preview)
			{
			case PreviewCondition.Editor:
				flag = true;
				break;
			case PreviewCondition.Game:
				flag2 = true;
				break;
			case PreviewCondition.Both:
				flag = true;
				flag2 = true;
				break;
			}
			DebugCircle(origin, Vector3.forward, Physics.M_castColor, radius, drawDuration, preview, drawDepth);
			if (flag)
			{
				if (drawType == CastDrawType.Minimal)
				{
					Debug.DrawLine(origin, origin + direction * maxDistance, color, drawDuration);
				}
				else
				{
					Vector3 vector = origin.normalized * radius;
					if (vector == Vector3.zero)
					{
						vector = Vector3.up;
					}
					Vector3 rhs = Vector3.Slerp(vector, -vector, 0.5f);
					Vector3 vector2 = Vector3.Cross(vector, rhs).normalized * radius;
					Debug.DrawLine(origin + vector2 * radius, origin + vector2 * radius + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(origin - vector2 * radius, origin - vector2 * radius + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(origin + vector2 * radius, origin + vector2 * radius + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(origin + vector * radius, origin + vector * radius + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(origin - vector * radius, origin - vector * radius + direction * maxDistance, color, drawDuration);
				}
			}
			if (flag2)
			{
				if (drawType == CastDrawType.Minimal)
				{
					GLDebug.DrawLine(origin, origin + direction * maxDistance, color, drawDuration, depthTest: true);
				}
				else
				{
					Vector3 vector3 = origin.normalized * radius;
					if (vector3 == Vector3.zero)
					{
						vector3 = Vector3.up;
					}
					Vector3 rhs2 = Vector3.Slerp(vector3, -vector3, 0.5f);
					Vector3 vector4 = Vector3.Cross(vector3, rhs2).normalized * radius;
					GLDebug.DrawLine(origin + vector4 * radius, origin + vector4 * radius + direction * maxDistance, color, drawDuration);
					GLDebug.DrawLine(origin - vector4 * radius, origin - vector4 * radius + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(origin + vector4 * radius, origin + vector4 * radius + direction * maxDistance, color, drawDuration);
					GLDebug.DrawLine(origin + vector3 * radius, origin + vector3 * radius + direction * maxDistance, color, drawDuration);
					GLDebug.DrawLine(origin - vector3 * radius, origin - vector3 * radius + direction * maxDistance, color, drawDuration);
				}
			}
			DebugCircle(origin + direction * maxDistance, Vector3.forward, color, radius, drawDuration, preview, drawDepth);
		}

		internal static void DebugCircle(Vector3 position, Vector3 up, Color color, float radius = 1f, float drawDuration = 0f, PreviewCondition preview = PreviewCondition.Editor, bool drawDepth = false)
		{
			Vector3 vector = up.normalized * radius;
			Vector3 rhs = Vector3.Slerp(vector, -vector, 0.5f);
			Vector3 vector2 = Vector3.Cross(vector, rhs).normalized * radius;
			Matrix4x4 matrix4x = new Matrix4x4
			{
				[0] = vector2.x,
				[1] = vector2.y,
				[2] = vector2.z,
				[4] = vector.x,
				[5] = vector.y,
				[6] = vector.z,
				[8] = rhs.x,
				[9] = rhs.y,
				[10] = rhs.z
			};
			Vector3 start = position + matrix4x.MultiplyPoint3x4(new Vector3(Mathf.Cos(0f), 0f, Mathf.Sin(0f)));
			Vector3 vector3 = Vector3.zero;
			color = ((color == default(Color)) ? Color.white : color);
			bool flag = false;
			bool flag2 = false;
			switch (preview)
			{
			case PreviewCondition.Editor:
				flag = true;
				break;
			case PreviewCondition.Game:
				flag2 = true;
				break;
			case PreviewCondition.Both:
				flag = true;
				flag2 = true;
				break;
			}
			for (int i = 0; i < 91; i++)
			{
				vector3.x = Mathf.Cos((float)(i * 4) * (MathF.PI / 180f));
				vector3.z = Mathf.Sin((float)(i * 4) * (MathF.PI / 180f));
				vector3.y = 0f;
				vector3 = position + matrix4x.MultiplyPoint3x4(vector3);
				if (flag)
				{
					Debug.DrawLine(start, vector3, color, drawDuration, drawDepth);
				}
				if (flag2)
				{
					GLDebug.DrawLine(start, vector3, color, drawDuration, drawDepth);
				}
				start = vector3;
			}
		}

		internal static void DebugPoint(Vector3 position, Color color, float scale = 0.5f, float drawDuration = 0f, PreviewCondition preview = PreviewCondition.Editor, bool drawDepth = false)
		{
			color = ((color == default(Color)) ? Color.white : color);
			bool flag = false;
			bool flag2 = false;
			switch (preview)
			{
			case PreviewCondition.Editor:
				flag = true;
				break;
			case PreviewCondition.Game:
				flag2 = true;
				break;
			case PreviewCondition.Both:
				flag = true;
				flag2 = true;
				break;
			}
			if (flag)
			{
				Debug.DrawRay(position + Vector3.up * (scale * 0.5f), -Vector3.up * scale, color, drawDuration, drawDepth);
				Debug.DrawRay(position + Vector3.right * (scale * 0.5f), -Vector3.right * scale, color, drawDuration, drawDepth);
				Debug.DrawRay(position + Vector3.forward * (scale * 0.5f), -Vector3.forward * scale, color, drawDuration, drawDepth);
			}
			if (flag2)
			{
				GLDebug.DrawRay(position + Vector3.up * (scale * 0.5f), -Vector3.up * scale, color, drawDuration, drawDepth);
				GLDebug.DrawRay(position + Vector3.right * (scale * 0.5f), -Vector3.right * scale, color, drawDuration, drawDepth);
				GLDebug.DrawRay(position + Vector3.forward * (scale * 0.5f), -Vector3.forward * scale, color, drawDuration, drawDepth);
			}
		}

		internal static void DebugSphereCast(Vector3 origin, Vector3 direction, float maxDistance, Color color, float radius, float drawDuration, CastDrawType drawType, PreviewCondition preview, bool drawDepth)
		{
			bool flag = false;
			bool flag2 = false;
			switch (preview)
			{
			case PreviewCondition.Editor:
				flag = true;
				break;
			case PreviewCondition.Game:
				flag2 = true;
				break;
			case PreviewCondition.Both:
				flag = true;
				flag2 = true;
				break;
			}
			DebugWireSphere(origin, Physics.M_castColor, radius, drawDuration, preview, drawDepth);
			if (flag)
			{
				if (drawType == CastDrawType.Minimal)
				{
					Debug.DrawLine(origin, origin + direction * maxDistance, color, drawDuration);
				}
				else
				{
					Vector3 vector = origin.normalized * radius;
					if (vector == Vector3.zero)
					{
						vector = Vector3.up;
					}
					Vector3 rhs = Vector3.Slerp(vector, -vector, 0.5f);
					Vector3 vector2 = Vector3.Cross(vector, rhs).normalized * radius;
					Debug.DrawLine(origin + vector2 * radius, origin + vector2 * radius + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(origin - vector2 * radius, origin - vector2 * radius + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(origin + vector2 * radius, origin + vector2 * radius + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(origin + vector * radius, origin + vector * radius + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(origin - vector * radius, origin - vector * radius + direction * maxDistance, color, drawDuration);
				}
			}
			if (flag2)
			{
				if (drawType == CastDrawType.Minimal)
				{
					GLDebug.DrawLine(origin, origin + direction * maxDistance, color, drawDuration, depthTest: true);
				}
				else
				{
					Vector3 vector3 = origin.normalized * radius;
					if (vector3 == Vector3.zero)
					{
						vector3 = Vector3.up;
					}
					Vector3 rhs2 = Vector3.Slerp(vector3, -vector3, 0.5f);
					Vector3 vector4 = Vector3.Cross(vector3, rhs2).normalized * radius;
					GLDebug.DrawLine(origin + vector4 * radius, origin + vector4 * radius + direction * maxDistance, color, drawDuration);
					GLDebug.DrawLine(origin - vector4 * radius, origin - vector4 * radius + direction * maxDistance, color, drawDuration);
					Debug.DrawLine(origin + vector4 * radius, origin + vector4 * radius + direction * maxDistance, color, drawDuration);
					GLDebug.DrawLine(origin + vector3 * radius, origin + vector3 * radius + direction * maxDistance, color, drawDuration);
					GLDebug.DrawLine(origin - vector3 * radius, origin - vector3 * radius + direction * maxDistance, color, drawDuration);
				}
			}
			DebugWireSphere(origin + direction * maxDistance, color, radius, drawDuration, preview, drawDepth);
		}

		internal static void DebugWireSphere(Vector3 position, Color color, float radius = 1f, float drawDuration = 0f, PreviewCondition preview = PreviewCondition.Editor, bool drawDepth = false)
		{
			float num = 10f;
			Vector3 start = new Vector3(position.x, position.y + radius * Mathf.Sin(0f), position.z + radius * Mathf.Cos(0f));
			Vector3 start2 = new Vector3(position.x + radius * Mathf.Cos(0f), position.y, position.z + radius * Mathf.Sin(0f));
			Vector3 start3 = new Vector3(position.x + radius * Mathf.Cos(0f), position.y + radius * Mathf.Sin(0f), position.z);
			bool flag = false;
			bool flag2 = false;
			switch (preview)
			{
			case PreviewCondition.Editor:
				flag = true;
				break;
			case PreviewCondition.Game:
				flag2 = true;
				break;
			case PreviewCondition.Both:
				flag = true;
				flag2 = true;
				break;
			}
			for (int i = 1; i < 37; i++)
			{
				Vector3 vector = new Vector3(position.x, position.y + radius * Mathf.Sin(num * (float)i * (MathF.PI / 180f)), position.z + radius * Mathf.Cos(num * (float)i * (MathF.PI / 180f)));
				Vector3 vector2 = new Vector3(position.x + radius * Mathf.Cos(num * (float)i * (MathF.PI / 180f)), position.y, position.z + radius * Mathf.Sin(num * (float)i * (MathF.PI / 180f)));
				Vector3 vector3 = new Vector3(position.x + radius * Mathf.Cos(num * (float)i * (MathF.PI / 180f)), position.y + radius * Mathf.Sin(num * (float)i * (MathF.PI / 180f)), position.z);
				if (flag)
				{
					Debug.DrawLine(start, vector, color, drawDuration, drawDepth);
					Debug.DrawLine(start2, vector2, color, drawDuration, drawDepth);
					Debug.DrawLine(start3, vector3, color, drawDuration, drawDepth);
				}
				if (flag2)
				{
					GLDebug.DrawLine(start, vector, color, drawDuration, drawDepth);
					GLDebug.DrawLine(start2, vector2, color, drawDuration, drawDepth);
					GLDebug.DrawLine(start3, vector3, color, drawDuration, drawDepth);
				}
				start = vector;
				start2 = vector2;
				start3 = vector3;
			}
		}
	}
}

using System;
using System.Diagnostics;
using TMPEffects.CharacterData;
using TMPEffects.Components.Animator;
using TMPEffects.TMPAnimations;
using UnityEngine;

namespace TMPEffects.Modifiers
{
	[Serializable]
	public class CharDataModifiers
	{
		[SerializeField]
		private TMPMeshModifiers meshModifiers;

		[SerializeField]
		private TMPCharacterModifiers characterModifiers;

		public TMPMeshModifiers MeshModifiers => meshModifiers;

		public TMPCharacterModifiers CharacterModifiers => characterModifiers;

		public Vector3 BL_Position { get; private set; }

		public Vector3 TL_Position { get; private set; }

		public Vector3 TR_Position { get; private set; }

		public Vector3 BR_Position { get; private set; }

		public Color32 BL_Color { get; private set; }

		public Color32 TL_Color { get; private set; }

		public Color32 TR_Color { get; private set; }

		public Color32 BR_Color { get; private set; }

		public CharDataModifiers()
		{
			meshModifiers = new TMPMeshModifiers();
			characterModifiers = new TMPCharacterModifiers();
		}

		public CharDataModifiers(CharDataModifiers original)
		{
			meshModifiers = new TMPMeshModifiers(original.meshModifiers);
			characterModifiers = new TMPCharacterModifiers(original.characterModifiers);
		}

		public void Combine(CharDataModifiers other)
		{
			meshModifiers.Combine(other.meshModifiers);
			characterModifiers.Combine(other.characterModifiers);
		}

		public void CalculateVertexColors(CharData cData, IAnimatorDataProvider context)
		{
			BL_Color = context.Modifiers.MeshModifiers.BL_Color.GetValue(cData.InitialMesh.GetColor(0));
			TL_Color = context.Modifiers.MeshModifiers.TL_Color.GetValue(cData.InitialMesh.GetColor(1));
			TR_Color = context.Modifiers.MeshModifiers.TR_Color.GetValue(cData.InitialMesh.GetColor(2));
			BR_Color = context.Modifiers.MeshModifiers.BR_Color.GetValue(cData.InitialMesh.GetColor(3));
		}

		public void CalculateVertexPositions(CharData cData, IAnimatorDataProvider context)
		{
			Vector3 vector = cData.InitialMesh.BL_Position;
			Vector3 vector2 = cData.InitialMesh.TL_Position;
			Vector3 vector3 = cData.InitialMesh.TR_Position;
			Vector3 vector4 = cData.InitialMesh.BR_Position;
			if (meshModifiers.Modifier.HasFlag(TMPMeshModifiers.ModifierFlags.Deltas))
			{
				vector += TMPAnimationUtility.ScaleVector(meshModifiers.BL_Delta, cData, context);
				vector2 += TMPAnimationUtility.ScaleVector(meshModifiers.TL_Delta, cData, context);
				vector3 += TMPAnimationUtility.ScaleVector(meshModifiers.TR_Delta, cData, context);
				vector4 += TMPAnimationUtility.ScaleVector(meshModifiers.BR_Delta, cData, context);
			}
			if (characterModifiers.Modifier.HasFlag(TMPCharacterModifiers.ModifierFlags.Scale))
			{
				vector = characterModifiers.ScaleDelta.MultiplyPoint3x4(vector - cData.InitialPosition) + cData.InitialPosition;
				vector2 = characterModifiers.ScaleDelta.MultiplyPoint3x4(vector2 - cData.InitialPosition) + cData.InitialPosition;
				vector3 = characterModifiers.ScaleDelta.MultiplyPoint3x4(vector3 - cData.InitialPosition) + cData.InitialPosition;
				vector4 = characterModifiers.ScaleDelta.MultiplyPoint3x4(vector4 - cData.InitialPosition) + cData.InitialPosition;
			}
			if (characterModifiers.Modifier.HasFlag(TMPCharacterModifiers.ModifierFlags.Rotations))
			{
				for (int i = 0; i < characterModifiers.Rotations.Count; i++)
				{
					Rotation rotation = characterModifiers.Rotations[i];
					if (!(rotation.eulerAngles == Vector3.zero))
					{
						Vector3 vector5 = cData.InitialPosition + TMPAnimationUtility.ScaleVector(rotation.pivot - cData.InitialPosition, cData, context);
						Matrix4x4 matrix4x = Matrix4x4.Rotate(Quaternion.Euler(rotation.eulerAngles));
						vector = matrix4x.MultiplyPoint3x4(vector - vector5) + vector5;
						vector2 = matrix4x.MultiplyPoint3x4(vector2 - vector5) + vector5;
						vector3 = matrix4x.MultiplyPoint3x4(vector3 - vector5) + vector5;
						vector4 = matrix4x.MultiplyPoint3x4(vector4 - vector5) + vector5;
					}
				}
			}
			if (characterModifiers.Modifier.HasFlag(TMPCharacterModifiers.ModifierFlags.PositionDelta))
			{
				Vector3 vector6 = TMPAnimationUtility.ScaleVector(characterModifiers.PositionDelta, cData, context);
				vector += vector6;
				vector2 += vector6;
				vector3 += vector6;
				vector4 += vector6;
			}
			BL_Position = vector;
			TL_Position = vector2;
			TR_Position = vector3;
			BR_Position = vector4;
		}

		public Vector3 VertexPosition(int i)
		{
			return i switch
			{
				0 => BL_Position, 
				1 => TL_Position, 
				2 => TR_Position, 
				3 => BR_Position, 
				_ => throw new IndexOutOfRangeException(), 
			};
		}

		public Color32 VertexColor(int i)
		{
			return i switch
			{
				0 => BL_Color, 
				1 => TL_Color, 
				2 => TR_Color, 
				3 => BR_Color, 
				_ => throw new IndexOutOfRangeException(), 
			};
		}

		private static Vector3 GetPreciseScale(Matrix4x4 matrix)
		{
			return new Vector3(matrix.GetColumn(0).magnitude * Mathf.Sign(matrix.m00), matrix.GetColumn(1).magnitude * Mathf.Sign(matrix.m11), matrix.GetColumn(2).magnitude * Mathf.Sign(matrix.m22));
		}

		public static void LerpUnclamped(CharData cData, IAnimatorDataProvider ctx, CharDataModifiers start, CharDataModifiers end, float t, CharDataModifiers result)
		{
			LerpCharacterModifiersUnclamped(cData, start.CharacterModifiers, end.CharacterModifiers, t, result.CharacterModifiers);
			LerpMeshModifiersUnclamped(cData, ctx, start.MeshModifiers, end.MeshModifiers, t, result.MeshModifiers);
		}

		public static void LerpUnclamped(CharData cData, CharDataModifiers modifiers, float t, CharDataModifiers result)
		{
			LerpCharacterModifiersUnclamped(cData, modifiers.CharacterModifiers, t, result.CharacterModifiers);
			LerpMeshModifiersUnclamped(cData, modifiers.MeshModifiers, t, result.MeshModifiers);
		}

		public static void LerpCharacterModifiersUnclamped(CharData cData, TMPCharacterModifiers start, TMPCharacterModifiers end, float t, TMPCharacterModifiers result)
		{
			result.ClearModifiers();
			TMPCharacterModifiers.ModifierFlags modifierFlags = end.Modifier | start.Modifier;
			if (modifierFlags.HasFlag(TMPCharacterModifiers.ModifierFlags.PositionDelta))
			{
				result.PositionDelta = Vector3.LerpUnclamped(start.PositionDelta, end.PositionDelta, t);
			}
			if (modifierFlags.HasFlag(TMPCharacterModifiers.ModifierFlags.Scale))
			{
				Vector3 preciseScale = GetPreciseScale(end.ScaleDelta);
				Vector3 vector = Vector3.LerpUnclamped(GetPreciseScale(start.ScaleDelta), preciseScale, t);
				result.ScaleDelta = Matrix4x4.Scale(vector);
			}
			if (!modifierFlags.HasFlag(TMPCharacterModifiers.ModifierFlags.Rotations))
			{
				return;
			}
			try
			{
				for (int i = 0; i < start.Rotations.Count; i++)
				{
					Rotation rotation = start.Rotations[i];
					result.AddRotation(new Rotation(Vector3.LerpUnclamped(rotation.eulerAngles, cData.InitialRotation.eulerAngles, t), rotation.pivot));
				}
				for (int j = 0; j < end.Rotations.Count; j++)
				{
					Rotation rotation2 = end.Rotations[j];
					result.AddRotation(new Rotation(Vector3.LerpUnclamped(cData.InitialRotation.eulerAngles, rotation2.eulerAngles, t), rotation2.pivot));
				}
			}
			catch
			{
				StackTrace stackTrace = new StackTrace();
				TMPEffectsBugReport.BugReportPrompt("Tried to add to many with " + end.Rotations.Count + ": " + stackTrace.ToString());
			}
		}

		public static void LerpCharacterModifiersUnclamped(CharData cData, TMPCharacterModifiers modifiers, float t, TMPCharacterModifiers result)
		{
			if (modifiers.Modifier.HasFlag(TMPCharacterModifiers.ModifierFlags.PositionDelta))
			{
				result.PositionDelta = modifiers.PositionDelta * t;
			}
			if (modifiers.Modifier.HasFlag(TMPCharacterModifiers.ModifierFlags.Rotations))
			{
				try
				{
					for (int i = 0; i < modifiers.Rotations.Count; i++)
					{
						Rotation rotation = modifiers.Rotations[i];
						result.AddRotation(new Rotation(Vector3.LerpUnclamped(cData.InitialRotation.eulerAngles, rotation.eulerAngles, t), rotation.pivot));
					}
				}
				catch (Exception ex)
				{
					TMPEffectsBugReport.BugReportPrompt("Tried to add too many with " + modifiers.Rotations.Count + "; " + result.Rotations.Count + ":\n" + ex);
				}
			}
			if (modifiers.Modifier.HasFlag(TMPCharacterModifiers.ModifierFlags.Scale))
			{
				Vector3 preciseScale = GetPreciseScale(modifiers.ScaleDelta);
				Vector3 vector = Vector3.LerpUnclamped(cData.InitialScale, preciseScale, t);
				result.ScaleDelta = Matrix4x4.Scale(vector);
			}
		}

		public static void LerpMeshModifiersUnclamped(CharData cData, IAnimatorDataProvider ctx, TMPMeshModifiers start, TMPMeshModifiers end, float t, TMPMeshModifiers result)
		{
			result.ClearModifiers();
			TMPMeshModifiers.ModifierFlags modifierFlags = start.Modifier | end.Modifier;
			if (modifierFlags.HasFlag(TMPMeshModifiers.ModifierFlags.Deltas))
			{
				result.BL_Delta = Vector3.LerpUnclamped(start.BL_Delta, end.BL_Delta, t);
				result.TL_Delta = Vector3.LerpUnclamped(start.TL_Delta, end.TL_Delta, t);
				result.TR_Delta = Vector3.LerpUnclamped(start.TR_Delta, end.TR_Delta, t);
				result.BR_Delta = Vector3.LerpUnclamped(start.BR_Delta, end.BR_Delta, t);
			}
			if (end.Modifier.HasFlag(TMPMeshModifiers.ModifierFlags.Colors))
			{
				if (start.Modifier.HasFlag(TMPMeshModifiers.ModifierFlags.Colors))
				{
					if (cData.info.index == 2)
					{
						UnityEngine.Debug.Log("option 0; end: " + end.Modifier.ToString() + " start: " + start.Modifier);
					}
					result.BL_Color = ColorOverride.LerpUnclamped(start.BL_Color, end.BL_Color, t);
					result.TL_Color = ColorOverride.LerpUnclamped(start.TL_Color, end.TL_Color, t);
					result.TR_Color = ColorOverride.LerpUnclamped(start.TR_Color, end.TR_Color, t);
					result.BR_Color = ColorOverride.LerpUnclamped(start.BR_Color, end.BR_Color, t);
				}
				else if (cData.MeshModifiers.Modifier.HasFlag(TMPMeshModifiers.ModifierFlags.Colors))
				{
					if (cData.info.index == 2)
					{
						UnityEngine.Debug.Log("option 1");
					}
					result.BL_Color = ColorOverride.LerpUnclamped(cData.MeshModifiers.BL_Color, end.BL_Color, t);
					result.TL_Color = ColorOverride.LerpUnclamped(cData.MeshModifiers.TL_Color, end.TL_Color, t);
					result.TR_Color = ColorOverride.LerpUnclamped(cData.MeshModifiers.TR_Color, end.TR_Color, t);
					result.BR_Color = ColorOverride.LerpUnclamped(cData.MeshModifiers.BR_Color, end.BR_Color, t);
				}
				else if (ctx.Modifiers.MeshModifiers.Modifier.HasFlag(TMPMeshModifiers.ModifierFlags.Colors))
				{
					if (cData.info.index == 2)
					{
						UnityEngine.Debug.Log("option 2");
					}
					result.BL_Color = ColorOverride.LerpUnclamped(ctx.Modifiers.MeshModifiers.BL_Color, end.BL_Color, t);
					result.TL_Color = ColorOverride.LerpUnclamped(ctx.Modifiers.MeshModifiers.TL_Color, end.TL_Color, t);
					result.TR_Color = ColorOverride.LerpUnclamped(ctx.Modifiers.MeshModifiers.TR_Color, end.TR_Color, t);
					result.BR_Color = ColorOverride.LerpUnclamped(ctx.Modifiers.MeshModifiers.BR_Color, end.BR_Color, t);
				}
				else
				{
					if (cData.info.index == 2)
					{
						UnityEngine.Debug.Log("option 3");
					}
					result.BL_Color = ColorOverride.LerpUnclamped(cData.InitialMesh.BL_Color, end.BL_Color, t);
					result.TL_Color = ColorOverride.LerpUnclamped(cData.InitialMesh.TL_Color, end.TL_Color, t);
					result.TR_Color = ColorOverride.LerpUnclamped(cData.InitialMesh.TR_Color, end.TR_Color, t);
					result.BR_Color = ColorOverride.LerpUnclamped(cData.InitialMesh.BR_Color, end.BR_Color, t);
				}
			}
			if (modifierFlags.HasFlag(TMPMeshModifiers.ModifierFlags.UVs))
			{
				Vector3 value = start.BL_UV0.GetValue(cData.InitialMesh.BL_UV0);
				Vector3 value2 = end.BL_UV0.GetValue(cData.InitialMesh.BL_UV0);
				result.BL_UV0 = new Vector3Override(Vector3.LerpUnclamped(value, value2, t));
				value = start.TL_UV0.GetValue(cData.InitialMesh.TL_UV0);
				value2 = end.TL_UV0.GetValue(cData.InitialMesh.TL_UV0);
				result.TL_UV0 = new Vector3Override(Vector3.LerpUnclamped(value, value2, t));
				value = start.TR_UV0.GetValue(cData.InitialMesh.TR_UV0);
				value2 = end.TR_UV0.GetValue(cData.InitialMesh.TR_UV0);
				result.TR_UV0 = new Vector3Override(Vector3.LerpUnclamped(value, value2, t));
				value = start.BR_UV0.GetValue(cData.InitialMesh.BR_UV0);
				value2 = end.BR_UV0.GetValue(cData.InitialMesh.BR_UV0);
				result.BR_UV0 = new Vector3Override(Vector3.LerpUnclamped(value, value2, t));
			}
		}

		public static void LerpMeshModifiersUnclamped(CharData cData, TMPMeshModifiers modifiers, float t, TMPMeshModifiers result)
		{
			if (modifiers.Modifier.HasFlag(TMPMeshModifiers.ModifierFlags.Deltas))
			{
				result.BL_Delta = modifiers.BL_Delta * t;
				result.TL_Delta = modifiers.TL_Delta * t;
				result.TR_Delta = modifiers.TR_Delta * t;
				result.BR_Delta = modifiers.BR_Delta * t;
			}
			if (modifiers.Modifier.HasFlag(TMPMeshModifiers.ModifierFlags.Colors))
			{
				result.BL_Color = ColorOverride.LerpUnclamped(cData.InitialMesh.BL_Color, modifiers.BL_Color, t);
				result.TL_Color = ColorOverride.LerpUnclamped(cData.InitialMesh.TL_Color, modifiers.TL_Color, t);
				result.TR_Color = ColorOverride.LerpUnclamped(cData.InitialMesh.TR_Color, modifiers.TR_Color, t);
				result.BR_Color = ColorOverride.LerpUnclamped(cData.InitialMesh.BR_Color, modifiers.BR_Color, t);
			}
			if (modifiers.Modifier.HasFlag(TMPMeshModifiers.ModifierFlags.UVs))
			{
				Vector3 value = modifiers.BL_UV0.GetValue(cData.InitialMesh.BL_UV0);
				result.BL_UV0 = new Vector3Override(Vector3.LerpUnclamped(cData.InitialMesh.BL_UV0, value, t));
				value = modifiers.TL_UV0.GetValue(cData.InitialMesh.TL_UV0);
				result.TL_UV0 = new Vector3Override(Vector3.LerpUnclamped(cData.InitialMesh.TL_UV0, value, t));
				value = modifiers.TR_UV0.GetValue(cData.InitialMesh.TR_UV0);
				result.TR_UV0 = new Vector3Override(Vector3.LerpUnclamped(cData.InitialMesh.TR_UV0, value, t));
				value = modifiers.BR_UV0.GetValue(cData.InitialMesh.BR_UV0);
				result.BR_UV0 = new Vector3Override(Vector3.LerpUnclamped(cData.InitialMesh.BR_UV0, value, t));
			}
		}

		public void Reset()
		{
			meshModifiers.ClearModifiers();
			characterModifiers.ClearModifiers();
		}
	}
}

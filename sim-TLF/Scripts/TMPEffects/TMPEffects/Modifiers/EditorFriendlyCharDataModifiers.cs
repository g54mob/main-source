using System;
using System.Collections.Generic;
using TMPEffects.CharacterData;
using TMPEffects.Components.Animator;
using TMPEffects.Parameters;
using TMPEffects.TMPAnimations;
using UnityEngine;

namespace TMPEffects.Modifiers
{
	[Serializable]
	public class EditorFriendlyCharDataModifiers
	{
		public TMPParameterTypes.TypedVector3 Position = new TMPParameterTypes.TypedVector3(TMPParameterTypes.VectorType.Offset, Vector3.zero);

		public Vector3 Scale = Vector3.one;

		public List<EditorFriendlyRotation> Rotations = new List<EditorFriendlyRotation>();

		public TMPParameterTypes.TypedVector3 BL_Position = new TMPParameterTypes.TypedVector3(TMPParameterTypes.VectorType.Offset, Vector3.zero);

		public TMPParameterTypes.TypedVector3 TL_Position = new TMPParameterTypes.TypedVector3(TMPParameterTypes.VectorType.Offset, Vector3.zero);

		public TMPParameterTypes.TypedVector3 TR_Position = new TMPParameterTypes.TypedVector3(TMPParameterTypes.VectorType.Offset, Vector3.zero);

		public TMPParameterTypes.TypedVector3 BR_Position = new TMPParameterTypes.TypedVector3(TMPParameterTypes.VectorType.Offset, Vector3.zero);

		public ColorOverride BL_Color;

		public ColorOverride TL_Color;

		public ColorOverride TR_Color;

		public ColorOverride BR_Color;

		public TMPParameterTypes.TypedVector3 BL_UV0 = new TMPParameterTypes.TypedVector3(TMPParameterTypes.VectorType.Offset, Vector3.zero);

		public TMPParameterTypes.TypedVector3 TL_UV0 = new TMPParameterTypes.TypedVector3(TMPParameterTypes.VectorType.Offset, Vector3.zero);

		public TMPParameterTypes.TypedVector3 TR_UV0 = new TMPParameterTypes.TypedVector3(TMPParameterTypes.VectorType.Offset, Vector3.zero);

		public TMPParameterTypes.TypedVector3 BR_UV0 = new TMPParameterTypes.TypedVector3(TMPParameterTypes.VectorType.Offset, Vector3.zero);

		public EditorFriendlyCharDataModifiers()
		{
		}

		public EditorFriendlyCharDataModifiers(EditorFriendlyCharDataModifiers other)
		{
			Position = other.Position;
			Scale = other.Scale;
			Rotations = new List<EditorFriendlyRotation>(other.Rotations);
			BL_Position = other.BL_Position;
			TL_Position = other.TL_Position;
			TR_Position = other.TR_Position;
			BR_Position = other.BR_Position;
			BL_Color = other.BL_Color;
			TL_Color = other.TL_Color;
			TR_Color = other.TR_Color;
			BR_Color = other.BR_Color;
			BL_UV0 = other.BL_UV0;
			TL_UV0 = other.TL_UV0;
			TR_UV0 = other.TR_UV0;
			BR_UV0 = other.BR_UV0;
		}

		public void ToCharDataModifiers(CharData cData, IAnimationContext ctx, CharDataModifiers result)
		{
			ToCharDataModifiers(cData, ctx.AnimatorContext, result);
		}

		public void ToCharDataModifiers(CharData cData, IAnimatorContext ctx, CharDataModifiers result)
		{
			Vector3 vector = Position.ToDelta(cData, ctx);
			if (vector != Vector3.zero)
			{
				result.CharacterModifiers.PositionDelta = vector;
			}
			if (Scale != Vector3.one)
			{
				result.CharacterModifiers.ScaleDelta = Matrix4x4.Scale(Scale);
			}
			if (Rotations.Count > 0)
			{
				for (int i = 0; i < Rotations.Count; i++)
				{
					EditorFriendlyRotation editorFriendlyRotation = Rotations[i];
					if (editorFriendlyRotation.eulerAngles != Vector3.zero)
					{
						Vector3 zero = Vector3.zero;
						vector = editorFriendlyRotation.pivot.ToPosition(cData, ctx);
						zero = vector;
						result.CharacterModifiers.AddRotation(new Rotation(editorFriendlyRotation.eulerAngles, zero));
					}
				}
			}
			if ((BL_Color.Override | TL_Color.Override | TR_Color.Override | BR_Color.Override) != ColorOverride.OverrideMode.None)
			{
				result.MeshModifiers.BL_Color = BL_Color;
				result.MeshModifiers.TL_Color = TL_Color;
				result.MeshModifiers.TR_Color = TR_Color;
				result.MeshModifiers.BR_Color = BR_Color;
			}
			vector = BL_Position.ToDelta(cData, ctx, cData.InitialMesh.BL_Position);
			if (vector != Vector3.zero)
			{
				result.MeshModifiers.BL_Delta = vector;
			}
			vector = TL_Position.ToDelta(cData, ctx, cData.InitialMesh.TL_Position);
			if (vector != Vector3.zero)
			{
				result.MeshModifiers.TL_Delta = vector;
			}
			vector = TR_Position.ToDelta(cData, ctx, cData.InitialMesh.TR_Position);
			if (vector != Vector3.zero)
			{
				result.MeshModifiers.TR_Delta = vector;
			}
			vector = BR_Position.ToDelta(cData, ctx, cData.InitialMesh.BR_Position);
			if (vector != Vector3.zero)
			{
				result.MeshModifiers.BR_Delta = vector;
			}
		}
	}
}

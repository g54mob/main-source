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
		public TMPParameterTypes.TypedVector3 Position;

		public Vector3 Scale;

		public List<EditorFriendlyRotation> Rotations;

		public TMPParameterTypes.TypedVector3 BL_Position;

		public TMPParameterTypes.TypedVector3 TL_Position;

		public TMPParameterTypes.TypedVector3 TR_Position;

		public TMPParameterTypes.TypedVector3 BR_Position;

		public ColorOverride BL_Color;

		public ColorOverride TL_Color;

		public ColorOverride TR_Color;

		public ColorOverride BR_Color;

		public TMPParameterTypes.TypedVector3 BL_UV0;

		public TMPParameterTypes.TypedVector3 TL_UV0;

		public TMPParameterTypes.TypedVector3 TR_UV0;

		public TMPParameterTypes.TypedVector3 BR_UV0;

		public EditorFriendlyCharDataModifiers()
		{
		}

		public EditorFriendlyCharDataModifiers(EditorFriendlyCharDataModifiers other)
		{
		}

		public void ToCharDataModifiers(CharData cData, IAnimationContext ctx, CharDataModifiers result)
		{
		}

		public void ToCharDataModifiers(CharData cData, IAnimatorContext ctx, CharDataModifiers result)
		{
		}
	}
}

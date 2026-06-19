using System;
using TMPEffects.CharacterData;
using TMPEffects.Components.Animator;
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

		public TMPMeshModifiers MeshModifiers => null;

		public TMPCharacterModifiers CharacterModifiers => null;

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
		}

		public CharDataModifiers(CharDataModifiers original)
		{
		}

		public void Combine(CharDataModifiers other)
		{
		}

		public void CalculateVertexColors(CharData cData, IAnimatorDataProvider context)
		{
		}

		public void CalculateVertexPositions(CharData cData, IAnimatorDataProvider context)
		{
		}

		public Vector3 VertexPosition(int i)
		{
			return default(Vector3);
		}

		public Color32 VertexColor(int i)
		{
			return default(Color32);
		}

		private static Vector3 GetPreciseScale(Matrix4x4 matrix)
		{
			return default(Vector3);
		}

		public static void LerpUnclamped(CharData cData, IAnimatorDataProvider ctx, CharDataModifiers start, CharDataModifiers end, float t, CharDataModifiers result)
		{
		}

		public static void LerpUnclamped(CharData cData, CharDataModifiers modifiers, float t, CharDataModifiers result)
		{
		}

		public static void LerpCharacterModifiersUnclamped(CharData cData, TMPCharacterModifiers start, TMPCharacterModifiers end, float t, TMPCharacterModifiers result)
		{
		}

		public static void LerpCharacterModifiersUnclamped(CharData cData, TMPCharacterModifiers modifiers, float t, TMPCharacterModifiers result)
		{
		}

		public static void LerpMeshModifiersUnclamped(CharData cData, IAnimatorDataProvider ctx, TMPMeshModifiers start, TMPMeshModifiers end, float t, TMPMeshModifiers result)
		{
		}

		public static void LerpMeshModifiersUnclamped(CharData cData, TMPMeshModifiers modifiers, float t, TMPMeshModifiers result)
		{
		}

		public void Reset()
		{
		}
	}
}

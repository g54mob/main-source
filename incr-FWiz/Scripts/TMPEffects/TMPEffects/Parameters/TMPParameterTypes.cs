using System;
using TMPEffects.CharacterData;
using TMPEffects.Components.Animator;
using TMPEffects.TMPAnimations;
using UnityEngine;

namespace TMPEffects.Parameters
{
	public static class TMPParameterTypes
	{
		public enum OffsetType
		{
			SegmentIndex = 0,
			Index = 5,
			XPos = 10,
			YPos = 15,
			WorldXPos = 20,
			WorldYPos = 25,
			WorldZPos = 30,
			Word = 35,
			Line = 40,
			Baseline = 45
		}

		public enum VectorType
		{
			Position = 0,
			Offset = 1,
			Anchor = 2
		}

		[Serializable]
		public struct TypedVector2
		{
			public Vector2 vector;

			public VectorType type;

			public TypedVector2(VectorType type, Vector2 vector)
			{
				this.vector = default(Vector2);
				this.type = default(VectorType);
			}

			public static implicit operator TypedVector2(TypedVector3 v)
			{
				return default(TypedVector2);
			}

			private TypedVector2 IgnoreScaling(CharData cData, IAnimationContext context)
			{
				return default(TypedVector2);
			}

			private TypedVector2 IgnoreScaling(CharData cData, IAnimatorDataProvider context)
			{
				return default(TypedVector2);
			}

			public Vector2 ToPosition(CharData cData, IAnimationContext context)
			{
				return default(Vector2);
			}

			public Vector2 ToPosition(CharData cData, IAnimationContext context, Vector2 referencePos)
			{
				return default(Vector2);
			}

			public Vector2 ToPosition(CharData cData, IAnimatorDataProvider animatorData)
			{
				return default(Vector2);
			}

			public Vector2 ToPosition(CharData cData, IAnimatorDataProvider animatorData, Vector2 referencePos)
			{
				return default(Vector2);
			}

			public Vector2 ToDelta(CharData cData, IAnimationContext context)
			{
				return default(Vector2);
			}

			public Vector2 ToDelta(CharData cData, IAnimationContext context, Vector2 referencePos)
			{
				return default(Vector2);
			}

			public Vector2 ToDelta(CharData cData, IAnimatorDataProvider animatorData)
			{
				return default(Vector2);
			}

			public Vector2 ToDelta(CharData cData, IAnimatorDataProvider animatorData, Vector2 referencePos)
			{
				return default(Vector2);
			}

			public override string ToString()
			{
				return null;
			}
		}

		[Serializable]
		public struct TypedVector3
		{
			public Vector3 vector;

			public VectorType type;

			public TypedVector3(VectorType type, Vector3 vector)
			{
				this.vector = default(Vector3);
				this.type = default(VectorType);
			}

			public bool Equals(TypedVector3 other)
			{
				return false;
			}

			public static implicit operator TypedVector3(TypedVector2 v)
			{
				return default(TypedVector3);
			}

			private TypedVector3 IgnoreScaling(CharData cData, IAnimationContext context)
			{
				return default(TypedVector3);
			}

			private TypedVector3 IgnoreScaling(CharData cData, IAnimatorDataProvider context)
			{
				return default(TypedVector3);
			}

			public Vector3 ToPosition(CharData cData, IAnimationContext context)
			{
				return default(Vector3);
			}

			public Vector3 ToPosition(CharData cData, IAnimationContext context, Vector3 referencePos)
			{
				return default(Vector3);
			}

			public Vector3 ToPosition(CharData cData, IAnimatorDataProvider animatorData)
			{
				return default(Vector3);
			}

			public Vector3 ToPosition(CharData cData, IAnimatorDataProvider animatorData, Vector3 referencePos)
			{
				return default(Vector3);
			}

			public Vector3 ToDelta(CharData cData, IAnimationContext context)
			{
				return default(Vector3);
			}

			public Vector3 ToDelta(CharData cData, IAnimationContext context, Vector3 referencePos)
			{
				return default(Vector3);
			}

			public Vector3 ToDelta(CharData cData, IAnimatorDataProvider animatorData)
			{
				return default(Vector3);
			}

			public Vector3 ToDelta(CharData cData, IAnimatorDataProvider animatorData, Vector3 referencePos)
			{
				return default(Vector3);
			}

			public override string ToString()
			{
				return null;
			}
		}
	}
}

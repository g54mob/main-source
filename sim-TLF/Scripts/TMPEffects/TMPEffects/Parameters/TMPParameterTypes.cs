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
				this.type = type;
				this.vector = vector;
			}

			public static implicit operator TypedVector2(TypedVector3 v)
			{
				return new TypedVector2
				{
					vector = v.vector,
					type = v.type
				};
			}

			private TypedVector2 IgnoreScaling(CharData cData, IAnimationContext context)
			{
				return IgnoreScaling(cData, context.AnimatorContext);
			}

			private TypedVector2 IgnoreScaling(CharData cData, IAnimatorDataProvider context)
			{
				return type switch
				{
					VectorType.Position => new TypedVector2(type, TMPAnimationUtility.GetRawPosition(vector, cData, context)), 
					VectorType.Anchor => new TypedVector2(type, vector), 
					VectorType.Offset => new TypedVector2(type, TMPAnimationUtility.GetRawDelta(vector, cData, context)), 
					_ => throw new NotImplementedException("type"), 
				};
			}

			public Vector2 ToPosition(CharData cData, IAnimationContext context)
			{
				return ToPosition(cData, context.AnimatorContext, cData.InitialPosition);
			}

			public Vector2 ToPosition(CharData cData, IAnimationContext context, Vector2 referencePos)
			{
				return ToPosition(cData, context.AnimatorContext, referencePos);
			}

			public Vector2 ToPosition(CharData cData, IAnimatorDataProvider animatorData)
			{
				return ToPosition(cData, animatorData, cData.InitialPosition);
			}

			public Vector2 ToPosition(CharData cData, IAnimatorDataProvider animatorData, Vector2 referencePos)
			{
				TypedVector2 typedVector = this;
				return type switch
				{
					VectorType.Position => typedVector.IgnoreScaling(cData, animatorData).vector, 
					VectorType.Anchor => new TypedVector2(VectorType.Position, TMPAnimationUtility.AnchorToPosition(vector, cData)).ToPosition(cData, animatorData), 
					VectorType.Offset => referencePos + vector, 
					_ => throw new NotImplementedException("type"), 
				};
			}

			public Vector2 ToDelta(CharData cData, IAnimationContext context)
			{
				return ToDelta(cData, context.AnimatorContext, cData.InitialPosition);
			}

			public Vector2 ToDelta(CharData cData, IAnimationContext context, Vector2 referencePos)
			{
				return ToDelta(cData, context.AnimatorContext, referencePos);
			}

			public Vector2 ToDelta(CharData cData, IAnimatorDataProvider animatorData)
			{
				return ToDelta(cData, animatorData, cData.InitialPosition);
			}

			public Vector2 ToDelta(CharData cData, IAnimatorDataProvider animatorData, Vector2 referencePos)
			{
				switch (type)
				{
				case VectorType.Position:
				{
					TypedVector2 typedVector = this;
					return typedVector.IgnoreScaling(cData, animatorData).vector - referencePos;
				}
				case VectorType.Anchor:
					return new TypedVector2(VectorType.Position, TMPAnimationUtility.AnchorToPosition(vector, cData)).ToDelta(cData, animatorData, referencePos);
				case VectorType.Offset:
					return vector;
				default:
					throw new NotImplementedException("type");
				}
			}

			public override string ToString()
			{
				string[] obj = new string[5] { "{ ", null, null, null, null };
				Vector2 vector = this.vector;
				obj[1] = vector.ToString();
				obj[2] = ", ";
				obj[3] = type.ToString();
				obj[4] = " }";
				return string.Concat(obj);
			}
		}

		[Serializable]
		public struct TypedVector3
		{
			public Vector3 vector;

			public VectorType type;

			public TypedVector3(VectorType type, Vector3 vector)
			{
				this.type = type;
				this.vector = vector;
			}

			public bool Equals(TypedVector3 other)
			{
				if (vector == other.vector)
				{
					return type == other.type;
				}
				return false;
			}

			public static implicit operator TypedVector3(TypedVector2 v)
			{
				return new TypedVector3
				{
					vector = v.vector,
					type = v.type
				};
			}

			private TypedVector3 IgnoreScaling(CharData cData, IAnimationContext context)
			{
				return IgnoreScaling(cData, context.AnimatorContext);
			}

			private TypedVector3 IgnoreScaling(CharData cData, IAnimatorDataProvider context)
			{
				return type switch
				{
					VectorType.Position => new TypedVector3(type, TMPAnimationUtility.GetRawPosition(vector, cData, context)), 
					VectorType.Offset => new TypedVector3(type, TMPAnimationUtility.GetRawDelta(vector, cData, context)), 
					VectorType.Anchor => this, 
					_ => throw new NotImplementedException("type"), 
				};
			}

			public Vector3 ToPosition(CharData cData, IAnimationContext context)
			{
				return ToPosition(cData, context.AnimatorContext, cData.InitialPosition);
			}

			public Vector3 ToPosition(CharData cData, IAnimationContext context, Vector3 referencePos)
			{
				return ToPosition(cData, context.AnimatorContext, referencePos);
			}

			public Vector3 ToPosition(CharData cData, IAnimatorDataProvider animatorData)
			{
				return ToPosition(cData, animatorData, cData.InitialPosition);
			}

			public Vector3 ToPosition(CharData cData, IAnimatorDataProvider animatorData, Vector3 referencePos)
			{
				TypedVector3 typedVector = this;
				return type switch
				{
					VectorType.Position => typedVector.IgnoreScaling(cData, animatorData).vector, 
					VectorType.Anchor => new TypedVector3(VectorType.Position, TMPAnimationUtility.AnchorToPosition(vector, cData)).ToPosition(cData, animatorData), 
					VectorType.Offset => referencePos + vector, 
					_ => throw new NotImplementedException("type"), 
				};
			}

			public Vector3 ToDelta(CharData cData, IAnimationContext context)
			{
				return ToDelta(cData, context.AnimatorContext, cData.InitialPosition);
			}

			public Vector3 ToDelta(CharData cData, IAnimationContext context, Vector3 referencePos)
			{
				return ToDelta(cData, context.AnimatorContext, referencePos);
			}

			public Vector3 ToDelta(CharData cData, IAnimatorDataProvider animatorData)
			{
				return ToDelta(cData, animatorData, cData.InitialPosition);
			}

			public Vector3 ToDelta(CharData cData, IAnimatorDataProvider animatorData, Vector3 referencePos)
			{
				switch (type)
				{
				case VectorType.Position:
				{
					TypedVector3 typedVector = this;
					return typedVector.IgnoreScaling(cData, animatorData).vector - referencePos;
				}
				case VectorType.Anchor:
					return new TypedVector3(VectorType.Position, TMPAnimationUtility.AnchorToPosition(vector, cData)).ToDelta(cData, animatorData, referencePos);
				case VectorType.Offset:
					return vector;
				default:
					throw new NotImplementedException("type");
				}
			}

			public override string ToString()
			{
				string[] obj = new string[5] { "{ ", null, null, null, null };
				Vector3 vector = this.vector;
				obj[1] = vector.ToString();
				obj[2] = ", ";
				obj[3] = type.ToString();
				obj[4] = " }";
				return string.Concat(obj);
			}
		}
	}
}

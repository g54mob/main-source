using System.Runtime.CompilerServices;
using ProtoBuf.Internal;

namespace ProtoBuf.Serializers
{
	internal static class SerializerFeaturesExtensions
	{
		private const SerializerFeatures CategoryMask = SerializerFeatures.CategoryMessageWrappedAtRoot;

		private const SerializerFeatures WireTypeMask = (SerializerFeatures)15;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SerializerFeatures AsFeatures(this WireType wireType)
		{
			if (wireType != WireType.None)
			{
				return (SerializerFeatures)((wireType & (WireType)15) | (WireType)16);
			}
			return SerializerFeatures.CategoryRepeated;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SerializerFeatures GetCategory(this SerializerFeatures features)
		{
			return features & SerializerFeatures.CategoryMessageWrappedAtRoot;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InheritFrom(this ref SerializerFeatures features, SerializerFeatures overrides)
		{
			if ((features & SerializerFeatures.CategoryMessageWrappedAtRoot) == 0)
			{
				features |= overrides & SerializerFeatures.CategoryMessageWrappedAtRoot;
			}
			if ((features & SerializerFeatures.WireTypeVarint) == 0)
			{
				features |= overrides & (SerializerFeatures)31;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void HintIfNeeded(this SerializerFeatures features, ref ProtoReader.State state)
		{
			if ((features & (SerializerFeatures)15) == (SerializerFeatures)8)
			{
				state.Hint(WireType.SignedVariant);
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void ThrowInvalidCategory(this SerializerFeatures features)
		{
			SerializerFeatures category = features.GetCategory();
			string message = ((category == features) ? $"The category {category} is not expected in this context" : $"The category {category} is not expected in this context (full features: {features})");
			ThrowHelper.ThrowInvalidOperationException(message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsPackedDisabled(this SerializerFeatures features)
		{
			return (features & SerializerFeatures.OptionPackedDisabled) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsRepeated(this SerializerFeatures features)
		{
			return (features & SerializerFeatures.CategoryMessageWrappedAtRoot) == 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void ThrowWireTypeNotSpecified()
		{
			ThrowHelper.ThrowInvalidOperationException("The serializer features provided do not include a wire-type");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static WireType GetWireType(this SerializerFeatures features)
		{
			if ((features & SerializerFeatures.WireTypeVarint) == 0)
			{
				ThrowWireTypeNotSpecified();
			}
			return (WireType)(features & (SerializerFeatures)15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ApplyRecursionCheck(this SerializerFeatures features)
		{
			return (features & SerializerFeatures.OptionSkipRecursionCheck) == 0;
		}
	}
}

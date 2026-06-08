using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using ProtoBuf.Internal;

namespace ProtoBuf.Serializers
{
	internal static class SerializerCache<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicMethods)] TProvider> where TProvider : class
	{
		internal static readonly TProvider InstanceField = (TProvider)Activator.CreateInstance(typeof(TProvider), nonPublic: true);

		public static ISerializer<T> GetSerializer<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>()
		{
			return SerializerCache<TProvider, T>.InstanceField;
		}
	}
	internal static class SerializerCache<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicMethods)] TProvider, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T> where TProvider : class
	{
		internal static readonly ISerializer<T> InstanceField = SerializerCache.Verify((SerializerCache<TProvider>.InstanceField as ISerializer<T>) ?? (SerializerCache<TProvider>.InstanceField as ISerializerProxy<T>)?.Serializer);

		public static ISerializer<T> Instance
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return InstanceField;
			}
		}
	}
	public static class SerializerCache
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void ThrowInvalidSerializer<T>(ISerializer<T> serializer, string message, Exception innerException = null)
		{
			string text = typeof(T).NormalizeName();
			string text2 = serializer.GetType().NormalizeName();
			string text3 = serializer.Features.ToString();
			try
			{
				ThrowHelper.ThrowInvalidOperationException("The serializer " + text2 + " for type " + text + " has invalid features: " + message + " (" + text3 + ")", innerException);
			}
			catch (InvalidOperationException ex)
			{
				ex.Data.Add("type", text);
				ex.Data.Add("serializer", text2);
				ex.Data.Add("features", text3);
				throw;
			}
		}

		internal static ISerializer<T> Verify<T>(ISerializer<T> serializer)
		{
			if (serializer == null)
			{
				return null;
			}
			try
			{
				SerializerFeatures features = serializer.Features;
				if (serializer is IRepeatedSerializer<T>)
				{
					if ((features & (SerializerFeatures)(-1)) != SerializerFeatures.CategoryRepeated)
					{
						ThrowInvalidSerializer(serializer, $"repeated serializers may only specify {SerializerFeatures.CategoryRepeated}");
					}
					return serializer;
				}
				WireType wireType = features.GetWireType();
				switch (wireType)
				{
				default:
					ThrowInvalidSerializer(serializer, $"invalid wire-type {wireType}");
					break;
				case WireType.Variant:
				case WireType.Fixed64:
				case WireType.String:
				case WireType.StartGroup:
				case WireType.Fixed32:
				case WireType.SignedVariant:
					break;
				}
				switch (features.GetCategory())
				{
				case SerializerFeatures.CategoryMessage:
				case SerializerFeatures.CategoryMessageWrappedAtRoot:
					if (TypeHelper<T>.CanBePacked)
					{
						ThrowInvalidSerializer(serializer, "message serializer specified for a type that can be 'packed'");
					}
					break;
				case SerializerFeatures.CategoryScalar:
					if (TypeHelper<T>.CanBePacked && (uint)wireType > 1u && wireType != WireType.Fixed32 && wireType != WireType.SignedVariant)
					{
						ThrowInvalidSerializer(serializer, "invalid wire-type for a type that can be 'packed'");
					}
					break;
				default:
					features.ThrowInvalidCategory();
					break;
				}
				if ((features & (SerializerFeatures.OptionPackedDisabled | SerializerFeatures.OptionClearCollection)) != SerializerFeatures.CategoryRepeated)
				{
					ThrowInvalidSerializer(serializer, $"serializers should not specify {SerializerFeatures.OptionPackedDisabled | SerializerFeatures.OptionClearCollection}");
				}
				return serializer;
			}
			catch (InvalidOperationException ex) when (!ex.Data.Contains("serializer"))
			{
				ThrowInvalidSerializer(serializer, ex.Message, ex);
				throw;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ISerializer<T> Get<TProvider, T>() where TProvider : class
		{
			return SerializerCache<TProvider, T>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object GetInstance(Type providerType, Type type)
		{
			return typeof(SerializerCache<, >).MakeGenericType(providerType, type).GetField("InstanceField", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(null);
		}
	}
}

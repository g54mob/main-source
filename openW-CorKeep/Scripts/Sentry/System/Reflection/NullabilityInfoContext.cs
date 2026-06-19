using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace System.Reflection
{
	internal sealed class NullabilityInfoContext
	{
		[Flags]
		private enum NotAnnotatedStatus
		{
			None = 0,
			Private = 1,
			Internal = 2
		}

		private readonly struct NullableAttributeStateParser
		{
			private static readonly object UnknownByte = (byte)0;

			private readonly object? _nullableAttributeArgument;

			public static NullableAttributeStateParser Unknown => new NullableAttributeStateParser(UnknownByte);

			public NullableAttributeStateParser(object? nullableAttributeArgument)
			{
				_nullableAttributeArgument = nullableAttributeArgument;
			}

			public bool ParseNullableState(int index, ref NullabilityState state)
			{
				object nullableAttributeArgument = _nullableAttributeArgument;
				if (!(nullableAttributeArgument is byte b))
				{
					if (nullableAttributeArgument is ReadOnlyCollection<CustomAttributeTypedArgument> readOnlyCollection)
					{
						ReadOnlyCollection<CustomAttributeTypedArgument> readOnlyCollection2 = readOnlyCollection;
						if (index < readOnlyCollection2.Count && readOnlyCollection2[index].Value is byte b2)
						{
							state = TranslateByte(b2);
							return true;
						}
					}
					return false;
				}
				byte b3 = b;
				state = TranslateByte(b3);
				return true;
			}
		}

		private const string CompilerServicesNameSpace = "System.Runtime.CompilerServices";

		private readonly Dictionary<Module, NotAnnotatedStatus> _publicOnlyModules = new Dictionary<Module, NotAnnotatedStatus>();

		private readonly Dictionary<MemberInfo, NullabilityState> _context = new Dictionary<MemberInfo, NullabilityState>();

		internal static bool IsSupported { get; } = !AppContext.TryGetSwitch("System.Reflection.NullabilityInfoContext.IsSupported", out var isEnabled) || isEnabled;

		private NullabilityState? GetNullableContext(MemberInfo? memberInfo)
		{
			while (memberInfo != null)
			{
				if (_context.TryGetValue(memberInfo, out var value))
				{
					return value;
				}
				foreach (CustomAttributeData customAttributesDatum in memberInfo.GetCustomAttributesData())
				{
					if (customAttributesDatum.AttributeType.Name == "NullableContextAttribute" && customAttributesDatum.AttributeType.Namespace == "System.Runtime.CompilerServices" && customAttributesDatum.ConstructorArguments.Count == 1)
					{
						value = TranslateByte(customAttributesDatum.ConstructorArguments[0].Value);
						_context.Add(memberInfo, value);
						return value;
					}
				}
				memberInfo = memberInfo.DeclaringType;
			}
			return null;
		}

		public NullabilityInfo Create(ParameterInfo parameterInfo)
		{
			EnsureIsSupported();
			IList<CustomAttributeData> customAttributesData = parameterInfo.GetCustomAttributesData();
			NullableAttributeStateParser parser = ((parameterInfo.Member is MethodBase method && IsPrivateOrInternalMethodAndAnnotationDisabled(method)) ? NullableAttributeStateParser.Unknown : CreateParser(customAttributesData));
			NullabilityInfo nullabilityInfo = GetNullabilityInfo(parameterInfo.Member, parameterInfo.ParameterType, parser);
			if (nullabilityInfo.ReadState != NullabilityState.Unknown)
			{
				CheckParameterMetadataType(parameterInfo, nullabilityInfo);
			}
			CheckNullabilityAttributes(nullabilityInfo, customAttributesData);
			return nullabilityInfo;
		}

		private void CheckParameterMetadataType(ParameterInfo parameter, NullabilityInfo nullability)
		{
			if (!(parameter.Member is MethodInfo method))
			{
				return;
			}
			MethodInfo methodMetadataDefinition = GetMethodMetadataDefinition(method);
			ParameterInfo parameterInfo = null;
			if (string.IsNullOrEmpty(parameter.Name))
			{
				parameterInfo = methodMetadataDefinition.ReturnParameter;
			}
			else
			{
				ParameterInfo[] parameters = methodMetadataDefinition.GetParameters();
				for (int i = 0; i < parameters.Length; i++)
				{
					if (parameter.Position == i && parameter.Name == parameters[i].Name)
					{
						parameterInfo = parameters[i];
						break;
					}
				}
			}
			if (parameterInfo != null)
			{
				CheckGenericParameters(nullability, methodMetadataDefinition, parameterInfo.ParameterType, parameter.Member.ReflectedType);
			}
		}

		private static MethodInfo GetMethodMetadataDefinition(MethodInfo method)
		{
			if (method.IsGenericMethod && !method.IsGenericMethodDefinition)
			{
				method = method.GetGenericMethodDefinition();
			}
			return (MethodInfo)GetMemberMetadataDefinition(method);
		}

		private static void CheckNullabilityAttributes(NullabilityInfo nullability, IList<CustomAttributeData> attributes)
		{
			NullabilityState nullabilityState = NullabilityState.Unknown;
			NullabilityState nullabilityState2 = NullabilityState.Unknown;
			foreach (CustomAttributeData attribute in attributes)
			{
				if (attribute.AttributeType.Namespace == "System.Diagnostics.CodeAnalysis")
				{
					if (attribute.AttributeType.Name == "NotNullAttribute")
					{
						nullabilityState = NullabilityState.NotNull;
					}
					else if ((attribute.AttributeType.Name == "MaybeNullAttribute" || attribute.AttributeType.Name == "MaybeNullWhenAttribute") && nullabilityState == NullabilityState.Unknown && !IsValueTypeOrValueTypeByRef(nullability.Type))
					{
						nullabilityState = NullabilityState.Nullable;
					}
					else if (attribute.AttributeType.Name == "DisallowNullAttribute")
					{
						nullabilityState2 = NullabilityState.NotNull;
					}
					else if (attribute.AttributeType.Name == "AllowNullAttribute" && nullabilityState2 == NullabilityState.Unknown && !IsValueTypeOrValueTypeByRef(nullability.Type))
					{
						nullabilityState2 = NullabilityState.Nullable;
					}
				}
			}
			if (nullabilityState != NullabilityState.Unknown)
			{
				nullability.ReadState = nullabilityState;
			}
			if (nullabilityState2 != NullabilityState.Unknown)
			{
				nullability.WriteState = nullabilityState2;
			}
		}

		public NullabilityInfo Create(PropertyInfo propertyInfo)
		{
			EnsureIsSupported();
			MethodInfo getMethod = propertyInfo.GetGetMethod(nonPublic: true);
			MethodInfo setMethod = propertyInfo.GetSetMethod(nonPublic: true);
			NullableAttributeStateParser parser = (((getMethod == null || IsPrivateOrInternalMethodAndAnnotationDisabled(getMethod)) && (setMethod == null || IsPrivateOrInternalMethodAndAnnotationDisabled(setMethod))) ? NullableAttributeStateParser.Unknown : CreateParser(propertyInfo.GetCustomAttributesData()));
			NullabilityInfo nullabilityInfo = GetNullabilityInfo(propertyInfo, propertyInfo.PropertyType, parser);
			if (getMethod != null)
			{
				CheckNullabilityAttributes(nullabilityInfo, getMethod.ReturnParameter.GetCustomAttributesData());
			}
			else
			{
				nullabilityInfo.ReadState = NullabilityState.Unknown;
			}
			if (setMethod != null)
			{
				CheckNullabilityAttributes(nullabilityInfo, setMethod.GetParameters()[^1].GetCustomAttributesData());
			}
			else
			{
				nullabilityInfo.WriteState = NullabilityState.Unknown;
			}
			return nullabilityInfo;
		}

		private bool IsPrivateOrInternalMethodAndAnnotationDisabled(MethodBase method)
		{
			if ((method.IsPrivate || method.IsFamilyAndAssembly || method.IsAssembly) && IsPublicOnly(method.IsPrivate, method.IsFamilyAndAssembly, method.IsAssembly, method.Module))
			{
				return true;
			}
			return false;
		}

		public NullabilityInfo Create(EventInfo eventInfo)
		{
			EnsureIsSupported();
			return GetNullabilityInfo(eventInfo, eventInfo.EventHandlerType, CreateParser(eventInfo.GetCustomAttributesData()));
		}

		public NullabilityInfo Create(FieldInfo fieldInfo)
		{
			EnsureIsSupported();
			IList<CustomAttributeData> customAttributesData = fieldInfo.GetCustomAttributesData();
			NullableAttributeStateParser parser = (IsPrivateOrInternalFieldAndAnnotationDisabled(fieldInfo) ? NullableAttributeStateParser.Unknown : CreateParser(customAttributesData));
			NullabilityInfo nullabilityInfo = GetNullabilityInfo(fieldInfo, fieldInfo.FieldType, parser);
			CheckNullabilityAttributes(nullabilityInfo, customAttributesData);
			return nullabilityInfo;
		}

		private static void EnsureIsSupported()
		{
			if (!IsSupported)
			{
				throw new InvalidOperationException("NullabilityInfoContext is not supported");
			}
		}

		private bool IsPrivateOrInternalFieldAndAnnotationDisabled(FieldInfo fieldInfo)
		{
			if ((fieldInfo.IsPrivate || fieldInfo.IsFamilyAndAssembly || fieldInfo.IsAssembly) && IsPublicOnly(fieldInfo.IsPrivate, fieldInfo.IsFamilyAndAssembly, fieldInfo.IsAssembly, fieldInfo.Module))
			{
				return true;
			}
			return false;
		}

		private bool IsPublicOnly(bool isPrivate, bool isFamilyAndAssembly, bool isAssembly, Module module)
		{
			if (!_publicOnlyModules.TryGetValue(module, out var value))
			{
				value = PopulateAnnotationInfo(module.GetCustomAttributesData());
				_publicOnlyModules.Add(module, value);
			}
			if (value == NotAnnotatedStatus.None)
			{
				return false;
			}
			if (((isPrivate || isFamilyAndAssembly) && value.HasFlag(NotAnnotatedStatus.Private)) || (isAssembly && value.HasFlag(NotAnnotatedStatus.Internal)))
			{
				return true;
			}
			return false;
		}

		private static NotAnnotatedStatus PopulateAnnotationInfo(IList<CustomAttributeData> customAttributes)
		{
			bool flag = default(bool);
			foreach (CustomAttributeData customAttribute in customAttributes)
			{
				if (customAttribute.AttributeType.Name == "NullablePublicOnlyAttribute" && customAttribute.AttributeType.Namespace == "System.Runtime.CompilerServices" && customAttribute.ConstructorArguments.Count == 1)
				{
					object value = customAttribute.ConstructorArguments[0].Value;
					int num;
					if (value is bool)
					{
						flag = (bool)value;
						num = 1;
					}
					else
					{
						num = 0;
					}
					if (((uint)num & (flag ? 1u : 0u)) != 0)
					{
						return NotAnnotatedStatus.Private | NotAnnotatedStatus.Internal;
					}
					return NotAnnotatedStatus.Private;
				}
			}
			return NotAnnotatedStatus.None;
		}

		private NullabilityInfo GetNullabilityInfo(MemberInfo memberInfo, Type type, NullableAttributeStateParser parser)
		{
			int index = 0;
			NullabilityInfo nullabilityInfo = GetNullabilityInfo(memberInfo, type, parser, ref index);
			if (nullabilityInfo.ReadState != NullabilityState.Unknown)
			{
				TryLoadGenericMetaTypeNullability(memberInfo, nullabilityInfo);
			}
			return nullabilityInfo;
		}

		private NullabilityInfo GetNullabilityInfo(MemberInfo memberInfo, Type type, NullableAttributeStateParser parser, ref int index)
		{
			NullabilityState state = NullabilityState.Unknown;
			NullabilityInfo elementType = null;
			NullabilityInfo[] array = Array.Empty<NullabilityInfo>();
			Type type2 = type;
			if (type2.IsByRef || type2.IsPointer)
			{
				type2 = type2.GetElementType();
			}
			if (type2.IsValueType)
			{
				Type underlyingType = Nullable.GetUnderlyingType(type2);
				if ((object)underlyingType != null)
				{
					type2 = underlyingType;
					state = NullabilityState.Nullable;
				}
				else
				{
					state = NullabilityState.NotNull;
				}
				if (type2.IsGenericType)
				{
					index++;
				}
			}
			else
			{
				if (!parser.ParseNullableState(index++, ref state))
				{
					NullabilityState? nullableContext = GetNullableContext(memberInfo);
					if (nullableContext.HasValue)
					{
						NullabilityState valueOrDefault = nullableContext.GetValueOrDefault();
						state = valueOrDefault;
					}
				}
				if (type2.IsArray)
				{
					elementType = GetNullabilityInfo(memberInfo, type2.GetElementType(), parser, ref index);
				}
			}
			if (type2.IsGenericType)
			{
				Type[] genericArguments = type2.GetGenericArguments();
				array = new NullabilityInfo[genericArguments.Length];
				for (int i = 0; i < genericArguments.Length; i++)
				{
					array[i] = GetNullabilityInfo(memberInfo, genericArguments[i], parser, ref index);
				}
			}
			return new NullabilityInfo(type, state, state, elementType, array);
		}

		private static NullableAttributeStateParser CreateParser(IList<CustomAttributeData> customAttributes)
		{
			foreach (CustomAttributeData customAttribute in customAttributes)
			{
				if (customAttribute.AttributeType.Name == "NullableAttribute" && customAttribute.AttributeType.Namespace == "System.Runtime.CompilerServices" && customAttribute.ConstructorArguments.Count == 1)
				{
					return new NullableAttributeStateParser(customAttribute.ConstructorArguments[0].Value);
				}
			}
			return new NullableAttributeStateParser(null);
		}

		private void TryLoadGenericMetaTypeNullability(MemberInfo memberInfo, NullabilityInfo nullability)
		{
			MemberInfo memberMetadataDefinition = GetMemberMetadataDefinition(memberInfo);
			Type type = null;
			if (memberMetadataDefinition is FieldInfo fieldInfo)
			{
				type = fieldInfo.FieldType;
			}
			else if (memberMetadataDefinition is PropertyInfo property)
			{
				type = GetPropertyMetaType(property);
			}
			if (type != null)
			{
				CheckGenericParameters(nullability, memberMetadataDefinition, type, memberInfo.ReflectedType);
			}
		}

		private static MemberInfo GetMemberMetadataDefinition(MemberInfo member)
		{
			Type declaringType = member.DeclaringType;
			if (declaringType != null && declaringType.IsGenericType && !declaringType.IsGenericTypeDefinition)
			{
				return declaringType.GetGenericTypeDefinition().GetMemberWithSameMetadataDefinitionAs(member);
			}
			return member;
		}

		private static Type GetPropertyMetaType(PropertyInfo property)
		{
			MethodInfo getMethod = property.GetGetMethod(nonPublic: true);
			if ((object)getMethod != null)
			{
				return getMethod.ReturnType;
			}
			return property.GetSetMethod(nonPublic: true).GetParameters()[0].ParameterType;
		}

		private void CheckGenericParameters(NullabilityInfo nullability, MemberInfo metaMember, Type metaType, Type? reflectedType)
		{
			if (metaType.IsGenericParameter)
			{
				if (nullability.ReadState == NullabilityState.NotNull)
				{
					TryUpdateGenericParameterNullability(nullability, metaType, reflectedType);
				}
			}
			else
			{
				if (!metaType.ContainsGenericParameters)
				{
					return;
				}
				if (nullability.GenericTypeArguments.Length != 0)
				{
					Type[] genericArguments = metaType.GetGenericArguments();
					for (int i = 0; i < genericArguments.Length; i++)
					{
						CheckGenericParameters(nullability.GenericTypeArguments[i], metaMember, genericArguments[i], reflectedType);
					}
					return;
				}
				NullabilityInfo elementType = nullability.ElementType;
				if (elementType != null && metaType.IsArray)
				{
					CheckGenericParameters(elementType, metaMember, metaType.GetElementType(), reflectedType);
				}
				else if (metaType.IsByRef)
				{
					CheckGenericParameters(nullability, metaMember, metaType.GetElementType(), reflectedType);
				}
			}
		}

		private bool TryUpdateGenericParameterNullability(NullabilityInfo nullability, Type genericParameter, Type? reflectedType)
		{
			if ((object)reflectedType != null && !genericParameter.IsGenericMethodParameter() && TryUpdateGenericTypeParameterNullabilityFromReflectedType(nullability, genericParameter, reflectedType, reflectedType))
			{
				return true;
			}
			if (IsValueTypeOrValueTypeByRef(nullability.Type))
			{
				return true;
			}
			NullabilityState state = NullabilityState.Unknown;
			if (CreateParser(genericParameter.GetCustomAttributesData()).ParseNullableState(0, ref state))
			{
				nullability.ReadState = state;
				nullability.WriteState = state;
				return true;
			}
			NullabilityState? nullableContext = GetNullableContext(genericParameter);
			if (nullableContext.HasValue)
			{
				NullabilityState writeState = (nullability.ReadState = nullableContext.GetValueOrDefault());
				nullability.WriteState = writeState;
				return true;
			}
			return false;
		}

		private bool TryUpdateGenericTypeParameterNullabilityFromReflectedType(NullabilityInfo nullability, Type genericParameter, Type context, Type reflectedType)
		{
			Type type = ((context.IsGenericType && !context.IsGenericTypeDefinition) ? context.GetGenericTypeDefinition() : context);
			if (genericParameter.DeclaringType == type)
			{
				return false;
			}
			Type baseType = type.BaseType;
			if ((object)baseType == null)
			{
				return false;
			}
			if (!baseType.IsGenericType || (baseType.IsGenericTypeDefinition ? baseType : baseType.GetGenericTypeDefinition()) != genericParameter.DeclaringType)
			{
				return TryUpdateGenericTypeParameterNullabilityFromReflectedType(nullability, genericParameter, baseType, reflectedType);
			}
			Type[] genericArguments = baseType.GetGenericArguments();
			Type type2 = genericArguments[genericParameter.GenericParameterPosition];
			if (type2.IsGenericParameter)
			{
				return TryUpdateGenericParameterNullability(nullability, type2, reflectedType);
			}
			NullableAttributeStateParser parser = CreateParser(type.GetCustomAttributesData());
			int index = 1;
			for (int i = 0; i < genericParameter.GenericParameterPosition; i++)
			{
				index += CountNullabilityStates(genericArguments[i]);
			}
			return TryPopulateNullabilityInfo(nullability, parser, ref index);
			static int CountNullabilityStates(Type type4)
			{
				Type type3 = Nullable.GetUnderlyingType(type4) ?? type4;
				if (type3.IsGenericType)
				{
					int num = 1;
					Type[] genericArguments2 = type3.GetGenericArguments();
					foreach (Type type5 in genericArguments2)
					{
						num += CountNullabilityStates(type5);
					}
					return num;
				}
				if (type3.HasElementType)
				{
					return (type3.IsArray ? 1 : 0) + CountNullabilityStates(type3.GetElementType());
				}
				return (!type4.IsValueType) ? 1 : 0;
			}
		}

		private bool TryPopulateNullabilityInfo(NullabilityInfo nullability, NullableAttributeStateParser parser, ref int index)
		{
			bool flag = IsValueTypeOrValueTypeByRef(nullability.Type);
			if (!flag)
			{
				NullabilityState state = NullabilityState.Unknown;
				if (!parser.ParseNullableState(index, ref state))
				{
					return false;
				}
				nullability.ReadState = state;
				nullability.WriteState = state;
			}
			if (!flag || (Nullable.GetUnderlyingType(nullability.Type) ?? nullability.Type).IsGenericType)
			{
				index++;
			}
			if (nullability.GenericTypeArguments.Length != 0)
			{
				NullabilityInfo[] genericTypeArguments = nullability.GenericTypeArguments;
				foreach (NullabilityInfo nullability2 in genericTypeArguments)
				{
					TryPopulateNullabilityInfo(nullability2, parser, ref index);
				}
			}
			else
			{
				NullabilityInfo elementType = nullability.ElementType;
				if (elementType != null)
				{
					TryPopulateNullabilityInfo(elementType, parser, ref index);
				}
			}
			return true;
		}

		private static NullabilityState TranslateByte(object? value)
		{
			if (!(value is byte b))
			{
				return NullabilityState.Unknown;
			}
			return TranslateByte(b);
		}

		private static NullabilityState TranslateByte(byte b)
		{
			return b switch
			{
				1 => NullabilityState.NotNull, 
				2 => NullabilityState.Nullable, 
				_ => NullabilityState.Unknown, 
			};
		}

		private static bool IsValueTypeOrValueTypeByRef(Type type)
		{
			if (!type.IsValueType)
			{
				if (type.IsByRef || type.IsPointer)
				{
					return type.GetElementType().IsValueType;
				}
				return false;
			}
			return true;
		}
	}
}

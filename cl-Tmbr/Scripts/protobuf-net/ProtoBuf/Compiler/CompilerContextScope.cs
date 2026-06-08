using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using ProtoBuf.Internal;
using ProtoBuf.Meta;

namespace ProtoBuf.Compiler
{
	internal sealed class CompilerContextScope
	{
		private static class SharedModule
		{
			internal static readonly ModuleBuilder Shared = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("SharedModule"), AssemblyBuilderAccess.RunAndCollect).DefineDynamicModule("SharedModule");
		}

		private ModuleBuilder _module;

		private readonly RuntimeTypeModel _model;

		private int _localUniqueId;

		private static int s_globalUniqueId;

		internal string AssemblyName { get; }

		public bool IsFullEmit { get; }

		internal static CompilerContextScope CreateInProcess()
		{
			return new CompilerContextScope(null, null, isFullEmit: false, null);
		}

		internal static CompilerContextScope CreateForModule(RuntimeTypeModel model, ModuleBuilder module, bool isFullEmit, string assemblyName)
		{
			return new CompilerContextScope(model, module, isFullEmit, assemblyName);
		}

		private CompilerContextScope(RuntimeTypeModel model, ModuleBuilder module, bool isFullEmit, string assemblyName)
		{
			_model = model;
			_module = module;
			IsFullEmit = isFullEmit;
			AssemblyName = assemblyName;
		}

		private ModuleBuilder GetModule()
		{
			return _module ?? (_module = GetSharedModule());
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static ModuleBuilder GetSharedModule()
		{
			return SharedModule.Shared;
		}

		internal static ILGenerator Implement(TypeBuilder type, Type interfaceType, string name, bool @explicit = true)
		{
			MethodInfo methodInfo = interfaceType.GetMethod(name, BindingFlags.Instance | BindingFlags.Public) ?? throw new ArgumentException("Declaration not found for '" + name + "'", "name");
			ParameterInfo[] parameters = methodInfo.GetParameters();
			string text = name;
			MethodAttributes methodAttributes = (methodInfo.Attributes & ~MethodAttributes.Abstract) | MethodAttributes.Final;
			if (@explicit)
			{
				text = interfaceType.NormalizeName() + "." + text;
				methodAttributes &= ~MethodAttributes.MemberAccessMask;
				methodAttributes |= MethodAttributes.Private | MethodAttributes.HideBySig;
			}
			MethodBuilder methodBuilder = type.DefineMethod(text, methodAttributes, methodInfo.ReturnType, Array.ConvertAll(parameters, (ParameterInfo x) => x.ParameterType));
			for (int num = 0; num < parameters.Length; num++)
			{
				methodBuilder.DefineParameter(num + 1, parameters[num].Attributes, parameters[num].Name);
			}
			type.DefineMethodOverride(methodBuilder, methodInfo);
			return methodBuilder.GetILGenerator();
		}

		private int Uniquify()
		{
			if (!IsFullEmit)
			{
				return Interlocked.Increment(ref s_globalUniqueId);
			}
			return Interlocked.Increment(ref _localUniqueId);
		}

		internal FieldInfo DefineSubTypeStateCallbackField<T>(MethodInfo callback)
		{
			if (typeof(T).IsValueType)
			{
				ThrowHelper.ThrowInvalidOperationException("Not expected for value-type");
			}
			Type typeFromHandle = typeof(Action<T, ISerializationContext>);
			ModuleBuilder module = GetModule();
			lock (module)
			{
				string text = "<" + callback.Name + ">_helper_" + Uniquify();
				TypeBuilder typeBuilder;
				try
				{
					typeBuilder = module.DefineType(text, TypeAttributes.Abstract | TypeAttributes.Sealed | TypeAttributes.BeforeFieldInit);
				}
				catch (Exception innerException)
				{
					throw new InvalidOperationException("Unable to define type: " + text, innerException);
				}
				string text2 = "s_" + callback.Name;
				FieldAttributes fieldAttributes = FieldAttributes.Assembly | FieldAttributes.Static;
				if (IsFullEmit)
				{
					fieldAttributes |= FieldAttributes.InitOnly;
				}
				FieldBuilder field = typeBuilder.DefineField(text2, typeFromHandle, fieldAttributes);
				if (IsFullEmit)
				{
					MethodBuilder methodBuilder = typeBuilder.DefineMethod(callback.Name, MethodAttributes.Private | MethodAttributes.Static | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName, CallingConventions.Standard, typeof(void), new Type[2]
					{
						typeof(T),
						typeof(ISerializationContext)
					});
					methodBuilder.DefineParameter(1, ParameterAttributes.None, "obj");
					methodBuilder.DefineParameter(2, ParameterAttributes.None, "context");
					WriteCall(methodBuilder.GetILGenerator(), callback);
					ConstructorBuilder constructorBuilder = typeBuilder.DefineTypeInitializer();
					ILGenerator iLGenerator = constructorBuilder.GetILGenerator();
					iLGenerator.Emit(OpCodes.Ldnull);
					iLGenerator.Emit(OpCodes.Ldftn, methodBuilder);
					iLGenerator.Emit(OpCodes.Newobj, typeFromHandle.GetConstructors().Single());
					iLGenerator.Emit(OpCodes.Stsfld, field);
					iLGenerator.Emit(OpCodes.Ret);
				}
				Type type = typeBuilder.CreateType();
				FieldInfo field2 = type.GetField(text2, BindingFlags.Static | BindingFlags.NonPublic);
				if (!IsFullEmit)
				{
					DynamicMethod dynamicMethod = new DynamicMethod(callback.Name, typeof(void), new Type[2]
					{
						typeof(T),
						typeof(ISerializationContext)
					}, typeof(T), skipVisibility: true);
					WriteCall(dynamicMethod.GetILGenerator(), callback);
					field2.SetValue(null, dynamicMethod.CreateDelegate(typeFromHandle));
				}
				return field2;
			}
			static void WriteCall(ILGenerator il, MethodInfo methodInfo)
			{
				il.Emit(OpCodes.Ldarg_0);
				ParameterInfo[] parameters = methodInfo.GetParameters();
				foreach (ParameterInfo parameterInfo in parameters)
				{
					Type parameterType = parameterInfo.ParameterType;
					if (parameterType == typeof(ISerializationContext))
					{
						il.Emit(OpCodes.Ldarg_1);
					}
					else if (parameterType == typeof(SerializationContext))
					{
						il.Emit(OpCodes.Ldarg_1);
						il.EmitCall(OpCodes.Call, typeof(SerializationContext).GetMethod("AsSerializationContext"), null);
					}
					else if (parameterType == typeof(StreamingContext))
					{
						il.Emit(OpCodes.Ldarg_1);
						il.EmitCall(OpCodes.Call, typeof(SerializationContext).GetMethod("AsStreamingContext"), null);
					}
					else
					{
						ThrowHelper.ThrowNotSupportedException($"Unknown callback parameter: {parameterInfo.Name}, {parameterType}");
					}
				}
				il.EmitCall(OpCodes.Callvirt, methodInfo, null);
				il.Emit(OpCodes.Ret);
			}
		}

		internal bool ImplementsServiceFor<T>(CompatibilityLevel ambient)
		{
			if (_model == null || typeof(T).IsEnum || (object)Nullable.GetUnderlyingType(typeof(T)) != null)
			{
				return false;
			}
			if (!_model.IsKnownType<T>(ambient))
			{
				return false;
			}
			MetaType metaType = _model[typeof(T)];
			if (metaType == null)
			{
				return false;
			}
			if ((object)metaType.SerializerType != null)
			{
				return false;
			}
			if (_model.TryGetRepeatedProvider(metaType.Type) != null)
			{
				return false;
			}
			return true;
		}
	}
}

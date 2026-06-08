using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using ProtoBuf.Internal;
using ProtoBuf.Internal.Serializers;
using ProtoBuf.Meta;
using ProtoBuf.Serializers;

namespace ProtoBuf.Compiler
{
	internal sealed class CompilerContext : IDisposable
	{
		internal enum SignatureType
		{
			WriterScope_Input = 0,
			ReaderScope_Input = 1,
			Context = 2
		}

		internal static class StateBasedReadMethods
		{
			internal static readonly Type ByRefStateType = typeof(ProtoReader.State).MakeByRefType();

			private static readonly Hashtable s_perTypeCache = new Hashtable();

			private static Dictionary<string, MethodInfo> CreateAndAdd(Type parentType)
			{
				Dictionary<string, MethodInfo> dictionary = new Dictionary<string, MethodInfo>(StringComparer.Ordinal);
				MethodInfo[] methods = parentType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (MethodInfo methodInfo in methods)
				{
					if (methodInfo.IsDefined(typeof(ObsoleteAttribute), inherit: true))
					{
						continue;
					}
					ParameterInfo[] parameters = methodInfo.GetParameters();
					if (methodInfo.IsStatic)
					{
						if (parameters.Length != 1 || parameters[0].ParameterType != ByRefStateType)
						{
							continue;
						}
					}
					else if (parameters.Length != 0)
					{
						continue;
					}
					dictionary.Add(methodInfo.Name, methodInfo);
				}
				lock (s_perTypeCache)
				{
					s_perTypeCache[parentType] = dictionary;
					return dictionary;
				}
			}

			internal static bool Find(Type parentType, string methodName, out MethodInfo method)
			{
				Dictionary<string, MethodInfo> dictionary = ((Dictionary<string, MethodInfo>)s_perTypeCache[parentType]) ?? CreateAndAdd(parentType);
				return dictionary.TryGetValue(methodName, out method);
			}
		}

		private sealed class UsingBlock : IDisposable
		{
			private Local local;

			private CompilerContext ctx;

			private CodeLabel label;

			public UsingBlock(CompilerContext ctx, Local local)
			{
				if (local == null)
				{
					throw new ArgumentNullException("local");
				}
				Type type = local.Type;
				if ((!type.IsValueType && !type.IsSealed) || typeof(IDisposable).IsAssignableFrom(type))
				{
					this.local = local;
					this.ctx = ctx ?? throw new ArgumentNullException("ctx");
					label = ctx.BeginTry();
				}
			}

			public void Dispose()
			{
				if (this.local == null || ctx == null)
				{
					return;
				}
				ctx.EndTry(label, @short: false);
				ctx.BeginFinally();
				Type typeFromHandle = typeof(IDisposable);
				MethodInfo method = typeFromHandle.GetMethod("Dispose");
				Type type = this.local.Type;
				if (type.IsValueType)
				{
					ctx.LoadAddress(this.local, type);
					ctx.Constrain(type);
					ctx.EmitCall(method);
				}
				else
				{
					CodeLabel codeLabel = ctx.DefineLabel();
					if (typeFromHandle.IsAssignableFrom(type))
					{
						ctx.LoadValue(this.local);
						ctx.BranchIfFalse(codeLabel, @short: true);
						ctx.LoadAddress(this.local, type);
					}
					else
					{
						using Local local = new Local(ctx, typeFromHandle);
						ctx.LoadValue(this.local);
						ctx.TryCast(typeFromHandle);
						ctx.CopyValue();
						ctx.StoreValue(local);
						ctx.BranchIfFalse(codeLabel, @short: true);
						ctx.LoadAddress(local, typeFromHandle);
					}
					ctx.EmitCall(method);
					ctx.MarkLabel(codeLabel);
				}
				ctx.EndFinally();
				this.local = null;
				ctx = null;
				label = default(CodeLabel);
			}
		}

		private readonly DynamicMethod method;

		private static int next;

		private static readonly MethodInfo s_CreateInstance = typeof(ProtoReader.State).GetMethod("CreateInstance", BindingFlags.Instance | BindingFlags.Public);

		private readonly string _traceName;

		private readonly OpCode _state;

		private readonly byte _inputArg;

		private readonly SignatureType _signature;

		private static readonly MethodInfo s_GetInbuiltSerializer = typeof(TypeModel).GetMethod("GetInbuiltSerializer", BindingFlags.Static | BindingFlags.Public);

		private readonly ILGenerator il;

		private readonly List<LocalBuilder> locals = new List<LocalBuilder>();

		private int nextLabel;

		private List<Assembly> knownTrustedAssemblies;

		private List<Assembly> knownUntrustedAssemblies;

		public TypeModel Model { get; }

		internal bool NonPublic { get; }

		public Local InputValue { get; }

		public bool IsStatic { get; }

		internal CompilerContextScope Scope { get; }

		public bool IsService
		{
			get
			{
				if (Scope.IsFullEmit)
				{
					return !IsStatic;
				}
				return false;
			}
		}

		internal ILGenerator IL => il;

		internal CodeLabel DefineLabel()
		{
			CodeLabel result = new CodeLabel(il.DefineLabel(), nextLabel++);
			return result;
		}

		[Conditional("DEBUG_COMPILE")]
		private void TraceCompile(string value)
		{
		}

		internal void MarkLabel(CodeLabel label)
		{
			il.MarkLabel(label.Value);
		}

		public static ProtoSerializer<TActual> BuildSerializer<TActual>(CompilerContextScope scope, IRuntimeProtoSerializerNode head, TypeModel model)
		{
			Type expectedType = head.ExpectedType;
			try
			{
				using CompilerContext compilerContext = new CompilerContext(scope, expectedType, SignatureType.WriterScope_Input, isStatic: true, model, typeof(TActual), null);
				compilerContext.WriteNullCheckedTail(expectedType, head, compilerContext.InputValue);
				compilerContext.Emit(OpCodes.Ret);
				return (ProtoSerializer<TActual>)compilerContext.method.CreateDelegate(typeof(ProtoSerializer<TActual>));
			}
			catch (Exception innerException)
			{
				string text = expectedType.FullName;
				if (string.IsNullOrEmpty(text))
				{
					text = expectedType.Name;
				}
				throw new InvalidOperationException("It was not possible to prepare a serializer for: " + text, innerException);
			}
		}

		public static ProtoSubTypeDeserializer<T> BuildSubTypeDeserializer<T>(CompilerContextScope scope, IRuntimeProtoSerializerNode head, TypeModel model) where T : class
		{
			using CompilerContext compilerContext = new CompilerContext(scope, head.ExpectedType, SignatureType.ReaderScope_Input, isStatic: true, model, typeof(SubTypeState<T>), typeof(T));
			head.EmitRead(compilerContext, compilerContext.InputValue);
			compilerContext.Return();
			return (ProtoSubTypeDeserializer<T>)compilerContext.method.CreateDelegate(typeof(ProtoSubTypeDeserializer<T>));
		}

		public static ProtoDeserializer<T> BuildDeserializer<T>(CompilerContextScope scope, IRuntimeProtoSerializerNode head, TypeModel model, bool isScalar = false)
		{
			using CompilerContext compilerContext = new CompilerContext(scope, head.ExpectedType, SignatureType.ReaderScope_Input, isStatic: true, model, typeof(T), typeof(T));
			head.EmitRead(compilerContext, compilerContext.InputValue);
			if (!isScalar)
			{
				compilerContext.LoadValue(compilerContext.InputValue);
			}
			compilerContext.Return();
			return (ProtoDeserializer<T>)compilerContext.method.CreateDelegate(typeof(ProtoDeserializer<T>));
		}

		public static Func<ISerializationContext, T> BuildFactory<T>(CompilerContextScope scope, IRuntimeProtoSerializerNode head, TypeModel model)
		{
			if (head is IProtoTypeSerializer protoTypeSerializer && protoTypeSerializer.ShouldEmitCreateInstance)
			{
				using (CompilerContext compilerContext = new CompilerContext(scope, head.ExpectedType, SignatureType.Context, isStatic: true, model, typeof(ISerializationContext), typeof(T)))
				{
					protoTypeSerializer.EmitCreateInstance(compilerContext, callNoteObject: false);
					compilerContext.Return();
					return (Func<ISerializationContext, T>)compilerContext.method.CreateDelegate(typeof(Func<ISerializationContext, T>));
				}
			}
			return null;
		}

		internal void CreateInstance<T>()
		{
			LoadState();
			LoadNullRef();
			EmitCall(s_CreateInstance.MakeGenericMethod(typeof(T)));
		}

		internal void Return()
		{
			Emit(OpCodes.Ret);
		}

		private static bool IsObject(Type type)
		{
			return type == typeof(object);
		}

		internal void CastToObject(Type type)
		{
			if (!IsObject(type))
			{
				if (type.IsValueType)
				{
					il.Emit(OpCodes.Box, type);
				}
				else
				{
					il.Emit(OpCodes.Castclass, typeof(object));
				}
			}
		}

		internal void CastFromObject(Type type)
		{
			if (!IsObject(type))
			{
				if (type.IsValueType)
				{
					il.Emit(OpCodes.Unbox_Any, type);
				}
				else
				{
					il.Emit(OpCodes.Castclass, type);
				}
			}
		}

		internal CompilerContext(CompilerContext parent, ILGenerator il, bool isStatic, SignatureType signature, Type inputType, string traceName)
			: this(parent.Scope, il, isStatic, signature, parent.Model, inputType, traceName)
		{
		}

		internal void ThrowException(Type exceptionType)
		{
			il.ThrowException(exceptionType);
		}

		internal CompilerContext(CompilerContextScope scope, ILGenerator il, bool isStatic, SignatureType signature, TypeModel model, Type inputType, string traceName)
		{
			Scope = scope;
			this.il = il ?? throw new ArgumentNullException("il");
			Model = model ?? throw new ArgumentNullException("model");
			if ((object)inputType != null)
			{
				InputValue = new Local(null, inputType);
			}
			_traceName = traceName;
			IsStatic = isStatic;
			_signature = signature;
			GetOpCodes(signature, isStatic, out _state, out _inputArg);
		}

		public override string ToString()
		{
			return _traceName;
		}

		private static void GetOpCodes(SignatureType signature, bool isStatic, out OpCode state, out byte inputArg)
		{
			if ((uint)signature <= 1u)
			{
				state = (isStatic ? OpCodes.Ldarg_0 : OpCodes.Ldarg_1);
				inputArg = (byte)(isStatic ? 1u : 2u);
			}
			else
			{
				state = default(OpCode);
				inputArg = ((!isStatic) ? ((byte)1) : ((byte)0));
			}
		}

		private CompilerContext(CompilerContextScope scope, Type associatedType, SignatureType signature, bool isStatic, TypeModel model, Type inputType, Type returnType)
		{
			Scope = scope;
			Model = model ?? throw new ArgumentNullException("model");
			NonPublic = true;
			_signature = signature;
			GetOpCodes(signature, isStatic, out _state, out _inputArg);
			Type[] parameterTypes = signature switch
			{
				SignatureType.ReaderScope_Input => new Type[2]
				{
					StateBasedReadMethods.ByRefStateType,
					inputType
				}, 
				SignatureType.WriterScope_Input => new Type[2]
				{
					WriterUtil.ByRefStateType,
					inputType
				}, 
				_ => new Type[1] { inputType }, 
			};
			method = new DynamicMethod("proto_" + Interlocked.Increment(ref next).ToString(CultureInfo.InvariantCulture), returnType ?? typeof(void), parameterTypes, associatedType.IsInterface ? typeof(object) : associatedType, skipVisibility: true);
			il = method.GetILGenerator();
			if ((object)inputType != null)
			{
				InputValue = new Local(null, inputType);
			}
			_traceName = method.Name;
			IsStatic = isStatic;
		}

		public void LoadSelfAsService<TService, T>(CompatibilityLevel compatibilityLevel, DataFormat dataFormat) where TService : class
		{
			ISerializer<T> inbuiltSerializer = TypeModel.GetInbuiltSerializer<T>(compatibilityLevel, dataFormat);
			if (IsStatic || inbuiltSerializer != null)
			{
				if (inbuiltSerializer != null && typeof(TService) == typeof(ISerializer<T>) && !(inbuiltSerializer is PrimaryTypeProvider))
				{
					LoadValue((int)compatibilityLevel);
					LoadValue((int)dataFormat);
					EmitCall(s_GetInbuiltSerializer.MakeGenericMethod(typeof(T)));
				}
				else
				{
					LoadNullRef();
				}
			}
			else
			{
				Emit(OpCodes.Ldarg_0);
				if (!Scope.IsFullEmit || !Scope.ImplementsServiceFor<T>(compatibilityLevel))
				{
					TryCast(typeof(TService));
				}
			}
		}

		private void Emit(OpCode opcode)
		{
			il.Emit(opcode);
		}

		public void LoadValue(string value)
		{
			if (value == null)
			{
				LoadNullRef();
			}
			else
			{
				il.Emit(OpCodes.Ldstr, value);
			}
		}

		public void LoadValue(float value)
		{
			il.Emit(OpCodes.Ldc_R4, value);
		}

		public void LoadValue(double value)
		{
			il.Emit(OpCodes.Ldc_R8, value);
		}

		public void LoadValue(long value)
		{
			il.Emit(OpCodes.Ldc_I8, value);
		}

		public void LoadValue(bool value)
		{
			Emit(value ? OpCodes.Ldc_I4_1 : OpCodes.Ldc_I4_0);
		}

		public void LoadValue(int value)
		{
			switch (value)
			{
			case 0:
				Emit(OpCodes.Ldc_I4_0);
				return;
			case 1:
				Emit(OpCodes.Ldc_I4_1);
				return;
			case 2:
				Emit(OpCodes.Ldc_I4_2);
				return;
			case 3:
				Emit(OpCodes.Ldc_I4_3);
				return;
			case 4:
				Emit(OpCodes.Ldc_I4_4);
				return;
			case 5:
				Emit(OpCodes.Ldc_I4_5);
				return;
			case 6:
				Emit(OpCodes.Ldc_I4_6);
				return;
			case 7:
				Emit(OpCodes.Ldc_I4_7);
				return;
			case 8:
				Emit(OpCodes.Ldc_I4_8);
				return;
			case -1:
				Emit(OpCodes.Ldc_I4_M1);
				return;
			}
			if (value >= -128 && value <= 127)
			{
				il.Emit(OpCodes.Ldc_I4_S, (sbyte)value);
			}
			else
			{
				il.Emit(OpCodes.Ldc_I4, value);
			}
		}

		void IDisposable.Dispose()
		{
		}

		internal LocalBuilder GetFromPool(Type type)
		{
			int count = locals.Count;
			for (int i = 0; i < count; i++)
			{
				LocalBuilder localBuilder = locals[i];
				if (localBuilder != null && localBuilder.LocalType == type)
				{
					locals[i] = null;
					return localBuilder;
				}
			}
			return il.DeclareLocal(type);
		}

		internal void ReleaseToPool(LocalBuilder value)
		{
			int count = locals.Count;
			for (int i = 0; i < count; i++)
			{
				if (locals[i] == null)
				{
					locals[i] = value;
					return;
				}
			}
			locals.Add(value);
		}

		public void LoadState()
		{
			Emit(_state);
		}

		public void StoreValue(Local local)
		{
			if (local == InputValue)
			{
				il.Emit(OpCodes.Starg_S, _inputArg);
			}
			else if (local != null)
			{
				switch (local.Value.LocalIndex)
				{
				case 0:
					Emit(OpCodes.Stloc_0);
					break;
				case 1:
					Emit(OpCodes.Stloc_1);
					break;
				case 2:
					Emit(OpCodes.Stloc_2);
					break;
				case 3:
					Emit(OpCodes.Stloc_3);
					break;
				default:
				{
					OpCode opcode = (UseShortForm(local) ? OpCodes.Stloc_S : OpCodes.Stloc);
					il.Emit(opcode, local.Value);
					break;
				}
				}
			}
		}

		public void LoadValue(Local local)
		{
			if (local == null)
			{
				return;
			}
			if (local == InputValue)
			{
				switch (_inputArg)
				{
				case 0:
					Emit(OpCodes.Ldarg_0);
					break;
				case 1:
					Emit(OpCodes.Ldarg_1);
					break;
				case 2:
					Emit(OpCodes.Ldarg_2);
					break;
				case 3:
					Emit(OpCodes.Ldarg_3);
					break;
				default:
					il.Emit(OpCodes.Ldarg_S, _inputArg);
					break;
				}
				return;
			}
			switch (local.Value.LocalIndex)
			{
			case 0:
				Emit(OpCodes.Ldloc_0);
				break;
			case 1:
				Emit(OpCodes.Ldloc_1);
				break;
			case 2:
				Emit(OpCodes.Ldloc_2);
				break;
			case 3:
				Emit(OpCodes.Ldloc_3);
				break;
			default:
			{
				OpCode opcode = (UseShortForm(local) ? OpCodes.Ldloc_S : OpCodes.Ldloc);
				il.Emit(opcode, local.Value);
				break;
			}
			}
		}

		public Local GetLocalWithValue(Type type, Local fromValue)
		{
			if (fromValue != null)
			{
				if (fromValue.Type == type)
				{
					return fromValue.AsCopy();
				}
				LoadValue(fromValue);
				if (!type.IsValueType && ((object)fromValue.Type == null || !type.IsAssignableFrom(fromValue.Type)))
				{
					Cast(type);
				}
			}
			Local local = new Local(this, type);
			StoreValue(local);
			return local;
		}

		internal void EmitStateBasedRead(string methodName, Type expectedType)
		{
			EmitStateBasedRead(typeof(ProtoReader.State), methodName, expectedType);
		}

		internal void EmitStateBasedRead(Type ownerType, string methodName, Type expectedType)
		{
			if (!StateBasedReadMethods.Find(ownerType, methodName, out var methodInfo))
			{
				throw new ArgumentException("No suitable '" + methodName + "' method found on " + ownerType.Name);
			}
			if (methodInfo.ReturnType != expectedType)
			{
				throw new ArgumentException("Method '" + methodName + "' has wrong return type; got " + methodInfo.ReturnType.Name + ", expected " + expectedType.Name);
			}
			LoadState();
			EmitCall(methodInfo);
		}

		internal void EmitStateBasedWrite(string methodName, Local fromValue, Type type = null, Type argType = null)
		{
			if (string.IsNullOrEmpty(methodName))
			{
				throw new ArgumentNullException("methodName");
			}
			if ((object)type == null)
			{
				type = typeof(ProtoWriter.State);
			}
			Type type2;
			MethodInfo methodInfo;
			try
			{
				var anon = (from method in type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public)
					where method.Name == methodName && !method.IsGenericMethodDefinition && method.ReturnType == typeof(void)
					let args = method.GetParameters()
					where args.Length == ((!method.IsStatic) ? 1 : 2) && (!method.IsStatic || args[0].ParameterType == WriterUtil.ByRefStateType)
					let paramType = args[method.IsStatic ? 1 : 0].ParameterType
					where (object)argType == null || argType == paramType
					select new
					{
						Method = method,
						Type = paramType
					}).Single();
				type2 = anon.Type;
				methodInfo = anon.Method;
			}
			catch (Exception innerException)
			{
				throw new InvalidOperationException("Unable to uniquely resolve " + type.Name + "." + methodName, innerException);
			}
			using Local local = GetLocalWithValue(type2, fromValue);
			LoadState();
			LoadValue(local);
			EmitCall(methodInfo);
		}

		public void EmitCall(MethodInfo method)
		{
			EmitCall(method, null);
		}

		public void EmitCall(MethodInfo method, Type targetType)
		{
			MemberInfo member = method ?? throw new ArgumentNullException("method");
			CheckAccessibility(ref member);
			OpCode opcode;
			if (method.IsStatic || method.DeclaringType.IsValueType)
			{
				opcode = OpCodes.Call;
			}
			else
			{
				opcode = OpCodes.Callvirt;
				if ((object)targetType != null && targetType.IsValueType && !method.DeclaringType.IsValueType)
				{
					Constrain(targetType);
				}
			}
			il.EmitCall(opcode, method, null);
		}

		public void LoadNullRef()
		{
			Emit(OpCodes.Ldnull);
		}

		internal void WriteNullCheckedTail(Type type, IRuntimeProtoSerializerNode tail, Local valueFrom)
		{
			if (tail is TagDecorator tagDecorator && tagDecorator.ExpectedType == type && tagDecorator.CanEmitDirectWrite())
			{
				tagDecorator.EmitDirectWrite(this, valueFrom);
			}
			else if (type.IsValueType)
			{
				Type underlyingType = Nullable.GetUnderlyingType(type);
				if ((object)underlyingType != null)
				{
					using (Local local = GetLocalWithValue(type, valueFrom))
					{
						LoadAddress(local, type);
						LoadValue(type.GetProperty("HasValue"));
						CodeLabel label = DefineLabel();
						BranchIfFalse(label, @short: false);
						LoadAddress(local, type);
						EmitCall(type.GetMethod("GetValueOrDefault", Type.EmptyTypes));
						tail.EmitWrite(this, null);
						MarkLabel(label);
						return;
					}
				}
				tail.EmitWrite(this, valueFrom);
			}
			else
			{
				LoadValue(valueFrom);
				CopyValue();
				CodeLabel label2 = DefineLabel();
				CodeLabel label3 = DefineLabel();
				BranchIfTrue(label2, @short: true);
				DiscardValue();
				Branch(label3, @short: false);
				MarkLabel(label2);
				tail.EmitWrite(this, null);
				MarkLabel(label3);
			}
		}

		internal void ReadNullCheckedTail(Type type, IRuntimeProtoSerializerNode tail, Local valueFrom)
		{
			Type underlyingType;
			if (type.IsValueType && (object)(underlyingType = Nullable.GetUnderlyingType(type)) != null)
			{
				if (tail.RequiresOldValue)
				{
					using Local local = GetLocalWithValue(type, valueFrom);
					LoadAddress(local, type);
					EmitCall(type.GetMethod("GetValueOrDefault", Type.EmptyTypes));
				}
				tail.EmitRead(this, null);
				if (tail.ReturnsValue)
				{
					EmitCtor(type, underlyingType);
				}
			}
			else
			{
				tail.EmitRead(this, valueFrom);
			}
		}

		public void EmitCtor(Type type)
		{
			EmitCtor(type, Type.EmptyTypes);
		}

		public void EmitCtor(ConstructorInfo ctor)
		{
			if ((object)ctor == null)
			{
				throw new ArgumentNullException("ctor");
			}
			MemberInfo member = ctor;
			CheckAccessibility(ref member);
			il.Emit(OpCodes.Newobj, ctor);
		}

		public void InitLocal(Type type, Local target)
		{
			LoadAddress(target, type, evenIfClass: true);
			il.Emit(OpCodes.Initobj, type);
		}

		public void EmitCtor(Type type, params Type[] parameterTypes)
		{
			if (type.IsValueType && parameterTypes.Length == 0)
			{
				il.Emit(OpCodes.Initobj, type);
				return;
			}
			ConstructorInfo constructor = Helpers.GetConstructor(type, parameterTypes, nonPublic: true);
			if ((object)constructor == null)
			{
				throw new InvalidOperationException("No suitable constructor found for " + type.FullName);
			}
			EmitCtor(constructor);
		}

		private bool InternalsVisible(Assembly assembly)
		{
			if (string.IsNullOrEmpty(Scope.AssemblyName))
			{
				return false;
			}
			if (knownTrustedAssemblies != null && knownTrustedAssemblies.IndexOf(assembly) >= 0)
			{
				return true;
			}
			if (knownUntrustedAssemblies != null && knownUntrustedAssemblies.IndexOf(assembly) >= 0)
			{
				return false;
			}
			bool flag = false;
			Type typeFromHandle = typeof(InternalsVisibleToAttribute);
			if ((object)typeFromHandle == null)
			{
				return false;
			}
			object[] customAttributes = assembly.GetCustomAttributes(typeFromHandle, inherit: false);
			for (int i = 0; i < customAttributes.Length; i++)
			{
				InternalsVisibleToAttribute internalsVisibleToAttribute = (InternalsVisibleToAttribute)customAttributes[i];
				if (internalsVisibleToAttribute.AssemblyName == Scope.AssemblyName || internalsVisibleToAttribute.AssemblyName.StartsWith(Scope.AssemblyName + ",", StringComparison.Ordinal))
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				(knownTrustedAssemblies ?? (knownTrustedAssemblies = new List<Assembly>())).Add(assembly);
			}
			else
			{
				(knownUntrustedAssemblies ?? (knownUntrustedAssemblies = new List<Assembly>())).Add(assembly);
			}
			return flag;
		}

		internal void CheckAccessibility(ref MemberInfo member)
		{
			if ((object)member == null)
			{
				throw new ArgumentNullException("member");
			}
			if (NonPublic)
			{
				return;
			}
			if (member is FieldInfo && (member.Name.StartsWith("<", StringComparison.Ordinal) & member.Name.EndsWith(">k__BackingField", StringComparison.Ordinal)))
			{
				string name = member.Name.Substring(1, member.Name.Length - 17);
				PropertyInfo property = member.DeclaringType.GetProperty(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
				if ((object)property != null)
				{
					member = property;
				}
			}
			MemberTypes memberType = member.MemberType;
			bool flag;
			switch (memberType)
			{
			case MemberTypes.TypeInfo:
			{
				Type type = (Type)member;
				flag = type.IsPublic || InternalsVisible(type.Assembly);
				break;
			}
			case MemberTypes.NestedType:
			{
				Type type = (Type)member;
				do
				{
					flag = type.IsNestedPublic || type.IsPublic || (((object)type.DeclaringType == null || type.IsNestedAssembly || type.IsNestedFamORAssem) && InternalsVisible(type.Assembly));
				}
				while (flag && (object)(type = type.DeclaringType) != null);
				break;
			}
			case MemberTypes.Field:
			{
				FieldInfo fieldInfo = (FieldInfo)member;
				flag = fieldInfo.IsPublic || ((fieldInfo.IsAssembly || fieldInfo.IsFamilyOrAssembly) && InternalsVisible(fieldInfo.DeclaringType.Assembly));
				break;
			}
			case MemberTypes.Constructor:
			{
				ConstructorInfo constructorInfo = (ConstructorInfo)member;
				flag = constructorInfo.IsPublic || ((constructorInfo.IsAssembly || constructorInfo.IsFamilyOrAssembly) && InternalsVisible(constructorInfo.DeclaringType.Assembly));
				break;
			}
			case MemberTypes.Method:
			{
				MethodInfo methodInfo = (MethodInfo)member;
				flag = methodInfo.IsPublic || ((methodInfo.IsAssembly || methodInfo.IsFamilyOrAssembly) && InternalsVisible(methodInfo.DeclaringType.Assembly));
				if (!flag && (member is MethodBuilder || member.DeclaringType == typeof(TypeModel)))
				{
					flag = true;
				}
				break;
			}
			case MemberTypes.Property:
				flag = true;
				break;
			default:
				throw new NotSupportedException(memberType.ToString());
			}
			if (flag)
			{
				return;
			}
			MemberInfo memberInfo = member;
			if (!(memberInfo is FieldBuilder) && !(memberInfo is TypeBuilder) && !(memberInfo is PropertyBuilder))
			{
				if (memberType == MemberTypes.TypeInfo || memberType == MemberTypes.NestedType)
				{
					throw new InvalidOperationException("Non-public type cannot be used with full dll compilation: " + ((Type)member).NormalizeName());
				}
				throw new InvalidOperationException("Non-public member cannot be used with full dll compilation: " + member.DeclaringType.NormalizeName() + "." + member.Name);
			}
		}

		public void LoadValue(FieldInfo field, bool checkAccessibility = true)
		{
			MemberInfo member = field;
			if (checkAccessibility)
			{
				CheckAccessibility(ref member);
			}
			if (member is PropertyInfo property)
			{
				LoadValue(property);
				return;
			}
			OpCode opcode = (field.IsStatic ? OpCodes.Ldsfld : OpCodes.Ldfld);
			il.Emit(opcode, field);
		}

		public void StoreValue(FieldInfo field)
		{
			MemberInfo member = field;
			CheckAccessibility(ref member);
			if (member is PropertyInfo property)
			{
				StoreValue(property);
				return;
			}
			OpCode opcode = (field.IsStatic ? OpCodes.Stsfld : OpCodes.Stfld);
			il.Emit(opcode, field);
		}

		public void LoadValue(PropertyInfo property)
		{
			MemberInfo member = property;
			CheckAccessibility(ref member);
			EmitCall(Helpers.GetGetMethod(property, nonPublic: true, allowInternal: true));
		}

		public void StoreValue(PropertyInfo property)
		{
			MemberInfo member = property;
			CheckAccessibility(ref member);
			EmitCall(Helpers.GetSetMethod(property, nonPublic: true, allowInternal: true));
		}

		internal static void LoadValue(ILGenerator il, int value)
		{
			switch (value)
			{
			case 0:
				il.Emit(OpCodes.Ldc_I4_0);
				return;
			case 1:
				il.Emit(OpCodes.Ldc_I4_1);
				return;
			case 2:
				il.Emit(OpCodes.Ldc_I4_2);
				return;
			case 3:
				il.Emit(OpCodes.Ldc_I4_3);
				return;
			case 4:
				il.Emit(OpCodes.Ldc_I4_4);
				return;
			case 5:
				il.Emit(OpCodes.Ldc_I4_5);
				return;
			case 6:
				il.Emit(OpCodes.Ldc_I4_6);
				return;
			case 7:
				il.Emit(OpCodes.Ldc_I4_7);
				return;
			case 8:
				il.Emit(OpCodes.Ldc_I4_8);
				return;
			case -1:
				il.Emit(OpCodes.Ldc_I4_M1);
				return;
			}
			if (value >= -128 && value <= 127)
			{
				il.Emit(OpCodes.Ldc_I4_S, (sbyte)value);
			}
			else
			{
				il.Emit(OpCodes.Ldc_I4, value);
			}
		}

		private bool UseShortForm(Local local)
		{
			return local.Value.LocalIndex < 256;
		}

		internal void LoadAddress(Local local, Type type, bool evenIfClass = false)
		{
			if (evenIfClass || type.IsValueType)
			{
				if (local == null)
				{
					throw new InvalidOperationException("Cannot load the address of the head of the stack");
				}
				if (local == InputValue)
				{
					il.Emit(OpCodes.Ldarga_S, _inputArg);
					return;
				}
				OpCode opcode = (UseShortForm(local) ? OpCodes.Ldloca_S : OpCodes.Ldloca);
				il.Emit(opcode, local.Value);
			}
			else
			{
				LoadValue(local);
			}
		}

		internal void Branch(CodeLabel label, bool @short)
		{
			OpCode opcode = (@short ? OpCodes.Br_S : OpCodes.Br);
			il.Emit(opcode, label.Value);
		}

		internal void BranchIfFalse(CodeLabel label, bool @short)
		{
			OpCode opcode = (@short ? OpCodes.Brfalse_S : OpCodes.Brfalse);
			il.Emit(opcode, label.Value);
		}

		internal void BranchIfTrue(CodeLabel label, bool @short)
		{
			OpCode opcode = (@short ? OpCodes.Brtrue_S : OpCodes.Brtrue);
			il.Emit(opcode, label.Value);
		}

		internal void BranchIfEqual(CodeLabel label, bool @short)
		{
			OpCode opcode = (@short ? OpCodes.Beq_S : OpCodes.Beq);
			il.Emit(opcode, label.Value);
		}

		internal void CopyValue()
		{
			Emit(OpCodes.Dup);
		}

		internal void BranchIfGreater(CodeLabel label, bool @short)
		{
			OpCode opcode = (@short ? OpCodes.Bgt_S : OpCodes.Bgt);
			il.Emit(opcode, label.Value);
		}

		internal void BranchIfLess(CodeLabel label, bool @short)
		{
			OpCode opcode = (@short ? OpCodes.Blt_S : OpCodes.Blt);
			il.Emit(opcode, label.Value);
		}

		internal void DiscardValue()
		{
			Emit(OpCodes.Pop);
		}

		public void Subtract()
		{
			Emit(OpCodes.Sub);
		}

		public void Switch(CodeLabel[] jumpTable)
		{
			if (jumpTable.Length <= 128)
			{
				Label[] array = new Label[jumpTable.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = jumpTable[i].Value;
				}
				il.Emit(OpCodes.Switch, array);
				return;
			}
			using Local local = GetLocalWithValue(typeof(int), null);
			int num = jumpTable.Length;
			int num2 = 0;
			int num3 = num / 128;
			if (num % 128 != 0)
			{
				num3++;
			}
			Label[] array2 = new Label[num3];
			for (int j = 0; j < num3; j++)
			{
				array2[j] = il.DefineLabel();
			}
			CodeLabel label = DefineLabel();
			LoadValue(local);
			LoadValue(128);
			Emit(OpCodes.Div);
			il.Emit(OpCodes.Switch, array2);
			Branch(label, @short: false);
			Label[] array3 = new Label[128];
			for (int k = 0; k < num3; k++)
			{
				il.MarkLabel(array2[k]);
				int num4 = Math.Min(128, num);
				num -= num4;
				if (array3.Length != num4)
				{
					array3 = new Label[num4];
				}
				int num5 = num2;
				for (int l = 0; l < num4; l++)
				{
					array3[l] = jumpTable[num2++].Value;
				}
				LoadValue(local);
				if (num5 != 0)
				{
					LoadValue(num5);
					Emit(OpCodes.Sub);
				}
				il.Emit(OpCodes.Switch, array3);
				if (num != 0)
				{
					Branch(label, @short: false);
				}
			}
			MarkLabel(label);
		}

		internal void EndFinally()
		{
			il.EndExceptionBlock();
		}

		internal void BeginFinally()
		{
			il.BeginFinallyBlock();
		}

		internal void EndTry(CodeLabel label, bool @short)
		{
			OpCode opcode = (@short ? OpCodes.Leave_S : OpCodes.Leave);
			il.Emit(opcode, label.Value);
		}

		internal CodeLabel BeginTry()
		{
			CodeLabel result = new CodeLabel(il.BeginExceptionBlock(), nextLabel++);
			return result;
		}

		internal void Constrain(Type type)
		{
			il.Emit(OpCodes.Constrained, type);
		}

		internal void TryCast(Type type)
		{
			il.Emit(OpCodes.Isinst, type);
		}

		internal void Cast(Type type)
		{
			il.Emit(OpCodes.Castclass, type);
		}

		public IDisposable Using(Local local)
		{
			return new UsingBlock(this, local);
		}

		internal void Add()
		{
			Emit(OpCodes.Add);
		}

		internal void LoadLength(Local arr, bool zeroIfNull)
		{
			if (zeroIfNull)
			{
				CodeLabel label = DefineLabel();
				CodeLabel label2 = DefineLabel();
				LoadValue(arr);
				CopyValue();
				BranchIfTrue(label, @short: true);
				DiscardValue();
				LoadValue(0);
				Branch(label2, @short: true);
				MarkLabel(label);
				Emit(OpCodes.Ldlen);
				Emit(OpCodes.Conv_I4);
				MarkLabel(label2);
			}
			else
			{
				LoadValue(arr);
				Emit(OpCodes.Ldlen);
				Emit(OpCodes.Conv_I4);
			}
		}

		internal void CreateArray(Type elementType, Local length)
		{
			LoadValue(length);
			il.Emit(OpCodes.Newarr, elementType);
		}

		internal void LoadArrayValue(Local arr, Local i)
		{
			Type type = arr.Type;
			type = type.GetElementType();
			LoadValue(arr);
			LoadValue(i);
			switch (Helpers.GetTypeCode(type))
			{
			case ProtoTypeCode.SByte:
				Emit(OpCodes.Ldelem_I1);
				return;
			case ProtoTypeCode.Int16:
				Emit(OpCodes.Ldelem_I2);
				return;
			case ProtoTypeCode.Int32:
				Emit(OpCodes.Ldelem_I4);
				return;
			case ProtoTypeCode.Int64:
				Emit(OpCodes.Ldelem_I8);
				return;
			case ProtoTypeCode.Byte:
				Emit(OpCodes.Ldelem_U1);
				return;
			case ProtoTypeCode.UInt16:
				Emit(OpCodes.Ldelem_U2);
				return;
			case ProtoTypeCode.UInt32:
				Emit(OpCodes.Ldelem_U4);
				return;
			case ProtoTypeCode.UInt64:
				Emit(OpCodes.Ldelem_I8);
				return;
			case ProtoTypeCode.Single:
				Emit(OpCodes.Ldelem_R4);
				return;
			case ProtoTypeCode.Double:
				Emit(OpCodes.Ldelem_R8);
				return;
			}
			if (type.IsValueType)
			{
				il.Emit(OpCodes.Ldelema, type);
				il.Emit(OpCodes.Ldobj, type);
			}
			else
			{
				Emit(OpCodes.Ldelem_Ref);
			}
		}

		internal static void LoadValue(ILGenerator il, Type type)
		{
			il.Emit(OpCodes.Ldtoken, type);
			il.EmitCall(OpCodes.Call, typeof(Type).GetMethod("GetTypeFromHandle"), null);
		}

		internal void LoadValue(Type type)
		{
			il.Emit(OpCodes.Ldtoken, type);
			EmitCall(typeof(Type).GetMethod("GetTypeFromHandle"));
		}

		internal void ConvertToInt32(ProtoTypeCode typeCode, bool uint32Overflow)
		{
			switch (typeCode)
			{
			case ProtoTypeCode.SByte:
			case ProtoTypeCode.Byte:
			case ProtoTypeCode.Int16:
			case ProtoTypeCode.UInt16:
				Emit(OpCodes.Conv_I4);
				break;
			case ProtoTypeCode.Int64:
				Emit(OpCodes.Conv_Ovf_I4);
				break;
			case ProtoTypeCode.UInt32:
				Emit(uint32Overflow ? OpCodes.Conv_Ovf_I4_Un : OpCodes.Conv_Ovf_I4);
				break;
			case ProtoTypeCode.UInt64:
				Emit(OpCodes.Conv_Ovf_I4_Un);
				break;
			default:
				throw new InvalidOperationException("ConvertToInt32 not implemented for: " + typeCode);
			case ProtoTypeCode.Int32:
				break;
			}
		}

		internal void ConvertFromInt32(ProtoTypeCode typeCode, bool uint32Overflow)
		{
			switch (typeCode)
			{
			case ProtoTypeCode.SByte:
				Emit(OpCodes.Conv_Ovf_I1);
				break;
			case ProtoTypeCode.Byte:
				Emit(OpCodes.Conv_Ovf_U1);
				break;
			case ProtoTypeCode.Int16:
				Emit(OpCodes.Conv_Ovf_I2);
				break;
			case ProtoTypeCode.UInt16:
				Emit(OpCodes.Conv_Ovf_U2);
				break;
			case ProtoTypeCode.UInt32:
				Emit(uint32Overflow ? OpCodes.Conv_Ovf_U4 : OpCodes.Conv_U4);
				break;
			case ProtoTypeCode.Int64:
				Emit(OpCodes.Conv_I8);
				break;
			case ProtoTypeCode.UInt64:
				Emit(OpCodes.Conv_U8);
				break;
			default:
				throw new InvalidOperationException();
			case ProtoTypeCode.Int32:
				break;
			}
		}

		internal void LoadValue(decimal value)
		{
			if (value == 0m)
			{
				LoadValue(typeof(decimal).GetField("Zero"));
				return;
			}
			int[] bits = decimal.GetBits(value);
			LoadValue(bits[0]);
			LoadValue(bits[1]);
			LoadValue(bits[2]);
			LoadValue((int)((uint)bits[3] >> 31));
			LoadValue((bits[3] >> 16) & 0xFF);
			EmitCtor(typeof(decimal), typeof(int), typeof(int), typeof(int), typeof(bool), typeof(byte));
		}

		internal void LoadValue(Guid value)
		{
			if (value == Guid.Empty)
			{
				LoadValue(typeof(Guid).GetField("Empty"));
				return;
			}
			byte[] array = value.ToByteArray();
			int value2 = array[0] | (array[1] << 8) | (array[2] << 16) | (array[3] << 24);
			LoadValue(value2);
			short value3 = (short)(array[4] | (array[5] << 8));
			LoadValue(value3);
			value3 = (short)(array[6] | (array[7] << 8));
			LoadValue(value3);
			for (value2 = 8; value2 <= 15; value2++)
			{
				LoadValue(array[value2]);
			}
			EmitCtor(typeof(Guid), typeof(int), typeof(short), typeof(short), typeof(byte), typeof(byte), typeof(byte), typeof(byte), typeof(byte), typeof(byte), typeof(byte), typeof(byte));
		}

		internal void LoadSerializationContext(Type asType)
		{
			LoadState();
			switch (_signature)
			{
			case SignatureType.WriterScope_Input:
				LoadValue(typeof(ProtoWriter.State).GetProperty("Context"));
				break;
			case SignatureType.ReaderScope_Input:
				LoadValue(typeof(ProtoReader.State).GetProperty("Context"));
				break;
			case SignatureType.Context:
				LoadValue(InputValue);
				break;
			default:
				ThrowHelper.ThrowInvalidOperationException($"Cannot load context for {_signature}");
				break;
			}
			if (!(asType == typeof(ISerializationContext)))
			{
				if (asType == typeof(SerializationContext))
				{
					EmitCall(typeof(SerializationContext).GetMethod("AsSerializationContext"));
				}
				else if (asType == typeof(StreamingContext))
				{
					EmitCall(typeof(SerializationContext).GetMethod("AsStreamingContext"));
				}
				else
				{
					ThrowHelper.ThrowArgumentException("Unexpected context type: " + asType.NormalizeName());
				}
			}
		}

		internal bool AllowInternal(PropertyInfo property)
		{
			if (!NonPublic)
			{
				return InternalsVisible(property.DeclaringType.Assembly);
			}
			return true;
		}
	}
}

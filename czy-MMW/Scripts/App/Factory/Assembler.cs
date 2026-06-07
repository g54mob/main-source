using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Factory.Allocators;
using JetBrains.Annotations;

namespace Factory
{
	public class Assembler : IDisposable
	{
		private interface ITypeAssembler : IDisposable
		{
			Assembler ScopeAssembler { get; }

			object Create(IScope context);

			void Assemble([NotNull] object obj, IScope context);

			bool Release(object obj, IScope context);
		}

		private class TypeAssembler<T> : ITypeAssembler, IDisposable where T : class
		{
			private class Dependency
			{
				private readonly Func<object, int> DefaultGetLengthDelegate = (object target) => 1;

				public Type Type { get; }

				public Action<object, int, object> SetDelegate { get; }

				public Func<object, int> GetLengthDelegate { get; }

				public static Dependency CreateField(FieldInfo field)
				{
					if (field.FieldType.IsArray)
					{
						Action<object, int, object> setDelegate = delegate(object target, int index, object param)
						{
							(field.GetValue(target) as IList)[index] = param;
						};
						Func<object, int> getLengthDelegate = (object target) => (field.GetValue(target) as IList).Count;
						return new Dependency(field.FieldType.GetElementType(), setDelegate, getLengthDelegate);
					}
					Action<object, object> setDelegate2 = delegate(object target, object param)
					{
						field.SetValue(target, param);
					};
					return new Dependency(field.FieldType, setDelegate2);
				}

				public static Dependency CreateProperty(PropertyInfo property)
				{
					MethodInfo setMethod = property.GetSetMethod(nonPublic: true);
					if (setMethod == null)
					{
						Log.Error("Unable to get set method for property {0}.", property);
						return null;
					}
					return new Dependency(property.PropertyType, CreateSetDelegate(typeof(T), setMethod));
				}

				private Dependency(Type type, Action<object, object> setDelegate)
				{
					Type = type;
					SetDelegate = delegate(object target, int index, object param)
					{
						setDelegate(target, param);
					};
					GetLengthDelegate = DefaultGetLengthDelegate;
				}

				private Dependency(Type elementType, Action<object, int, object> setDelegate, Func<object, int> getLengthDelegate)
				{
					Type = elementType;
					SetDelegate = setDelegate;
					GetLengthDelegate = getLengthDelegate;
				}
			}

			private List<Type> _interfaceTypes = new List<Type>();

			private List<Dependency> _dependencies;

			private bool _hasCreatedHandler;

			private bool _hasReleasedHandler;

			public Binding Binding { get; set; }

			public IAllocator<T> Allocator { get; set; }

			public bool EstablishesScope { get; set; }

			public Assembler ScopeAssembler { get; set; }

			public TypeAssembler(Type interfaceType)
			{
				Binding = Binding.Free;
				Type type = typeof(T);
				if (type != interfaceType)
				{
					if (interfaceType.IsInterface)
					{
						Type type2 = type;
						while (Array.IndexOf(type2.GetInterfaces(), interfaceType) >= 0)
						{
							_interfaceTypes.Add(type2);
							type2 = type2.BaseType;
						}
					}
					else
					{
						Type type3 = type;
						while (type3 != interfaceType)
						{
							_interfaceTypes.Add(type3);
							type3 = type3.BaseType;
						}
					}
				}
				_interfaceTypes.Add(interfaceType);
				while (type != null)
				{
					FieldInfo[] fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					foreach (FieldInfo fieldInfo in fields)
					{
						if (fieldInfo.IsDefined(typeof(DependencyAttribute), inherit: false))
						{
							Dependency dependency = Dependency.CreateField(fieldInfo);
							AddDependency(dependency);
						}
					}
					PropertyInfo[] properties = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					foreach (PropertyInfo propertyInfo in properties)
					{
						if (propertyInfo.IsDefined(typeof(DependencyAttribute), inherit: false))
						{
							Dependency dependency2 = Dependency.CreateProperty(propertyInfo);
							AddDependency(dependency2);
						}
					}
					type = type.BaseType;
				}
				_hasCreatedHandler = typeof(ICreatedInScopeHandler).IsAssignableFrom(typeof(T));
				_hasReleasedHandler = typeof(IReleasedFromScopeHandler).IsAssignableFrom(typeof(T));
			}

			public object Create(IScope scope)
			{
				T val = Allocator.Allocate(scope);
				if (val == null)
				{
					return null;
				}
				IScope scope2 = scope;
				if (EstablishesScope)
				{
					Scope scope3 = new Scope(ScopeAssembler ?? scope.Assembler, val);
					scope3.ParentScope = scope;
					scope.AddChildScope(scope3, val);
					scope = scope3;
				}
				if (scope == null)
				{
					return val;
				}
				IScope scope4 = null;
				if (Binding == Binding.Scope)
				{
					scope4 = scope2;
				}
				else if (Binding == Binding.EstablishedScope)
				{
					scope4 = scope;
				}
				if (scope4 != null)
				{
					foreach (Type interfaceType in _interfaceTypes)
					{
						scope4.Set(interfaceType, val);
					}
				}
				Assemble(val, scope);
				Allocator.OnObjectAssembled(val, scope);
				return val;
			}

			public void Assemble(object obj, IScope scope)
			{
				if (_dependencies != null)
				{
					foreach (Dependency dependency in _dependencies)
					{
						int num = dependency.GetLengthDelegate(obj);
						for (int i = 0; i < num; i++)
						{
							object arg = scope.Get(dependency.Type);
							dependency.SetDelegate(obj, i, arg);
						}
					}
				}
				if (_hasCreatedHandler)
				{
					(obj as ICreatedInScopeHandler).OnCreatedInScope(scope);
				}
			}

			public bool Release(object obj, IScope scope)
			{
				if (_hasReleasedHandler)
				{
					(obj as IReleasedFromScopeHandler).OnReleasedFromScope(scope);
				}
				bool result = Allocator.Release((T)obj, scope);
				if (Binding == Binding.Scope)
				{
					foreach (Type interfaceType in _interfaceTypes)
					{
						scope.Unset(interfaceType);
					}
				}
				return result;
			}

			public void Dispose()
			{
				if (Allocator != null)
				{
					Allocator.Dispose();
					Allocator = null;
				}
			}

			private void AddDependency(Dependency dependency)
			{
				if (_dependencies == null)
				{
					_dependencies = new List<Dependency>();
				}
				_dependencies.Add(dependency);
			}
		}

		public class TypeConfigurator<T> where T : class
		{
			private readonly TypeAssembler<T> _typeAssembler;

			public TypeConfigurator(Assembler assembler, Type interfaceType)
			{
				_typeAssembler = assembler._typeAssemblers[interfaceType] as TypeAssembler<T>;
			}

			public TypeConfigurator<T> Binding(Binding binding)
			{
				_typeAssembler.Binding = binding;
				return this;
			}

			public TypeConfigurator<T> Allocator(IAllocator<T> allocator)
			{
				_typeAssembler.Allocator = allocator;
				return this;
			}

			public TypeConfigurator<T> EstablishScope(Assembler assembler = null)
			{
				_typeAssembler.EstablishesScope = true;
				_typeAssembler.ScopeAssembler = assembler;
				return this;
			}
		}

		private static readonly Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("Assembler");

		private readonly Dictionary<Type, ITypeAssembler> _typeAssemblers = new Dictionary<Type, ITypeAssembler>();

		private readonly Dictionary<int, ITypeSerializer> _typeSerializers = new Dictionary<int, ITypeSerializer>();

		private readonly Dictionary<Type, int> _typeIds = new Dictionary<Type, int>();

		private int _globalTypeSerializerHashCode;

		public bool IsValidatingObjectScrubbing { get; set; }

		public string Name { get; private set; }

		public int GlobalTypeSerializerHashCode => _globalTypeSerializerHashCode;

		public Assembler(string name)
		{
			Name = name;
		}

		public TypeConfigurator<TConcrete> Register<TInterface, TConcrete>() where TConcrete : class, TInterface
		{
			Type typeFromHandle = typeof(TInterface);
			Type typeFromHandle2 = typeof(TConcrete);
			if (typeof(TInterface) != typeof(TConcrete))
			{
				Log.Info("Creating TypeAssembler for {0}, bound to interface {1}.", typeof(TConcrete), typeof(TInterface));
			}
			else
			{
				Log.Info("Creating TypeAssembler for {0}.", typeof(TConcrete));
			}
			TypeAssembler<TConcrete> value = new TypeAssembler<TConcrete>(typeFromHandle);
			_typeAssemblers[typeFromHandle] = value;
			if (typeFromHandle2 != typeFromHandle)
			{
				_typeAssemblers[typeFromHandle2] = value;
			}
			if (TypeUtilities.GetCustomAttribute<SerializableAttribute>(typeFromHandle2) != null)
			{
				ITypeSerializer typeSerializer = new TypeSerializer<TConcrete>();
				_typeSerializers[typeSerializer.TypeId] = typeSerializer;
				_typeIds[typeFromHandle2] = typeSerializer.TypeId;
				int hashCode = typeSerializer.GetHashCode();
				_globalTypeSerializerHashCode ^= hashCode;
				Log.Info("Creating TypeSerializer for {0} with a hash code of {1}. The assembler's serializer hash code is now {2}.", typeof(TConcrete), hashCode, _globalTypeSerializerHashCode);
			}
			return new TypeConfigurator<TConcrete>(this, typeFromHandle);
		}

		public TypeConfigurator<T> Register<T>() where T : class
		{
			return Register<T, T>();
		}

		public T Create<T>(IScope scope) where T : class
		{
			return Create(typeof(T), scope) as T;
		}

		public object Create(Type type, IScope scope)
		{
			if (!_typeAssemblers.TryGetValue(type, out var value))
			{
				return null;
			}
			return value.Create(scope);
		}

		public void Assemble([NotNull] object obj, IScope scope)
		{
			if (!_typeAssemblers.TryGetValue(obj.GetType(), out var value))
			{
				Diagnostics.FailAssert($"{Name} could not assemble {obj}.");
			}
			else
			{
				value.Assemble(obj, scope);
			}
		}

		public Assembler GetAssemblerForType(Type type)
		{
			if (!_typeAssemblers.TryGetValue(type, out var value))
			{
				return null;
			}
			Assembler scopeAssembler = value.ScopeAssembler;
			if (scopeAssembler != null)
			{
				return scopeAssembler;
			}
			return this;
		}

		public IEnumerable<Type> GetRegisteredTypesAssignableToType(Type type)
		{
			foreach (Type key in _typeAssemblers.Keys)
			{
				if (type.IsAssignableFrom(key))
				{
					yield return key;
				}
			}
		}

		public object Import(ImportContext context)
		{
			try
			{
				return ImportUnsafe(context);
			}
			catch (Exception ex)
			{
				Diagnostics.FailAssert("{0}", ex);
				return null;
			}
		}

		public void Dispose()
		{
			foreach (ITypeAssembler value in _typeAssemblers.Values)
			{
				value.Dispose();
			}
			_typeAssemblers.Clear();
		}

		private object ImportUnsafe(ImportContext context)
		{
			List<ITypeSerializer> list = new List<ITypeSerializer>();
			List<List<object>> list2 = new List<List<object>>();
			Stopwatch stopwatch = Stopwatch.StartNew();
			Stopwatch stopwatch2 = Stopwatch.StartNew();
			long position = context.Reader.BaseStream.Position;
			long num = context.Reader.ReadInt64();
			if (context.Reader.BaseStream.Length - position < num)
			{
				Log.Error("Malformed stream encountered during import. Total import size is reported as {0} bytes, but only {1} bytes left are the stream.", num, context.Reader.BaseStream.Length - position);
				return null;
			}
			int num2 = context.Reader.ReadInt32();
			if (num2 != _globalTypeSerializerHashCode)
			{
				Log.Info("Unable to import stream as the stream's global serializer hash code ({0}) differs from ours ({1}).", num2, _globalTypeSerializerHashCode);
				return null;
			}
			int num3 = context.Reader.ReadInt32();
			int num4 = context.Reader.ReadInt32();
			for (int i = 0; i < num4; i++)
			{
				int num5 = context.Reader.ReadInt32();
				ITypeSerializer serializer = GetSerializer(num5);
				if (!Diagnostics.Verify(serializer != null, "Unable to import type with id {0}.", num5))
				{
					return null;
				}
				int num6 = context.Reader.ReadInt32();
				if (serializer.GetHashCode() != num6)
				{
					Log.Info("Unable to import type {0} because the serializer hash codes differ. Theirs is {1}, ours is {2}.", serializer.Type, num6, serializer.GetHashCode());
					return null;
				}
				if (i == 0 && serializer.Version != num3)
				{
					Log.Info("Unable to import root object type of version {0} with local serializer of version {1}.", num3, serializer.Version);
					return null;
				}
				int num7 = context.Reader.ReadInt32();
				List<object> list3 = new List<object>();
				for (int j = 0; j < num7; j++)
				{
					object obj = context.Scope.Get(serializer.Type);
					context.AddObject(obj);
					list3.Add(obj);
				}
				list.Add(serializer);
				list2.Add(list3);
			}
			stopwatch2.Stop();
			bool flag = true;
			for (int k = 0; k < list.Count && flag; k++)
			{
				ITypeSerializer typeSerializer = list[k];
				List<object> list4 = list2[k];
				try
				{
					foreach (object item in list4)
					{
						if (typeSerializer.Deserialize(item, context) == null)
						{
							Log.Error("Object of type {0} failed to deserialise.", typeSerializer.Type);
							flag = false;
							break;
						}
					}
				}
				catch (InvalidCastException ex)
				{
					Log.Error("Caught exception while during deserialisation.\n{0}", ex);
					flag = false;
				}
			}
			if (!flag)
			{
				foreach (List<object> item2 in list2)
				{
					foreach (object item3 in item2)
					{
						context.Scope.Release(item3);
					}
				}
				return null;
			}
			context.MapDictionaries();
			for (int l = 0; l < list.Count; l++)
			{
				ITypeSerializer typeSerializer2 = list[l];
				if (!typeof(IDeserializedHandler).IsAssignableFrom(typeSerializer2.Type))
				{
					continue;
				}
				foreach (object item4 in list2[l])
				{
					IDeserializedHandler deserializedHandler = item4 as IDeserializedHandler;
					if (Diagnostics.Verify(deserializedHandler != null, "Unable to find IDeserializedHandler interface on {0}.", item4))
					{
						deserializedHandler.OnDeserialized(context.Scope);
					}
				}
			}
			object obj2 = null;
			if (list2.Count > 0 && list2[0].Count > 0)
			{
				obj2 = list2[0][0];
			}
			stopwatch.Stop();
			long elapsedTicks = stopwatch.ElapsedTicks;
			long elapsedTicks2 = stopwatch2.ElapsedTicks;
			Log.Info("Deserialized {0}:\n\tinstancing: {1:0.00}s ({2:00}%)\n\tdeserialising: {3:0.00}s ({4:00}%)", obj2?.GetType(), (float)elapsedTicks2 / (float)Stopwatch.Frequency, (float)elapsedTicks2 / (float)elapsedTicks * 100f, (float)(elapsedTicks - elapsedTicks2) / (float)Stopwatch.Frequency, (float)(elapsedTicks - elapsedTicks2) / (float)elapsedTicks * 100f);
			return obj2;
		}

		public bool Export(object obj, ExportContext context)
		{
			ExportContext.ObjectLibrary library = context.Library;
			Stopwatch stopwatch = Stopwatch.StartNew();
			Stopwatch stopwatch2 = Stopwatch.StartNew();
			long position = context.Writer.BaseStream.Position;
			long value = 0L;
			context.Writer.Write(value);
			context.Writer.Write(_globalTypeSerializerHashCode);
			ITypeSerializer serializer = GetSerializer(obj.GetType());
			if (!Diagnostics.Verify(serializer != null, "Cannot find type serializer for root object {0}.", obj))
			{
				return false;
			}
			context.Writer.Write(serializer.Version);
			int num = 0;
			List<object> list = new List<object>();
			list.Add(obj);
			while (list.Count > 0)
			{
				num++;
				object obj2 = list[list.Count - 1];
				list.RemoveAt(list.Count - 1);
				if (library.ContainsObject(obj2))
				{
					continue;
				}
				library.AddObject(obj2);
				ITypeSerializer serializer2 = GetSerializer(obj2.GetType());
				if (!Diagnostics.Verify(serializer2 != null, "Cannot find type serializer for {0}.", obj2))
				{
					return false;
				}
				foreach (object nestedObject in serializer2.GetNestedObjects(obj2))
				{
					if (nestedObject != null)
					{
						list.Add(nestedObject);
					}
				}
			}
			library.BuildIndex();
			context.Writer.Write(library.Types.Count);
			foreach (Type type in library.Types)
			{
				context.Writer.Write(_typeIds[type]);
				context.Writer.Write(GetSerializer(type).GetHashCode());
				context.Writer.Write(library.GetObjectsOfType(type).Count);
			}
			long position2 = context.Writer.BaseStream.Position;
			stopwatch2.Stop();
			Log.Info("Collated {0} objects in {1:0.00}s. Table of contents is {2} bytes.", num, stopwatch2.ElapsedTicks / Stopwatch.Frequency, position2 - position);
			bool flag = true;
			foreach (Type type2 in library.Types)
			{
				Stopwatch stopwatch3 = Stopwatch.StartNew();
				num = 0;
				ITypeSerializer serializer3 = GetSerializer(type2);
				foreach (object item in library.GetObjectsOfType(type2))
				{
					num++;
					if (!serializer3.Serialize(item, context))
					{
						flag = false;
						break;
					}
				}
				stopwatch3.Stop();
				Log.Info("Serialized {0} x {1} in {2:0.00}s, {3} bytes.", num, type2, stopwatch3.ElapsedTicks / Stopwatch.Frequency, context.Writer.BaseStream.Position - position2);
				position2 = context.Writer.BaseStream.Position;
				if (!flag)
				{
					break;
				}
			}
			if (!flag)
			{
				Log.Info("Failed to serialize!");
				stopwatch.Stop();
				return false;
			}
			context.Writer.BaseStream.Position = position;
			value = position2 - position;
			context.Writer.Write(value);
			context.Writer.BaseStream.Position = position2;
			stopwatch.Stop();
			Log.Info("Serialized {0} in {1:0.00}s total, {2} bytes.", obj.GetType(), stopwatch.ElapsedTicks / Stopwatch.Frequency, context.Writer.BaseStream.Position - position);
			return true;
		}

		public bool Release<T>(T obj, IScope context)
		{
			if (_typeAssemblers.TryGetValue(obj.GetType(), out var value))
			{
				value.Release(obj, context);
				return true;
			}
			return false;
		}

		public Type TranslateTypeId(int typeId)
		{
			ITypeSerializer serializer = GetSerializer(typeId);
			if (Diagnostics.Verify(serializer != null, "Cannot determine type for unknown type id {0}.", typeId))
			{
				return serializer.Type;
			}
			return null;
		}

		private ITypeAssembler GetAssembler(Type type)
		{
			if (_typeAssemblers.TryGetValue(type, out var value))
			{
				return value;
			}
			return null;
		}

		public static Func<object, object> CreateGetDelegate(Type declaringType, MethodInfo method)
		{
			return (Func<object, object>)typeof(Assembler).GetMethod("CreateGenericGetDelegate", BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(declaringType, method.ReturnType).Invoke(null, new object[1] { method });
		}

		private static Func<object, object> CreateGenericGetDelegate<TTarget, TReturn>(MethodInfo method) where TTarget : class
		{
			Func<TTarget, TReturn> typedDelegate = (Func<TTarget, TReturn>)Delegate.CreateDelegate(typeof(Func<TTarget, TReturn>), method);
			return (object target) => typedDelegate((TTarget)target);
		}

		public static Action<object, object> CreateSetDelegate(Type declaringType, MethodInfo method)
		{
			return (Action<object, object>)typeof(Assembler).GetMethod("CreateGenericSetDelegate", BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(declaringType, method.GetParameters()[0].ParameterType).Invoke(null, new object[1] { method });
		}

		private static Action<object, object> CreateGenericSetDelegate<TTarget, TParam>(MethodInfo method) where TTarget : class
		{
			Action<TTarget, TParam> typedDelegate = (Action<TTarget, TParam>)Delegate.CreateDelegate(typeof(Action<TTarget, TParam>), method);
			return delegate(object target, object param)
			{
				typedDelegate((TTarget)target, (TParam)param);
			};
		}

		private ITypeSerializer GetSerializer(Type objectType)
		{
			if (_typeIds.TryGetValue(objectType, out var value) && _typeSerializers.TryGetValue(value, out var value2))
			{
				return value2;
			}
			return null;
		}

		private ITypeSerializer GetSerializer(int typeId)
		{
			if (_typeSerializers.TryGetValue(typeId, out var value))
			{
				return value;
			}
			return null;
		}

		public static void DontCall_EnsureAOTGenericCallsAreCompiled<TTarget, TParam>() where TTarget : class
		{
			CreateGenericGetDelegate<TTarget, TParam>(null);
			CreateGenericSetDelegate<TTarget, TParam>(null);
		}
	}
}

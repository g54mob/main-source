using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Coherence.Log;
using UnityEngine;

namespace Coherence.Toolkit.Bindings
{
	[Serializable]
	[DebuggerDisplay("{Name}")]
	public class Descriptor : IEquatable<Descriptor>
	{
		internal const BindingFlags OnValueSyncedCallbackBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

		[SerializeField]
		private string name;

		[SerializeField]
		private string monoAssemblyType;

		[SerializeField]
		private bool required;

		[SerializeField]
		private bool enforcesLODingWhenFieldsOverriden;

		[SerializeField]
		private string valueSyncCallbackName;

		[SerializeField]
		private MemberTypes memberType;

		[SerializeField]
		private List<string> parameterAssemblyTypes;

		[SerializeField]
		private SerializableType ownerType;

		[SerializeField]
		private SyncMode defaultSyncMode;

		[SerializeReference]
		public object CustomData;

		[SerializeField]
		private SerializableType bindingType;

		[SerializeField]
		private string oldName;

		[SerializeField]
		private List<string> oldParameterAssemblyTypes;

		private bool methodCompatible;

		private MessageTarget defaultRouting;

		private int? cachedHashCode;

		private Coherence.Log.Logger logger;

		public string Name => null;

		public string MonoAssemblyType => null;

		public bool MethodCompatible => false;

		public virtual string BakedCSharpType => null;

		public bool IsMethod => false;

		public bool Required
		{
			get
			{
				return false;
			}
			internal set
			{
			}
		}

		public bool EnforcesLODingWhenFieldsOverriden => false;

		public string ValueSyncCallbackName
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public List<string> ParameterAssemblyTypes => null;

		public MemberTypes MemberType => default(MemberTypes);

		public Type BindingType => null;

		public Type OwnerType => null;

		public string OwnerAssemblyQualifiedName => null;

		public MessageTarget DefaultRouting => default(MessageTarget);

		public SyncMode DefaultSyncMode => default(SyncMode);

		public virtual string Signature => null;

		public Descriptor(Type ownerType, MemberInfo memberInfo)
		{
		}

		public Descriptor(Type ownerType, MethodInfo methodInfo)
		{
		}

		public Descriptor(string name, Type ownerType, Type bindingType, bool required = false)
		{
		}

		private void HandleRequiredCommand(MethodInfo methodInfo)
		{
		}

		public static bool operator ==(Descriptor obj1, Descriptor obj2)
		{
			return false;
		}

		public static bool operator !=(Descriptor obj1, Descriptor obj2)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(Descriptor other)
		{
			return false;
		}

		private int GenerateHashCode()
		{
			return 0;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public bool IsDescriptorRelated(Descriptor other)
		{
			return false;
		}

		public bool ShouldDefaultToNoneInterpolation()
		{
			return false;
		}

		internal Binding InstantiateBinding(Component component)
		{
			return null;
		}

		private bool IsMethodDescriptorRelated(Descriptor other)
		{
			return false;
		}

		private List<Type> GetParameterAssemblyRuntimeTypes()
		{
			return null;
		}

		private string GetCallbackNameFromAttribute(MemberInfo memberInfo)
		{
			return null;
		}

		private Type GetValueType(MemberInfo memberInfo)
		{
			return null;
		}

		private static Type GetParameterTypeFromBindingType(Type bindingType)
		{
			return null;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security;
using Castle.Core.Internal;
using Castle.DynamicProxy.Internal;

namespace Castle.DynamicProxy
{
	[Serializable]
	public class ProxyGenerationOptions : ISerializable
	{
		public static readonly ProxyGenerationOptions Default = new ProxyGenerationOptions();

		private List<object> mixins;

		private readonly IList<CustomAttributeInfo> additionalAttributes = new List<CustomAttributeInfo>();

		[NonSerialized]
		private MixinData mixinData;

		public IProxyGenerationHook Hook { get; set; }

		public IInterceptorSelector Selector { get; set; }

		public Type BaseTypeForInterfaceProxy { get; set; }

		public IList<CustomAttributeInfo> AdditionalAttributes => additionalAttributes;

		public MixinData MixinData
		{
			get
			{
				if (mixinData == null)
				{
					throw new InvalidOperationException("Call Initialize before accessing the MixinData property.");
				}
				return mixinData;
			}
		}

		public bool HasMixins
		{
			get
			{
				if (mixins != null)
				{
					return mixins.Count != 0;
				}
				return false;
			}
		}

		public ProxyGenerationOptions(IProxyGenerationHook hook)
		{
			BaseTypeForInterfaceProxy = typeof(object);
			Hook = hook;
		}

		public ProxyGenerationOptions()
			: this(new AllMethodsHook())
		{
		}

		private ProxyGenerationOptions(SerializationInfo info, StreamingContext context)
		{
			Hook = (IProxyGenerationHook)info.GetValue("hook", typeof(IProxyGenerationHook));
			Selector = (IInterceptorSelector)info.GetValue("selector", typeof(IInterceptorSelector));
			mixins = (List<object>)info.GetValue("mixins", typeof(List<object>));
			BaseTypeForInterfaceProxy = Type.GetType(info.GetString("baseTypeForInterfaceProxy.AssemblyQualifiedName"));
		}

		public void Initialize()
		{
			if (mixinData == null)
			{
				try
				{
					mixinData = new MixinData(mixins);
				}
				catch (ArgumentException ex)
				{
					throw new InvalidMixinConfigurationException("There is a problem with the mixins added to this ProxyGenerationOptions: " + ex.Message, ex);
				}
			}
		}

		[SecurityCritical]
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("hook", Hook);
			info.AddValue("selector", Selector);
			info.AddValue("mixins", mixins);
			info.AddValue("baseTypeForInterfaceProxy.AssemblyQualifiedName", BaseTypeForInterfaceProxy.AssemblyQualifiedName);
		}

		public void AddDelegateTypeMixin(Type delegateType)
		{
			if (delegateType == null)
			{
				throw new ArgumentNullException("delegateType");
			}
			if (!delegateType.IsDelegateType())
			{
				throw new ArgumentException("Type must be a delegate type.", "delegateType");
			}
			AddMixinImpl(delegateType);
		}

		public void AddDelegateMixin(Delegate @delegate)
		{
			if ((object)@delegate == null)
			{
				throw new ArgumentNullException("delegate");
			}
			AddMixinImpl(@delegate);
		}

		public void AddMixinInstance(object instance)
		{
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			if (instance is Type)
			{
				throw new ArgumentException("You may not mix in types using this method.", "instance");
			}
			AddMixinImpl(instance);
		}

		private void AddMixinImpl(object instanceOrType)
		{
			if (mixins == null)
			{
				mixins = new List<object>();
			}
			mixins.Add(instanceOrType);
			mixinData = null;
		}

		public object[] MixinsAsArray()
		{
			if (mixins == null)
			{
				return new object[0];
			}
			return mixins.ToArray();
		}

		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			if (!(obj is ProxyGenerationOptions proxyGenerationOptions))
			{
				return false;
			}
			Initialize();
			proxyGenerationOptions.Initialize();
			if (!object.Equals(Hook, proxyGenerationOptions.Hook))
			{
				return false;
			}
			if (!object.Equals(Selector == null, proxyGenerationOptions.Selector == null))
			{
				return false;
			}
			if (!object.Equals(MixinData, proxyGenerationOptions.MixinData))
			{
				return false;
			}
			if (!object.Equals(BaseTypeForInterfaceProxy, proxyGenerationOptions.BaseTypeForInterfaceProxy))
			{
				return false;
			}
			if (!Castle.Core.Internal.CollectionExtensions.AreEquivalent(AdditionalAttributes, proxyGenerationOptions.AdditionalAttributes))
			{
				return false;
			}
			return true;
		}

		public override int GetHashCode()
		{
			Initialize();
			int num = ((Hook != null) ? Hook.GetType().GetHashCode() : 0);
			num = 29 * num + ((Selector != null) ? 1 : 0);
			num = 29 * num + MixinData.GetHashCode();
			num = 29 * num + ((BaseTypeForInterfaceProxy != null) ? BaseTypeForInterfaceProxy.GetHashCode() : 0);
			return 29 * num + Castle.Core.Internal.CollectionExtensions.GetContentsHashCode(AdditionalAttributes);
		}
	}
}

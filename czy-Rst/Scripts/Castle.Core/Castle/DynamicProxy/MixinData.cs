using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Internal;

namespace Castle.DynamicProxy
{
	public class MixinData
	{
		private readonly Dictionary<Type, int> mixinPositions = new Dictionary<Type, int>();

		private readonly List<object> mixinsImpl = new List<object>();

		private int delegateMixinCount;

		public IEnumerable<Type> MixinInterfaces => mixinPositions.Keys;

		public IEnumerable<object> Mixins => mixinsImpl;

		public MixinData(IEnumerable<object> mixinInstances)
		{
			if (mixinInstances == null)
			{
				return;
			}
			List<Type> list = new List<Type>();
			Dictionary<Type, object> dictionary = new Dictionary<Type, object>();
			delegateMixinCount = 0;
			foreach (object mixinInstance in mixinInstances)
			{
				Type[] array;
				object value;
				if (mixinInstance is Delegate)
				{
					delegateMixinCount++;
					array = new Type[1] { mixinInstance.GetType() };
					value = mixinInstance;
				}
				else if (mixinInstance is Type type && type.IsDelegateType())
				{
					delegateMixinCount++;
					array = new Type[1] { type };
					value = null;
				}
				else
				{
					array = mixinInstance.GetType().GetInterfaces();
					value = mixinInstance;
				}
				Type[] array2 = array;
				foreach (Type type2 in array2)
				{
					list.Add(type2);
					if (dictionary.TryGetValue(type2, out var value2))
					{
						string message = ((value2 == null) ? $"The list of mixins already contains a mixin for delegate type '{type2.FullName}'." : $"The list of mixins contains two mixins implementing the same interface '{type2.FullName}': {value2.GetType().Name} and {mixinInstance.GetType().Name}. An interface cannot be added by more than one mixin.");
						throw new ArgumentException(message, "mixinInstances");
					}
					dictionary[type2] = value;
				}
			}
			if (delegateMixinCount > 1)
			{
				HashSet<MethodInfo> hashSet = new HashSet<MethodInfo>();
				foreach (Type key2 in dictionary.Keys)
				{
					if (key2.IsDelegateType())
					{
						MethodInfo method = key2.GetMethod("Invoke");
						if (hashSet.Contains(method, MethodSignatureComparer.Instance))
						{
							throw new ArgumentException("The list of mixins contains at least two delegate mixins for the same delegate signature.", "mixinInstances");
						}
						hashSet.Add(method);
					}
				}
			}
			list.Sort((Type x, Type y) => string.CompareOrdinal(x.FullName, y.FullName));
			for (int num = 0; num < list.Count; num++)
			{
				Type key = list[num];
				object item = dictionary[key];
				mixinPositions[key] = num;
				mixinsImpl.Add(item);
			}
		}

		public bool ContainsMixin(Type mixinInterfaceType)
		{
			return mixinPositions.ContainsKey(mixinInterfaceType);
		}

		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			if (!(obj is MixinData mixinData))
			{
				return false;
			}
			if (mixinsImpl.Count != mixinData.mixinsImpl.Count)
			{
				return false;
			}
			if (delegateMixinCount != mixinData.delegateMixinCount)
			{
				return false;
			}
			for (int i = 0; i < mixinsImpl.Count; i++)
			{
				if (mixinsImpl[i]?.GetType() != mixinData.mixinsImpl[i]?.GetType())
				{
					return false;
				}
			}
			if (delegateMixinCount > 0)
			{
				IEnumerable<Type> first = mixinPositions.Select((KeyValuePair<Type, int> m) => m.Key).Where(TypeUtil.IsDelegateType);
				IEnumerable<Type> second = mixinData.mixinPositions.Select((KeyValuePair<Type, int> m) => m.Key).Where(TypeUtil.IsDelegateType);
				return first.SequenceEqual(second);
			}
			return true;
		}

		public override int GetHashCode()
		{
			int num = 0;
			foreach (object item in mixinsImpl)
			{
				num = (29 * num + item?.GetType().GetHashCode()) ?? 307;
			}
			return num;
		}

		public object GetMixinInstance(Type mixinInterfaceType)
		{
			return mixinsImpl[mixinPositions[mixinInterfaceType]];
		}

		public int GetMixinPosition(Type mixinInterfaceType)
		{
			return mixinPositions[mixinInterfaceType];
		}
	}
}

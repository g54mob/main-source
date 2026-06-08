using System;
using System.Collections.Generic;
using System.Reflection;
using MLAPI.Logging;

namespace MLAPI.Messaging
{
	internal class RpcTypeDefinition
	{
		private static readonly Dictionary<Type, RpcTypeDefinition> typeLookup = new Dictionary<Type, RpcTypeDefinition>();

		private static readonly Dictionary<ulong, string> hashResults = new Dictionary<ulong, string>();

		public readonly Dictionary<ulong, ReflectionMethod> serverMethods = new Dictionary<ulong, ReflectionMethod>();

		public readonly Dictionary<ulong, ReflectionMethod> clientMethods = new Dictionary<ulong, ReflectionMethod>();

		private readonly ReflectionMethod[] delegateMethods;

		public static RpcTypeDefinition Get(Type type)
		{
			if (typeLookup.ContainsKey(type))
			{
				return typeLookup[type];
			}
			RpcTypeDefinition rpcTypeDefinition = new RpcTypeDefinition(type);
			typeLookup.Add(type, rpcTypeDefinition);
			return rpcTypeDefinition;
		}

		private static ulong HashMethodNameAndValidate(string name)
		{
			ulong num = NetworkedBehaviour.HashMethodName(name);
			if (hashResults.ContainsKey(num))
			{
				string text = hashResults[num];
				if (text != name && NetworkLog.CurrentLogLevel <= LogLevel.Error)
				{
					NetworkLog.LogError("Hash collision detected for RPC method. The method \"" + name + "\" collides with the method \"" + text + "\". This can be solved by increasing the amount of bytes to use for hashing in the NetworkConfig or changing the name of one of the conflicting methods.");
				}
			}
			else
			{
				hashResults.Add(num, name);
			}
			return num;
		}

		private static List<MethodInfo> GetAllMethods(Type type, Type limitType)
		{
			List<MethodInfo> list = new List<MethodInfo>();
			while ((object)type != null && (object)type != limitType)
			{
				list.AddRange(type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
				type = type.BaseType;
			}
			return list;
		}

		private RpcTypeDefinition(Type type)
		{
			List<ReflectionMethod> list = new List<ReflectionMethod>();
			List<MethodInfo> allMethods = GetAllMethods(type, typeof(NetworkedBehaviour));
			for (int i = 0; i < allMethods.Count; i++)
			{
				MethodInfo methodInfo = allMethods[i];
				ParameterInfo[] parameters = methodInfo.GetParameters();
				ReflectionMethod reflectionMethod = ReflectionMethod.Create(methodInfo, parameters, list.Count);
				if (reflectionMethod == null)
				{
					continue;
				}
				Dictionary<ulong, ReflectionMethod> dictionary = (reflectionMethod.serverTarget ? serverMethods : clientMethods);
				ulong key = HashMethodNameAndValidate(methodInfo.Name);
				if (!dictionary.ContainsKey(key))
				{
					dictionary.Add(key, reflectionMethod);
				}
				if (parameters.Length != 0)
				{
					ulong key2 = HashMethodNameAndValidate(NetworkedBehaviour.GetHashableMethodSignature(methodInfo));
					if (!dictionary.ContainsKey(key2))
					{
						dictionary.Add(key2, reflectionMethod);
					}
				}
				if (reflectionMethod.useDelegate)
				{
					list.Add(reflectionMethod);
				}
			}
			delegateMethods = list.ToArray();
		}

		internal RpcDelegate[] CreateTargetedDelegates(NetworkedBehaviour target)
		{
			if (delegateMethods.Length == 0)
			{
				return null;
			}
			RpcDelegate[] array = new RpcDelegate[delegateMethods.Length];
			for (int i = 0; i < delegateMethods.Length; i++)
			{
				array[i] = (RpcDelegate)Delegate.CreateDelegate(typeof(RpcDelegate), target, delegateMethods[i].method.Name);
			}
			return array;
		}
	}
}

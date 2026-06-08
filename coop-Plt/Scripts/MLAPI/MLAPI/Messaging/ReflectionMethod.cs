using System;
using System.IO;
using System.Reflection;
using MLAPI.Logging;
using MLAPI.Serialization;
using MLAPI.Serialization.Pooled;

namespace MLAPI.Messaging
{
	internal class ReflectionMethod
	{
		internal readonly MethodInfo method;

		internal readonly bool useDelegate;

		internal readonly bool serverTarget;

		private readonly bool requireOwnership;

		private readonly int index;

		private readonly Type[] parameterTypes;

		private readonly object[] parameterRefs;

		internal static ReflectionMethod Create(MethodInfo method, ParameterInfo[] parameters, int index)
		{
			RPCAttribute[] array = (RPCAttribute[])method.GetCustomAttributes(typeof(RPCAttribute), inherit: true);
			if (array.Length == 0)
			{
				return null;
			}
			if (array.Length > 1 && NetworkLog.CurrentLogLevel <= LogLevel.Normal)
			{
				NetworkLog.LogWarning("Having more than one ServerRPC or ClientRPC attribute per method is not supported.");
			}
			if ((object)method.ReturnType != typeof(void) && !SerializationManager.IsTypeSupported(method.ReturnType) && NetworkLog.CurrentLogLevel <= LogLevel.Error)
			{
				NetworkLog.LogWarning("Invalid return type of RPC. Has to be either void or RpcResponse<T> with a serializable type");
			}
			return new ReflectionMethod(method, parameters, array[0], index);
		}

		internal ReflectionMethod(MethodInfo method, ParameterInfo[] parameters, RPCAttribute attribute, int index)
		{
			this.method = method;
			this.index = index;
			if (attribute is ServerRPCAttribute serverRPCAttribute)
			{
				requireOwnership = serverRPCAttribute.RequireOwnership;
				serverTarget = true;
			}
			else
			{
				requireOwnership = false;
				serverTarget = false;
			}
			if (parameters.Length == 2 && (object)method.ReturnType == typeof(void) && (object)parameters[0].ParameterType == typeof(ulong) && (object)parameters[1].ParameterType == typeof(Stream))
			{
				useDelegate = true;
				return;
			}
			useDelegate = false;
			parameterTypes = new Type[parameters.Length];
			parameterRefs = new object[parameters.Length];
			for (int i = 0; i < parameters.Length; i++)
			{
				parameterTypes[i] = parameters[i].ParameterType;
			}
		}

		internal object Invoke(NetworkedBehaviour target, ulong senderClientId, Stream stream)
		{
			if (requireOwnership && senderClientId != target.OwnerClientId)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("Only owner can invoke ServerRPC that is marked to require ownership");
				}
				return null;
			}
			target.executingRpcSender = senderClientId;
			if (stream.Position == 0L)
			{
				if (useDelegate)
				{
					return InvokeDelegate(target, senderClientId, stream);
				}
				return InvokeReflected(target, stream);
			}
			using PooledBitStream pooledBitStream = PooledBitStream.Get();
			pooledBitStream.CopyUnreadFrom(stream);
			pooledBitStream.Position = 0L;
			if (useDelegate)
			{
				return InvokeDelegate(target, senderClientId, pooledBitStream);
			}
			return InvokeReflected(target, pooledBitStream);
		}

		private object InvokeReflected(NetworkedBehaviour instance, Stream stream)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			for (int i = 0; i < parameterTypes.Length; i++)
			{
				parameterRefs[i] = pooledBitReader.ReadObjectPacked(parameterTypes[i]);
			}
			return method.Invoke(instance, parameterRefs);
		}

		private object InvokeDelegate(NetworkedBehaviour target, ulong senderClientId, Stream stream)
		{
			target.rpcDelegates[index](senderClientId, stream);
			return null;
		}
	}
}

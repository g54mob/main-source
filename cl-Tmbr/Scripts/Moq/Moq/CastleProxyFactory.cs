using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime;
using System.Text;
using Castle.DynamicProxy;
using Moq.Internals;
using Moq.Properties;

namespace Moq
{
	internal sealed class CastleProxyFactory : ProxyFactory
	{
		private sealed class Interceptor : Castle.DynamicProxy.IInterceptor
		{
			private static readonly MethodInfo proxyInterceptorGetter = typeof(IProxy).GetProperty("Interceptor").GetMethod;

			private IInterceptor interceptor;

			internal Interceptor(IInterceptor interceptor)
			{
				this.interceptor = interceptor;
			}

			public void Intercept(Castle.DynamicProxy.IInvocation underlying)
			{
				if (underlying.Method == proxyInterceptorGetter)
				{
					underlying.ReturnValue = interceptor;
					return;
				}
				Invocation invocation = new Invocation(underlying);
				try
				{
					interceptor.Intercept(invocation);
					underlying.ReturnValue = invocation.ReturnValue;
				}
				catch (Exception exception)
				{
					invocation.Exception = exception;
					throw;
				}
				finally
				{
					invocation.DetachFromUnderlying();
				}
			}
		}

		private sealed class Invocation : Moq.Invocation
		{
			private Castle.DynamicProxy.IInvocation underlying;

			internal Invocation(Castle.DynamicProxy.IInvocation underlying)
				: base(underlying.Proxy.GetType(), underlying.Method, underlying.Arguments)
			{
				this.underlying = underlying;
			}

			protected internal override object CallBase()
			{
				MethodInfo methodInfo = base.Method;
				if (methodInfo.DeclaringType.IsInterface && !methodInfo.IsAbstract)
				{
					MethodInfo methodInfo2 = FindMostSpecificOverride(methodInfo, underlying.Proxy.GetType());
					return DynamicInvokeNonVirtually(methodInfo2, underlying.Proxy, base.Arguments);
				}
				underlying.Proceed();
				return underlying.ReturnValue;
			}

			public void DetachFromUnderlying()
			{
				underlying = null;
			}
		}

		private sealed class IncludeObjectMethodsHook : AllMethodsHook
		{
			public override bool ShouldInterceptMethod(Type type, MethodInfo method)
			{
				if (!base.ShouldInterceptMethod(type, method))
				{
					return IsRelevantObjectMethod(method);
				}
				return true;
			}

			private static bool IsRelevantObjectMethod(MethodInfo method)
			{
				if (method.DeclaringType == typeof(object))
				{
					if (!(method.Name == "ToString") && !(method.Name == "Equals"))
					{
						return method.Name == "GetHashCode";
					}
					return true;
				}
				return false;
			}
		}

		private ProxyGenerationOptions generationOptions;

		private ProxyGenerator generator;

		private static ConcurrentDictionary<Pair<MethodInfo, Type>, MethodInfo> mostSpecificOverrides;

		private static ConcurrentDictionary<MethodInfo, Func<object, object[], object>> nonVirtualInvocationThunks;

		public CastleProxyFactory()
		{
			generationOptions = new ProxyGenerationOptions
			{
				Hook = new IncludeObjectMethodsHook(),
				BaseTypeForInterfaceProxy = typeof(InterfaceProxy)
			};
			generator = new ProxyGenerator();
		}

		public override object CreateProxy(Type mockType, IInterceptor interceptor, Type[] interfaces, object[] arguments)
		{
			Type[] array = new Type[1 + interfaces.Length];
			array[0] = typeof(IProxy);
			Array.Copy(interfaces, 0, array, 1, interfaces.Length);
			if (mockType.IsInterface)
			{
				return generator.CreateInterfaceProxyWithoutTarget(mockType, array, generationOptions, new Interceptor(interceptor));
			}
			if (mockType.IsDelegateType())
			{
				ProxyGenerationOptions proxyGenerationOptions = new ProxyGenerationOptions();
				proxyGenerationOptions.AddDelegateTypeMixin(mockType);
				object obj = generator.CreateClassProxy(typeof(object), array, proxyGenerationOptions, new Interceptor(interceptor));
				return Delegate.CreateDelegate(mockType, obj, obj.GetType().GetMethod("Invoke"));
			}
			try
			{
				return generator.CreateClassProxy(mockType, array, generationOptions, arguments, new Interceptor(interceptor));
			}
			catch (TypeLoadException innerException)
			{
				throw new ArgumentException(string.Format(Resources.TypeNotMockable, mockType), innerException);
			}
			catch (MissingMethodException innerException2)
			{
				throw new ArgumentException(Resources.ConstructorNotFound, innerException2);
			}
		}

		public override bool IsMethodVisible(MethodInfo method, out string messageIfNotVisible)
		{
			return ProxyUtil.IsAccessible(method, out messageIfNotVisible);
		}

		public override bool IsTypeVisible(Type type)
		{
			return ProxyUtil.IsAccessible(type);
		}

		static CastleProxyFactory()
		{
			mostSpecificOverrides = new ConcurrentDictionary<Pair<MethodInfo, Type>, MethodInfo>();
			nonVirtualInvocationThunks = new ConcurrentDictionary<MethodInfo, Func<object, object[], object>>();
		}

		public static MethodInfo FindMostSpecificOverride(MethodInfo declaration, Type proxyType)
		{
			return mostSpecificOverrides.GetOrAdd(new Pair<MethodInfo, Type>(declaration, proxyType), delegate(Pair<MethodInfo, Type> key)
			{
				Pair<MethodInfo, Type> pair = key;
				pair.Deconstruct(out var item, out var item2);
				MethodInfo methodInfo = item;
				Type type = item2;
				int genericParameterCount = (methodInfo.IsGenericMethod ? methodInfo.GetGenericArguments().Length : 0);
				Type returnType = methodInfo.ReturnType;
				Type[] types = methodInfo.GetParameterTypes().ToArray();
				Type declaringType = methodInfo.DeclaringType;
				Type baseType = type.BaseType;
				if (baseType != null && declaringType.IsAssignableFrom(baseType))
				{
					InterfaceMapping interfaceMap = baseType.GetInterfaceMap(declaringType);
					int num = Array.IndexOf(interfaceMap.InterfaceMethods, methodInfo);
					return interfaceMap.TargetMethods[num];
				}
				Type[] interfaces = type.GetInterfaces();
				HashSet<MethodInfo> hashSet = new HashSet<MethodInfo>();
				foreach (Type implementedInterface in interfaces.Where((Type i) => declaringType.IsAssignableFrom(i)))
				{
					MethodInfo method = implementedInterface.GetMethod(methodInfo.Name, genericParameterCount, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, types, null);
					if (method?.GetBaseDefinition() != methodInfo)
					{
						StringBuilder stringBuilder = new StringBuilder();
						stringBuilder.Append(declaringType.FullName);
						stringBuilder.Replace('+', '.');
						stringBuilder.Append('.');
						stringBuilder.Append(methodInfo.Name);
						method = implementedInterface.GetMethod(stringBuilder.ToString(), genericParameterCount, BindingFlags.Instance | BindingFlags.NonPublic, null, types, null);
					}
					if (!(method == null) && !hashSet.Any((MethodInfo cm) => implementedInterface.IsAssignableFrom(cm.DeclaringType)))
					{
						hashSet.ExceptWith(hashSet.Where((MethodInfo cm) => cm.DeclaringType.IsAssignableFrom(implementedInterface)).ToArray());
						hashSet.Add(method);
					}
				}
				int num2 = hashSet.Count();
				if (num2 > 1)
				{
					throw new AmbiguousImplementationException();
				}
				return (num2 == 1) ? hashSet.First() : methodInfo;
			});
		}

		public static object DynamicInvokeNonVirtually(MethodInfo method, object instance, object[] arguments)
		{
			Func<object, object[], object> orAdd = nonVirtualInvocationThunks.GetOrAdd(method, delegate(MethodInfo methodInfo)
			{
				ParameterTypes parameterTypes = methodInfo.GetParameterTypes();
				int count = parameterTypes.Count;
				DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(object), new Type[2]
				{
					typeof(object),
					typeof(object[])
				})
				{
					InitLocals = true
				};
				ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
				LocalBuilder[] array = new LocalBuilder[count];
				LocalBuilder local = iLGenerator.DeclareLocal(typeof(object));
				Type[] array2 = parameterTypes.ToArray();
				for (int i = 0; i < count; i++)
				{
					if (array2[i].IsByRef)
					{
						array2[i] = array2[i].GetElementType();
					}
				}
				for (int j = 0; j < count; j++)
				{
					array[j] = iLGenerator.DeclareLocal(array2[j]);
					iLGenerator.Emit(OpCodes.Ldarg_1);
					iLGenerator.Emit(OpCodes.Ldc_I4, j);
					iLGenerator.Emit(OpCodes.Ldelem_Ref);
					iLGenerator.Emit(OpCodes.Unbox_Any, array2[j]);
					iLGenerator.Emit(OpCodes.Stloc, array[j]);
				}
				Label label = iLGenerator.DefineLabel();
				iLGenerator.BeginExceptionBlock();
				iLGenerator.Emit(OpCodes.Ldarg_0);
				iLGenerator.Emit(OpCodes.Castclass, methodInfo.DeclaringType);
				for (int k = 0; k < count; k++)
				{
					iLGenerator.Emit(parameterTypes[k].IsByRef ? OpCodes.Ldloca : OpCodes.Ldloc, array[k]);
				}
				iLGenerator.Emit(OpCodes.Call, methodInfo);
				if (methodInfo.ReturnType != typeof(void))
				{
					iLGenerator.Emit(OpCodes.Box, methodInfo.ReturnType);
					iLGenerator.Emit(OpCodes.Castclass, typeof(object));
					iLGenerator.Emit(OpCodes.Stloc, local);
				}
				iLGenerator.Emit(OpCodes.Leave, label);
				iLGenerator.BeginFinallyBlock();
				for (int l = 0; l < count; l++)
				{
					iLGenerator.Emit(OpCodes.Ldarg_1);
					iLGenerator.Emit(OpCodes.Ldc_I4, l);
					iLGenerator.Emit(OpCodes.Ldloc, array[l]);
					iLGenerator.Emit(OpCodes.Box, array[l].LocalType);
					iLGenerator.Emit(OpCodes.Stelem_Ref);
				}
				iLGenerator.Emit(OpCodes.Endfinally);
				iLGenerator.EndExceptionBlock();
				iLGenerator.MarkLabel(label);
				iLGenerator.Emit(OpCodes.Ldloc, local);
				iLGenerator.Emit(OpCodes.Ret);
				return (Func<object, object[], object>)dynamicMethod.CreateDelegate(typeof(Func<object, object[], object>));
			});
			return orAdd(instance, arguments);
		}
	}
}

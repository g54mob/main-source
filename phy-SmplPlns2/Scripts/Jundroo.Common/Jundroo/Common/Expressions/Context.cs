using System;
using System.Collections.Generic;
using System.Reflection;
using Jundroo.Common.Expressions.Exceptions;
using Jundroo.Common.Expressions.SpecialFunctions;
using Jundroo.Common.Expressions.Tokens;
using UnityEngine;

namespace Jundroo.Common.Expressions
{
	public class Context
	{
		public delegate Token VariableResolveDelegate(string text);

		private const float Deg2Rad = MathF.PI / 180f;

		private const float Rad2Deg = 57.29578f;

		private static Dictionary<(Type, MemberAccessPermissionFlags), TypeMetadata> _cachedTypeMetadata = new Dictionary<(Type, MemberAccessPermissionFlags), TypeMetadata>();

		private static Context _defaultContext;

		private List<VariableResolveDelegate> _variableResolveDelegates = new List<VariableResolveDelegate>();

		public Dictionary<string, object> Constants { get; private set; }

		public bool EnableMemory { get; set; }

		public Dictionary<string, (MethodInfo Method, object Instance)> Functions { get; private set; }

		public Func<float> GetDeltaTime { get; set; } = () => 1f;

		public Dictionary<Type, TypeMetadata> InstanceTypeMetadata { get; } = new Dictionary<Type, TypeMetadata>();

		public Dictionary<string, (MethodInfo GetMethod, object Instance)> Properties { get; private set; }

		public Dictionary<string, Func<Func<float>, (MethodInfo Method, object Instance)>> SpecialFunctions { get; private set; }

		public event VariableResolveDelegate VariableResolve
		{
			add
			{
				_variableResolveDelegates.Add(value);
			}
			remove
			{
				_variableResolveDelegates.Remove(value);
			}
		}

		public Context(bool addDefaults = true, params object[] contexts)
		{
			Properties = new Dictionary<string, (MethodInfo, object)>();
			Functions = new Dictionary<string, (MethodInfo, object)>();
			Constants = new Dictionary<string, object>();
			SpecialFunctions = new Dictionary<string, Func<Func<float>, (MethodInfo, object)>>();
			if (addDefaults)
			{
				AddDefaults();
			}
			foreach (object obj in contexts)
			{
				if (obj == null)
				{
					continue;
				}
				PropertyInfo[] properties = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (PropertyInfo propertyInfo in properties)
				{
					ExposedAttribute exposedAttribute = (ExposedAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(ExposedAttribute));
					if (exposedAttribute != null)
					{
						string name = exposedAttribute.Name ?? propertyInfo.Name;
						AddVariable(name, propertyInfo.GetGetMethod(nonPublic: true), obj);
					}
				}
				MethodInfo[] methods = obj.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (MethodInfo methodInfo in methods)
				{
					ExposedAttribute exposedAttribute2 = (ExposedAttribute)Attribute.GetCustomAttribute(methodInfo, typeof(ExposedAttribute));
					if (exposedAttribute2 != null)
					{
						string name2 = exposedAttribute2.Name ?? methodInfo.Name;
						AddFunction(name2, methodInfo, obj);
					}
				}
			}
		}

		public Context(Dictionary<string, (MethodInfo Method, object Instance)> properties, Dictionary<string, (MethodInfo Method, object Instance)> functions, Dictionary<string, object> constants, bool addDefaults = true)
		{
			Properties = properties;
			Functions = functions;
			Constants = constants;
			SpecialFunctions = new Dictionary<string, Func<Func<float>, (MethodInfo, object)>>();
			if (addDefaults)
			{
				AddDefaults();
			}
		}

		public static string FormatNumber(float v, string format)
		{
			if (string.IsNullOrWhiteSpace(format))
			{
				return v.ToString();
			}
			switch (format[0])
			{
			case 'D':
			case 'X':
			case 'd':
			case 'x':
				return ((int)v).ToString(format);
			default:
				return v.ToString(format);
			}
		}

		public void AddConstant(string name, object value)
		{
			if (Constants.ContainsKey(name) || Properties.ContainsKey(name))
			{
				throw new ExpressionCompileException("Context build error: property " + name + " already defined.");
			}
			Constants[name] = value;
		}

		public void AddDefaults()
		{
			if (_defaultContext == null)
			{
				_defaultContext = new Context(false);
				_defaultContext.GetDefaults();
			}
			foreach (KeyValuePair<string, object> constant in _defaultContext.Constants)
			{
				AddConstant(constant.Key, constant.Value);
			}
			EnableMemory = true;
			foreach (KeyValuePair<string, Func<Func<float>, (MethodInfo, object)>> specialFunction in _defaultContext.SpecialFunctions)
			{
				AddSpecialFunction(specialFunction.Key, specialFunction.Value);
			}
			foreach (KeyValuePair<string, (MethodInfo, object)> function in _defaultContext.Functions)
			{
				AddFunction(function.Key, function.Value.Item1, function.Value.Item2);
			}
		}

		public void AddFunction(string name, MethodInfo method, object instance)
		{
			if (Functions.ContainsKey(name) || SpecialFunctions.ContainsKey(name))
			{
				throw new ExpressionCompileException("Context build error: function " + name + " already defined.");
			}
			Functions[name] = (method, instance);
		}

		public void AddSpecialFunction(string name, Func<Func<float>, (MethodInfo Method, object Instance)> factory)
		{
			if (Functions.ContainsKey(name) || SpecialFunctions.ContainsKey(name))
			{
				throw new ExpressionCompileException("Context build error: function " + name + " already defined.");
			}
			SpecialFunctions[name] = factory;
		}

		public void AddVariable(string name, MethodInfo getMethod, object instance)
		{
			if (Constants.ContainsKey(name) || Properties.ContainsKey(name))
			{
				throw new ExpressionCompileException("Context build error: property " + name + " already defined.");
			}
			Properties[name] = (getMethod, instance);
		}

		public void AllowMemberAccessForType(Type type, MemberAccessPermissionFlags permissions)
		{
			if (!_cachedTypeMetadata.TryGetValue((type, permissions), out var value))
			{
				value = new TypeMetadata(type, permissions);
				_cachedTypeMetadata.Add((type, permissions), value);
			}
			InstanceTypeMetadata.Add(type, value);
		}

		public void AllowMemberAccessForType<T>(MemberAccessPermissionFlags permissions)
		{
			AllowMemberAccessForType(typeof(T), permissions);
		}

		public object GetConstant(string name)
		{
			Constants.TryGetValue(name, out var value);
			return value;
		}

		public MethodInfo GetMethod(string name, Type instanceType)
		{
			while (instanceType != null)
			{
				if (InstanceTypeMetadata.TryGetValue(instanceType, out var value) && value.Methods.TryGetValue(name, out var value2))
				{
					return value2;
				}
				instanceType = instanceType.BaseType;
			}
			return null;
		}

		public Dictionary<string, MethodInfo> GetMethods(Type instanceType)
		{
			Dictionary<string, MethodInfo> dictionary = new Dictionary<string, MethodInfo>();
			while (instanceType != null)
			{
				if (InstanceTypeMetadata.TryGetValue(instanceType, out var value))
				{
					foreach (KeyValuePair<string, MethodInfo> method in value.Methods)
					{
						if (!dictionary.ContainsKey(method.Key))
						{
							dictionary.Add(method.Key, method.Value);
						}
					}
				}
				instanceType = instanceType.BaseType;
			}
			return dictionary;
		}

		public Dictionary<string, MethodInfo> GetProperties(Type instanceType)
		{
			Dictionary<string, MethodInfo> dictionary = new Dictionary<string, MethodInfo>();
			while (instanceType != null)
			{
				if (InstanceTypeMetadata.TryGetValue(instanceType, out var value))
				{
					foreach (KeyValuePair<string, MethodInfo> property in value.Properties)
					{
						if (!dictionary.ContainsKey(property.Key))
						{
							dictionary.Add(property.Key, property.Value);
						}
					}
				}
				instanceType = instanceType.BaseType;
			}
			return dictionary;
		}

		public (MethodInfo Method, object Instance)? GetProperty(string name)
		{
			if (Properties.TryGetValue(name, out (MethodInfo, object) value))
			{
				return value;
			}
			return null;
		}

		public MethodInfo GetProperty(string name, Type instanceType)
		{
			while (instanceType != null)
			{
				if (InstanceTypeMetadata.TryGetValue(instanceType, out var value) && value.Properties.TryGetValue(name, out var value2))
				{
					return value2;
				}
				instanceType = instanceType.BaseType;
			}
			return null;
		}

		public Token ResolveVariable(string text)
		{
			foreach (VariableResolveDelegate variableResolveDelegate in _variableResolveDelegates)
			{
				Token token = variableResolveDelegate?.Invoke(text);
				if (token != null)
				{
					return token;
				}
			}
			return null;
		}

		private static float AcosDegrees(float r)
		{
			return Mathf.Acos(r) * 57.29578f;
		}

		private static float AsinDegrees(float r)
		{
			return Mathf.Asin(r) * 57.29578f;
		}

		private static float Atan2Degrees(float y, float x)
		{
			return Mathf.Atan2(y, x) * 57.29578f;
		}

		private static float AtanDegrees(float r)
		{
			return Mathf.Atan(r) * 57.29578f;
		}

		private static float CosDegrees(float angle)
		{
			return Mathf.Cos(angle * (MathF.PI / 180f));
		}

		private static float SinDegrees(float angle)
		{
			return Mathf.Sin(angle * (MathF.PI / 180f));
		}

		private static float TanDegrees(float angle)
		{
			return Mathf.Tan(angle * (MathF.PI / 180f));
		}

		private void GetDefaults()
		{
			AddConstant("true", true);
			AddConstant("false", false);
			EnableMemory = true;
			AddSpecialFunction("sum", IntegrateFunction.Create);
			AddSpecialFunction("rate", DifferentiateFunction.Create);
			AddSpecialFunction("PID", PIDFunction.Create);
			AddSpecialFunction("smooth", SmoothFunction.Create);
			BindingFlags bindingAttr = BindingFlags.Static | BindingFlags.Public;
			Type typeFromHandle = typeof(Mathf);
			AddConstant("pi", MathF.PI);
			AddConstant("e", Mathf.Log(1f));
			AddFunction("ceil", typeFromHandle.GetMethod("Ceil", bindingAttr), null);
			AddFunction("clamp01", typeFromHandle.GetMethod("Clamp01", bindingAttr), null);
			AddFunction("deltaangle", typeFromHandle.GetMethod("DeltaAngle", bindingAttr), null);
			AddFunction("exp", typeFromHandle.GetMethod("Exp", bindingAttr), null);
			AddFunction("floor", typeFromHandle.GetMethod("Floor", bindingAttr), null);
			AddFunction("inverselerp", typeFromHandle.GetMethod("InverseLerp", bindingAttr), null);
			AddFunction("lerp", typeFromHandle.GetMethod("Lerp", bindingAttr), null);
			AddFunction("lerpangle", typeFromHandle.GetMethod("LerpAngle", bindingAttr), null);
			AddFunction("lerpunclamped", typeFromHandle.GetMethod("LerpUnclamped", bindingAttr), null);
			AddFunction("log10", typeFromHandle.GetMethod("Log10", bindingAttr), null);
			AddFunction("pingpong", typeFromHandle.GetMethod("PingPong", bindingAttr), null);
			AddFunction("pow", typeFromHandle.GetMethod("Pow", bindingAttr), null);
			AddFunction("repeat", typeFromHandle.GetMethod("Repeat", bindingAttr), null);
			AddFunction("round", typeFromHandle.GetMethod("Round", bindingAttr), null);
			AddFunction("sign", typeFromHandle.GetMethod("Sign", bindingAttr), null);
			AddFunction("smoothstep", typeFromHandle.GetMethod("SmoothStep", bindingAttr), null);
			AddFunction("sqrt", typeFromHandle.GetMethod("Sqrt", bindingAttr), null);
			AddFunction("abs", typeFromHandle.GetMethod("Abs", bindingAttr, null, new Type[1] { typeof(float) }, null), null);
			AddFunction("clamp", typeFromHandle.GetMethod("Clamp", new Type[3]
			{
				typeof(float),
				typeof(float),
				typeof(float)
			}), null);
			AddFunction("log", typeFromHandle.GetMethod("Log", bindingAttr, null, new Type[2]
			{
				typeof(float),
				typeof(float)
			}, null), null);
			AddFunction("max", typeFromHandle.GetMethod("Max", new Type[2]
			{
				typeof(float),
				typeof(float)
			}), null);
			AddFunction("min", typeFromHandle.GetMethod("Min", new Type[2]
			{
				typeof(float),
				typeof(float)
			}), null);
			typeFromHandle = typeof(Context);
			bindingAttr = BindingFlags.Static | BindingFlags.NonPublic;
			AddFunction("sin", typeFromHandle.GetMethod("SinDegrees", bindingAttr), null);
			AddFunction("cos", typeFromHandle.GetMethod("CosDegrees", bindingAttr), null);
			AddFunction("tan", typeFromHandle.GetMethod("TanDegrees", bindingAttr), null);
			AddFunction("asin", typeFromHandle.GetMethod("AsinDegrees", bindingAttr), null);
			AddFunction("acos", typeFromHandle.GetMethod("AcosDegrees", bindingAttr), null);
			AddFunction("atan", typeFromHandle.GetMethod("AtanDegrees", bindingAttr), null);
			AddFunction("atan2", typeFromHandle.GetMethod("Atan2Degrees", bindingAttr), null);
			AddFunction("format", new Func<float, string, string>(FormatNumber).Method, null);
		}
	}
}

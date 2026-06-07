using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.Scripts.Expressions.SpecialFunctions;
using ModApi.Expressions.Exceptions;
using ModApi.Expressions.Tokens;
using UnityEngine;

namespace ModApi.Expressions
{
	public class Context
	{
		public delegate Token VariableResolveDelegate(string text);

		private const double Deg2Rad = System.Math.PI / 180.0;

		private const double Rad2Deg = 180.0 / System.Math.PI;

		private static Context _defaultContext;

		private List<VariableResolveDelegate> _variableResolveDelegates = new List<VariableResolveDelegate>();

		public bool EnableMemory { get; set; }

		public Func<double> GetDeltaTime { get; set; } = () => 1.0;

		internal Dictionary<string, object> Constants { get; private set; }

		internal Dictionary<string, (MethodInfo getMethod, object instance)> Properties { get; private set; }

		internal Dictionary<string, (MethodInfo method, object instance)> Functions { get; private set; }

		internal Dictionary<string, Func<Func<double>, (MethodInfo, object)>> SpecialFunctions { get; private set; }

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

		public Context(bool addDefaults = true)
		{
			Properties = new Dictionary<string, (MethodInfo, object)>();
			Functions = new Dictionary<string, (MethodInfo, object)>();
			Constants = new Dictionary<string, object>();
			SpecialFunctions = new Dictionary<string, Func<Func<double>, (MethodInfo, object)>>();
			if (addDefaults)
			{
				AddDefaults();
			}
		}

		public Context(bool addDefaults = true, params object[] contexts)
			: this(addDefaults)
		{
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

		public Context(bool addDefaults = true, params (Type type, object instance, string namePrefix, bool allowAllPublic)[] contexts)
			: this(addDefaults)
		{
			for (int i = 0; i < contexts.Length; i++)
			{
				var (type, obj, text, flag) = contexts[i];
				if (type == null)
				{
					break;
				}
				PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
				foreach (PropertyInfo propertyInfo in properties)
				{
					MethodInfo getMethod = propertyInfo.GetGetMethod();
					ExposedAttribute customAttribute = propertyInfo.GetCustomAttribute<ExposedAttribute>(inherit: true);
					if (customAttribute != null)
					{
						AddVariable((text ?? string.Empty) + (customAttribute.Name ?? propertyInfo.Name), getMethod, getMethod.IsStatic ? null : obj);
					}
					else if (flag && getMethod.IsPublic)
					{
						AddVariable((text ?? string.Empty) + propertyInfo.Name, getMethod, getMethod.IsStatic ? null : obj);
					}
				}
				MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
				foreach (MethodInfo methodInfo in methods)
				{
					if (!methodInfo.Name.StartsWith("get_") && !methodInfo.Name.StartsWith("set_"))
					{
						ExposedAttribute customAttribute2 = methodInfo.GetCustomAttribute<ExposedAttribute>(inherit: true);
						if (customAttribute2 != null)
						{
							AddFunction((text ?? string.Empty) + (customAttribute2.Name ?? methodInfo.Name), methodInfo, methodInfo.IsStatic ? null : obj);
						}
						else if (flag && methodInfo.IsPublic)
						{
							AddFunction((text ?? string.Empty) + methodInfo.Name, methodInfo, methodInfo.IsStatic ? null : obj);
						}
					}
				}
			}
		}

		internal Context(Dictionary<string, (MethodInfo, object)> properties, Dictionary<string, (MethodInfo, object)> functions, Dictionary<string, object> constants, bool addDefaults = true)
		{
			Properties = properties;
			Functions = functions;
			Constants = constants;
			if (addDefaults)
			{
				AddDefaults();
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

		public void AddFunction<T>(string name, T del) where T : Delegate
		{
			if (Functions.ContainsKey(name) || SpecialFunctions.ContainsKey(name))
			{
				throw new ExpressionCompileException("Context build error: function " + name + " already defined.");
			}
			Functions[name] = (del.Method, del.Target);
		}

		public void AddVariable(string name, MethodInfo getMethod, object instance)
		{
			if (Constants.ContainsKey(name) || Properties.ContainsKey(name))
			{
				throw new ExpressionCompileException("Context build error: property " + name + " already defined.");
			}
			Properties[name] = (getMethod, instance);
		}

		public void AddConstant(string name, object value)
		{
			if (Constants.ContainsKey(name) || Properties.ContainsKey(name))
			{
				throw new ExpressionCompileException("Context build error: property " + name + " already defined.");
			}
			Constants[name] = value;
		}

		public void AddSpecialFunction(string name, Func<Func<double>, (MethodInfo, object)> factory)
		{
			if (Functions.ContainsKey(name) || SpecialFunctions.ContainsKey(name))
			{
				throw new ExpressionCompileException("Context build error: function " + name + " already defined.");
			}
			SpecialFunctions[name] = factory;
		}

		public void AddDefaults()
		{
			if (_defaultContext == null)
			{
				_defaultContext = new Context(addDefaults: false);
				_defaultContext.GetDefaults();
			}
			foreach (KeyValuePair<string, object> constant in _defaultContext.Constants)
			{
				AddConstant(constant.Key, constant.Value);
			}
			EnableMemory = true;
			foreach (KeyValuePair<string, Func<Func<double>, (MethodInfo, object)>> specialFunction in _defaultContext.SpecialFunctions)
			{
				AddSpecialFunction(specialFunction.Key, specialFunction.Value);
			}
			foreach (KeyValuePair<string, (MethodInfo, object)> function in _defaultContext.Functions)
			{
				AddFunction(function.Key, function.Value.Item1, function.Value.Item2);
			}
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

		public object GetConstant(string name)
		{
			Constants.TryGetValue(name, out var value);
			return value;
		}

		public (MethodInfo method, object instance)? GetProperty(string name)
		{
			if (Properties.TryGetValue(name, out (MethodInfo, object) value))
			{
				return value;
			}
			return null;
		}

		private static Vector3d CreateVector(double x, double y, double z)
		{
			return new Vector3d(x, y, z);
		}

		private static double VectorX(Vector3d v)
		{
			return v.x;
		}

		private static double VectorY(Vector3d v)
		{
			return v.y;
		}

		private static double VectorZ(Vector3d v)
		{
			return v.z;
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
			AddConstant("pi", System.Math.PI);
			AddConstant("E", System.Math.E);
			AddConstant("Rad2Deg", 180.0 / System.Math.PI);
			AddConstant("Deg2Rad", System.Math.PI / 180.0);
			Type typeFromHandle = typeof(System.Math);
			AddFunction("abs", typeFromHandle.GetMethod("Abs", new Type[1] { typeof(double) }), null);
			AddFunction("acos", typeFromHandle.GetMethod("Acos"), null);
			AddFunction("asin", typeFromHandle.GetMethod("Asin"), null);
			AddFunction("atan", typeFromHandle.GetMethod("Atan"), null);
			AddFunction("atan2", typeFromHandle.GetMethod("Atan2"), null);
			AddFunction("cos", typeFromHandle.GetMethod("Cos"), null);
			AddFunction("sin", typeFromHandle.GetMethod("Sin"), null);
			AddFunction("tan", typeFromHandle.GetMethod("Tan"), null);
			AddFunction("log", typeFromHandle.GetMethod("Log", new Type[2]
			{
				typeof(double),
				typeof(double)
			}), null);
			AddFunction("ln", typeFromHandle.GetMethod("Log", new Type[1] { typeof(double) }), null);
			AddFunction("log10", typeFromHandle.GetMethod("Log10"), null);
			AddFunction("max", typeFromHandle.GetMethod("Max", new Type[2]
			{
				typeof(double),
				typeof(double)
			}), null);
			AddFunction("min", typeFromHandle.GetMethod("Min", new Type[2]
			{
				typeof(double),
				typeof(double)
			}), null);
			AddFunction("pow", typeFromHandle.GetMethod("Pow", new Type[2]
			{
				typeof(double),
				typeof(double)
			}), null);
			AddFunction("sqrt", typeFromHandle.GetMethod("Sqrt"), null);
			AddFunction("exp", typeFromHandle.GetMethod("Exp"), null);
			AddFunction("ceil", typeFromHandle.GetMethod("Ceiling", new Type[1] { typeof(double) }), null);
			AddFunction("floor", typeFromHandle.GetMethod("Floor", new Type[1] { typeof(double) }), null);
			typeFromHandle = typeof(Mathd);
			AddFunction("clamp", typeFromHandle.GetMethod("Clamp", new Type[3]
			{
				typeof(double),
				typeof(double),
				typeof(double)
			}), null);
			AddFunction("clamp01", typeFromHandle.GetMethod("Clamp01"), null);
			AddFunction("deltaAngle", typeFromHandle.GetMethod("DeltaAngle"), null);
			AddFunction("inverselerp", typeFromHandle.GetMethod("InverseLerp"), null);
			AddFunction("lerp", typeFromHandle.GetMethod("Lerp"), null);
			AddFunction("lerpangle", typeFromHandle.GetMethod("LerpAngle"), null);
			AddFunction("lerpunclamped", typeFromHandle.GetMethod("LerpUnclamped"), null);
			AddFunction("pingpong", typeFromHandle.GetMethod("PingPong"), null);
			AddFunction("repeat", typeFromHandle.GetMethod("Repeat"), null);
			AddFunction("round", typeFromHandle.GetMethod("Round"), null);
			AddFunction("sign", typeFromHandle.GetMethod("Sign"), null);
			AddFunction("smoothstep", typeFromHandle.GetMethod("SmoothStep"), null);
			typeFromHandle = typeof(Context);
			AddFunction("vec", typeFromHandle.GetMethod("CreateVector", BindingFlags.Static | BindingFlags.NonPublic), null);
			AddFunction("x", typeFromHandle.GetMethod("VectorX", BindingFlags.Static | BindingFlags.NonPublic), null);
			AddFunction("y", typeFromHandle.GetMethod("VectorY", BindingFlags.Static | BindingFlags.NonPublic), null);
			AddFunction("z", typeFromHandle.GetMethod("VectorZ", BindingFlags.Static | BindingFlags.NonPublic), null);
			typeFromHandle = typeof(Vector3d);
			AddStatic("angle", "Angle", typeFromHandle);
			AddStatic("clampMagnitude", "ClampMagnitude", typeFromHandle);
			AddStatic("cross", "Cross", typeFromHandle);
			AddStatic("distance", "Distance", typeFromHandle);
			AddStatic("dot", "Dot", typeFromHandle);
			AddStatic("exclude", "Exclude", typeFromHandle);
			AddStatic("isNaN", "IsNaN", typeFromHandle);
			AddStatic("lerp3", "Lerp", typeFromHandle);
			AddStatic("magnitude", "Magnitude", typeFromHandle);
			AddStatic("max3", "Max", typeFromHandle);
			AddStatic("min3", "Min", typeFromHandle);
			AddStatic("moveTowards", "MoveTowards", typeFromHandle);
			AddStatic("normalize", "Normalize", typeFromHandle);
			AddStatic("project", "Project", typeFromHandle);
			AddStatic("projectOnPlane", "ProjectOnPlane", typeFromHandle);
			AddStatic("reflect", "Reflect", typeFromHandle);
			AddFunction("scale", typeFromHandle.GetMethod("Scale", BindingFlags.Static | BindingFlags.Public, null, new Type[2]
			{
				typeof(Vector3d),
				typeof(Vector3d)
			}, null), null);
			AddStatic("signedAngle", "SignedAngle", typeFromHandle);
			AddStatic("slerp", "Slerp", typeFromHandle);
			AddStatic("sqrMagnitude", "SqrMagnitude", typeFromHandle);
		}

		private void AddStatic(string name, string method, Type t)
		{
			AddFunction(name, t.GetMethod(method, BindingFlags.Static | BindingFlags.Public), null);
		}
	}
}

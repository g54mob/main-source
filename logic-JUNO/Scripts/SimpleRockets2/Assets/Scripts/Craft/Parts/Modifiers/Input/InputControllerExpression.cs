using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using Assets.Scripts.Craft.FlightData;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Input;
using ModApi.Expressions;
using ModApi.Expressions.Tokens;
using UnityEngine;
using UnityEngine.Scripting;

namespace Assets.Scripts.Craft.Parts.Modifiers.Input
{
	public class InputControllerExpression : IInputControllerInput
	{
		private interface IInputControllerVariable
		{
			void RefreshInput(IPartScript partScript);
		}

		private abstract class InputControllerVariable<T> : Token<T>, IInputControllerVariable
		{
			public override bool IsFinal => true;

			public abstract void RefreshInput(IPartScript partScript);
		}

		private abstract class CustomPropertyVariable<T, TInst> : InputControllerVariable<T>
		{
			private readonly PropertyInfo _property;

			private TInst _instance;

			protected TInst Instance
			{
				get
				{
					return _instance;
				}
				set
				{
					_instance = value;
				}
			}

			public CustomPropertyVariable(PropertyInfo property)
			{
				if (property != null)
				{
					_property = property;
					return;
				}
				throw new ArgumentNullException("property");
			}

			public override Expression GetExpression(Context context, ParameterExpression dataSlots)
			{
				Expression<Func<object>> expression = () => _instance;
				_ = _property.PropertyType;
				Expression expression2 = Expression.Property(Expression.Convert(expression.Body, _property.DeclaringType), _property);
				if (expression2.Type != typeof(T))
				{
					expression2 = Expression.Convert(expression2, typeof(T));
				}
				ParameterExpression parameterExpression = Expression.Variable(typeof(T));
				expression2 = Expression.Block(new ParameterExpression[1] { parameterExpression }, Expression.Assign(parameterExpression, expression2), Expression.Condition(Expression.Equal(parameterExpression, parameterExpression), parameterExpression, Expression.Default(typeof(T))));
				return Expression.Condition(Expression.Equal(expression.Body, Expression.Constant(null)), Expression.Default(typeof(T)), expression2);
			}

			public override Func<double[], T> GetFunc(Context context)
			{
				Func<double[], double> func = null;
				if (typeof(T) == typeof(double) && _property.PropertyType != typeof(double))
				{
					if (_property.PropertyType == typeof(float))
					{
						Func<TInst, float> f1 = GenericPropertyWrap<TInst, float>(_property);
						func = (double[] dat) => (_instance != null) ? GuardNaN(f1(_instance)) : 0.0;
					}
					else if (_property.PropertyType == typeof(int))
					{
						Func<TInst, int> f2 = GenericPropertyWrap<TInst, int>(_property);
						func = (double[] dat) => (_instance != null) ? ((double)f2(_instance)) : 0.0;
					}
					else if (_property.PropertyType == typeof(short))
					{
						Func<TInst, short> f3 = GenericPropertyWrap<TInst, short>(_property);
						func = (double[] dat) => (_instance != null) ? ((double)f3(_instance)) : 0.0;
					}
				}
				else if (typeof(T) == typeof(double))
				{
					Func<TInst, double> f4 = GenericPropertyWrap<TInst, double>(_property);
					func = (double[] dat) => (_instance != null) ? GuardNaN(f4(_instance)) : 0.0;
				}
				if (func is Func<double[], T> result)
				{
					return result;
				}
				Func<TInst, T> f5 = GenericPropertyWrap<TInst, T>(_property);
				return (double[] dat) => (_instance != null) ? f5(_instance) : default(T);
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				static double GuardNaN(double value)
				{
					if (value != value)
					{
						return 0.0;
					}
					return value;
				}
			}
		}

		private class CraftControlsVariable<T> : CustomPropertyVariable<T, CraftControls>
		{
			public CraftControlsVariable(PropertyInfo prop)
				: base(prop)
			{
			}

			public override void RefreshInput(IPartScript partScript)
			{
				base.Instance = partScript?.CommandPod?.Controls;
			}
		}

		private class ActivationGroupVariable : InputControllerVariable<bool>
		{
			private readonly int _group;

			private CraftControls _instance;

			public ActivationGroupVariable(int group)
			{
				_group = group;
			}

			public override Expression GetExpression(Context context, ParameterExpression dataSlots)
			{
				int ag = _group;
				return ((Expression<Func<bool>>)(() => _instance != null && _instance.GetActivationGroup(ag))).Body;
			}

			public override Func<double[], bool> GetFunc(Context context)
			{
				int ag = _group;
				return (double[] data) => _instance != null && _instance.GetActivationGroup(ag);
			}

			public override void RefreshInput(IPartScript partScript)
			{
				_instance = partScript?.CommandPod?.Controls;
			}
		}

		private class CraftFlightDataVariable<T> : CustomPropertyVariable<T, CraftFlightData>
		{
			public CraftFlightDataVariable(PropertyInfo prop)
				: base(prop)
			{
			}

			public override void RefreshInput(IPartScript partScript)
			{
				base.Instance = (CraftFlightData)(partScript?.CraftScript?.FlightData);
			}
		}

		private class CraftOrbitDataVariable<T> : CustomPropertyVariable<T, CraftOrbitData>
		{
			public CraftOrbitDataVariable(PropertyInfo prop)
				: base(prop)
			{
			}

			public override void RefreshInput(IPartScript partScript)
			{
				base.Instance = (CraftOrbitData)(partScript?.CraftScript?.FlightData?.Orbit);
			}
		}

		private abstract class FlightProgramVariable<T> : InputControllerVariable<T>
		{
			protected string Variable { get; set; }

			protected string TargetPartId { get; set; }

			protected FlightProgramScript Modifier { get; set; }

			public FlightProgramVariable(string variable, string targetPartId)
			{
				Variable = variable;
				TargetPartId = targetPartId;
			}

			public abstract override Expression GetExpression(Context context, ParameterExpression dataSlots);

			public abstract override Func<double[], T> GetFunc(Context context);

			public override void RefreshInput(IPartScript partScript)
			{
				if (!InputControllerInput.IsValidInput(Modifier, partScript))
				{
					Modifier = InputControllerInput.FindTargetModifier(partScript, TargetPartId, "FlightProgram")?.GetScript() as FlightProgramScript;
					if (!InputControllerInput.IsValidInput(Modifier, partScript))
					{
						Modifier = null;
					}
				}
			}
		}

		private class FlightProgramNumberVariable : FlightProgramVariable<double>
		{
			public FlightProgramNumberVariable(string variable, string targetPartId)
				: base(variable, targetPartId)
			{
			}

			public override Expression GetExpression(Context context, ParameterExpression dataSlots)
			{
				string v = base.Variable;
				return ((Expression<Func<double>>)(() => (Modifier == null) ? 0.0 : (Modifier.GetGlobalValueAsDouble(v) ?? 0.0))).Body;
			}

			public override Func<double[], double> GetFunc(Context context)
			{
				string v = base.Variable;
				return (double[] data) => (!(base.Modifier == null)) ? base.Modifier.GetGlobalValueAsDouble(v).GetValueOrDefault() : 0.0;
			}
		}

		private class FlightProgramVectorVariable : FlightProgramVariable<Vector3d>
		{
			public FlightProgramVectorVariable(string variable, string targetPartId)
				: base(variable, targetPartId)
			{
			}

			public override Expression GetExpression(Context context, ParameterExpression dataSlots)
			{
				string v = base.Variable;
				return ((Expression<Func<Vector3d>>)(() => (Modifier == null) ? Vector3d.zero : (Modifier.GetGlobalValueAsVector(v) ?? Vector3d.zero))).Body;
			}

			public override Func<double[], Vector3d> GetFunc(Context context)
			{
				string v = base.Variable;
				return (double[] data) => (!(base.Modifier == null)) ? (base.Modifier.GetGlobalValueAsVector(v) ?? Vector3d.zero) : Vector3d.zero;
			}
		}

		private class PartModifierPropertyVariable : InputControllerVariable<double>
		{
			private readonly Func<double> _defaultInput = () => 0.0;

			private string _targetPartId;

			private string _targetModifierId;

			private string _targetPropertyName;

			private Func<double> _getInput;

			private PropertyInfo _currentProperty;

			private object _instance;

			private bool _isData;

			public PartModifierPropertyVariable(string targetPartId, string targetModifierId, string targetPropertyName, bool isData)
			{
				_targetPartId = targetPartId;
				_targetModifierId = targetModifierId;
				_targetPropertyName = targetPropertyName;
				_isData = isData;
				_getInput = _defaultInput;
			}

			public override Expression GetExpression(Context context, ParameterExpression dataSlots)
			{
				return ((Expression<Func<double>>)(() => _getInput())).Body;
			}

			public override Func<double[], double> GetFunc(Context context)
			{
				return (double[] data) => _getInput();
			}

			public override void RefreshInput(IPartScript partScript)
			{
				PartModifierScript partModifierScript = ((!_isData) ? (_instance as PartModifierScript) : (_instance as PartModifierData)?.GetScript());
				if (!InputControllerInput.IsValidInput(partModifierScript, partScript))
				{
					partModifierScript = InputControllerInput.FindTargetModifier(partScript, _targetPartId, _targetModifierId)?.GetScript();
					if (!InputControllerInput.IsValidInput(partModifierScript, partScript))
					{
						partModifierScript = null;
					}
				}
				object instance = _instance;
				_instance = ((!_isData) ? ((IDisposable)partModifierScript) : ((IDisposable)(partModifierScript?.GetData())));
				if (_instance != null)
				{
					Type type = _instance.GetType();
					if (_getInput != null && instance == _instance)
					{
						return;
					}
					_currentProperty = type.GetProperty(_targetPropertyName);
					if (_currentProperty == null)
					{
						Type[] interfaces = type.GetInterfaces();
						foreach (Type type2 in interfaces)
						{
							_currentProperty = type2.GetProperty(_targetPropertyName);
							if (_currentProperty != null)
							{
								break;
							}
						}
					}
					if (_currentProperty == null)
					{
						Debug.LogWarning($"Could not find input '{_targetPropertyName}' on part modifier of type '{type}'.");
						_getInput = _defaultInput;
					}
					else
					{
						_getInput = WrapDoublePropertyGetDelegate(_currentProperty, _instance);
					}
				}
				else
				{
					_getInput = _defaultInput;
				}
			}
		}

		private class PartModifierWrapperVariable : InputControllerVariable<double>
		{
			private string _targetPartId;

			private string _targetModifierId;

			private IInputControllerInput _instance;

			public PartModifierWrapperVariable(string targetPartId, string targetModifierId)
			{
				_targetPartId = targetPartId;
				_targetModifierId = targetModifierId;
			}

			public override Expression GetExpression(Context context, ParameterExpression dataSlots)
			{
				return ((Expression<Func<double>>)(() => (_instance == null) ? 0f : _instance.Value)).Body;
			}

			public override Func<double[], double> GetFunc(Context context)
			{
				_ = _instance;
				return (double[] d) => (_instance != null) ? ((double)_instance.Value) : 0.0;
			}

			public override void RefreshInput(IPartScript partScript)
			{
				PartModifierScript modifier = _instance as PartModifierScript;
				if (!InputControllerInput.IsValidInput(modifier, partScript))
				{
					modifier = InputControllerInput.FindTargetModifier(partScript, _targetPartId, _targetModifierId)?.GetScript();
					if (InputControllerInput.IsValidInput(modifier, partScript) && modifier is IInputControllerInput instance)
					{
						_instance = instance;
					}
					else
					{
						_instance = null;
					}
				}
			}
		}

		[Preserve]
		private static class IL2CPPBodge
		{
			public static CraftControlsVariable<string> CraftControlsVariable_string;

			public static CraftControlsVariable<double> CraftControlsVariable_double;

			public static CraftControlsVariable<bool> CraftControlsVariable_bool;

			public static CraftControlsVariable<float> CraftControlsVariable_float;

			public static CraftControlsVariable<Vector3d> CraftControlsVariable_vec;

			public static CraftFlightDataVariable<string> CraftFlightDataVariable_string;

			public static CraftFlightDataVariable<double> CraftFlightDataVariable_double;

			public static CraftFlightDataVariable<bool> CraftFlightDataVariable_bool;

			public static CraftFlightDataVariable<float> CraftFlightDataVariable_float;

			public static CraftFlightDataVariable<Vector3d> CraftFlightDataVariable_vec;

			public static CraftOrbitDataVariable<string> CraftOrbitDataVariable_string;

			public static CraftOrbitDataVariable<double> CraftOrbitDataVariable_double;

			public static CraftOrbitDataVariable<bool> CraftOrbitDataVariable_bool;

			public static CraftOrbitDataVariable<float> CraftOrbitDataVariable_float;

			public static CraftOrbitDataVariable<Vector3d> CraftOrbitDataVariable_vec;

			public static Func<string> Func_string;

			public static Func<double> Func_double;

			public static Func<bool> Func_bool;

			public static Func<float> Func_float;

			public static Func<Vector3d> Func_vec;
		}

		private List<IInputControllerVariable> _variables = new List<IInputControllerVariable>();

		private Func<double> _function;

		public bool Enabled => true;

		public float Value => (float)_function();

		public Func<double> Function => _function;

		public static InputControllerExpression Create(string text, Context.VariableResolveDelegate customResolve = null)
		{
			try
			{
				InputControllerExpression inputControllerExpression = new InputControllerExpression();
				Context context = new Context();
				context.GetDeltaTime = () => Time.deltaTime;
				context.EnableMemory = true;
				context.VariableResolve += inputControllerExpression.Context_VariableResolve;
				if (customResolve != null)
				{
					context.VariableResolve += customResolve;
				}
				inputControllerExpression._function = Parser.Process<double>(text, context);
				return inputControllerExpression;
			}
			catch (Exception arg)
			{
				Debug.LogWarning($"Unable to parse input: \"{text}\" | {arg}");
				return null;
			}
		}

		public static (InputControllerExpression controller, Delegate del) CreateAnyType(string text, Action<Context> contextHook = null)
		{
			InputControllerExpression inputControllerExpression = new InputControllerExpression();
			Context context = new Context();
			context.GetDeltaTime = () => Time.deltaTime;
			context.EnableMemory = true;
			context.VariableResolve += inputControllerExpression.Context_VariableResolve;
			contextHook?.Invoke(context);
			return (controller: inputControllerExpression, del: Parser.ProcessAnyType(text, context));
		}

		public static Func<TInst, TRet> GenericPropertyWrap<TInst, TRet>(PropertyInfo property)
		{
			return (Func<TInst, TRet>)Delegate.CreateDelegate(typeof(Func<TInst, TRet>), property.GetGetMethod());
		}

		public static Func<double> WrapDoublePropertyGetDelegate(PropertyInfo property, object instance)
		{
			Type propertyType = property.PropertyType;
			Delegate obj = Delegate.CreateDelegate(typeof(Func<>).MakeGenericType(propertyType), instance, property.GetGetMethod());
			if (propertyType == typeof(float))
			{
				Func<float> f = (Func<float>)obj;
				return () => f();
			}
			if (propertyType == typeof(double))
			{
				return (Func<double>)obj;
			}
			if (propertyType == typeof(bool))
			{
				Func<bool> f2 = (Func<bool>)obj;
				return () => (!f2()) ? (-1.0) : 1.0;
			}
			if (propertyType == typeof(Vector3d))
			{
				Func<Vector3d> f3 = (Func<Vector3d>)obj;
				return () => f3().magnitude;
			}
			Debug.LogWarning("Only float, double, and boolean properties are supported as input controller inputs.");
			return null;
		}

		public void RefreshInput(IPartScript partScript)
		{
			foreach (IInputControllerVariable variable in _variables)
			{
				variable.RefreshInput(partScript);
			}
		}

		private static Type CorrectType(Type t)
		{
			if (t == typeof(float) || t == typeof(int) || t == typeof(short))
			{
				return typeof(double);
			}
			return t;
		}

		private Token Context_VariableResolve(string text)
		{
			Token token = ResolveVariable(text);
			if (token is IInputControllerVariable item)
			{
				_variables.Add(item);
			}
			return token;
		}

		private Token ResolveVariable(string text)
		{
			Type type = null;
			PropertyInfo property = typeof(CraftControls).GetProperty(text);
			if (property != null)
			{
				return (Token)Activator.CreateInstance(typeof(CraftControlsVariable<>).MakeGenericType(CorrectType(property.PropertyType)), property);
			}
			if (text.StartsWith("AG", StringComparison.Ordinal))
			{
				string text2 = text;
				if (int.TryParse(text2.Substring(2, text2.Length - 2), out var result) || result < 1)
				{
					return new ActivationGroupVariable(result);
				}
			}
			else if (text.StartsWith("FlightData.", StringComparison.Ordinal))
			{
				Type typeFromHandle = typeof(CraftFlightData);
				string text2 = text;
				property = typeFromHandle.GetProperty(text2.Substring(11, text2.Length - 11));
				type = typeof(CraftFlightDataVariable<>);
			}
			else if (text.StartsWith("FD.", StringComparison.Ordinal))
			{
				Type typeFromHandle2 = typeof(CraftFlightData);
				string text2 = text;
				property = typeFromHandle2.GetProperty(text2.Substring(3, text2.Length - 3));
				type = typeof(CraftFlightDataVariable<>);
			}
			else if (text.StartsWith("OrbitData.", StringComparison.Ordinal))
			{
				Type typeFromHandle3 = typeof(CraftOrbitData);
				string text2 = text;
				property = typeFromHandle3.GetProperty(text2.Substring(10, text2.Length - 10));
				type = typeof(CraftOrbitDataVariable<>);
			}
			else if (text.StartsWith("OD.", StringComparison.Ordinal))
			{
				Type typeFromHandle4 = typeof(CraftOrbitData);
				string text2 = text;
				property = typeFromHandle4.GetProperty(text2.Substring(3, text2.Length - 3));
				type = typeof(CraftOrbitDataVariable<>);
			}
			if (property != null && type != null)
			{
				return (Token)Activator.CreateInstance(type.MakeGenericType(CorrectType(property.PropertyType)), property);
			}
			int num = text.IndexOf('.');
			if (num != -1)
			{
				string text3 = text.Remove(num);
				string text4;
				if (text.Length > num + 1)
				{
					string text2 = text;
					int num2 = num + 1;
					text4 = text2.Substring(num2, text2.Length - num2);
				}
				else
				{
					text4 = string.Empty;
				}
				text = text4;
				num = text.IndexOf('.');
				if (num == -1)
				{
					return new PartModifierWrapperVariable(text3, text);
				}
				string text5 = text.Remove(num);
				string text6;
				if (text.Length > num + 1)
				{
					string text2 = text;
					int num2 = num + 1;
					text6 = text2.Substring(num2, text2.Length - num2);
				}
				else
				{
					text6 = string.Empty;
				}
				string text7 = text6;
				if (text5 == "FlightProgram" || text5 == "VZ")
				{
					if (text3.StartsWith("v:"))
					{
						string variable = text7;
						string text2 = text3;
						return new FlightProgramVectorVariable(variable, text2.Substring(2, text2.Length - 2));
					}
					return new FlightProgramNumberVariable(text7, text3);
				}
				if (text7.StartsWith("Data.", StringComparison.Ordinal))
				{
					string text2 = text7;
					text7 = text2.Substring(5, text2.Length - 5);
					return new PartModifierPropertyVariable(text3, text5, text7, isData: true);
				}
				return new PartModifierPropertyVariable(text3, text5, text7, isData: false);
			}
			return null;
		}
	}
}

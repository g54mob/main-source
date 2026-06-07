using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Jundroo.Common.Expressions;
using Jundroo.Common.Expressions.Exceptions;
using Jundroo.Common.Math;
using Jundroo.Common.Platform;
using UnityEngine;

namespace Jundroo.Common.Utils
{
	public class DynamicExpressionText
	{
		private class ConstElement : StringElement
		{
			private bool _cached;

			public ConstElement(string value)
			{
				Value = value;
				base.CachedValue = value;
				_cached = false;
			}

			public override bool UpdateCachedValue()
			{
				if (!_cached)
				{
					_cached = true;
					return true;
				}
				return false;
			}
		}

		private class FloatExpElement : StringElement
		{
			private static readonly Regex _formatRegexQuotes = new Regex("\"([^']+)\"");

			private static readonly Regex _formatRegexSingleQuotes = new Regex("'([^']+)'");

			private readonly string _format;

			private readonly Func<float> _func;

			private readonly UnitType? _unit;

			private float _cachePrecision;

			private float _cacheResult;

			private string _positivePrefix;

			private float _result;

			public string Prefix
			{
				get
				{
					if (!(_result >= 0f))
					{
						return string.Empty;
					}
					return _positivePrefix;
				}
			}

			public override string Value
			{
				get
				{
					if (_unit.HasValue)
					{
						UnitType value = _unit.Value;
						if (value == UnitType.Mass || value == UnitType.Force)
						{
							return Prefix + (_result / MassScale).Format(_unit.Value, solo: false, longName: false, _format);
						}
						return Prefix + _result.Format(_unit.Value, solo: false, longName: false, _format);
					}
					return Prefix + Context.FormatNumber(_result, _format);
				}
			}

			public FloatExpElement(Func<float> func, string format, UnitType? unit)
			{
				_func = func;
				if (format.StartsWith('+') || format.StartsWith(' '))
				{
					_positivePrefix = format[0].ToString();
					format = format.Substring(1);
				}
				else
				{
					_positivePrefix = string.Empty;
				}
				_format = format;
				_unit = unit;
				_cacheResult = float.NaN;
				_cachePrecision = GetCachePrecision(format);
			}

			public override void Update()
			{
				_result = _func();
			}

			public override bool UpdateCachedValue()
			{
				if (System.Math.Abs(_cacheResult - _result) <= _cachePrecision)
				{
					return false;
				}
				_cacheResult = _result;
				base.CachedValue = Value;
				return true;
			}

			private static float GetCachePrecision(string format)
			{
				if (string.IsNullOrWhiteSpace(format))
				{
					return Mathf.Epsilon;
				}
				string text = _formatRegexQuotes.Replace(format, string.Empty);
				text = _formatRegexSingleQuotes.Replace(text ?? string.Empty, string.Empty);
				if (string.IsNullOrWhiteSpace(text))
				{
					return Mathf.Epsilon;
				}
				text = text.ToLower();
				if (text.Length == 1)
				{
					switch (text[0])
					{
					case 'd':
					case 'x':
						return 0.1f;
					case 'c':
					case 'f':
					case 'n':
						return 0.001f;
					case 'p':
						return 1E-06f;
					}
				}
				else if (text.Length == 2)
				{
					switch (text[0])
					{
					case 'd':
					case 'x':
						return 0.1f;
					case 'c':
					case 'f':
					case 'n':
					case 'p':
						switch (text[1])
						{
						case '0':
							return 0.001f;
						case '1':
							return 0.0001f;
						case '2':
							return 1E-05f;
						case '3':
							return 1E-06f;
						case '4':
							return 1E-07f;
						case '5':
							return 1E-08f;
						case '6':
							return 1E-09f;
						case '7':
							return 1E-10f;
						case '8':
							return 1E-11f;
						case '9':
							return 1E-12f;
						}
						break;
					}
				}
				bool flag = true;
				foreach (char c in text)
				{
					if (c != '0' && c != '#' && c != '.')
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					int num = text.IndexOf('.');
					if (num < 0)
					{
						return 0.1f;
					}
					switch (text.Length - (num + 1))
					{
					case 0:
						return 0.1f;
					case 1:
						return 0.01f;
					case 2:
						return 0.001f;
					case 3:
						return 0.0001f;
					case 4:
						return 1E-05f;
					case 5:
						return 1E-06f;
					case 6:
						return 1E-07f;
					case 7:
						return 1E-08f;
					case 8:
						return 1E-09f;
					case 9:
						return 1E-10f;
					}
				}
				return Mathf.Epsilon;
			}
		}

		private abstract class StringElement
		{
			public string CachedValue { get; protected set; }

			public virtual string Value { get; protected set; }

			public virtual void Update()
			{
			}

			public abstract bool UpdateCachedValue();
		}

		private class StringExpElement : StringElement
		{
			private readonly Func<string> _func;

			public StringExpElement(Func<string> func)
			{
				_func = func;
			}

			public override void Update()
			{
				Value = _func();
			}

			public override bool UpdateCachedValue()
			{
				string value = Value;
				if (base.CachedValue != value)
				{
					base.CachedValue = value;
					return true;
				}
				return false;
			}
		}

		private readonly Regex _expressionRegex = new Regex("{([^{};]*)(?:;(.*?))?(?:;(.*?))?}");

		private IDynamicExpressionSource _expressionSource;

		private List<StringElement> _parsedInput;

		private StringBuilder _sb = new StringBuilder();

		public static float MassScale { get; set; } = 0.01f;

		public bool HasDynamicInput { get; private set; }

		public string Text => _sb.ToString();

		public string WarningLogSource { get; set; }

		public DynamicExpressionText(IDynamicExpressionSource expressionSource)
		{
			_expressionSource = expressionSource;
		}

		public void MatchInputs(string text)
		{
			MatchCollection matchCollection = _expressionRegex.Matches(text);
			HasDynamicInput = false;
			if (_parsedInput == null)
			{
				_parsedInput = new List<StringElement>();
			}
			else
			{
				_parsedInput.Clear();
			}
			int num = 0;
			foreach (Match item in matchCollection)
			{
				if (item.Index > num)
				{
					_parsedInput.Add(new ConstElement(text.Substring(num, item.Index - num)));
					num = item.Index;
				}
				try
				{
					if (string.IsNullOrEmpty(item.Groups[2].Value))
					{
						Func<string> stringExpression = _expressionSource.GetStringExpression(item.Groups[1].Value);
						if (stringExpression != null)
						{
							_parsedInput.Add(new StringExpElement(stringExpression));
							HasDynamicInput = true;
						}
						else
						{
							_parsedInput.Add(new ConstElement(item.Groups[1].Value));
						}
					}
					else
					{
						Func<float> floatExpression = _expressionSource.GetFloatExpression(item.Groups[1].Value);
						UnitType result;
						if (floatExpression == null)
						{
							_parsedInput.Add(new ConstElement(item.Groups[1].Value));
						}
						else if (Enum.TryParse<UnitType>(item.Groups[3].Value, out result))
						{
							_parsedInput.Add(new FloatExpElement(floatExpression, item.Groups[2].Value, result));
							HasDynamicInput = true;
						}
						else
						{
							_parsedInput.Add(new FloatExpElement(floatExpression, item.Groups[2].Value, null));
							HasDynamicInput = true;
						}
					}
				}
				catch (ExpressionCompileException ex)
				{
					if (!Device.IsDemoBuild)
					{
						Debug.LogWarning($"Invalid expression on '{WarningLogSource}': Click for details\n{ex.Message}\nExpressions: {!Parser.Funk}\nExpression: {item.Value}");
					}
				}
				catch (ExpressionParseException ex2)
				{
					if (!Device.IsDemoBuild)
					{
						Debug.LogWarning($"Invalid syntax in expression on '{WarningLogSource}': Click for details\n{ex2.Message}\nExpressions: {!Parser.Funk}\nExpression: {item.Value}");
					}
				}
				num += item.Length;
			}
			if (num < text.Length)
			{
				_parsedInput.Add(new ConstElement(text.Substring(num)));
			}
		}

		public bool ParseText(string text, bool refreshInputs = false)
		{
			bool flag = false;
			if (_parsedInput == null || refreshInputs)
			{
				flag = true;
				MatchInputs(text);
				if (refreshInputs)
				{
					foreach (StringElement item in _parsedInput)
					{
						item.Update();
					}
				}
			}
			foreach (StringElement item2 in _parsedInput)
			{
				flag |= item2.UpdateCachedValue();
			}
			if (flag)
			{
				_sb.Clear();
				foreach (StringElement item3 in _parsedInput)
				{
					try
					{
						_sb.Append(item3.CachedValue);
					}
					catch (Exception ex)
					{
						_sb.Append(ex.Message);
						Debug.LogException(ex);
					}
				}
				return true;
			}
			return false;
		}

		public void Update()
		{
			foreach (StringElement item in _parsedInput)
			{
				item.Update();
			}
		}
	}
}

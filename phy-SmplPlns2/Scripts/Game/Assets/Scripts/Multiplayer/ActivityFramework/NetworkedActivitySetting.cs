using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Multiplayer.ActivityFramework.Events;
using Assets.Scripts.Multiplayer.Extensions;
using FishNet.Serializing;
using Jundroo.Common.DataTypes;
using Jundroo.Common.Utils;

namespace Assets.Scripts.Multiplayer.ActivityFramework
{
	public class NetworkedActivitySetting
	{
		public enum SettingValueType : byte
		{
			String = 0,
			Float = 1,
			Int = 2,
			Bool = 3
		}

		public enum VisibilityType : byte
		{
			Hidden = 0,
			Visible = 1,
			VisibleReadOnly = 2
		}

		private object _defaultValue;

		private object _value;

		private List<string> _valueOptions;

		public string DisplayName { get; private set; }

		public string Id { get; private set; }

		public bool IsDefault
		{
			get
			{
				if (_defaultValue == null)
				{
					return _value == null;
				}
				if (ValueType == SettingValueType.Float)
				{
					if (_value is float num && _defaultValue is float num2)
					{
						return Math.Abs(num - num2) < 0.01f;
					}
					return false;
				}
				return object.Equals(_value, _defaultValue);
			}
		}

		public VisibilityType LobbyVisibility { get; private set; }

		public VisibilityType MenuVisibility { get; private set; }

		public bool ReadOnly { get; private set; }

		public object Value
		{
			get
			{
				return _value;
			}
			set
			{
				if (value is int valueInt)
				{
					ValueInt = valueInt;
					return;
				}
				if (value is float valueFloat)
				{
					ValueFloat = valueFloat;
					return;
				}
				if (value is bool valueBool)
				{
					ValueBool = valueBool;
					return;
				}
				if (value is string valueString)
				{
					ValueString = valueString;
					return;
				}
				throw GetInvalidValueTypeException(setter: true, value.GetType());
			}
		}

		public bool ValueBool
		{
			get
			{
				if (ValueType == SettingValueType.Bool)
				{
					return (bool)(Value ?? ((object)false));
				}
				if (ValueType == SettingValueType.String)
				{
					if (!bool.TryParse(Value as string, out var result))
					{
						throw GetInvalidValueTypeException(setter: false, typeof(bool));
					}
					return result;
				}
				throw GetInvalidValueTypeException(setter: false, typeof(bool));
			}
			set
			{
				if (ValueType == SettingValueType.Bool)
				{
					SetValue(value);
					return;
				}
				if (ValueType == SettingValueType.String)
				{
					SetValue(value.ToString());
					return;
				}
				throw GetInvalidValueTypeException(setter: true, typeof(bool));
			}
		}

		public float ValueFloat
		{
			get
			{
				if (ValueType == SettingValueType.Float)
				{
					return (float)(Value ?? ((object)0f));
				}
				if (ValueType == SettingValueType.Int)
				{
					return (int)(Value ?? ((object)0));
				}
				if (ValueType == SettingValueType.String)
				{
					if (!float.TryParse(Value as string, out var result))
					{
						throw GetInvalidValueTypeException(setter: false, typeof(float));
					}
					return result;
				}
				throw GetInvalidValueTypeException(setter: false, typeof(float));
			}
			set
			{
				if (ValueType == SettingValueType.Float)
				{
					SetValue(value);
					return;
				}
				if (ValueType == SettingValueType.Int)
				{
					SetValue((int)value);
					return;
				}
				if (ValueType == SettingValueType.String)
				{
					SetValue(value.ToString());
					return;
				}
				throw GetInvalidValueTypeException(setter: true, typeof(float));
			}
		}

		public string ValueFormat { get; private set; } = "n0";

		public int ValueInt
		{
			get
			{
				if (ValueType == SettingValueType.Int)
				{
					return (int)(Value ?? ((object)0));
				}
				if (ValueType == SettingValueType.Float)
				{
					return (int)(float)(Value ?? ((object)0f));
				}
				if (ValueType == SettingValueType.String)
				{
					if (!int.TryParse(Value as string, out var result))
					{
						throw GetInvalidValueTypeException(setter: false, typeof(int));
					}
					return result;
				}
				throw GetInvalidValueTypeException(setter: false, typeof(int));
			}
			set
			{
				if (ValueType == SettingValueType.Int)
				{
					SetValue(value);
					return;
				}
				if (ValueType == SettingValueType.Float)
				{
					SetValue((float)value, true, false);
					return;
				}
				if (ValueType == SettingValueType.String)
				{
					SetValue(value.ToString());
					return;
				}
				throw GetInvalidValueTypeException(setter: true, typeof(int));
			}
		}

		public IReadOnlyList<string> ValueOptions => _valueOptions;

		public MinMaxValue<float>? ValueRange { get; private set; }

		public string ValueString
		{
			get
			{
				if (ValueType == SettingValueType.String)
				{
					return (string)Value;
				}
				if (ValueType == SettingValueType.Int)
				{
					return ((int)(Value ?? ((object)0))).ToString();
				}
				if (ValueType == SettingValueType.Float)
				{
					return ((float)(Value ?? ((object)0f))).ToString();
				}
				if (ValueType == SettingValueType.Bool)
				{
					return ((bool)(Value ?? ((object)false))).ToString();
				}
				throw GetInvalidValueTypeException(setter: false, typeof(string));
			}
			set
			{
				if (ValueType == SettingValueType.String)
				{
					SetValue(value);
					return;
				}
				if (ValueType == SettingValueType.Int)
				{
					if (!int.TryParse(value, out var result))
					{
						throw GetInvalidValueTypeException(setter: true, typeof(string));
					}
					SetValue(result);
					return;
				}
				if (ValueType == SettingValueType.Float)
				{
					if (!float.TryParse(value, out var result2))
					{
						throw GetInvalidValueTypeException(setter: true, typeof(string));
					}
					SetValue(result2);
					return;
				}
				if (ValueType == SettingValueType.Bool)
				{
					if (!bool.TryParse(value, out var result3))
					{
						throw GetInvalidValueTypeException(setter: true, typeof(string));
					}
					SetValue(result3);
					return;
				}
				throw GetInvalidValueTypeException(setter: true, typeof(string));
			}
		}

		public SettingValueType ValueType { get; private set; }

		public event EventHandler<NetworkedActivitySettingValueChangedEventArgs<bool>> ValueBoolChanged;

		public event EventHandler<NetworkedActivitySettingValueChangedEventArgs<object>> ValueChanged;

		public event EventHandler<NetworkedActivitySettingValueChangedEventArgs<float>> ValueFloatChanged;

		public event EventHandler<NetworkedActivitySettingValueChangedEventArgs<int>> ValueIntChanged;

		public event EventHandler<NetworkedActivitySettingValueChangedEventArgs<string>> ValueStringChanged;

		private NetworkedActivitySetting()
		{
			_valueOptions = new List<string>(0);
		}

		public static NetworkedActivitySetting CreateNew<TValue>(string id, TValue value)
		{
			NetworkedActivitySetting networkedActivitySetting = new NetworkedActivitySetting();
			networkedActivitySetting.Id = id;
			networkedActivitySetting.DisplayName = id;
			networkedActivitySetting.MenuVisibility = VisibilityType.Hidden;
			networkedActivitySetting.LobbyVisibility = VisibilityType.Hidden;
			networkedActivitySetting.ReadOnly = false;
			Type typeFromHandle = typeof(TValue);
			if (typeFromHandle == typeof(int))
			{
				networkedActivitySetting.ValueType = SettingValueType.Int;
				networkedActivitySetting._value = value;
			}
			else if (typeFromHandle == typeof(float))
			{
				networkedActivitySetting.ValueType = SettingValueType.Float;
				networkedActivitySetting._value = value;
			}
			else if (typeFromHandle == typeof(bool))
			{
				networkedActivitySetting.ValueType = SettingValueType.Bool;
				networkedActivitySetting._value = value;
			}
			else
			{
				if (!(typeFromHandle == typeof(string)))
				{
					throw new NotSupportedException($"Setting type of '{typeFromHandle}' is not currently supported");
				}
				networkedActivitySetting.ValueType = SettingValueType.String;
				networkedActivitySetting._value = value;
			}
			return networkedActivitySetting;
		}

		public static NetworkedActivitySetting LoadFromNetwork(Reader reader)
		{
			NetworkedActivitySetting networkedActivitySetting = new NetworkedActivitySetting();
			networkedActivitySetting.SerializeRead(reader, valueOnly: false);
			return networkedActivitySetting;
		}

		public static NetworkedActivitySetting LoadFromXml(XElement xml)
		{
			NetworkedActivitySetting networkedActivitySetting = new NetworkedActivitySetting();
			networkedActivitySetting.SerializeRead(xml, valueOnly: false);
			networkedActivitySetting._defaultValue = networkedActivitySetting.Value;
			return networkedActivitySetting;
		}

		public void RestoreDefaultValue()
		{
			SetValue(_defaultValue, raiseEvents: true, ignoreReadOnly: true);
		}

		public void SerializeRead(Reader reader, bool valueOnly)
		{
			if (!valueOnly)
			{
				Id = reader.ReadStringAllocated();
				DisplayName = reader.ReadStringAllocated();
				ValueType = reader.ReadEnum<SettingValueType>();
			}
			object value = ValueType switch
			{
				SettingValueType.Float => reader.ReadSingle(), 
				SettingValueType.Int => reader.ReadInt32(), 
				SettingValueType.Bool => reader.ReadBoolean(), 
				SettingValueType.String => reader.ReadStringAllocated(), 
				_ => throw new NotSupportedException($"ValueType of '{ValueType}' is not currently supported"), 
			};
			if (!valueOnly)
			{
				MenuVisibility = reader.ReadEnum<VisibilityType>();
				LobbyVisibility = reader.ReadEnum<VisibilityType>();
				ReadOnly = reader.ReadBoolean();
				if (reader.ReadBoolean())
				{
					ValueRange = new MinMaxValue<float>(reader.ReadSingle(), reader.ReadSingle());
				}
				int num = reader.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					_valueOptions.Add(reader.ReadStringAllocated());
				}
				ValueFormat = reader.ReadStringAllocated();
				if (reader.ReadBoolean())
				{
					_defaultValue = ValueType switch
					{
						SettingValueType.Float => reader.ReadSingle(), 
						SettingValueType.Int => reader.ReadInt32(), 
						SettingValueType.Bool => reader.ReadBoolean(), 
						SettingValueType.String => reader.ReadStringAllocated(), 
						_ => throw new NotSupportedException($"ValueType of '{ValueType}' is not currently supported for default value."), 
					};
				}
				else
				{
					_defaultValue = null;
				}
			}
			SetValue(value, raiseEvents: true, ignoreReadOnly: true);
		}

		public void SerializeRead(XElement xml, bool valueOnly)
		{
			SettingValueType? settingValueType = (valueOnly ? new SettingValueType?(ValueType) : ((SettingValueType?)null));
			if (!valueOnly)
			{
				Id = xml.GetStringAttributeOrNullIfEmpty("id") ?? throw new InvalidOperationException($"Setting requires an 'id' attribute: {xml}");
				DisplayName = xml.GetStringAttributeOrNullIfEmpty("displayName") ?? throw new InvalidOperationException($"Setting requires a 'displayName' attribute: {xml}");
				settingValueType = xml.GetEnumAttributeOrNull<SettingValueType>("type");
			}
			object obj = null;
			if (settingValueType.HasValue)
			{
				ValueType = settingValueType.Value;
				obj = ValueType switch
				{
					SettingValueType.Float => xml.GetFloatAttribute("value"), 
					SettingValueType.Int => xml.GetIntAttribute("value"), 
					SettingValueType.Bool => xml.GetBoolAttribute("value"), 
					SettingValueType.String => xml.GetStringAttribute("value"), 
					_ => throw new NotSupportedException($"ValueType of '{ValueType}' is not currently supported"), 
				};
			}
			else
			{
				string stringAttribute = xml.GetStringAttribute("value");
				int result2;
				float result3;
				if (bool.TryParse(stringAttribute, out var result))
				{
					ValueType = SettingValueType.Bool;
					obj = result;
				}
				else if (int.TryParse(stringAttribute, out result2))
				{
					ValueType = SettingValueType.Int;
					obj = result2;
				}
				else if (float.TryParse(stringAttribute, out result3))
				{
					ValueType = SettingValueType.Float;
					obj = result3;
				}
				else
				{
					ValueType = SettingValueType.String;
					obj = stringAttribute;
				}
			}
			if (!valueOnly)
			{
				MenuVisibility = xml.GetEnumAttribute("menuVisibility", VisibilityType.Hidden);
				LobbyVisibility = xml.GetEnumAttribute("lobbyVisibility", VisibilityType.Hidden);
				ReadOnly = xml.GetBoolAttribute("readOnly", MenuVisibility == VisibilityType.Hidden && LobbyVisibility == VisibilityType.Hidden);
				float? floatAttributeOrNull = xml.GetFloatAttributeOrNull("valueMin");
				float? floatAttributeOrNull2 = xml.GetFloatAttributeOrNull("valueMax");
				if (floatAttributeOrNull.HasValue || floatAttributeOrNull2.HasValue)
				{
					ValueRange = new MinMaxValue<float>(floatAttributeOrNull ?? float.MinValue, floatAttributeOrNull2 ?? float.MaxValue);
				}
				string stringAttributeOrNullIfEmpty = xml.GetStringAttributeOrNullIfEmpty("valueOptions");
				if (stringAttributeOrNullIfEmpty != null)
				{
					StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(stringAttributeOrNullIfEmpty, ',').GetEnumerator();
					while (enumerator.MoveNext())
					{
						StringUtility.StringSplitEntry current = enumerator.Current;
						if (current.Span.Length > 0)
						{
							_valueOptions.Add(current.ToString());
						}
					}
				}
				ValueFormat = xml.GetStringAttribute("valueFormat", "n0");
			}
			SetValue(obj, raiseEvents: true, ignoreReadOnly: true);
		}

		public void SerializeWrite(Writer writer, bool valueOnly)
		{
			if (!valueOnly)
			{
				writer.Write(Id);
				writer.Write(DisplayName);
				writer.WriteEnum(ValueType);
			}
			switch (ValueType)
			{
			case SettingValueType.Int:
				writer.Write(ValueInt);
				break;
			case SettingValueType.Float:
				writer.Write(ValueFloat);
				break;
			case SettingValueType.Bool:
				writer.Write(ValueBool);
				break;
			case SettingValueType.String:
				writer.Write(ValueString);
				break;
			default:
				throw new NotSupportedException($"Setting type of '{ValueType}' is not currently supported");
			}
			if (valueOnly)
			{
				return;
			}
			writer.WriteEnum(MenuVisibility);
			writer.WriteEnum(LobbyVisibility);
			writer.Write(ReadOnly);
			writer.Write(ValueRange.HasValue);
			if (ValueRange.HasValue)
			{
				writer.Write(ValueRange.Value.MinValue);
				writer.Write(ValueRange.Value.MaxValue);
			}
			writer.Write(_valueOptions.Count);
			foreach (string valueOption in _valueOptions)
			{
				writer.Write(valueOption);
			}
			writer.Write(ValueFormat);
			writer.WriteBoolean(_defaultValue != null);
			if (_defaultValue != null)
			{
				switch (ValueType)
				{
				case SettingValueType.Int:
					writer.Write((int)_defaultValue);
					break;
				case SettingValueType.Float:
					writer.Write((float)_defaultValue);
					break;
				case SettingValueType.Bool:
					writer.Write((bool)_defaultValue);
					break;
				case SettingValueType.String:
					writer.Write((string)_defaultValue);
					break;
				default:
					throw new NotSupportedException($"Setting type of '{ValueType}' is not currently supported");
				}
			}
		}

		public void SerializeWrite(XElement xml, bool valueOnly)
		{
			if (!valueOnly)
			{
				xml.SetAttributeValue("id", Id);
				xml.SetAttributeValue("displayName", DisplayName);
				xml.SetAttributeValue("type", ValueType);
			}
			xml.SetAttributeValue("value", ValueString);
			if (!valueOnly)
			{
				xml.SetAttributeValue("menuVisibility", MenuVisibility);
				xml.SetAttributeValue("lobbyVisibility", LobbyVisibility);
				xml.SetAttributeValue("readOnly", ReadOnly);
				if (ValueRange.HasValue)
				{
					xml.SetAttributeValue("valueMin", ValueRange.Value.MinValue);
					xml.SetAttributeValue("valueMax", ValueRange.Value.MaxValue);
				}
				if (ValueOptions.Count > 0)
				{
					xml.SetAttributeValue("valueOptions", string.Join(',', ValueOptions));
				}
			}
		}

		private Exception GetInvalidValueTypeException(bool setter, Type targetType)
		{
			return new InvalidOperationException(string.Format("Unable to {0} setting '{1}' as a '{2}' value because it is a '{3}' type.", setter ? "set" : "get", DisplayName, targetType.Name, ValueType));
		}

		private void SetValue(bool value, bool raiseEvents = true, bool ignoreReadOnly = false)
		{
			SetValueValidateReadOnly(value, ignoreReadOnly);
			bool flag = (bool)(Value ?? ((object)false));
			if (flag != value)
			{
				_value = value;
				if (raiseEvents)
				{
					this.ValueBoolChanged?.Invoke(this, new NetworkedActivitySettingValueChangedEventArgs<bool>(this, flag, value));
					this.ValueChanged?.Invoke(this, new NetworkedActivitySettingValueChangedEventArgs<object>(this, flag, value));
				}
			}
		}

		private void SetValue(float value, bool raiseEvents = true, bool ignoreReadOnly = false)
		{
			SetValueValidateReadOnly(value, ignoreReadOnly);
			SetValueValidateRange(value);
			SetValueValidateOptions(value);
			float num = (float)(Value ?? ((object)0f));
			if (num != value)
			{
				_value = value;
				if (raiseEvents)
				{
					this.ValueFloatChanged?.Invoke(this, new NetworkedActivitySettingValueChangedEventArgs<float>(this, num, value));
					this.ValueChanged?.Invoke(this, new NetworkedActivitySettingValueChangedEventArgs<object>(this, num, value));
				}
			}
		}

		private void SetValue(int value, bool raiseEvents = true, bool ignoreReadOnly = false)
		{
			SetValueValidateReadOnly(value, ignoreReadOnly);
			SetValueValidateRange(value);
			SetValueValidateOptions(value);
			int num = (int)(Value ?? ((object)0));
			if (num != value)
			{
				_value = value;
				if (raiseEvents)
				{
					this.ValueIntChanged?.Invoke(this, new NetworkedActivitySettingValueChangedEventArgs<int>(this, num, value));
					this.ValueChanged?.Invoke(this, new NetworkedActivitySettingValueChangedEventArgs<object>(this, num, value));
				}
			}
		}

		private void SetValue(string value, bool raiseEvents = true, bool ignoreReadOnly = false)
		{
			SetValueValidateReadOnly(value, ignoreReadOnly);
			SetValueValidateOptions(value);
			string text = (string)(Value ?? null);
			if (text != value)
			{
				_value = value;
				if (raiseEvents)
				{
					this.ValueStringChanged?.Invoke(this, new NetworkedActivitySettingValueChangedEventArgs<string>(this, text, value));
					this.ValueChanged?.Invoke(this, new NetworkedActivitySettingValueChangedEventArgs<object>(this, text, value));
				}
			}
		}

		private void SetValue(object value, bool raiseEvents = true, bool ignoreReadOnly = false)
		{
			if (value is int value2)
			{
				SetValue(value2, raiseEvents, ignoreReadOnly);
				return;
			}
			if (value is float value3)
			{
				SetValue(value3, raiseEvents, ignoreReadOnly);
				return;
			}
			if (value is bool value4)
			{
				SetValue(value4, raiseEvents, ignoreReadOnly);
				return;
			}
			if (value is string value5)
			{
				SetValue(value5, raiseEvents, ignoreReadOnly);
				return;
			}
			throw GetInvalidValueTypeException(setter: true, value.GetType());
		}

		private void SetValueValidateOptions(object value)
		{
			if (_valueOptions.Count > 0 && !_valueOptions.Contains(value.ToString()))
			{
				throw new InvalidOperationException(string.Format("Unable to set setting '{0}' to '{1}' because it is not one of the available options '{2}'.", DisplayName, value, string.Join(",", ValueOptions)));
			}
		}

		private void SetValueValidateRange(float value)
		{
			if (ValueRange.HasValue)
			{
				if (value < ValueRange.Value.MinValue || ValueRange.Value.MaxValue < value)
				{
					throw new InvalidOperationException($"Unable to set setting '{DisplayName}' to '{value}' because it is outside of the expected range '{ValueRange}'.");
				}
			}
		}

		private void SetValueValidateReadOnly(object value, bool ignoreReadOnly = false)
		{
			if (!ignoreReadOnly && ReadOnly)
			{
				throw new InvalidOperationException($"Unable to set setting '{DisplayName}' to '{value}' because it is read-only.");
			}
		}
	}
}

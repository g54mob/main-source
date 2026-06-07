using System.Collections.Generic;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using UnityEngine;

namespace ModApi.Craft.Program
{
	public class ExpressionResult
	{
		private bool? _bool;

		private List<ExpressionListItem> _list;

		private double? _number;

		private bool _resetCaches;

		private string _text;

		private Vector3d? _vector;

		public bool BoolValue
		{
			get
			{
				ResetCaches();
				if (!_bool.HasValue)
				{
					_bool = CastToBool();
				}
				return _bool.Value;
			}
			set
			{
				ExpressionType = ExpressionType.Boolean;
				_bool = value;
				_resetCaches = true;
			}
		}

		public ExpressionType ExpressionType { get; private set; }

		public bool IsNumberOrNumberAsText
		{
			get
			{
				if (ExpressionType == ExpressionType.Number)
				{
					return true;
				}
				if (ExpressionType == ExpressionType.Text && double.TryParse(TextValue, out var _))
				{
					return true;
				}
				return false;
			}
		}

		public bool IsVectorOrVectorAsText
		{
			get
			{
				if (ExpressionType == ExpressionType.Vector)
				{
					return true;
				}
				if (ExpressionType == ExpressionType.Text && TryParseVector(TextValue, out var _))
				{
					return true;
				}
				return false;
			}
		}

		public IReadOnlyList<ExpressionListItem> ListValue
		{
			get
			{
				ResetCaches();
				if (_list == null)
				{
					_list = CastToList();
				}
				return _list;
			}
		}

		public double NumberValue
		{
			get
			{
				ResetCaches();
				if (!_number.HasValue)
				{
					_number = CastToNumber();
				}
				return _number.Value;
			}
			set
			{
				ExpressionType = ExpressionType.Number;
				_number = value;
				_resetCaches = true;
			}
		}

		public string TextValue
		{
			get
			{
				ResetCaches();
				if (_text == null)
				{
					_text = CastToText();
				}
				return _text;
			}
			set
			{
				ExpressionType = ExpressionType.Text;
				_text = value;
				_resetCaches = true;
			}
		}

		public Vector3d VectorValue
		{
			get
			{
				ResetCaches();
				if (!_vector.HasValue)
				{
					_vector = CastToVector();
				}
				return _vector.Value;
			}
			set
			{
				ExpressionType = ExpressionType.Vector;
				_vector = value;
				_resetCaches = true;
			}
		}

		public ExpressionResult(XElement xml)
		{
			bool flag = false;
			double? doubleAttributeOrNull = xml.GetDoubleAttributeOrNull("number");
			if (xml.GetDoubleAttributeOrNull("number").HasValue)
			{
				NumberValue = doubleAttributeOrNull.Value;
				flag = true;
			}
			if (!flag)
			{
				string stringAttribute = xml.GetStringAttribute("text");
				if (stringAttribute != null)
				{
					TextValue = stringAttribute;
					flag = true;
				}
			}
			if (!flag)
			{
				bool? boolAttributeOrNull = xml.GetBoolAttributeOrNull("bool");
				if (boolAttributeOrNull.HasValue)
				{
					BoolValue = boolAttributeOrNull.Value;
					flag = true;
				}
			}
			if (!flag)
			{
				Vector3d? vector3dAttributeOrNull = xml.GetVector3dAttributeOrNull("vector");
				if (vector3dAttributeOrNull.HasValue)
				{
					VectorValue = vector3dAttributeOrNull.Value;
					flag = true;
				}
			}
			if (!flag)
			{
				XElement xElement = xml.Element("Items");
				if (xElement != null)
				{
					List<ExpressionListItem> list = new List<ExpressionListItem>();
					foreach (XElement item in xElement.Elements("I"))
					{
						list.Add(ExpressionListItem.CreateFromSerialised(item.Attribute("v").Value));
					}
					_list = list;
					OnListModified();
					flag = true;
				}
			}
			if (!flag)
			{
				NumberValue = 0.0;
			}
		}

		public ExpressionResult()
		{
			NumberValue = 0.0;
		}

		public ExpressionResult(List<ExpressionListItem> list)
		{
			_list = list;
			OnListModified();
		}

		public List<ExpressionListItem> GetListForModification()
		{
			if (_list == null)
			{
				_list = new List<ExpressionListItem>();
			}
			return _list;
		}

		public void OnListModified()
		{
			ExpressionType = ExpressionType.List;
			_resetCaches = true;
		}

		public void SaveXml(XElement xml)
		{
			switch (ExpressionType)
			{
			case ExpressionType.Boolean:
				xml.SetAttributeValue("bool", _bool);
				break;
			case ExpressionType.Text:
				xml.SetAttributeValue("text", _text);
				break;
			case ExpressionType.Number:
				xml.SetAttributeValue("number", _number);
				break;
			case ExpressionType.Vector:
				xml.SetAttributeValue("vector", _vector);
				break;
			case ExpressionType.List:
			{
				XElement xElement = new XElement("Items");
				xml.Add(xElement);
				{
					foreach (ExpressionListItem item in _list)
					{
						XElement xElement2 = new XElement("I");
						xElement2.SetAttributeValue("v", item);
						xElement.Add(xElement2);
					}
					break;
				}
			}
			}
		}

		public void Set(ExpressionResult value)
		{
			_bool = value._bool;
			_number = value._number;
			_text = value._text;
			_vector = value._vector;
			_list = ((value._list == null) ? null : new List<ExpressionListItem>(value._list));
			_resetCaches = value._resetCaches;
			ExpressionType = value.ExpressionType;
		}

		internal static bool TryParseVector(string s, out Vector3d result)
		{
			if (s.StartsWith("#"))
			{
				if (ColorUtility.TryParseHtmlString(s, out var color))
				{
					result = new Vector3d(color.r, color.g, color.b);
					return true;
				}
			}
			else
			{
				if (Vector3d.TryParse(s, out var result2))
				{
					result = result2;
					return true;
				}
				if (Vector2d.TryParse(s, out var result3))
				{
					result = (Vector3d)result3;
					return true;
				}
			}
			result = Vector3d.zero;
			return false;
		}

		private bool CastToBool()
		{
			switch (ExpressionType)
			{
			case ExpressionType.Boolean:
				return _bool.Value;
			case ExpressionType.Text:
				if (!(_text.ToLower() == "true"))
				{
					return NumberValue != 0.0;
				}
				return true;
			case ExpressionType.Number:
				return _number.Value != 0.0;
			case ExpressionType.Vector:
				return false;
			default:
				return false;
			}
		}

		private List<ExpressionListItem> CastToList()
		{
			return new List<ExpressionListItem>();
		}

		private double CastToNumber()
		{
			switch (ExpressionType)
			{
			case ExpressionType.Boolean:
				return _bool.Value ? 1 : 0;
			case ExpressionType.Text:
			{
				double.TryParse(_text, out var result);
				return result;
			}
			case ExpressionType.Number:
				return _number.Value;
			case ExpressionType.Vector:
				return _vector.Value.magnitude;
			default:
				return 0.0;
			}
		}

		private string CastToText()
		{
			switch (ExpressionType)
			{
			case ExpressionType.Boolean:
				if (!_bool.Value)
				{
					return "false";
				}
				return "true";
			case ExpressionType.List:
				return $"List with {_list.Count} item(s)";
			case ExpressionType.Text:
				return _text;
			case ExpressionType.Number:
				return _number.Value.ToString();
			case ExpressionType.Vector:
				return _vector.Value.ToString();
			default:
				return string.Empty;
			}
		}

		private Vector3d CastToVector()
		{
			switch (ExpressionType)
			{
			case ExpressionType.Boolean:
				return Vector3d.zero;
			case ExpressionType.Text:
			{
				TryParseVector(_text, out var result);
				return result;
			}
			case ExpressionType.Number:
				return Vector3d.zero;
			case ExpressionType.Vector:
				return _vector.Value;
			default:
				return Vector3d.zero;
			}
		}

		private void ResetCaches()
		{
			if (_resetCaches)
			{
				_resetCaches = false;
				if (ExpressionType != ExpressionType.Boolean)
				{
					_bool = null;
				}
				if (ExpressionType != ExpressionType.List)
				{
					_list = null;
				}
				if (ExpressionType != ExpressionType.Number)
				{
					_number = null;
				}
				if (ExpressionType != ExpressionType.Text)
				{
					_text = null;
				}
				if (ExpressionType != ExpressionType.Vector)
				{
					_vector = null;
				}
			}
		}
	}
}

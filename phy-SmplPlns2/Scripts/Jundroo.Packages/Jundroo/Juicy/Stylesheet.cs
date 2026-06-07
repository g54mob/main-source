using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using UnityEngine;

namespace Jundroo.Juicy
{
	public class Stylesheet : IStylesheet
	{
		private Dictionary<string, string> _constantsCache = new Dictionary<string, string>();

		private Stack<Dictionary<string, string>> _constantsStack = new Stack<Dictionary<string, string>>();

		private Dictionary<string, WidgetStyle> _styles = new Dictionary<string, WidgetStyle>();

		private Dictionary<string, XElement> _templates = new Dictionary<string, XElement>();

		public Stylesheet()
		{
			PushConstantsLayer();
		}

		public string GetConstant(string name)
		{
			string value = null;
			if (!_constantsCache.TryGetValue(name, out value))
			{
				foreach (Dictionary<string, string> item in _constantsStack)
				{
					if (item.TryGetValue(name, out value))
					{
						_constantsCache[name] = value;
						break;
					}
				}
			}
			return value;
		}

		public WidgetStyle GetStyle(string name)
		{
			if (_styles.TryGetValue(name, out var value))
			{
				return value;
			}
			return null;
		}

		public XElement GetTemplate(string name)
		{
			if (_templates.TryGetValue(name, out var value))
			{
				return value;
			}
			return null;
		}

		public void LoadXml(XElement xml, IWidgetContext context)
		{
			IEnumerable<XElement> enumerable = xml.Element("Constants")?.Elements();
			if (enumerable != null)
			{
				foreach (XElement item in enumerable)
				{
					if (context.PreprocessElement(item))
					{
						SetConstant(item.GetStringAttribute("name"), item.GetStringAttribute("value"));
					}
				}
			}
			IEnumerable<XElement> enumerable2 = xml.Element("Styles")?.Elements();
			if (enumerable2 != null)
			{
				foreach (XElement item2 in enumerable2)
				{
					if (context.PreprocessElement(item2))
					{
						ProcessConstants(item2);
						WidgetStyle widgetStyle = new WidgetStyle(item2.GetStringAttribute("class"), item2);
						SetStyle(widgetStyle.Name, widgetStyle);
					}
				}
			}
			IEnumerable<XElement> enumerable3 = xml.Element("Templates")?.Elements();
			if (enumerable3 == null)
			{
				return;
			}
			foreach (XElement item3 in enumerable3)
			{
				if (context.PreprocessElement(item3))
				{
					string stringAttribute = item3.GetStringAttribute("templateId");
					_templates[stringAttribute] = item3;
				}
			}
		}

		public void PopConstantsLayer()
		{
			_constantsStack.Pop();
			_constantsCache.Clear();
		}

		public void ProcessConstants(XElement element)
		{
			foreach (XAttribute item in element.Attributes())
			{
				string text = item.Value;
				if (text.Contains('@'))
				{
					string pattern = "(?<!@)@(\\(?)([a-zA-Z0-9]+)\\)?";
					text = Regex.Replace(text, pattern, delegate(Match m)
					{
						string value = m.Groups[2].Value;
						string constant = GetConstant(value);
						if (constant == null)
						{
							Debug.LogWarning("Could not find constant '" + value + "' in element '" + element.Name.LocalName + "'");
							return m.Value;
						}
						return constant;
					});
					if (text.Contains("@@"))
					{
						text = text.Replace("@@", "@");
					}
				}
				item.Value = text;
			}
		}

		public void PushConstantsLayer()
		{
			_constantsStack.Push(new Dictionary<string, string>());
			_constantsCache.Clear();
		}

		public void SetConstant(string name, string value)
		{
			try
			{
				_constantsStack.Peek()[name] = value;
				_constantsCache[name] = value;
			}
			catch (Exception innerException)
			{
				throw new Exception("Could not set constant '" + name + "' to value '" + value + "'", innerException);
			}
		}

		public void SetStyle(string name, WidgetStyle style)
		{
			if (style.Name.Contains(' '))
			{
				string[] array = style.Name.Split(' ');
				if (array.Length != 2)
				{
					throw new NotSupportedException("Nested styles can only have a single parent: " + style.Name);
				}
				string name2 = array[0];
				style.NestedName = array[1];
				WidgetStyle widgetStyle = GetStyle(name2);
				if (widgetStyle == null)
				{
					widgetStyle = new WidgetStyle(name2);
					SetStyle(name2, widgetStyle);
				}
				widgetStyle.Children.Add(style);
			}
			style.Order = _styles.Values.Count;
			_styles[name] = style;
		}
	}
}

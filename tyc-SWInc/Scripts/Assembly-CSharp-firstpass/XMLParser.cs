using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UnityEngine;

public static class XMLParser
{
	public class XMLNode
	{
		public string Name;

		public string Value;

		public List<XMLNode> Children;

		public Dictionary<string, string> Attributes;

		public string GetAttribute(string key)
		{
			string value = "";
			if (!Attributes.TryGetValue(key, out value))
			{
				throw new Exception("Tried getting non-existent attribute " + key + " for XML tag " + Name);
			}
			return value;
		}

		public string TryGetAttribute(string key, string defaultValue = null)
		{
			string value = "";
			if (!Attributes.TryGetValue(key, out value))
			{
				return defaultValue;
			}
			return value;
		}

		public XMLNode[] GetNodes(string key, bool expectsValues = true)
		{
			XMLNode[] array = Children.Where((XMLNode x) => x.Name.Equals(key)).ToArray();
			if (array.Length == 0 && expectsValues)
			{
				throw new Exception("Asked for non-existent XML tag " + key);
			}
			return array;
		}

		public XMLNode GetNode(string key, bool expectsValues = true)
		{
			XMLNode xMLNode = Children.FirstOrDefault((XMLNode x) => x.Name.Equals(key));
			if (xMLNode == null && expectsValues)
			{
				throw new Exception("Asked for non-existent XML tag " + key);
			}
			return xMLNode;
		}

		public string GetNodeValue(string key, string def = null)
		{
			XMLNode xMLNode = Children.FirstOrDefault((XMLNode x) => x.Name.Equals(key));
			if (xMLNode != null)
			{
				return xMLNode.Value;
			}
			return def;
		}

		public T GetNodeValue<T>(string key)
		{
			XMLNode xMLNode = Children.FirstOrDefault((XMLNode x) => x.Name.Equals(key));
			if (xMLNode == null)
			{
				throw new Exception("Asked for non-existent XML tag " + key);
			}
			Type typeFromHandle = typeof(T);
			object obj = TypeDescriptor.GetConverter(typeFromHandle).ConvertFrom(xMLNode.Value);
			if (obj != null)
			{
				return (T)obj;
			}
			throw new Exception("Failed converting " + key + " to " + typeFromHandle.Name);
		}

		public T GetNodeValue<T>(string key, T defaultValue)
		{
			XMLNode xMLNode = Children.FirstOrDefault((XMLNode x) => x.Name.Equals(key));
			if (xMLNode == null)
			{
				return defaultValue;
			}
			object obj = TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(xMLNode.Value);
			if (obj != null)
			{
				return (T)obj;
			}
			return defaultValue;
		}

		public T? GetNodeValueOptional<T>(string key) where T : struct
		{
			XMLNode xMLNode = Children.FirstOrDefault((XMLNode x) => x.Name.Equals(key));
			if (xMLNode == null)
			{
				return null;
			}
			Type typeFromHandle = typeof(T);
			object obj = TypeDescriptor.GetConverter(typeFromHandle).ConvertFrom(xMLNode.Value);
			if (obj != null)
			{
				return (T)obj;
			}
			throw new Exception("Failed converting " + key + " to " + typeFromHandle.Name);
		}

		public bool Contains(string name)
		{
			return Children.Any((XMLNode x) => x.Name.Equals(name));
		}

		public XMLNode(string name, string value, List<XMLNode> children, Dictionary<string, string> att)
		{
			Name = name;
			Value = value;
			Children = children;
			Attributes = att;
		}

		public XMLNode(string name)
		{
			Name = name;
			Value = null;
			Children = new List<XMLNode>();
			Attributes = new Dictionary<string, string>();
		}

		public XMLNode(string name, string value, Dictionary<string, string> att = null)
		{
			Name = name;
			Value = value;
			Children = new List<XMLNode>();
			Attributes = att ?? new Dictionary<string, string>();
		}

		public XMLNode(string name, params XMLNode[] children)
		{
			Name = name;
			Value = null;
			Children = children.ToList();
			Attributes = new Dictionary<string, string>();
		}

		public XMLNode()
		{
			Name = "";
			Value = null;
			Children = new List<XMLNode>();
			Attributes = new Dictionary<string, string>();
		}

		public override string ToString()
		{
			if (Value != null)
			{
				return "<" + Name + ">" + Value + "</" + Name + ">";
			}
			if (Children.Count > 0)
			{
				return "<" + Name + "><" + Children.Count + "></" + Name + ">";
			}
			return "<" + Name + ">";
		}
	}

	public static XMLNode ParseXML(string text)
	{
		if (string.IsNullOrEmpty(text.Trim()))
		{
			return null;
		}
		int pos = 0;
		int line = 1;
		return ParseTag(text, ref pos, ref line);
	}

	public static List<XMLNode> ParseXMLFull(string text)
	{
		if (string.IsNullOrEmpty(text.Trim()))
		{
			return null;
		}
		int pos = 0;
		int line = 1;
		List<XMLNode> list = new List<XMLNode>();
		XMLNode item;
		while ((item = ParseTag(text, ref pos, ref line)) != null)
		{
			list.Add(item);
		}
		return list;
	}

	private static XMLNode ParseTag(string text, ref int pos, ref int line)
	{
		if (pos >= text.Length)
		{
			return null;
		}
		bool flag = false;
		StringBuilder stringBuilder = new StringBuilder();
		XMLNode xMLNode = new XMLNode();
		int num = 0;
		bool flag2 = false;
		int num2 = -1;
		IgnoreWhiteSpace(text, ref pos, ref line);
		while (!flag && pos < text.Length)
		{
			char c = text[pos];
			if (c == '\n')
			{
				line++;
			}
			switch (num)
			{
			case 0:
				if (c != '<')
				{
					break;
				}
				if (pos + 1 < text.Length && (text[pos + 1] == '!' || text[pos + 1] == '?'))
				{
					while (pos + 1 < text.Length && (text[pos] != '-' || text[pos + 1] != '>'))
					{
						ReadUntil(text, ref pos, '-', ref line);
					}
					pos += 2;
					break;
				}
				num2 = line;
				flag2 = true;
				pos++;
				if (IgnoreWhiteSpace(text, ref pos, ref line))
				{
					throw new UnityException("Failed parsing XML at line " + num2);
				}
				pos--;
				num = 1;
				break;
			case 1:
				if (!char.IsWhiteSpace(c) && c != '>')
				{
					stringBuilder.Append(c);
					break;
				}
				if (c == '>')
				{
					pos--;
				}
				xMLNode.Name = stringBuilder.ToString();
				stringBuilder.Clear();
				num = 2;
				break;
			case 2:
				if (c == '>')
				{
					num = 5;
					break;
				}
				if (!char.IsWhiteSpace(c))
				{
					stringBuilder.Append(c);
					num = 3;
					break;
				}
				if (IgnoreWhiteSpace(text, ref pos, ref line))
				{
					throw new UnityException("Failed parsing XML node " + xMLNode.Name + " at line " + num2 + " while reading inital tag");
				}
				pos--;
				break;
			case 3:
				if (c == '=')
				{
					pos++;
					if (IgnoreWhiteSpace(text, ref pos, ref line))
					{
						throw new UnityException("Failed parsing XML node " + xMLNode.Name + " at line " + num2 + " while reading attributes");
					}
					if (text[pos] != '"')
					{
						throw new UnityException("Failed parsing XML node " + xMLNode.Name + " at line " + num2 + " while reading attributes");
					}
					pos++;
					string value = ParseString(text, ref pos, '"', ref line);
					xMLNode.Attributes[stringBuilder.ToString()] = value;
					stringBuilder.Clear();
					pos--;
					num = 2;
				}
				else if (!char.IsWhiteSpace(c))
				{
					stringBuilder.Append(c);
				}
				else
				{
					if (IgnoreWhiteSpace(text, ref pos, ref line))
					{
						throw new UnityException("Failed parsing XML node " + xMLNode.Name + " at line " + num2 + " while reading attributes");
					}
					pos--;
				}
				break;
			case 4:
			{
				XMLNode xMLNode2 = ParseTag(text, ref pos, ref line);
				if (xMLNode2 == null)
				{
					throw new UnityException("Failed parsing child tag for " + xMLNode.Name + " at line " + num2);
				}
				xMLNode.Children.Add(xMLNode2);
				pos--;
				num = 6;
				break;
			}
			case 5:
				if (!HasSubItems(text, pos))
				{
					xMLNode.Value = ParseString(text, ref pos, '<', ref line);
					pos -= 2;
				}
				else
				{
					pos--;
				}
				num = 6;
				break;
			case 6:
				if (char.IsWhiteSpace(c))
				{
					if (IgnoreWhiteSpace(text, ref pos, ref line))
					{
						throw new UnityException("Failed parsing XML node " + xMLNode.Name + " at line " + num2);
					}
					pos--;
				}
				else if (IsEndTag(text, pos))
				{
					pos += 2;
					if (IgnoreWhiteSpace(text, ref pos, ref line))
					{
						throw new UnityException("Failed parsing XML node " + xMLNode.Name + " at line " + num2);
					}
					string text2 = ParseString(text, ref pos, '>', ref line, true);
					pos--;
					if (!text2.Equals(xMLNode.Name))
					{
						throw new UnityException("Failed parsing XML node " + xMLNode.Name + " at line " + num2 + ", wrong end tag " + text2 + " at line " + line);
					}
					if (IgnoreWhiteSpace(text, ref pos, ref line))
					{
						throw new UnityException("Failed parsing XML node " + xMLNode.Name + " at line " + num2);
					}
					if (text[pos] != '>')
					{
						throw new UnityException("Failed parsing XML node " + xMLNode.Name + ", missing ending of tag at line " + line);
					}
					flag = true;
				}
				else if (c == '<' && pos + 1 < text.Length && (text[pos + 1] == '!' || text[pos + 1] == '?'))
				{
					while (pos + 1 < text.Length && (text[pos] != '-' || text[pos + 1] != '>'))
					{
						ReadUntil(text, ref pos, '-', ref line);
					}
					pos += 2;
				}
				else if (c == '<')
				{
					num = 4;
					pos--;
				}
				else
				{
					if (pos >= text.Length)
					{
						throw new UnityException("Failed parsing XML node " + xMLNode.Name + ", missing ending of tag at line " + line);
					}
					ReadUntil(text, ref pos, '<', ref line, false);
					pos--;
				}
				break;
			default:
				throw new UnityException("Reached undefined XML parser state at line " + line);
			}
			pos++;
		}
		if (!flag2)
		{
			return null;
		}
		return xMLNode;
	}

	private static bool HasSubItems(string text, int pos)
	{
		while (char.IsWhiteSpace(text[pos]) && pos < text.Length)
		{
			pos++;
		}
		if (text[pos] == '<')
		{
			if (pos + 1 < text.Length)
			{
				return text[pos + 1] != '/';
			}
			return true;
		}
		return false;
	}

	private static bool IgnoreWhiteSpace(string text, ref int pos, ref int line)
	{
		while (char.IsWhiteSpace(text[pos]))
		{
			pos++;
			if (pos >= text.Length)
			{
				return true;
			}
			if (text[pos] == '\n')
			{
				line++;
			}
		}
		return false;
	}

	private static bool IsEndTag(string text, int pos)
	{
		if (pos < text.Length && text[pos] == '<' && pos + 1 < text.Length)
		{
			return text[pos + 1] == '/';
		}
		return false;
	}

	private static string ParseString(string text, ref int pos, char endChar, ref int line, bool endOnSpace = false)
	{
		StringBuilder stringBuilder = new StringBuilder();
		while (pos < text.Length && text[pos] != endChar && (!endOnSpace || !char.IsWhiteSpace(text[pos])))
		{
			stringBuilder.Append(text[pos]);
			pos++;
			if (pos < text.Length && text[pos] == '\n')
			{
				line++;
			}
		}
		pos++;
		if (pos < text.Length && text[pos] == '\n')
		{
			line++;
		}
		return stringBuilder.ToString();
	}

	private static void ReadUntil(string text, ref int pos, char endChar, ref int line, bool skipToNext = true)
	{
		while (pos < text.Length && text[pos] != endChar)
		{
			pos++;
			if (pos < text.Length && text[pos] == '\n')
			{
				line++;
			}
		}
		if (skipToNext)
		{
			pos++;
			if (pos < text.Length && text[pos] == '\n')
			{
				line++;
			}
		}
	}

	public static string ExportXML(XMLNode root)
	{
		StringBuilder stringBuilder = new StringBuilder();
		AppendNode(stringBuilder, root, 0);
		return stringBuilder.ToString();
	}

	private static void AppendNode(StringBuilder sb, XMLNode node, int indent)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(new string('\t', indent));
		stringBuilder.Append('<');
		stringBuilder.Append(node.Name);
		if (node.Attributes.Count > 0)
		{
			stringBuilder.Append(" " + string.Join(" ", node.Attributes.Select((KeyValuePair<string, string> x) => x.Key + "=\"" + x.Value + "\"").ToArray()));
		}
		stringBuilder.Append('>');
		if (node.Children.Count > 0)
		{
			sb.AppendLine(stringBuilder.ToString());
			foreach (XMLNode child in node.Children)
			{
				AppendNode(sb, child, indent + 1);
			}
			sb.AppendLine(new string('\t', indent) + "</" + node.Name + ">");
		}
		else if (node.Value != null)
		{
			sb.AppendLine(stringBuilder.ToString() + node.Value + "</" + node.Name + ">");
		}
		else
		{
			sb.AppendLine(stringBuilder.ToString() + "</" + node.Name + ">");
		}
	}

	public static void Clear(this StringBuilder sb)
	{
		sb.Length = 0;
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Tyd
{
	public abstract class TydCollection : TydNode, IEnumerable<TydNode>, IEnumerable
	{
		protected List<TydNode> _nodes = new List<TydNode>();

		protected Dictionary<string, string> _attributes;

		public string AttributeClass
		{
			get
			{
				return GetAttributeOrNull("class");
			}
			set
			{
				SetAttribute("class", value);
			}
		}

		public string AttributeHandle
		{
			get
			{
				return GetAttributeOrNull("handle");
			}
			set
			{
				SetAttribute("handle", value);
			}
		}

		public string AttributeSource
		{
			get
			{
				return GetAttributeOrNull("source");
			}
			set
			{
				SetAttribute("source", value);
			}
		}

		public bool AttributeAbstract
		{
			get
			{
				return HasAttribute("abstract");
			}
			set
			{
				UnsetAttribute("abstract", !value);
			}
		}

		public bool AttributeNoInherit
		{
			get
			{
				return HasAttribute("noinherit");
			}
			set
			{
				UnsetAttribute("noinherit", !value);
			}
		}

		public int Count
		{
			get
			{
				return _nodes.Count;
			}
		}

		public List<TydNode> Nodes
		{
			get
			{
				return _nodes;
			}
			set
			{
				_nodes = value;
			}
		}

		public TydNode this[int index]
		{
			get
			{
				return _nodes[index];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEnumerator<TydNode> GetEnumerator()
		{
			foreach (TydNode node in _nodes)
			{
				yield return node;
			}
		}

		public TydCollection(string name, int docLine = -1)
			: base(name, docLine)
		{
		}

		public void SetupAttributes(Dictionary<string, string> attributes)
		{
			_attributes = attributes;
		}

		public IEnumerable<T> GetChildValues<T>(bool onlyStrings = true)
		{
			for (int i = 0; i < _nodes.Count; i++)
			{
				TydString tydString;
				if ((tydString = _nodes[i] as TydString) != null)
				{
					yield return tydString.GetValue<T>(base.Name);
				}
				else if (onlyStrings)
				{
					throw new Exception("Could not convert node in " + base.Name + " as it is not a string");
				}
			}
		}

		public IEnumerable<string> GetChildValues(bool onlyStrings = true)
		{
			for (int i = 0; i < _nodes.Count; i++)
			{
				TydString tydString;
				if ((tydString = _nodes[i] as TydString) != null)
				{
					yield return tydString.Value;
				}
				else if (onlyStrings)
				{
					throw new Exception("Node in " + base.Name + " is not a string");
				}
			}
		}

		public T GetChildValue<T>(string name, bool required = true, T defaultValue = default(T))
		{
			for (int i = 0; i < _nodes.Count; i++)
			{
				TydNode tydNode = _nodes[i];
				if (name.Equals(tydNode.Name))
				{
					return GetChildValue<T>(i);
				}
			}
			if (required)
			{
				if (string.IsNullOrEmpty(base.Name))
				{
					throw new Exception("Missing node " + name);
				}
				throw new Exception("Missing node " + name + " in " + base.Name);
			}
			return defaultValue;
		}

		public string GetChildValue(string name, bool required = true)
		{
			for (int i = 0; i < _nodes.Count; i++)
			{
				TydNode tydNode = _nodes[i];
				if (name.Equals(tydNode.Name))
				{
					return GetChildValue(i);
				}
			}
			if (required)
			{
				throw new Exception("Missing node " + name + " in " + base.Name);
			}
			return null;
		}

		public T GetChildValue<T>(int idx)
		{
			if (idx < 0 || idx >= _nodes.Count)
			{
				throw new Exception("Index is out of bounds for " + base.Name);
			}
			TydString tydString;
			if ((tydString = _nodes[idx] as TydString) != null)
			{
				return tydString.GetValue<T>();
			}
			throw new Exception("Node " + _nodes[idx].Name + " in " + base.Name + " is not a string");
		}

		public string GetChildValue(int idx)
		{
			if (idx < 0 || idx >= _nodes.Count)
			{
				throw new Exception("Index is out of bounds for " + base.Name);
			}
			TydString tydString;
			if ((tydString = _nodes[idx] as TydString) != null)
			{
				return tydString.Value;
			}
			throw new Exception("Node " + _nodes[idx].Name + " in " + base.Name + " is not a string");
		}

		public TydNode GetChild(string name, bool required = false)
		{
			for (int i = 0; i < _nodes.Count; i++)
			{
				TydNode tydNode = _nodes[i];
				if (name.Equals(tydNode.Name))
				{
					return tydNode;
				}
			}
			if (required)
			{
				throw new Exception("Missing node " + name + " in " + base.Name);
			}
			return null;
		}

		public T GetChild<T>(string name, bool required = false) where T : TydNode
		{
			for (int i = 0; i < _nodes.Count; i++)
			{
				TydNode tydNode = _nodes[i];
				T result;
				if (name.Equals(tydNode.Name) && (result = tydNode as T) != null)
				{
					return result;
				}
			}
			if (required)
			{
				throw new Exception("Missing node " + name + " in " + base.Name);
			}
			return null;
		}

		public TydTable Seek(string key, string value)
		{
			TydTable result;
			if ((result = this as TydTable) != null)
			{
				string childValue = GetChildValue(key, false);
				if (value.Equals(childValue))
				{
					return result;
				}
			}
			for (int i = 0; i < _nodes.Count; i++)
			{
				TydCollection tydCollection;
				if ((tydCollection = _nodes[i] as TydCollection) != null)
				{
					TydTable tydTable = tydCollection.Seek(key, value);
					if (tydTable != null)
					{
						return tydTable;
					}
				}
			}
			return null;
		}

		public IEnumerable<KeyValuePair<string, string>> GetAttributes()
		{
			if (_attributes == null)
			{
				yield break;
			}
			foreach (KeyValuePair<string, string> attribute in _attributes)
			{
				yield return attribute;
			}
		}

		public void SetAttribute(string key, string value)
		{
			if (_attributes == null)
			{
				_attributes = new Dictionary<string, string>();
			}
			_attributes[key] = value;
		}

		public void UnsetAttribute(string key, bool unset)
		{
			if (_attributes == null)
			{
				if (unset)
				{
					return;
				}
				_attributes = new Dictionary<string, string>();
			}
			if (unset)
			{
				_attributes.Remove(key);
			}
			else
			{
				_attributes[key] = null;
			}
		}

		public bool TryGetAttribute(string key, out string value)
		{
			if (_attributes != null)
			{
				return _attributes.TryGetValue(key, out value);
			}
			value = null;
			return false;
		}

		public bool HasAttribute(string key)
		{
			if (_attributes != null)
			{
				return _attributes.ContainsKey(key);
			}
			return false;
		}

		public string GetAttributeOrNull(string key, string defaultValue = null)
		{
			string value;
			if (_attributes != null && _attributes.TryGetValue(key, out value))
			{
				return value;
			}
			return defaultValue;
		}

		public T AddChild<T>(T node) where T : TydNode
		{
			_nodes.Add(node);
			node.Parent = this;
			return node;
		}

		public T InsertChild<T>(T node, int id) where T : TydNode
		{
			_nodes.Insert(id, node);
			node.Parent = this;
			return node;
		}

		public T ReplaceChild<T>(T node) where T : TydNode
		{
			node.Parent = this;
			for (int i = 0; i < _nodes.Count; i++)
			{
				TydNode tydNode = _nodes[i];
				if (node.Name.Equals(tydNode.Name))
				{
					_nodes[i] = node;
					return node;
				}
			}
			_nodes.Add(node);
			return node;
		}

		public void AddChildren<T>(params T[] ns) where T : TydNode
		{
			foreach (T val in ns)
			{
				_nodes.Add(val);
				val.Parent = this;
			}
		}

		protected void CopyDataFrom(TydCollection other)
		{
			other.DocIndexEnd = DocIndexEnd;
			Dictionary<string, string> attributes = other._attributes;
			other._attributes = ((attributes != null) ? attributes.ToDictionary((KeyValuePair<string, string> x) => x.Key, (KeyValuePair<string, string> x) => x.Value) : null);
			for (int num = 0; num < _nodes.Count; num++)
			{
				other.AddChild(_nodes[num].DeepClone());
			}
		}
	}
}

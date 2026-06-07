using System.Collections.Generic;
using System.IO;

namespace SimpleJSON
{
	public class JSONNode
	{
		public virtual JSONNode Item
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual JSONNode Item
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual string Value
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual int Count => 0;

		public virtual IEnumerable<JSONNode> Childs => null;

		public IEnumerable<JSONNode> DeepChilds => null;

		public virtual int AsInt
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public virtual float AsFloat
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public virtual double AsDouble
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public virtual bool AsBool
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual JSONArray AsArray => null;

		public virtual JSONClass AsObject => null;

		public virtual void Add(string aKey, JSONNode aItem)
		{
		}

		public virtual void Add(JSONNode aItem)
		{
		}

		public virtual JSONNode Remove(string aKey)
		{
			return null;
		}

		public virtual JSONNode Remove(int aIndex)
		{
			return null;
		}

		public virtual JSONNode Remove(JSONNode aNode)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		public virtual string ToString(string aPrefix)
		{
			return null;
		}

		public static implicit operator JSONNode(string s)
		{
			return null;
		}

		public static implicit operator string(JSONNode d)
		{
			return null;
		}

		public static bool operator ==(JSONNode a, object b)
		{
			return false;
		}

		public static bool operator !=(JSONNode a, object b)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		internal static string Escape(string aText)
		{
			return null;
		}

		public static JSONNode Parse(string aJSON)
		{
			return null;
		}

		public static JSONNode Deserialize(BinaryReader aReader)
		{
			return null;
		}
	}
}

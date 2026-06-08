using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using ThirdParty.RuntimeBackports;

namespace Amazon.Runtime.Documents
{
	public struct Document : IEquatable<Document>, IEnumerable<Document>, IEnumerable, IEnumerable<KeyValuePair<string, Document>>
	{
		private readonly bool _dataBool;

		private readonly double _dataDouble;

		private readonly int _dataInt;

		private readonly long _dataLong;

		private readonly string _dataString;

		private List<Document> _dataList;

		private Dictionary<string, Document> _dataDictionary;

		public DocumentType Type { get; private set; }

		public Document(bool value)
		{
			this = default(Document);
			Type = DocumentType.Bool;
			_dataBool = value;
		}

		public Document(double value)
		{
			this = default(Document);
			Type = DocumentType.Double;
			_dataDouble = value;
		}

		public Document(int value)
		{
			this = default(Document);
			Type = DocumentType.Int;
			_dataInt = value;
		}

		public Document(long value)
		{
			this = default(Document);
			Type = DocumentType.Long;
			_dataLong = value;
		}

		public Document(string value)
		{
			this = default(Document);
			Type = DocumentType.String;
			_dataString = value;
		}

		public Document(List<Document> values)
		{
			this = default(Document);
			Type = DocumentType.List;
			_dataList = values;
		}

		public Document(params Document[] values)
			: this(values.ToList())
		{
		}

		public Document(Dictionary<string, Document> values)
		{
			this = default(Document);
			Type = DocumentType.Dictionary;
			_dataDictionary = values;
		}

		public static implicit operator Document(bool value)
		{
			return new Document(value);
		}

		public static implicit operator Document(double value)
		{
			return new Document(value);
		}

		public static implicit operator Document(int value)
		{
			return new Document(value);
		}

		public static implicit operator Document(long value)
		{
			return new Document(value);
		}

		public static implicit operator Document(string value)
		{
			return new Document(value);
		}

		public static implicit operator Document(Document[] values)
		{
			return new Document(values);
		}

		public static implicit operator Document(Dictionary<string, Document> values)
		{
			return new Document(values);
		}

		public bool IsBool()
		{
			return Type == DocumentType.Bool;
		}

		public bool AsBool()
		{
			AssertIsType(DocumentType.Bool);
			return _dataBool;
		}

		public bool IsDictionary()
		{
			return Type == DocumentType.Dictionary;
		}

		public Dictionary<string, Document> AsDictionary()
		{
			AssertIsType(DocumentType.Dictionary);
			return _dataDictionary;
		}

		public bool IsDouble()
		{
			return Type == DocumentType.Double;
		}

		public double AsDouble()
		{
			AssertIsType(DocumentType.Double);
			return _dataDouble;
		}

		public bool IsInt()
		{
			return Type == DocumentType.Int;
		}

		public int AsInt()
		{
			AssertIsType(DocumentType.Int);
			return _dataInt;
		}

		public bool IsList()
		{
			return Type == DocumentType.List;
		}

		public List<Document> AsList()
		{
			AssertIsType(DocumentType.List);
			return _dataList;
		}

		public bool IsLong()
		{
			return Type == DocumentType.Long;
		}

		public long AsLong()
		{
			AssertIsType(DocumentType.Long);
			return _dataLong;
		}

		public bool IsNull()
		{
			return Type == DocumentType.Null;
		}

		public bool IsString()
		{
			return Type == DocumentType.String;
		}

		public string AsString()
		{
			AssertIsType(DocumentType.String);
			return _dataString;
		}

		private void AssertIsType(DocumentType type)
		{
			if (Type != type)
			{
				throw new InvalidDocumentTypeConversionException(type, Type);
			}
		}

		public bool Equals(Document other)
		{
			if (Type != other.Type)
			{
				return false;
			}
			switch (Type)
			{
			case DocumentType.Null:
				return true;
			case DocumentType.Bool:
				return _dataBool == other.AsBool();
			case DocumentType.Double:
			{
				double dataDouble = _dataDouble;
				return dataDouble.Equals(other.AsDouble());
			}
			case DocumentType.Int:
				return _dataInt == other.AsInt();
			case DocumentType.Long:
				return _dataLong == other.AsLong();
			case DocumentType.String:
				return _dataString.Equals(other.AsString());
			case DocumentType.List:
				return _dataList.Equals(other.AsList());
			case DocumentType.Dictionary:
				return _dataDictionary.Equals(other.AsDictionary());
			default:
				return false;
			}
		}

		public bool Equals(Document? other)
		{
			if (!other.HasValue)
			{
				return false;
			}
			return Equals(other.Value);
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as Document?);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public static bool operator ==(Document left, Document right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Document left, Document right)
		{
			return !left.Equals(right);
		}

		IEnumerator<Document> IEnumerable<Document>.GetEnumerator()
		{
			return AsList().GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			if (Type == DocumentType.List)
			{
				return AsList().GetEnumerator();
			}
			if (Type == DocumentType.Dictionary)
			{
				return AsDictionary().GetEnumerator();
			}
			return new Document[1] { this }.GetEnumerator();
		}

		public void Add(Document document)
		{
			if (Type == DocumentType.Null)
			{
				Type = DocumentType.List;
				_dataList = new List<Document>();
			}
			AssertIsType(DocumentType.List);
			_dataList.Add(document);
		}

		IEnumerator<KeyValuePair<string, Document>> IEnumerable<KeyValuePair<string, Document>>.GetEnumerator()
		{
			return AsDictionary().GetEnumerator();
		}

		public void Add(string key, Document value)
		{
			if (Type == DocumentType.Null)
			{
				_dataDictionary = new Dictionary<string, Document>();
				Type = DocumentType.Dictionary;
			}
			AssertIsType(DocumentType.Dictionary);
			_dataDictionary.Add(key, value);
		}

		public override string ToString()
		{
			switch (Type)
			{
			case DocumentType.Bool:
			{
				bool dataBool = _dataBool;
				return dataBool.ToString();
			}
			case DocumentType.Dictionary:
				return "Document dictionary";
			case DocumentType.Double:
			{
				double dataDouble = _dataDouble;
				return dataDouble.ToString(CultureInfo.CurrentCulture);
			}
			case DocumentType.Int:
			{
				int dataInt = _dataInt;
				return dataInt.ToString();
			}
			case DocumentType.List:
				return "Document list";
			case DocumentType.Long:
			{
				long dataLong = _dataLong;
				return dataLong.ToString();
			}
			case DocumentType.Null:
				return "Document null value";
			case DocumentType.String:
				return _dataString;
			default:
				return base.ToString();
			}
		}

		[RequiresUnreferencedCode("FromObject is not currently supported for Native AOT compilation due unbounded reflection required.")]
		public static Document FromObject(object o)
		{
			using JsonDocument jsonDocument = JsonDocument.Parse(JsonSerializer.Serialize(o));
			return FromObject(jsonDocument.RootElement);
		}

		[RequiresUnreferencedCode("FromObject is not currently supported for Native AOT compilation due unbounded reflection required.")]
		private static Document FromObject(JsonElement jsonElement)
		{
			switch (jsonElement.ValueKind)
			{
			case JsonValueKind.Undefined:
			case JsonValueKind.Null:
				return default(Document);
			case JsonValueKind.True:
			case JsonValueKind.False:
				return new Document(jsonElement.GetBoolean());
			case JsonValueKind.Number:
			{
				if (jsonElement.TryGetInt64(out var value))
				{
					return new Document(value);
				}
				if (jsonElement.TryGetDouble(out var value2))
				{
					return new Document(value2);
				}
				throw new NotSupportedException("Unsupported number format");
			}
			case JsonValueKind.String:
				return new Document(jsonElement.GetString());
			case JsonValueKind.Array:
				return new Document(jsonElement.EnumerateArray().Select(FromObject).ToArray());
			case JsonValueKind.Object:
			{
				Dictionary<string, Document> dictionary = new Dictionary<string, Document>();
				Copy(jsonElement, dictionary);
				return new Document(dictionary);
			}
			default:
				throw new NotSupportedException($"Couldn't convert {jsonElement.ValueKind}");
			}
		}

		[RequiresUnreferencedCode("FromObject is not currently supported for Native AOT compilation due unbounded reflection required.")]
		private static void Copy(JsonElement jsonElement, Dictionary<string, Document> target)
		{
			foreach (JsonProperty item in jsonElement.EnumerateObject())
			{
				target[item.Name] = FromObject(item.Value);
			}
		}
	}
}

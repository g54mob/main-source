using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlMetadata : IXmlKnownType, IXmlIdentity, IXmlKnownTypeMap, IXmlIncludedType, IXmlIncludedTypeMap
	{
		private readonly Type clrType;

		private readonly bool? qualified;

		private readonly bool? isNullable;

		private readonly bool? isReference;

		private readonly string rootLocalName;

		private readonly string rootNamespaceUri;

		private readonly string childNamespaceUri;

		private readonly string typeLocalName;

		private readonly string typeNamespaceUri;

		private readonly HashSet<string> reservedNamespaceUris;

		private List<Type> pendingIncludes;

		private readonly XmlIncludedTypeSet includedTypes;

		private readonly XmlContext context;

		private readonly DictionaryAdapterMeta source;

		private readonly CompiledXPath path;

		protected static readonly StringComparer NameComparer = StringComparer.OrdinalIgnoreCase;

		private const CursorFlags RootFlags = CursorFlags.Elements | CursorFlags.Mutable;

		public Type ClrType => clrType;

		public bool? Qualified => qualified;

		public bool? IsNullable => isNullable;

		public bool? IsReference => isReference;

		public XmlName Name => new XmlName(rootLocalName, rootNamespaceUri);

		public XmlName XsiType => new XmlName(typeLocalName, typeNamespaceUri);

		XmlName IXmlIdentity.XsiType => XmlName.Empty;

		public string ChildNamespaceUri => childNamespaceUri;

		public IEnumerable<string> ReservedNamespaceUris => reservedNamespaceUris.ToArray();

		public XmlIncludedTypeSet IncludedTypes
		{
			get
			{
				ProcessPendingIncludes();
				return includedTypes;
			}
		}

		public IXmlContext Context => context;

		public CompiledXPath Path => path;

		IXmlKnownType IXmlKnownTypeMap.Default => this;

		IXmlIncludedType IXmlIncludedTypeMap.Default => this;

		public XmlMetadata(DictionaryAdapterMeta meta, IEnumerable<string> reservedNamespaceUris)
		{
			if (meta == null)
			{
				throw Error.ArgumentNull("meta");
			}
			if (reservedNamespaceUris == null)
			{
				throw Error.ArgumentNull("reservedNamespaceUris");
			}
			source = meta;
			clrType = meta.Type;
			context = new XmlContext(this);
			includedTypes = new XmlIncludedTypeSet();
			this.reservedNamespaceUris = (reservedNamespaceUris as HashSet<string>) ?? new HashSet<string>(reservedNamespaceUris);
			XmlRootAttribute result = null;
			XmlTypeAttribute result2 = null;
			XmlDefaultsAttribute result3 = null;
			XmlIncludeAttribute result4 = null;
			XmlNamespaceAttribute result5 = null;
			ReferenceAttribute result6 = null;
			XPathAttribute result7 = null;
			XPathVariableAttribute result8 = null;
			XPathFunctionAttribute result9 = null;
			object[] behaviors = meta.Behaviors;
			foreach (object obj in behaviors)
			{
				if (TryCast(obj, ref result) || TryCast(obj, ref result2) || TryCast(obj, ref result3))
				{
					continue;
				}
				if (TryCast(obj, ref result4))
				{
					AddPendingInclude(result4);
				}
				else if (TryCast(obj, ref result5))
				{
					context.AddNamespace(result5);
				}
				else if (!TryCast(obj, ref result6) && !TryCast(obj, ref result7))
				{
					if (TryCast(obj, ref result8))
					{
						context.AddVariable(result8);
					}
					else if (TryCast(obj, ref result9))
					{
						context.AddFunction(result9);
					}
				}
			}
			if (result3 != null)
			{
				qualified = result3.Qualified;
				isNullable = result3.IsNullable;
			}
			if (result6 != null)
			{
				isReference = true;
			}
			typeLocalName = XmlConvert.EncodeLocalName(((!meta.HasXmlType()) ? null : meta.GetXmlType().NonEmpty()) ?? result2?.TypeName.NonEmpty() ?? GetDefaultTypeLocalName(clrType));
			rootLocalName = XmlConvert.EncodeLocalName(result?.ElementName.NonEmpty() ?? typeLocalName);
			typeNamespaceUri = result2?.Namespace;
			rootNamespaceUri = result?.Namespace;
			childNamespaceUri = typeNamespaceUri ?? rootNamespaceUri;
			if (result7 != null)
			{
				path = result7.GetPath;
				path.SetContext(context);
			}
		}

		public bool IsReservedNamespaceUri(string namespaceUri)
		{
			return reservedNamespaceUris.Contains(namespaceUri);
		}

		public IXmlCursor SelectBase(IXmlNode node)
		{
			if (path != null)
			{
				return node.Select(path, this, context, CursorFlags.Elements | CursorFlags.Mutable);
			}
			return node.SelectChildren(this, context, CursorFlags.Elements | CursorFlags.Mutable);
		}

		private bool IsMatch(IXmlIdentity xmlIdentity)
		{
			XmlName name = xmlIdentity.Name;
			if (NameComparer.Equals(rootLocalName, name.LocalName))
			{
				if (rootNamespaceUri != null)
				{
					return NameComparer.Equals(rootNamespaceUri, name.NamespaceUri);
				}
				return true;
			}
			return false;
		}

		private bool IsMatch(Type clrType)
		{
			return clrType == this.clrType;
		}

		public bool TryGet(IXmlIdentity xmlIdentity, out IXmlKnownType knownType)
		{
			if (!IsMatch(xmlIdentity))
			{
				return Try.Failure<IXmlKnownType>(out knownType);
			}
			return Try.Success(out knownType, (IXmlKnownType)this);
		}

		public bool TryGet(Type clrType, out IXmlKnownType knownType)
		{
			if (!IsMatch(clrType))
			{
				return Try.Failure<IXmlKnownType>(out knownType);
			}
			return Try.Success(out knownType, (IXmlKnownType)this);
		}

		public bool TryGet(XmlName xsiType, out IXmlIncludedType includedType)
		{
			if (!(xsiType == XmlName.Empty) && !(xsiType == XsiType))
			{
				return Try.Failure<IXmlIncludedType>(out includedType);
			}
			return Try.Success(out includedType, (IXmlIncludedType)this);
		}

		public bool TryGet(Type clrType, out IXmlIncludedType includedType)
		{
			if (!(clrType == this.clrType))
			{
				return Try.Failure<IXmlIncludedType>(out includedType);
			}
			return Try.Success(out includedType, (IXmlIncludedType)this);
		}

		private void AddPendingInclude(XmlIncludeAttribute attribute)
		{
			if (pendingIncludes == null)
			{
				pendingIncludes = new List<Type>();
			}
			pendingIncludes.Add(attribute.Type);
		}

		private void ProcessPendingIncludes()
		{
			List<Type> list = pendingIncludes;
			pendingIncludes = null;
			if (list == null)
			{
				return;
			}
			foreach (Type item in list)
			{
				XmlIncludedType includedType = new XmlIncludedType(GetDefaultXsiType(item), item);
				includedTypes.Add(includedType);
			}
		}

		public XmlName GetDefaultXsiType(Type clrType)
		{
			if (clrType == this.clrType)
			{
				return XsiType;
			}
			if (includedTypes.TryGet(clrType, out var includedType))
			{
				return includedType.XsiType;
			}
			switch (XmlTypeSerializer.For(clrType).Kind)
			{
			case XmlTypeKind.Complex:
				if (clrType.GetTypeInfo().IsInterface)
				{
					return GetXmlMetadata(clrType).XsiType;
				}
				break;
			case XmlTypeKind.Collection:
			{
				Type collectionItemType = clrType.GetCollectionItemType();
				return new XmlName("ArrayOf" + GetDefaultXsiType(collectionItemType).LocalName, null);
			}
			}
			return new XmlName(clrType.Name, null);
		}

		public IEnumerable<IXmlIncludedType> GetIncludedTypes(Type baseType)
		{
			Queue<XmlMetadata> queue = new Queue<XmlMetadata>();
			HashSet<Type> visited = new HashSet<Type> { baseType };
			if (TryGetXmlMetadata(baseType, out var metadata))
			{
				queue.Enqueue(metadata);
			}
			metadata = this;
			while (true)
			{
				foreach (IXmlIncludedType includedType in metadata.IncludedTypes)
				{
					Type clrType = includedType.ClrType;
					if (baseType != clrType && baseType.IsAssignableFrom(clrType) && visited.Add(clrType))
					{
						yield return includedType;
						if (TryGetXmlMetadata(clrType, out metadata))
						{
							queue.Enqueue(metadata);
						}
					}
				}
				if (queue.Count != 0)
				{
					metadata = queue.Dequeue();
					continue;
				}
				break;
			}
		}

		private bool TryGetXmlMetadata(Type clrType, out XmlMetadata metadata)
		{
			if (XmlTypeSerializer.For(clrType).Kind != XmlTypeKind.Complex || !clrType.GetTypeInfo().IsInterface)
			{
				return Try.Failure<XmlMetadata>(out metadata);
			}
			return Try.Success(out metadata, GetXmlMetadata(clrType));
		}

		private XmlMetadata GetXmlMetadata(Type clrType)
		{
			return source.GetAdapterMeta(clrType).GetXmlMeta();
		}

		private string GetDefaultTypeLocalName(Type clrType)
		{
			string name = clrType.Name;
			if (!IsInterfaceName(name))
			{
				return name;
			}
			return name.Substring(1);
		}

		private static bool IsInterfaceName(string name)
		{
			if (name.Length > 1 && name[0] == 'I')
			{
				return char.IsUpper(name, 1);
			}
			return false;
		}

		private static bool TryCast<T>(object obj, ref T result) where T : class
		{
			if (!(obj is T val))
			{
				return false;
			}
			result = val;
			return true;
		}
	}
}

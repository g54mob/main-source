using System;
using System.Runtime.Serialization;
using System.Xml.XPath;

namespace Castle.Components.DictionaryAdapter.Xml
{
	internal static class Error
	{
		internal static Exception ArgumentNull(string paramName)
		{
			return new ArgumentNullException(paramName);
		}

		internal static Exception ArgumentOutOfRange(string paramName)
		{
			return new ArgumentOutOfRangeException(paramName);
		}

		internal static Exception InvalidOperation()
		{
			return new InvalidOperationException();
		}

		internal static Exception NotSupported()
		{
			return new NotSupportedException();
		}

		internal static Exception ObjectDisposed(string objectName)
		{
			return new ObjectDisposedException(objectName);
		}

		internal static Exception AttributeConflict(string propertyName)
		{
			return new InvalidOperationException($"The behaviors defined for property '{propertyName}' are ambiguous or conflicting.");
		}

		internal static Exception SeparateGetterSetterOnComplexType(string propertyName)
		{
			return new InvalidOperationException($"Cannot apply getter/setter behaviors for property '{propertyName}'.  Separate getters/setters are supported for simple types only.");
		}

		internal static Exception XmlMetadataNotAvailable(Type clrType)
		{
			return new InvalidOperationException($"XML metadata is not available for type '{clrType.FullName}'.");
		}

		internal static Exception NotDictionaryAdapter(string paramName)
		{
			return new ArgumentException("The argument is not a dictionary adapter.", paramName);
		}

		internal static Exception NoInstanceDescriptor(string paramName)
		{
			return new ArgumentException("The dictionary adapter does not have an instance descriptor.", paramName);
		}

		internal static Exception NoXmlAdapter(string paramName)
		{
			return new ArgumentException("The dictionary adapter does not have XmlAdapter behavior.", paramName);
		}

		internal static Exception NotRealizable<T>()
		{
			return new NotSupportedException($"The given node cannot provide an underlying object of type {typeof(T).FullName}.");
		}

		internal static Exception CursorNotMutable()
		{
			return new NotSupportedException("The cursor does not support creation, removal, or modification of nodes.");
		}

		internal static Exception CursorNotInCreatableState()
		{
			return new InvalidOperationException("The cursor cannot create nodes in its current state.");
		}

		internal static Exception CursorNotInRemovableState()
		{
			return new InvalidOperationException("The cursor cannot remove nodes in its current state.");
		}

		internal static Exception CursorNotInCoercibleState()
		{
			return new InvalidOperationException("The cursor cannot change node types in its current state.");
		}

		internal static Exception CursorNotInRealizableState()
		{
			return new InvalidOperationException("The cursor cannot realize virtual nodes in its current state");
		}

		internal static Exception CursorCannotMoveToGivenNode()
		{
			return new InvalidOperationException("The cursor cannot move to the given node.");
		}

		internal static Exception CannotSetAttribute(IXmlIdentity identity)
		{
			return new InvalidOperationException($"Cannot set attribute on node '{identity.Name.ToString()}'.");
		}

		internal static Exception NotXmlKnownType(Type clrType)
		{
			return new SerializationException($"No XML type is defined for CLR type {clrType.FullName}.");
		}

		internal static Exception UnsupportedCollectionType(Type clrType)
		{
			return new SerializationException($"Unsupported collection type: {clrType.FullName}.");
		}

		internal static Exception NotCollectionType(string paramName)
		{
			return new ArgumentException("The argument is not a valid collection type.", paramName);
		}

		internal static Exception InvalidLocalName()
		{
			return new FormatException("Invalid local name.");
		}

		internal static Exception InvalidNamespaceUri()
		{
			return new FormatException("Invalid namespace URI.");
		}

		internal static Exception NoDefaultKnownType()
		{
			return new InvalidOperationException("No default XML type exists in the given context.");
		}

		internal static Exception XPathNotCreatable(CompiledXPath path)
		{
			return new XPathException($"The path '{path.Path.Expression}' is not a creatable XPath expression.");
		}

		internal static Exception XPathNavigationFailed(XPathExpression path)
		{
			return new XPathException($"Failed navigation to {path.Expression} element after creation.");
		}

		internal static Exception ObjectIdNotFound(string id)
		{
			return new SerializationException($"No object with ID '{id}' was present in the XML.");
		}
	}
}

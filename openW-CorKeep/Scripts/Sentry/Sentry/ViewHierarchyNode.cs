using System.Collections.Generic;
using System.Text.Json;
using Sentry.Extensibility;

namespace Sentry
{
	public abstract class ViewHierarchyNode : ISentryJsonSerializable
	{
		private List<ViewHierarchyNode>? _children;

		public string Type { get; set; }

		public List<ViewHierarchyNode> Children
		{
			get
			{
				return _children ?? (_children = new List<ViewHierarchyNode>());
			}
			set
			{
				_children = value;
			}
		}

		protected ViewHierarchyNode(string type)
		{
			Type = type;
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			writer.WriteString("type", Type);
			WriteAdditionalProperties(writer, logger);
			List<ViewHierarchyNode> children = Children;
			if (children != null)
			{
				writer.WriteStartArray("children");
				foreach (ViewHierarchyNode item in children)
				{
					item.WriteTo(writer, logger);
				}
				writer.WriteEndArray();
			}
			writer.WriteEndObject();
		}

		protected abstract void WriteAdditionalProperties(Utf8JsonWriter writer, IDiagnosticLogger? logger);
	}
}

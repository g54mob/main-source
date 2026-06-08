using System;
using System.Collections.Generic;

namespace ProtoBuf.Meta
{
	public sealed class SchemaGenerationOptions
	{
		internal static readonly SchemaGenerationOptions Default = new SchemaGenerationOptions();

		private List<Service> _services;

		private List<Type> _types;

		public ProtoSyntax Syntax { get; set; } = ProtoSyntax.Default;

		public SchemaGenerationFlags Flags { get; set; }

		public string Package { get; set; }

		public List<Service> Services => _services ?? (_services = new List<Service>());

		public List<Type> Types => _types ?? (_types = new List<Type>());

		internal bool HasServices => (_services?.Count ?? 0) != 0;

		internal bool HasTypes => (_types?.Count ?? 0) != 0;

		public string Origin { get; set; }
	}
}

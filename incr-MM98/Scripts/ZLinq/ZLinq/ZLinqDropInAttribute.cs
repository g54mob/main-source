using System;

namespace ZLinq
{
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
	public sealed class ZLinqDropInAttribute : Attribute
	{
		public string GenerateNamespace { get; }

		public DropInGenerateTypes DropInGenerateTypes { get; }

		public bool GenerateAsPublic { get; set; }

		public string? ConditionalCompilationSymbols { get; set; }

		public bool DisableEmitSource { get; set; }

		public ZLinqDropInAttribute(string generateNamespace, DropInGenerateTypes dropInGenerateTypes)
		{
			GenerateNamespace = generateNamespace;
			DropInGenerateTypes = dropInGenerateTypes;
		}
	}
}

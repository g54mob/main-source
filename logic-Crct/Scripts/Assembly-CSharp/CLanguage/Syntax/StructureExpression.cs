using System.Collections.Generic;
using CLanguage.Compiler;
using CLanguage.Types;

namespace CLanguage.Syntax
{
	public class StructureExpression : Expression
	{
		public class Item
		{
			public int Index;

			public string? Field;

			public Expression Expression;

			public Item(string? field, Expression expression)
			{
			}
		}

		public List<Item> Items { get; private set; }

		public override string ToString()
		{
			return null;
		}

		public override CType GetEvaluatedCType(EmitContext ec)
		{
			return null;
		}

		protected override void DoEmit(EmitContext ec)
		{
		}
	}
}

using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Castle.DynamicProxy.Generators.Emitters
{
	internal sealed class CodeBuilder
	{
		private readonly List<LocalReference> locals;

		private readonly List<IStatement> statements;

		private bool isEmpty;

		internal bool IsEmpty => isEmpty;

		public CodeBuilder()
		{
			statements = new List<IStatement>();
			locals = new List<LocalReference>();
			isEmpty = true;
		}

		public CodeBuilder AddStatement(IStatement statement)
		{
			isEmpty = false;
			statements.Add(statement);
			return this;
		}

		public LocalReference DeclareLocal(Type type)
		{
			LocalReference localReference = new LocalReference(type);
			locals.Add(localReference);
			return localReference;
		}

		internal void Generate(ILGenerator il)
		{
			foreach (LocalReference local in locals)
			{
				local.Generate(il);
			}
			foreach (IStatement statement in statements)
			{
				statement.Emit(il);
			}
		}
	}
}

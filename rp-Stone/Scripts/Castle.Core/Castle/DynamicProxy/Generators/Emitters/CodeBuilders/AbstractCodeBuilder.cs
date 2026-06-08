using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Castle.DynamicProxy.Generators.Emitters.CodeBuilders
{
	public abstract class AbstractCodeBuilder
	{
		private readonly ILGenerator generator;

		private readonly List<Reference> ilmarkers;

		private readonly List<Statement> stmts;

		private bool isEmpty;

		public ILGenerator Generator => generator;

		internal bool IsEmpty => isEmpty;

		protected AbstractCodeBuilder(ILGenerator generator)
		{
			this.generator = generator;
			stmts = new List<Statement>();
			ilmarkers = new List<Reference>();
			isEmpty = true;
		}

		public AbstractCodeBuilder AddExpression(Expression expression)
		{
			return AddStatement(new ExpressionStatement(expression));
		}

		public AbstractCodeBuilder AddStatement(Statement stmt)
		{
			SetNonEmpty();
			stmts.Add(stmt);
			return this;
		}

		public LocalReference DeclareLocal(Type type)
		{
			LocalReference localReference = new LocalReference(type);
			ilmarkers.Add(localReference);
			return localReference;
		}

		public void SetNonEmpty()
		{
			isEmpty = false;
		}

		internal void Generate(IMemberEmitter member, ILGenerator il)
		{
			foreach (Reference ilmarker in ilmarkers)
			{
				ilmarker.Generate(il);
			}
			foreach (Statement stmt in stmts)
			{
				stmt.Emit(member, il);
			}
		}
	}
}

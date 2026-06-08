using System;
using System.Linq.Expressions;

namespace HandlebarsDotNet.Compiler
{
	internal class HashParameterAssignmentExpression : HandlebarsExpression
	{
		public string Name { get; set; }

		public override ExpressionType NodeType => (ExpressionType)6010;

		public override Type Type => typeof(object);

		public HashParameterAssignmentExpression(string name)
		{
			Name = name;
		}
	}
}

using System;
using System.Linq.Expressions;
using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.Compiler
{
	internal class PathExpression : HandlebarsExpression
	{
		public enum ResolutionContext
		{
			None = 0,
			Parameter = 1
		}

		public new string Path { get; }

		public ResolutionContext Context { get; set; }

		public override ExpressionType NodeType => (ExpressionType)6004;

		public override Type Type => typeof(PathInfo);

		public PathExpression(string path)
		{
			Path = path;
		}
	}
}

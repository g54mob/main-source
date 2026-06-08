using System.Collections.Generic;
using HandlebarsDotNet.Features;

namespace HandlebarsDotNet
{
	public class CompileTimeConfiguration
	{
		public IList<IExpressionMiddleware> ExpressionMiddleware { get; } = new List<IExpressionMiddleware>();

		public IList<IFeatureFactory> Features { get; } = new List<IFeatureFactory>
		{
			new BuildInHelpersFeatureFactory(),
			new DefaultCompilerFeatureFactory(),
			new MissingHelperFeatureFactory()
		};

		public IExpressionCompiler ExpressionCompiler { get; set; }
	}
}

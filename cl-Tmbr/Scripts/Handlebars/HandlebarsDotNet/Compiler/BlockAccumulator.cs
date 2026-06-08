using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HandlebarsDotNet.Compiler
{
	internal class BlockAccumulator : TokenConverter
	{
		private readonly ICompiledHandlebarsConfiguration _configuration;

		public static IEnumerable<object> Accumulate(IEnumerable<object> tokens, ICompiledHandlebarsConfiguration configuration)
		{
			return new BlockAccumulator(configuration).ConvertTokens(tokens).ToList();
		}

		private BlockAccumulator(ICompiledHandlebarsConfiguration configuration)
		{
			_configuration = configuration;
		}

		public override IEnumerable<object> ConvertTokens(IEnumerable<object> sequence)
		{
			IEnumerator<object> enumerator = sequence.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Expression expression = (Expression)enumerator.Current;
				BlockAccumulatorContext blockAccumulatorContext = BlockAccumulatorContext.Create(expression, null, _configuration);
				if (blockAccumulatorContext != null)
				{
					yield return AccumulateBlock(expression, enumerator, blockAccumulatorContext);
				}
				else
				{
					yield return expression;
				}
			}
		}

		private Expression AccumulateBlock(Expression parentItem, IEnumerator<object> enumerator, BlockAccumulatorContext context)
		{
			while (enumerator.MoveNext())
			{
				Expression expression = (Expression)enumerator.Current;
				BlockAccumulatorContext blockAccumulatorContext = BlockAccumulatorContext.Create(expression, parentItem, _configuration);
				if (blockAccumulatorContext != null)
				{
					context.HandleElement(AccumulateBlock(expression, enumerator, blockAccumulatorContext));
					continue;
				}
				if (context.IsClosingElement(expression))
				{
					return context.GetAccumulatedBlock();
				}
				context.HandleElement(expression);
			}
			throw new HandlebarsCompilerException("Reached end of template before block expression '" + context.BlockName + "' was closed");
		}
	}
}

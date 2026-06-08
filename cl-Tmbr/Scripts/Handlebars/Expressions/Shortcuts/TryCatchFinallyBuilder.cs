using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Expressions.Shortcuts
{
	internal class TryCatchFinallyBuilder : ExpressionContainer
	{
		private readonly List<CatchBlock> _catchBlocks = new List<CatchBlock>();

		private Expression _finallyBody;

		private Expression _body;

		public override Expression Expression
		{
			get
			{
				if (_finallyBody != null)
				{
					if (!_catchBlocks.Any())
					{
						return Expression.TryFinally(_body, _finallyBody);
					}
					return Expression.TryCatchFinally(_body, _finallyBody, _catchBlocks.ToArray());
				}
				if (!_catchBlocks.Any())
				{
					throw new InvalidOperationException("No `catch` block provided");
				}
				return Expression.TryCatch(_body, _catchBlocks.ToArray());
			}
		}

		internal TryCatchFinallyBuilder()
			: base(Expression.Empty())
		{
		}

		public TryCatchFinallyBuilder Body(Action<BlockBuilder> body)
		{
			BlockBuilder blockBuilder = new BlockBuilder(null);
			body(blockBuilder);
			return Body(blockBuilder);
		}

		public TryCatchFinallyBuilder Body(Expression body)
		{
			_body = body;
			return this;
		}

		public TryCatchFinallyBuilder Catch<T>(Action<ExpressionContainer<T>, BlockBuilder> @catch) where T : Exception
		{
			ExpressionContainer<T> expressionContainer = ExpressionShortcuts.Var<T>();
			BlockBuilder blockBuilder = ExpressionShortcuts.Block();
			@catch(expressionContainer, blockBuilder);
			CatchBlock catchBlock = Expression.Catch((ParameterExpression)(Expression)expressionContainer, blockBuilder);
			return Catch(catchBlock);
		}

		public TryCatchFinallyBuilder Catch<T>(Func<ExpressionContainer<T>, Expression> @catch) where T : Exception
		{
			ExpressionContainer<T> expressionContainer = ExpressionShortcuts.Var<T>();
			Expression body = @catch(expressionContainer);
			CatchBlock catchBlock = Expression.Catch((ParameterExpression)(Expression)expressionContainer, body);
			return Catch(catchBlock);
		}

		public TryCatchFinallyBuilder Catch(CatchBlock @catch)
		{
			_catchBlocks.Add(@catch);
			return this;
		}

		public TryCatchFinallyBuilder Finally(Action<BlockBuilder> @finally)
		{
			BlockBuilder blockBuilder = ExpressionShortcuts.Block();
			@finally(blockBuilder);
			return Finally(blockBuilder);
		}

		public TryCatchFinallyBuilder Finally(Expression @finally)
		{
			_finallyBody = @finally;
			return this;
		}

		public TryCatchFinallyBuilder Catch<T>(Action<ExpressionContainer<T>, BlockBuilder> @catch, Func<ExpressionContainer<T>, ExpressionContainer<bool>> when) where T : Exception
		{
			ExpressionContainer<T> expressionContainer = ExpressionShortcuts.Var<T>();
			BlockBuilder blockBuilder = ExpressionShortcuts.Block();
			@catch(expressionContainer, blockBuilder);
			ExpressionContainer<bool> expressionContainer2 = when?.Invoke(expressionContainer);
			CatchBlock catchBlock = ((expressionContainer2 == null) ? Expression.Catch((ParameterExpression)(Expression)expressionContainer, blockBuilder) : Expression.Catch((ParameterExpression)(Expression)expressionContainer, blockBuilder, expressionContainer2));
			return Catch(catchBlock);
		}

		public TryCatchFinallyBuilder Catch<T>(Func<ExpressionContainer<T>, Expression> @catch, Func<ExpressionContainer<T>, ExpressionContainer<bool>> when) where T : Exception
		{
			ExpressionContainer<T> expressionContainer = ExpressionShortcuts.Var<T>();
			Expression body = @catch(expressionContainer);
			ExpressionContainer<bool> expressionContainer2 = when?.Invoke(expressionContainer);
			CatchBlock catchBlock = ((expressionContainer2 == null) ? Expression.Catch((ParameterExpression)(Expression)expressionContainer, body) : Expression.Catch((ParameterExpression)(Expression)expressionContainer, body, expressionContainer2));
			return Catch(catchBlock);
		}
	}
}

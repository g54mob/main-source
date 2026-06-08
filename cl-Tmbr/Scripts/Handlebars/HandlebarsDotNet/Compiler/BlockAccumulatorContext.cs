using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using HandlebarsDotNet.PathStructure;
using HandlebarsDotNet.StringUtils;

namespace HandlebarsDotNet.Compiler
{
	internal abstract class BlockAccumulatorContext
	{
		private static readonly HashSet<string> ConditionHelpers = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "#if", "#unless", "^if", "^unless" };

		private static readonly HashSet<string> IteratorHelpers = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "#each", "^each" };

		public abstract string BlockName { get; protected set; }

		public static BlockAccumulatorContext Create(Expression item, Expression parentItem, ICompiledHandlebarsConfiguration configuration)
		{
			BlockAccumulatorContext result = null;
			string closingElement;
			if (IsConditionalBlock(item))
			{
				result = new ConditionalBlockAccumulatorContext(item);
			}
			else if (IsPartialBlock(item))
			{
				result = new PartialBlockAccumulatorContext(item);
			}
			else if (IsIteratorBlock(item))
			{
				result = new IteratorBlockAccumulatorContext(item);
			}
			else if (IsBlockHelper(item, configuration))
			{
				result = new BlockHelperAccumulatorContext(item);
			}
			else if (IsDetachedClosingElement(item, parentItem, out closingElement))
			{
				throw new HandlebarsCompilerException("A closing element '" + closingElement + "' was found without a matching open element");
			}
			return result;
		}

		private static bool IsConditionalBlock(Expression item)
		{
			item = UnwrapStatement(item);
			if (item is HelperExpression helperExpression)
			{
				return ConditionHelpers.Contains(helperExpression.HelperName);
			}
			return false;
		}

		private static bool IsBlockHelper(Expression item, ICompiledHandlebarsConfiguration configuration)
		{
			item = UnwrapStatement(item);
			if (item is HelperExpression helperExpression)
			{
				PathInfo pathInfo = PathInfo.Parse(helperExpression.HelperName);
				if (!helperExpression.IsBlock)
				{
					if (!configuration.Helpers.ContainsKey((PathInfoLight)pathInfo))
					{
						if (!configuration.BlockHelpers.ContainsKey((PathInfoLight)pathInfo))
						{
							return configuration.BlockDecorators.ContainsKey((PathInfoLight)pathInfo);
						}
						return true;
					}
					return false;
				}
				return true;
			}
			return false;
		}

		private static bool IsIteratorBlock(Expression item)
		{
			item = UnwrapStatement(item);
			if (item is HelperExpression helperExpression)
			{
				return IteratorHelpers.Contains(helperExpression.HelperName);
			}
			return false;
		}

		private static bool IsPartialBlock(Expression item)
		{
			item = UnwrapStatement(item);
			if (!(item is PathExpression pathExpression))
			{
				if (item is HelperExpression helperExpression)
				{
					return helperExpression.HelperName.StartsWith("#>");
				}
				return false;
			}
			return pathExpression.Path.StartsWith("#>");
		}

		private static bool IsDetachedClosingElement(Expression item, Expression parentItem, out string closingElement)
		{
			closingElement = null;
			string itemElement = GetItemElement(item);
			if (itemElement == null)
			{
				return false;
			}
			string itemElement2 = GetItemElement(parentItem);
			if (!itemElement.StartsWith("/"))
			{
				return false;
			}
			if (itemElement2 == null || IsClosingElementNotMatchOpenElement(itemElement, itemElement2))
			{
				closingElement = itemElement;
				return true;
			}
			return false;
		}

		private static bool IsClosingElementNotMatchOpenElement(string closingElement, string openElement)
		{
			if (closingElement == null)
			{
				throw new ArgumentNullException("closingElement");
			}
			if (openElement == null)
			{
				throw new ArgumentNullException("openElement");
			}
			if (!openElement.StartsWith("#") || openElement.StartsWith("#>") || openElement.StartsWith("#*"))
			{
				return false;
			}
			return new Substring(openElement, 1) != new Substring(closingElement, 1);
		}

		private static string GetItemElement(Expression item)
		{
			item = UnwrapStatement(item);
			if (!(item is PathExpression { Path: var path }))
			{
				if (!(item is HelperExpression { HelperName: var helperName }))
				{
					return null;
				}
				return helperName;
			}
			return path;
		}

		protected static Expression UnwrapStatement(Expression item)
		{
			if (item is StatementExpression statementExpression)
			{
				return statementExpression.Body;
			}
			return item;
		}

		protected BlockAccumulatorContext(Expression startingNode)
		{
		}

		public abstract void HandleElement(Expression item);

		public abstract bool IsClosingElement(Expression item);

		public abstract Expression GetAccumulatedBlock();
	}
}

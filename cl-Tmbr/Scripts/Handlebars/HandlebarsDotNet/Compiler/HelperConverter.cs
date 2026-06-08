using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HandlebarsDotNet.Compiler.Lexer;
using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.Compiler
{
	internal class HelperConverter : TokenConverter
	{
		private static readonly HashSet<string> BuiltInHelpers = new HashSet<string> { "else", "each" };

		private readonly ICompiledHandlebarsConfiguration _configuration;

		public static IEnumerable<object> Convert(IEnumerable<object> sequence, ICompiledHandlebarsConfiguration configuration)
		{
			return new HelperConverter(configuration).ConvertTokens(sequence).ToList();
		}

		private HelperConverter(ICompiledHandlebarsConfiguration configuration)
		{
			_configuration = configuration;
		}

		public override IEnumerable<object> ConvertTokens(IEnumerable<object> sequence)
		{
			IEnumerator<object> enumerator = sequence.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				if (!(current is StartExpressionToken { IsRaw: var isRaw } startExpressionToken))
				{
					yield return current;
					continue;
				}
				yield return startExpressionToken;
				current = GetNext(enumerator);
				object obj = current;
				if (!(obj is Expression))
				{
					if (obj is WordExpressionToken wordExpressionToken)
					{
						if (IsRegisteredHelperName(wordExpressionToken.Value))
						{
							yield return HandlebarsExpression.Helper(wordExpressionToken.Value, isBlock: false, isRaw, wordExpressionToken.Context);
							continue;
						}
						WordExpressionToken wordExpressionToken2 = wordExpressionToken;
						if (IsRegisteredBlockHelperName(wordExpressionToken2.Value, isRaw))
						{
							yield return HandlebarsExpression.Helper(wordExpressionToken2.Value, isBlock: true, isRaw, wordExpressionToken2.Context);
							continue;
						}
						WordExpressionToken wordExpressionToken3 = wordExpressionToken;
						if (IsUnregisteredBlockHelperName(wordExpressionToken3.Value, isRaw, sequence))
						{
							HelperExpression helperExpression = HandlebarsExpression.Helper(wordExpressionToken3.Value, isBlock: true, isRaw, wordExpressionToken3.Context);
							helperExpression.IsBlock = true;
							yield return helperExpression;
							continue;
						}
					}
					yield return current;
				}
				else
				{
					yield return current;
				}
			}
		}

		private bool IsRegisteredHelperName(string name)
		{
			PathInfo pathInfo = PathInfo.Parse(name);
			if (!pathInfo.IsValidHelperLiteral && !_configuration.Compatibility.RelaxedHelperNaming)
			{
				return false;
			}
			if (pathInfo.IsBlockHelper || pathInfo.IsInversion || pathInfo.IsBlockClose || pathInfo.IsThis)
			{
				return false;
			}
			name = pathInfo.TrimmedPath;
			if (!_configuration.Helpers.ContainsKey((PathInfoLight)pathInfo) && !_configuration.Decorators.ContainsKey((PathInfoLight)pathInfo))
			{
				return BuiltInHelpers.Contains(name);
			}
			return true;
		}

		private bool IsRegisteredBlockHelperName(string name, bool isRaw)
		{
			PathInfo pathInfo = PathInfo.Parse(name);
			if (!pathInfo.IsValidHelperLiteral && !_configuration.Compatibility.RelaxedHelperNaming)
			{
				return false;
			}
			if (!isRaw && !pathInfo.IsBlockHelper && !pathInfo.IsInversion)
			{
				return false;
			}
			if (pathInfo.IsBlockClose)
			{
				return false;
			}
			if (pathInfo.IsThis)
			{
				return false;
			}
			name = pathInfo.TrimmedPath;
			if (!_configuration.BlockHelpers.ContainsKey((PathInfoLight)pathInfo) && !_configuration.BlockDecorators.ContainsKey((PathInfoLight)pathInfo))
			{
				return BuiltInHelpers.Contains(name);
			}
			return true;
		}

		private bool IsUnregisteredBlockHelperName(string name, bool isRaw, IEnumerable<object> sequence)
		{
			PathInfo pathInfo = PathInfo.Parse(name);
			if (!pathInfo.IsValidHelperLiteral && !_configuration.Compatibility.RelaxedHelperNaming)
			{
				return false;
			}
			if (!isRaw && !pathInfo.IsBlockHelper && !pathInfo.IsInversion)
			{
				return false;
			}
			name = name.Substring(1);
			if (name.StartsWith("*"))
			{
				name = name.Substring(1);
			}
			string expectedBlockName = "/" + name;
			return sequence.OfType<WordExpressionToken>().Any((WordExpressionToken o) => string.Equals(o.Value, expectedBlockName, StringComparison.OrdinalIgnoreCase));
		}

		private static object GetNext(IEnumerator<object> enumerator)
		{
			enumerator.MoveNext();
			return enumerator.Current;
		}
	}
}

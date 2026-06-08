using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace Stonescript.Compiler
{
	public class ParseTree
	{
		public Script script;

		public ParserRuleContext root;

		protected Dictionary<IParseTree, object> constants = new Dictionary<IParseTree, object>();

		public string CachedConstantsString
		{
			get
			{
				string text = "";
				foreach (KeyValuePair<IParseTree, object> constant in constants)
				{
					text += $"{constant.Key.GetText()} = {constant.Value}\n";
				}
				return text;
			}
		}

		public ParseTree(Script script, ParserRuleContext root)
		{
			this.script = script;
			this.root = root;
		}

		public void CacheConstant(IParseTree node, object value)
		{
			constants[node] = value;
		}

		public bool IsCached(IParseTree node)
		{
			return constants.ContainsKey(node);
		}

		public bool TryGetConstant(IParseTree node, out object value)
		{
			if (constants.ContainsKey(node))
			{
				value = constants[node];
				return true;
			}
			value = null;
			return false;
		}
	}
}

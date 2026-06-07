using System;
using Assets.Scripts.Lua;
using Jundroo.Common.Utils;
using MoonSharp.Interpreter;

namespace Assets.Scripts.Craft.Parts.Modifiers.Mfd
{
	public class LuaExpressionSource : IDynamicExpressionSource
	{
		private LuaScript _script;

		public LuaExpressionSource(LuaScript script)
		{
			_script = script;
		}

		public Func<float> GetFloatExpression(string expression)
		{
			return delegate
			{
				DynValue dynValue = _script.RunScript("return " + expression);
				return (dynValue != null && dynValue.Type == DataType.Number) ? ((float)dynValue.Number) : 0f;
			};
		}

		public Func<string> GetStringExpression(string expression)
		{
			return () => _script.RunScript("return " + expression).ToString();
		}
	}
}

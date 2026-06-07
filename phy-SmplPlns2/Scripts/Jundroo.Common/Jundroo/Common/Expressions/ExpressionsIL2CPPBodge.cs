using System;
using Jundroo.Common.Expressions.Tokens;

namespace Jundroo.Common.Expressions
{
	internal static class ExpressionsIL2CPPBodge
	{
		public static ConstantToken<bool> ConstantToken_bool;

		public static ConstantToken<float> ConstantToken_number;

		public static ConstantToken<string> ConstantToken_string;

		public static Func<bool> Func_bool;

		public static Func<float> Func_number;

		public static Func<string> Func_string;

		public static InvocationToken<bool> InvocationToken_bool;

		public static InvocationToken<float> InvocationToken_number;

		public static InvocationToken<string> InvocationToken_string;

		public static TernaryOperationToken<bool> TernaryOperationToken_bool;

		public static TernaryOperationToken<float> TernaryOperationToken_number;

		public static TernaryOperationToken<string> TernaryOperationToken_string;

		public static Token<bool> Token_bool;

		public static Token<float> Token_number;

		public static Token<string> Token_string;

		public static PropertyToken<bool> VariableToken_bool;

		public static PropertyToken<float> VariableToken_number;

		public static PropertyToken<string> VariableToken_string;

		public static void CallGenerics()
		{
			InvocationToken.WrapFunc0<float>(null, null);
			InvocationToken.WrapFunc0<bool>(null, null);
			InvocationToken.WrapFunc0<string>(null, null);
			InvocationToken.WrapFunc1<float, float>(null, null, null);
			InvocationToken.WrapFunc1<float, bool>(null, null, null);
			InvocationToken.WrapFunc1<float, string>(null, null, null);
			InvocationToken.WrapFunc1<bool, float>(null, null, null);
			InvocationToken.WrapFunc1<bool, bool>(null, null, null);
			InvocationToken.WrapFunc1<bool, string>(null, null, null);
			InvocationToken.WrapFunc1<string, float>(null, null, null);
			InvocationToken.WrapFunc1<string, bool>(null, null, null);
			InvocationToken.WrapFunc1<string, string>(null, null, null);
			InvocationToken.WrapFunc2<float, float, float>(null, null, null, null);
			InvocationToken.WrapFunc2<float, float, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<float, float, string>(null, null, null, null);
			InvocationToken.WrapFunc2<float, bool, float>(null, null, null, null);
			InvocationToken.WrapFunc2<float, bool, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<float, bool, string>(null, null, null, null);
			InvocationToken.WrapFunc2<float, string, float>(null, null, null, null);
			InvocationToken.WrapFunc2<float, string, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<float, string, string>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, float, float>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, float, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, float, string>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, bool, float>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, bool, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, bool, string>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, string, float>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, string, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, string, string>(null, null, null, null);
			InvocationToken.WrapFunc2<string, float, float>(null, null, null, null);
			InvocationToken.WrapFunc2<string, float, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<string, float, string>(null, null, null, null);
			InvocationToken.WrapFunc2<string, bool, float>(null, null, null, null);
			InvocationToken.WrapFunc2<string, bool, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<string, bool, string>(null, null, null, null);
			InvocationToken.WrapFunc2<string, string, float>(null, null, null, null);
			InvocationToken.WrapFunc2<string, string, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<string, string, string>(null, null, null, null);
			InvocationToken.WrapFunc3<float, float, float, float>(null, null, null, null, null);
			InvocationToken.WrapFunc5<float, float, float, float, float, float>(null, null, null, null, null, null, null);
		}
	}
}

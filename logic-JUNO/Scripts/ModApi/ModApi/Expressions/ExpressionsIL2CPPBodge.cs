using System;
using ModApi.Expressions.Tokens;
using UnityEngine;
using UnityEngine.Scripting;

namespace ModApi.Expressions
{
	[Preserve]
	internal static class ExpressionsIL2CPPBodge
	{
		public static Func<string> Func_string;

		public static Func<double> Func_double;

		public static Func<bool> Func_bool;

		public static Func<float> Func_float;

		public static Func<int> Func_int;

		public static Func<Vector3d> Func_vector3d;

		public static ConstantToken<string> ConstantToken_string;

		public static ConstantToken<double> ConstantToken_double;

		public static ConstantToken<bool> ConstantToken_bool;

		public static ConstantToken<float> ConstantToken_float;

		public static ConstantToken<int> ConstantToken_int;

		public static ConstantToken<Vector3d> ConstantToken_vector3d;

		public static InvocationToken<string> InvocationToken_string;

		public static InvocationToken<double> InvocationToken_double;

		public static InvocationToken<bool> InvocationToken_bool;

		public static InvocationToken<float> InvocationToken_float;

		public static InvocationToken<int> InvocationToken_int;

		public static InvocationToken<Vector3d> InvocationToken_vector3d;

		public static TernaryOperationToken<string> TernaryOperationToken_string;

		public static TernaryOperationToken<double> TernaryOperationToken_double;

		public static TernaryOperationToken<bool> TernaryOperationToken_bool;

		public static TernaryOperationToken<float> TernaryOperationToken_float;

		public static TernaryOperationToken<int> TernaryOperationToken_int;

		public static TernaryOperationToken<Vector3d> TernaryOperationToken_vector3d;

		public static VariableToken<string> VariableToken_string;

		public static VariableToken<double> VariableToken_double;

		public static VariableToken<bool> VariableToken_bool;

		public static VariableToken<float> VariableToken_float;

		public static VariableToken<int> VariableToken_int;

		public static VariableToken<Vector3d> VariableToken_vector3d;

		public static Token<string> Token_string;

		public static Token<double> Token_double;

		public static Token<bool> Token_bool;

		public static Token<float> Token_float;

		public static Token<int> Token_int;

		public static Token<Vector3d> Token_vector3d;

		[Preserve]
		public static void CallGenerics()
		{
			InvocationToken.WrapFunc0<double>(null, null);
			InvocationToken.WrapFunc0<float>(null, null);
			InvocationToken.WrapFunc0<bool>(null, null);
			InvocationToken.WrapFunc0<string>(null, null);
			InvocationToken.WrapFunc0<int>(null, null);
			InvocationToken.WrapFunc0<Vector3d>(null, null);
			InvocationToken.WrapFunc1<double, double>(null, null, null);
			InvocationToken.WrapFunc1<double, float>(null, null, null);
			InvocationToken.WrapFunc1<double, bool>(null, null, null);
			InvocationToken.WrapFunc1<double, string>(null, null, null);
			InvocationToken.WrapFunc1<double, int>(null, null, null);
			InvocationToken.WrapFunc1<double, Vector3d>(null, null, null);
			InvocationToken.WrapFunc1<float, double>(null, null, null);
			InvocationToken.WrapFunc1<float, float>(null, null, null);
			InvocationToken.WrapFunc1<float, bool>(null, null, null);
			InvocationToken.WrapFunc1<float, string>(null, null, null);
			InvocationToken.WrapFunc1<float, int>(null, null, null);
			InvocationToken.WrapFunc1<float, Vector3d>(null, null, null);
			InvocationToken.WrapFunc1<bool, double>(null, null, null);
			InvocationToken.WrapFunc1<bool, float>(null, null, null);
			InvocationToken.WrapFunc1<bool, bool>(null, null, null);
			InvocationToken.WrapFunc1<bool, string>(null, null, null);
			InvocationToken.WrapFunc1<bool, int>(null, null, null);
			InvocationToken.WrapFunc1<bool, Vector3d>(null, null, null);
			InvocationToken.WrapFunc1<string, double>(null, null, null);
			InvocationToken.WrapFunc1<string, float>(null, null, null);
			InvocationToken.WrapFunc1<string, bool>(null, null, null);
			InvocationToken.WrapFunc1<string, string>(null, null, null);
			InvocationToken.WrapFunc1<string, int>(null, null, null);
			InvocationToken.WrapFunc1<string, Vector3d>(null, null, null);
			InvocationToken.WrapFunc1<int, double>(null, null, null);
			InvocationToken.WrapFunc1<int, float>(null, null, null);
			InvocationToken.WrapFunc1<int, bool>(null, null, null);
			InvocationToken.WrapFunc1<int, string>(null, null, null);
			InvocationToken.WrapFunc1<int, int>(null, null, null);
			InvocationToken.WrapFunc1<int, Vector3d>(null, null, null);
			InvocationToken.WrapFunc1<Vector3d, double>(null, null, null);
			InvocationToken.WrapFunc1<Vector3d, float>(null, null, null);
			InvocationToken.WrapFunc1<Vector3d, bool>(null, null, null);
			InvocationToken.WrapFunc1<Vector3d, string>(null, null, null);
			InvocationToken.WrapFunc1<Vector3d, int>(null, null, null);
			InvocationToken.WrapFunc1<Vector3d, Vector3d>(null, null, null);
			InvocationToken.WrapFunc2<double, double, double>(null, null, null, null);
			InvocationToken.WrapFunc2<double, double, float>(null, null, null, null);
			InvocationToken.WrapFunc2<double, double, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<double, double, string>(null, null, null, null);
			InvocationToken.WrapFunc2<double, double, int>(null, null, null, null);
			InvocationToken.WrapFunc2<double, double, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<double, float, double>(null, null, null, null);
			InvocationToken.WrapFunc2<double, float, float>(null, null, null, null);
			InvocationToken.WrapFunc2<double, float, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<double, float, string>(null, null, null, null);
			InvocationToken.WrapFunc2<double, float, int>(null, null, null, null);
			InvocationToken.WrapFunc2<double, float, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<double, bool, double>(null, null, null, null);
			InvocationToken.WrapFunc2<double, bool, float>(null, null, null, null);
			InvocationToken.WrapFunc2<double, bool, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<double, bool, string>(null, null, null, null);
			InvocationToken.WrapFunc2<double, bool, int>(null, null, null, null);
			InvocationToken.WrapFunc2<double, bool, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<double, string, double>(null, null, null, null);
			InvocationToken.WrapFunc2<double, string, float>(null, null, null, null);
			InvocationToken.WrapFunc2<double, string, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<double, string, string>(null, null, null, null);
			InvocationToken.WrapFunc2<double, string, int>(null, null, null, null);
			InvocationToken.WrapFunc2<double, string, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<double, int, double>(null, null, null, null);
			InvocationToken.WrapFunc2<double, int, float>(null, null, null, null);
			InvocationToken.WrapFunc2<double, int, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<double, int, string>(null, null, null, null);
			InvocationToken.WrapFunc2<double, int, int>(null, null, null, null);
			InvocationToken.WrapFunc2<double, int, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<double, Vector3d, double>(null, null, null, null);
			InvocationToken.WrapFunc2<double, Vector3d, float>(null, null, null, null);
			InvocationToken.WrapFunc2<double, Vector3d, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<double, Vector3d, string>(null, null, null, null);
			InvocationToken.WrapFunc2<double, Vector3d, int>(null, null, null, null);
			InvocationToken.WrapFunc2<double, Vector3d, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<float, double, double>(null, null, null, null);
			InvocationToken.WrapFunc2<float, double, float>(null, null, null, null);
			InvocationToken.WrapFunc2<float, double, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<float, double, string>(null, null, null, null);
			InvocationToken.WrapFunc2<float, double, int>(null, null, null, null);
			InvocationToken.WrapFunc2<float, double, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<float, float, double>(null, null, null, null);
			InvocationToken.WrapFunc2<float, float, float>(null, null, null, null);
			InvocationToken.WrapFunc2<float, float, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<float, float, string>(null, null, null, null);
			InvocationToken.WrapFunc2<float, float, int>(null, null, null, null);
			InvocationToken.WrapFunc2<float, float, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<float, bool, double>(null, null, null, null);
			InvocationToken.WrapFunc2<float, bool, float>(null, null, null, null);
			InvocationToken.WrapFunc2<float, bool, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<float, bool, string>(null, null, null, null);
			InvocationToken.WrapFunc2<float, bool, int>(null, null, null, null);
			InvocationToken.WrapFunc2<float, bool, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<float, string, double>(null, null, null, null);
			InvocationToken.WrapFunc2<float, string, float>(null, null, null, null);
			InvocationToken.WrapFunc2<float, string, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<float, string, string>(null, null, null, null);
			InvocationToken.WrapFunc2<float, string, int>(null, null, null, null);
			InvocationToken.WrapFunc2<float, string, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<float, int, double>(null, null, null, null);
			InvocationToken.WrapFunc2<float, int, float>(null, null, null, null);
			InvocationToken.WrapFunc2<float, int, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<float, int, string>(null, null, null, null);
			InvocationToken.WrapFunc2<float, int, int>(null, null, null, null);
			InvocationToken.WrapFunc2<float, int, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<float, Vector3d, double>(null, null, null, null);
			InvocationToken.WrapFunc2<float, Vector3d, float>(null, null, null, null);
			InvocationToken.WrapFunc2<float, Vector3d, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<float, Vector3d, string>(null, null, null, null);
			InvocationToken.WrapFunc2<float, Vector3d, int>(null, null, null, null);
			InvocationToken.WrapFunc2<float, Vector3d, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, double, double>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, double, float>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, double, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, double, string>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, double, int>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, double, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, float, double>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, float, float>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, float, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, float, string>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, float, int>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, float, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, bool, double>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, bool, float>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, bool, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, bool, string>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, bool, int>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, bool, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, string, double>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, string, float>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, string, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, string, string>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, string, int>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, string, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, int, double>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, int, float>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, int, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, int, string>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, int, int>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, int, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, Vector3d, double>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, Vector3d, float>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, Vector3d, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, Vector3d, string>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, Vector3d, int>(null, null, null, null);
			InvocationToken.WrapFunc2<bool, Vector3d, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<string, double, double>(null, null, null, null);
			InvocationToken.WrapFunc2<string, double, float>(null, null, null, null);
			InvocationToken.WrapFunc2<string, double, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<string, double, string>(null, null, null, null);
			InvocationToken.WrapFunc2<string, double, int>(null, null, null, null);
			InvocationToken.WrapFunc2<string, double, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<string, float, double>(null, null, null, null);
			InvocationToken.WrapFunc2<string, float, float>(null, null, null, null);
			InvocationToken.WrapFunc2<string, float, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<string, float, string>(null, null, null, null);
			InvocationToken.WrapFunc2<string, float, int>(null, null, null, null);
			InvocationToken.WrapFunc2<string, float, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<string, bool, double>(null, null, null, null);
			InvocationToken.WrapFunc2<string, bool, float>(null, null, null, null);
			InvocationToken.WrapFunc2<string, bool, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<string, bool, string>(null, null, null, null);
			InvocationToken.WrapFunc2<string, bool, int>(null, null, null, null);
			InvocationToken.WrapFunc2<string, bool, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<string, string, double>(null, null, null, null);
			InvocationToken.WrapFunc2<string, string, float>(null, null, null, null);
			InvocationToken.WrapFunc2<string, string, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<string, string, string>(null, null, null, null);
			InvocationToken.WrapFunc2<string, string, int>(null, null, null, null);
			InvocationToken.WrapFunc2<string, string, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<string, int, double>(null, null, null, null);
			InvocationToken.WrapFunc2<string, int, float>(null, null, null, null);
			InvocationToken.WrapFunc2<string, int, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<string, int, string>(null, null, null, null);
			InvocationToken.WrapFunc2<string, int, int>(null, null, null, null);
			InvocationToken.WrapFunc2<string, int, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<string, Vector3d, double>(null, null, null, null);
			InvocationToken.WrapFunc2<string, Vector3d, float>(null, null, null, null);
			InvocationToken.WrapFunc2<string, Vector3d, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<string, Vector3d, string>(null, null, null, null);
			InvocationToken.WrapFunc2<string, Vector3d, int>(null, null, null, null);
			InvocationToken.WrapFunc2<string, Vector3d, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<int, double, double>(null, null, null, null);
			InvocationToken.WrapFunc2<int, double, float>(null, null, null, null);
			InvocationToken.WrapFunc2<int, double, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<int, double, string>(null, null, null, null);
			InvocationToken.WrapFunc2<int, double, int>(null, null, null, null);
			InvocationToken.WrapFunc2<int, double, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<int, float, double>(null, null, null, null);
			InvocationToken.WrapFunc2<int, float, float>(null, null, null, null);
			InvocationToken.WrapFunc2<int, float, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<int, float, string>(null, null, null, null);
			InvocationToken.WrapFunc2<int, float, int>(null, null, null, null);
			InvocationToken.WrapFunc2<int, float, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<int, bool, double>(null, null, null, null);
			InvocationToken.WrapFunc2<int, bool, float>(null, null, null, null);
			InvocationToken.WrapFunc2<int, bool, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<int, bool, string>(null, null, null, null);
			InvocationToken.WrapFunc2<int, bool, int>(null, null, null, null);
			InvocationToken.WrapFunc2<int, bool, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<int, string, double>(null, null, null, null);
			InvocationToken.WrapFunc2<int, string, float>(null, null, null, null);
			InvocationToken.WrapFunc2<int, string, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<int, string, string>(null, null, null, null);
			InvocationToken.WrapFunc2<int, string, int>(null, null, null, null);
			InvocationToken.WrapFunc2<int, string, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<int, int, double>(null, null, null, null);
			InvocationToken.WrapFunc2<int, int, float>(null, null, null, null);
			InvocationToken.WrapFunc2<int, int, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<int, int, string>(null, null, null, null);
			InvocationToken.WrapFunc2<int, int, int>(null, null, null, null);
			InvocationToken.WrapFunc2<int, int, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<int, Vector3d, double>(null, null, null, null);
			InvocationToken.WrapFunc2<int, Vector3d, float>(null, null, null, null);
			InvocationToken.WrapFunc2<int, Vector3d, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<int, Vector3d, string>(null, null, null, null);
			InvocationToken.WrapFunc2<int, Vector3d, int>(null, null, null, null);
			InvocationToken.WrapFunc2<int, Vector3d, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, double, double>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, double, float>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, double, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, double, string>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, double, int>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, double, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, float, double>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, float, float>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, float, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, float, string>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, float, int>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, float, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, bool, double>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, bool, float>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, bool, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, bool, string>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, bool, int>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, bool, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, string, double>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, string, float>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, string, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, string, string>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, string, int>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, string, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, int, double>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, int, float>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, int, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, int, string>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, int, int>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, int, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, Vector3d, double>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, Vector3d, float>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, Vector3d, bool>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, Vector3d, string>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, Vector3d, int>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, Vector3d, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc3<double, double, double, double>(null, null, null, null, null);
			InvocationToken.WrapFunc5<double, double, double, double, double, double>(null, null, null, null, null, null, null);
			InvocationToken.WrapFunc1<double, Vector3d>(null, null, null);
			InvocationToken.WrapFunc1<bool, Vector3d>(null, null, null);
			InvocationToken.WrapFunc1<Vector3d, Vector3d>(null, null, null);
			InvocationToken.WrapFunc2<Vector3d, Vector3d, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<double, Vector3d, Vector3d>(null, null, null, null);
			InvocationToken.WrapFunc2<Vector3d, Vector3d, double>(null, null, null, null);
			InvocationToken.WrapFunc3<double, Vector3d, Vector3d, Vector3d>(null, null, null, null, null);
			InvocationToken.WrapFunc0<Vector3d>(null, null);
			InvocationToken.WrapFunc3<Vector3d, Vector3d, Vector3d, double>(null, null, null, null, null);
			InvocationToken.WrapFunc3<Vector3d, double, double, double>(null, null, null, null, null);
		}
	}
}

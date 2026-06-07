
// add - test cases for docstring handling
using System.Collections.Generic;
using UnityEngine;

namespace GptDeepResearch.Check
{
	public static class TestDocstrings
	{
		// Test 1: Original sample (should parse & run)
		public static string Test1 = @"def func():
'''
    with tab line
    with 4 space line
     with 5 space line
'''
# a normal comment
    for i in range(4):
        move(1, 0)

func()";
		// Expected: parser accepts; no 'Expected indent' error.

		// Test 2: Top-level docstring
		public static string Test2 = @"'''module docstring
line2
'''
x = 1";
		// Expected: accepted; x == 1.

		// Test 3: Assigned triple-quoted string
		public static string Test3 =
	@"s = " + "\"\"\"" + @"this is a
multi-line string
still works" + "\"\"\"" + @"
print(s)";

		// Expected: accepted and s holds the multi-line string.
		public static void RunTests()
		{
			Debug.Log("Testing docstring parsing...");

			try
			{
				var lexer1 = new PythonLexer(Test1);
				var parser1 = new PythonParser(lexer1.Tokens);
				var ast1 = parser1.Parse();
				Debug.Log("Test 1 PASSED: Function with docstring parsed successfully");
			}
			catch (System.Exception e)
			{
				Debug.LogError($"Test 1 FAILED: {e.Message}");
			}

			try
			{
				var lexer2 = new PythonLexer(Test2);
				var parser2 = new PythonParser(lexer2.Tokens);
				var ast2 = parser2.Parse();
				Debug.Log("Test 2 PASSED: Top-level docstring parsed successfully");
			}
			catch (System.Exception e)
			{
				Debug.LogError($"Test 2 FAILED: {e.Message}");
			}

			try
			{
				var lexer3 = new PythonLexer(Test3);
				var parser3 = new PythonParser(lexer3.Tokens);
				var ast3 = parser3.Parse();
				Debug.Log("Test 3 PASSED: Assigned triple-quoted string parsed successfully");
			}
			catch (System.Exception e)
			{
				Debug.LogError($"Test 3 FAILED: {e.Message}");
			}
		}
	}
}
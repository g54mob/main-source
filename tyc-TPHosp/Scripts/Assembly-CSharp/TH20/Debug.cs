#define LOG_LEVEL_VERBOSE
using System;
using System.Diagnostics;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	public static class Debug
	{
		public enum AssertMode
		{
			LogError = 0,
			ThrowException = 1
		}

		public class AssertException : Exception
		{
			public AssertException()
			{
			}

			public AssertException(string message)
				: base(message)
			{
			}

			public AssertException(string message, Exception inner)
				: base(message, inner)
			{
			}
		}

		public static AssertMode CurrentAssertMode { get; set; }

		[ContractAnnotation("expression:false => halt")]
		[Conditional("ASSERTS_ENABLED")]
		public static void Assert(bool expression)
		{
			if (!expression)
			{
				if (CurrentAssertMode == AssertMode.LogError)
				{
					Logging.Error("Assertion failed");
				}
				else if (CurrentAssertMode == AssertMode.ThrowException)
				{
					throw new AssertException("Assertion failed");
				}
			}
		}

		[ContractAnnotation("expression:false => halt")]
		[Conditional("ASSERTS_ENABLED")]
		public static void Assert(bool expression, string errorMessage)
		{
			if (!expression)
			{
				if (CurrentAssertMode == AssertMode.LogError)
				{
					Logging.Error(errorMessage);
				}
				else if (CurrentAssertMode == AssertMode.ThrowException)
				{
					throw new AssertException(errorMessage);
				}
			}
		}

		[StringFormatMethod("errorMessage")]
		[ContractAnnotation("expression:false => halt")]
		[Conditional("ASSERTS_ENABLED")]
		public static void Assert(bool expression, string errorMessage, params object[] args)
		{
			if (!expression)
			{
				if (CurrentAssertMode == AssertMode.LogError)
				{
					Logging.Error(errorMessage, args);
				}
				else if (CurrentAssertMode == AssertMode.ThrowException)
				{
					throw new AssertException(string.Format(errorMessage, args));
				}
			}
		}

		[ContractAnnotation("expression:false => halt")]
		[Conditional("ASSERTS_ENABLED")]
		public static void Assert(bool expression, UnityEngine.Object relatedUnityObject)
		{
			if (!expression)
			{
				if (CurrentAssertMode == AssertMode.LogError)
				{
					Logging.Error(relatedUnityObject, "Assertion failed");
				}
				else if (CurrentAssertMode == AssertMode.ThrowException)
				{
					throw new AssertException("Assertion failed");
				}
			}
		}

		[StringFormatMethod("errorMessage")]
		[ContractAnnotation("expression:false => halt")]
		[Conditional("ASSERTS_ENABLED")]
		public static void Assert(bool expression, UnityEngine.Object relatedUnityObject, string errorMessage, params object[] args)
		{
			if (!expression)
			{
				if (CurrentAssertMode == AssertMode.LogError)
				{
					Logging.Error(relatedUnityObject, errorMessage, args);
				}
				else if (CurrentAssertMode == AssertMode.ThrowException)
				{
					throw new AssertException(string.Format(errorMessage, args));
				}
			}
		}
	}
}

using System;
using System.ComponentModel;
using UnityEngine;

namespace Restory.Gameplay.Cheats
{
	public class ExceptionAndErrorTestCheats : SRDebugCheatBase
	{
		private const string CATEGORY_NAME = "Exception&Error Cheats";

		[Category("Exception&Error Cheats")]
		public void DebugPrintLog()
		{
			Debug.Log("DebugPrintLog");
		}

		[Category("Exception&Error Cheats")]
		public void DebugPrintWarning()
		{
			Debug.LogWarning("DebugPrintWarning");
		}

		[Category("Exception&Error Cheats")]
		public void DebugPrintError()
		{
			Debug.LogErrorFormat("DebugPrintError");
		}

		[Category("Exception&Error Cheats")]
		public void DebugPrintAssert()
		{
		}

		[Category("Exception&Error Cheats")]
		public void DebugPrintLogExceptionAssert()
		{
			Debug.LogException(new Exception("DebugPrintLogExceptionAssert"));
		}

		[Category("Exception&Error Cheats")]
		public void DebugThrowException()
		{
			throw new Exception("DebugThrowException");
		}
	}
}

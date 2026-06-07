using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CLanguage.Interpreter;
using UnityEngine;

public class ArduinoCodeTest : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CRun_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ArduinoCodeTest _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CRun_003Ed__4(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public const string code = "\r\n\r\n    void setup() {                \r\n        // initialize the digital pin as an output.\r\n        // Pin 13 has an LED connected on most Arduino boards:\r\n        pinMode(13, OUTPUT);     \r\n    }\r\n\r\n    void loop() {\r\n\r\n        digitalWrite(13, HIGH);   // set the LED on\r\n        delay(500);              // wait for 3 seconds\r\n \r\n        digitalWrite(13, LOW);    // set the LED off\r\n        delay(500);              // wait for 3 seconds\r\n    }";

	private CInterpreter i;

	public int frameSteps;

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CRun_003Ed__4))]
	private IEnumerator Run()
	{
		return null;
	}

	public void Step(int microseconds)
	{
	}
}

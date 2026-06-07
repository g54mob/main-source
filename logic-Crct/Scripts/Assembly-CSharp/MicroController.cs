using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.MemoryMappedFiles;
using System.Runtime.CompilerServices;
using System.Text;
using CLanguage;
using CLanguage.Interpreter;
using CLanguage.Tests;
using UnityEngine;

public class MicroController : PinComponent
{
	private enum AnalogReference
	{
		EXTERNAL = 0,
		DEFAULT = 1,
		INTERNAL = 2
	}

	public class Pin
	{
		public int Index;

		public int Mode;

		public int DigitalValue;

		public int AnalogValue;
	}

	[CompilerGenerated]
	private sealed class _003CRun_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MicroController _003C_003E4__this;

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
		public _003CRun_003Ed__24(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003C_SendSerial_003Ed__91 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MicroController _003C_003E4__this;

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
		public _003C_SendSerial_003Ed__91(int _003C_003E1__state)
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

	[Header("Interaction")]
	public Transform button;

	public Vector3 buttonBasePos;

	public Vector3 buttonPressedPos;

	[Header("Onboard LEDS")]
	public Renderer power;

	public Renderer pin13;

	public Renderer tx;

	public Renderer rx;

	public Material powerOn;

	public Material ledOff;

	public Material pin13On;

	public Material txrxOn;

	public bool hasPower;

	private MCElement mcElm;

	public int frameSteps;

	public bool running;

	public ArduinoMachine machine;

	public CInterpreter interpreter;

	public string fileName;

	public string code;

	private string emptyCode;

	private Random rand;

	private readonly Stopwatch stopwatch;

	public Pin[] Pins;

	private double refV;

	private AnalogReference analogReference;

	private bool[] interruptOn;

	private Value[] interruptCallback;

	private int[] interruptMode;

	private bool[] interruptPrev;

	private MemoryMappedFile mmf;

	private MemoryMappedViewStream mmvStream;

	private bool canSerial;

	private StringBuilder sb;

	private byte[] Checkbuffer;

	public void Power(bool on)
	{
	}

	public override void TickUpdate()
	{
	}

	public override void FinishPlacement()
	{
	}

	public override object[] VarData()
	{
		return null;
	}

	public override object[] ReturnSaveData()
	{
		return null;
	}

	public override void ProcessVarData(object[] data)
	{
	}

	public override void ProcessSaveData(object[] data)
	{
	}

	public override bool ValuesChanged(object[] data)
	{
		return false;
	}

	public override void InteractDown()
	{
	}

	[IteratorStateMachine(typeof(_003CRun_003Ed__24))]
	private IEnumerator Run()
	{
		return null;
	}

	public override void InteractUp()
	{
	}

	public void ResetTriggered(bool on)
	{
	}

	public override void Awake()
	{
	}

	public void UpdateCode(string c, string f)
	{
	}

	public void Compile()
	{
	}

	public void DigitalRead(CInterpreter state)
	{
	}

	public void DigitalWrite(CInterpreter state)
	{
	}

	public void PinMode(CInterpreter state)
	{
	}

	public void AnalogRead(CInterpreter state)
	{
	}

	public void AnalogWrite(CInterpreter state)
	{
	}

	public void AnalogRef(CInterpreter state)
	{
	}

	public void NoTone(CInterpreter state)
	{
	}

	public void Tone(CInterpreter state)
	{
	}

	public void ToneDuration(CInterpreter state)
	{
	}

	public void __tick(CInterpreter state)
	{
	}

	public void Delay(CInterpreter state)
	{
	}

	public void DelayMicroseconds(CInterpreter state)
	{
	}

	public void Millis(CInterpreter state)
	{
	}

	public void Micros(CInterpreter state)
	{
	}

	public void SqrtDbl(CInterpreter state)
	{
	}

	public void SqrtLong(CInterpreter state)
	{
	}

	public void Pow(CInterpreter state)
	{
	}

	public void Cos(CInterpreter state)
	{
	}

	public void Sin(CInterpreter state)
	{
	}

	public void Tan(CInterpreter state)
	{
	}

	public void RandomSeed(CInterpreter state)
	{
	}

	public void RandomMax(CInterpreter state)
	{
	}

	public void RandomMinMax(CInterpreter state)
	{
	}

	public void isAlpha(CInterpreter state)
	{
	}

	public void isAlphaNumeric(CInterpreter state)
	{
	}

	public void isAscii(CInterpreter state)
	{
	}

	public void isControl(CInterpreter state)
	{
	}

	public void isDigit(CInterpreter state)
	{
	}

	public void isGraph(CInterpreter state)
	{
	}

	public void isHexDigit(CInterpreter state)
	{
	}

	public void isLower(CInterpreter state)
	{
	}

	public void isPrintable(CInterpreter state)
	{
	}

	public void isPunct(CInterpreter state)
	{
	}

	public void isSpace(CInterpreter state)
	{
	}

	public void isUpper(CInterpreter state)
	{
	}

	public void DigitalPinToInterrupt(CInterpreter state)
	{
	}

	public void AttachInterrupt(CInterpreter state)
	{
	}

	public void DetachInterrupt(CInterpreter state)
	{
	}

	public void CheckInterrupts(CInterpreter state)
	{
	}

	public void SPI_TransferI(CInterpreter state)
	{
	}

	public void SerialBegin(CInterpreter state)
	{
	}

	[IteratorStateMachine(typeof(_003C_SendSerial_003Ed__91))]
	private IEnumerator _SendSerial()
	{
		return null;
	}

	public void SerialPrintlnII(CInterpreter state)
	{
	}

	public void SerialPrintlnI(CInterpreter state)
	{
	}

	public void SerialPrintS(CInterpreter state)
	{
	}

	public void SerialPrintlnDbl(CInterpreter state)
	{
	}

	public void SerialPrintlnS(CInterpreter state)
	{
	}
}

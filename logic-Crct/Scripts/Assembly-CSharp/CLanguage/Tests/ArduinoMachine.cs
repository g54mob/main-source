using System.Diagnostics;
using System.IO;
using CLanguage.Compiler;
using CLanguage.Interpreter;
using CLanguage.Types;

namespace CLanguage.Tests
{
	public class ArduinoMachine : MachineInfo
	{
		public class TestArduino
		{
			public class Pin
			{
				public int Index;

				public int Mode;

				public int DigitalValue;

				public int AnalogValue;
			}

			private readonly Stopwatch stopwatch;

			public Pin[] Pins;

			public StringWriter SerialOut;

			public void Delay(CInterpreter state)
			{
			}

			public void Millis(CInterpreter state)
			{
			}

			public void Map(CInterpreter state)
			{
			}

			public void Constrain(CInterpreter state)
			{
			}

			public void PinMode(CInterpreter state)
			{
			}

			public void AnalogRead(CInterpreter state)
			{
			}

			public void DigitalRead(CInterpreter state)
			{
			}

			public void DigitalWrite(CInterpreter state)
			{
			}

			public void SerialBegin(CInterpreter state)
			{
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

			public void SerialPrintlnS(CInterpreter state)
			{
			}
		}

		public MicroController mc;

		public ArduinoMachine(MicroController m)
		{
		}

		public ArduinoMachine()
		{
		}

		public void Init()
		{
		}

		public override ResolvedVariable GetUnresolvedVariable(string name, CType[] argTypes, EmitContext context)
		{
			return null;
		}
	}
}

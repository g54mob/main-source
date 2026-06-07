using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 0, 1)]
	[Title("Emit Signal")]
	[Description("Emits a specific signal, which is captured by other listeners")]
	[Category("Visual Scripting/Emit Signal")]
	[Parameter("Signal", "The signal name emitted")]
	[Keywords(new string[] { "Event", "Raise", "Command", "Fire", "Trigger", "Dispatch", "Execute" })]
	[Image(typeof(IconSignal), ColorTheme.Type.Red)]
	public class InstructionLogicRaiseSignal : Instruction
	{
		[SerializeField]
		private Signal m_Signal;

		public override string Title
		{
			get
			{
				string text = m_Signal.ToString();
				if (!string.IsNullOrEmpty(text))
				{
					return "Signal '" + text + "'";
				}
				return "Signal (none)";
			}
		}

		protected override Task Run(Args args)
		{
			Signals.Emit(new SignalArgs(m_Signal.Value, args.Self));
			return Instruction.DefaultResult;
		}
	}
}

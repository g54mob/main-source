using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Wait Seconds")]
	[Description("Waits a certain amount of seconds")]
	[Category("Time/Wait Seconds")]
	[Parameter("Seconds", "The amount of seconds to wait")]
	[Parameter("Mode", "Whether to use the time scale or not")]
	[Keywords(new string[] { "Wait", "Time", "Seconds", "Minutes", "Cooldown", "Timeout", "Yield" })]
	[Image(typeof(IconTimer), ColorTheme.Type.Blue)]
	public class InstructionCommonTimeWait : Instruction
	{
		[SerializeField]
		private PropertyGetDecimal m_Seconds = new PropertyGetDecimal(1f);

		[SerializeField]
		private TimeMode m_Mode = new TimeMode(TimeMode.UpdateMode.GameTime);

		public override string Title => string.Format("Wait {0} {1}", m_Seconds, (m_Seconds.ToString() == "1") ? "second" : "seconds");

		protected override async Task Run(Args args)
		{
			float duration = (float)m_Seconds.Get(args);
			await Time(duration, m_Mode);
		}
	}
}

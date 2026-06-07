using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Level Zoom")]
	[Category("Cameras/Shots/Zoom/Change Level Zoom")]
	[Description("Changes the targeted zoom level percentage")]
	[Parameter("Level", "The zoom level value between zero and one")]
	public class InstructionShotZoomValue : TInstructionShotZoom
	{
		[SerializeField]
		private PropertyGetDecimal m_Level = GetDecimalDecimal.Create(0.5f);

		public override string Title => $"Set {m_Shot}[Zoom] Level = {m_Level}";

		protected override Task Run(Args args)
		{
			ShotSystemZoom shotSystem = GetShotSystem<ShotSystemZoom>(args);
			if (shotSystem == null)
			{
				return Instruction.DefaultResult;
			}
			shotSystem.Level = (float)m_Level.Get(args);
			return Instruction.DefaultResult;
		}
	}
}

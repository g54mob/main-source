using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Smooth Time")]
	[Category("Cameras/Shots/Zoom/Change Smooth Time")]
	[Description("Changes how smooth the zoom responds to input")]
	[Parameter("Smooth Time", "How smooth is the zoom transition")]
	public class InstructionShotZoomSmoothTime : TInstructionShotZoom
	{
		[SerializeField]
		private PropertyGetDecimal m_SmoothTime = GetDecimalDecimal.Create(0.1f);

		public override string Title => $"Set {m_Shot}[Zoom] Smooth Time = {m_SmoothTime}";

		protected override Task Run(Args args)
		{
			ShotSystemZoom shotSystem = GetShotSystem<ShotSystemZoom>(args);
			if (shotSystem == null)
			{
				return Instruction.DefaultResult;
			}
			shotSystem.SmoothTime = (float)m_SmoothTime.Get(args);
			return Instruction.DefaultResult;
		}
	}
}

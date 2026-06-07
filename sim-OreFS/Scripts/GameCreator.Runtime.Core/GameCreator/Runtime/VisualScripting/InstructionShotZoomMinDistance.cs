using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Min Distance")]
	[Category("Cameras/Shots/Zoom/Change Min Distance")]
	[Description("Changes the targeted zoom level percentage")]
	[Parameter("Min Distance", "The minimum zoom distance between the target and the Shot")]
	public class InstructionShotZoomMinDistance : TInstructionShotZoom
	{
		[SerializeField]
		private PropertyGetDecimal m_MinDistance = GetDecimalDecimal.Create(1f);

		public override string Title => $"Set {m_Shot}[Zoom] Min Distance = {m_MinDistance}";

		protected override Task Run(Args args)
		{
			ShotSystemZoom shotSystem = GetShotSystem<ShotSystemZoom>(args);
			if (shotSystem == null)
			{
				return Instruction.DefaultResult;
			}
			shotSystem.MinDistance = (float)m_MinDistance.Get(args);
			return Instruction.DefaultResult;
		}
	}
}

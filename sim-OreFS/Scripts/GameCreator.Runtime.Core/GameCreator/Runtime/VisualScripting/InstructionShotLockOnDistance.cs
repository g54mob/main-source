using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Distance")]
	[Category("Cameras/Shots/Lock On/Change Distance")]
	[Description("Changes the distance from the anchor point")]
	[Parameter("Distance", "The new distance in self local coordinates")]
	[Keywords(new string[] { "Cameras", "Track", "View" })]
	public class InstructionShotLockOnDistance : TInstructionShotLockOn
	{
		[SerializeField]
		private PropertyGetDecimal m_Distance = GetDecimalDecimal.Create(5f);

		public override string Title => $"Set {m_Shot}[Lock On] Distance = {m_Distance}";

		protected override Task Run(Args args)
		{
			ShotSystemLockOn shotSystem = GetShotSystem<ShotSystemLockOn>(args);
			if (shotSystem == null)
			{
				return Instruction.DefaultResult;
			}
			shotSystem.Distance = (float)m_Distance.Get(args);
			return Instruction.DefaultResult;
		}
	}
}

using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Image(typeof(IconCameraShot), ColorTheme.Type.Yellow)]
	[Title("Set Main Shot")]
	[Category("Cameras/Set Main Shot")]
	[Description("Assigns a Camera Shot as the new Main Shot")]
	[Parameter("Shot", "The new main Camera Shot")]
	public class InstructionShotSetMain : Instruction
	{
		[SerializeField]
		protected PropertyGetGameObject m_Shot = GetGameObjectShot.Create;

		public override string Title => $"Set {m_Shot} as Main Shot";

		protected override Task Run(Args args)
		{
			ShortcutMainShot.Change(m_Shot.Get<ShotCamera>(args));
			return Instruction.DefaultResult;
		}
	}
}

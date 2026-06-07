using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	public class ClipDefault : Clip
	{
		public const string NAME_INSTRUCTIONS = "m_Instructions";

		[SerializeField]
		private RunInstructionsList m_Instructions = new RunInstructionsList();

		public ClipDefault()
			: base(0f)
		{
		}

		public ClipDefault(float time)
			: base(time)
		{
		}

		public ClipDefault(InstructionList instructions, float time)
			: base(time)
		{
			m_Instructions = new RunInstructionsList(instructions);
		}

		protected override void OnStart(ITrack track, Args args)
		{
			base.OnStart(track, args);
			Run(args);
		}

		private void Run(Args args)
		{
			m_Instructions.Run(args.Clone, new RunnerConfig
			{
				Name = "On Clip Run",
				Location = new RunnerLocationLocation((args.Self != null) ? args.Self.transform.position : Vector3.zero, (args.Self != null) ? args.Self.transform.rotation : Quaternion.identity)
			});
		}
	}
}

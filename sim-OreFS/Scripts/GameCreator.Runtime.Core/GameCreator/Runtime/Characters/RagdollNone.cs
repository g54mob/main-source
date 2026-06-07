using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("None")]
	[Category("None")]
	[Image(typeof(IconNull), ColorTheme.Type.TextLight)]
	[Description("No Ragdoll")]
	public class RagdollNone : TRagdollSystem
	{
		protected internal override void OnStartup(Character character)
		{
		}

		protected internal override void OnDispose(Character character)
		{
		}

		protected internal override void OnEnable(Character character)
		{
		}

		protected internal override void OnDisable(Character character)
		{
		}

		protected internal override void OnUpdate(Character character)
		{
		}

		protected internal override void OnLateUpdate(Character character)
		{
		}

		protected internal override Task StartRagdoll(Character character)
		{
			return Task.CompletedTask;
		}

		protected internal override Task StopRagdoll(Character character)
		{
			return Task.CompletedTask;
		}

		protected internal override Task RecoverRagdoll(Character character)
		{
			return Task.CompletedTask;
		}

		protected internal override void OnDrawGizmos(Character character)
		{
		}
	}
}

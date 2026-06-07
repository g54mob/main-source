using System;
using System.Reflection;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 0, 1)]
	[Title("Sync Action")]
	[Description("Asks the Player's NetActionCore to run the referenced Actions on server and other clients")]
	[Category("Network/Sync Action")]
	[Parameter("Actions", "The Actions component to synchronize")]
	[Keywords(new string[] { "Mirror", "Network", "Multiplayer", "RPC", "Broadcast" })]
	[Image(typeof(IconInstructions), ColorTheme.Type.Blue)]
	public class InstructionSyncAction : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Actions = GetGameObjectActions.Create();

		public override string Title => $"Sync {m_Actions}";

		protected override Task Run(Args args)
		{
			Actions actions = m_Actions.Get<Actions>(args);
			if (actions == null)
			{
				Debug.LogWarning("[InstructionSyncAction] Actions reference is null – nothing to sync.");
				return Instruction.DefaultResult;
			}
			MonoBehaviour monoBehaviour = FindNetActionCoreByName(actions.gameObject);
			if (monoBehaviour == null)
			{
				Debug.LogWarning("[InstructionSyncAction] NetActionCore not found on Player root. Broadcast skipped.");
				return Instruction.DefaultResult;
			}
			MethodInfo method = monoBehaviour.GetType().GetMethod("NotifyActionFired", BindingFlags.Instance | BindingFlags.Public);
			if (method == null)
			{
				Debug.LogWarning("[InstructionSyncAction] NetActionCore.NotifyActionFired method not found.");
				return Instruction.DefaultResult;
			}
			try
			{
				method.Invoke(monoBehaviour, new object[1] { actions });
			}
			catch (TargetInvocationException ex)
			{
				Debug.LogError($"[InstructionSyncAction] NotifyActionFired threw: {ex.InnerException}");
			}
			catch (Exception arg)
			{
				Debug.LogError($"[InstructionSyncAction] NotifyActionFired failed: {arg}");
			}
			return Instruction.DefaultResult;
		}

		private static MonoBehaviour FindNetActionCoreByName(GameObject anyGOUnderPlayer)
		{
			if (!anyGOUnderPlayer)
			{
				return null;
			}
			Transform root = anyGOUnderPlayer.transform.root;
			if (!root)
			{
				return null;
			}
			MonoBehaviour[] componentsInChildren = root.GetComponentsInChildren<MonoBehaviour>(includeInactive: true);
			foreach (MonoBehaviour monoBehaviour in componentsInChildren)
			{
				Type type = (monoBehaviour ? monoBehaviour.GetType() : null);
				if (type != null && type.Name == "NetActionCore")
				{
					return monoBehaviour;
				}
			}
			return null;
		}
	}
}

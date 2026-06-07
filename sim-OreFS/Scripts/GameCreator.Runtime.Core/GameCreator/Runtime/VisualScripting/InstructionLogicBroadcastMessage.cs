using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 0, 1)]
	[Title("Broadcast Message")]
	[Description("Invokes any method on any component found on the target game object")]
	[Category("Visual Scripting/Broadcast Message")]
	[Parameter("Game Object", "The target game object that receives the broadcast message")]
	[Parameter("Message", "The name of the method or methods that are called")]
	[Parameter("Send Upwards", "If true the message travels from the game object towards the root")]
	[Example("By default all broadcast messages travel from the target game object and towards all its children. Setting the Send Upwards field to true makes the message travel from the game object towards the root parent")]
	[Keywords(new string[] { "Execute", "Call", "Invoke", "Function" })]
	[Image(typeof(IconMessage), ColorTheme.Type.Yellow)]
	public class InstructionLogicBroadcastMessage : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_GameObject = new PropertyGetGameObject();

		[SerializeField]
		private PropertyGetString m_Message = new PropertyGetString();

		[SerializeField]
		private bool m_SendUpwards;

		public override string Title => string.Format("Broadcast {0} on {1} {2}", m_Message, m_GameObject, m_SendUpwards ? "upwards" : string.Empty);

		protected override Task Run(Args args)
		{
			GameObject gameObject = m_GameObject.Get(args);
			if (gameObject == null)
			{
				return Instruction.DefaultResult;
			}
			string methodName = m_Message.Get(args);
			if (m_SendUpwards)
			{
				gameObject.SendMessageUpwards(methodName, SendMessageOptions.DontRequireReceiver);
			}
			else
			{
				gameObject.SendMessage(methodName, SendMessageOptions.DontRequireReceiver);
			}
			return Instruction.DefaultResult;
		}
	}
}

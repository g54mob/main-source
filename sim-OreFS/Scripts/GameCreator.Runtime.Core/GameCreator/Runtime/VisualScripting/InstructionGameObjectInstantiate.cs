using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Instantiate")]
	[Description("Creates a new instance of a referenced game object")]
	[Category("Game Objects/Instantiate")]
	[Parameter("Game Object", "Game Object reference that is instantiated")]
	[Parameter("Position", "The position of the new game object instance")]
	[Parameter("Rotation", "The rotation of the new game object instance")]
	[Parameter("Save", "Optional value where the newly instantiated game object is stored")]
	[Image(typeof(IconCubeSolid), ColorTheme.Type.Blue, typeof(OverlayPlus))]
	[Keywords(new string[] { "Create", "New", "Game Object" })]
	public class InstructionGameObjectInstantiate : Instruction
	{
		[SerializeField]
		private PropertyGetInstantiate m_GameObject = new PropertyGetInstantiate();

		[SerializeField]
		private PropertyGetPosition m_Position = GetPositionCharactersPlayer.Create;

		[SerializeField]
		private PropertyGetRotation m_Rotation = GetRotationCharactersPlayer.Create;

		[SerializeField]
		private PropertyGetGameObject m_Parent = GetGameObjectNone.Create();

		[SerializeField]
		private PropertySetGameObject m_Save = SetGameObjectNone.Create;

		public override string Title => $"Instantiate {m_GameObject}";

		protected override Task Run(Args args)
		{
			Vector3 position = m_Position.Get(args);
			Quaternion rotation = m_Rotation.Get(args);
			GameObject gameObject = m_GameObject.Get(args, position, rotation);
			if (gameObject != null)
			{
				Transform transform = m_Parent.Get<Transform>(args);
				if (transform != null)
				{
					gameObject.transform.SetParent(transform);
				}
				m_Save.Set(gameObject, args);
			}
			return Instruction.DefaultResult;
		}
	}
}

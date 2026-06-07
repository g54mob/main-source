using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Attach Prop")]
	[Description("Attaches a prefab or instance Prop onto a Character's bone")]
	[Category("Characters/Visuals/Attach Prop")]
	[Parameter("Character", "The character target")]
	[Parameter("Type", "Whether to attach the prop as a prefab or instance")]
	[Parameter("Prop", "The prefab or instance object that is attached to the character")]
	[Parameter("Bone", "Which bone the prop is attached to")]
	[Parameter("Position", "Local offset from which the prop is distanced from the bone")]
	[Parameter("Rotation", "Local offset from which the prop is rotated from the bone")]
	[Keywords(new string[] { "Characters", "Add", "Grab", "Draw", "Pull", "Take", "Object" })]
	[Image(typeof(IconTennis), ColorTheme.Type.Yellow)]
	public class InstructionCharacterAttachProp : Instruction
	{
		private enum Type
		{
			Prefab = 0,
			Instance = 1
		}

		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[SerializeField]
		private Type m_Type;

		[SerializeField]
		private PropertyGetGameObject m_Prop = new PropertyGetGameObject();

		[SerializeField]
		private HandleField m_Handle = new HandleField();

		public override string Title => $"Attach {m_Type} {m_Prop} on {m_Character} {m_Handle}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			GameObject gameObject = m_Prop.Get(args);
			if (gameObject == null)
			{
				return Instruction.DefaultResult;
			}
			Args args2 = new Args(character.gameObject);
			HandleResult handleResult = m_Handle.Get(args2);
			switch (m_Type)
			{
			case Type.Prefab:
				character.Props.AttachPrefab(handleResult.Bone, gameObject, handleResult.LocalPosition, handleResult.LocalRotation);
				break;
			case Type.Instance:
				character.Props.AttachInstance(handleResult.Bone, gameObject, handleResult.LocalPosition, handleResult.LocalRotation);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			return Instruction.DefaultResult;
		}
	}
}

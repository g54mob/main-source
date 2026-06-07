using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Drop Prop")]
	[Description("Drops a prefab or instance Prop (if any) from a Character")]
	[Category("Characters/Visuals/Drop Prop")]
	[Parameter("Character", "The character target")]
	[Parameter("Type", "Whether to drop the prop form a prefab or as its instance")]
	[Parameter("Prop", "The prefab or instance object prop that is dropped from the character")]
	[Keywords(new string[] { "Characters", "Detach", "Let", "Sheathe", "Put", "Holster", "Object" })]
	[Image(typeof(IconTennis), ColorTheme.Type.TextLight, typeof(OverlayArrowDown))]
	public class InstructionCharacterDropProp : Instruction
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

		public override string Title => $"Drop {m_Type} {m_Prop} from {m_Character}";

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
			switch (m_Type)
			{
			case Type.Prefab:
				character.Props.DropPrefab(gameObject);
				break;
			case Type.Instance:
				character.Props.DropInstance(gameObject);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			return Instruction.DefaultResult;
		}
	}
}

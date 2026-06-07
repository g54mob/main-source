using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Model")]
	[Description("Changes the Character current model")]
	[Category("Characters/Visuals/Change Model")]
	[Parameter("Character", "The character target")]
	[Parameter("Model", "The prefab object that replaces the current Character model")]
	[Parameter("Skeleton", "Optional parameter that replaces the configuration of volumes")]
	[Parameter("Footstep Sounds", "Optional parameter that replaces the current Footstep sounds")]
	[Parameter("Offset", "A local offset from the center of the Character")]
	[Keywords(new string[] { "Characters", "Model" })]
	[Image(typeof(IconCharacter), ColorTheme.Type.Yellow)]
	public class InstructionCharacterChangeModel : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[Space]
		[SerializeField]
		private PropertyGetGameObject m_Model = new PropertyGetGameObject();

		[SerializeField]
		private MaterialSoundsAsset m_MaterialSounds;

		[SerializeField]
		private Vector3 m_Offset = Vector3.zero;

		public override string Title => $"Change Model on {m_Character} to {m_Model}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			GameObject gameObject = m_Model.Get(args);
			if (gameObject == null)
			{
				return Instruction.DefaultResult;
			}
			character.ChangeModel(gameObject, new Character.ChangeOptions
			{
				materials = m_MaterialSounds,
				offset = m_Offset
			});
			return Instruction.DefaultResult;
		}
	}
}

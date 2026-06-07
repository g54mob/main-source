using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Take off Skin Mesh")]
	[Description("Removes an instance of a Skin Mesh from a Character")]
	[Category("Characters/Visuals/Take off Skin Mesh")]
	[Parameter("Prefab", "Game Object reference with a Skin Mesh Renderer that is removed")]
	[Parameter("From Character", "Target Character that uses its armature to wear the skin mesh")]
	[Image(typeof(IconSkinMesh), ColorTheme.Type.TextLight, typeof(OverlayArrowRight))]
	[Keywords(new string[] { "Renderer", "Game Object", "Armature" })]
	public class InstructionCharacterTakeOffSkinMesh : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Prefab = GetGameObjectInstance.Create();

		[SerializeField]
		private PropertyGetGameObject m_FromCharacter = GetGameObjectPlayer.Create();

		public override string Title => $"Take {m_Prefab} off {m_FromCharacter}";

		protected override Task Run(Args args)
		{
			Character character = m_FromCharacter.Get<Character>(args);
			GameObject gameObject = m_Prefab.Get(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			if (gameObject == null)
			{
				return Instruction.DefaultResult;
			}
			character.Props.RemoveSkinMesh(gameObject);
			return Instruction.DefaultResult;
		}
	}
}

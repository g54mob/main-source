using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Put on Skin Mesh")]
	[Description("Creates a new instance of a skin mesh renderer and puts it on a Character")]
	[Category("Characters/Visuals/Put on Skin Mesh")]
	[Parameter("Prefab", "Game Object reference with a Skin Mesh Renderer that is instantiated")]
	[Parameter("On Character", "Target Character that uses its armature to wear the skin mesh")]
	[Image(typeof(IconSkinMesh), ColorTheme.Type.Yellow, typeof(OverlayArrowLeft))]
	[Keywords(new string[] { "Renderer", "New", "Game Object", "Armature" })]
	public class InstructionCharacterPutOnSkinMesh : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Prefab = GetGameObjectInstance.Create();

		[SerializeField]
		private PropertyGetGameObject m_OnCharacter = GetGameObjectPlayer.Create();

		public override string Title => $"Put {m_Prefab} on {m_OnCharacter}";

		protected override Task Run(Args args)
		{
			Character character = m_OnCharacter.Get<Character>(args);
			GameObject gameObject = m_Prefab.Get(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			if (gameObject == null)
			{
				return Instruction.DefaultResult;
			}
			character.Props.AttachSkinMesh(gameObject);
			return Instruction.DefaultResult;
		}
	}
}

using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Teleport")]
	[Description("Instantaneously moves a Character from its current position to a new one")]
	[Category("Characters/Navigation/Teleport")]
	[Parameter("Location", "The position and/or rotation where the Character is teleported")]
	[Keywords(new string[] { "Change", "Position", "Location", "Respawn", "Spawn" })]
	[Image(typeof(IconCharacter), ColorTheme.Type.Blue)]
	public class InstructionCharacterNavigationTeleport : TInstructionCharacterNavigation
	{
		[SerializeField]
		private PropertyGetLocation m_Location = GetLocationNavigationMarker.Create;

		public override string Title => $"Teleport {m_Character} to {m_Location}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			Location location = m_Location.Get(args);
			Vector3 position = location.GetPosition(character.gameObject);
			Quaternion rotation = location.GetRotation(character.gameObject);
			if (location.HasPosition(character.gameObject))
			{
				character.Driver.SetPosition(position);
			}
			if (location.HasRotation(character.gameObject))
			{
				character.Driver.SetRotation(rotation);
			}
			return Instruction.DefaultResult;
		}
	}
}

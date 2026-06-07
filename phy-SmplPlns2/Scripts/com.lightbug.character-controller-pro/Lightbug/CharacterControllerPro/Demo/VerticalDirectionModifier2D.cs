using Lightbug.CharacterControllerPro.Core;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	public class VerticalDirectionModifier2D : VerticalDirectionModifier
	{
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (isReady)
			{
				CharacterActor character = GetCharacter(other.transform);
				if (character != null)
				{
					HandleUpDirection(character);
					character.Up = reference.referenceTransform.up;
				}
			}
		}
	}
}

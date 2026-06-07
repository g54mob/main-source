using Lightbug.CharacterControllerPro.Core;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	public class VerticalDirectionModifier3D : VerticalDirectionModifier
	{
		private void OnTriggerEnter(Collider other)
		{
			if (isReady)
			{
				CharacterActor character = GetCharacter(other.transform);
				if (character != null)
				{
					HandleUpDirection(character);
					character.Teleport(reference.referenceTransform);
				}
			}
		}
	}
}

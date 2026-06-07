using System.Collections.Generic;
using Lightbug.CharacterControllerPro.Core;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	public abstract class VerticalDirectionModifier : MonoBehaviour
	{
		[SerializeField]
		protected CharacterReferenceObject reference = new CharacterReferenceObject();

		[Tooltip("This will change the up direction constraint settings from the CharacterActor component bsaed on this object")]
		[SerializeField]
		private bool modifyUpDirection = true;

		[Tooltip("The duration this modifier will be inactive once it is activated. Use this to prevent the character from re-activating the effect over and over again (the default value of 1 second should be enough.)")]
		[SerializeField]
		private float waitTime = 1f;

		protected bool isReady = true;

		private float time;

		protected Dictionary<Transform, CharacterActor> characters = new Dictionary<Transform, CharacterActor>();

		private void Update()
		{
			if (!isReady)
			{
				time += Time.deltaTime;
				if (time >= waitTime)
				{
					time = 0f;
					isReady = true;
				}
			}
		}

		protected void HandleUpDirection(CharacterActor character)
		{
			if (reference != null && modifyUpDirection)
			{
				if (reference.verticalAlignmentReference != null)
				{
					character.upDirectionReference = reference.verticalAlignmentReference;
				}
				else
				{
					character.upDirectionReference = null;
					character.constraintUpDirection = reference.referenceTransform.up;
				}
				isReady = false;
			}
		}

		protected CharacterActor GetCharacter(Transform objectTransform)
		{
			if (!characters.TryGetValue(objectTransform, out var value))
			{
				value = objectTransform.GetComponent<CharacterActor>();
				if (value != null)
				{
					characters.Add(objectTransform, value);
				}
			}
			return value;
		}
	}
}

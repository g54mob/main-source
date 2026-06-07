using System;
using Lightbug.CharacterControllerPro.Implementation;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	[Serializable]
	public class CharacterAIAction
	{
		public SequenceType sequenceType;

		[Min(0f)]
		public float duration = 1f;

		public CharacterActions action;
	}
}

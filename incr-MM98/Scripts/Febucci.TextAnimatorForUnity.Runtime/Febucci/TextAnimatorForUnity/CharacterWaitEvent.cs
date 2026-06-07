using System;
using Febucci.TextAnimatorCore.Text;
using Febucci.TextAnimatorCore.Typing;
using UnityEngine.Events;

namespace Febucci.TextAnimatorForUnity
{
	[Serializable]
	public class CharacterWaitEvent : UnityEvent<CharacterData, WaitMode>
	{
	}
}

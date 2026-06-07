using System.Collections;
using Febucci.TextAnimatorCore.Typing;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity.Actions
{
	[AddComponentMenu("Text Animator for Unity/Actions/Play Sound Action")]
	internal sealed class PlaySound : TypewriterActionComponent
	{
		[SerializeField]
		private AudioSource source;

		protected override IEnumerator PerformAction(TypingInfo typingInfo)
		{
			if (source != null && source.clip != null)
			{
				source.Play();
				yield return new WaitForSeconds(source.clip.length);
			}
		}
	}
}

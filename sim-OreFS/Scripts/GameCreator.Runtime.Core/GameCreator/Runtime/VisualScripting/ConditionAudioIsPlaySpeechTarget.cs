using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Speech Target Playing")]
	[Description("Returns true if the given target game object is playing any audio clip")]
	[Category("Audio/Is Speech Target Playing")]
	[Parameter("Target", "The game object target")]
	[Keywords(new string[] { "SFX", "Speech", "Audio", "Running" })]
	[Image(typeof(IconFace), ColorTheme.Type.Blue, typeof(OverlayArrowRight))]
	public class ConditionAudioIsPlaySpeechTarget : Condition
	{
		[SerializeField]
		private PropertyGetGameObject m_Target = GetGameObjectCharactersInstance.Create;

		protected override string Summary => $"is {m_Target} playing Speech";

		protected override bool Run(Args args)
		{
			GameObject gameObject = m_Target.Get(args);
			if (gameObject != null)
			{
				return Singleton<AudioManager>.Instance.Speech.IsPlaying(gameObject);
			}
			return false;
		}
	}
}

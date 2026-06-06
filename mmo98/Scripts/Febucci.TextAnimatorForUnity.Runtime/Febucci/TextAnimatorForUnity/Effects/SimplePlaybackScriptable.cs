using System;
using Febucci.TextAnimatorCore;
using Febucci.TextAnimatorCore.BuiltIn;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity.Effects
{
	[Serializable]
	[CreateAssetMenu(menuName = "Text Animator for Unity/Playbacks/Simple", fileName = "Simple Playback")]
	internal sealed class SimplePlaybackScriptable : CoreLibraryPlaybackScriptable
	{
		[SerializeField]
		private SimplePlayback playback;

		protected override IEffectPlayback Playback => playback;
	}
}

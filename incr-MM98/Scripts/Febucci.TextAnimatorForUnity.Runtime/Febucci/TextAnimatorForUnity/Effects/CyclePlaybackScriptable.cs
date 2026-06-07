using System;
using Febucci.TextAnimatorCore;
using Febucci.TextAnimatorCore.BuiltIn;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity.Effects
{
	[Serializable]
	[CreateAssetMenu(menuName = "Text Animator for Unity/Playbacks/Cycle", fileName = "Cycle Playback")]
	public sealed class CyclePlaybackScriptable : CoreLibraryPlaybackScriptable
	{
		[SerializeField]
		private CyclePlayback playback;

		protected override IEffectPlayback Playback => playback;
	}
}

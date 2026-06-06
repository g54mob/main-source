using System;
using Febucci.TextAnimatorCore;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity.Effects
{
	[Serializable]
	[CreateAssetMenu(menuName = "Text Animator for Unity/Playbacks/Weighted", fileName = "Weighted Playback")]
	public sealed class WeightedPlaybackScriptable : CoreLibraryPlaybackScriptable
	{
		[SerializeField]
		private WeightedPlaybackWrapper playback;

		protected override IEffectPlayback Playback => playback;
	}
}

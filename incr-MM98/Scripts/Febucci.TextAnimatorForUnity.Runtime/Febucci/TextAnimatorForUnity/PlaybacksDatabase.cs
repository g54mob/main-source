using System;
using System.Collections.Generic;
using Febucci.TextAnimatorCore;
using Febucci.TextAnimatorCore.Data;
using Febucci.TextAnimatorForUnity.Effects;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity
{
	[Serializable]
	[CreateAssetMenu(fileName = "Playbacks Database", menuName = "Text Animator for Unity/Playbacks/Create Playbacks Database", order = 100)]
	public class PlaybacksDatabase : Database<EffectPlaybackScriptableBase>, IDatabaseProvider<IEffectPlayback>
	{
		private Dictionary<string, IEffectPlayback> converted;

		public override bool IsCaseSensitive => false;

		public Dictionary<string, IEffectPlayback> Database
		{
			get
			{
				BuildOnce();
				return converted;
			}
		}

		protected override void OnBuildOnce()
		{
			base.OnBuildOnce();
			converted = new Dictionary<string, IEffectPlayback>();
			foreach (KeyValuePair<string, EffectPlaybackScriptableBase> item in base.Dictionary)
			{
				converted.Add(item.Key, item.Value);
			}
		}
	}
}

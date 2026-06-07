using System;
using System.Collections.Generic;
using Febucci.TextAnimatorCore;
using Febucci.TextAnimatorCore.Data;
using Febucci.TextAnimatorForUnity.Effects.Core;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity
{
	[Serializable]
	[CreateAssetMenu(fileName = "Animations Database", menuName = "Text Animator for Unity/Effects/Create Animations Database", order = 100)]
	public class AnimationsDatabase : Database<EffectScriptableBase>, IDatabaseProvider<IEffect>
	{
		private Dictionary<string, IEffect> converted;

		public override bool IsCaseSensitive => false;

		public Dictionary<string, IEffect> Database
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
			converted = new Dictionary<string, IEffect>();
			foreach (KeyValuePair<string, EffectScriptableBase> item in base.Dictionary)
			{
				converted.Add(item.Key, item.Value);
			}
		}
	}
}

using System;
using System.Collections.Generic;
using Febucci.TextAnimatorCore.Data;
using Febucci.TextAnimatorCore.Typing;
using Febucci.TextAnimatorForUnity.Actions.Core;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity.Actions
{
	[Serializable]
	[CreateAssetMenu(fileName = "ActionDatabase", menuName = "Text Animator for Unity/Actions/Create Actions Database", order = 100)]
	public class ActionDatabase : Database<ActionScriptableBase>, IDatabaseProvider<ITypewriterAction>
	{
		private Dictionary<string, ITypewriterAction> converted = new Dictionary<string, ITypewriterAction>();

		public override bool IsCaseSensitive => false;

		public Dictionary<string, ITypewriterAction> Database
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
			converted = new Dictionary<string, ITypewriterAction>();
			foreach (KeyValuePair<string, ActionScriptableBase> item in base.Dictionary)
			{
				converted.Add(item.Key, item.Value);
			}
		}
	}
}

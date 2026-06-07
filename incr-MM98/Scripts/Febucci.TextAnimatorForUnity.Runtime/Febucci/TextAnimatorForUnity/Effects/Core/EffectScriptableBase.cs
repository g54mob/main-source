using System;
using Febucci.Parsing;
using Febucci.TextAnimatorCore;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity.Effects.Core
{
	[Serializable]
	public abstract class EffectScriptableBase : ScriptableObject, IEffect, ITagProvider
	{
		public abstract string TagID { get; set; }

		public virtual void Initialize()
		{
		}
	}
}

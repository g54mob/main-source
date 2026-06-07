using System;
using Febucci.Parsing;
using Febucci.TextAnimatorCore.Typing;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity.Actions.Core
{
	[Serializable]
	public abstract class ActionScriptableBase : ScriptableObject, ITypewriterAction, ITagProvider
	{
		public abstract string TagID { get; set; }

		public abstract IActionState CreateActionFrom(ActionMarker marker, object typewriter);
	}
}

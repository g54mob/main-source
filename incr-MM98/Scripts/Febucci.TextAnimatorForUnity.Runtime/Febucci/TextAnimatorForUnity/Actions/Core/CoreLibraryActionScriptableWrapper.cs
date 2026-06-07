using Febucci.TextAnimatorCore.Typing;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity.Actions.Core
{
	internal abstract class CoreLibraryActionScriptableWrapper<TState> : ActionScriptableBase where TState : IActionState
	{
		[SerializeField]
		private string tagID;

		private IActionState state;

		public override string TagID
		{
			get
			{
				return tagID;
			}
			set
			{
				tagID = value;
			}
		}

		public override IActionState CreateActionFrom(ActionMarker marker, object typewriter)
		{
			state = CreateState(marker, typewriter);
			return state;
		}

		protected abstract TState CreateState(ActionMarker marker, object typewriter);
	}
}

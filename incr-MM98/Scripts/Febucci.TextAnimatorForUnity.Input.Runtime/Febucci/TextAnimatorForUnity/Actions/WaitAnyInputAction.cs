using System;
using Febucci.TextAnimatorCore.Typing;
using Febucci.TextAnimatorForUnity.Actions.Core;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity.Actions
{
	[Serializable]
	[CreateAssetMenu(menuName = "Text Animator for Unity/Actions/Wait Any Input", fileName = "Wait Any Input Action")]
	[TagInfo("waitinput")]
	public sealed class WaitAnyInputAction : ActionScriptableBase
	{
		[SerializeField]
		private string tagID;

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
			return new UnityInputWrapper(_: true);
		}
	}
}

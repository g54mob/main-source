using ParadoxNotion.Design;
using ParadoxNotion.Serialization;
using UnityEngine;

namespace NodeCanvas.Framework.Internal
{
	[DoNotList]
	[Description("Please resolve the MissingAction issue by either replacing the action, importing the missing action type, or refactoring the type in GraphRefactor.")]
	public class MissingAction : ActionTask, IMissingRecoverable
	{
		[SerializeField]
		private string _missingType;

		[SerializeField]
		private string _recoveryState;

		string IMissingRecoverable.missingType
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		string IMissingRecoverable.recoveryState
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override string info => null;
	}
}

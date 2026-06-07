using ParadoxNotion.Design;
using ParadoxNotion.Serialization;
using UnityEngine;

namespace NodeCanvas.Framework.Internal
{
	[DoNotList]
	public sealed class MissingConnection : Connection, IMissingRecoverable
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
	}
}

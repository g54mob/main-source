using ParadoxNotion.Serialization;
using UnityEngine;

namespace NodeCanvas.Framework.Internal
{
	public class MissingVariableType : Variable<object>, IMissingRecoverable
	{
		[SerializeField]
		private string _missingType;

		[SerializeField]
		private string _recoveryState;

		public string missingType
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string recoveryState
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

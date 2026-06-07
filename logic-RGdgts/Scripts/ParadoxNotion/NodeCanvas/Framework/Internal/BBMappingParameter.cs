using System;
using UnityEngine;

namespace NodeCanvas.Framework.Internal
{
	[Serializable]
	public class BBMappingParameter : BBObjectParameter
	{
		[SerializeField]
		private string _targetSubGraphVariableID;

		[SerializeField]
		private bool _canRead;

		[SerializeField]
		private bool _canWrite;

		public string targetSubGraphVariableID => null;

		public bool canRead
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool canWrite
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public BBMappingParameter()
		{
		}

		public BBMappingParameter(Variable subVariable)
		{
		}
	}
}

using System;
using UnityEngine;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class RequiredNest2
	{
		[Required("trans2 is invalid custom message - hohoho")]
		[AllowNesting]
		public Transform trans2;
	}
}

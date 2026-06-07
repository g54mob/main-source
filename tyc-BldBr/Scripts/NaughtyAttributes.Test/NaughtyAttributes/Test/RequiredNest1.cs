using System;
using UnityEngine;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class RequiredNest1
	{
		[Required(null)]
		[AllowNesting]
		public Transform trans1;

		public RequiredNest2 nest2;
	}
}

using System;
using System.Collections.Generic;
using UnityEngine;

namespace FuryStudios.FurySDK.Utils
{
	[Serializable]
	public abstract class GroupConditions : ICondition
	{
		[SerializeReference]
		public List<ICondition> conditions;

		public abstract bool IsSatisfied();
	}
}

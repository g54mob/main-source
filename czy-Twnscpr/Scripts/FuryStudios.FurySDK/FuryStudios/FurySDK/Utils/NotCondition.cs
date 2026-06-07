using UnityEngine;

namespace FuryStudios.FurySDK.Utils
{
	public class NotCondition : ICondition
	{
		[SerializeReference]
		private ICondition condition;

		public bool IsSatisfied()
		{
			return false;
		}
	}
}

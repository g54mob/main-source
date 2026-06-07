using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	public class HasComponent<T> : ConditionTask<Transform> where T : Component
	{
		protected override bool OnCheck()
		{
			return false;
		}
	}
}

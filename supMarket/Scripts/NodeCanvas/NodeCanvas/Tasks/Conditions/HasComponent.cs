using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("GameObject")]
	public class HasComponent<T> : ConditionTask<Transform>
	{
		protected override bool OnCheck()
		{
			return false;
		}
	}
}

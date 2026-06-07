using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("GameObject")]
	public class IsActive : ConditionTask<Transform>
	{
		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}

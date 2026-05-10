using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("GameObject")]
	public class GetComponent<T> : ActionTask<Transform>
	{
		[BlackboardOnly]
		public BBParameter<T> saveAs;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}

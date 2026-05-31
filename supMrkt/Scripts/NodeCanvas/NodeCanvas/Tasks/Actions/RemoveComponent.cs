using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("GameObject")]
	public class RemoveComponent<T> : ActionTask<Transform>
	{
		[Tooltip("DestroyImmediately is recomended if you are destroying objects in use of the framework.")]
		public bool immediately;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}

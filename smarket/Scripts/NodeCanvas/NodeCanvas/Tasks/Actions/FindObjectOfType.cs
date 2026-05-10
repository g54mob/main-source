using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("GameObject")]
	[Description("Note that this is very slow")]
	public class FindObjectOfType<T> : ActionTask
	{
		[BlackboardOnly]
		public BBParameter<T> saveComponentAs;

		[BlackboardOnly]
		public BBParameter<GameObject> saveGameObjectAs;

		protected override void OnExecute()
		{
		}
	}
}

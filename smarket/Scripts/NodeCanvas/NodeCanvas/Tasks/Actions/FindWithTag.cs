using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("GameObject")]
	public class FindWithTag : ActionTask
	{
		[RequiredField]
		[TagField]
		public string searchTag;

		[BlackboardOnly]
		public BBParameter<GameObject> saveAs;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}

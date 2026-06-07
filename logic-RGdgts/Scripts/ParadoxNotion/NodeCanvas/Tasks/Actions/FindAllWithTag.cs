using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class FindAllWithTag : ActionTask
	{
		[RequiredField]
		[TagField]
		public BBParameter<string> searchTag;

		[BlackboardOnly]
		public BBParameter<List<GameObject>> saveAs;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}

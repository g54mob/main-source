using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("GameObject")]
	[Description("Action will end in Failure if no objects are found")]
	public class FindAllWithLayer : ActionTask
	{
		[RequiredField]
		public BBParameter<LayerMask> targetLayers;

		[BlackboardOnly]
		public BBParameter<List<GameObject>> saveAs;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}

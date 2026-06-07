using System;
using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Obsolete]
	public class GetGameObjectPosition : ActionTask<Transform>
	{
		[BlackboardOnly]
		public BBParameter<Vector3> saveAs;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}

using System.Collections.Generic;
using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class GetAllChildGameObjects : ActionTask<Transform>
	{
		[BlackboardOnly]
		public BBParameter<List<GameObject>> saveAs;

		public bool recursive;

		protected override string info => null;

		protected override void OnExecute()
		{
		}

		private List<Transform> Get(Transform parent)
		{
			return null;
		}
	}
}

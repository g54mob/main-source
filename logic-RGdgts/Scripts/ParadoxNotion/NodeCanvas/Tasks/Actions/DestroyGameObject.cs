using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class DestroyGameObject : ActionTask<Transform>
	{
		public bool immediately;

		protected override string info => null;

		protected override void OnUpdate()
		{
		}
	}
}

using CTS.BBT;
using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	public class ActionSewerBodyDropConstructor : ActionConstructor<WorkerActionSewerBodyDrop>
	{
		[SerializeField]
		private SewerHole _sewerHole;

		protected override WorkerActionSewerBodyDrop ConstructAction()
		{
			return new WorkerActionSewerBodyDrop(_sewerHole);
		}
	}
}

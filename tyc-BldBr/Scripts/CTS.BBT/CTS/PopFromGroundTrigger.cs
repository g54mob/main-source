using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class PopFromGroundTrigger : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private PopFromGround _pop;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_pop.Pop();
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_pop.ResetPos();
		}
	}
}

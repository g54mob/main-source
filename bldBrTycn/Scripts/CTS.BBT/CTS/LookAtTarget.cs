using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class LookAtTarget : CTSBehaviour, IReceive<Transform>, ILateUpdatable
	{
		private Transform _target;

		public void OnReceive(Transform obj)
		{
			_target = obj;
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			UpdateSpreader.AddLateUpdate(this);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			UpdateSpreader.RemoveLateUpdate(this);
		}

		public void OnLateUpdate()
		{
			if (!(_target == null))
			{
				base.transform.rotation = Quaternion.LookRotation(_target.position - base.transform.position);
			}
		}
	}
}

using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class VFXSoftParenting : CTSBehaviour
	{
		[SerializeField]
		private bool _copyPosition;

		[SerializeField]
		private bool _copyRotation;

		private Transform _parent;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_parent = null;
			if ((bool)base.transform.parent)
			{
				_parent = base.transform.parent;
				base.transform.SetParent(null);
			}
		}

		private void LateUpdate()
		{
			if ((bool)_parent)
			{
				if (_copyPosition)
				{
					base.transform.position = _parent.position;
				}
				if (_copyRotation)
				{
					base.transform.rotation = _parent.rotation;
				}
			}
		}
	}
}

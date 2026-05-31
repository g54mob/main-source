using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class RoomAssignationVisualToggler : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private UIWallMenu _wallMenu;

		[SerializeField]
		private LayerMask _layerMask;

		protected override void OnAwake()
		{
			base.OnAwake();
			UIWallMenu.OnMenuOpen += OnMenuOpened;
		}

		private void OnDestroy()
		{
			UIWallMenu.OnMenuOpen -= OnMenuOpened;
			OnMenuOpened(isOpen: false);
		}

		private void OnMenuOpened(bool isOpen)
		{
			if ((bool)MainCamera.CameraReference)
			{
				if (isOpen)
				{
					MainCamera.CameraReference.cullingMask |= _layerMask;
				}
				else
				{
					MainCamera.CameraReference.cullingMask &= ~(int)_layerMask;
				}
			}
		}
	}
}

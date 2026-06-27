using Restory.Gameplay.Equipment.DevicePaintingTools;
using Restory.Utils;
using UnityEngine;

namespace Restory.Gameplay.Equipment.Views
{
	public class DevicePainterEnablerFromDevicePainterToolView : MonoBehaviour
	{
		[SerializeField]
		private DevicePainterToolView devicePainterToolView;

		[SerializeField]
		private PaintingToolWorkplaceItem paintingToolWorkplaceItem;

		private void OnEnable()
		{
			devicePainterToolView.OnDevicePainterToolAdded += ResolveDevicePainterToolAdded;
		}

		private void OnDisable()
		{
			if (devicePainterToolView.MonoShellExists())
			{
				devicePainterToolView.OnDevicePainterToolAdded -= ResolveDevicePainterToolAdded;
			}
		}

		private void ResolveDevicePainterToolAdded()
		{
			paintingToolWorkplaceItem.MakeAvailable();
			devicePainterToolView.OnDevicePainterToolAdded -= ResolveDevicePainterToolAdded;
		}
	}
}

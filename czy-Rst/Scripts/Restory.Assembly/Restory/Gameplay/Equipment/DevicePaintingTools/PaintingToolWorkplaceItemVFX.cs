using Restory.Gameplay.Effects;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment.DevicePaintingTools
{
	public class PaintingToolWorkplaceItemVFX : MonoBehaviour
	{
		[SerializeField]
		private PaintingToolWorkplaceItem paintingTool;

		[SerializeField]
		private Transform vfxPoint;

		private VfxService vfxService;

		[Inject]
		private void Construct(VfxService vfxService)
		{
			this.vfxService = vfxService;
		}

		private void OnEnable()
		{
			paintingTool.OnNewPalettesAdded += ResolveNewPalettesAdded;
		}

		private void OnDisable()
		{
			if (paintingTool.MonoShellExists())
			{
				paintingTool.OnNewPalettesAdded -= ResolveNewPalettesAdded;
			}
		}

		private void ResolveNewPalettesAdded()
		{
			vfxService.PlayPlacementEffect(vfxPoint);
		}
	}
}

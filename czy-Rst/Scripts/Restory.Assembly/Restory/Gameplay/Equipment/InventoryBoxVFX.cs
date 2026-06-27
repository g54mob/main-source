using Restory.Gameplay.Effects;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment
{
	public class InventoryBoxVFX : MonoBehaviour
	{
		[SerializeField]
		private InventoryBox inventoryBox;

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
			inventoryBox.OnItemAdded += ResolveItemAdded;
		}

		private void OnDisable()
		{
			if (inventoryBox.MonoShellExists())
			{
				inventoryBox.OnItemAdded -= ResolveItemAdded;
			}
		}

		private void ResolveItemAdded()
		{
			vfxService?.PlayPlacementEffect(vfxPoint);
		}
	}
}

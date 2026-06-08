using UnityEngine;

namespace Dorfromantik
{
	public class PipetteTool : MonoBehaviour
	{
		[SerializeField]
		private VfxConfiguration tileStackEffect;

		[SerializeField]
		private TileStack tileStack;

		[SerializeField]
		private InputRouter inputRouter;

		[SerializeField]
		private VfxManager vfxManager;

		private void Start()
		{
			inputRouter.OnPipettePick += PipettePickTile;
		}

		private void PipettePickTile(Tile pickedTile)
		{
			tileStack.ReplaceStackedTile(0, pickedTile);
			inputRouter.RotatePreviewTile(pickedTile.RotationIndex);
			vfxManager.SpawnEffectAtTransform(tileStackEffect, tileStack.GetStackedTile(0).transform);
		}

		private void OnDestroy()
		{
			inputRouter.OnPipettePick -= PipettePickTile;
		}
	}
}

using UnityEngine;

namespace Dorfromantik
{
	public class RewardTilePreviewer : MonoBehaviour
	{
		[SerializeField]
		private SessionQuestReward targetReward;

		[SerializeField]
		private bool showAsWhitePreviewTile;

		[SerializeField]
		private KeyCode showPreviewKey;

		[SerializeField]
		private bool useOverwriteSeed;

		[SerializeField]
		private int overwriteSeed;

		[SerializeField]
		private Material skyboxMat;

		[SerializeField]
		private Vector3 hsvOffsetColor2 = new Vector3(0f, -20f, 7f);

		[SerializeField]
		private BiomeManager biomeManager;

		[SerializeField]
		private TileFactory tileFactory;

		private Tile previewedTile;

		public void CreateRewardTile()
		{
			if (!(targetReward == null))
			{
				if (previewedTile != null)
				{
					Object.Destroy(previewedTile.gameObject);
					previewedTile = null;
				}
				biomeManager.Debug_OverrideBiomes(targetReward.displayBiome);
				previewedTile = Object.Instantiate(targetReward.displayTile, base.transform);
				previewedTile.transform.localPosition = Vector3.zero;
				previewedTile.transform.localRotation = Quaternion.AngleAxis(targetReward.displayRotation, Vector3.up);
				previewedTile.InitializeSeed(useOverwriteSeed ? overwriteSeed : targetReward.seed);
				tileFactory.InitializePrebuiltTile(previewedTile);
				BiomeManager.ApplyBiomeToTile(previewedTile, targetReward.displayBiome, targetReward);
				previewedTile.ChangeTileState(TileState.stackPreview);
				previewedTile.SetLayer(10);
				if (showAsWhitePreviewTile)
				{
					previewedTile.SetMaterials(targetReward.displayBiome.GetBiomeTileSlotMaterial());
				}
				Color cameraBackgroundColor;
				Color.RGBToHSV(cameraBackgroundColor = targetReward.displayBiome.CameraBackgroundColor, out var H, out var S, out var V);
				Vector3 vector = new Vector3(H + hsvOffsetColor2.x / 100f, S + hsvOffsetColor2.y / 100f, V + hsvOffsetColor2.z / 100f);
				Color value = Color.HSVToRGB(vector.x, vector.y, vector.z);
				skyboxMat.SetColor("_Color1", cameraBackgroundColor);
				skyboxMat.SetColor("_Color2", value);
			}
		}

		private void Update()
		{
			if (Input.GetKeyDown(showPreviewKey))
			{
				CreateRewardTile();
			}
		}
	}
}

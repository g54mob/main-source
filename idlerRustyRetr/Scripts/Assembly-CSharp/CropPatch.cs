using UnityEngine;

public class CropPatch : MonoBehaviour
{
	public CropSlot[] cropSlots;

	[Header("Sign")]
	public CropSign cropSign;

	private void Start()
	{
		for (int i = 0; i < cropSlots.Length; i++)
		{
			GameManager.ins.cropSlots.Add(cropSlots[i]);
		}
		SaveData.ins.UpdateTotalCropTiles();
		GameManager.ins.cropPatches.Add(this);
		AchievementManager.ins.PlaceCropSlots();
	}

	private void OnDestroy()
	{
		for (int i = 0; i < cropSlots.Length; i++)
		{
			GameManager.ins.cropSlots.Remove(cropSlots[i]);
		}
		SaveData.ins.UpdateTotalCropTiles();
		GameManager.ins.cropPatches.Remove(this);
	}
}

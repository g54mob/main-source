using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class TileUnlockController : MonoBehaviour
{
	public static TileUnlockController Instance;

	[SerializeField]
	private GameObject tileUnlockCanvas;

	private GameObject spawnedPreviewObject;

	[SerializeField]
	private SoundManager soundManager;

	[SerializeField]
	private AudioClip sfx_unlock;

	[SerializeField]
	private List<GameObject> foundTiles;

	[SerializeField]
	private TextMeshProUGUI tileNameText;

	[SerializeField]
	private TextMeshProUGUI tileDescriptionText;

	[SerializeField]
	private TextMeshProUGUI tileUnlockedLabel;

	[SerializeField]
	private Animator tileUnlockAnimator;

	private void Awake()
	{
		Instance = this;
	}

	public void UnlockTile(GridObject gridObjectToUnlock)
	{
		PlayerController.Instance.ResetCameraPosition();
		CameraController.Instance.ResetZoomValue();
		spawnedPreviewObject = Object.Instantiate(gridObjectToUnlock.gameObject, new Vector3(0f, -12.5f, 0f), Quaternion.identity);
		spawnedPreviewObject.transform.localScale = new Vector3(1f, 0f, 1f);
		spawnedPreviewObject.transform.DOScaleY(1f, 0.35f).SetEase(Ease.OutBounce);
		ShowTileData(gridObjectToUnlock);
	}

	public bool TileUnlockCanvasActive()
	{
		return tileUnlockCanvas.activeInHierarchy;
	}

	public void HideAllTiles()
	{
		foundTiles.Clear();
		TileObject[] array = Object.FindObjectsOfType<TileObject>();
		foreach (TileObject tileObject in array)
		{
			foundTiles.Add(tileObject.gameObject);
			tileObject.gameObject.SetActive(value: false);
		}
	}

	public void ShowAllTiles()
	{
		foreach (GameObject foundTile in foundTiles)
		{
			foundTile.gameObject.SetActive(value: true);
		}
	}

	private void ShowTileData(GridObject gridObjectToUnlock)
	{
		tileUnlockAnimator.SetBool("enabled", value: true);
		tileUnlockCanvas.SetActive(value: true);
		tileUnlockedLabel.text = LocalizationController.Instance.GetLabelTranslation("tileUnlocked");
		tileNameText.text = LocalizationController.Instance.GetLabelTranslation(gridObjectToUnlock.GetNameLabel());
		tileDescriptionText.text = LocalizationController.Instance.GetLabelTranslation(gridObjectToUnlock.GetDescriptionLabel());
		soundManager.PlaySound(sfx_unlock, randomPitch: false);
	}

	public void OnContinueButtonPressed()
	{
		tileUnlockAnimator.SetBool("enabled", value: false);
		Object.Destroy(spawnedPreviewObject);
		SteamAchievementManager.Instance.ShowUnlockedTile();
	}

	public void HideTileUnlockCanvas()
	{
		tileUnlockCanvas.SetActive(value: false);
		tileNameText.text = "";
		tileDescriptionText.text = "";
		tileUnlockedLabel.text = "";
		WorldSetupPreview.Instance.ShowButtonPreviewText("");
		GameManager.Instance.EnableRestartButton();
	}
}

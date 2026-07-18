using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorldSetupPreview : MonoBehaviour
{
	public static WorldSetupPreview Instance;

	[SerializeField]
	private Transform tilesPreviewParent;

	[SerializeField]
	private GameObject tilePreviewInstancePrefab;

	[SerializeField]
	private int tilesWidthCount;

	[SerializeField]
	private GridLayoutGroup gridLayoutGroup;

	[SerializeField]
	private WorldShape worldShape;

	[SerializeField]
	private GameObject worldShapeButton;

	[SerializeField]
	private Image selectedWorldShapeImage;

	[SerializeField]
	private List<WorldShapeData> worldShapeOptions;

	[SerializeField]
	private int selectedWorldShapeIndex;

	private bool canChangeWorldVariables = true;

	[SerializeField]
	private Button changeShapeButton;

	[SerializeField]
	private Button changeWorldSizeButtonPlus;

	[SerializeField]
	private Button changeWorldSizeButtonMinus;

	[SerializeField]
	private List<WorldShape> worldShapesToAddTwo;

	[SerializeField]
	private TextMeshProUGUI tilesCountText;

	[SerializeField]
	private Animator tilesCountAnimator;

	[SerializeField]
	private SoundManager soundManager;

	[SerializeField]
	private AudioClip tileSpawnSound;

	[SerializeField]
	private GameObject uiElementsObject;

	private bool previewActive = true;

	[SerializeField]
	private Animator uiElementsAnimator;

	[SerializeField]
	private TextMeshProUGUI buttonPreviewText;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		uiElementsAnimator.Play("anim_world_setup_preview_start");
		UpdatePreview();
		selectedWorldShapeIndex = (PlayerPrefs.HasKey("worldshape") ? (PlayerPrefs.GetInt("worldshape") - 1) : (-1));
		tilesWidthCount = (PlayerPrefs.HasKey("tilesWidthCount") ? PlayerPrefs.GetInt("tilesWidthCount") : 3);
		ChangeWorldShape();
	}

	private void Update()
	{
		changeShapeButton.interactable = GridController.Instance.IsRotateTweenFinished();
		changeWorldSizeButtonPlus.interactable = GridController.Instance.IsRotateTweenFinished();
		changeWorldSizeButtonMinus.interactable = GridController.Instance.IsRotateTweenFinished();
	}

	public void SetWorldShape(WorldShape worldShape)
	{
		this.worldShape = worldShape;
		if (DemoController.Instance.IsDemo() && this.worldShape == WorldShape.diamond)
		{
			ChangeWorldShape();
		}
		if (this.worldShape == WorldShape.diamond && tilesWidthCount % 2 == 0)
		{
			tilesWidthCount++;
		}
		UpdatePreview();
	}

	public void ChangeWorldShape()
	{
		selectedWorldShapeIndex++;
		if (selectedWorldShapeIndex >= worldShapeOptions.Count)
		{
			selectedWorldShapeIndex = 0;
		}
		selectedWorldShapeImage.sprite = worldShapeOptions[selectedWorldShapeIndex].previewSprite;
		PlayerPrefs.SetInt("worldshape", selectedWorldShapeIndex);
		SetWorldShape(worldShapeOptions[selectedWorldShapeIndex].worldShape);
		if (tilesWidthCount % 2 == 0 && (worldShape == WorldShape.diamond || worldShape == WorldShape.circle))
		{
			tilesWidthCount++;
			UpdatePreview();
		}
	}

	public WorldShape GetWorldShape()
	{
		return worldShape;
	}

	public void ChangeTilesWidthCount(bool add)
	{
		if (GridController.Instance.IsRotateTweenFinished())
		{
			tilesWidthCount += ((!add) ? (worldShapesToAddTwo.Contains(worldShape) ? (-2) : (-1)) : ((!worldShapesToAddTwo.Contains(worldShape)) ? 1 : 2));
			if (tilesWidthCount <= 1)
			{
				tilesWidthCount = 1;
			}
			if (tilesWidthCount > 5 && DemoController.Instance.IsDemo())
			{
				tilesWidthCount = 5;
			}
			if (tilesWidthCount >= 11)
			{
				tilesWidthCount = 11;
			}
			PlayerPrefs.SetInt("tilesWidthCount", tilesWidthCount);
			UpdatePreview();
		}
	}

	private void UpdatePreview()
	{
		if (tilesCountText.text != tilesWidthCount.ToString())
		{
			tilesCountAnimator.Play("anim_tilesize-change");
		}
		tilesCountText.text = tilesWidthCount.ToString();
		StopAllCoroutines();
		StopCoroutine(GridController.Instance.BuildWorld());
		try
		{
			foreach (Transform item in tilesPreviewParent)
			{
				GridController.Instance.ClearTiles();
				GridController.Instance.RemoveFromGrid(item.position);
				Object.Destroy(item.gameObject);
			}
		}
		catch
		{
		}
		GridController.Instance.SetTileWidthCount(tilesWidthCount);
		StartCoroutine(GridController.Instance.BuildWorld());
		soundManager.ResetPitch();
	}

	public void PlayTileSpawnSound()
	{
		soundManager.PlaySound(tileSpawnSound, randomPitch: false);
		soundManager.ChangePitch(add: true);
	}

	public void ResetPitch()
	{
		soundManager.ResetPitch();
	}

	public bool IsPreviewUIActive()
	{
		return previewActive;
	}

	public void HidePreviewUI()
	{
		previewActive = false;
		uiElementsAnimator.Play("anim_world_setup_preview_hide");
	}

	public void ShowButtonPreviewText(string text)
	{
		buttonPreviewText.text = LocalizationController.Instance.GetLabelTranslation(text);
	}
}

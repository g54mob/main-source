using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{
	public static BackgroundController Instance;

	[SerializeField]
	private List<BackgroundTileColorCombination> backgroundOptions;

	[SerializeField]
	private Image backgroundImage;

	[SerializeField]
	private Material tileMaterial;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		int num = (PlayerPrefs.HasKey("backgroundTileCombination") ? PlayerPrefs.GetInt("backgroundTileCombination") : (-1));
		int num2 = -1;
		while (num2 == num || num2 == -1)
		{
			num2 = Random.Range(0, backgroundOptions.Count);
		}
		PlayerPrefs.SetInt("backgroundTileCombination", num2);
		BackgroundTileColorCombination backgroundTileColorCombination = backgroundOptions[num2];
		backgroundImage.sprite = backgroundTileColorCombination.backgroundColor;
		GridController.Instance.SetTileMaterial(backgroundTileColorCombination.tileMaterial);
		tileMaterial = backgroundTileColorCombination.tileMaterial;
	}

	public Material GetTileMaterial()
	{
		return tileMaterial;
	}
}

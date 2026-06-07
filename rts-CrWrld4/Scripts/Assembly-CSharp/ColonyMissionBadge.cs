using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColonyMissionBadge : MonoBehaviour
{
	public RectTransform imageContainer;

	public RawImage image;

	public TextMeshProUGUI titleText;

	public TextMeshProUGUI authorText;

	public TextMeshProUGUI sizeText;

	public TextMeshProUGUI numberText;

	public TextMeshProUGUI thumbsText;

	public GameObject thumbsContainer;

	public Image objectiveNullifyImage;

	public Image objectiveTotemImage;

	public Image objectiveReclaimImage;

	public Image objectiveSurviveImage;

	public Image objectiveCollectImage;

	public Image objectiveCustomImage;

	public Image borderImage;

	public Image selectedImage;

	public GameObject updateCover;

	[NonSerialized]
	public ColonySector colonySector;

	private bool _selected;

	private ColonySector.MapEntry _mapEntry;

	private bool assignedTexture;

	private int updateLaterCount;

	public bool selected
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public ColonySector.MapEntry mapEntry
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private void LateUpdate()
	{
	}

	private void UpdateMapImage()
	{
	}

	private void UpdateSize()
	{
	}

	public void OnAuthorClicked()
	{
	}

	public void OnClick()
	{
	}
}

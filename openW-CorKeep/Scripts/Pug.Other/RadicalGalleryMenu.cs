using System.Collections.Generic;
using UnityEngine;

public class RadicalGalleryMenu : RadicalMenu
{
	private const int VISIBLE_IMAGE_EDGE_SIZE_UNITY_UNITS = 3;

	public GameObject leftArrow;

	public GameObject rightArrow;

	public Animator animator;

	private int previousIndex;

	public GameObject galleryContainer;

	public GalleryImage galleryImagePrefab;

	public List<Sprite> images;

	protected override void Awake()
	{
		base.Awake();
		foreach (Sprite image in images)
		{
			GalleryImage galleryImage = Object.Instantiate(galleryImagePrefab, galleryContainer.transform);
			galleryImage.spriteRenderer.sprite = image;
			menuOptions.Add(galleryImage);
		}
	}

	public override void Activate()
	{
		base.Activate();
		previousIndex = base.selectedIndex;
	}

	public override void Deactivate(bool pop)
	{
		base.Deactivate(pop);
	}

	protected override void OnSelectedOptionChanged()
	{
		List<RadicalMenuOption> allCurrentlyActiveMenuOptions = GetAllCurrentlyActiveMenuOptions();
		bool flag = base.selectedIndex == 0 && previousIndex == allCurrentlyActiveMenuOptions.Count - 1;
		bool flag2 = base.selectedIndex == allCurrentlyActiveMenuOptions.Count - 1 && previousIndex == 0;
		if (base.selectedIndex != previousIndex)
		{
			if ((base.selectedIndex > previousIndex && !flag2) || flag)
			{
				animator.SetTrigger("skimRight");
			}
			else
			{
				animator.SetTrigger("skimLeft");
			}
			previousIndex = base.selectedIndex;
		}
		for (int i = 0; i < allCurrentlyActiveMenuOptions.Count; i++)
		{
			int num = i - base.selectedIndex;
			if (base.selectedIndex == 0 && i == allCurrentlyActiveMenuOptions.Count - 1)
			{
				num = -1;
			}
			else if (base.selectedIndex == allCurrentlyActiveMenuOptions.Count - 1 && i == 0)
			{
				num = 1;
			}
			float x = menuEntryVirtualHeight * (float)num;
			Vector3 localPosition = new Vector3(x, 0f, 0f);
			float halfImageWidth = ((GalleryImage)allCurrentlyActiveMenuOptions[i]).GetHalfImageWidth();
			switch (num)
			{
			case -1:
				localPosition += new Vector3(0f - halfImageWidth + 3f, 0f, 0f);
				break;
			case 1:
				localPosition += new Vector3(halfImageWidth - 3f, 0f, 0f);
				break;
			}
			((GalleryImage)allCurrentlyActiveMenuOptions[i]).MakeTransparent(num != 0);
			allCurrentlyActiveMenuOptions[i].transform.localPosition = localPosition;
		}
		float num2 = ((GalleryImage)GetSelectedMenuOption()).GetHalfImageWidth() + 0.5f;
		leftArrow.transform.localPosition = new Vector3(0f - num2, -1.5f, 10f);
		rightArrow.transform.localPosition = new Vector3(num2, -1.5f, 10f);
	}

	public override List<MenuHelperButtons.HelpButtonTypes> GetHelpButtonsToShow()
	{
		return new List<MenuHelperButtons.HelpButtonTypes>
		{
			MenuHelperButtons.HelpButtonTypes.NAVIGATE,
			MenuHelperButtons.HelpButtonTypes.BACK
		};
	}
}

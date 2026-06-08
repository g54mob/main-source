using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuspectAppearance : MonoBehaviour
{
	private enum Feature
	{
		Body = 0,
		HairBack = 1,
		Head = 2,
		Eyes = 3,
		Eyebrows = 4,
		Mouths = 5,
		HairFront = 6,
		Wrinkles = 7,
		FacialHair = 8
	}

	public void SetAppearance(string firstName, Appearance appearance)
	{
		Debug.Log("firstName " + firstName);
		int num = appearance?.age ?? CreateTablesHelpers.RANDY.Next(20, 60);
		Color32 eyeColor = GetEyeColor(appearance);
		Color32 skinColor = GetSkinColor(eyeColor);
		Color32 hairColor = GetHairColor(skinColor, num);
		bool flag = IsMaleName(firstName);
		SetIndexActive(GetBodyPart(Feature.Body), (!flag) ? 1 : 0);
		Transform bodyPart = GetBodyPart(Feature.HairBack);
		if (flag)
		{
			bodyPart.gameObject.SetActive(value: false);
		}
		else
		{
			SetColor(SetIndexActive(bodyPart), hairColor);
		}
		SetColor(SetIndexActive(GetBodyPart(Feature.Head)), skinColor);
		SetIndexActive(GetBodyPart(Feature.Eyes).GetChild((!flag) ? 1 : 0)).GetChild(1).GetComponent<Image>().color = eyeColor;
		SetColor(SetIndexActive(GetBodyPart(Feature.Eyebrows)), hairColor);
		SetIndexActive(GetBodyPart(Feature.Mouths));
		if (flag)
		{
			int index = CreateTablesHelpers.RANDY.Next((num < 45) ? 3 : 4);
			SetColor(SetIndexActive(GetBodyPart(Feature.HairFront).GetChild(0), index), hairColor);
		}
		else
		{
			SetColor(SetIndexActive(GetBodyPart(Feature.HairFront).GetChild(1)), hairColor);
		}
		Transform bodyPart2 = GetBodyPart(Feature.Wrinkles);
		if (num < 30)
		{
			bodyPart2.gameObject.SetActive(value: false);
		}
		else
		{
			int index2 = ((num > 40) ? ((num <= 55) ? 1 : 2) : 0);
			SetColor(SetIndexActive(bodyPart2, index2), skinColor);
		}
		Transform bodyPart3 = GetBodyPart(Feature.FacialHair);
		if (flag && num >= 25 && CreateTablesHelpers.IsPercentChance(30))
		{
			SetColor(SetIndexActive(bodyPart3), hairColor);
		}
		else
		{
			bodyPart3.gameObject.SetActive(value: false);
		}
	}

	private Color32 GetHairColor(Color32 skinTone, int age)
	{
		List<Color32> list = new List<Color32>();
		if (age >= 55)
		{
			list.Add(SuspectColors.GRAY);
		}
		else
		{
			list.Add(SuspectColors.BLACK);
			if (skinTone.Equals(SuspectColors.PEACH_SKIN))
			{
				list.AddRange(new Color32[3]
				{
					SuspectColors.DARK_BROWN,
					SuspectColors.LIGHT_BROWN,
					SuspectColors.BLONDE
				});
			}
		}
		return CreateTablesHelpers.GetRandomValue(list);
	}

	private Color32 GetEyeColor(Appearance appearance)
	{
		if (appearance == null || appearance.eyeColor == null)
		{
			return SuspectColors.BLACK;
		}
		if (appearance.eyeColor.Equals("Brown", StringComparison.OrdinalIgnoreCase))
		{
			return SuspectColors.DARK_BROWN;
		}
		if (appearance.eyeColor.Equals("Green", StringComparison.OrdinalIgnoreCase))
		{
			return SuspectColors.GREEN;
		}
		if (appearance.eyeColor.Equals("Blue", StringComparison.OrdinalIgnoreCase))
		{
			return SuspectColors.BLUE;
		}
		return SuspectColors.BLACK;
	}

	private Color32 GetSkinColor(Color32 eyeColor)
	{
		if (eyeColor.Equals(SuspectColors.GREEN) || eyeColor.Equals(SuspectColors.BLUE))
		{
			return SuspectColors.PEACH_SKIN;
		}
		return CreateTablesHelpers.GetRandomValue(SuspectColors.SKIN_COLORS);
	}

	private void SetColor(Transform transform, Color32 color)
	{
		transform.GetComponent<Image>().color = color;
	}

	private Transform SetIndexActive(Transform parent)
	{
		return SetIndexActive(parent, CreateTablesHelpers.RANDY.Next(parent.childCount));
	}

	private Transform SetIndexActive(Transform parent, int index)
	{
		Transform transform = null;
		parent.gameObject.SetActive(value: true);
		for (int i = 0; i < parent.childCount; i++)
		{
			if (i == index)
			{
				transform = parent.GetChild(i);
				transform.gameObject.SetActive(value: true);
			}
			else
			{
				parent.GetChild(i).gameObject.SetActive(value: false);
			}
		}
		return transform;
	}

	public bool IsMaleName(string firstName)
	{
		return Array.IndexOf(CreateTablesHelpers.maleNames, CreateTablesHelpers.ToNameCase(firstName)) >= 0;
	}

	private Transform GetBodyPart(Feature feature)
	{
		return base.transform.GetChild((int)feature);
	}
}

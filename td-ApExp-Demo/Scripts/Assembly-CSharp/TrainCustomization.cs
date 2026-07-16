using System.Collections.Generic;
using UnityEngine;

public class TrainCustomization : MonoBehaviour
{
	public enum ColorCategory
	{
		Paint = 0,
		Metal = 1
	}

	public List<SpriteRenderer> srsPaint;

	public List<SpriteRenderer> srsMetal;

	[field: SerializeField]
	public Color ColorPaint { get; private set; } = new Color(0.7f, 1f, 0.35f);

	[field: SerializeField]
	public Color ColorMetal { get; private set; } = Color.white;

	private void OnValidate()
	{
		UpdateAllColors();
	}

	public void ChangeCategoryColor(Color color, ColorCategory category)
	{
		switch (category)
		{
		case ColorCategory.Paint:
			ColorPaint = color;
			ApplyColorToCategorySRs(ColorCategory.Paint);
			break;
		case ColorCategory.Metal:
			ColorMetal = color;
			ApplyColorToCategorySRs(ColorCategory.Metal);
			break;
		}
	}

	public void UpdateAllColors()
	{
		ApplyColorToCategorySRs(ColorCategory.Paint);
		ApplyColorToCategorySRs(ColorCategory.Metal);
	}

	public void ApplyColorToCategorySRs(ColorCategory category)
	{
		switch (category)
		{
		case ColorCategory.Paint:
		{
			foreach (SpriteRenderer item in srsPaint)
			{
				if ((bool)item)
				{
					item.color = ColorPaint;
				}
			}
			break;
		}
		case ColorCategory.Metal:
		{
			foreach (SpriteRenderer item2 in srsMetal)
			{
				if ((bool)item2)
				{
					item2.color = ColorMetal;
				}
			}
			break;
		}
		}
	}

	public void RegisterSRByCategory(SpriteRenderer sr, ColorCategory category)
	{
		if (!sr)
		{
			return;
		}
		switch (category)
		{
		case ColorCategory.Paint:
			if (!srsPaint.Contains(sr))
			{
				srsPaint.Add(sr);
				sr.color = ColorPaint;
			}
			break;
		case ColorCategory.Metal:
			if (!srsMetal.Contains(sr))
			{
				srsMetal.Add(sr);
				sr.color = ColorMetal;
			}
			break;
		}
	}

	public void UnregisterSR(SpriteRenderer sr)
	{
		List<SpriteRenderer>[] array = new List<SpriteRenderer>[2] { srsPaint, srsMetal };
		foreach (List<SpriteRenderer> list in array)
		{
			if (list.Contains(sr))
			{
				list.Remove(sr);
			}
		}
	}
}

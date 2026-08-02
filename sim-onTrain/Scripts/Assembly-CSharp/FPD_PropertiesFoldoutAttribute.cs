using UnityEngine;

public class FPD_PropertiesFoldoutAttribute : PropertyAttribute
{
	public int HowManyNextPropertiesToContain;

	public bool foldout;

	public string title;

	public int indent;

	public int frameStyleID;

	public string frameStyle;

	public int extraSpacing;

	public FPD_PropertiesFoldoutAttribute(int howManyNextPropsInside, bool defaultFoldout = false, string title = "", int extraSpacing = 0, int indent = 1)
	{
		HowManyNextPropertiesToContain = howManyNextPropsInside;
		foldout = defaultFoldout;
		this.title = title;
		this.indent = indent;
		frameStyle = null;
		frameStyleID = -1;
		this.extraSpacing = extraSpacing;
	}

	public FPD_PropertiesFoldoutAttribute(string frameStyle, int howManyNextPropsInside, bool defaultFoldout = false, string title = "", int extraSpacing = 0, int indent = 1)
	{
		HowManyNextPropertiesToContain = howManyNextPropsInside;
		foldout = defaultFoldout;
		this.title = title;
		this.indent = indent;
		this.frameStyle = frameStyle;
		this.extraSpacing = extraSpacing;
	}

	public FPD_PropertiesFoldoutAttribute(int howManyNextPropsInside, bool defaultFoldout, int frameStyleID, string title = "", int extraSpacing = 0, int indent = 1)
	{
		HowManyNextPropertiesToContain = howManyNextPropsInside;
		foldout = defaultFoldout;
		this.title = title;
		this.indent = indent;
		this.frameStyleID = frameStyleID;
		this.extraSpacing = extraSpacing;
	}
}

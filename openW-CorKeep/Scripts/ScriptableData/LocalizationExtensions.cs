using UnityEngine;
using UnityEngine.UI;

public static class LocalizationExtensions
{
	public static void SetTitle(this Text target, TextDataBlock text)
	{
		target.text = text.GetLocalized().title;
		target.SetTitle(text);
	}

	public static void SetDescription(this Text target, TextDataBlock text)
	{
		target.text = text.GetLocalized().description;
		target.SetDescription(text);
	}

	public static void ApplyTitle(this TextDataBlock text, Text target)
	{
		target.text = text.GetLocalized().title;
	}

	public static void ApplyTitle(this TextDataBlock text, Text target, object arg0)
	{
		target.text = string.Format(text.GetLocalized().title, arg0);
	}

	public static void ApplyTitle(this TextDataBlock text, Text target, object arg0, object arg1)
	{
		target.text = string.Format(text.GetLocalized().title, arg0, arg1);
	}

	public static void ApplyTitle(this TextDataBlock text, Text target, object arg0, object arg1, object arg2)
	{
		target.text = string.Format(text.GetLocalized().title, arg0, arg1, arg2);
	}

	public static void ApplyTitle(this TextDataBlock text, Text target, params object[] args)
	{
		target.text = string.Format(text.GetLocalized().title, args);
	}

	public static void ApplyTitle(this TextDataBlock text, TextMesh target)
	{
		target.text = text.GetLocalized().title;
	}

	public static void ApplyTitle(this TextDataBlock text, TextMesh target, object arg0)
	{
		target.text = string.Format(text.GetLocalized().title, arg0);
	}

	public static void ApplyTitle(this TextDataBlock text, TextMesh target, object arg0, object arg1)
	{
		target.text = string.Format(text.GetLocalized().title, arg0, arg1);
	}

	public static void ApplyTitle(this TextDataBlock text, TextMesh target, object arg0, object arg1, object arg2)
	{
		target.text = string.Format(text.GetLocalized().title, arg0, arg1, arg2);
	}

	public static void ApplyTitle(this TextDataBlock text, TextMesh target, params object[] args)
	{
		target.text = string.Format(text.GetLocalized().title, args);
	}

	public static void ApplyDescription(this TextDataBlock text, Text target)
	{
		target.text = text.GetLocalized().description;
	}

	public static void ApplyDescription(this TextDataBlock text, Text target, object arg0)
	{
		target.text = string.Format(text.GetLocalized().description, arg0);
	}

	public static void ApplyDescription(this TextDataBlock text, Text target, object arg0, object arg1)
	{
		target.text = string.Format(text.GetLocalized().description, arg0, arg1);
	}

	public static void ApplyDescription(this TextDataBlock text, Text target, object arg0, object arg1, object arg2)
	{
		target.text = string.Format(text.GetLocalized().description, arg0, arg1, arg2);
	}

	public static void ApplyDescription(this TextDataBlock text, Text target, params object[] args)
	{
		target.text = string.Format(text.GetLocalized().description, args);
	}

	public static void ApplyDescription(this TextDataBlock text, TextMesh target)
	{
		target.text = text.GetLocalized().description;
	}

	public static void ApplyDescription(this TextDataBlock text, TextMesh target, object arg0)
	{
		target.text = string.Format(text.GetLocalized().description, arg0);
	}

	public static void ApplyDescription(this TextDataBlock text, TextMesh target, object arg0, object arg1)
	{
		target.text = string.Format(text.GetLocalized().description, arg0, arg1);
	}

	public static void ApplyDescription(this TextDataBlock text, TextMesh target, object arg0, object arg1, object arg2)
	{
		target.text = string.Format(text.GetLocalized().description, arg0, arg1, arg2);
	}

	public static void ApplyDescription(this TextDataBlock text, TextMesh target, params object[] args)
	{
		target.text = string.Format(text.GetLocalized().description, args);
	}
}

using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NativeShare
{
	private string subject;

	private string text;

	private string title;

	private string targetPackage;

	private string targetClass;

	private List<string> files;

	private List<string> mimes;

	public NativeShare()
	{
		subject = string.Empty;
		text = string.Empty;
		title = string.Empty;
		targetPackage = string.Empty;
		targetClass = string.Empty;
		files = new List<string>(0);
		mimes = new List<string>(0);
	}

	public NativeShare SetSubject(string subject)
	{
		if (subject != null)
		{
			this.subject = subject;
		}
		return this;
	}

	public NativeShare SetText(string text)
	{
		if (text != null)
		{
			this.text = text;
		}
		return this;
	}

	public NativeShare SetTitle(string title)
	{
		if (title != null)
		{
			this.title = title;
		}
		return this;
	}

	public NativeShare SetTarget(string androidPackageName, string androidClassName = null)
	{
		if (!string.IsNullOrEmpty(androidPackageName))
		{
			targetPackage = androidPackageName;
			if (androidClassName != null)
			{
				targetClass = androidClassName;
			}
		}
		return this;
	}

	public NativeShare AddFile(string filePath, string mime = null)
	{
		if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
		{
			files.Add(filePath);
			mimes.Add(mime ?? string.Empty);
		}
		else
		{
			Debug.LogError("File does not exist at path or permission denied: " + filePath);
		}
		return this;
	}

	public void Share()
	{
		if (files.Count == 0 && subject.Length == 0 && text.Length == 0)
		{
			Debug.LogWarning("Share Error: attempting to share nothing!");
		}
		else
		{
			Debug.Log("No sharing set up for this platform.");
		}
	}

	public static bool TargetExists(string androidPackageName, string androidClassName = null)
	{
		return true;
	}

	public static bool FindTarget(out string androidPackageName, out string androidClassName, string packageNameRegex, string classNameRegex = null)
	{
		androidPackageName = null;
		androidClassName = null;
		return false;
	}
}

using System;
using System.IO;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
public class FolderPickerAttribute : PropertyAttribute
{
	public readonly bool hasValidRoot;

	public readonly string root;

	public string DefaultRoot
	{
		get
		{
			if (!hasValidRoot)
			{
				return "Assets";
			}
			return root;
		}
	}

	public FolderPickerAttribute()
	{
		hasValidRoot = false;
	}

	public FolderPickerAttribute(string root)
	{
		hasValidRoot = root.StartsWith("Assets") && Directory.Exists(root);
		if (hasValidRoot)
		{
			this.root = root;
		}
	}
}

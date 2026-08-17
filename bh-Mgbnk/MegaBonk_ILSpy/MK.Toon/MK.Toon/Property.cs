using System;
using Cpp2ILInjected;
using UnityEngine;

namespace MK.Toon;

public abstract class Property<T>
{
	protected string[] _keywords;

	protected Uniform _uniform;

	public Uniform uniform => _uniform;

	public Property(Uniform uniform, string[] keywords)
	{
		_keywords = keywords;
		_uniform = uniform;
	}

	public abstract T GetValue(Material material);

	public abstract void SetValue(Material material, T value);

	protected void SetKeyword(Material material, bool b, int keywordIndex)
	{
		//IL_0110: Expected O, but got I4
		//IL_0119: Expected O, but got I4
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_008b: Expected O, but got I4
		//IL_009c: Expected O, but got I4
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		if (b && _keywords != null)
		{
			string[] keywords = _keywords;
			if (keywords.Length > keywordIndex && keywords.Length != 0)
			{
				object obj = 0;
				string[] array = keywords;
				object obj2 = 0;
				string[] keywords2;
				while (true)
				{
					keywords2 = _keywords;
					if ((nint)obj >= array.Length)
					{
						break;
					}
					material.DisableKeyword(keywords2[obj2]);
					array = _keywords;
					obj2++;
					obj = obj2;
				}
				material.EnableKeyword(keywords2[keywordIndex]);
				return;
			}
		}
		string[] keywords3 = _keywords;
		object obj3 = 0;
		object obj4 = 0;
		bool flag;
		do
		{
			if ((nint)obj3 >= keywords3.Length)
			{
				return;
			}
			string[] keywords4 = _keywords;
			material.DisableKeyword(keywords4[obj4]);
			keywords3 = _keywords;
			obj4++;
			flag = _keywords != null;
			obj3 = obj4;
		}
		while (flag);
		throw new NullReferenceException();
	}

	private void CleanKeywords(Material material)
	{
		//IL_0013: Expected O, but got I4
		//IL_001c: Expected O, but got I4
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		string[] keywords = _keywords;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < keywords.Length)
		{
			string[] keywords2 = _keywords;
			material.DisableKeyword(keywords2[obj2]);
			keywords = _keywords;
			obj2++;
			obj = obj2;
		}
	}
}
public abstract class Property<T, U> : Property<T>
{
	public Property(Uniform uniform, string[] keywords)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
	}

	public abstract void SetValue(Material material, T valueM, U valueS);
}

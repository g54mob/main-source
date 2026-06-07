using System;
using System.Collections.Generic;
using Tyd;
using UnityEngine;

public abstract class DLCObject
{
	public List<Texture2D> ManufacturingIcons = new List<Texture2D>();

	public Dictionary<string, Dictionary<string, string>> Localizations = new Dictionary<string, Dictionary<string, string>>();

	public AssetBundle Bundle;

	public abstract string DLCName { get; }

	public virtual void Initialize(AssetBundle b, TydDocument meta)
	{
		Debug.Log("Loaded DLC: " + DLCName);
		Bundle = b;
		TydList child = meta.GetChild<TydList>("Furniture");
		if (child != null)
		{
			foreach (string childValue in child.GetChildValues())
			{
				GameObject obj = b.LoadAsset<GameObject>(childValue);
				ObjectDatabase.Instance.AddFurniture(obj);
			}
		}
		TydList child2 = meta.GetChild<TydList>("ManufacturingIcons");
		if (child2 == null)
		{
			return;
		}
		foreach (string childValue2 in child2.GetChildValues())
		{
			Texture2D item = b.LoadAsset<Texture2D>(childValue2);
			ManufacturingIcons.Add(item);
		}
	}

	public TydDocument GetTranslation(string language)
	{
		TextAsset textAsset = Bundle.LoadAsset<TextAsset>("Translation" + language);
		if (textAsset != null)
		{
			return TydFile.FromContent(textAsset.text, DLCName + "/" + language).DocumentNode;
		}
		return null;
	}

	public virtual IEnumerable<SoftwareType> EmbeddedSoftwareTypes()
	{
		yield break;
	}

	public virtual IEnumerable<CompanyType> EmbeddedCompanyTypes()
	{
		yield break;
	}

	public virtual IEnumerable<ValueTuple<string, RandomNameGenerator>> EmbeddedNameGenerators()
	{
		yield break;
	}

	public virtual IEnumerable<Texture2D> GetManufacturingIcons()
	{
		yield break;
	}

	public virtual WriteDictionary Serialize(GameReader.NewLoadMode mode)
	{
		return null;
	}

	public virtual void Deserialize(WriteDictionary d)
	{
	}
}

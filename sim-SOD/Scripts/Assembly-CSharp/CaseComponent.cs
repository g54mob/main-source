using System.Runtime.CompilerServices;
using UnityEngine;

public class CaseComponent
{
	public delegate void DiscoveredThis(CaseComponent discovered);

	public delegate void NewName();

	public delegate void NewSprite();

	public string name;

	public bool isFound;

	public Sprite iconSprite;

	public event DiscoveredThis OnDiscoveredThis
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event NewName OnNewName
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event NewSprite OnNewSprite
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public virtual void SetFound(bool newVal)
	{
	}

	public virtual string GetIdentifier()
	{
		return null;
	}

	public virtual void OnDiscovery()
	{
	}

	public virtual void UpdateName()
	{
	}

	public virtual string GenerateName()
	{
		return null;
	}

	public virtual string FoundAtName()
	{
		return null;
	}

	public virtual string GenerateNameSuffix()
	{
		return null;
	}

	public void SetNewIcon(Sprite newLarge)
	{
	}
}

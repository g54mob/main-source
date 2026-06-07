using System;
using UnityEngine;

public class SpriteLightGroup : MonoBehaviour
{
	public string nameOverride;

	public GameObject prefabDestination;

	[SerializeField]
	private int groupID;

	public SpriteLight[] ChildLights { get; private set; }

	public int GroupID
	{
		get
		{
			return groupID;
		}
		set
		{
			if (!Application.isEditor || Application.isPlaying)
			{
				throw new InvalidOperationException("SpriteLightGroup should only be modified in the editor");
			}
			groupID = value;
		}
	}

	public string GroupName
	{
		get
		{
			if (!string.IsNullOrEmpty(nameOverride))
			{
				return nameOverride;
			}
			return base.name;
		}
	}

	public void EnumerateChildLights()
	{
		ChildLights = GetComponentsInChildren<SpriteLight>();
		SpriteLight[] childLights = ChildLights;
		foreach (SpriteLight obj in childLights)
		{
			obj.ParentGroup = this;
			obj.groupID = groupID;
		}
	}
}

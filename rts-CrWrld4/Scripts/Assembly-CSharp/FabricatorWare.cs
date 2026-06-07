using System;
using NBT.Tags;
using UnityEngine;

public class FabricatorWare : MonoBehaviour
{
	private MeshFilter meshFilter;

	private Mesh mesh;

	[NonSerialized]
	public bool meta;

	[NonSerialized]
	public int heightInFabricatorPlan;

	[NonSerialized]
	public int creationTime;

	[NonSerialized]
	public int padPos;

	[NonSerialized]
	public int sectionNumber;

	public const float size = 0.25f;

	private int _wareType;

	public int wareType
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public void Awake()
	{
	}

	public void OnDestroy()
	{
	}

	public void ReadData(Tag data)
	{
	}

	public TagCompound WriteData()
	{
		return null;
	}
}

using System;
using TMPro;
using UnityEngine;

[Serializable]
public class Section : MonoBehaviour
{
	[SerializeField]
	private Transform centerSphere;

	[SerializeField]
	protected TextMeshPro debugLabel;

	[SerializeField]
	private float sphereYOffset = 0.1f;

	private Vector2Int _003CGridPos_003Ek__BackingField;

	private Vector3 _003CCenter_003Ek__BackingField;

	private bool _003CTilePlacedInSection_003Ek__BackingField;

	private SectionManager _003CSectionManager_003Ek__BackingField;

	protected int seed;

	public Vector2Int GridPos
	{
		get
		{
			return _003CGridPos_003Ek__BackingField;
		}
		private set
		{
			_003CGridPos_003Ek__BackingField = value;
		}
	}

	public Vector3 Center
	{
		get
		{
			return _003CCenter_003Ek__BackingField;
		}
		private set
		{
			_003CCenter_003Ek__BackingField = value;
		}
	}

	private Vector2 WorldPosition => new Vector2(base.transform.position.x, base.transform.position.z);

	public bool TilePlacedInSection
	{
		get
		{
			return _003CTilePlacedInSection_003Ek__BackingField;
		}
		private set
		{
			_003CTilePlacedInSection_003Ek__BackingField = value;
		}
	}

	protected SectionManager SectionManager
	{
		get
		{
			return _003CSectionManager_003Ek__BackingField;
		}
		private set
		{
			_003CSectionManager_003Ek__BackingField = value;
		}
	}

	public void Setup(Vector2Int gridPos, SectionManager sectionManager)
	{
		GridPos = gridPos;
		SectionManager = sectionManager;
		seed = gridPos.GetHashCode() + sectionManager.Seed;
		UnityEngine.Random.InitState(seed);
		float x = UnityEngine.Random.Range((0f - sectionManager.SectionSize) / 2f, sectionManager.SectionSize / 2f) * sectionManager.SpreadRandomness + WorldPosition.x;
		float z = UnityEngine.Random.Range((0f - sectionManager.SectionSize) / 2f, sectionManager.SectionSize / 2f) * sectionManager.SpreadRandomness + WorldPosition.y;
		Center = new Vector3(x, 0f, z);
		SpecificSetup();
		Randomizer.RandomizeSeed();
		centerSphere.transform.position = Center + Vector3.up * sphereYOffset;
		base.name = $"Section ({gridPos.x}|{gridPos.y})";
	}

	public void PlaceTile(Tile tile)
	{
		if ((bool)tile)
		{
			PlaceTile();
		}
	}

	public void PlaceTile()
	{
		TilePlacedInSection = true;
	}

	protected virtual void SpecificSetup()
	{
	}

	public virtual void DebugInfluence(float distance, float influence)
	{
		debugLabel.text = $"{GridPos}\nDist: {distance:0.00}\nInfl: {influence:0.00}";
	}

	public virtual void Clear()
	{
	}
}

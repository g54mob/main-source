using System.Collections.Generic;
using UnityEngine;

public class BuildingStructure : MonoBehaviour
{
	public List<BuildingBehaviour> BuildingBehaviours;

	public List<SpriteRenderer> _formSprites;

	public List<SpriteRenderer> _detailSprites;

	public List<SpriteRenderer> _shadowSprites;

	public List<GameObject> _blueprintExludes;

	public List<GameObject> _buildOnlyObjects;

	public List<Behaviour> _buildOnlyBehaviours;

	public List<Pipe> Pipes;

	public RadiusProvider RadiusProvider;

	public Material _blueprintValidMat;

	public Material _blueprintInvalidMat;

	public float _detailGrowthStartSize;

	public float _detailGrowthDuration;

	public float _buildShake;

	public Material _formMat;

	public Material _shadowMat;

	public BoxCollider2D AreaBox;

	public Transform ParentContainer;

	public void Initiate()
	{
	}

	public void OnDeconstruct()
	{
	}

	public void SetConstruction(Construction construction)
	{
	}

	public void SetBlueprint(Blueprint blueprint, bool valid = true)
	{
	}

	public void SetBlueprintValidity(Blueprint blueprint, bool valid = true)
	{
	}

	public void SetAlreadyBuilt()
	{
	}

	public void DoBuild()
	{
	}

	public void Shake(float amount)
	{
	}

	public bool HasPipe(Pipe pipe)
	{
		return false;
	}

	public void ClearAllPipeConnections()
	{
	}

	public void Move(Vector2 position)
	{
	}

	public List<BuildingSelectorData> GetSelectorTransforms()
	{
		return null;
	}
}

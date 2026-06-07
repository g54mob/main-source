using UnityEngine;

public class Obj_TerritoryArea_Circle : MonoBehaviour
{
	[SerializeField]
	private GridSystem.eTerritoryType territoryType;

	[SerializeField]
	private bool doRandomBorder;

	[Range(0f, 1f)]
	[SerializeField]
	private float borderRemoveRate;

	public float radius;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnRequestInitializeTerritory()
	{
	}
}

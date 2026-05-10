using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class CheckoutGridSize : MonoBehaviour
{
	[Header("Cell Prefab (örn. Cube, localScale = 0.1,0.1,0.1)")]
	public GameObject cellPrefab;

	[Header("Grid (X,Z)")]
	public Vector2Int gridXZ;

	[Header("Yerleşim")]
	[Tooltip("KÜP-KÜP arası kenar-kenar boşluk. Örn: cube=0.1, gap=0.1 → merkezler 0.2 aralıkla.")]
	public float gap;

	public float yOffset;

	public bool pivotCenter;

	public bool checkerColors;

	public bool removeColliders;

	[Header("Otomasyon")]
	public bool autoRegenerate;

	[SerializeField]
	[HideInInspector]
	private Transform container;

	private const string kContainerName = "__CheckoutGridCells";

	[ContextMenu("Regenerate")]
	public void Regenerate()
	{
	}

	[ContextMenu("Clear")]
	public void Clear()
	{
	}

	private void EnsureContainer()
	{
	}

	private void FindContainer()
	{
	}

	private Transform CreateCell()
	{
		return null;
	}

	private static List<Transform> GetChildren(Transform parent)
	{
		return null;
	}

	private static void SafeDestroyGO(GameObject go)
	{
	}

	private static void SafeDestroyComponent(Component comp)
	{
	}

	private static void ApplyChecker(Transform t, bool light)
	{
	}
}

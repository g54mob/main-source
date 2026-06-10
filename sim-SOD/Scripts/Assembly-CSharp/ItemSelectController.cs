using System.Collections.Generic;
using UnityEngine;

public class ItemSelectController : MonoBehaviour
{
	[Header("References")]
	public RectTransform pageRect;

	public WindowContentController wcc;

	[Header("Prefabs")]
	public GameObject selectPrefab;

	private List<ItemSelectButtonController> spawned;

	public void Setup(WindowContentController newWcc)
	{
	}
}

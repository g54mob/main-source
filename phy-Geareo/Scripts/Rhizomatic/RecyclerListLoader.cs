using System.Collections.Generic;
using Rhizomatic.Pooling;
using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class RecyclerListLoader : MonoBehaviour
{
	public RectTransform viewport;

	public RectTransform container;

	public RecyclerListItem prefab;

	public bool notScenePrefab;

	public int bottomMargin;

	public int topMargin;

	public int itemHeight;

	public int itemsCount;

	private ObjectPool _pool;

	public RecyclerItemBuilder itemBuilder;

	private bool dirty;

	public List<RecyclerListItem> currentItems { get; }

	public ObjectPool pool => null;

	private void Awake()
	{
	}

	public void ForceUpdate()
	{
	}

	public void ForceUpdateContainer()
	{
	}

	private void Update()
	{
	}

	public void MarkDirty()
	{
	}
}

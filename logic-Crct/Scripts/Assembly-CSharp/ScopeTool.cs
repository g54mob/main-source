using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScopeTool : ToolBase
{
	[Header("Scope Box")]
	public ScopeBox scopeBox;

	public GameObject legendPrefab;

	public Transform legendArea;

	public Button addScopeButton;

	public List<ScopeLegend> scopeLegends;

	private bool addingScope;

	private readonly int compMask;

	private Ray ray;

	private RaycastHit hit;

	private new void Awake()
	{
	}

	public override void OnClick()
	{
	}

	public void AddScope()
	{
	}

	public void Clear()
	{
	}

	private void AddComponentToScope(BaseComponent c)
	{
	}

	public override void Cancel()
	{
	}

	public override void Update()
	{
	}
}

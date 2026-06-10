using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class RainSheetController : MonoBehaviour
{
	[Serializable]
	public class RainSheet
	{
		public Transform rainSheetTransform;

		public MeshRenderer renderer;
	}

	[Header("Components")]
	[ReorderableList]
	public List<RainSheet> sheets;

	[Header("Settings")]
	public bool indoorRaycast;

	public int raycastsPerFrame;

	private int rainBlockOnlyMask;

	private int rainBlockAndRoomMeshMask;

	private int sheetCursor;

	public float rainSheetHeight;

	public bool snowMode;

	public Material material;

	public Material snowMaterial;

	private void Start()
	{
	}

	public void SetSnowMode(bool val, bool forceUpdate = false)
	{
	}

	public void SetEnabled(bool val)
	{
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
	}
}

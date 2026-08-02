using System;
using UnityEngine;

public class CubeController : MonoBehaviour
{
	[Serializable]
	public class CubeColor
	{
		public Color color = Color.white;

		public UltimateRadialButtonInfo buttonInfo;
	}

	public CubeColor[] cubeColors;

	private Transform onMouseDownTransform;

	private Renderer selectedRenderer;

	private void Start()
	{
		for (int i = 0; i < cubeColors.Length; i++)
		{
			cubeColors[i].buttonInfo.id = i;
			UltimateRadialMenu.RegisterToRadialMenu("ObjectExample", UpdateCubeColor, cubeColors[i].buttonInfo);
		}
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo))
			{
				onMouseDownTransform = hitInfo.transform;
			}
			else if (UltimateRadialMenu.GetUltimateRadialMenu("ObjectExample").RadialMenuActive && UltimateRadialMenu.GetUltimateRadialMenu("ObjectExample").CurrentButtonIndex < 0)
			{
				UltimateRadialMenu.GetUltimateRadialMenu("ObjectExample").DisableRadialMenu();
			}
		}
		if (Input.GetMouseButtonUp(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo2) && hitInfo2.transform == onMouseDownTransform)
		{
			selectedRenderer = hitInfo2.transform.GetComponent<Renderer>();
			Vector3 position = Camera.main.WorldToScreenPoint(hitInfo2.transform.position);
			UltimateRadialMenu.GetUltimateRadialMenu("ObjectExample").SetPosition(position);
			if (!UltimateRadialMenu.GetUltimateRadialMenu("ObjectExample").RadialMenuActive)
			{
				UltimateRadialMenu.GetUltimateRadialMenu("ObjectExample").EnableRadialMenu();
			}
		}
	}

	public void UpdateCubeColor(int id)
	{
		if (!(selectedRenderer == null))
		{
			selectedRenderer.material.color = cubeColors[id].color;
		}
	}
}

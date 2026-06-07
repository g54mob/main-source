using System.Collections.Generic;
using UnityEngine;

public class Accessibility_StopMovingBG_SwapMaterial : MonoBehaviour
{
	[SerializeField]
	private List<MeshRenderer> meshRenderers;

	[SerializeField]
	private Material material_Moving;

	[SerializeField]
	private Material material_StopMoving;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	private void OnGameSettingChanged()
	{
	}
}

using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActiveCodebreakerController : MonoBehaviour
{
	public InteractableController controller;

	public TextMeshPro text;

	public bool cracked;

	public MeshRenderer rend;

	public List<Material> activeMaterials;

	private void Update()
	{
	}

	public void OnCrack(string codeStr)
	{
	}
}

using System.Collections.Generic;
using UnityEngine;

public class SurviveModeDisplay : MonoBehaviour
{
	public GameObject imagePrefab;

	public GameObject container;

	public Transform imageContainer;

	public GameObject creeperPPContainer;

	private int lastBaseCount;

	private List<HoldBaseImage> holdImages;

	public void LateUpdate()
	{
	}

	private void CreateImages()
	{
	}

	private void RefreshImages()
	{
	}

	public static void DestroyChildren(Transform transform)
	{
	}
}

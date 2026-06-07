using System.Collections.Generic;
using DentedPixel;
using UnityEngine;

public class PerformanceTests : MonoBehaviour
{
	public bool debug;

	public GameObject bulletPrefab;

	private LeanPool bulletPool;

	private Dictionary<GameObject, int> animIds;

	public float shipSpeed;

	private float shipDirectionX;

	private void Start()
	{
	}

	private void Update()
	{
	}
}

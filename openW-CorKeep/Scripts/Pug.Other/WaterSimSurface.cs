using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class WaterSimSurface : MonoBehaviour
{
	[Serializable]
	public enum Type
	{
		Surface = 0,
		Blocker = 1
	}

	public static readonly List<WaterSimSurface> instances = new List<WaterSimSurface>();

	public Type type;

	public Renderer renderer { get; private set; }

	private void Awake()
	{
		renderer = GetComponent<Renderer>();
	}

	private void OnEnable()
	{
		instances.Add(this);
	}

	private void OnDisable()
	{
		instances.Remove(this);
	}
}

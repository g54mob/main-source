using System.Collections.Generic;
using UnityEngine;

public class IgnoreColliderForBuilding : MonoBehaviour
{
	public static List<Collider2D> IgnoredColliders;

	public List<Collider2D> Colliders;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}
}

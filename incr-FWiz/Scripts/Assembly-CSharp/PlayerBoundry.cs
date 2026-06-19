using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundry : MonoBehaviour
{
	public string ID;

	[SerializeField]
	private Collider2D _collider;

	private static List<PlayerBoundry> _activeMapBarriers;

	private static List<Collider2D> _activeMapBarriersColliders;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public static List<Collider2D> GetColliders()
	{
		return null;
	}

	public static List<PlayerBoundry> GetMapBarriers()
	{
		return null;
	}
}

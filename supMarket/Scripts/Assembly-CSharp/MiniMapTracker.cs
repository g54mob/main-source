using System.Collections.Generic;
using UnityEngine;

public class MiniMapTracker : MonoBehaviour
{
	private Transform m_Player;

	[SerializeField]
	private GameObject m_TrackerArrow;

	public List<Color> m_ArrowColors;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnLocalPlayerUpdated(PlayerInstance _instance)
	{
	}

	private void Start()
	{
	}

	private void LateUpdate()
	{
	}
}

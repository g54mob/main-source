using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class NetworkMinimapTracker : MonoBehaviourPunCallbacks
{
	public List<Color> m_ArrowColors;

	[SerializeField]
	private GameObject m_TrackerArrow;

	private void Start()
	{
	}

	private void LateUpdate()
	{
	}
}

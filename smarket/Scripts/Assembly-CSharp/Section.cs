using System;
using UnityEngine;

public class Section : MonoBehaviour
{
	[Header("Objects")]
	[SerializeField]
	private GameObject[] m_ToBeDisabled;

	[SerializeField]
	private GameObject[] m_ToBeEnabled;

	[Header("Animation")]
	[SerializeField]
	private float m_AnimationHeightDifference;

	[SerializeField]
	private float m_Speed;

	[Header("DoorMechanic")]
	public bool isFrontSection;

	public bool isDoor;

	public GameObject frontWall;

	public Action<int> onUpgradeAnimationFinished;

	public void OpenSection(int id, bool playAnimation = true)
	{
	}
}

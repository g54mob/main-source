using UnityEngine;

public class StorageSection : MonoBehaviour
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

	public void OpenSection(bool playAnimation = true)
	{
	}
}

using UnityEngine;

public class Sponge : MonoBehaviour
{
	[SerializeField]
	private GameObject m_SqueegeeModel;

	[SerializeField]
	private Vector3 m_EnablePosition;

	[SerializeField]
	private Vector3 m_DisablePosition;

	[SerializeField]
	private Vector3 m_EnableRotation;

	[SerializeField]
	private Vector3 m_DisableRotation;

	[SerializeField]
	private float m_Yposition;

	[SerializeField]
	private float m_Xrotation;

	[SerializeField]
	private Animator m_Animator;

	[SerializeField]
	private float m_MaxRaycastDistance;

	private bool m_IsEnabled;

	private bool m_IsCleaning;

	public GameObject SqueegeeModel => null;

	public bool IsEnabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public void FakeOpenAnimate(bool isOpen, bool willAnimate)
	{
	}

	public void OpenAnimate(bool isOpen, bool willAnimate)
	{
	}

	public void CleaningAnimation(bool down)
	{
	}
}

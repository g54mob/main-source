using UnityEngine;

public class Mop : MonoBehaviour
{
	[SerializeField]
	private GameObject m_MobModel;

	[SerializeField]
	private Vector3 m_EnablePosition;

	[SerializeField]
	private Vector3 m_DisablePosition;

	[SerializeField]
	private Vector3 m_EnableRotation;

	[SerializeField]
	private Vector3 m_DisableRotation;

	[SerializeField]
	private Vector3 m_AnimationStartPosition;

	[SerializeField]
	private Vector3 m_AnimationStartRotation;

	[SerializeField]
	private float m_TransitionSpeed;

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

	private bool m_IsDown;

	public GameObject MobModel => null;

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

	public void OpenAnimate(bool isOpen, bool willAnimate)
	{
	}

	public void FakeOpenAnimate(bool isOpen, bool willAnimate)
	{
	}

	public void CleaningAnimation(bool down)
	{
	}
}

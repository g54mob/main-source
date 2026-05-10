using UnityEngine;

public class TrashBag : MonoBehaviour
{
	[SerializeField]
	private GameObject m_TrashBagModel;

	[SerializeField]
	private Vector3 m_EnablePosition;

	[SerializeField]
	private Vector3 m_DisablePosition;

	[SerializeField]
	private Vector3 m_EnableRotation;

	[SerializeField]
	private Vector3 m_DisableRotation;

	private bool m_IsEnabled;

	private bool m_IsJanitor;

	public GameObject TrashBagModel => null;

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

	public bool IsJanitor
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public void MoveToTrashBag(Garbage garbage)
	{
	}

	public void JanitorMoveToTrashBag(Garbage garbage)
	{
	}

	private void OpenAnimate(bool isOpen)
	{
	}

	private void OpenAnimateJanitor(bool isOpen)
	{
	}
}

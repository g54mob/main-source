using UnityEngine;

public class Door : MonoBehaviour
{
	private bool isLocked;

	[SerializeField]
	private float openDst = 0.2f;

	[SerializeField]
	private float closeDst = 0.3f;

	private Animator anim;

	public BoxCollider2D bc2d { get; private set; }

	public bool IsLocked
	{
		get
		{
			return isLocked;
		}
		set
		{
			isLocked = value;
			bc2d.enabled = value;
			if (IsLocked)
			{
				anim.Play("Close");
			}
		}
	}

	private void Awake()
	{
		anim = GetComponent<Animator>();
		bc2d = GetComponent<BoxCollider2D>();
	}

	private void Update()
	{
		if (IsLocked || anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
		{
			return;
		}
		float num = float.MaxValue;
		foreach (PlayerController player in PlayerManager.Instance.Players)
		{
			float magnitude = (player.transform.position - base.transform.position).magnitude;
			if (magnitude < num)
			{
				num = magnitude;
			}
		}
		if (num < openDst)
		{
			anim.Play("Open");
		}
		else if (num > closeDst)
		{
			anim.Play("Close");
		}
	}
}

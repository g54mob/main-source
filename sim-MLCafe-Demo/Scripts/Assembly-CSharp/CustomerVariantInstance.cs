using UnityEngine;

public class CustomerVariantInstance : MonoBehaviour
{
	[SerializeField]
	private new string name;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private Transform bone_hand;

	public void SetName(string name)
	{
		this.name = name;
	}

	public string GetName()
	{
		return name;
	}

	public Animator GetAnimator()
	{
		return animator;
	}

	public Transform GetHandBone()
	{
		return bone_hand;
	}
}

using UnityEngine;

public class SteerableBlockGizmo : MonoBehaviour
{
	private GameObject rightArrow;

	private GameObject leftArrow;

	private void Awake()
	{
		rightArrow = base.transform.Find("RightArrow").gameObject;
		leftArrow = base.transform.Find("LeftArrow").gameObject;
		leftArrow.SetActive(value: false);
	}

	public void SetArrowDirection(bool isRight)
	{
		rightArrow.SetActive(isRight);
		leftArrow.SetActive(!isRight);
	}
}

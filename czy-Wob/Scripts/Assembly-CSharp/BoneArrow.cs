using UnityEngine;

public class BoneArrow : MonoBehaviour
{
	public BonesLoader bonesRef;

	public bool pageUp = true;

	public CoreButtonUnityGUI buttonRef;

	public void OnClick()
	{
		if (pageUp)
		{
			PageUp();
		}
		else
		{
			PageDown();
		}
	}

	private void PageUp()
	{
		bonesRef.PageUp();
	}

	private void PageDown()
	{
		bonesRef.PageDown();
	}

	public void LockArrow()
	{
		buttonRef.interactable = false;
		base.gameObject.SetActive(value: false);
	}

	public void UnlockArrow()
	{
		base.gameObject.SetActive(value: true);
		buttonRef.interactable = true;
	}
}

using UnityEngine;

public class EndPop : MonoBehaviour
{
	public void Pop()
	{
		base.transform.localScale = new Vector3(1f, 1f, 1f);
	}

	public void Disapear()
	{
		base.transform.localScale = new Vector3(0f, 0f, 1f);
	}
}

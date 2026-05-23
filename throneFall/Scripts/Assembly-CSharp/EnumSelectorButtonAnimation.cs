using UnityEngine;

public class EnumSelectorButtonAnimation : MonoBehaviour
{
	public Transform decreaseB;

	public Transform increaseB;

	private void OnEnable()
	{
		decreaseB.localScale = Vector3.zero;
		increaseB.localScale = Vector3.zero;
	}
}

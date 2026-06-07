using UnityEngine;

public class ChildOffsetter : MonoBehaviour
{
	[SerializeField]
	private float _offset;

	public void UpdateChildren()
	{
		int num = 0;
		for (int i = 0; i < base.transform.childCount; i++)
		{
			Transform child = base.transform.GetChild(i);
			if (child.gameObject.activeSelf)
			{
				child.localPosition = Vector3.up * ((float)num * _offset);
				num++;
			}
		}
	}
}

using UnityEngine;

public class WindRotate : MonoBehaviour
{
	private void Update()
	{
		base.transform.Rotate(Time.deltaTime * 200f, 0f, 0f);
	}
}

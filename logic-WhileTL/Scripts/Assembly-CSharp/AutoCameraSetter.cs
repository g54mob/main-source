using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class AutoCameraSetter : MonoBehaviour
{
	private void Start()
	{
		GetComponent<Canvas>().worldCamera = Camera.main;
	}
}

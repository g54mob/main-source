using UnityEngine;

public class MouseDerail : MonoBehaviour
{
	private void Update()
	{
		if ((Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) && Input.GetMouseButtonDown(1) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo, 200f) && (bool)hitInfo.transform.GetComponent<TrainCar>())
		{
			hitInfo.transform.GetComponent<TrainCar>().Derail();
		}
	}
}

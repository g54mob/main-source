using System.Collections;
using UnityEngine;

public class MenuScreen : MonoBehaviour
{
	public bool IsOpen { get; set; }

	private IEnumerator Start()
	{
		yield return WaitFor.EndOfFrame;
		RectTransform component = GetComponent<RectTransform>();
		component.localPosition = new Vector3(0.5f, 0f, component.localPosition.z);
	}

	public void ResetButtonStates()
	{
	}
}

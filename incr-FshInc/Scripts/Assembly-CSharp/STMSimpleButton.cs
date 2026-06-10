using UnityEngine;
using UnityEngine.Events;

public class STMSimpleButton : MonoBehaviour
{
	public UnityEvent buttonEvent;

	public Vector3 normalSize = Vector3.one;

	public Vector3 mouseoverSize = Vector3.one;

	public Vector3 clickSize = Vector3.one;

	public void OnMouseEnter()
	{
		base.transform.localScale = mouseoverSize;
	}

	public void OnMouseExit()
	{
		base.transform.localScale = normalSize;
	}

	public void OnMouseDown()
	{
		base.transform.localScale = clickSize;
		buttonEvent.Invoke();
	}

	public void OnMouseUp()
	{
		base.transform.localScale = mouseoverSize;
	}
}

using UnityEngine;

public class OutlineSelectObject : MonoBehaviour
{
	private RaycastHit hit;

	private Ray ray;

	public Transform obj;

	private int layer;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Reset();
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit) && obj == null)
			{
				obj = hit.transform;
				layer = obj.gameObject.layer;
				obj.gameObject.layer = LayerMask.NameToLayer("Outline");
				MonoBehaviour.print(obj.gameObject.name + " selected");
			}
		}
		if (Input.GetMouseButtonDown(1))
		{
			Reset();
		}
	}

	private void Reset()
	{
		if (obj != null)
		{
			obj.gameObject.layer = layer;
			obj = null;
		}
	}
}

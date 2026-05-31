using UnityEngine;

public class cam : MonoBehaviour
{
	public LayerMask mask;

	public LayerMask mask2;

	public float dist;

	private void Update()
	{
		if (!Input.GetButtonDown("use") || !Physics.Raycast(new Ray(base.transform.position, base.transform.forward), out var hitInfo, dist, mask))
		{
			return;
		}
		GameObject gameObject = hitInfo.transform.gameObject;
		if (gameObject.tag == "slomokno")
		{
			if (Physics.Raycast(new Ray(base.transform.position, base.transform.forward), out var hitInfo2, dist, mask2))
			{
				if (hitInfo2.transform.GetComponent<vkl>() != null)
				{
					hitInfo2.transform.GetComponent<vkl>().SendMessage("use");
				}
				else
				{
					gameObject.GetComponent<dver>().SendMessage("use");
				}
			}
			else
			{
				gameObject.GetComponent<dver>().SendMessage("use");
			}
		}
		else if (gameObject.GetComponent(gameObject.name) != null)
		{
			gameObject.GetComponent(gameObject.name).SendMessage("use");
		}
	}
}

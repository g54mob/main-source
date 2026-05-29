using UnityEngine;

public class Wftpscam : MonoBehaviour
{
	public GameObject cam;

	public GameObject cam2;

	private RaycastHit hit;

	public pl pl;

	private void Update()
	{
		if (Physics.Raycast(new Ray(cam.transform.position, base.transform.position - cam.transform.position), out hit, 1f))
		{
			cam2.transform.position = hit.point + hit.normal * 0.1f;
		}
		else
		{
			cam2.transform.localPosition = new Vector3(0f, 0f, 0f);
		}
		if (pl.MY > 60f)
		{
			pl.MY = 60f;
		}
	}
}

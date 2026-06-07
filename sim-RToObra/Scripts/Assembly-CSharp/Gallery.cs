using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Gallery : MonoBehaviour
{
	public Player player;

	public GameObject sky;

	public MeshRenderer planeRenderer;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			StartCoroutine(SnapAll());
		}
	}

	private IEnumerator SnapAll()
	{
		List<GameObject> gos = new List<GameObject>();
		sky.SetActive(false);
		planeRenderer.enabled = false;
		for (int i = 0; i < 100; i++)
		{
			GameObject gameObject = GameObject.Find(string.Format("crew{0:##}", i));
			if (gameObject == null)
			{
				break;
			}
			gos.Add(gameObject);
			gameObject.SetActive(false);
		}
		Vector3 playerOffset = player.footPos - gos[0].transform.position + new Vector3(0f, 0.01f, 0f);
		int c = 0;
		foreach (GameObject go in gos)
		{
			go.SetActive(true);
			player.footPos = go.transform.position + playerOffset;
			yield return new WaitForSeconds(1f);
			ScreenCap.TakeScreenshot(string.Format("Gallery{0:00}.png", c));
			c++;
			yield return new WaitForSeconds(0.1f);
			go.SetActive(false);
		}
	}
}

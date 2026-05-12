using System.Collections;
using UnityEngine;

public class lampa : MonoBehaviour
{
	public Transform bone;

	public Vector3[] rot;

	public int x;

	private bool a;

	private void Update()
	{
		bone.localEulerAngles = new Vector3(Mathf.LerpAngle(bone.localEulerAngles.x, rot[x].x, Time.deltaTime * 1f), Mathf.LerpAngle(bone.localEulerAngles.y, rot[x].y, Time.deltaTime * 1f), 0f);
	}

	public void use()
	{
		x++;
		if (x >= rot.Length)
		{
			x = 0;
		}
		if (!a && x == 4)
		{
			a = true;
			StartCoroutine(cor());
		}
	}

	private IEnumerator cor()
	{
		yield return new WaitForSeconds(3f);
		base.gameObject.GetComponent<AudioSource>().Play();
	}
}

using System;
using UnityEngine;

public class LiveRainDrop : MonoBehaviour
{
	public GameObject splashGo;

	public bool falling;

	[NonSerialized]
	public float lifetime;

	private Renderer dropRenderer;

	private float age;

	private bool splashing;

	private void OnEnable()
	{
		if (dropRenderer == null)
		{
			dropRenderer = GetComponent<Renderer>();
		}
		age = 0f;
		splashing = false;
		splashGo.transform.localScale = Vector3.one;
		dropRenderer.enabled = true;
	}

	private void Update()
	{
		age += Clock.play.deltaTime;
		if (age > lifetime)
		{
			falling = false;
			base.gameObject.SetActive(false);
			return;
		}
		bool flag = splashing;
		splashing = age > lifetime * 0.25f;
		if (!flag && splashing)
		{
			dropRenderer.enabled = false;
		}
		float t = Mathf.Pow(age / lifetime, 2f);
		float y = Mathf.Lerp(1f, 0.1f, t);
		float num = Mathf.Lerp(1f, 2f, t);
		splashGo.transform.localScale = new Vector3(num, y, num);
	}
}

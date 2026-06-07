using System;
using UnityEngine;
using UnityEngine.UI;

public class ImagePulse : MonoBehaviour
{
	public Gradient Pulse;

	public float Speed = 1f;

	[NonSerialized]
	private Graphic _img;

	private void Awake()
	{
		_img = GetComponent<Graphic>();
	}

	private void Update()
	{
		_img.color = Pulse.Evaluate(Time.realtimeSinceStartup * Speed % 1f);
	}
}

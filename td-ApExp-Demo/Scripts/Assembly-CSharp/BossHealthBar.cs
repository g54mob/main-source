using System;
using UnityEngine;

public class BossHealthBar : MonoBehaviour
{
	private bool isEnabled;

	[field: NonSerialized]
	public Tweener Tweener { get; private set; }

	[field: NonSerialized]
	public BarController BarController { get; private set; }

	private void Start()
	{
		Tweener = GetComponent<Tweener>();
		BarController = GetComponent<BarController>();
	}

	public void Activate()
	{
		if (!isEnabled)
		{
			isEnabled = true;
			Tweener.Move(isToEndPos: true);
		}
	}

	public void Deactivate()
	{
		if (isEnabled)
		{
			isEnabled = false;
			Tweener.Move(isToEndPos: false);
		}
	}
}

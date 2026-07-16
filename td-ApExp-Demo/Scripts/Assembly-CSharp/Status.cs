using System;
using UnityEngine;

public class Status : MonoBehaviour
{
	public Unit unit;

	[NonSerialized]
	public bool isHidden;

	private bool statusActive;

	public void Initialize(Unit unit)
	{
		this.unit = unit;
	}

	public void SetIcon(bool active)
	{
		if (active)
		{
			if (!isHidden)
			{
				base.gameObject.SetActive(value: true);
			}
			statusActive = true;
		}
		else
		{
			base.gameObject.SetActive(value: false);
			statusActive = false;
		}
	}

	public void HideIcon(bool hide)
	{
		if (hide)
		{
			base.gameObject.SetActive(value: false);
			isHidden = true;
		}
		else if (!hide && statusActive)
		{
			base.gameObject.SetActive(value: true);
			isHidden = false;
		}
	}
}

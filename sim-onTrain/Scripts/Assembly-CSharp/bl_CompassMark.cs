using System;
using UnityEngine;

public class bl_CompassMark : MonoBehaviour
{
	[Serializable]
	public enum ActivationType
	{
		OnEnable = 0,
		OnTrigger = 1
	}

	public ActivationType m_ActivationType;

	public Sprite Icon;

	public Color IconColor = Color.white;

	private bool MarkSet;

	private CompassMark Mark => new CompassMark
	{
		Target = base.transform,
		Icon = Icon,
		IconColor = IconColor
	};

	private void Start()
	{
		if (m_ActivationType == ActivationType.OnEnable)
		{
			if (!MarkSet)
			{
				CompassMarkEvent.SetCompassMark(Mark);
				MarkSet = true;
			}
			else
			{
				CompassMarkEvent.ShowMark(base.transform, show: true);
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (m_ActivationType == ActivationType.OnTrigger && other.transform.tag == "Player")
		{
			CompassMarkEvent.SetCompassMark(Mark);
			MarkSet = true;
		}
	}

	private void OnDestroy()
	{
		if (MarkSet)
		{
			CompassMarkEvent.DestroyMark(base.transform);
		}
	}

	private void OnDisable()
	{
		if (MarkSet)
		{
			CompassMarkEvent.ShowMark(base.transform, show: false);
		}
	}
}

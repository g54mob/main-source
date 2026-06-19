using System.Collections.Generic;
using OUSystems.Basics.UI;
using UnityEngine;

public class SetActiveDuringHover : MonoBehaviour
{
	[SerializeField]
	private HoverListener _listener;

	public List<GameObject> Activate;

	public bool Reverse;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void OnHover()
	{
	}

	public void OnHoverEnd()
	{
	}
}

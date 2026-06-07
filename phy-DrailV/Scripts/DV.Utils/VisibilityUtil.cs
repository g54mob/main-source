using System;
using UnityEngine;

public class VisibilityUtil : MonoBehaviour
{
	public event Action<bool> VisibilityChanged;

	private void OnBecameVisible()
	{
		this.VisibilityChanged?.Invoke(obj: true);
	}

	private void OnBecameInvisible()
	{
		this.VisibilityChanged?.Invoke(obj: false);
	}
}

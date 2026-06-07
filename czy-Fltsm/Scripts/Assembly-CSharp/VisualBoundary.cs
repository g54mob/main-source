using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

public class VisualBoundary : MonoBehaviour
{
	[SerializeField]
	private float _offsetY = 0.25f;

	private static bool _visible = false;

	private static HashSet<VisualBoundary> _visualBoundaries = new HashSet<VisualBoundary>();

	protected virtual void Awake()
	{
		_visualBoundaries.Add(this);
		base.transform.position = base.transform.position.SetY(_offsetY);
		DisplayObject(_visible);
	}

	private void OnDestroy()
	{
		_visualBoundaries.Remove(this);
	}

	private void LateUpdate()
	{
		base.transform.position = base.transform.position.SetY(_offsetY);
		base.transform.rotation = Math3d.FlattenQuaternion(base.transform.rotation);
	}

	public static void Display(bool display)
	{
		if (display == _visible)
		{
			return;
		}
		_visible = display;
		foreach (VisualBoundary visualBoundary in _visualBoundaries)
		{
			visualBoundary.DisplayObject(_visible);
		}
	}

	public virtual void SetSize(float width, float height)
	{
	}

	public void DisplayObject(bool display)
	{
		base.gameObject.SetActive(display);
	}
}

using System;
using UnityEngine;

public class MouseOverPlaneEvents
{
	private Ray mouseRay;

	private bool isMouseOverPlane;

	public Camera Camera { get; set; }

	public Plane Plane { get; set; }

	public bool IsRunning { get; private set; }

	public event Action<Vector3> OnMouseEnterPlane;

	public event Action<Vector3> OnMouseOverPlane;

	public event Action OnMouseExitPlane;

	public event Func<bool> OnOverRestrictedZone;

	public event Action OnStop;

	public MouseOverPlaneEvents()
	{
		Camera = Camera.main;
		Plane = new Plane(Vector3.up, 0f);
		isMouseOverPlane = false;
		IsRunning = false;
	}

	public void Run()
	{
		mouseRay = Camera.ScreenPointToRay(Input.mousePosition);
		float enter;
		bool num = Plane.Raycast(mouseRay, out enter);
		bool flag = false;
		if (this.OnOverRestrictedZone != null)
		{
			flag = this.OnOverRestrictedZone();
		}
		if (num && !flag)
		{
			Vector3 point = mouseRay.GetPoint(enter);
			if (!isMouseOverPlane)
			{
				this.OnMouseEnterPlane?.Invoke(point);
				isMouseOverPlane = true;
			}
			this.OnMouseOverPlane?.Invoke(point);
		}
		else
		{
			MouseExitingPlane();
		}
		IsRunning = true;
	}

	public void Stop()
	{
		if (IsRunning)
		{
			MouseExitingPlane();
			this.OnStop?.Invoke();
			IsRunning = false;
		}
	}

	private void MouseExitingPlane()
	{
		if (isMouseOverPlane)
		{
			this.OnMouseExitPlane?.Invoke();
		}
		isMouseOverPlane = false;
	}
}

using System;
using UnityEngine;

public class MouseOverObjectEvents
{
	private Ray mouseRay;

	private RaycastHit objectRaycastHit;

	private GameObject currentObject;

	private GameObject lastObject;

	private int objectLayers;

	private string objectTagName;

	public Camera Camera { get; set; }

	public bool IsRunning { get; private set; }

	public event Action<RaycastHit> OnMouseEnterObject;

	public event Action<RaycastHit> OnMouseOverObject;

	public event Action<GameObject> OnMouseExitObject;

	public event Func<bool> OnOverRestrictedZone;

	public event Action OnStop;

	public MouseOverObjectEvents(int objectLayers, string objectTagName)
	{
		this.objectLayers = objectLayers;
		this.objectTagName = objectTagName;
		Camera = Camera.main;
		IsRunning = false;
	}

	public void Run()
	{
		mouseRay = Camera.ScreenPointToRay(Input.mousePosition);
		bool num = Physics.Raycast(mouseRay, out objectRaycastHit, 100f, objectLayers);
		bool flag = false;
		if (this.OnOverRestrictedZone != null)
		{
			flag = this.OnOverRestrictedZone();
		}
		if (num && objectRaycastHit.collider.CompareTag(objectTagName) && !flag)
		{
			currentObject = objectRaycastHit.collider.gameObject;
			if (currentObject != lastObject)
			{
				if (lastObject != null)
				{
					this.OnMouseExitObject?.Invoke(lastObject);
				}
				this.OnMouseEnterObject?.Invoke(objectRaycastHit);
				lastObject = currentObject;
			}
			this.OnMouseOverObject?.Invoke(objectRaycastHit);
		}
		else
		{
			MouseExitingObject();
		}
		IsRunning = true;
	}

	public void Stop()
	{
		if (IsRunning)
		{
			MouseExitingObject();
			this.OnStop?.Invoke();
			IsRunning = false;
		}
	}

	private void MouseExitingObject()
	{
		if (currentObject != null)
		{
			this.OnMouseExitObject?.Invoke(currentObject);
			currentObject = null;
		}
		lastObject = null;
	}
}

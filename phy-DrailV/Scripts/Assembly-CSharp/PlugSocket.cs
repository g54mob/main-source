using System;
using UnityEngine;

public class PlugSocket : MonoBehaviour
{
	[Header("General")]
	public string connectionTag;

	public string socketTag;

	public float snapInDuration = 0.5f;

	[Header("Components")]
	public Transform plugMarker;

	public Collider senseMarker;

	[Header("Visuals")]
	public GameObject snapIndicator;

	[Header("Audio")]
	public AudioClip plugInSound;

	public AudioClip unplugSound;

	private PluggableObject objectInsideTrigger;

	private bool currentObjectOutside;

	private float objectOutsideCooldown;

	public PluggableObject Plug { get; private set; }

	public bool IsFree => Plug == null;

	public bool IsPluggedIn
	{
		get
		{
			if (Plug != null)
			{
				return Plug.State == PluggableObject.PluggableState.PluggedIn;
			}
			return false;
		}
	}

	private bool SnapIndicator
	{
		get
		{
			if ((bool)snapIndicator)
			{
				return snapIndicator.activeInHierarchy;
			}
			return false;
		}
		set
		{
			if ((bool)snapIndicator && VRManager.IsVREnabled())
			{
				snapIndicator.SetActive(value);
			}
		}
	}

	public event Action<PluggableObject, PlugSocket> PluggedIn;

	public event Action<PluggableObject, PlugSocket> Unplugged;

	private void OnTriggerEnter(Collider other)
	{
		if (!(Plug == null))
		{
			return;
		}
		PluggableObject component = other.GetComponent<PluggableObject>();
		if (!(component != null) || !(component != objectInsideTrigger) || !CanAccept(component))
		{
			return;
		}
		objectInsideTrigger = component;
		objectOutsideCooldown = 0f;
		currentObjectOutside = false;
		if (!component.IsLocked)
		{
			if (!Connect(component))
			{
				SnapIndicator = true;
			}
		}
		else
		{
			SnapIndicator = true;
		}
	}

	private bool Connect(PluggableObject plug)
	{
		if (plug.StartSnappingTo(this))
		{
			Plug = plug;
			SnapIndicator = false;
			return true;
		}
		return false;
	}

	private void OnTriggerExit(Collider other)
	{
		if (!(objectInsideTrigger != null))
		{
			return;
		}
		PluggableObject component = other.GetComponent<PluggableObject>();
		if (component != null && component == objectInsideTrigger)
		{
			SnapIndicator = false;
			if (component.yankOutOfHand)
			{
				objectOutsideCooldown = 0.1f;
				currentObjectOutside = true;
			}
			else
			{
				objectInsideTrigger = null;
				objectOutsideCooldown = 0f;
				currentObjectOutside = false;
			}
		}
	}

	public void Eject()
	{
		if (Plug != null)
		{
			Plug.Unplug();
		}
	}

	public void NotifyPlugged(PluggableObject plug, bool playSound = true)
	{
		Plug = plug;
		objectInsideTrigger = plug;
		objectOutsideCooldown = 0f;
		if (playSound && (bool)plugInSound)
		{
			plugInSound.Play(base.transform.position);
		}
		HandlePlugging(Plug);
		this.PluggedIn?.Invoke(plug, this);
	}

	public void NotifyUnplugged(PluggableObject plug, bool playSound = true)
	{
		if (Plug == plug)
		{
			objectInsideTrigger = plug;
			if (playSound && (bool)unplugSound)
			{
				unplugSound.Play(base.transform.position);
			}
			HandleUnplugging(Plug);
			Plug = null;
			this.Unplugged?.Invoke(plug, this);
		}
	}

	public virtual bool CanAccept(PluggableObject plug)
	{
		if (Plug == null && plug != null)
		{
			return plug.connectionTag == connectionTag;
		}
		return false;
	}

	private void Update()
	{
		if (!(objectOutsideCooldown > 0f) || !currentObjectOutside)
		{
			return;
		}
		objectOutsideCooldown -= Time.deltaTime;
		if (objectOutsideCooldown <= 0f)
		{
			objectInsideTrigger = null;
			if ((bool)snapIndicator)
			{
				snapIndicator.SetActive(value: false);
			}
		}
	}

	private void OnDisable()
	{
		if (!UnloadWatcher.isUnloading)
		{
			Eject();
		}
	}

	protected virtual void HandlePlugging(PluggableObject plug)
	{
	}

	protected virtual void HandleUnplugging(PluggableObject plug)
	{
	}
}

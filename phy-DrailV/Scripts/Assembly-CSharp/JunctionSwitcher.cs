using System;
using DV.Utils;
using UnityEngine;

public class JunctionSwitcher : MonoBehaviour
{
	public Transform pointerOrigin;

	public JunctionSwitchRemoteControllable PointedSwitch { get; private set; }

	public bool IndirectlyPointing { get; private set; }

	public virtual bool IgnoreInteractables => false;

	public event Action<JunctionSwitchRemoteControllable> JunctionHovered;

	public event Action<JunctionSwitchRemoteControllable> JunctionUnHovered;

	public event Action<JunctionSwitchRemoteControllable> JunctionSwitched;

	protected virtual void Awake()
	{
		base.enabled = false;
	}

	private void OnEnable()
	{
		SingletonBehaviour<JunctionSwitcherManager>.Instance.AddSwitcher(this);
	}

	private void OnDisable()
	{
		if (!UnloadWatcher.isUnloading)
		{
			SingletonBehaviour<JunctionSwitcherManager>.Instance.RemoveSwitcher(this);
		}
	}

	public virtual void PlayHoverAudio(AudioClip clip)
	{
		clip.Play2D();
	}

	public virtual void PlayClickAudio(AudioClip clip)
	{
		clip.Play2D();
	}

	public virtual void Use()
	{
		if ((bool)PointedSwitch)
		{
			PointedSwitch.HandleThumbpad(Vector3.one);
			PlayClickAudio(SingletonBehaviour<JunctionSwitcherManager>.Instance.switchSound);
		}
	}

	public void SetTarget(JunctionSwitchRemoteControllable junctionSwitch = null, bool indirectlyPointing = false)
	{
		if (!(PointedSwitch == junctionSwitch))
		{
			if (PointedSwitch == null && junctionSwitch != null)
			{
				PlayHoverAudio(SingletonBehaviour<JunctionSwitcherManager>.Instance.hoverOverSwitch);
			}
			JunctionSwitchRemoteControllable pointedSwitch = PointedSwitch;
			PointedSwitch = junctionSwitch;
			if ((bool)pointedSwitch)
			{
				this.JunctionUnHovered?.Invoke(pointedSwitch);
				pointedSwitch.VisualSwitch.SetManualInteractionAllowedState(allowed: true);
				pointedSwitch.VisualSwitch.junction.Switched -= OnPointedSwitched;
			}
			if ((bool)PointedSwitch && SingletonBehaviour<JunctionSwitcherManager>.Instance.IsSwitchingAllowed(PointedSwitch.VisualSwitch.junction))
			{
				IndirectlyPointing = indirectlyPointing;
				this.JunctionHovered?.Invoke(PointedSwitch);
				PointedSwitch.VisualSwitch.SetManualInteractionAllowedState(allowed: false);
				PointedSwitch.VisualSwitch.junction.Switched += OnPointedSwitched;
			}
			else
			{
				IndirectlyPointing = false;
			}
		}
	}

	private void OnPointedSwitched(Junction.SwitchMode arg1, int arg2)
	{
		this.JunctionSwitched?.Invoke(PointedSwitch);
	}

	public virtual bool CheckSpecialHit(RaycastHit hit, int hitLayer, JunctionSwitcherManager.UpdateJunctionControlDelegate callback)
	{
		return false;
	}
}

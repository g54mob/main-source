using System;
using System.Collections.Generic;
using System.Linq;
using DV.Common;
using DV.Interaction;
using DV.TerrainTools;
using DV.Utils;
using UnityEngine;
using UnityEngine.EventSystems;

public class JunctionSwitcherManager : SingletonBehaviour<JunctionSwitcherManager>
{
	public delegate bool UpdateJunctionControlDelegate(JunctionSwitcher switcher, JunctionSwitchRemoteControllable junctionControl, bool indirectlyPointing);

	private const float SIGNAL_DISTANCE = 300f;

	[Header("Sounds")]
	public AudioClip hoverOverSwitch;

	public AudioClip switchSound;

	private HashSet<JunctionSwitcher> activeSwitchers = new HashSet<JunctionSwitcher>();

	private Dictionary<JunctionSwitcher, JunctionSwitchRemoteControllable> highlightedJunctions = new Dictionary<JunctionSwitcher, JunctionSwitchRemoteControllable>();

	private RaycastHit[] hits = new RaycastHit[10];

	private LayerMask junctionLayerMask;

	private LayerMask interactableLayerMask;

	private LayerMask nestedInteractableLayer;

	private Grabber grabber;

	private HashSet<Junction> allowedJunctionsForSwitching = new HashSet<Junction>();

	public event Action SwitchingAllowedWhitelistChanged;

	public new static string AllowAutoCreate()
	{
		return null;
	}

	protected override void Awake()
	{
		base.Awake();
		junctionLayerMask = LayerMask.GetMask("Laser_Pointer_Target", "Train_Walkable", "Grabbed_Item", "World_Item", "Interactable", "Inventory");
		interactableLayerMask = LayerMask.GetMask("Interactable", "Grabbed_Item", "World_Item");
		nestedInteractableLayer = LayerMask.GetMask("Inventory");
		if (VRManager.IsVREnabled())
		{
			if ((bool)PlayerManager.PlayerTransform)
			{
				PlayerChanged();
			}
			else
			{
				PlayerManager.PlayerChanged += PlayerChanged;
			}
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		PlayerManager.PlayerChanged -= PlayerChanged;
	}

	private void PlayerChanged()
	{
		PlayerManager.PlayerChanged -= PlayerChanged;
		grabber = PlayerManager.PlayerTransform.GetComponentInChildren<Grabber>();
	}

	public void AddSwitcher(JunctionSwitcher switcher)
	{
		activeSwitchers.Add(switcher);
		base.enabled = true;
	}

	public void RemoveSwitcher(JunctionSwitcher switcher)
	{
		if ((bool)switcher.PointedSwitch)
		{
			ToggleHighlight(on: false, switcher.PointedSwitch, switcher);
		}
		switcher.SetTarget();
		activeSwitchers.Remove(switcher);
		if (activeSwitchers.Count == 0)
		{
			base.enabled = false;
		}
	}

	private void Update()
	{
		foreach (JunctionSwitcher activeSwitcher in activeSwitchers)
		{
			SwitcherLogic(activeSwitcher);
		}
	}

	private void SwitcherLogic(JunctionSwitcher switcher)
	{
		bool flag = (bool)EventSystem.current && EventSystem.current.IsPointerOverGameObject();
		if (!switcher.IgnoreInteractables && (bool)grabber && (bool)grabber.Raycaster.CurrentlyRaycasted && (bool)grabber.Raycaster.CurrentlyRaycasted.GetComponentInParent<ConnectablePrefab>())
		{
			flag = true;
		}
		int num = ((!flag) ? Physics.RaycastNonAlloc(switcher.pointerOrigin.position, switcher.pointerOrigin.forward, hits, 300f, junctionLayerMask) : 0);
		if (num != 0)
		{
			RaycastUtils.SortDistanceAndExpandCache(ref hits, num);
			for (int i = 0; i < num; i++)
			{
				RaycastHit hit = hits[i];
				int layer = hit.collider.gameObject.layer;
				if (switcher.CheckSpecialHit(hit, layer, UpdateJunctionControl))
				{
					return;
				}
				bool flag2 = (int)interactableLayerMask == ((int)interactableLayerMask | (1 << layer));
				if (flag2 && (bool)hit.collider.GetComponent<PlugSocket>())
				{
					continue;
				}
				if ((flag2 && !switcher.IgnoreInteractables) || ((int)nestedInteractableLayer == ((int)nestedInteractableLayer | (1 << layer)) && !switcher.IgnoreInteractables))
				{
					break;
				}
				if (layer == LayerMask.NameToLayer("Train_Walkable"))
				{
					if (!hit.collider.TryGetComponent<TeleportArcPassThrough>(out var component) || !component.ShouldIgnoreCollidersForHit(hit))
					{
						break;
					}
					continue;
				}
				JunctionSwitchRemoteControllable component2 = hit.collider.GetComponent<JunctionSwitchRemoteControllable>();
				Junction junction = ((component2 != null) ? component2.VisualSwitch.junction : null);
				if (junction != null && !IsSwitchingAllowed(junction))
				{
					break;
				}
				if (UpdateJunctionControl(switcher, component2, indirectlyPointing: false))
				{
					return;
				}
			}
		}
		if ((bool)switcher.PointedSwitch)
		{
			ToggleHighlight(on: false, switcher.PointedSwitch, switcher);
		}
		switcher.SetTarget();
	}

	private bool UpdateJunctionControl(JunctionSwitcher switcher, JunctionSwitchRemoteControllable junctionControl, bool indirectlyPointing)
	{
		if (junctionControl == null || !junctionControl.enabled)
		{
			return false;
		}
		if ((bool)switcher.PointedSwitch)
		{
			ToggleHighlight(on: false, switcher.PointedSwitch, switcher);
		}
		ToggleHighlight(on: true, junctionControl, switcher);
		switcher.SetTarget(junctionControl, indirectlyPointing);
		return true;
	}

	public void ToggleHighlight(bool on, JunctionSwitchRemoteControllable remoteSwitch, JunctionSwitcher switcher)
	{
		if (!on)
		{
			highlightedJunctions.Remove(switcher);
		}
		if (!highlightedJunctions.Values.Contains(remoteSwitch))
		{
			remoteSwitch.ToggleHighlight(on);
		}
		if (on)
		{
			highlightedJunctions[switcher] = remoteSwitch;
		}
	}

	public void ResetSwitchWhitelist()
	{
		allowedJunctionsForSwitching.Clear();
		this.SwitchingAllowedWhitelistChanged?.Invoke();
	}

	public void AllowSwitchingForJunction(Junction junction)
	{
		allowedJunctionsForSwitching.Add(junction);
		this.SwitchingAllowedWhitelistChanged?.Invoke();
	}

	public bool IsSwitchingAllowed(Junction junction)
	{
		if (!GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.JunctionSwitching))
		{
			return false;
		}
		if (allowedJunctionsForSwitching.Count == 0)
		{
			return true;
		}
		return allowedJunctionsForSwitching.Contains(junction);
	}
}

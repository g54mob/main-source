using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.ResourceCollection;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.MechanicalParts
{
	public class Decoupler : BindableDronePart, IHasResourceHub
	{
		public string DecoupleSound;

		private KeyBinding _decoupleBinding;

		private bool _isDecoupled;

		private ResourceHub _parentHub;

		[HideInInspector]
		public ResourceHub ResourceHub { get; private set; }

		public void ChangeParentHub(ResourceHub newParent)
		{
			if (ResourceHub == null)
			{
				InitResourceHubs();
			}
			if (!RuntimeGlobals.HasWirelessResourceTransfer)
			{
				if (_parentHub != null)
				{
					_parentHub.RemoveConnectedHub(ResourceHub);
					ResourceHub.RemoveConnectedHub(_parentHub);
				}
				_parentHub = newParent;
				_parentHub.AddConnectedHub(ResourceHub);
				ResourceHub.AddConnectedHub(_parentHub);
			}
		}

		protected override void DronePartBreak()
		{
			base.DronePartBreak();
			if (_parentHub != null && ResourceHub != null)
			{
				_parentHub.RemoveConnectedHub(ResourceHub);
				ResourceHub = null;
			}
		}

		public override List<KeyBinding> GetKeyBindings()
		{
			_decoupleBinding = new KeyBinding("Decouple", KeyCode.None);
			return new List<KeyBinding> { _decoupleBinding };
		}

		protected override void Awake()
		{
			base.Awake();
			KeyBindings = GetKeyBindings();
		}

		protected override void Start()
		{
			base.Start();
			if (ResourceHub == null)
			{
				InitResourceHubs();
			}
		}

		private void InitResourceHubs()
		{
			if (!RuntimeGlobals.HasWirelessResourceTransfer)
			{
				ResourceHub = new ResourceHub();
				ResourceHub.Init();
				_parentHub = FindResourceHubRecursive(true);
				_parentHub.AddConnectedHub(ResourceHub);
				ResourceHub.AddConnectedHub(_parentHub);
			}
			else
			{
				ResourceHub = FindResourceHubRecursive(true);
			}
		}

		public override void Update()
		{
			base.Update();
			if (!IsBroken && CanControlDrone && !RuntimeGlobals.IsGamePaused && Activated && !RuntimeGlobals.HasWirelessResourceTransfer)
			{
				ResourceHub.Update();
			}
		}

		public override void FixedUpdate()
		{
			base.FixedUpdate();
			if (!IsActive() || _isDecoupled || !_decoupleBinding.IsPressed(KeyEventHub))
			{
				return;
			}
			base.transform.parent = null;
			PlaySound(DecoupleSound);
			if (Joint != null)
			{
				Joint.autoConfigureConnectedAnchor = true;
				Joint.connectedBody = null;
				LineRenderer.enabled = false;
				Object.Destroy(Joint);
			}
			if (ParentDronePart != null && ParentDronePart.Children.Contains(this))
			{
				ParentDronePart.Children.Remove(this);
			}
			ParentDronePart = null;
			if (!RuntimeGlobals.HasWirelessResourceTransfer)
			{
				if (_parentHub != null)
				{
					_parentHub.RemoveConnectedHub(ResourceHub);
					ResourceHub.RemoveConnectedHub(_parentHub);
				}
				_parentHub = null;
			}
			_isDecoupled = true;
		}

		public override void SetBroken(bool isBroken)
		{
			base.SetBroken(isBroken);
			if (isBroken)
			{
				if (_parentHub != null)
				{
					_parentHub.RemoveConnectedHub(ResourceHub);
					ResourceHub.RemoveConnectedHub(_parentHub);
				}
				_parentHub = null;
			}
		}
	}
}

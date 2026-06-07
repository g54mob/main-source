using System.Collections;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.DronePartResources;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.InteractiveObjects
{
	public class ResourceContainer : NimbatusWorldObject
	{
		public SkeletonAnimation Animation;

		public List<GameObject> Thrusters;

		private bool _closed;

		private int _dronePartCounter;

		private bool _opening;

		private bool _closing;

		private TrackEntry _closedToOpen;

		private TrackEntry _openToClosed;

		protected override void Awake()
		{
			base.Awake();
			RuntimeGlobals.ResourceContainer = this;
		}

		public override void WakeUp()
		{
			Thrusters.ForEach(delegate(GameObject t)
			{
				t.SetActive(true);
			});
		}

		protected override void Start()
		{
			base.Start();
			_closed = true;
			_opening = false;
			_closing = false;
			Animation.AnimationState.SetAnimation(1, "upDownMotion", true);
			Animation.AnimationState.Complete += AnimationState_Complete;
		}

		private IEnumerator OpenContainer()
		{
			if (!_opening)
			{
				_opening = true;
				while (!_closed)
				{
					yield return true;
				}
				_closedToOpen = Animation.AnimationState.SetAnimation(0, "closedToOpen", false);
				Animation.AnimationState.AddAnimation(0, "idleOpen", true, 0f);
			}
		}

		private void AnimationState_Complete(TrackEntry trackEntry)
		{
			if (trackEntry == _closedToOpen)
			{
				_closedToOpen = null;
				_closed = false;
				_closing = false;
				_opening = false;
			}
			if (trackEntry == _openToClosed)
			{
				_openToClosed = null;
				_closed = true;
				_closing = false;
				_opening = false;
			}
		}

		private IEnumerator CloseContainer()
		{
			if (!_closing)
			{
				_closing = true;
				while (_closed)
				{
					yield return true;
				}
				_openToClosed = Animation.AnimationState.SetAnimation(0, "openToClosed", false);
				Animation.AnimationState.AddAnimation(0, "idleClosed", true, 0f);
			}
		}

		public void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.layer == RuntimeGlobals.NimbatusPlayer.gameObject.layer)
			{
				_dronePartCounter++;
				StopAllCoroutines();
				StartCoroutine(OpenContainer());
			}
			ResourceTank component = other.gameObject.GetComponent<ResourceTank>();
			if (component != null)
			{
				component.StartDrain(base.transform);
			}
		}

		public void OnTriggerStay(Collider other)
		{
			ResourceTank component = other.gameObject.GetComponent<ResourceTank>();
			if (component != null)
			{
				component.StartDrain(base.transform);
			}
		}

		public void OnTriggerExit(Collider other)
		{
			if (other.gameObject.layer == RuntimeGlobals.NimbatusPlayer.gameObject.layer)
			{
				_dronePartCounter--;
				if (_dronePartCounter <= 0)
				{
					StopAllCoroutines();
					StartCoroutine(CloseContainer());
				}
			}
			ResourceTank component = other.gameObject.GetComponent<ResourceTank>();
			if (component != null)
			{
				component.StopDrain();
			}
		}
	}
}

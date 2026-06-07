using System.Collections.Generic;
using DV.Common;
using DV.Items;
using DV.Player;
using DV.Utils;
using UnityEngine;

namespace DV.Customization.Gadgets
{
	public class GadgetWiringTool : GadgetInteractor, ItemPositionController.IPositionProvider
	{
		[SerializeField]
		private Transform nozzle;

		public AudioSource soundWiring;

		public float soundPitch = 10f;

		public float soundVolume = 10f;

		public float pitchExponent = 0.5f;

		public float soundSmoothing = 0.1f;

		public float soundMaxDelta = 0.5f;

		public ItemWorkingAnimation itemWorkingAnimation;

		public AudioClip soundOnWiringStarted;

		public AudioClip soundOnWiringCanceled;

		public AudioClip soundOnWiringAdded;

		public AudioClip soundOnWiringRemoved;

		private GadgetBase source;

		private GadgetBase animationTarget;

		private readonly List<GadgetWiringModule.WireLinkPort> connectionLister = new List<GadgetWiringModule.WireLinkPort>();

		private float distanceTrack;

		private float distance;

		private float soundValue;

		private Transform startingTransformReference;

		private Vector3 startingLocalPos;

		private GadgetBase hoverTarget;

		public override bool CallRegularUpdateWhenNull => true;

		public GadgetBase Source => source;

		public int Priority => 1;

		private void Awake()
		{
			if (!VRManager.IsVREnabled())
			{
				itemWorkingAnimation.AnimationStarted += delegate
				{
					SingletonBehaviour<ItemPositionController>.Instance.Add(this);
					startingTransformReference = animationTarget.Custom.transform;
					startingLocalPos = startingTransformReference.InverseTransformPoint(SingletonBehaviour<ItemPositionController>.Instance.itemAnchor.position);
				};
				itemWorkingAnimation.AnimationStopped += delegate
				{
					SingletonBehaviour<ItemPositionController>.Instance.Remove(this);
				};
				itemWorkingAnimation.WorkDoneCallback = () => true;
				itemWorkingAnimation.InputPressedCallback = () => true;
			}
		}

		private void OnDestroy()
		{
			if (!VRManager.IsVREnabled())
			{
				itemWorkingAnimation.StopAnimating();
			}
		}

		protected override HighlightMode OnUpdate(GadgetBase target, bool use)
		{
			if (Mathf.Abs(distance - distanceTrack) > soundMaxDelta)
			{
				distanceTrack = distance + Mathf.Sign(distanceTrack - distance) * soundMaxDelta;
			}
			float num = 1f - Mathf.Exp((0f - Time.deltaTime) / soundSmoothing);
			float num2 = (distance - distanceTrack) * num;
			distanceTrack += num2;
			soundValue = num2;
			soundWiring.pitch = Mathf.Pow(Mathf.Abs(soundValue) * soundPitch, pitchExponent);
			soundWiring.volume = soundValue * soundValue * soundVolume * soundVolume;
			if (hoverTarget != target)
			{
				GadgetSystemUtility.HoverHapticFeedback(base.gameObject);
			}
			hoverTarget = target;
			if (source == null)
			{
				if (target == null)
				{
					return HighlightMode.None;
				}
				ShowWiresOf(target);
				distance = 0f;
				if (target.HasAnyWirePorts && SingletonBehaviour<GadgetSystemUtility>.Instance.CheckWiringAgainstRestrictions(target) && GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.WiringGadgets))
				{
					GadgetInteractor.ShowInteractionTextLMB("interaction/wiring/start");
					return HighlightMode.Wiring;
				}
				return HighlightMode.Bad;
			}
			ShowWiresOf(source);
			if (target == null || !source.TryGetCompatiblePorts(target, out var myPort, out var otherPort))
			{
				Vector3 b = (VRManager.IsVREnabled() ? nozzle.position : (PlayerManager.ActiveCamera.transform.position + PlayerManager.ActiveCamera.transform.forward));
				ShowWire(source.transform.position, b, WireHighlightMode.Seek);
				distance = Vector3.Distance(source.transform.position, b);
				if (!(target != null))
				{
					return HighlightMode.None;
				}
				return HighlightMode.Bad;
			}
			if (target != null && (!SingletonBehaviour<GadgetSystemUtility>.Instance.CheckWiringAgainstRestrictions(target) || !GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.WiringGadgets)))
			{
				return HighlightMode.Bad;
			}
			distance = Vector3.Distance(source.transform.position, target.transform.position);
			if (GadgetWiringModule.WireLinkPort.AreWired(myPort, otherPort))
			{
				ShowWire(source, target, WireHighlightMode.Remove);
				GadgetInteractor.ShowInteractionTextLMB("interaction/wiring/unwire");
				return HighlightMode.Wiring;
			}
			GadgetInteractor.ShowInteractionTextLMB("interaction/wiring/wire");
			ShowWire(source, target, WireHighlightMode.Valid);
			return HighlightMode.Wiring;
		}

		private void ShowWiresOf(GadgetBase gadget)
		{
			connectionLister.Clear();
			foreach (GadgetWiringModule.WireLinkPort wireLinkPort in gadget.WireLinkPorts)
			{
				wireLinkPort.GetLinks(connectionLister);
			}
			foreach (GadgetWiringModule.WireLinkPort item in connectionLister)
			{
				ShowWire(gadget, item.owner, WireHighlightMode.Exist);
			}
			connectionLister.Clear();
		}

		private void PlayWiringAudio()
		{
			distanceTrack = 0f;
			distance = 0f;
			soundWiring.volume = 0f;
			if (!soundWiring.isPlaying)
			{
				soundWiring.PlayRandomTime();
			}
		}

		protected override void OnUsed()
		{
			GadgetWiringModule.WireLinkPort myPort;
			GadgetWiringModule.WireLinkPort otherPort;
			if (source == null)
			{
				if (base.Target != null && base.Target.HasAnyWirePorts && GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.WiringGadgets) && SingletonBehaviour<GadgetSystemUtility>.Instance.CheckWiringAgainstRestrictions(base.Target))
				{
					source = base.Target;
				}
				if (source != null)
				{
					PlayWiringAudio();
					soundOnWiringStarted?.Play(base.transform.position);
					animationTarget = source;
					itemWorkingAnimation.StartAnimating();
				}
				distance = 0f;
			}
			else if (source == base.Target || base.Target == null || !SingletonBehaviour<GadgetSystemUtility>.Instance.CheckWiringAgainstRestrictions(base.Target) || !GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.WiringGadgets))
			{
				source = null;
				distance = 0f;
				soundOnWiringCanceled?.Play(base.transform.position);
			}
			else if (source.TryGetCompatiblePorts(base.Target, out myPort, out otherPort))
			{
				if (GadgetWiringModule.WireLinkPort.AreWired(myPort, otherPort))
				{
					GadgetWiringModule.WireLinkPort.Unwire(myPort, otherPort);
					source = null;
					distance = 0f;
					distanceTrack = 0f;
					animationTarget = base.Target;
					itemWorkingAnimation.StartAnimating();
					soundOnWiringRemoved?.Play(base.transform.position);
				}
				else if (GadgetWiringModule.WireLinkPort.Wire(myPort, otherPort))
				{
					source = null;
					distance = 0f;
					distanceTrack = 0f;
					animationTarget = base.Target;
					itemWorkingAnimation.StartAnimating();
					soundOnWiringAdded?.Play(base.transform.position);
				}
			}
		}

		protected override void OnUngrabbed()
		{
			source = null;
			soundWiring.Stop();
			if (!VRManager.IsVREnabled())
			{
				itemWorkingAnimation.StopAnimating();
			}
		}

		public (Vector3 pos, Quaternion rot, float overridePreviousPerc) GetPose(Vector3 pos, Quaternion rot)
		{
			Transform transform = ((animationTarget != null) ? animationTarget.transform : null);
			if (transform == null)
			{
				return default((Vector3, Quaternion, float));
			}
			(Vector3, Quaternion) tuple = TransformUtils.CalculateAlignmentTargets(SingletonBehaviour<ItemPositionController>.Instance.itemAnchor, transform.position, Quaternion.LookRotation(transform.forward, Vector3.up), vrInteractionPoint);
			float num = ItemWorkingAnimation.EaseInCubic(itemWorkingAnimation.MoveToWorkProgress);
			if (itemWorkingAnimation.WorkDone)
			{
				return (pos: tuple.Item1, rot: tuple.Item2, overridePreviousPerc: num);
			}
			Vector3 a = startingTransformReference.TransformPoint(startingLocalPos);
			tuple.Item1 = Vector3.Lerp(a, tuple.Item1, num);
			return (pos: tuple.Item1, rot: tuple.Item2, overridePreviousPerc: 1f);
		}
	}
}

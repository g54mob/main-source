using MoreMountains.Feedbacks;
using Unity.Cinemachine;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/Cinemachine/MMCinemachinePriorityListener")]
	[RequireComponent(typeof(CinemachineVirtualCameraBase))]
	public class MMCinemachinePriorityListener : MonoBehaviour
	{
		[HideInInspector]
		public TimescaleModes TimescaleMode;

		[Header("Priority Listener")]
		[Tooltip("whether to listen on a channel defined by an int or by a MMChannel scriptable object. Ints are simple to setup but can get messy and make it harder to remember what int corresponds to what. MMChannel scriptable objects require you to create them in advance, but come with a readable name and are more scalable")]
		public MMChannelModes ChannelMode;

		[Tooltip("the channel to listen to - has to match the one on the feedback")]
		[MMFEnumCondition("ChannelMode", new int[] { 0 })]
		public int Channel;

		[Tooltip("the MMChannel definition asset to use to listen for events. The feedbacks targeting this shaker will have to reference that same MMChannel definition to receive events - to create a MMChannel, right click anywhere in your project (usually in a Data folder) and go MoreMountains > MMChannel, then name it with some unique name")]
		[MMFEnumCondition("ChannelMode", new int[] { 1 })]
		public MMChannel MMChannelDefinition;

		protected CinemachineVirtualCameraBase _camera;

		protected int _initialPriority;

		public virtual float GetTime()
		{
			if (TimescaleMode != TimescaleModes.Scaled)
			{
				return Time.unscaledTime;
			}
			return Time.time;
		}

		public virtual float GetDeltaTime()
		{
			if (TimescaleMode != TimescaleModes.Scaled)
			{
				return Time.unscaledDeltaTime;
			}
			return Time.deltaTime;
		}

		protected virtual void Awake()
		{
			_camera = base.gameObject.GetComponent<CinemachineVirtualCameraBase>();
			_initialPriority = _camera.Priority.Value;
		}

		public virtual void OnMMCinemachinePriorityEvent(MMChannelData channelData, bool forceMaxPriority, int newPriority, bool forceTransition, CinemachineBlendDefinition blendDefinition, bool resetValuesAfterTransition, TimescaleModes timescaleMode, bool restore = false)
		{
			TimescaleMode = timescaleMode;
			if (MMChannel.Match(channelData, ChannelMode, Channel, MMChannelDefinition))
			{
				if (restore)
				{
					SetPriority(_initialPriority);
				}
				else
				{
					SetPriority(newPriority);
				}
			}
			else if (forceMaxPriority)
			{
				if (restore)
				{
					SetPriority(_initialPriority);
				}
				else
				{
					SetPriority(0);
				}
			}
		}

		protected virtual void SetPriority(int newPriority)
		{
			PrioritySettings priority = _camera.Priority;
			priority.Value = newPriority;
			_camera.Priority = priority;
		}

		protected virtual void OnEnable()
		{
			MMCinemachinePriorityEvent.Register(OnMMCinemachinePriorityEvent);
		}

		protected virtual void OnDisable()
		{
			MMCinemachinePriorityEvent.Unregister(OnMMCinemachinePriorityEvent);
		}
	}
}

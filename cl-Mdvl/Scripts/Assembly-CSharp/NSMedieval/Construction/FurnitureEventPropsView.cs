using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.PlayerTriggeredEventSystem;
using UnityEngine;

namespace NSMedieval.Construction
{
	[DisallowMultipleComponent]
	public class FurnitureEventPropsView : MonoBehaviour
	{
		[NonSerialized]
		private BaseBuildingInstance baseBuildingInstance;

		[NonSerialized]
		private BaseBuildingViewComponent baseBuildingViewComponent;

		private readonly HashSet<GameObject> children = new HashSet<GameObject>();

		private void OnEventStateChanged(EventState state)
		{
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(23, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Views\\FurnitureEventPropsView.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Event state changed to ");
				messageBuilder.AppendFormatted(state);
			}
			Log.Trace(messageBuilder);
			if (baseBuildingInstance == null || !baseBuildingInstance.EligibleForEvent())
			{
				messageBuilder = new FVLogTraceInterpolationHandler(42, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Views\\FurnitureEventPropsView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Base is null: ");
					messageBuilder.AppendFormatted(baseBuildingInstance == null);
					messageBuilder.AppendLiteral(" or not eligible for event: ");
					messageBuilder.AppendFormatted(baseBuildingInstance?.EligibleForEvent());
				}
				Log.Trace(messageBuilder);
				return;
			}
			if (!MonoSingleton<PlayerTriggeredEventManager>.Instance.IsInEventRoom(baseBuildingInstance))
			{
				messageBuilder = new FVLogTraceInterpolationHandler(27, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Views\\FurnitureEventPropsView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Base ");
					messageBuilder.AppendFormatted(baseBuildingInstance == null);
					messageBuilder.AppendLiteral(" is not  in event room");
				}
				Log.Trace(messageBuilder);
				return;
			}
			switch (state)
			{
			case EventState.Started:
				OnEventStarted();
				break;
			case EventState.Ended:
			case EventState.Disposed:
				OnEventEnded();
				break;
			default:
				throw new ArgumentOutOfRangeException("state", state, null);
			case EventState.NotStarted:
			case EventState.Gathering:
				break;
			}
		}

		private void OnEventStarted()
		{
			foreach (GameObject child in children)
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(15, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Views\\FurnitureEventPropsView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Enabling child ");
					messageBuilder.AppendFormatted(child.name);
				}
				Log.Trace(messageBuilder);
				child.SetActive(value: true);
			}
		}

		private void OnEventEnded()
		{
			foreach (GameObject child in children)
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(16, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Views\\FurnitureEventPropsView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Disabling child ");
					messageBuilder.AppendFormatted(child.name);
				}
				Log.Trace(messageBuilder);
				child.SetActive(value: false);
			}
		}

		private void InitBuildingInstance()
		{
			if (baseBuildingViewComponent == null)
			{
				baseBuildingViewComponent = GetComponentInParent<BaseBuildingViewComponent>();
				if (baseBuildingViewComponent == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(75, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Views\\FurnitureEventPropsView.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Missing BaseBuildingViewComponent in FurnitureEventPropsView. Parent name: ");
						messageBuilder.AppendFormatted(base.transform.parent.name);
					}
					Log.Error(messageBuilder);
					return;
				}
			}
			if (baseBuildingInstance == null)
			{
				baseBuildingInstance = baseBuildingViewComponent.BaseBuildingInstance;
			}
		}

		private void InitChildren()
		{
			children.Clear();
			Transform[] componentsInChildren = GetComponentsInChildren<Transform>(includeInactive: true);
			foreach (Transform transform in componentsInChildren)
			{
				if (!(transform == base.gameObject.transform))
				{
					children.Add(transform.gameObject);
				}
			}
		}

		private void Start()
		{
			InitBuildingInstance();
			InitChildren();
		}

		public void OnEnable()
		{
			Subscribe();
		}

		public void OnDisable()
		{
			Unsubscribe();
		}

		private void OnDestroy()
		{
			Unsubscribe();
			baseBuildingInstance = null;
		}

		private void Subscribe()
		{
			if (MonoSingleton<PlayerTriggeredEventManager>.IsInstantiated())
			{
				MonoSingleton<PlayerTriggeredEventManager>.Instance.EventStartedEvent += OnEventStarted;
				MonoSingleton<PlayerTriggeredEventManager>.Instance.EventEndedEvent += OnEventEnded;
			}
		}

		private void Unsubscribe()
		{
			if (MonoSingleton<PlayerTriggeredEventManager>.IsInstantiated())
			{
				MonoSingleton<PlayerTriggeredEventManager>.Instance.EventStartedEvent -= OnEventStarted;
				MonoSingleton<PlayerTriggeredEventManager>.Instance.EventEndedEvent -= OnEventEnded;
			}
		}

		private void OnEventStarted(PlayerTriggeredEventInstance eventInstance)
		{
			eventInstance.StateChangedEvent += OnEventStateChanged;
		}

		private void OnEventEnded(PlayerTriggeredEventInstance eventInstance)
		{
			eventInstance.StateChangedEvent -= OnEventStateChanged;
		}
	}
}

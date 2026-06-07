using System;
using MalbersAnimations.Events;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[Serializable]
	public class AnimalEvent
	{
		[Flag]
		public EventBehaviorType eventBehaviorType;

		[Hide("eventBehaviorType", false, true, true, new int[] { 2 })]
		public bool boolEvent;

		[Hide("eventBehaviorType", false, true, true, new int[] { 4 })]
		public float floatEvent;

		[Hide("eventBehaviorType", false, true, true, new int[] { 8 })]
		public int intEvent;

		[Hide("eventBehaviorType", false, true, true, new int[] { 16 })]
		public string stringEvent;

		[Hide("eventBehaviorType", false, true, true, new int[] { 32 })]
		public Vector3 vector3Event;

		[Hide("eventBehaviorType", false, true, true, new int[] { 64 })]
		public Vector2 vector2Event;

		[Hide("eventBehaviorType", false, true, true, new int[] { 128 })]
		public GameObject gameObjectEvent;

		[Hide("eventBehaviorType", false, true, true, new int[] { 256 })]
		public Transform transformEvent;

		[Hide("eventBehaviorType", false, true, true, new int[] { 512 })]
		public Component componentEvent;

		[Hide("eventBehaviorType", false, true, true, new int[] { 1024 })]
		public Sprite spriteEvent;

		public void Invoke(MEvent mEvent)
		{
			if (eventBehaviorType != 0)
			{
				if (CheckEventType(EventBehaviorType.VoidEvent))
				{
					mEvent.Invoke();
				}
				if (CheckEventType(EventBehaviorType.BoolEvent))
				{
					mEvent.Invoke(boolEvent);
				}
				if (CheckEventType(EventBehaviorType.FloatEvent))
				{
					mEvent.Invoke(floatEvent);
				}
				if (CheckEventType(EventBehaviorType.IntEvent))
				{
					mEvent.Invoke(intEvent);
				}
				if (CheckEventType(EventBehaviorType.StringEvent))
				{
					mEvent.Invoke(stringEvent);
				}
				if (CheckEventType(EventBehaviorType.Vector3Event))
				{
					mEvent.Invoke(vector3Event);
				}
				if (CheckEventType(EventBehaviorType.Vector2Event))
				{
					mEvent.Invoke(vector2Event);
				}
				if (CheckEventType(EventBehaviorType.GameObjectEvent))
				{
					mEvent.Invoke(gameObjectEvent);
				}
				if (CheckEventType(EventBehaviorType.TransformEvent))
				{
					mEvent.Invoke(transformEvent);
				}
				if (CheckEventType(EventBehaviorType.ComponentEvent))
				{
					mEvent.Invoke(componentEvent);
				}
				if (CheckEventType(EventBehaviorType.SpriteEvent))
				{
					mEvent.Invoke(spriteEvent);
				}
			}
		}

		private bool CheckEventType(EventBehaviorType modifier)
		{
			return (eventBehaviorType & modifier) == modifier;
		}
	}
}

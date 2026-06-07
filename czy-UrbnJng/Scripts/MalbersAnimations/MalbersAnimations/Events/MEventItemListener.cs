using System;
using System.Collections.Generic;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations.Events
{
	[Serializable]
	public class MEventItemListener
	{
		public MEvent Event;

		public bool active = true;

		[HideInInspector]
		public bool useInt;

		[HideInInspector]
		public bool useFloat;

		[HideInInspector]
		public bool useVoid = true;

		[HideInInspector]
		public bool useString;

		[HideInInspector]
		public bool useBool;

		[HideInInspector]
		public bool useGO;

		[HideInInspector]
		public bool useTransform;

		[HideInInspector]
		public bool useVector3;

		[HideInInspector]
		public bool useVector2;

		[HideInInspector]
		public bool useComponent;

		[HideInInspector]
		public bool useSprite;

		public UnityEvent Response = new UnityEvent();

		public UnityEvent ResponseNull = new UnityEvent();

		public FloatEvent ResponseFloat = new FloatEvent();

		public IntEvent ResponseInt = new IntEvent();

		public BoolEvent ResponseBool = new BoolEvent();

		public UnityEvent ResponseBoolFalse = new UnityEvent();

		public UnityEvent ResponseBoolTrue = new UnityEvent();

		public StringEvent ResponseString = new StringEvent();

		public GameObjectEvent ResponseGO = new GameObjectEvent();

		public TransformEvent ResponseTransform = new TransformEvent();

		public ComponentEvent ResponseComponent = new ComponentEvent();

		public SpriteEvent ResponseSprite = new SpriteEvent();

		public Vector3Event ResponseVector3 = new Vector3Event();

		public Vector2Event ResponseVector2 = new Vector2Event();

		public List<AdvancedIntegerEvent> IntEventList = new List<AdvancedIntegerEvent>();

		public List<AdvancedFloatEvent> FloatEventList = new List<AdvancedFloatEvent>();

		public bool AdvancedInteger;

		public bool AdvancedFloat;

		public bool AdvancedBool;

		[Tooltip("Inverts the value of the Bool Event")]
		public bool InvertBool;

		[Tooltip("Multiply the Upcoming Result from the Float Event with this value")]
		public FloatReference multiplier = new FloatReference(1f);

		public Transform Owner { get; set; }

		public virtual void OnEventInvoked()
		{
			if (active && useVoid)
			{
				Response.Invoke();
			}
		}

		public virtual void OnEventInvoked(string value)
		{
			if (active && useString)
			{
				ResponseString.Invoke(value);
			}
		}

		public virtual void OnEventInvoked(float value)
		{
			if (active && useFloat)
			{
				ResponseFloat.Invoke(value * (float)multiplier);
			}
		}

		public virtual void OnEventInvoked(int value)
		{
			if (!active || !useInt)
			{
				return;
			}
			ResponseInt.Invoke(value);
			if (!AdvancedInteger)
			{
				return;
			}
			foreach (AdvancedIntegerEvent intEvent in IntEventList)
			{
				intEvent.ExecuteAdvanceIntegerEvent(value);
			}
		}

		public virtual void OnEventInvoked(bool value)
		{
			if (!active || !useBool)
			{
				return;
			}
			ResponseBool.Invoke(InvertBool ? (!value) : value);
			if (AdvancedBool)
			{
				if (value)
				{
					ResponseBoolTrue.Invoke();
				}
				else
				{
					ResponseBoolFalse.Invoke();
				}
			}
		}

		public virtual void OnEventInvoked(Vector3 value)
		{
			if (active && useVector3)
			{
				ResponseVector3.Invoke(value);
			}
		}

		public virtual void OnEventInvoked(Vector2 value)
		{
			if (active && useVector2)
			{
				ResponseVector2.Invoke(value);
			}
		}

		public virtual void OnEventInvoked(GameObject value)
		{
			if (active && useGO)
			{
				if ((bool)value)
				{
					ResponseGO.Invoke(value);
				}
				else
				{
					ResponseNull.Invoke();
				}
			}
		}

		public virtual void OnEventInvoked(Transform value)
		{
			if (active && useTransform)
			{
				ResponseTransform.Invoke(value);
				if (!value)
				{
					ResponseNull.Invoke();
				}
			}
		}

		public virtual void OnEventInvoked(Component value)
		{
			if (active && useComponent)
			{
				if ((bool)value)
				{
					ResponseComponent.Invoke(value);
				}
				else
				{
					ResponseNull.Invoke();
				}
			}
		}

		public virtual void OnEventInvoked(Sprite value)
		{
			if (active && useSprite)
			{
				if ((bool)value)
				{
					ResponseSprite.Invoke(value);
				}
				else
				{
					ResponseNull.Invoke();
				}
			}
		}

		public MEventItemListener()
		{
			useVoid = true;
			useInt = (useFloat = (useString = (useBool = (useGO = (useTransform = (useVector3 = (useVector2 = (useSprite = (useComponent = false)))))))));
		}
	}
}

using System;
using UnityEngine;
using UnityEngine.Events;

namespace DG.Tweening.Timeline.Core
{
	[Serializable]
	public class DOTweenClipElement
	{
		public enum Type
		{
			Tween = 0,
			GlobalTween = 1,
			Event = 2,
			[Obsolete]
			Sequence = 3,
			Action = 4,
			Interval = 5
		}

		public enum ToFromType
		{
			Dynamic = 0,
			Direct = 1
		}

		public enum PropertyType
		{
			Unset = 0,
			Float = 1,
			Int = 2,
			Uint = 3,
			String = 4,
			Vector2 = 5,
			Vector3 = 6,
			Vector4 = 7,
			Quaternion = 8,
			Color = 9,
			Rect = 10
		}

		public Type type;

		[SerializeField]
		private string _guid;

		public int pin;

		public bool isActive;

		public bool executeInEditMode;

		public float startTime;

		public float duration;

		public int loops;

		public LoopType loopType;

		public UnityEngine.Object target;

		public Ease ease;

		public AnimationCurve easeCurve;

		public float overshootOrAmplitude;

		public float period;

		public ToFromType toType;

		public ToFromType fromType;

		public string plugId;

		public int plugDataIndex;

		public string plugDataGuid;

		public bool isRelative;

		public AxisConstraint axisConstraint;

		public bool boolOption0;

		public int intOption0;

		public int intOption1;

		public float floatOption0;

		public float floatOption1;

		public string stringOption0;

		public UnityEngine.Object objOption;

		public float toFloatVal;

		public float fromFloatVal;

		public int toIntVal;

		public int fromIntVal;

		public uint fromUintVal;

		public uint toUintVal;

		public string toStringVal;

		public string fromStringVal;

		public Vector2 fromVector2Val;

		public Vector2 toVector2Val;

		public Vector3 fromVector3Val;

		public Vector3 toVector3Val;

		public Vector4 fromVector4Val;

		public Vector4 toVector4Val;

		public Color fromColorVal;

		public Color toColorVal;

		public Rect fromRectVal;

		public Rect toRectVal;

		public UnityEvent onComplete;

		public UnityEvent onStepComplete;

		public UnityEvent onUpdate;

		public bool editor_lockVector;

		public string guid => null;

		public DOTweenClipElement(string guid, Type type, float startTime)
		{
		}

		public DOTweenClipElement Clone(bool regenerateGuid)
		{
			return null;
		}

		private void AssignEventsReferencesFrom(DOTweenClipElement clipElement)
		{
		}
	}
}

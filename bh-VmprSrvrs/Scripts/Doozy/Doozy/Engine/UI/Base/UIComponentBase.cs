using System.Collections.Generic;
using Doozy.Engine.Settings;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Doozy.Engine.UI.Base
{
	public abstract class UIComponentBase<T> : MonoBehaviour
	{
		public static readonly List<T> Database;

		private static int s_uiInteractionsDisableLevel;

		private static EventSystem s_unityEventSystem;

		public bool DebugMode;

		public Vector3 StartPosition;

		public Vector3 StartRotation;

		public Vector3 StartScale;

		public float StartAlpha;

		private RectTransform m_rectTransform;

		protected static DoozySettings Settings => null;

		public static bool UIInteractionsDisabled => false;

		public static EventSystem UnityEventSystem => null;

		public RectTransform RectTransform => null;

		protected virtual void Reset()
		{
		}

		public virtual void Awake()
		{
		}

		public virtual void Start()
		{
		}

		public virtual void OnEnable()
		{
		}

		public virtual void OnDisable()
		{
		}

		public virtual void OnDestroy()
		{
		}

		public virtual bool IsActive()
		{
			return false;
		}

		public bool IsDestroyed()
		{
			return false;
		}

		public virtual void ResetToStartValues()
		{
		}

		public virtual void ResetPosition()
		{
		}

		public virtual void ResetRotation()
		{
		}

		public virtual void ResetScale()
		{
		}

		public virtual void ResetAlpha()
		{
		}

		public virtual void UpdateStartValues()
		{
		}

		public virtual void UpdateStartPosition()
		{
		}

		public virtual void UpdateStartRotation()
		{
		}

		public virtual void UpdateStartScale()
		{
		}

		public virtual void UpdateStartAlpha()
		{
		}

		protected static void RemoveAnyNullReferencesFromTheDatabase()
		{
		}

		public static void EnableUIInteractions()
		{
		}

		public static void EnableUIInteractionsByForce()
		{
		}

		public static void DisableUIInteractions()
		{
		}
	}
}

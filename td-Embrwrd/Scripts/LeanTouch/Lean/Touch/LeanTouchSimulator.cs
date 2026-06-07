using System;
using UnityEngine;

namespace Lean.Touch
{
	[AddComponentMenu("Lean/Touch/Lean Touch Simulator")]
	[HelpURL("https://carloswilkes.com/Documentation/LeanTouch#LeanTouchSimulator")]
	[RequireComponent(typeof(LeanTouch))]
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	public class LeanTouchSimulator : MonoBehaviour
	{
		[SerializeField]
		private KeyCode pinchTwistKey;

		[SerializeField]
		private KeyCode movePivotKey;

		[SerializeField]
		private KeyCode multiDragKey;

		[SerializeField]
		private Texture2D fingerTexture;

		private Vector2 pivot;

		[NonSerialized]
		private LeanTouch cachedTouch;

		public KeyCode PinchTwistKey
		{
			get
			{
				return default(KeyCode);
			}
			set
			{
			}
		}

		public KeyCode MovePivotKey
		{
			get
			{
				return default(KeyCode);
			}
			set
			{
			}
		}

		public KeyCode MultiDragKey
		{
			get
			{
				return default(KeyCode);
			}
			set
			{
			}
		}

		public Texture2D FingerTexture
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void OnGUI()
		{
		}

		private void HandleSimulateFingers()
		{
		}
	}
}

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lean.Touch
{
	[ExecuteInEditMode]
	[AddComponentMenu("Lean/Touch/Lean Drag Trail")]
	[HelpURL("https://carloswilkes.com/Documentation/LeanTouch#LeanDragTrail")]
	public class LeanDragTrail : MonoBehaviour
	{
		[Serializable]
		public class FingerData : LeanFingerData
		{
			public LineRenderer Line;

			public float Age;

			public float Width;
		}

		public LeanFingerFilter Use;

		public LeanScreenDepth ScreenDepth;

		[SerializeField]
		private LineRenderer prefab;

		[SerializeField]
		private int maxTrails;

		[SerializeField]
		protected float fadeTime;

		[SerializeField]
		protected Color startColor;

		[SerializeField]
		protected Color endColor;

		[SerializeField]
		protected List<FingerData> fingerDatas;

		public LineRenderer Prefab
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int MaxTrails
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float FadeTime
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Color StartColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public Color EndColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public void AddFinger(LeanFinger finger)
		{
		}

		public void RemoveFinger(LeanFinger finger)
		{
		}

		public void RemoveAllFingers()
		{
		}

		protected virtual void Awake()
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void Update()
		{
		}

		protected virtual void UpdateLine(FingerData fingerData, LeanFinger finger, LineRenderer line)
		{
		}

		protected virtual void HandleFingerUp(LeanFinger finger)
		{
		}
	}
}

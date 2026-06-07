using System;
using UnityEngine;

namespace TheraBytes.BetterUi
{
	[Serializable]
	public class RectTransformData : IScreenConfigConnection
	{
		public static readonly RectTransformData Invalid;

		public static readonly RectTransformData Identity;

		public Vector3 LocalPosition;

		public Vector2 AnchoredPosition;

		public Vector2 SizeDelta;

		public Vector2 AnchorMin;

		public Vector2 AnchorMax;

		public Vector2 Pivot;

		public Vector3 Scale;

		[SerializeField]
		private Quaternion rotation;

		public Vector3 EulerAngles;

		[SerializeField]
		private bool saveRotationAsEuler;

		[SerializeField]
		private string screenConfigName;

		public Quaternion Rotation
		{
			get
			{
				return default(Quaternion);
			}
			set
			{
			}
		}

		public bool SaveRotationAsEuler
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Vector2 OffsetMax
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public Vector2 OffsetMin
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public string ScreenConfigName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public RectTransformData()
		{
		}

		public RectTransformData(RectTransform rectTransform)
		{
		}

		public static RectTransformData Combine(RectTransformData original, RectTransformData addition)
		{
			return null;
		}

		public static RectTransformData Separate(RectTransformData original, RectTransformData subtraction)
		{
			return null;
		}

		public void PullFromData(RectTransformData transformData)
		{
		}

		public void PullFromTransform(RectTransform transform)
		{
		}

		public void PushToTransform(RectTransform transform)
		{
		}

		public static RectTransformData Lerp(RectTransformData a, RectTransformData b, float amount)
		{
			return null;
		}

		public static RectTransformData Lerp(RectTransformData a, RectTransformData b, float amount, bool eulerRotation)
		{
			return null;
		}

		public static RectTransformData LerpUnclamped(RectTransformData a, RectTransformData b, float amount)
		{
			return null;
		}

		public static RectTransformData LerpUnclamped(RectTransformData a, RectTransformData b, float amount, bool eulerRotation)
		{
			return null;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public static bool operator ==(RectTransformData a, RectTransformData b)
		{
			return false;
		}

		public static bool operator !=(RectTransformData a, RectTransformData b)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}

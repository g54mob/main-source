using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AillieoUtils.UI
{
	public class RadialLayoutGroup : LayoutGroup
	{
		public enum Direction
		{
			Clockwise = 0,
			Counterclockwise = 1,
			Bidirectional = 2
		}

		public enum ConstraintMode
		{
			Interval = 0,
			Range = 1
		}

		[SerializeField]
		private ConstraintMode mAngleConstraint;

		[SerializeField]
		private ConstraintMode mRadiusConstraint;

		[SerializeField]
		private Direction mLayoutDir;

		[SerializeField]
		private float mRadiusStart;

		[SerializeField]
		private float mRadiusDelta;

		[SerializeField]
		private float mRadiusRange;

		[SerializeField]
		private float mAngleDelta;

		[SerializeField]
		private float mAngleStart;

		[SerializeField]
		private float mAngleCenter;

		[SerializeField]
		private float mAngleRange;

		[SerializeField]
		private bool mChildRotate;

		private List<RectTransform> childList = new List<RectTransform>();

		private List<ILayoutIgnorer> ignoreList = new List<ILayoutIgnorer>();

		private static readonly Vector2 center = new Vector2(0.5f, 0.5f);

		public ConstraintMode AngleConstraint
		{
			get
			{
				return mAngleConstraint;
			}
			set
			{
				SetProperty(ref mAngleConstraint, value);
			}
		}

		public ConstraintMode RadiusConstraint
		{
			get
			{
				return mRadiusConstraint;
			}
			set
			{
				SetProperty(ref mRadiusConstraint, value);
			}
		}

		public Direction LayoutDir
		{
			get
			{
				return mLayoutDir;
			}
			set
			{
				SetProperty(ref mLayoutDir, value);
			}
		}

		public float RadiusStart
		{
			get
			{
				return mRadiusStart;
			}
			set
			{
				SetProperty(ref mRadiusStart, value);
			}
		}

		public float RadiusDelta
		{
			get
			{
				return mRadiusDelta;
			}
			set
			{
				SetProperty(ref mRadiusDelta, value);
			}
		}

		public float RadiusRange
		{
			get
			{
				return mRadiusRange;
			}
			set
			{
				SetProperty(ref mRadiusRange, value);
			}
		}

		public float AngleDelta
		{
			get
			{
				return mAngleDelta;
			}
			set
			{
				SetProperty(ref mAngleDelta, value);
			}
		}

		public float AngleStart
		{
			get
			{
				return mAngleStart;
			}
			set
			{
				SetProperty(ref mAngleStart, value);
			}
		}

		public float AngleCenter
		{
			get
			{
				return mAngleCenter;
			}
			set
			{
				SetProperty(ref mAngleCenter, value);
			}
		}

		public float AngleRange
		{
			get
			{
				return mAngleRange;
			}
			set
			{
				SetProperty(ref mAngleRange, value);
			}
		}

		public bool ChildRotate
		{
			get
			{
				return mChildRotate;
			}
			set
			{
				SetProperty(ref mChildRotate, value);
			}
		}

		public override void CalculateLayoutInputVertical()
		{
		}

		public override void CalculateLayoutInputHorizontal()
		{
		}

		public override void SetLayoutHorizontal()
		{
			CalculateChildrenPositions();
		}

		public override void SetLayoutVertical()
		{
			CalculateChildrenPositions();
		}

		private void CalculateChildrenPositions()
		{
			m_Tracker.Clear();
			childList.Clear();
			for (int i = 0; i < base.transform.childCount; i++)
			{
				RectTransform rectTransform = base.transform.GetChild(i) as RectTransform;
				if (!rectTransform.gameObject.activeSelf)
				{
					continue;
				}
				ignoreList.Clear();
				rectTransform.GetComponents(ignoreList);
				if (ignoreList.Count == 0)
				{
					childList.Add(rectTransform);
					continue;
				}
				for (int j = 0; j < ignoreList.Count; j++)
				{
					if (!ignoreList[j].ignoreLayout)
					{
						childList.Add(rectTransform);
						break;
					}
				}
				ignoreList.Clear();
			}
			EnsureParameters(childList.Count);
			for (int k = 0; k < childList.Count; k++)
			{
				RectTransform child = childList[k];
				float num = (float)k * mAngleDelta;
				float angle = ((LayoutDir == Direction.Clockwise) ? (mAngleStart - num) : (mAngleStart + num));
				ProcessOneChild(child, angle, mRadiusStart + (float)k * mRadiusDelta);
			}
			childList.Clear();
		}

		private void EnsureParameters(int childCount)
		{
			EnsureAngleParameters(childCount);
			EnsureRadiusParameters(childCount);
		}

		private void EnsureAngleParameters(int childCount)
		{
			int num = childCount - 1;
			switch (LayoutDir)
			{
			case Direction.Clockwise:
				if (AngleConstraint == ConstraintMode.Interval)
				{
					mAngleRange = (float)num * mAngleDelta;
				}
				else if (num > 0)
				{
					mAngleDelta = mAngleRange / (float)num;
				}
				else
				{
					mAngleDelta = 0f;
				}
				break;
			case Direction.Counterclockwise:
				if (AngleConstraint == ConstraintMode.Interval)
				{
					mAngleRange = (float)num * mAngleDelta;
				}
				else if (num > 0)
				{
					mAngleDelta = mAngleRange / (float)num;
				}
				else
				{
					mAngleDelta = 0f;
				}
				break;
			case Direction.Bidirectional:
				if (AngleConstraint == ConstraintMode.Interval)
				{
					mAngleRange = (float)num * mAngleDelta;
				}
				else if (num > 0)
				{
					mAngleDelta = mAngleRange / (float)num;
				}
				else
				{
					mAngleDelta = 0f;
				}
				mAngleStart = mAngleCenter - mAngleRange * 0.5f;
				break;
			}
		}

		private void EnsureRadiusParameters(int childCount)
		{
			int num = childCount - 1;
			switch (LayoutDir)
			{
			case Direction.Clockwise:
				if (RadiusConstraint == ConstraintMode.Interval)
				{
					mRadiusRange = (float)num * mRadiusDelta;
				}
				else if (num > 0)
				{
					mRadiusDelta = mRadiusRange / (float)num;
				}
				else
				{
					mRadiusDelta = 0f;
				}
				break;
			case Direction.Counterclockwise:
			case Direction.Bidirectional:
				if (RadiusConstraint == ConstraintMode.Interval)
				{
					mRadiusRange = (float)num * mRadiusDelta;
				}
				else if (num > 0)
				{
					mRadiusDelta = mRadiusRange / (float)num;
				}
				else
				{
					mRadiusDelta = 0f;
				}
				break;
			}
		}

		private void ProcessOneChild(RectTransform child, float angle, float radius)
		{
			Vector3 vector = new Vector3(Mathf.Cos(angle * (MathF.PI / 180f)), Mathf.Sin(angle * (MathF.PI / 180f)), 0f);
			child.localPosition = vector * radius;
			DrivenTransformProperties drivenProperties = DrivenTransformProperties.Anchors | DrivenTransformProperties.AnchoredPosition | DrivenTransformProperties.Pivot | DrivenTransformProperties.Rotation;
			m_Tracker.Add(this, child, drivenProperties);
			child.anchorMin = center;
			child.anchorMax = center;
			child.pivot = center;
			if (ChildRotate)
			{
				child.localEulerAngles = new Vector3(0f, 0f, angle);
			}
			else
			{
				child.localEulerAngles = Vector3.zero;
			}
		}
	}
}

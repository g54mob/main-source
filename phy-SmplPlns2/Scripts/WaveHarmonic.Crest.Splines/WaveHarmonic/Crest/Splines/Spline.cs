using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest.Splines
{
	[AddComponentMenu("Crest/Spline/Crest Spline")]
	public sealed class Spline : ManagedBehaviour<WaterRenderer>
	{
		[Serializable]
		internal sealed class DebugFields
		{
			[Tooltip("Forces the spline to update every frame.")]
			[SerializeField]
			internal bool _UpdateEveryFrame;
		}

		[SerializeField]
		internal SplineContainer _Source;

		[Tooltip("Where generated ribbon should lie relative to spline.\n\nIf set to Center, ribbon is centered around spline.")]
		[SerializeField]
		internal SplineOffset _Offset = SplineOffset.Center;

		[Tooltip("Connect start and end point to close spline into a loop.\n\nRequires at least 3 spline points.")]
		[SerializeField]
		internal bool _Closed;

		[Tooltip("The radius of the spline.")]
		[SerializeField]
		private float _Radius = 10f;

		[Tooltip("Increasing subdivision increases the geometry density.\n\nMostly useful for water level changes. High values can reduce staircasing effect.")]
		[SerializeField]
		private int _Subdivisions = 1;

		[SerializeField]
		internal DebugFields _Debug = new DebugFields();

		private static readonly List<LodInput> s_Inputs = new List<LodInput>();

		private static readonly List<IReceiveSplineChangeMessages> s_Receivers = new List<IReceiveSplineChangeMessages>();

		public bool Closed
		{
			get
			{
				return _Closed;
			}
			set
			{
				_Closed = value;
			}
		}

		public SplineOffset Offset
		{
			get
			{
				return _Offset;
			}
			set
			{
				_Offset = value;
			}
		}

		public float Radius
		{
			get
			{
				return _Radius;
			}
			set
			{
				_Radius = value;
			}
		}

		public int Subdivisions
		{
			get
			{
				return _Subdivisions;
			}
			set
			{
				_Subdivisions = value;
			}
		}

		internal bool HasSource => _Source != null;

		private bool HasSplinePoints()
		{
			return GetComponentsInChildren<SplinePoint>().Length != 0;
		}

		internal static void NotifyReceivers(Transform sibling)
		{
			sibling.GetComponents(s_Receivers);
			foreach (IReceiveSplineChangeMessages s_Receiver in s_Receivers)
			{
				s_Receiver.OnSplineChange();
			}
			sibling.GetComponents(s_Inputs);
			foreach (LodInput s_Input in s_Inputs)
			{
				(s_Input.Data as IReceiveSplineChangeMessages)?.OnSplineChange();
			}
		}

		public void UpdateSpline()
		{
			NotifyReceivers(base.transform);
		}

		private protected override void OnEnable()
		{
			base.OnEnable();
			UnityEngine.Splines.Spline.Changed -= OnSplineChanged;
			UnityEngine.Splines.Spline.Changed += OnSplineChanged;
		}

		private protected override void OnDisable()
		{
			base.OnDisable();
			UnityEngine.Splines.Spline.Changed -= OnSplineChanged;
		}

		private protected override void Initialize()
		{
			base.Initialize();
			if (GetComponentsInChildren<SplinePoint>().Length == 0 && (_Source != null || TryGetComponent<SplineContainer>(out _Source)))
			{
				InitializeFromContainer();
			}
		}

		internal void InitializeFromContainer()
		{
			foreach (BezierKnot item in _Source.Spline)
			{
				GameObject obj = new GameObject();
				obj.name = "Spline Point";
				obj.transform.parent = base.transform;
				obj.transform.position = _Source.transform.TransformPoint(item.Position);
				obj.AddComponent<SplinePoint>();
			}
		}

		internal void OnSplineChanged(UnityEngine.Splines.Spline spline, int index, SplineModification modification)
		{
			SplineContainer source = _Source;
			if (source == null || source.Spline != spline)
			{
				return;
			}
			SplinePoint[] componentsInChildren = GetComponentsInChildren<SplinePoint>();
			switch (modification)
			{
			case SplineModification.ClosedModified:
				Closed = spline.Closed;
				break;
			case SplineModification.KnotModified:
			{
				for (int l = 0; l < spline.Count; l++)
				{
					BezierKnot bezierKnot3 = spline[l];
					SplinePoint obj = componentsInChildren[l];
					obj.transform.position = source.transform.TransformPoint(bezierKnot3.Position);
					obj._LocalPosition = obj.transform.localPosition;
				}
				break;
			}
			case SplineModification.KnotInserted:
			{
				for (int m = 0; m < spline.Count; m++)
				{
					BezierKnot bezierKnot4 = spline[m];
					if (m >= componentsInChildren.Length || !(componentsInChildren[m].transform.position == source.transform.TransformPoint(bezierKnot4.Position)))
					{
						GameObject obj2 = new GameObject();
						obj2.name = "Spline Point";
						obj2.transform.parent = base.transform;
						obj2.transform.position = source.transform.TransformPoint(bezierKnot4.Position);
						obj2.transform.SetSiblingIndex(m);
						obj2.AddComponent<SplinePoint>();
						break;
					}
				}
				break;
			}
			case SplineModification.KnotRemoved:
			{
				int num = 0;
				foreach (SplinePoint splinePoint2 in componentsInChildren)
				{
					if (num >= spline.Count)
					{
						Helpers.Destroy(splinePoint2.gameObject, undo: true);
						continue;
					}
					BezierKnot bezierKnot2 = spline[num];
					if (splinePoint2.transform.position != source.transform.TransformPoint(bezierKnot2.Position))
					{
						Helpers.Destroy(splinePoint2.gameObject, undo: true);
					}
					else
					{
						num++;
					}
				}
				break;
			}
			case SplineModification.KnotReordered:
			{
				for (int i = 0; i < spline.Count; i++)
				{
					BezierKnot bezierKnot = spline[i];
					foreach (SplinePoint splinePoint in componentsInChildren)
					{
						if (splinePoint.transform.position == source.transform.TransformPoint(bezierKnot.Position))
						{
							splinePoint.transform.SetSiblingIndex(i);
							break;
						}
					}
				}
				break;
			}
			}
			UpdateSpline();
		}
	}
}

using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy
{
	[ExecuteAlways]
	public abstract class SplineProcessor : DTVersionedMonoBehaviour
	{
		[SerializeField]
		protected CurvySpline m_Spline;

		public CurvySpline Spline
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public abstract void Refresh();

		private void OnSplineRefresh(CurvySplineEventArgs e)
		{
		}

		private void OnSplineCoordinatesChanged(CurvySpline spline)
		{
		}

		private void ProcessEvent([NotNull] CurvySpline spline)
		{
		}

		[UsedImplicitly]
		protected virtual void Awake()
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		protected override void OnValidate()
		{
		}

		[UsedImplicitly]
		protected virtual void Start()
		{
		}

		protected void BindEvents()
		{
		}

		protected void UnbindEvents()
		{
		}

		private void UnbindEvents([NotNull] CurvySpline spline)
		{
		}
	}
}

using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	public class ShotSystemViewport : TShotSystem
	{
		public static readonly int ID = "ShotSystemViewport".GetHashCode();

		[SerializeField]
		private EnablerProjection m_Projection = new EnablerProjection();

		[SerializeField]
		private EnablerFloat m_FieldOfView = new EnablerFloat(isEnabled: false, 60f);

		[SerializeField]
		private EnablerFloat m_OrthographicSize = new EnablerFloat(isEnabled: false, 5f);

		[SerializeField]
		private EnablerFloat m_ClipPlaneNear = new EnablerFloat(isEnabled: false, 0.3f);

		[SerializeField]
		private EnablerFloat m_ClipPlaneFar = new EnablerFloat(isEnabled: false, 1000f);

		public override int Id => ID;

		public bool ChangeProjection => m_Projection.IsEnabled;

		public bool ChangeFieldOfView => m_FieldOfView.IsEnabled;

		public bool ChangeOrthographicSize => m_OrthographicSize.IsEnabled;

		public bool ChangeClipPlaneNear => m_ClipPlaneNear.IsEnabled;

		public bool ChangeClipPlaneFar => m_ClipPlaneFar.IsEnabled;

		public bool Projection => m_Projection.Value == EnablerProjection.Type.Orthographic;

		public float FieldOfView => m_FieldOfView.Value;

		public float OrthographicSize => m_OrthographicSize.Value;

		public float ClipPlaneNear => m_ClipPlaneNear.Value;

		public float ClipPlaneFar => m_ClipPlaneFar.Value;
	}
}

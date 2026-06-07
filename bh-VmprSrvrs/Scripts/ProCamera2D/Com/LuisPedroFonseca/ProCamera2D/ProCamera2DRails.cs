using System.Collections.Generic;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[HelpURL("http://www.procamera2d.com/user-guide/extension-rails/")]
	public class ProCamera2DRails : BasePC2D, IPreMover
	{
		public static string ExtensionName;

		[HideInInspector]
		public List<Vector3> RailNodes;

		public FollowMode FollowMode;

		public List<CameraTarget> CameraTargets;

		private Dictionary<CameraTarget, Transform> _cameraTargetsOnRails;

		private List<CameraTarget> _tempCameraTargets;

		private KDTree _kdTree;

		private int _prmOrder;

		public int PrMOrder
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void PreMove(float deltaTime)
		{
		}

		private void Step()
		{
		}

		public void AddRailsTarget(Transform targetTransform, float targetInfluenceH = 1f, float targetInfluenceV = 1f, Vector2 targetOffset = default(Vector2), float duration = 0f)
		{
		}

		public void RemoveRailsTarget(Transform targetTransform)
		{
		}

		public CameraTarget GetRailsTarget(Transform targetTransform)
		{
			return null;
		}

		public void DisableTargets(float transitionDuration = 0f)
		{
		}

		public void EnableTargets(float transitionDuration = 0f)
		{
		}

		private Vector3 GetPositionOnRail(Vector3 pos)
		{
			return default(Vector3);
		}

		private Vector3 GetPositionOnRailSegment(Vector3 node1, Vector3 node2, Vector3 pos)
		{
			return default(Vector3);
		}
	}
}

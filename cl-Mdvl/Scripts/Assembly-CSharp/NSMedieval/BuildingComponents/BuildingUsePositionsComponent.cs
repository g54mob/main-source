using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.Extensions;
using NSMedieval.Model;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	public class BuildingUsePositionsComponent : MonoBehaviour
	{
		[SerializeField]
		private List<Transform> useTransforms;

		[SerializeField]
		private List<Transform> animationTransforms;

		[SerializeField]
		private List<Vec3Int> workplacePositions;

		[SerializeField]
		private HashSet<Vector3> animationPositions;

		private BaseBuildingBlueprint blueprint;

		public Transform WorkPositionsParent { get; protected set; }

		public List<Transform> UseTransforms => useTransforms;

		public List<Vec3Int> WorkplacePositions => workplacePositions;

		public HashSet<Vector3> AnimationPositions => animationPositions;

		protected virtual void Awake()
		{
			if (WorkPositionsParent == null)
			{
				WorkPositionsParent = base.transform;
			}
		}

		public void Dispose()
		{
			if (useTransforms != null)
			{
				foreach (Transform useTransform in useTransforms)
				{
					Object.Destroy(useTransform.gameObject);
				}
				useTransforms.Clear();
			}
			workplacePositions?.Clear();
			workplacePositions = null;
			animationPositions?.Clear();
			animationPositions = null;
		}

		public virtual void Initialize(TransformSettings[] workplaceTransforms)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(47, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\ComponentMisc\\BuildingUsePositionsComponent.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Initializing BuildingUsePositionsComponent for ");
				messageBuilder.AppendFormatted(base.gameObject.name);
			}
			Log.Debug(messageBuilder);
			if (workplaceTransforms == null || workplaceTransforms.Length <= 0)
			{
				return;
			}
			foreach (TransformSettings transformSettings in workplaceTransforms)
			{
				if (transformSettings.IsValid)
				{
					GameObject gameObject = InstantiateTransform("_WorkPosition");
					transformSettings.ApplyToTransform(gameObject.transform);
					useTransforms.Add(gameObject.transform);
				}
			}
		}

		public Transform GetUsePositionTransform(Vector3 position)
		{
			foreach (Transform useTransform in useTransforms)
			{
				if (Vector3.Distance(useTransform.position, position) <= 0.5f)
				{
					return useTransform;
				}
			}
			return useTransforms.GetClosest(position);
		}

		public Transform GetUsePositionTransform(Vec3Int gridPosition)
		{
			Vector3 worldPosition = GridUtils.GetWorldPosition(gridPosition);
			return GetUsePositionTransform(worldPosition);
		}

		public void InitializePositions()
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(20, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\ComponentMisc\\BuildingUsePositionsComponent.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("InitializePositions ");
				messageBuilder.AppendFormatted(base.gameObject.name);
			}
			Log.Debug(messageBuilder);
			if (workplacePositions == null)
			{
				workplacePositions = new List<Vec3Int>();
			}
			foreach (Transform useTransform in useTransforms)
			{
				Vec3Int gridPosition = GridUtils.GetGridPosition(useTransform.position);
				workplacePositions.Add(gridPosition);
			}
			if (animationPositions == null)
			{
				animationPositions = new HashSet<Vector3>();
			}
			foreach (Transform animationTransform in animationTransforms)
			{
				animationPositions.Add(animationTransform.position);
			}
		}

		private void OnDrawGizmos()
		{
			if (useTransforms != null && useTransforms.Count > 0)
			{
				Gizmos.color = Color.blue;
				foreach (Transform useTransform in useTransforms)
				{
					Gizmos.DrawSphere(useTransform.position, 0.15f);
				}
			}
			if (animationTransforms == null || animationTransforms.Count <= 0)
			{
				return;
			}
			Gizmos.color = Color.yellow;
			foreach (Transform animationTransform in animationTransforms)
			{
				Gizmos.DrawSphere(animationTransform.position, 0.15f);
			}
		}

		private GameObject InstantiateTransform(string name)
		{
			GameObject obj = new GameObject(name);
			obj.transform.SetParent(WorkPositionsParent);
			obj.transform.localPosition = Vector3.zero;
			obj.transform.localRotation = Quaternion.identity;
			return obj;
		}
	}
}

using UnityEngine;

namespace Restory.Gameplay.Elements
{
	public class FlexibleElement : InsertableElement
	{
		private const string PLACEMENT_SETTINGS_GROUP_NAME = "Placement Settings";

		private const string PROJECTION_SETTINGS_GROUP_NAME = "Projection Settings";

		private const string VIEW_GROUP_NAME = "View";

		[SerializeField]
		private BoxCollider placementCollider;

		[SerializeField]
		private MeshFilter placementMeshFilter;

		[SerializeField]
		private BoxCollider projectionCollider;

		[SerializeField]
		private MeshFilter projectionMeshFilter;

		[SerializeField]
		private GameObject attachedModel;

		[SerializeField]
		private GameObject placementModel;

		public GameObject AttachedModel => attachedModel;

		public GameObject PlacementModel => placementModel;

		public override bool InSocket
		{
			get
			{
				return base.InSocket;
			}
			set
			{
				if (base.InSocket != value)
				{
					base.InSocket = value;
					ChangeElementModel(value);
				}
			}
		}

		protected override void Awake()
		{
			base.Awake();
			if (projectionCollider == null)
			{
				projectionCollider = placementCollider;
			}
			if (projectionMeshFilter == null)
			{
				projectionMeshFilter = placementMeshFilter;
			}
		}

		public override void Init()
		{
			if (!isInitialized)
			{
				base.ProjectionData = new ElementProjectionData(base.transform, AttachmentPosition, projectionCollider, projectionMeshFilter);
				placementPositionHandler.Init(placementCollider);
				isInitialized = true;
				base.IsSelected = false;
				base.Progress = 0f;
			}
			ChangeElementModel(InSocket);
		}

		public void SetElementPlacementModel()
		{
			ChangeElementModel(inSocket: false);
		}

		private void ChangeElementModel(bool inSocket)
		{
			attachedModel.SetActive(inSocket);
			placementModel.SetActive(!inSocket);
		}
	}
}

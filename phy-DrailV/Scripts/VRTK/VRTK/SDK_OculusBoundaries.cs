using UnityEngine;

namespace VRTK
{
	[SDK_Description(typeof(SDK_OculusSystem), 0)]
	[SDK_Description(typeof(SDK_OculusSystem), 1)]
	public class SDK_OculusBoundaries : SDK_BaseBoundaries
	{
		private OvrAvatar avatarContainer;

		public override void InitBoundaries()
		{
			GetAvatar();
		}

		public override Transform GetPlayArea()
		{
			cachedPlayArea = GetSDKManagerPlayArea();
			if (cachedPlayArea == null)
			{
				OVRManager oVRManager = VRTK_SharedMethods.FindEvenInactiveComponent<OVRManager>(searchAllScenes: true);
				if (oVRManager != null)
				{
					cachedPlayArea = oVRManager.transform;
				}
			}
			return cachedPlayArea;
		}

		public override Vector3[] GetPlayAreaVertices()
		{
			OVRBoundary oVRBoundary = new OVRBoundary();
			if (oVRBoundary.GetConfigured())
			{
				Vector3 dimensions = oVRBoundary.GetDimensions(OVRBoundary.BoundaryType.OuterBoundary);
				float num = 0.1f;
				return new Vector3[8]
				{
					new Vector3(dimensions.x - num, 0f, dimensions.z - num),
					new Vector3(0f + num, 0f, dimensions.z - num),
					new Vector3(0f + num, 0f, 0f + num),
					new Vector3(dimensions.x - num, 0f, 0f + num),
					new Vector3(dimensions.x, 0f, dimensions.z),
					new Vector3(0f, 0f, dimensions.z),
					new Vector3(0f, 0f, 0f),
					new Vector3(dimensions.x, 0f, 0f)
				};
			}
			return null;
		}

		public override float GetPlayAreaBorderThickness()
		{
			return 0.1f;
		}

		public override bool IsPlayAreaSizeCalibrated()
		{
			return true;
		}

		public override bool GetDrawAtRuntime()
		{
			return false;
		}

		public override void SetDrawAtRuntime(bool value)
		{
		}

		public virtual OvrAvatar GetAvatar()
		{
			if (avatarContainer == null)
			{
				avatarContainer = VRTK_SharedMethods.FindEvenInactiveComponent<OvrAvatar>(searchAllScenes: true);
				if (avatarContainer != null && avatarContainer.GetComponent<VRTK_TransformFollow>() == null)
				{
					avatarContainer.gameObject.AddComponent<VRTK_TransformFollow>().gameObjectToFollow = GetPlayArea().gameObject;
				}
			}
			return avatarContainer;
		}
	}
}

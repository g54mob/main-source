using UnityEngine;

namespace VRTK
{
	[SDK_Description(typeof(SDK_UnitySystem), 0)]
	[SDK_Description(typeof(SDK_UnitySystem), 1)]
	[SDK_Description(typeof(SDK_UnitySystem), 2)]
	[SDK_Description(typeof(SDK_UnitySystem), 3)]
	[SDK_Description(typeof(SDK_UnitySystem), 4)]
	[SDK_Description(typeof(SDK_UnitySystem), 5)]
	public class SDK_UnityBoundaries : SDK_BaseBoundaries
	{
		public override void InitBoundaries()
		{
		}

		public override Transform GetPlayArea()
		{
			cachedPlayArea = GetSDKManagerPlayArea();
			if (cachedPlayArea == null)
			{
				GameObject gameObject = VRTK_SharedMethods.FindEvenInactiveGameObject<SDK_UnityCameraRig>(null, searchAllScenes: true);
				if (gameObject != null)
				{
					cachedPlayArea = gameObject.transform;
				}
			}
			return cachedPlayArea;
		}

		public override Vector3[] GetPlayAreaVertices()
		{
			return null;
		}

		public override float GetPlayAreaBorderThickness()
		{
			return 0.1f;
		}

		public override bool IsPlayAreaSizeCalibrated()
		{
			return false;
		}

		public override bool GetDrawAtRuntime()
		{
			return false;
		}

		public override void SetDrawAtRuntime(bool value)
		{
		}
	}
}

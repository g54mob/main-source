using UnityEngine;

namespace VRTK
{
	[SDK_Description(typeof(SDK_SteamVRSystem), 0)]
	public class SDK_SteamVRBoundaries : SDK_BaseBoundaries
	{
		protected SteamVR_PlayArea cachedSteamVRPlayArea;

		public override void InitBoundaries()
		{
			SteamVR_PlayArea steamVR_PlayArea = GetCachedSteamVRPlayArea();
			if (steamVR_PlayArea != null)
			{
				steamVR_PlayArea.BuildMesh();
			}
		}

		public override Transform GetPlayArea()
		{
			cachedPlayArea = GetSDKManagerPlayArea();
			if (cachedPlayArea == null)
			{
				SteamVR_PlayArea steamVR_PlayArea = VRTK_SharedMethods.FindEvenInactiveComponent<SteamVR_PlayArea>(searchAllScenes: true);
				if (steamVR_PlayArea != null)
				{
					cachedSteamVRPlayArea = steamVR_PlayArea;
					cachedPlayArea = steamVR_PlayArea.transform;
				}
			}
			return cachedPlayArea;
		}

		public override Vector3[] GetPlayAreaVertices()
		{
			SteamVR_PlayArea steamVR_PlayArea = GetCachedSteamVRPlayArea();
			if (steamVR_PlayArea != null)
			{
				return ProcessVertices(steamVR_PlayArea.vertices);
			}
			return null;
		}

		public override float GetPlayAreaBorderThickness()
		{
			SteamVR_PlayArea steamVR_PlayArea = GetCachedSteamVRPlayArea();
			if (steamVR_PlayArea != null)
			{
				return steamVR_PlayArea.borderThickness;
			}
			return 0f;
		}

		public override bool IsPlayAreaSizeCalibrated()
		{
			SteamVR_PlayArea steamVR_PlayArea = GetCachedSteamVRPlayArea();
			if (steamVR_PlayArea != null)
			{
				return steamVR_PlayArea.size == SteamVR_PlayArea.Size.Calibrated;
			}
			return false;
		}

		public override bool GetDrawAtRuntime()
		{
			SteamVR_PlayArea steamVR_PlayArea = GetCachedSteamVRPlayArea();
			if (!(steamVR_PlayArea != null))
			{
				return false;
			}
			return steamVR_PlayArea.drawInGame;
		}

		public override void SetDrawAtRuntime(bool value)
		{
			SteamVR_PlayArea steamVR_PlayArea = GetCachedSteamVRPlayArea();
			if (steamVR_PlayArea != null)
			{
				steamVR_PlayArea.drawInGame = value;
				steamVR_PlayArea.enabled = true;
			}
		}

		protected virtual SteamVR_PlayArea GetCachedSteamVRPlayArea()
		{
			if (cachedSteamVRPlayArea == null)
			{
				Transform playArea = GetPlayArea();
				if (playArea != null)
				{
					cachedSteamVRPlayArea = playArea.GetComponent<SteamVR_PlayArea>();
				}
			}
			return cachedSteamVRPlayArea;
		}

		protected virtual Vector3[] ProcessVertices(Vector3[] vertices)
		{
			return vertices;
		}
	}
}

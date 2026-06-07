using DV.Common;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV
{
	public static class ExternalCameraSavePositionManager
	{
		public struct CamPose
		{
			public Vector2 offset;

			public float pitch;

			public float fov;

			public CamPose(Vector2 offset, float pitch, float fov)
			{
				this.offset = offset;
				this.pitch = pitch;
				this.fov = fov;
			}
		}

		public static void ClearPosition()
		{
			User currentUser = SingletonBehaviour<UserManager>.Instance.CurrentUser;
			string propertyName = "ExtCamPose";
			if (currentUser.GameData.Remove(propertyName))
			{
				currentUser.Save(UserSavingMode.JustUser);
			}
		}

		public static void SavePosition()
		{
			if ((bool)PlayerManager.Car)
			{
				PlayerCameraSwitcher instance = SingletonBehaviour<PlayerCameraSwitcher>.Instance;
				if ((bool)instance)
				{
					SavePosition(instance.externalCamera.GetCamPose());
				}
			}
		}

		private static void SavePosition(CamPose camPose)
		{
			User currentUser = SingletonBehaviour<UserManager>.Instance.CurrentUser;
			string propertyName = "ExtCamPose";
			currentUser.GameData[propertyName] = JObject.FromObject(camPose);
			currentUser.Save(UserSavingMode.JustUser);
		}

		public static bool TryLoadPosition(out CamPose camPose)
		{
			camPose = default(CamPose);
			User currentUser = SingletonBehaviour<UserManager>.Instance.CurrentUser;
			string propertyName = "ExtCamPose";
			if (currentUser.GameData[propertyName] == null)
			{
				return false;
			}
			camPose = currentUser.GameData[propertyName].ToObject<CamPose>();
			return true;
		}
	}
}

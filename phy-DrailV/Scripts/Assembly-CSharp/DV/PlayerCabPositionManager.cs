using DV.Common;
using DV.ThingTypes;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV
{
	public static class PlayerCabPositionManager
	{
		public struct CabPosition
		{
			public Vector3 localPosition;

			public float localRotation;

			public float nonVRPitch;

			public float sittingHeight;

			public CabPosition(Vector3 localPosition, float localRotation, float nonVRPitch, float sittingHeight)
			{
				this.localPosition = localPosition;
				this.localRotation = localRotation;
				this.nonVRPitch = nonVRPitch;
				this.sittingHeight = sittingHeight;
			}
		}

		public static void SavePosition()
		{
			if ((bool)PlayerManager.Car && (bool)PlayerManager.Car.cabTeleportDestination)
			{
				bool flag = VRManager.IsVREnabled();
				CharacterControllerProvider component = PlayerManager.PlayerTransform.GetComponent<CharacterControllerProvider>();
				Transform transform = PlayerManager.Car.cabTeleportDestination.transform;
				Quaternion quaternion = Quaternion.Inverse(transform.rotation) * PlayerManager.PlayerCamera.transform.rotation;
				Vector3 localPosition = transform.InverseTransformPoint(PlayerManager.PlayerTransform.position);
				if (flag && LocomotionSetup.CurrentLocomotion == LocomotionType.Teleport)
				{
					localPosition.y -= (GamePreferences.Get<bool>(Preferences.SeatedPlayAreaType) ? GamePreferences.Get<float>(Preferences.PlayerSeatedHeight) : GamePreferences.Get<float>(Preferences.PlayerRoomscaleHeight));
				}
				CabPosition cabPosition = new CabPosition(localPosition, quaternion.eulerAngles.y, flag ? 0f : quaternion.eulerAngles.x, (!flag && component.IsSitting) ? component.PlayerSittingHeight : (-1f));
				SavePosition(PlayerManager.Car.carLivery.parentType, cabPosition, flag);
			}
		}

		private static void SavePosition(TrainCarType_v2 type, CabPosition cabPosition, bool isVR)
		{
			User currentUser = SingletonBehaviour<UserManager>.Instance.CurrentUser;
			string propertyName = (isVR ? "CabPositionsVR" : "CabPositionsNonVR");
			JToken jToken = currentUser.GameData[propertyName];
			if (jToken == null)
			{
				jToken = new JObject();
				currentUser.GameData[propertyName] = jToken;
			}
			jToken[type.id] = JObject.FromObject(cabPosition);
			currentUser.Save(UserSavingMode.JustUser);
		}

		public static bool TryLoadPosition(TrainCarType_v2 type, bool isVR, out CabPosition cabPosition)
		{
			cabPosition = default(CabPosition);
			User currentUser = SingletonBehaviour<UserManager>.Instance.CurrentUser;
			string propertyName = (isVR ? "CabPositionsVR" : "CabPositionsNonVR");
			if (currentUser.GameData[propertyName] == null)
			{
				return false;
			}
			JToken jToken = currentUser.GameData[propertyName][type.id];
			if (jToken == null)
			{
				return false;
			}
			cabPosition = jToken.ToObject<CabPosition>();
			return true;
		}

		public static void ClearPosition(TrainCarType_v2 type, bool isVR)
		{
			User currentUser = SingletonBehaviour<UserManager>.Instance.CurrentUser;
			string propertyName = (isVR ? "CabPositionsVR" : "CabPositionsNonVR");
			JObject jObject = (JObject)currentUser.GameData[propertyName];
			if (jObject == null)
			{
				jObject = new JObject();
				currentUser.GameData[propertyName] = jObject;
			}
			if (jObject.Remove(type.id))
			{
				currentUser.Save(UserSavingMode.JustUser);
			}
		}
	}
}

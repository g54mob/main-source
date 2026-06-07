using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Utilities/VRTK_SDKObjectAlias")]
	public class VRTK_SDKObjectAlias : MonoBehaviour
	{
		public enum SDKObject
		{
			Boundary = 0,
			Headset = 1
		}

		[Tooltip("The specific SDK Object to child this GameObject to.")]
		public SDKObject sdkObject;

		protected virtual void OnEnable()
		{
			VRTK_SDKManager.SubscribeLoadedSetupChanged(LoadedSetupChanged);
			ChildToSDKObject();
		}

		protected virtual void OnDisable()
		{
			if (!base.gameObject.activeSelf)
			{
				VRTK_SDKManager.UnsubscribeLoadedSetupChanged(LoadedSetupChanged);
			}
		}

		protected virtual void LoadedSetupChanged(VRTK_SDKManager sender, VRTK_SDKManager.LoadedSetupChangeEventArgs e)
		{
			if (VRTK_SDKManager.ValidInstance() && base.gameObject.activeInHierarchy)
			{
				ChildToSDKObject();
			}
		}

		protected virtual void ChildToSDKObject()
		{
			Vector3 localPosition = base.transform.localPosition;
			Quaternion localRotation = base.transform.localRotation;
			Vector3 localScale = base.transform.localScale;
			Transform parent = null;
			switch (sdkObject)
			{
			case SDKObject.Boundary:
				parent = VRTK_DeviceFinder.PlayAreaTransform();
				break;
			case SDKObject.Headset:
				parent = VRTK_DeviceFinder.HeadsetTransform();
				break;
			}
			base.transform.SetParent(parent);
			base.transform.localPosition = localPosition;
			base.transform.localRotation = localRotation;
			base.transform.localScale = localScale;
		}
	}
}

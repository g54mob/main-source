using System;
using GameCreator.Runtime.Cameras;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Camera")]
	[Category("Cameras/Camera")]
	[Image(typeof(IconCamera), ColorTheme.Type.Green)]
	[Description("Rotation of the selected Camera in world space")]
	public class GetRotationCamera : PropertyTypeGetRotation
	{
		[SerializeField]
		private PropertyGetGameObject m_Camera = GetGameObjectCameraMain.Create;

		public static PropertyGetRotation Create => new PropertyGetRotation(new GetRotationCamera());

		public override string String => m_Camera.ToString();

		public override Quaternion Get(Args args)
		{
			TCamera tCamera = m_Camera.Get<TCamera>(args);
			if (!(tCamera != null))
			{
				return default(Quaternion);
			}
			return tCamera.transform.rotation;
		}
	}
}

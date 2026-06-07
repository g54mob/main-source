using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	[Title("Previous Shot")]
	[Category("Cameras/Previous Shot")]
	[Image(typeof(IconCameraShot), ColorTheme.Type.Yellow, typeof(OverlayArrowLeft))]
	[Description("Reference to the previous Camera Shot used by a Camera")]
	public class GetGameObjectShotPrevious : PropertyTypeGetGameObject
	{
		[SerializeField]
		protected PropertyGetGameObject m_Camera = GetGameObjectCameraMain.Create;

		public static PropertyGetGameObject Create => new PropertyGetGameObject(new GetGameObjectShotPrevious());

		public override string String => $"{m_Camera} Previous Shot";

		public override GameObject Get(Args args)
		{
			TCamera tCamera = m_Camera.Get<TCamera>(args);
			ShotCamera shotCamera = ((tCamera != null) ? tCamera.Transition.PreviousShotCamera : null);
			if (!(shotCamera != null))
			{
				return null;
			}
			return shotCamera.gameObject;
		}
	}
}

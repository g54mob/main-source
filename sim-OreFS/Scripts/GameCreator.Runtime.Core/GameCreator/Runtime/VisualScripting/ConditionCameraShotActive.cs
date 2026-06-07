using System;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Shot Active")]
	[Description("Returns true if the Camera Shot is assigned to the Main Camera")]
	[Category("Cameras/Is Shot Active")]
	[Parameter("Shot", "The camera shot")]
	[Keywords(new string[] { "Camera", "Enabled", "Assigned", "Running" })]
	[Image(typeof(IconCameraShot), ColorTheme.Type.Green)]
	public class ConditionCameraShotActive : Condition
	{
		[SerializeField]
		private PropertyGetGameObject m_Shot = GetGameObjectShot.Create;

		protected override string Summary => $"is {m_Shot} Active";

		protected override bool Run(Args args)
		{
			ShotCamera shotCamera = m_Shot.Get<ShotCamera>(args);
			if (shotCamera == null)
			{
				return false;
			}
			MainCamera mainCamera = ShortcutMainCamera.Get<MainCamera>();
			if (mainCamera == null)
			{
				return false;
			}
			return mainCamera.Transition.CurrentShotCamera == shotCamera;
		}
	}
}

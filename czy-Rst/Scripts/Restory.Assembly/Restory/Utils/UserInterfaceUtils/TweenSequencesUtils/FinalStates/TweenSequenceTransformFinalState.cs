using System;
using Mandragora.Utils;
using UnityEngine;

namespace Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.FinalStates
{
	[Serializable]
	public class TweenSequenceTransformFinalState
	{
		private enum SettingsType
		{
			Local = 0,
			Global = 1
		}

		private enum TargetType
		{
			Position = 0,
			Transform = 1
		}

		[SerializeField]
		private Transform transformToAffect;

		[SerializeField]
		private SettingsType settingsType;

		[SerializeField]
		[BoolButton(25, 0, Red = false)]
		private bool setPosition;

		[SerializeField]
		private TargetType targetType;

		[SerializeField]
		private Vector3 finalPosition;

		[SerializeField]
		private Transform targetTransformToSetPositionTo;

		[SerializeField]
		[BoolButton(25, 0, Red = false)]
		private bool setRotation;

		[SerializeField]
		private Vector3 finalRotation;

		[SerializeField]
		[BoolButton(25, 0, Red = false)]
		private bool setScale;

		[SerializeField]
		private Vector3 finalScale;

		public void ApplySettings()
		{
			switch (settingsType)
			{
			case SettingsType.Local:
				if (setPosition)
				{
					Transform transform = transformToAffect;
					transform.localPosition = targetType switch
					{
						TargetType.Position => finalPosition, 
						TargetType.Transform => targetTransformToSetPositionTo.localPosition, 
						_ => default(Vector3), 
					};
				}
				if (setRotation)
				{
					transformToAffect.localEulerAngles = finalRotation;
				}
				if (setScale)
				{
					transformToAffect.localScale = finalScale;
				}
				break;
			case SettingsType.Global:
				if (setPosition)
				{
					Transform transform = transformToAffect;
					transform.position = targetType switch
					{
						TargetType.Position => finalPosition, 
						TargetType.Transform => targetTransformToSetPositionTo.position, 
						_ => default(Vector3), 
					};
				}
				if (setRotation)
				{
					transformToAffect.eulerAngles = finalRotation;
				}
				break;
			default:
				throw new NotImplementedException();
			}
		}
	}
}

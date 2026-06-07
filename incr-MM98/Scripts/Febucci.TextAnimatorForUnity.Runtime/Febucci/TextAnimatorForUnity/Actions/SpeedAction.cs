using System;
using System.Globalization;
using Febucci.TextAnimatorCore.Typing;
using Febucci.TextAnimatorCore.Typing.BuiltIn;
using Febucci.TextAnimatorForUnity.Actions.Core;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity.Actions
{
	[Serializable]
	[CreateAssetMenu(menuName = "Text Animator for Unity/Actions/Speed", fileName = "Speed Action")]
	[TagInfo("speed")]
	internal sealed class SpeedAction : CoreLibraryActionScriptableWrapper<SpeedActionState>
	{
		[Tooltip("Speed used in case the action does not have the first parameter")]
		public float defaultSpeed = 2f;

		protected override SpeedActionState CreateState(ActionMarker marker, object typewriter)
		{
			float result = 1f;
			if (marker.parameters != null && marker.parameters.Length != 0 && !float.TryParse(marker.parameters[0], NumberStyles.Float, CultureInfo.InvariantCulture, out result))
			{
				result = defaultSpeed;
			}
			return new SpeedActionState(result);
		}
	}
}

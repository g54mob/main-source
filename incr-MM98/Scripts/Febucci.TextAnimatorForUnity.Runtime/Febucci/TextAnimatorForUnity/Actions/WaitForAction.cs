using System;
using System.Globalization;
using Febucci.TextAnimatorCore.Typing;
using Febucci.TextAnimatorCore.Typing.BuiltIn;
using Febucci.TextAnimatorForUnity.Actions.Core;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity.Actions
{
	[Serializable]
	[CreateAssetMenu(menuName = "Text Animator for Unity/Actions/Wait For Seconds", fileName = "Wait For Seconds Action")]
	[TagInfo("waitfor")]
	internal sealed class WaitForAction : CoreLibraryActionScriptableWrapper<WaitForActionState>
	{
		[Tooltip("Time used in case the action does not have the first parameter")]
		public float defaultTime = 1f;

		protected override WaitForActionState CreateState(ActionMarker marker, object typewriter)
		{
			float result = 1f;
			if (marker.parameters != null && marker.parameters.Length != 0 && !float.TryParse(marker.parameters[0], NumberStyles.Float, CultureInfo.InvariantCulture, out result))
			{
				result = defaultTime;
			}
			return new WaitForActionState(result);
		}
	}
}

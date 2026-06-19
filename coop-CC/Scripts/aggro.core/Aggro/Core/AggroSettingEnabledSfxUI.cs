using FMODUnity;
using UnityEngine;

namespace Aggro.Core
{
	internal sealed class AggroSettingEnabledSfxUI : MonoBehaviour
	{
		public EventReference sfx;

		private void OnEnable()
		{
			AggroUtil.PlaySfxIfValid(sfx);
		}
	}
}

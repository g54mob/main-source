using UnityEngine;

namespace Aggro.Core
{
	public abstract class AggroSettingUI : MonoBehaviour
	{
		public abstract void Set(AggroSettingBase setting);

		public abstract void Refresh();
	}
}

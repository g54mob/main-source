using UnityEngine;

namespace I2.Loc
{
	public class RegisterCallback_AllowSyncFromGoogle : MonoBehaviour
	{
		public void Awake()
		{
		}

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}

		public virtual bool AllowSyncFromGoogle(LanguageSourceData Source)
		{
			return false;
		}
	}
}

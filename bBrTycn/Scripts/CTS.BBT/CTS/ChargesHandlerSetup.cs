using CTS.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace CTS
{
	public class ChargesHandlerSetup : CTSBehaviour
	{
		[FormerlySerializedAs("_financesScriptable")]
		[SerializeField]
		private FinancialSettingsScriptable financialSettingsScriptable;

		private void Start()
		{
			MonoSingleton<ChargesHandlers>.Instance.SetFinancialSettings(financialSettingsScriptable);
		}

		private void OnDestroy()
		{
			if (MonoSingleton<ChargesHandlers>.InstanceExists())
			{
				MonoSingleton<ChargesHandlers>.Instance.SetFinancialSettings(null);
			}
		}
	}
}

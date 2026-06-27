using System;
using Restory.Data.PC;

namespace Restory.Data.Email
{
	[Serializable]
	public class EmailButtonActivateApplicationSettings : EmailButtonSettingsBase
	{
		public PcAppInfo PcAppInfo;
	}
}

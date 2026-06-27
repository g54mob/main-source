using System;
using Restory.Data.InteractiveObjects;

namespace Restory.Data.Email
{
	[Serializable]
	public class EmailButtonDeliverObjectToPlayerSettings : EmailButtonSettingsBase
	{
		public InteractiveObjectInfo ObjectToDeliver;
	}
}

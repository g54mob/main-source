using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSEipix.Base;

namespace NSMedieval.StatsSystem
{
	public class WarningMessageEffect : EffectorBase
	{
		private string messageName;

		public WarningMessageEffect(StatEffector parent)
			: base(EffectorType.WarningMessage, parent)
		{
		}

		public override void InitParameters(Dictionary<string, string> data)
		{
			if (!data.ContainsKey("Type"))
			{
				Log.Error("Key 'type' not found!", "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\Model\\Effectors\\WarningMessageEffect.cs");
			}
			else
			{
				messageName = data["Type"];
			}
		}

		public override void Start(StatsInstance instance)
		{
			if (instance != null && !instance.HasDisposed && !instance.Owner.HasDisposed && !instance.HasDisposed && MonoSingleton<GlobalWarningMessagesManager>.IsInstantiated())
			{
				MonoSingleton<GlobalWarningMessagesManager>.Instance.SetEffectorMessageVisible(messageName, visible: true, instance);
			}
		}

		public override void Stack(StatsInstance instance, float multiplier)
		{
		}

		public override void End(StatsInstance instance)
		{
			if (!MonoSingleton<GlobalSaveController>.IsApplicationIsQuitting() && MonoSingleton<GlobalWarningMessagesManager>.IsInstantiated())
			{
				MonoSingleton<GlobalWarningMessagesManager>.Instance.SetEffectorMessageVisible(messageName, visible: false, instance);
			}
		}
	}
}

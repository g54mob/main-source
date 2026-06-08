using System.Collections.Immutable;
using System.Text;
using Timberborn.Debugging;
using Timberborn.TemplateSystem;
using UnityEngine;

namespace Timberborn.Automation
{
	internal class AutomationDevModule : IDevModule
	{
		private readonly AutomationRunner _automationRunner;

		public AutomationDevModule(AutomationRunner automationRunner)
		{
			_automationRunner = automationRunner;
		}

		public DevModuleDefinition GetDefinition()
		{
			return new DevModuleDefinition.Builder().AddMethod(DevMethod.Create("Automation: Log partitions", LogPartitions)).Build();
		}

		private void LogPartitions()
		{
			StringBuilder stringBuilder = new StringBuilder();
			ImmutableArray<AutomatorPartition>.Enumerator enumerator = _automationRunner.GetPartitionsSnapshot().GetEnumerator();
			while (enumerator.MoveNext())
			{
				AutomatorPartition current = enumerator.Current;
				stringBuilder.AppendLine("Partition " + current.DebuggingId + ":");
				ImmutableArray<Automator>.Enumerator enumerator2 = current.GetPlanSnapshot().GetEnumerator();
				while (enumerator2.MoveNext())
				{
					Automator current2 = enumerator2.Current;
					stringBuilder.Append("  - " + GetTemplateName(current2));
					if (!string.IsNullOrEmpty(current2.AutomatorName))
					{
						stringBuilder.Append(" - " + current2.AutomatorName);
					}
					if (current2.IsTransmitter)
					{
						stringBuilder.Append($" [{current2.UnfinishedState}]");
					}
					stringBuilder.AppendLine();
				}
			}
			Debug.Log(stringBuilder.ToString());
		}

		private static string GetTemplateName(Automator automator)
		{
			if (!automator.TryGetComponent<TemplateSpec>(out var component))
			{
				return automator.Name;
			}
			return component.TemplateName;
		}
	}
}

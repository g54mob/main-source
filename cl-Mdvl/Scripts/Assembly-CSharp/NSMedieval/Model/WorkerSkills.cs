using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Serialization;
using NSMedieval.State.WorkerJobs;
using NSMedieval.StatsSystem;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	[FVSerializableKey("WorkerSkills", "")]
	public class WorkerSkills : IFVSerializable, IDisposable
	{
		[SerializeField]
		private List<WorkerSkill> skills;

		[NonSerialized]
		private bool listenersSet;

		public List<WorkerSkill> Skills
		{
			get
			{
				if (skills == null)
				{
					InitSkills();
				}
				if (listenersSet)
				{
					return skills;
				}
				foreach (WorkerSkill skill in skills)
				{
					skill.OnLevelChangedEvent += OnLevelChangedEvent;
				}
				listenersSet = true;
				return skills;
			}
		}

		public WorkerSkills(IEnumerable<WorkerSkill> newSkills)
		{
			if (newSkills == null)
			{
				return;
			}
			skills = new List<WorkerSkill>();
			foreach (WorkerSkill newSkill in newSkills)
			{
				skills.Add(new WorkerSkill(newSkill.Id, newSkill.Level, 0f, GoalPreferenceLevel.None));
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(23, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\Model\\WorkerSkills.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Adding skill ");
					messageBuilder.AppendFormatted(newSkill.Id);
					messageBuilder.AppendLiteral(", level ");
					messageBuilder.AppendFormatted(newSkill.Level);
					messageBuilder.AppendLiteral(". ");
					messageBuilder.AppendFormatted(StackTraceLog.GetStackTrace());
				}
				Log.Info(messageBuilder);
			}
		}

		public WorkerSkills()
		{
		}

		public void Dispose()
		{
			if (skills == null)
			{
				return;
			}
			foreach (WorkerSkill skill in skills)
			{
				skill.Dispose();
			}
			skills.Clear();
		}

		public WorkerSkill GetSkill(SkillType skill)
		{
			int num = (int)skill;
			if (num < 0)
			{
				num = 0;
			}
			if (num < Skills.Count && skills.Count > 0)
			{
				WorkerSkill workerSkill = skills[num];
				if (workerSkill.Id == skill)
				{
					return workerSkill;
				}
			}
			int i = 0;
			for (int count = Skills.Count; i < count; i++)
			{
				WorkerSkill workerSkill2 = skills[i];
				if (workerSkill2.Id == skill)
				{
					return workerSkill2;
				}
			}
			return null;
		}

		internal bool AddExperience(SkillType skill, float amount)
		{
			return GetSkill(skill)?.AddExperience(amount) ?? false;
		}

		private void OnLevelChangedEvent(SkillType id)
		{
			MonoSingleton<ProductionManager>.Instance.UpdateAllProductionStates();
		}

		private void AddNewSkills()
		{
			if (skills == null)
			{
				return;
			}
			SkillType[] skillTypes = EnumValues.SkillTypes;
			foreach (SkillType skill in skillTypes)
			{
				if (!skills.Any((WorkerSkill workerSkill) => workerSkill.Id == skill))
				{
					bool isEnabled;
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(19, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\Model\\WorkerSkills.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Adding new skill ");
						messageBuilder.AppendFormatted(skill);
						messageBuilder.AppendLiteral(". ");
						messageBuilder.AppendFormatted(StackTraceLog.GetStackTrace());
					}
					Log.Info(messageBuilder);
					WorkerSkill item = new WorkerSkill(skill);
					skills.Add(item);
				}
			}
		}

		private void InitSkills()
		{
			if (skills != null)
			{
				return;
			}
			skills = new List<WorkerSkill>();
			SkillType[] skillTypes = EnumValues.SkillTypes;
			foreach (SkillType skillType in skillTypes)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(15, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\Model\\WorkerSkills.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Adding skill ");
					messageBuilder.AppendFormatted(skillType);
					messageBuilder.AppendLiteral(". ");
					messageBuilder.AppendFormatted(StackTraceLog.GetStackTrace());
				}
				Log.Info(messageBuilder);
				WorkerSkill workerSkill = new WorkerSkill(skillType);
				skills.Add(workerSkill);
				workerSkill.OnLevelChangedEvent += OnLevelChangedEvent;
			}
			listenersSet = true;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("skills", skills);
		}

		public WorkerSkills(FVDeserializer deserializer)
		{
			skills = deserializer.ReadObjectList<WorkerSkill>("skills");
			if (skills?.Count != EnumValues.SkillTypes.Length)
			{
				AddNewSkills();
			}
		}
	}
}

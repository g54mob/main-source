using System;
using Assets.Nimbatus.GUI.Common.Scripts;

namespace Assets.Nimbatus.Scripts.Missions.Objectives
{
	[Serializable]
	public abstract class MissionObjective
	{
		public TranslationTerm ObjectiveText;

		public abstract bool IsFullfilled();

		public abstract string GetStatusText();

		public abstract void ResetProgress();

		public abstract void Init();

		public abstract void SetFullfilled();
	}
}

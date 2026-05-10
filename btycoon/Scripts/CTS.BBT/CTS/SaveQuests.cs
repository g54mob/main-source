using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class SaveQuests : SaveContainer
	{
		public override void Save(ES3Settings settings)
		{
			QuestChain questChain = ComponentGetter.GetComponentSingleSingleton(typeof(QuestChain)) as QuestChain;
			if (!(questChain == null))
			{
				DialogueQuest[] componentsInChildren = questChain.GetComponentsInChildren<DialogueQuest>(includeInactive: true);
				foreach (DialogueQuest dialogueQuest in componentsInChildren)
				{
					ES3.Save("Dialogue" + dialogueQuest.name, dialogueQuest, settings);
				}
				if (questChain is Level01QuestChain level01QuestChain)
				{
					ES3.Save("Level01QuestChain", level01QuestChain, settings);
					SaveChild<MainQuest02>(level01QuestChain, includeInactive: true, settings);
					SaveChild<MainQuest10>(level01QuestChain, includeInactive: true, settings);
					SaveChild<MainQuest20>(level01QuestChain, includeInactive: true, settings);
				}
				else if ((bool)questChain)
				{
					SaveChild<MainQuest23>(questChain, includeInactive: true, settings);
					SaveChild<MainQuest24>(questChain, includeInactive: true, settings);
					SaveChild<MainQuest25>(questChain, includeInactive: true, settings);
					SaveChild<MainQuest26>(questChain, includeInactive: true, settings);
					SaveChild<MainQuest27>(questChain, includeInactive: true, settings);
					SaveChild<MainQuest28>(questChain, includeInactive: true, settings);
					SaveChild<MainQuest29>(questChain, includeInactive: true, settings);
					SaveChild<MainQuest30>(questChain, includeInactive: true, settings);
					SaveChild<MainQuest31>(questChain, includeInactive: true, settings);
					SaveChild<MainQuest32>(questChain, includeInactive: true, settings);
				}
			}
		}

		public override void LoadInit(ES3Settings settings)
		{
			QuestChain questChain = ComponentGetter.GetComponentSingleSingleton(typeof(QuestChain)) as QuestChain;
			if (questChain == null)
			{
				return;
			}
			DialogueQuest[] componentsInChildren = questChain.GetComponentsInChildren<DialogueQuest>(includeInactive: true);
			foreach (DialogueQuest dialogueQuest in componentsInChildren)
			{
				string key = "Dialogue" + dialogueQuest.name;
				if (ES3.KeyExists(key, settings))
				{
					ES3.LoadInto(key, dialogueQuest, settings);
				}
			}
			if (questChain is Level01QuestChain level01QuestChain)
			{
				LoadInto("Level01QuestChain", level01QuestChain, settings);
				LoadIntoChild<MainQuest02>(level01QuestChain, includeInactive: true, settings);
				LoadIntoChild<MainQuest10>(level01QuestChain, includeInactive: true, settings);
				LoadIntoChild<MainQuest20>(level01QuestChain, includeInactive: true, settings);
			}
			else if ((bool)questChain)
			{
				LoadIntoChild<MainQuest23>(questChain, includeInactive: true, settings);
				LoadIntoChild<MainQuest24>(questChain, includeInactive: true, settings);
				LoadIntoChild<MainQuest25>(questChain, includeInactive: true, settings);
				LoadIntoChild<MainQuest26>(questChain, includeInactive: true, settings);
				LoadIntoChild<MainQuest27>(questChain, includeInactive: true, settings);
				LoadIntoChild<MainQuest28>(questChain, includeInactive: true, settings);
				LoadIntoChild<MainQuest29>(questChain, includeInactive: true, settings);
				LoadIntoChild<MainQuest30>(questChain, includeInactive: true, settings);
				LoadIntoChild<MainQuest31>(questChain, includeInactive: true, settings);
				LoadIntoChild<MainQuest32>(questChain, includeInactive: true, settings);
			}
		}

		public override void LoadPost(ES3Settings settings)
		{
			LoadInit(settings);
		}

		private void SaveChild<T>(Component parent, bool includeInactive, ES3Settings settings, string key = "") where T : Component
		{
			T componentInChildren = parent.GetComponentInChildren<T>(includeInactive);
			if ((bool)componentInChildren)
			{
				if (string.IsNullOrEmpty(key))
				{
					key = typeof(T).Name;
				}
				ES3.Save(key, componentInChildren, settings);
			}
		}

		private void LoadIntoChild<T>(Component parent, bool includeInactive, ES3Settings settings, string key = "") where T : Component
		{
			T componentInChildren = parent.GetComponentInChildren<T>(includeInactive);
			if ((bool)componentInChildren)
			{
				if (string.IsNullOrEmpty(key))
				{
					key = typeof(T).Name;
				}
				LoadInto(key, componentInChildren, settings);
			}
		}
	}
}

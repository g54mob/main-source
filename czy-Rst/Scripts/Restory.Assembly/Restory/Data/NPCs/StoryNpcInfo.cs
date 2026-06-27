using System;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using Restory.Data.Base;
using UnityEngine;
using UnityEngine.Serialization;

namespace Restory.Data.NPCs
{
	[CreateAssetMenu(menuName = "Restory/NPC Visits and Work Orders/NPC", fileName = "NPC - Name")]
	public class StoryNpcInfo : RestoryEntityInfoBase, INpcInfo
	{
		private static class Style
		{
			public const string DialogueSystemSettings = "Dialogue System Settings";
		}

		[Serializable]
		private class NpcTextureEntry
		{
			public string ID;

			public Texture2D Texture;
		}

		[Serializable]
		private class NpcEmotionEntry
		{
			public NpcEmotionInfo EmotionInfo;

			public NpcEmotionData EmotionData;
		}

		[SerializeField]
		private string nameLocalizationKey;

		[SerializeField]
		private GameObject prefab;

		[FormerlySerializedAs("npcTexture")]
		[SerializeField]
		private Texture2D defaultNpcTexture;

		[SerializeField]
		private NpcTextureEntry[] additionalTextureEntries = new NpcTextureEntry[0];

		[SerializeField]
		private NpcSpawnAndExitPoints spawnAndExitPoints;

		[SerializeField]
		[ActorPopup(false, showReferenceDatabase = true)]
		private string[] dialogueActors = new string[0];

		[SerializeField]
		[ConversationPopup(false, false)]
		private string dialogueActorLogicCenterConversation;

		[SerializeField]
		private NpcEmotionEntry[] emotionsEntries = new NpcEmotionEntry[0];

		private Dictionary<string, Texture2D> additionalNpcTexturesDictionary;

		private Dictionary<NpcEmotionInfo, NpcEmotionData> emotionsDictionary;

		public string NameLocalizationKey => nameLocalizationKey;

		public GameObject Prefab => prefab;

		public Texture2D DefaultNpcTexture => defaultNpcTexture;

		public NpcSpawnAndExitPoints SpawnAndExitPoints => spawnAndExitPoints;

		public IReadOnlyList<string> DialogueActors => dialogueActors;

		public string DialogueActorLogicCenterConversation => dialogueActorLogicCenterConversation;

		public bool TryToGetTexture(string textureID, out Texture2D npcTexture)
		{
			if (string.IsNullOrEmpty(textureID) || textureID.ToLower() == "default")
			{
				npcTexture = defaultNpcTexture;
				return true;
			}
			return TryToGetAdditionalTexture(textureID, out npcTexture);
		}

		public Texture2D GetTextureByIdOrDefaultTexture(string textureID)
		{
			if (string.IsNullOrEmpty(textureID) || textureID.ToLower() == "default")
			{
				return defaultNpcTexture;
			}
			if (!TryToGetAdditionalTexture(textureID, out var npcTexture))
			{
				npcTexture = defaultNpcTexture;
				Debug.LogWarning("[StoryNpcInfo] was unable to find texture with ID " + textureID + "! Falling back to default texture instead.");
			}
			return npcTexture;
		}

		public bool TryToGetAdditionalTexture(string textureID, out Texture2D npcTexture)
		{
			if (additionalNpcTexturesDictionary == null)
			{
				additionalNpcTexturesDictionary = new Dictionary<string, Texture2D>();
				FillAdditionalTexturesDictionary();
			}
			return additionalNpcTexturesDictionary.TryGetValue(textureID, out npcTexture);
		}

		public bool TryToGetEmotionDataByInfo(NpcEmotionInfo emotionInfo, out NpcEmotionData emotionData)
		{
			if (emotionsDictionary == null)
			{
				emotionsDictionary = new Dictionary<NpcEmotionInfo, NpcEmotionData>();
				NpcEmotionEntry[] array = emotionsEntries;
				foreach (NpcEmotionEntry npcEmotionEntry in array)
				{
					if (npcEmotionEntry != null && (bool)npcEmotionEntry.EmotionInfo)
					{
						emotionsDictionary.Add(npcEmotionEntry.EmotionInfo, npcEmotionEntry.EmotionData);
					}
				}
			}
			return emotionsDictionary.TryGetValue(emotionInfo, out emotionData);
		}

		private void FillAdditionalTexturesDictionary()
		{
			NpcTextureEntry[] array = additionalTextureEntries;
			foreach (NpcTextureEntry npcTextureEntry in array)
			{
				if (npcTextureEntry != null && !string.IsNullOrEmpty(npcTextureEntry.ID) && (bool)npcTextureEntry.Texture)
				{
					additionalNpcTexturesDictionary.Add(npcTextureEntry.ID, npcTextureEntry.Texture);
				}
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using PixelCrushers.DialogueSystem;
using Restory.Data.Base;
using UnityEngine;
using UnityEngine.Pool;

namespace Restory.Data.Microstories
{
	[CreateAssetMenu(menuName = "Restory/NPC Visits and Work Orders/MicroStory", fileName = "MicroStory - Name")]
	public class MicroStoryInfo : RestoryEntityInfoBase
	{
		[SerializeField]
		private NpcGenderOptions npcGender;

		[SerializeField]
		private NpcAgeOptions npcAllowedAge;

		[SerializeField]
		private NpcCustomizationOptions requiredNpcCustomizationTags;

		[SerializeField]
		private NpcCustomizationOptions excludedNpcCustomizationTags;

		[SerializeField]
		[ConversationPopup(true, false)]
		private string startingConversation;

		[SerializeField]
		[ConversationPopup(true, false)]
		private string closingConversation;

		[SerializeField]
		private NpcCustomizationGroupsList npcCustomizationGroupsList;

		public NpcGenderOptions NpcGender => npcGender;

		public NpcAgeOptions NpcAllowedAge => npcAllowedAge;

		public NpcCustomizationOptions RequiredNpcCustomizationTags => requiredNpcCustomizationTags;

		public NpcCustomizationOptions ExcludedNpcCustomizationTags => excludedNpcCustomizationTags;

		public string StartingConversation => startingConversation;

		public string ClosingConversation => closingConversation;

		public GeneratedNpcSelectedOptions GenerateNPC()
		{
			GeneratedNpcSelectedOptions generatedNpcSelectedOptions = new GeneratedNpcSelectedOptions();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("NPC generated:");
			generatedNpcSelectedOptions.Gender = ((npcGender == NpcGenderOptions.Any) ? GetSingleRandomOptionFromEnum<NpcGenderOptions>() : npcGender);
			generatedNpcSelectedOptions.Age = ((npcAllowedAge == NpcAgeOptions.Any) ? GetSingleRandomOptionFromEnum<NpcAgeOptions>() : GetSingleRandomOptionFromEnum(npcAllowedAge));
			generatedNpcSelectedOptions.Customization = GetOptionsFromRequiredAndExcludedEnum(requiredNpcCustomizationTags, excludedNpcCustomizationTags);
			stringBuilder.AppendLine($"Gender - {generatedNpcSelectedOptions.Gender}");
			stringBuilder.AppendLine($"Age - {generatedNpcSelectedOptions.Age}");
			stringBuilder.AppendLine($"Customization - {generatedNpcSelectedOptions.Customization}");
			Debug.Log(stringBuilder.ToString());
			return generatedNpcSelectedOptions;
		}

		private T GetSingleRandomOptionFromEnum<T>() where T : struct, Enum
		{
			List<T> list = CollectionPool<List<T>, T>.Get();
			FillEnumValuesListWithAllValues(list);
			int index = UnityEngine.Random.Range(0, list.Count);
			T result = list[index];
			CollectionPool<List<T>, T>.Release(list);
			return result;
		}

		private T GetSingleRandomOptionFromEnum<T>(T allowedOptions) where T : struct, Enum
		{
			List<T> list = CollectionPool<List<T>, T>.Get();
			FillEnumValuesListWithAllowedValues(list, allowedOptions);
			int index = UnityEngine.Random.Range(0, list.Count);
			T result = list[index];
			CollectionPool<List<T>, T>.Release(list);
			return result;
		}

		private NpcCustomizationOptions GetOptionsFromRequiredAndExcludedEnum(NpcCustomizationOptions requiredOptions, NpcCustomizationOptions excludedOptions)
		{
			List<NpcCustomizationOptions> list = CollectionPool<List<NpcCustomizationOptions>, NpcCustomizationOptions>.Get();
			FillEnumValuesListWithAllValues(list);
			NpcCustomizationOptions npcCustomizationOptions = NpcCustomizationOptions.None;
			NpcCustomizationOptionsGroup[] customizationGroups = npcCustomizationGroupsList.CustomizationGroups;
			foreach (NpcCustomizationOptionsGroup npcCustomizationOptionsGroup in customizationGroups)
			{
				NpcCustomizationOptions npcCustomizationOptions2 = requiredOptions & npcCustomizationOptionsGroup.AllOptionsInGroup;
				if (npcCustomizationOptions2 == NpcCustomizationOptions.None)
				{
					NpcCustomizationOptions npcCustomizationOptions3 = npcCustomizationOptionsGroup.AllOptionsInGroup & ~excludedOptions;
					List<NpcCustomizationOptions> list2 = CollectionPool<List<NpcCustomizationOptions>, NpcCustomizationOptions>.Get();
					foreach (NpcCustomizationOptions item in list)
					{
						if (npcCustomizationOptions3.HasFlag(item))
						{
							list2.Add(item);
						}
					}
					int num = UnityEngine.Random.Range(0, npcCustomizationOptionsGroup.CanBeEmpty ? (list2.Count + 1) : list2.Count);
					if (num < list2.Count)
					{
						npcCustomizationOptions |= list2[num];
					}
					CollectionPool<List<NpcCustomizationOptions>, NpcCustomizationOptions>.Release(list2);
				}
				else
				{
					npcCustomizationOptions |= npcCustomizationOptions2;
				}
			}
			CollectionPool<List<NpcCustomizationOptions>, NpcCustomizationOptions>.Release(list);
			return npcCustomizationOptions;
		}

		private static void FillEnumValuesListWithAllValues<T>(List<T> allValidEnumValues) where T : struct, Enum
		{
			foreach (T value in Enum.GetValues(typeof(T)))
			{
				if (Convert.ToInt64(value) != 0L)
				{
					allValidEnumValues.Add(value);
				}
			}
		}

		private static void FillEnumValuesListWithAllowedValues<T>(List<T> allValidEnumValues, T allowedFlags) where T : struct, Enum
		{
			foreach (T value in Enum.GetValues(typeof(T)))
			{
				if (Convert.ToInt64(value) != 0L && allowedFlags.HasFlag(value))
				{
					allValidEnumValues.Add(value);
				}
			}
		}

		[UsedImplicitly]
		private bool ValidateRequiredCustomizationTags()
		{
			NpcCustomizationOptionsGroup[] customizationGroups = npcCustomizationGroupsList.CustomizationGroups;
			for (int i = 0; i < customizationGroups.Length; i++)
			{
				long num = Convert.ToInt64(customizationGroups[i].AllOptionsInGroup & requiredNpcCustomizationTags);
				int num2 = 0;
				while (num != 0L)
				{
					num &= num - 1;
					num2++;
				}
				if (num2 > 1)
				{
					return false;
				}
			}
			return true;
		}

		[UsedImplicitly]
		private bool ValidateExcludedCustomizationTags()
		{
			return (requiredNpcCustomizationTags & excludedNpcCustomizationTags) == 0;
		}
	}
}

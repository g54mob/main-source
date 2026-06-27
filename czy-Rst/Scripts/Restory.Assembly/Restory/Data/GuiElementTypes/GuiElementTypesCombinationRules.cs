using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Restory.Data.GuiElementTypes
{
	[CreateAssetMenu(menuName = "Restory/GUI/Gui Element Types Combination Rules", fileName = "GuiElementTypesCombinationRules", order = 22)]
	public class GuiElementTypesCombinationRules : ScriptableObject, ISerializationCallbackReceiver
	{
		[Serializable]
		public class GuiElementTypesAllowedTogether
		{
			public GuiElementType GuiElementType1;

			public GuiElementType GuiElementType2;
		}

		[SerializeField]
		private GuiElementType[] guiElementTypes = Array.Empty<GuiElementType>();

		[SerializeField]
		[HideInInspector]
		private List<GuiElementTypesAllowedTogether> elementTypesAllowedTogether;

		private void OnValidate()
		{
			if (elementTypesAllowedTogether == null)
			{
				elementTypesAllowedTogether = new List<GuiElementTypesAllowedTogether>();
			}
		}

		public bool CanBeShownTogether(GuiElementType guiElementType1, GuiElementType guiElementType2)
		{
			if (!(guiElementType1 == null) && !(guiElementType2 == null) && !(guiElementType1.ID == guiElementType2.ID) && IsInGuiElementTypesList(guiElementType1) && IsInGuiElementTypesList(guiElementType2))
			{
				return AreGuiElementTypesAllowedTogether(guiElementType1, guiElementType2);
			}
			return true;
		}

		private bool AreGuiElementTypesAllowedTogether(GuiElementType guiElementType1, GuiElementType guiElementType2)
		{
			foreach (GuiElementTypesAllowedTogether item in elementTypesAllowedTogether)
			{
				if ((item.GuiElementType1.ID == guiElementType1.ID && item.GuiElementType2.ID == guiElementType2.ID) || (item.GuiElementType2.ID == guiElementType1.ID && item.GuiElementType1.ID == guiElementType2.ID))
				{
					return true;
				}
			}
			return false;
		}

		private bool IsInGuiElementTypesList(GuiElementType guiElementType)
		{
			GuiElementType[] array = guiElementTypes;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].ID == guiElementType.ID)
				{
					return true;
				}
			}
			return false;
		}

		public void SetRule(GuiElementType guiElementType1, GuiElementType guiElementType2, bool canBeShownTogether)
		{
			GuiElementTypesAllowedTogether guiElementTypesAllowedTogether = elementTypesAllowedTogether.Find((GuiElementTypesAllowedTogether x) => (guiElementType1 == x.GuiElementType1 && guiElementType2 == x.GuiElementType2) || (guiElementType1 == x.GuiElementType2 && guiElementType2 == x.GuiElementType1));
			if (guiElementTypesAllowedTogether == null && canBeShownTogether)
			{
				elementTypesAllowedTogether.Add(new GuiElementTypesAllowedTogether
				{
					GuiElementType1 = guiElementType1,
					GuiElementType2 = guiElementType2
				});
			}
			else if (guiElementTypesAllowedTogether != null && !canBeShownTogether)
			{
				elementTypesAllowedTogether.Remove(guiElementTypesAllowedTogether);
			}
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
			for (int num = elementTypesAllowedTogether.Count - 1; num >= 0; num--)
			{
				if (!guiElementTypes.Contains(elementTypesAllowedTogether[num].GuiElementType1) || !guiElementTypes.Contains(elementTypesAllowedTogether[num].GuiElementType2))
				{
					elementTypesAllowedTogether.RemoveAt(num);
				}
			}
		}
	}
}

using System;
using Restory.Data.Elements;
using Restory.Data.Elements.Condition;
using Restory.Gameplay.Soldering;
using Restory.Gameplay.TextureMasks;
using UnityEngine;

namespace Restory.Gameplay.Elements
{
	[Serializable]
	public class ElementData
	{
		public ElementConditionBase Condition;

		public ElementInfo Info;

		public float NoiseSeed;

		public Vector2Int DirtMaskTextureSize;

		public int DirtMaskTextureId;

		public ElementDirtyPixelsData DirtyPixelsData = new ElementDirtyPixelsData();

		public bool IsInspected;

		public TextureUsageOptions DirtTextureOption = TextureUsageOptions.UseGeneratedTexture;

		public MaskPresetInfoBase DirtMaskPresetOverride;

		public ElementAdditionalProperty AdditionalProperty { get; set; }

		public bool JustSolderingNeeded()
		{
			if (AdditionalProperty is ScorchedCircuitProperty scorchedCircuitProperty)
			{
				return scorchedCircuitProperty.PreparedToSoldering();
			}
			return false;
		}

		private bool IsConditionDirty()
		{
			return Condition is DirtyElementCondition;
		}

		public bool IsIdenticalTo(ElementData otherElementData)
		{
			if (!IsConditionDirty() && Info == otherElementData.Info && Condition.ID == otherElementData.Condition.ID)
			{
				return IsInspected == otherElementData.IsInspected;
			}
			return false;
		}

		public ElementData Clone()
		{
			return (ElementData)MemberwiseClone();
		}
	}
}

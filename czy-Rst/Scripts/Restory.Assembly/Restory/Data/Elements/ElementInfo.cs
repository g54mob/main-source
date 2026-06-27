using System.Collections.Generic;
using Mandragora.Utils;
using Restory.Data.Base;
using Restory.Data.Devices;
using Restory.Data.Elements.ElementTypes;
using Restory.Gameplay.Elements;
using UnityEngine;

namespace Restory.Data.Elements
{
	[CreateAssetMenu(menuName = "Restory/Elements/ElementInfo", fileName = "Name - ElementInfo")]
	public class ElementInfo : RestoryEntityInfoBase, IElementInfo
	{
		[SerializeField]
		private string nameLocalizationKey;

		[SerializeField]
		private ElementCategory category;

		[SerializeField]
		private ElementBase prefab;

		[SerializeField]
		[Min(1f)]
		private int maxStackCount = 1;

		[SerializeField]
		private ElementMaterialType elementMaterialType;

		[Space]
		[SerializeField]
		[BoolButton(20, 0)]
		private bool isNotCriticalElement;

		[SerializeField]
		[BoolButton(20, 0, Red = false)]
		private bool isNeverGeneratedDirty;

		[SerializeField]
		[BoolButton(20, 0, Red = false)]
		private bool isNeverGeneratedBroken;

		[SerializeField]
		private List<float> provenNoiseSeeds;

		public string NameLocalizationKey => nameLocalizationKey;

		public ElementCategory Category => category;

		public ElementBase Prefab => prefab;

		public int MaxStackCount => maxStackCount;

		public bool IsCriticalElement => !isNotCriticalElement;

		public IDeviceInfo SourceDevice { get; set; }

		public ElementMaterialType ElementMaterialType => elementMaterialType;

		public bool CanBeDirty
		{
			get
			{
				if (category == ElementCategory.Draggable)
				{
					return !isNeverGeneratedDirty;
				}
				return false;
			}
		}

		public bool CanBeBroken
		{
			get
			{
				if (category == ElementCategory.Draggable)
				{
					return !isNeverGeneratedBroken;
				}
				return false;
			}
		}

		public IReadOnlyList<float> ProvenNoiseSeeds => provenNoiseSeeds;
	}
}

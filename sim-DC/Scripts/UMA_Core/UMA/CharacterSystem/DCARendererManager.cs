using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA.CharacterSystem
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(DynamicCharacterAvatar))]
	public class DCARendererManager : MonoBehaviour
	{
		[Serializable]
		public class RendererElement
		{
			public List<UMARendererAsset> rendererAssets;

			public List<SlotDataAsset> slotAssets;

			public List<string> wardrobeSlots;
		}

		public List<RendererElement> RendererElements;

		private bool lastState;

		public bool RenderersEnabled;

		private DynamicCharacterAvatar avatar;

		private UMAData.UMARecipe umaRecipe;

		private List<SlotDataAsset> wardrobeSlotAssets;

		private UMAContextBase context;

		private List<SlotData> slotsToAdd;

		[SerializeField]
		private bool showHelp;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void CharacterBegun(UMAData umaData)
		{
		}

		private bool HasSlot(List<SlotDataAsset> slots, string slotName)
		{
			return false;
		}
	}
}

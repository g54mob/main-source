using System;
using System.Collections.Generic;
using UnityEngine;

namespace NSMedieval.Construction
{
	[Serializable]
	public class MeshVariation
	{
		[SerializeField]
		private string name;

		[SerializeField]
		private List<SlotPropertySetter> slots;

		[SerializeField]
		private string icon;

		private Dictionary<string, string> meshBySlot = new Dictionary<string, string>();

		private Dictionary<string, string> textureBySlot = new Dictionary<string, string>();

		private bool initDone;

		private bool hasShaderParams;

		public string Name => name;

		public List<SlotPropertySetter> Slots => slots;

		public string Icon => icon;

		public bool HasShaderParams
		{
			get
			{
				InitMeshBySlot();
				return hasShaderParams;
			}
		}

		public bool HasMeshSlots
		{
			get
			{
				InitMeshBySlot();
				return meshBySlot.Count > 0;
			}
		}

		public bool HasTextureSlots
		{
			get
			{
				InitMeshBySlot();
				return textureBySlot.Count > 0;
			}
		}

		public string GetMeshName(string meshSlot)
		{
			InitMeshBySlot();
			if (meshBySlot.TryGetValue(meshSlot, out var value))
			{
				return value;
			}
			return string.Empty;
		}

		public string GetTextureName(string rendererSlotSlotName)
		{
			InitMeshBySlot();
			if (textureBySlot.TryGetValue(rendererSlotSlotName, out var value))
			{
				return value;
			}
			return string.Empty;
		}

		private void InitMeshBySlot()
		{
			if (initDone)
			{
				return;
			}
			if (meshBySlot == null)
			{
				meshBySlot = new Dictionary<string, string>();
			}
			if (textureBySlot == null)
			{
				textureBySlot = new Dictionary<string, string>();
			}
			initDone = true;
			foreach (SlotPropertySetter slot in slots)
			{
				if (slot.SlotType == SlotType.Mesh)
				{
					if (!meshBySlot.ContainsKey(slot.Slot))
					{
						meshBySlot.Add(slot.Slot, slot.Value);
					}
				}
				else if (slot.SlotType == SlotType.Texture)
				{
					if (!textureBySlot.ContainsKey(slot.Slot))
					{
						textureBySlot.Add(slot.Slot, slot.Value);
					}
				}
				else if (slot.SlotType == SlotType.ShaderParam)
				{
					hasShaderParams = true;
				}
			}
		}
	}
}

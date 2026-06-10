using System;
using UnityEngine;

namespace NSMedieval.Construction
{
	[Serializable]
	public class SlotPropertySetter
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private string slotType;

		[SerializeField]
		private string slot;

		[SerializeField]
		private string textureSlot;

		[SerializeField]
		private string value;

		[SerializeField]
		private SetShaderParam shaderParam;

		private bool slotTypeInitialized;

		private SlotType slotTypeCache;

		public string Slot => slot;

		public string Value => value;

		public SlotType SlotType
		{
			get
			{
				if (!slotTypeInitialized)
				{
					if (!Enum.TryParse<SlotType>(slotType, ignoreCase: true, out slotTypeCache))
					{
						slotTypeCache = SlotType.Mesh;
					}
					slotTypeInitialized = true;
				}
				return slotTypeCache;
			}
		}

		public SetShaderParam ShaderParam => shaderParam;
	}
}

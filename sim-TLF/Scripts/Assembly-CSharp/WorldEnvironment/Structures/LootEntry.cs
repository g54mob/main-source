using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace WorldEnvironment.Structures
{
	[Serializable]
	public class LootEntry
	{
		[Tooltip("Addressable посилання на префаб айтему")]
		public AssetReference ItemRef;

		[Range(0f, 1f)]
		[Tooltip("Шанс що цей айтем взагалі випаде (0 = ніколи, 1 = завжди)")]
		public float DropChance = 0.5f;

		[Tooltip("Мінімальна кількість що додається якщо айтем випав")]
		[Min(1f)]
		public int MinCount = 1;

		[Tooltip("Максимальна кількість що додається якщо айтем випав")]
		[Min(1f)]
		public int MaxCount = 1;

		[Tooltip("Лейбл для зручності в інспекторі — не впливає на логіку")]
		public string EditorLabel = "";
	}
}

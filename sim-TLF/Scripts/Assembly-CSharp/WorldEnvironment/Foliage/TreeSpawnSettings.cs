using System;
using UnityEngine;

namespace WorldEnvironment.Foliage
{
	[Serializable]
	public class TreeSpawnSettings
	{
		[Tooltip("Індекс прототипу дерева у TerrainData.treePrototypes[]")]
		public int TreePrototypeIndex;

		[Tooltip("Назва для зручності в інспекторі — не впливає на логіку")]
		public string EditorLabel = "Tree";

		[Range(0f, 1f)]
		[Tooltip("Шанс що дерево заспавниться в кожній точці кандидата")]
		public float SpawnChance = 0.3f;

		[Tooltip("Мінімальна відстань між деревами цього типу")]
		public float MinDistance = 3f;

		[Tooltip("Максимальний кут нахилу де може рости це дерево")]
		public float MaxSteepness = 25f;

		[Header("Розмір")]
		public float MinHeight = 0.8f;

		public float MaxHeight = 1.2f;

		public float MinWidth = 0.8f;

		public float MaxWidth = 1.2f;

		[Tooltip("Рандомний поворот по Y")]
		public bool RandomRotation = true;
	}
}

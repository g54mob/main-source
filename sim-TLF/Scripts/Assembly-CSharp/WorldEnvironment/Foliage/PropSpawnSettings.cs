using System;
using UnityEngine;

namespace WorldEnvironment.Foliage
{
	[Serializable]
	public class PropSpawnSettings
	{
		[Tooltip("Prefab каміння або іншого декору")]
		public GameObject Prefab;

		[Tooltip("Назва для зручності в інспекторі")]
		public string EditorLabel = "Rock";

		[Range(0f, 1f)]
		[Tooltip("Шанс спавну в кожній точці кандидата")]
		public float SpawnChance = 0.15f;

		[Tooltip("Мінімальна відстань між об'єктами цього типу")]
		public float MinDistance = 2f;

		[Tooltip("Максимальний кут нахилу поверхні де може з'явитись цей об'єкт. Для каміння можна ставити вище ніж для дерев.")]
		public float MaxSteepness = 45f;

		[Header("Масштаб")]
		public float MinScale = 0.7f;

		public float MaxScale = 1.4f;

		[Tooltip("Вирівнювати об'єкт по нормалі терейну (корисно для каміння на схилах)")]
		public bool AlignToTerrainNormal = true;

		[Tooltip("Рандомний поворот по Y навіть при AlignToTerrainNormal")]
		public bool RandomYRotation = true;
	}
}

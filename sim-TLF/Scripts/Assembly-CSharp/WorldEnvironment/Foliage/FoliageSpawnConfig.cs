using System.Collections.Generic;
using UnityEngine;

namespace WorldEnvironment.Foliage
{
	[CreateAssetMenu(fileName = "FoliageSpawnConfig", menuName = "World/Foliage Spawn Config")]
	public class FoliageSpawnConfig : ScriptableObject
	{
		[Header("Дерева (Terrain Tree System)")]
		[Tooltip("Список типів дерев для спавну. ВАЖЛИВО: префаби мають бути заздалегідь додані до TerrainData → Tree Prototypes. TreePrototypeIndex — це індекс у тому списку.")]
		public List<TreeSpawnSettings> Trees = new List<TreeSpawnSettings>();

		[Header("Каміння / Декор (Prefab Instantiate)")]
		[Tooltip("Список декоративних об'єктів що спавняться як звичайні prefab'и. Підходить для каміння, пнів, трави-пучків тощо.")]
		public List<PropSpawnSettings> Props = new List<PropSpawnSettings>();

		[Header("Global")]
		[Tooltip("Крок сітки семплювання поверхні терейну в Unity одиницях. Менше = точніше але повільніше. Рекомендовано 2-4.")]
		public float SurfaceSampleStep = 2f;

		[Tooltip("Максимальний кут нахилу поверхні де дозволений спавн будь-чого (глобальний ліміт)")]
		public float GlobalMaxSteepness = 35f;
	}
}

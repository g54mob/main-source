using System.Collections.Generic;
using UnityEngine;

namespace WorldEnvironment.Structures
{
	[CreateAssetMenu(fileName = "StructureSpawnConfig", menuName = "World/Structure Spawn Config")]
	public class StructureSpawnConfig : ScriptableObject
	{
		public List<StructureSettings> Structures;

		[Header("Global Settings")]
		[Tooltip("Максимальна загальна кількість структур на острів")]
		public int MaxStructuresPerIsland = 5;

		[Tooltip("Радіус острова в Unity одиницях — визначає зону для спавну")]
		public float IslandRadius = 50f;

		[Tooltip("Максимальна кількість точок поверхні що перевіряються при пошуку позиції для структури. Більше = краще покриття але повільніше. Рекомендовано 20-50.")]
		public int MaxRetries = 30;

		[Header("Boundary Check")]
		[Tooltip("Крок семплювання вздовж лінії між баунд точками в Unity одиницях.")]
		public float BoundaryCheckStep = 0.5f;

		[Tooltip("Максимально допустимий перепад висот між сусідніми семплами вздовж лінії між баунд точками.")]
		public float MaxHeightDifference = 0.5f;

		[Tooltip("Крок повороту по Y в градусах при пошуку валідної ротації.")]
		[Range(1f, 90f)]
		public float RotationSearchStep = 15f;
	}
}

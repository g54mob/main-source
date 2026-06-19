using UnityEngine;

namespace WorldEnvironment
{
	public enum ObjectUpAxis
	{
		[Tooltip("Вісь Y — стандарт для більшості об'єктів Unity")]
		Y = 0,
		[Tooltip("Вісь X — об'єкт дивиться боком відносно стандартної орієнтації")]
		X = 1,
		[Tooltip("Вісь Z — наприклад деякі імпортовані моделі з Blender")]
		Z = 2,
		[Tooltip("Вісь -Y — об'єкт перевернутий відносно стандарту")]
		NegativeY = 3,
		[Tooltip("Вісь -X")]
		NegativeX = 4,
		[Tooltip("Вісь -Z")]
		NegativeZ = 5
	}
}

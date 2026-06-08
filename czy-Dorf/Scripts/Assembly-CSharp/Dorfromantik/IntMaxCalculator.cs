using UnityEngine;

namespace Dorfromantik
{
	public class IntMaxCalculator : MonoBehaviour
	{
		[SerializeField]
		private Vector2Int maxInt = new Vector2Int(int.MinValue, int.MaxValue);

		private void CalculateMultiplication(int value)
		{
			if (value < 0)
			{
				value *= -1;
			}
			Debug.Log($"{maxInt.x + maxInt.x + maxInt.x} {maxInt.y + maxInt.y + maxInt.y}");
			Debug.Log($"{maxInt.x * 3} {maxInt.y * 3}");
			Debug.Log($"{maxInt.x * 2} {maxInt.y * 2}");
			Debug.Log($"{maxInt.x * maxInt.x} {maxInt.y * maxInt.y}");
			Debug.Log("ADDITION");
			for (int i = 0; i < value; i++)
			{
				Debug.Log($"{maxInt.x} + {i} = {maxInt.x + i} \n {maxInt.y} + {i} = {maxInt.y + i}");
			}
			Debug.Log("MULTIPLICATION");
			for (int j = 0; j < value; j++)
			{
				Debug.Log($"{maxInt.x} * {j} = {maxInt.x * j} \n {maxInt.y} * {j} = {maxInt.y * j}");
			}
		}
	}
}

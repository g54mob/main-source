using UnityEngine;

namespace PG.UI
{
	public class BaseControls : MonoBehaviour
	{
		public CarControllerInput UserInput { get; set; }

		public virtual void Init(CarControllerInput userInput)
		{
		}
	}
}

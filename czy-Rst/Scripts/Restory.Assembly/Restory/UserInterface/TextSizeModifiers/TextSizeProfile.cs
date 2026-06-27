using UnityEngine;

namespace Restory.UserInterface.TextSizeModifiers
{
	[CreateAssetMenu(fileName = "TextSizeProfile", menuName = "Restory/UserInterface/TextSizeProfile")]
	public class TextSizeProfile : ScriptableObject
	{
		[SerializeField]
		private float percentage;

		public float Percentage => 1f + percentage * 0.01f;
	}
}

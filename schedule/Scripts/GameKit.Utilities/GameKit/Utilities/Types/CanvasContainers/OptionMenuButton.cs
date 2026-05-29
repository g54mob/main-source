using TMPro;
using UnityEngine;

namespace GameKit.Utilities.Types.CanvasContainers
{
	public class OptionMenuButton : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("Text component to show button text.")]
		private TextMeshProUGUI _text;

		public ButtonData ButtonData { get; protected set; }

		public virtual void Initialize(ButtonData buttonData)
		{
		}
	}
}

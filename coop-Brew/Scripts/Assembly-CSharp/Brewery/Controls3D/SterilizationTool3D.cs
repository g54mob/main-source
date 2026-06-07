using UnityEngine;

namespace Brewery.Controls3D
{
	public class SterilizationTool3D : MonoBehaviour
	{
		public enum ToolType
		{
			Brush = 0,
			Rinse = 1,
			Sanitize = 2,
			Dry = 3
		}

		[Header("Configuration")]
		[SerializeField]
		private ToolType toolType;

		[Tooltip("Sibling Draggable3D component. Auto-found if null.")]
		[SerializeField]
		private Draggable3D draggable;

		public ToolType Type => default(ToolType);

		public Draggable3D Draggable => null;

		private void Awake()
		{
		}
	}
}

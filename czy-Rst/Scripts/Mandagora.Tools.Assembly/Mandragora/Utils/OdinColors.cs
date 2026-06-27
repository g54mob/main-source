using UnityEngine;

namespace Mandragora.Utils
{
	public static class OdinColors
	{
		public const string GizmoColors = "Gizmo";

		public const string Red = "@OdinColors.RedColor";

		public const string Green = "@OdinColors.GreenColor";

		public const string Blue = "@OdinColors.BlueColor";

		public const string Cyan = "@Color.cyan";

		public const string Magenta = "@Color.magenta";

		public const string Yellow = "@Color.yellow";

		public const string LightBlue = "@OdinColors.LightBlueColor";

		public const string LightRed = "@OdinColors.LightRedColor";

		public static readonly Color RedColor = new Color(1f, 0.2f, 0.2f);

		public static readonly Color GreenColor = new Color(0.3f, 1f, 0.3f);

		public static readonly Color BlueColor = new Color(0.3f, 0.5f, 1f);

		public static readonly Color LightBlueColor = new Color(0.6f, 0.6f, 1f);

		public static readonly Color LightRedColor = new Color(1f, 0.5f, 0.5f);
	}
}

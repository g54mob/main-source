using System.Collections.Generic;
using UnityEngine;

namespace PajamaLlama.Debugs
{
	public class GizmoVisual : MonoBehaviour
	{
		public enum IconType
		{
			TextLabel = 0,
			RoundedRectangle = 1,
			SmallDot = 2,
			SmallDiamond = 3,
			BigDot = 4,
			BigDiamond = 5
		}

		public enum IconColor
		{
			LightGray = 0,
			Blue = 1,
			Cyan = 2,
			Green = 3,
			Yellow = 4,
			Orange = 5,
			Red = 6,
			Magenta = 7
		}

		[Header("Lines")]
		[SerializeField]
		[Tooltip("Scale to set linelengths to.")]
		private float _lineLengthScale = 1f;

		[SerializeField]
		[Tooltip("Color to use for outline.")]
		private Color _lineColor = Color.yellow;

		[SerializeField]
		[Tooltip("List of transforms to draw lines for.")]
		private List<Transform> _lineTransforms = new List<Transform>();

		private void OnDrawGizmos()
		{
			DrawOutline(_lineTransforms, _lineColor, _lineLengthScale);
		}

		public static void AddIcon(GameObject gameObject, IconType iconType, IconColor iconColor)
		{
		}

		private static GUIContent[] ReturnTextures(string baseName, string postFix, int count)
		{
			return new GUIContent[count];
		}

		private static GUIContent ReturnTexture(string baseName, string postFix, int iconId)
		{
			return null;
		}

		private static GUIContent ReturnEditorIcon(IconType iconType, IconColor iconColor)
		{
			string text = "";
			string postFix = string.Empty;
			int num = 0;
			switch (iconType)
			{
			default:
				text = "sv_label_";
				num = (int)iconColor;
				break;
			case IconType.RoundedRectangle:
				text = "sv_icon_name";
				postFix = "";
				num = (int)iconColor;
				break;
			case IconType.SmallDot:
				text = "sv_icon_dot";
				postFix = "_sml";
				num = (int)iconColor;
				break;
			case IconType.SmallDiamond:
				text = "sv_icon_dot";
				postFix = "_sml";
				num = (int)(iconColor + 8);
				break;
			case IconType.BigDot:
				text = "sv_icon_dot";
				postFix = "_pix16_gizmo";
				num = (int)iconColor;
				break;
			case IconType.BigDiamond:
				text = "sv_icon_dot";
				postFix = "_pix16_gizmo";
				num = (int)(iconColor + 8);
				break;
			}
			return ReturnTexture(text, postFix, num);
		}

		public static void DrawLine(Vector3 originPoint, Vector3 endPoint, Color color, float lengthScale = 1f)
		{
			Gizmos.color = color;
			Vector3 vector = endPoint - originPoint;
			Gizmos.DrawLine(originPoint, originPoint + vector * lengthScale);
		}

		public static void DrawOutline(List<Transform> outlineTransforms, Color color, float lengthScale = 1f)
		{
			for (int i = 0; i < outlineTransforms.Count; i++)
			{
				DrawLine(outlineTransforms[(i + 1) % outlineTransforms.Count].position, outlineTransforms[i].position, color, lengthScale);
			}
		}
	}
}

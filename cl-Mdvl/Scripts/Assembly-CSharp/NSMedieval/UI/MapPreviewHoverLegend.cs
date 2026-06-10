using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Map;
using NSMedieval.Model.MapNew;
using NSMedieval.UI.Utils;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class MapPreviewHoverLegend : MonoBehaviour, IPointerMoveHandler, IEventSystemHandler
	{
		[SerializeField]
		private Image image;

		[SerializeField]
		private TooltipViewNew tooltipViewNew;

		private RectTransform rectTransform;

		private string currentLine;

		private Texture2D Texture => image.sprite.texture;

		private void Awake()
		{
			rectTransform = image.rectTransform;
			currentLine = string.Empty;
		}

		public void OnPointerMove(PointerEventData eventData)
		{
			if (!Texture)
			{
				Log.Error("OnPointerMove: texture is null", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\MapPreviewHoverLegend.cs");
				return;
			}
			if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out var localPoint))
			{
				Log.Error("Could not process Screen to Local point", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\MapPreviewHoverLegend.cs");
				return;
			}
			Rect rect = rectTransform.rect;
			float num = Mathf.InverseLerp(rect.xMin, rect.xMax, localPoint.x);
			float num2 = Mathf.InverseLerp(rect.yMin, rect.yMax, localPoint.y);
			int num3 = Mathf.FloorToInt(num * (float)Texture.width);
			int num4 = Mathf.FloorToInt(num2 * (float)Texture.height);
			if (num3 < 0 || num3 >= Texture.width || num4 < 0 || num4 >= Texture.height)
			{
				return;
			}
			VoxelType voxelType = MonoSingleton<MapGenerationController>.Instance.MapGenerator.GetVoxelType(num4, num3);
			if (!(voxelType == null))
			{
				bool flag = MonoSingleton<MapGenerationController>.Instance.MapGenerator.IsWaterAt(num4, num3);
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(17, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\MapPreviewHoverLegend.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("VoxelType:");
					messageBuilder.AppendFormatted(voxelType.GetID());
					messageBuilder.AppendLiteral(" Water:");
					messageBuilder.AppendFormatted(flag);
				}
				Log.Trace(messageBuilder);
				string text = ("voxel_" + voxelType.GetID().ToLower()).ToLocalized();
				if (flag)
				{
					text = "resource_group_Water".ToLocalized() + "  (" + text + ")";
				}
				if (!text.Equals(currentLine))
				{
					currentLine = text;
					tooltipViewNew.ShowFreshLine(currentLine);
				}
			}
		}
	}
}

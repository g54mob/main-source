using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Map;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval.Tutorial
{
	public class TutorialViewManager : MonoSingleton<TutorialViewManager>
	{
		[SerializeField]
		private GameObject gridMarkerPrefab;

		[SerializeField]
		private GameObject gridMarkerOutlinePrefab;

		[SerializeField]
		private GameObject volumeMarkerPrefab;

		[SerializeField]
		private BeamPreviewView beamPreviewPrefab;

		[SerializeField]
		private GameObject ladderPreviewPrefab;

		[SerializeField]
		private GameObject merlonPreviewPrefab;

		[SerializeField]
		private TutorialHighlightSquare highlightSquare;

		private readonly List<Transform> gridMarkers = new List<Transform>();

		private readonly List<Transform> gridMarkersOutline = new List<Transform>();

		private readonly List<BeamPreviewView> beamMarkers = new List<BeamPreviewView>();

		private readonly List<Transform> ladderMarkers = new List<Transform>();

		private readonly List<Transform> merlonMarkers = new List<Transform>();

		private Transform volumeMarker;

		private void Start()
		{
			if (!TutorialManager.IsTutorialActive)
			{
				highlightSquare.gameObject.SetActive(value: false);
				return;
			}
			highlightSquare.gameObject.SetActive(value: true);
			HideHighlightRect();
			for (int i = 0; i < 3; i++)
			{
				gridMarkers.GetNext(gridMarkerPrefab, base.transform);
			}
			volumeMarker = Object.Instantiate(volumeMarkerPrefab, base.transform).transform;
			HideAllMarkers();
			HideHighlightRect();
		}

		public void ShowVolumeMarker(Vec3Int position)
		{
			volumeMarker.gameObject.SetActive(value: true);
			volumeMarker.position = new Vector3(position.x, position.y, position.z);
		}

		public void ShowMerlonMarker(Vec3Int position, Vector3 rotation)
		{
			Transform next = merlonMarkers.GetNext(merlonPreviewPrefab, base.transform);
			next.position = GridUtils.GetWorldPosition(position);
			Quaternion rotation2 = next.rotation;
			rotation2.eulerAngles = rotation;
			next.rotation = rotation2;
		}

		public void HideMerlonMarker(Vec3Int position)
		{
			foreach (Transform merlonMarker in merlonMarkers)
			{
				if (!(merlonMarker.position != GridUtils.GetWorldPosition(position)))
				{
					merlonMarker.gameObject.SetActive(value: false);
					break;
				}
			}
		}

		public void ShowLadderMarker(Vec3Int position)
		{
			ladderMarkers.GetNext(ladderPreviewPrefab, base.transform).position = GridUtils.GetWorldPosition(position);
		}

		public void HideLadderMarker(Vec3Int position)
		{
			foreach (Transform ladderMarker in ladderMarkers)
			{
				if (!(ladderMarker.position != GridUtils.GetWorldPosition(position)))
				{
					ladderMarker.gameObject.SetActive(value: false);
					break;
				}
			}
		}

		public void ShowBeamMarker(Vec3Int startWall, Vec3Int endWall)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(13, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\TutorialViewManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Show Beam ");
				messageBuilder.AppendFormatted(startWall);
				messageBuilder.AppendLiteral(" > ");
				messageBuilder.AppendFormatted(endWall);
			}
			Log.Debug(messageBuilder);
			BeamPreviewView next = beamMarkers.GetNext(beamPreviewPrefab.gameObject, base.transform);
			int num = 1;
			if (startWall.x == endWall.x)
			{
				num = BuildingPlacementManager.CalculateBeamScaleZ(startWall, endWall, next);
			}
			if (startWall.z == endWall.z)
			{
				num = BuildingPlacementManager.CalculateBeamScaleX(startWall, endWall, next);
			}
			FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(53, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\TutorialViewManager.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("Placing beam. rightOffset: ");
				messageBuilder2.AppendFormatted(new Vector3((float)num / 2f, 0f, 0f));
				messageBuilder2.AppendLiteral(", leftOffset: ");
				messageBuilder2.AppendFormatted(new Vector3((float)(-num) / 2f, 0f, 0f));
				messageBuilder2.AppendLiteral(", newScale: ");
				messageBuilder2.AppendFormatted(new Vector3(num, 1f, 1f));
			}
			Log.Trace(messageBuilder2);
			next.SetupPositionAndScale(new Vector3((float)num / 2f, 0f, 0f), new Vector3((float)(-num) / 2f, 0f, 0f), new Vector3(num, 1f, 1f));
		}

		public void HideBeamMarker(List<Vec3Int> buildingInstancePositions)
		{
			foreach (Vec3Int buildingInstancePosition in buildingInstancePositions)
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(14, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\TutorialViewManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("BuildableBase ");
					messageBuilder.AppendFormatted(buildingInstancePosition);
				}
				Log.Trace(messageBuilder);
				foreach (BeamPreviewView beamMarker in beamMarkers)
				{
					if (!(beamMarker.Transform.position != GridUtils.GetWorldPosition(buildingInstancePosition)))
					{
						FVLogDebugInterpolationHandler messageBuilder2 = new FVLogDebugInterpolationHandler(9, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\TutorialViewManager.cs");
						if (isEnabled)
						{
							messageBuilder2.AppendLiteral("Hiding ");
							messageBuilder2.AppendFormatted(beamMarker.Transform.position);
							messageBuilder2.AppendLiteral(" ");
							messageBuilder2.AppendFormatted(beamMarker.MovableSupportLeft.transform.position);
							messageBuilder2.AppendLiteral(" ");
							messageBuilder2.AppendFormatted(beamMarker.MovableSupportRight.transform.position);
						}
						Log.Debug(messageBuilder2);
						beamMarker.gameObject.SetActive(value: false);
					}
				}
			}
		}

		public void ShowOutlineMarker(Vec3Int position, bool hidePrevious = true)
		{
			ShowOutlineMarker(position, position, hidePrevious);
		}

		public void HideOutlineMarker(Vec3Int position)
		{
			foreach (Transform item in gridMarkersOutline)
			{
				if (CheckMarkerPositionMatch(position, item))
				{
					item.gameObject.SetActive(value: false);
					break;
				}
			}
		}

		private static bool CheckMarkerPositionMatch(Vec3Int position, Transform marker)
		{
			Vector3 worldPosition = GridUtils.GetWorldPosition(position);
			if (Mathf.Approximately(marker.position.x, worldPosition.x))
			{
				return Mathf.Approximately(marker.position.z, worldPosition.z);
			}
			return false;
		}

		public void ShowOutlineMarker(Vec3Int startPoint, Vec3Int endPoint, bool hidePrevious = true)
		{
			if (hidePrevious)
			{
				HideAllMarkers();
			}
			Transform next = gridMarkersOutline.GetNext(gridMarkerOutlinePrefab, base.transform);
			ProcessMarkerShow(startPoint, endPoint, next);
		}

		public void ShowOutlineMarker(Vec3Int[] startPoints, Vec3Int[] endPoints)
		{
			HideAllMarkers();
			for (int i = 0; i < startPoints.Length; i++)
			{
				Transform next = gridMarkersOutline.GetNext(gridMarkerOutlinePrefab, base.transform);
				ProcessMarkerShow(startPoints[i], endPoints[i], next);
			}
		}

		public void ShowMarker(Vec3Int position, bool hidePrevious = true)
		{
			ShowMarker(position, position, hidePrevious);
		}

		public void HideMarker(Vec3Int position)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(20, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\TutorialViewManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Hide Grid Marker at ");
				messageBuilder.AppendFormatted(position);
			}
			Log.Debug(messageBuilder);
			for (int num = gridMarkers.Count - 1; num >= 0; num--)
			{
				Vector3 worldPosition = GridUtils.GetWorldPosition(position);
				Vector3 position2 = gridMarkers[num].position;
				position2.y = Mathf.Floor(position2.y);
				if (!(position2 != worldPosition))
				{
					gridMarkers[num].gameObject.SetActive(value: false);
					FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(15, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\TutorialViewManager.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("Hiding ");
						messageBuilder2.AppendFormatted(gridMarkers[num].position);
						messageBuilder2.AppendLiteral(" | ");
						messageBuilder2.AppendFormatted(worldPosition);
						messageBuilder2.AppendLiteral(" == ");
						messageBuilder2.AppendFormatted(position2);
						messageBuilder2.AppendLiteral(" ");
						messageBuilder2.AppendFormatted(position2 == worldPosition);
					}
					Log.Trace(messageBuilder2);
				}
			}
		}

		public void ShowMarker(Vec3Int startPoint, Vec3Int endPoint, bool hidePrevious = true)
		{
			if (hidePrevious)
			{
				HideAllMarkers();
			}
			Transform next = gridMarkers.GetNext(gridMarkerPrefab, base.transform);
			ProcessMarkerShow(startPoint, endPoint, next);
		}

		public void ShowMarkers(Vec3Int[] startPoints, Vec3Int[] endPoints)
		{
			HideAllMarkers();
			for (int i = 0; i < startPoints.Length; i++)
			{
				Transform next = gridMarkers.GetNext(gridMarkerPrefab, base.transform);
				ProcessMarkerShow(startPoints[i], endPoints[i], next);
			}
		}

		private void ProcessMarkerShow(Vec3Int startPoint, Vec3Int endPoint, Transform marker)
		{
			marker.gameObject.SetActive(value: true);
			float num = 0.01f;
			Vector3 vector = new Vector3(Floor(Mathf.Min(startPoint.x, endPoint.x)) - num, Floor(Mathf.Min(startPoint.y, endPoint.y)) - num, Floor(Mathf.Min(startPoint.z, endPoint.z)) - num);
			Vector3 vector2 = new Vector3(Ceil(Mathf.Max(startPoint.x, endPoint.x)) + num, Ceil(Mathf.Max(startPoint.y, endPoint.y)), Ceil(Mathf.Max(startPoint.z, endPoint.z)) + num);
			marker.localPosition = (vector + vector2) / 2f - new Vector3(0.5f, (float)(World.MapBlockHeight / 2) - num - 0.5f, 0.5f);
			Vector3 localScale = vector2 - vector;
			localScale.y = Mathf.Max(1f, localScale.y);
			marker.localScale = localScale;
		}

		public void ShowHighlightRect(RectTransform target)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(22, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\TutorialViewManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Show HighlightRect at ");
				messageBuilder.AppendFormatted(target);
			}
			Log.Trace(messageBuilder);
			highlightSquare.Show(target);
		}

		public void HideHighlightRect()
		{
			Log.Trace("Hide HighlightRect", "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\TutorialViewManager.cs");
			highlightSquare.Hide();
		}

		public void HideAllMarkers()
		{
			gridMarkers.SetAllActive(active: false);
			gridMarkersOutline.SetAllActive(active: false);
			beamMarkers.SetAllActive(active: false);
			volumeMarker.gameObject.SetActive(value: false);
			ladderMarkers.SetAllActive(active: false);
			merlonMarkers.SetAllActive(active: false);
		}

		private float Floor(float val)
		{
			return val - val % 1f;
		}

		private float Ceil(float val)
		{
			return Floor(val) + 1f;
		}
	}
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Presentation.UI.WorldMap
{
	public class ExportLineVisuals : MonoBehaviour
	{
		[SerializeField]
		private GameObject _exportLine;

		[SerializeField]
		private Vector3 _lineOffset;

		[SerializeField]
		private InputActionReference RightClickInputAction;

		private List<ExportLine> _lines = new List<ExportLine>();

		private int _currentLineIndex = -1;

		private bool _isPlacingLine;

		public bool IsPlacingLine => _isPlacingLine;

		private void Update()
		{
			if (!_isPlacingLine)
			{
				return;
			}
			RaycastHit hitInfo;
			if (RightClickInputAction.action.IsPressed())
			{
				_lines[_currentLineIndex].ExportButton.IsExporting = false;
				RemoveLine(_currentLineIndex);
				_isPlacingLine = false;
			}
			else if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, float.MaxValue))
			{
				Vector3 point = hitInfo.point;
				if ((bool)_lines[_currentLineIndex].DrawLineRenderer)
				{
					_lines[_currentLineIndex].DrawLineRenderer.SetEndPointPosition(point);
				}
			}
		}

		public void CreateLine(Transform startPoint, ResourceExportButton exportButton, string fromCityString)
		{
			if (!_isPlacingLine)
			{
				GameObject gameObject = Object.Instantiate(_exportLine);
				gameObject.transform.position += _lineOffset;
				ExportLine exportLine = new ExportLine
				{
					DrawLineRenderer = gameObject.GetComponent<ArcRenderer>(),
					ExportButton = exportButton,
					FromCityGuid = fromCityString
				};
				exportLine.DrawLineRenderer.SetStartPoint(startPoint);
				exportLine.DrawLineRenderer.CreateIcon(exportButton.ResourceType);
				_lines.Add(exportLine);
				_currentLineIndex = _lines.Count - 1;
				_isPlacingLine = true;
			}
		}

		public ExportLine GetCurrentLine()
		{
			return _lines[_currentLineIndex];
		}

		public ExportLine GetLine(ResourceExportButton button)
		{
			foreach (ExportLine line in _lines)
			{
				if (button == line.ExportButton)
				{
					return line;
				}
			}
			return null;
		}

		public void PlaceLineEndpoint(Transform endPoint, string toCityString)
		{
			_lines[_currentLineIndex].ToCityGuid = toCityString;
			int num = -1;
			for (int i = 0; i < _lines.Count; i++)
			{
				if (i != _currentLineIndex && _lines[i].FromCityGuid == _lines[_currentLineIndex].FromCityGuid && _lines[i].ToCityGuid == _lines[_currentLineIndex].ToCityGuid)
				{
					num = i;
				}
			}
			if (num == -1)
			{
				_lines[_currentLineIndex].DrawLineRenderer.SetEndPoint(endPoint);
			}
			else
			{
				Object.Destroy(_lines[_currentLineIndex].DrawLineRenderer.gameObject);
				_lines[num].DrawLineRenderer.CreateIcon(_lines[_currentLineIndex].ExportButton.ResourceType);
				_lines[_currentLineIndex].DrawLineRenderer = _lines[num].DrawLineRenderer;
			}
			_isPlacingLine = false;
		}

		public void RemoveLine(ResourceExportButton button)
		{
			for (int i = 0; i < _lines.Count; i++)
			{
				if (_lines[i].ExportButton == button)
				{
					RemoveLine(i);
				}
			}
		}

		private void RemoveLine(int idx)
		{
			for (int i = 0; i < _lines.Count; i++)
			{
				if (i != idx && _lines[i].DrawLineRenderer == _lines[idx].DrawLineRenderer)
				{
					_lines[i].DrawLineRenderer.RemoveIcon(_lines[idx].ExportButton.ResourceType);
					_lines.RemoveAt(idx);
					_currentLineIndex--;
					return;
				}
			}
			Object.Destroy(_lines[idx].DrawLineRenderer.gameObject);
			_lines.RemoveAt(idx);
			_currentLineIndex--;
		}

		public void AnimateLine(ResourceExportButton button)
		{
			foreach (ExportLine line in _lines)
			{
				if (line.ExportButton == button)
				{
					line.DrawLineRenderer.StartAnimation();
					break;
				}
			}
		}

		public void StopAnimationLine(ResourceExportButton button)
		{
			foreach (ExportLine line in _lines)
			{
				if (line.ExportButton == button)
				{
					line.DrawLineRenderer.StopAnimation();
					break;
				}
			}
		}
	}
}

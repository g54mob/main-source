using System.Collections.Generic;
using System.Linq;
using Client;
using Factory.Pools;
using UnityEngine;

namespace Motorways.Views
{
	public class HotkeyDebugView : MonoBehaviour, IView, IReusable
	{
		private GUIStyle _messageStyle = new GUIStyle();

		private GUIStyle _tableRowStyle = new GUIStyle();

		private static readonly Vector2 BaseResolution = new Vector2(1920f, 1080f);

		private Vector2Int _screenSize;

		private Matrix4x4 _hotkeyViewTransformationMatrix;

		private const float MessageFadeSpeed = 0.15f;

		private string _currentMessage = "";

		private float _currentMessageAlpha;

		private List<List<string>> _nextTabulatedMessageColumnsToDisplay;

		public bool IsShowingHotkeyDescriptions => _nextTabulatedMessageColumnsToDisplay != null;

		private void OnEnable()
		{
			_messageStyle.fontSize = 50;
			_messageStyle.alignment = TextAnchor.MiddleLeft;
			_messageStyle.richText = true;
			_messageStyle.normal.textColor = Color.magenta;
			_tableRowStyle.fontSize = 30;
			_tableRowStyle.normal.textColor = Color.gray;
			_tableRowStyle.alignment = TextAnchor.MiddleLeft;
			_tableRowStyle.padding = new RectOffset(5, 5, 5, 5);
		}

		public void ShowMessage(string message)
		{
			_currentMessage = message;
			_currentMessageAlpha = 1f;
		}

		public void ShowHotkeyDescriptions(List<HotkeyDescription> hotkeyDescriptions)
		{
			List<List<string>> list = new List<List<string>>
			{
				new List<string>(),
				new List<string>()
			};
			foreach (HotkeyDescription hotkeyDescription in hotkeyDescriptions)
			{
				list[0].Add(hotkeyDescription.description);
				list[1].Add(hotkeyDescription.KeyCodeDisplayName);
			}
			_nextTabulatedMessageColumnsToDisplay = list;
		}

		public void HideHotkeyDescriptions()
		{
			_nextTabulatedMessageColumnsToDisplay = null;
		}

		private void ShowTabulatedMessage(int startRow, int endRow, int horizontalOffsetIndex)
		{
			List<Vector2> list = new List<Vector2>();
			float num = 0f;
			for (int i = 0; i < _nextTabulatedMessageColumnsToDisplay.Count; i++)
			{
				list.Add(Vector2.zero);
				for (int j = startRow; j < endRow; j++)
				{
					GUIContent content = new GUIContent(_nextTabulatedMessageColumnsToDisplay[i][j]);
					Vector2 vector = _tableRowStyle.CalcSize(content);
					Vector2 value = list[i];
					if (vector.x > value.x)
					{
						value.x = vector.x;
					}
					if (vector.y > value.y)
					{
						value.y = vector.y;
					}
					list[i] = value;
					if (i == 0)
					{
						num += vector.y;
					}
				}
			}
			float num2 = list.Select((Vector2 bounds) => bounds.x).Sum();
			Rect position = new Rect(0.5f * (BaseResolution.x - num2) + (float)horizontalOffsetIndex * num2 * 0.5f, 0.5f * (BaseResolution.y - num), num2, num);
			GUI.Box(position, "");
			float num3 = 0f;
			for (int num4 = 0; num4 < _nextTabulatedMessageColumnsToDisplay.Count; num4++)
			{
				for (int num5 = startRow; num5 < endRow; num5++)
				{
					string text = _nextTabulatedMessageColumnsToDisplay[num4][num5];
					GUIContent content2 = new GUIContent(text);
					Vector2 vector2 = _tableRowStyle.CalcSize(content2);
					_tableRowStyle.normal.textColor = ((num4 == 0) ? Color.green : Color.white);
					GUI.Label(new Rect(position.x + num3, position.y + (float)(num5 - startRow) * vector2.y, list[num4].x, vector2.y), text, _tableRowStyle);
				}
				num3 += list[num4].x;
			}
		}

		public void Reset()
		{
			_messageStyle = new GUIStyle();
			_tableRowStyle = new GUIStyle();
			_currentMessage = "";
			_nextTabulatedMessageColumnsToDisplay = null;
			_currentMessageAlpha = 0f;
			_hotkeyViewTransformationMatrix = default(Matrix4x4);
		}

		public TickResult Tick(TimeInterval tickTime, float stepAlpha)
		{
			return TickResult.StopTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}
	}
}

using System;
using System.Collections.Generic;
using Data.FactoryFloor.GameMode;
using Events.UI.Arrows;
using Logic.Factory;
using NaughtyAttributes;
using Shapes;
using UnityEngine;

namespace Presentation.UI.Arrows
{
	public class ArrowSystem : MonoBehaviour
	{
		[SerializeField]
		private DrawArrowEvent _drawArrowEvent;

		[SerializeField]
		private DeleteArrowEvent _deleteArrowEvent;

		[SerializeField]
		private CurrentGameMode _currentGameMode;

		[SerializeField]
		private GameModeSO _editorGameMode;

		[SerializeField]
		private Polyline polylinePrefab;

		private Dictionary<ArrowData, Polyline> _spawnedArrows = new Dictionary<ArrowData, Polyline>();

		private bool _showArrows;

		private void Awake()
		{
			_drawArrowEvent.Register(HandleArrowDrawEvent);
			_deleteArrowEvent.Register(HandleArrowDeleteEvent);
			_currentGameMode.CurrentGameModeChanged += HandleGameModeChanged;
		}

		private void OnDestroy()
		{
			_drawArrowEvent.UnRegister(HandleArrowDrawEvent);
			_deleteArrowEvent.UnRegister(HandleArrowDeleteEvent);
			_currentGameMode.CurrentGameModeChanged -= HandleGameModeChanged;
		}

		private void HandleGameModeChanged(GameModeSO newGameMode)
		{
			_showArrows = newGameMode == _editorGameMode;
			foreach (KeyValuePair<ArrowData, Polyline> spawnedArrow in _spawnedArrows)
			{
				spawnedArrow.Value.gameObject.SetActive(_showArrows);
			}
		}

		private void HandleArrowDeleteEvent(ArrowData data)
		{
			if (_spawnedArrows.TryGetValue(data, out var value))
			{
				if (value != null && value.gameObject != null)
				{
					UnityEngine.Object.Destroy(value.gameObject);
				}
				_spawnedArrows.Remove(data);
			}
		}

		private void HandleArrowDrawEvent(ArrowData data)
		{
			if (!_spawnedArrows.ContainsKey(data))
			{
				Polyline polyline = UnityEngine.Object.Instantiate(polylinePrefab, base.transform);
				SetPoints(data, polyline);
				polyline.Color = Color.black;
				_spawnedArrows.Add(data, polyline);
				polyline.gameObject.SetActive(_showArrows);
			}
		}

		public static void SetPoints(ArrowData data, Polyline spawnedArrow)
		{
			int num = 36;
			List<Vector3> list = new List<Vector3>();
			for (int i = 0; i <= num; i++)
			{
				Vector3 item = Vector3.Lerp(data.Origin, data.End, (float)i / (float)num);
				item += new Vector3(0f, Mathf.Lerp(0f, data.Height, Mathf.Sin((float)i / (float)num * MathF.PI)), 0f);
				list.Add(item);
			}
			spawnedArrow.SetPoints(list);
			for (int j = 0; j <= num; j++)
			{
				float thickness = 0.2f;
				if ((float)j / (float)num >= 0.85f)
				{
					thickness = Mathf.Lerp(20f, 0f, (float)j / (float)num);
				}
				spawnedArrow.SetPointThickness(j, thickness);
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		public void TestArrow()
		{
			HandleArrowDrawEvent(new ArrowData(new Vector3Int(0, 0, 10), new Vector3Int(15, 0, 15), 5f));
		}

		[Button(null, EButtonEnableMode.Always)]
		public void TestDeleteArrow()
		{
			HandleArrowDeleteEvent(new ArrowData(new Vector3Int(0, 0, 10), new Vector3Int(15, 0, 15), 5f));
		}
	}
}

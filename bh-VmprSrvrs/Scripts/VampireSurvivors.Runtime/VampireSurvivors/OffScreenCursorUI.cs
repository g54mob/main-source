using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Signals;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors
{
	public class OffScreenCursorUI : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDoLateUpdate_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public OffScreenCursorUI _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CDoLateUpdate_003Ed__15(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[FormerlySerializedAs("_cursorPrefab")]
		[SerializeField]
		private GameObject _CursorPrefab;

		[FormerlySerializedAs("_canvasRect")]
		[SerializeField]
		private RectTransform _CanvasRect;

		[SerializeField]
		private float _ScreenBoundsOffset;

		private readonly Dictionary<GameObject, OffScreenCursor> _spawnedCursors;

		private SignalBus _signalBus;

		private GameManager _gameManager;

		private DataManager _data;

		private PlayerOptions _playerOptions;

		private Camera _cam;

		private Vector3 _screenCenter;

		private Vector3 _screenBounds;

		[Inject]
		private void Construct(SignalBus signal, GameManager gameManager, DataManager data, PlayerOptions player)
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		public static void GetArrowIndicatorPositionAndAngle(ref Vector3 screenPosition, ref float angle, Vector3 screenCentre, Vector3 screenBounds)
		{
		}

		[IteratorStateMachine(typeof(_003CDoLateUpdate_003Ed__15))]
		private IEnumerator DoLateUpdate()
		{
			return null;
		}

		private bool CheckIfInScreenBounds(Vector2 pos)
		{
			return false;
		}

		private void SpawnCursor(UISignals.SpawnOffScreenCursorSignal sig)
		{
		}

		private void RemoveCursor(UISignals.RemoveOffScreenCursorSignal sig)
		{
		}

		private void PositionNearScreenEdge(OffScreenCursor offScreenCursor, Vector3 screenPos)
		{
		}

		private void PointAtTarget(OffScreenCursor offScreenCursor, Vector3 screenPos)
		{
		}
	}
}

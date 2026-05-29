using System;
using System.Collections;
using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Pooling;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS
{
	public class AreaOfEffectPower : SimpleAction
	{
		[SerializeField]
		private AreaOfEffectPowerData _powerData;

		private AreaOfEffectCursor _cursor;

		private readonly Collider[] _physicsAlloc = new Collider[15];

		private readonly List<Collider> _hitColliders = new List<Collider>();

		public event Action PowerCast;

		public void Setup(AreaOfEffectPowerData data)
		{
			_powerData = data;
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			if ((bool)_powerData.SelectionMode)
			{
				CTSSingleton<SelectionModeList>.Instance.AddMode(_powerData.SelectionMode);
			}
			InputManager.game.select.onComplete += OnInputSelect;
		}

		private void OnInputSelect(InputAction.CallbackContext ctx)
		{
			if (WorldSelector.MousePositionWorldSpace.HasValue)
			{
				PullCursor();
				_cursor.transform.position = WorldSelector.MousePositionWorldSpace.Value;
				if ((bool)_powerData.EffectPrefab)
				{
					VFXTimer vFXTimer = Pooler.Pull(_powerData.EffectPrefab);
					vFXTimer.transform.position = _cursor.transform.position;
					vFXTimer.gameObject.SetActive(value: true);
				}
				this.PowerCast?.Invoke();
				if (_powerData.PhysicsScanDelay > 0f)
				{
					_cursor.gameObject.scene.StartCoroutine(DelayedCast(_powerData, _cursor, _physicsAlloc, _hitColliders));
					_cursor = null;
				}
				else
				{
					CastPower(_powerData, _cursor, _physicsAlloc, _hitColliders);
				}
				EndAction();
			}
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			PushCursor();
			InputManager.game.select.onComplete -= OnInputSelect;
			if (CTSSingleton<WorldSelector>.InstanceExists())
			{
				CTSSingleton<SelectionModeList>.Instance.RemoveMode(_powerData.SelectionMode);
			}
		}

		private void PushCursor()
		{
			if (!(_cursor == null))
			{
				Pooler.Push(_cursor);
				_cursor = null;
			}
		}

		private void PullCursor()
		{
			if (!(_cursor != null))
			{
				_cursor = Pooler.Pull(_powerData.CursorPrefab, active: true);
			}
		}

		private void Update()
		{
			if (!WorldSelector.MousePositionWorldSpace.HasValue)
			{
				PushCursor();
				return;
			}
			PullCursor();
			_cursor.transform.position = WorldSelector.MousePositionWorldSpace.Value;
		}

		private static void CastPower(AreaOfEffectPowerData powerData, AreaOfEffectCursor cursor, Collider[] physicsAlloc, List<Collider> hitColliders)
		{
			int num = cursor.OverlapNonAlloc(physicsAlloc, powerData.SphereCastLayerMask, QueryTriggerInteraction.Ignore);
			hitColliders.Clear();
			for (int i = 0; i < num; i++)
			{
				hitColliders.Add(physicsAlloc[i]);
			}
			powerData.CastPower(hitColliders);
		}

		private static IEnumerator DelayedCast(AreaOfEffectPowerData powerData, AreaOfEffectCursor cursor, Collider[] physicsAlloc, List<Collider> hitColliders)
		{
			yield return Coroutines.WaitForSeconds(powerData.PhysicsScanDelay);
			CastPower(powerData, cursor, physicsAlloc, hitColliders);
			Pooler.Push(cursor);
		}
	}
}

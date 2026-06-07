using System;
using System.Collections.Generic;
using Simulator;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class UI_PaintingGame : UI_BasePaintMiniGame
	{
		public struct Try
		{
			public readonly bool success;

			public readonly int circlesPassed;

			public readonly int consecutiveSuccess;

			public Try(bool success, int circlesPassed)
			{
				this.success = success;
				this.circlesPassed = circlesPassed;
				consecutiveSuccess = 0;
			}

			public Try(bool success, int circlesPassed, Try previous)
			{
				this.success = success;
				this.circlesPassed = circlesPassed;
				consecutiveSuccess = (previous.success ? (previous.consecutiveSuccess + 1) : 0);
			}
		}

		[Header("Positions")]
		[SerializeField]
		private RectTransform m_circlesContainer;

		[SerializeField]
		private List<RectTransform> m_possibleAnchors;

		[Header("Prefabs")]
		[SerializeField]
		private GameObject m_circlePrefab;

		private List<UI_PaintingGameCircle> m_circleInstances = new List<UI_PaintingGameCircle>();

		private List<RectTransform> m_availableAnchors;

		private float m_duration;

		private Vector2 m_range;

		private List<Try> m_tries = new List<Try>();

		private int m_consecutiveFail;

		public int CurrentScore { get; private set; }

		private void PrepareFirstAction()
		{
			m_availableAnchors = new List<RectTransform>(m_possibleAnchors);
			m_duration = PaintingSettings.DiskShrinkStartDuration;
			m_range = PaintingSettings.DiskStartSize;
			TransientManager<InputManager>.Instance.UIInputModule.submit.action.Disable();
			LaunchAction(m_duration * DiskDurationMultiplier(), m_range);
		}

		private void PrepareNewAction()
		{
			List<Try> tries = m_tries;
			float num = (tries[tries.Count - 1].success ? PaintingSettings.DiskNormalAcceleration : PaintingSettings.DiskFailAcceleration);
			m_duration *= 1f / (1f + num);
			m_duration *= DiskDurationMultiplier();
			float num2 = (m_range.y - m_range.x) * (1f - PaintingSettings.DiskSizeReducing);
			m_range = new Vector2(m_range.x, m_range.x + num2);
			LaunchAction(m_duration, m_range);
		}

		private void LaunchAction(float duration, Vector2 range)
		{
			int index = UnityEngine.Random.Range(0, m_availableAnchors.Count);
			RectTransform anchor = m_availableAnchors[index];
			m_availableAnchors.RemoveAt(index);
			UI_PaintingGameCircle component = UnityEngine.Object.Instantiate(m_circlePrefab, m_circlesContainer).GetComponent<UI_PaintingGameCircle>();
			component.Init(anchor, duration, range, OnAction);
			m_circleInstances.Add(component);
		}

		private float DiskDurationMultiplier()
		{
			if (TransientManager<InputManager>.Instance.CurrentDevice != EInputDeviceType.GAMEPAD)
			{
				return 1f;
			}
			return PaintingSettings.DiskDurationGamepadMultiplicator;
		}

		protected override int ComputeScore()
		{
			return CurrentScore;
		}

		private void AddTry(bool success, int circlesPassed)
		{
			if (m_tries.Count > 0)
			{
				List<Try> tries = m_tries;
				List<Try> tries2 = m_tries;
				tries.Add(new Try(success, circlesPassed, tries2[tries2.Count - 1]));
			}
			else
			{
				m_tries.Add(new Try(success, circlesPassed));
			}
			Action<bool, int> onTry = UI_BasePaintMiniGame.OnTry;
			if (onTry != null)
			{
				List<Try> tries3 = m_tries;
				onTry(success, PaintingSettings.ComputePaintingGameScore(tries3[tries3.Count - 1]));
			}
		}

		protected override void OnSetActive()
		{
			base.OnSetActive();
			m_tries.Clear();
			CurrentScore = 0;
			m_consecutiveFail = 0;
			PrepareFirstAction();
		}

		protected override void OnSetInactive()
		{
			base.OnSetInactive();
			foreach (UI_PaintingGameCircle circleInstance in m_circleInstances)
			{
				if (circleInstance != null)
				{
					circleInstance.Kill();
				}
			}
			m_tries.Clear();
		}

		private void OnAction(bool success, int circlesPassed)
		{
			AddTry(success, circlesPassed);
			if (success)
			{
				m_consecutiveFail = 0;
			}
			else
			{
				m_consecutiveFail++;
				if (m_consecutiveFail == PaintingSettings.PaintingGameMaxConsecutiveFail)
				{
					Complete();
					return;
				}
			}
			if (m_tries.Count == PaintingSettings.PaintingGameActionsCount)
			{
				Complete();
			}
			else
			{
				PrepareNewAction();
			}
		}
	}
}

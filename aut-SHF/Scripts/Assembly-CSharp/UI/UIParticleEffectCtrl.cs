using System;
using System.Collections.Generic;
using Libs;
using UnityEngine;

namespace UI
{
	public class UIParticleEffectCtrl : SingletonMonoBehaviour<UIParticleEffectCtrl>
	{
		[Serializable]
		public class UIParticleEffectInfo
		{
			public eParticleType type;

			public GameObject effectObj;
		}

		public enum eParticleType
		{
			Default = 0
		}

		public enum eParticleEffectMoveType
		{
			Default = 0,
			RightTurn = 1,
			LeftTurn = 2
		}

		public struct EffectInfo
		{
			public eParticleType type;

			public eParticleEffectMoveType moveType;

			public Vector2 from;

			public Vector2 to;

			public float delay;

			public float duration;

			public float param;

			public float finishDelay;

			public float fullAnimationTime => 0f;
		}

		public class IsoscelesTriangle
		{
			public static Vector2[] FindThirdPoint(Vector2 a, Vector2 b, float height)
			{
				return null;
			}
		}

		private class PlayEffectData
		{
			public EffectInfo info;

			public RectTransform effectRect;

			public float time;

			private bool isStarted;

			public bool isPlaying => false;

			public void Progress(float deltaTime)
			{
			}
		}

		public Canvas canvas;

		[Header("Settings")]
		[SerializeField]
		private float defaultDuration;

		[SerializeField]
		private float finishDelay;

		[Header("Effects")]
		[SerializeField]
		private List<UIParticleEffectInfo> effects;

		private List<EffectInfo> effectInfos;

		private List<PlayEffectData> playEffects;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void PlayAllEffect()
		{
		}

		private GameObject GetEffectObj(eParticleType type)
		{
			return null;
		}

		public void SetCursor(GameObject targetObj)
		{
		}

		public static Vector2 GetTargetScreenPosition(GameObject targetObj)
		{
			return default(Vector2);
		}

		public static Vector2 GetTargetScreenPositionFromWorld(Camera worldCamera, GameObject targetObj)
		{
			return default(Vector2);
		}

		public void PlayEffectOnce(eParticleType type = eParticleType.Default, eParticleEffectMoveType moveType = eParticleEffectMoveType.Default, Vector2 from = default(Vector2), Vector2 to = default(Vector2), float delay = 0f, float duration = 0f, float param = 1f, float finishDelay = 0f)
		{
		}

		public void PlayEffectOnce(EffectInfo info)
		{
		}

		public void SetEffect(eParticleType type = eParticleType.Default, eParticleEffectMoveType moveType = eParticleEffectMoveType.Default, Vector2 from = default(Vector2), Vector2 to = default(Vector2), float delay = 0f, float duration = 0f, float param = 1f, float finishDelay = 0f)
		{
		}

		public void SetEffect(EffectInfo info)
		{
		}

		public void ClearReservationEffects()
		{
		}

		public void StopEffects()
		{
		}
	}
}

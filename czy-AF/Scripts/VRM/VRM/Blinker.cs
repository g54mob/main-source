using System.Collections;
using UnityEngine;

namespace VRM
{
	public class Blinker : MonoBehaviour
	{
		[SerializeField]
		public VRMBlendShapeProxy BlendShapes;

		[SerializeField]
		private float m_interVal = 5f;

		[SerializeField]
		private float m_closingTime = 0.06f;

		[SerializeField]
		private float m_openingSeconds = 0.03f;

		[SerializeField]
		private float m_closeSeconds = 0.1f;

		protected Coroutine m_coroutine;

		private float m_nextRequest;

		private bool m_request;

		public bool Request
		{
			get
			{
				return m_request;
			}
			set
			{
				if (!(Time.time < m_nextRequest))
				{
					m_request = value;
					m_nextRequest = Time.time + 1f;
				}
			}
		}

		private void Reset()
		{
			BlendShapes = GetComponent<VRMBlendShapeProxy>();
		}

		protected IEnumerator BlinkRoutine()
		{
			while (true)
			{
				float waitTime = Time.time + Random.value * m_interVal;
				while (waitTime > Time.time)
				{
					if (Request)
					{
						m_request = false;
						break;
					}
					yield return null;
				}
				float value = 0f;
				float closeSpeed = 1f / m_closeSeconds;
				while (true)
				{
					value += Time.deltaTime * closeSpeed;
					if (value >= 1f)
					{
						break;
					}
					BlendShapes.ImmediatelySetValue(BlendShapeKey.CreateFromPreset(BlendShapePreset.Blink), value);
					yield return null;
				}
				BlendShapes.ImmediatelySetValue(BlendShapeKey.CreateFromPreset(BlendShapePreset.Blink), 1f);
				yield return new WaitForSeconds(m_closingTime);
				value = 1f;
				float openSpeed = 1f / m_openingSeconds;
				while (true)
				{
					value -= Time.deltaTime * openSpeed;
					if (value < 0f)
					{
						break;
					}
					BlendShapes.ImmediatelySetValue(BlendShapeKey.CreateFromPreset(BlendShapePreset.Blink), value);
					yield return null;
				}
				BlendShapes.ImmediatelySetValue(BlendShapeKey.CreateFromPreset(BlendShapePreset.Blink), 0f);
			}
		}

		private void Awake()
		{
			if (BlendShapes == null)
			{
				BlendShapes = GetComponent<VRMBlendShapeProxy>();
			}
		}

		private void OnEnable()
		{
			m_coroutine = StartCoroutine(BlinkRoutine());
		}

		private void OnDisable()
		{
			if (m_coroutine != null)
			{
				StopCoroutine(m_coroutine);
				m_coroutine = null;
			}
		}
	}
}

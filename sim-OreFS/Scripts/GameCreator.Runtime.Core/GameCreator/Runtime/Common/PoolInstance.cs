using System;
using System.Collections;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[AddComponentMenu("")]
	internal class PoolInstance : MonoBehaviour
	{
		[NonSerialized]
		private int m_PrefabId;

		[NonSerialized]
		private IEnumerator m_Coroutine;

		private void OnDisable()
		{
			CancelInvoke();
			if (!ApplicationManager.IsExiting)
			{
				Singleton<PoolManager>.Instance.OnDisableInstance(m_PrefabId, this);
				if (m_Coroutine != null)
				{
					StopCoroutine(m_Coroutine);
				}
			}
		}

		private void OnDestroy()
		{
			if (!ApplicationManager.IsExiting)
			{
				Singleton<PoolManager>.Instance.OnDestroyInstance(m_PrefabId, this);
			}
		}

		public void OnCreate(int prefabId)
		{
			m_PrefabId = prefabId;
		}

		public void SetDuration(float duration)
		{
			m_Coroutine = TimeoutDisable(duration);
			StartCoroutine(m_Coroutine);
		}

		private IEnumerator TimeoutDisable(float duration)
		{
			yield return new WaitForSeconds(duration);
			base.gameObject.SetActive(value: false);
		}
	}
}

using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public class RunnerPool
	{
		private const HideFlags INSTANCE_FLAGS = HideFlags.None;

		[NonSerialized]
		private readonly GameObject m_Template;

		[NonSerialized]
		private readonly List<GameObject> m_ReadyList;

		[NonSerialized]
		private readonly HashSet<GameObject> m_RunningList;

		public RunnerPool(GameObject template, int prewarmCounter)
		{
			m_Template = template;
			m_Template.SetActive(value: false);
			m_ReadyList = new List<GameObject>(prewarmCounter);
			m_RunningList = new HashSet<GameObject>(prewarmCounter);
			for (int i = 0; i < prewarmCounter; i++)
			{
				GameObject item = CreateInstance();
				m_ReadyList.Add(item);
			}
		}

		public TRunnerType Pick<TRunnerType>() where TRunnerType : Runner
		{
			GameObject gameObject = null;
			for (int num = m_ReadyList.Count - 1; num >= 0; num--)
			{
				gameObject = m_ReadyList[num];
				m_ReadyList.RemoveAt(num);
				if (gameObject != null)
				{
					m_RunningList.Add(gameObject);
					break;
				}
			}
			if (gameObject == null)
			{
				gameObject = CreateInstance();
				m_RunningList.Add(gameObject);
			}
			if (!(gameObject != null))
			{
				return null;
			}
			return gameObject.Get<TRunnerType>();
		}

		public void Restore(GameObject instance)
		{
			if (!(instance == null) && m_RunningList.Remove(instance))
			{
				instance.transform.SetParent(m_Template.transform.parent);
				instance.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
				instance.SetActive(value: false);
				m_ReadyList.Add(instance);
			}
		}

		private GameObject CreateInstance()
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(m_Template, Vector3.zero, Quaternion.identity, m_Template.transform.parent);
			gameObject.name = m_Template.name + " (Runner)";
			gameObject.Get<Runner>().Template = m_Template;
			gameObject.hideFlags = HideFlags.None;
			gameObject.SetActive(value: false);
			return gameObject;
		}
	}
}

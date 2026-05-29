using System;
using System.Collections.Generic;
using System.Linq;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[DefaultExecutionOrder(-1)]
	public class ObjectSwapOnPercent : MonoBehaviour, ISwap
	{
		private enum EMode
		{
			Single = 0,
			Additive = 1
		}

		[SerializeField]
		private SerializableDictionary<float, UnityEngine.Object> _content = new SerializableDictionary<float, UnityEngine.Object>();

		[SerializeField]
		[Range(0f, 1f)]
		private float _startPercent;

		[SerializeField]
		private EMode _mode;

		private float _currentPercent;

		public float GetCurrentPercent()
		{
			return _currentPercent;
		}

		public float GetStartPercent()
		{
			return _startPercent;
		}

		private void Awake()
		{
			SwapByPercent(_startPercent);
		}

		public void SwapByPercent(float percent)
		{
			if (_content.Count > 0)
			{
				percent = Math.Clamp(percent, 0f, 1f);
				_currentPercent = percent;
				switch (_mode)
				{
				case EMode.Single:
					SetSingleMeshBaseOnPercent(percent);
					break;
				case EMode.Additive:
					SetAdditiveMeshBaseOnPercent(percent);
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
		}

		private void SetSingleMeshBaseOnPercent(float percent)
		{
			foreach (var (num2, p_object) in _content.Reverse())
			{
				if (!(percent < num2))
				{
					SingleEnable(p_object);
					return;
				}
			}
			SingleEnable(null);
		}

		private void SetAdditiveMeshBaseOnPercent(float percent)
		{
			foreach (var (num2, obj2) in _content)
			{
				if (obj2 is GameObject gameObject)
				{
					gameObject.SetActive(percent >= num2);
				}
				else if (obj2 is MonoBehaviour monoBehaviour)
				{
					monoBehaviour.enabled = percent >= num2;
				}
			}
		}

		private void SingleEnable(UnityEngine.Object p_object)
		{
			foreach (UnityEngine.Object value in _content.Values)
			{
				if (!value)
				{
					continue;
				}
				if (value is GameObject gameObject)
				{
					if (gameObject == p_object)
					{
						gameObject.SetActive(value: true);
					}
					else if (gameObject.activeSelf)
					{
						gameObject.SetActive(value: false);
					}
				}
				else if (value is MonoBehaviour monoBehaviour)
				{
					if (monoBehaviour == p_object)
					{
						monoBehaviour.enabled = true;
					}
					else if (monoBehaviour.enabled)
					{
						monoBehaviour.enabled = false;
					}
				}
			}
		}

		private void OnValidate()
		{
			if (Application.isPlaying)
			{
				SwapByPercent(_startPercent);
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		private void AutoUpdateMeshes()
		{
			_content.Clear();
			List<GameObject> list = new List<GameObject>();
			for (int i = 0; i < base.transform.childCount; i++)
			{
				GameObject item = base.transform.GetChild(i).gameObject;
				list.Add(item);
			}
			if (list.Count >= 1)
			{
				_content.Add(0f, list[0]);
				float num = 1f / (float)(list.Count - 1);
				for (int j = 1; j < list.Count; j++)
				{
					float key = (float)j * num;
					_content.Add(key, list[j].gameObject);
				}
			}
		}
	}
}

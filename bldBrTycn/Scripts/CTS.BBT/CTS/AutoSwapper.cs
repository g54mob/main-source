using System;
using System.Collections.Generic;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class AutoSwapper : MonoBehaviour, ISwap
	{
		private enum EMode
		{
			Single = 0,
			Additive = 1
		}

		[SerializeField]
		private List<UnityEngine.Object> _content = new List<UnityEngine.Object>();

		[SerializeField]
		[Range(0f, 1f)]
		private float _startPercent;

		[SerializeField]
		private EMode _mode;

		private float _currentPercent;

		[SerializeField]
		private SerializableType _autoGet;

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
			for (int num = _content.Count - 1; num >= 0; num--)
			{
				float num2 = (float)(num + 1) / (float)_content.Count;
				if (!(percent < num2))
				{
					SingleEnable(_content[num]);
					return;
				}
			}
			SingleEnable(null);
		}

		private void SetAdditiveMeshBaseOnPercent(float percent)
		{
			for (int i = 0; i < _content.Count; i++)
			{
				float num = (float)(i + 1) / (float)_content.Count;
				UnityEngine.Object obj = _content[i];
				if (obj is GameObject gameObject)
				{
					gameObject.SetActive(percent >= num);
				}
				else if (obj is MonoBehaviour monoBehaviour)
				{
					monoBehaviour.enabled = percent >= num;
				}
			}
		}

		private void SingleEnable(UnityEngine.Object p_object)
		{
			foreach (UnityEngine.Object item in _content)
			{
				if (!item)
				{
					continue;
				}
				if (item is GameObject gameObject)
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
				else if (item is MonoBehaviour monoBehaviour)
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
			_content.AddRange(GetComponentsInChildren(_autoGet.Type));
		}
	}
}

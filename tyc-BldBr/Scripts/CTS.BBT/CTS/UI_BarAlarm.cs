using System.Collections.Generic;
using CTS.AI;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_BarAlarm : MonoBehaviour
	{
		[SerializeField]
		private UI_OpenClose _buttonOpenClose;

		[SerializeField]
		private Image _fireImage;

		[SerializeField]
		private GameObject _lightContainer;

		[SerializeField]
		private float _speedBlink;

		[SerializeField]
		private AnimationCurve _blinkColor;

		[SerializeField]
		private Color _alarmColor;

		[SerializeField]
		private bool _openBarWhenAlarmOff;

		private bool _alarmIsOn;

		private List<Light> _lights = new List<Light>();

		private Color _lightColor;

		private float _currentTime;

		private void Awake()
		{
			_alarmIsOn = false;
			ChangeColor();
			float num = _lightContainer.transform.childCount;
			new List<GameObject>();
			for (int i = 0; (float)i < num; i++)
			{
				Transform child = _lightContainer.transform.GetChild(i);
				_lights.Add(child.gameObject.GetComponent<Light>());
				Debug.Log(child.gameObject);
			}
			_lightColor = _lights[0].color;
		}

		private void OnDisable()
		{
			LevelParameters.OnBarOpenedStatusChanged -= OnBarOpenedStatusChanged;
		}

		private void OnEnable()
		{
			LevelParameters.OnBarOpenedStatusChanged += OnBarOpenedStatusChanged;
		}

		private void OnBarOpenedStatusChanged(bool open)
		{
			if (open)
			{
				BarOpenCloseAlarm();
			}
		}

		private void ChangeLightalarm(bool alarmOn)
		{
			if (alarmOn)
			{
				foreach (Light light in _lights)
				{
					light.color = Color.red;
				}
				return;
			}
			foreach (Light light2 in _lights)
			{
				light2.color = _lightColor;
			}
		}

		public void BarOpenCloseAlarm()
		{
			_alarmIsOn = false;
			ChangeLightalarm(_alarmIsOn);
			ChangeColor();
		}

		public void ActiveAlarm()
		{
			if (_alarmIsOn)
			{
				_alarmIsOn = false;
				if (_openBarWhenAlarmOff)
				{
					CTSSingleton<LevelParameters>.Instance.SetOpened(p_value: true);
				}
			}
			else
			{
				_alarmIsOn = true;
				foreach (Agent item in Agents.List)
				{
					if (item is Customer && item.Tags.HasTag(EAgentTag.IsInside))
					{
						item.ActionPlayer.ForceAction(new AgentActionLeave(), EActionPriority.Forced);
						item.Animator.EnableOverride("Panic");
					}
				}
				CTSSingleton<LevelParameters>.Instance.SetOpened(p_value: false);
			}
			ChangeLightalarm(_alarmIsOn);
			ChangeColor();
		}

		private void ChangeColor()
		{
			if (_alarmIsOn)
			{
				_fireImage.color = Color.red;
			}
			else
			{
				_fireImage.color = Color.green;
			}
		}

		public bool AlarmIsOn()
		{
			return _alarmIsOn;
		}

		private void Update()
		{
			if (_alarmIsOn)
			{
				BlinkLight();
			}
		}

		private void BlinkLight()
		{
			_currentTime += Time.deltaTime * _speedBlink;
			if (_currentTime > 1f)
			{
				_currentTime -= 1f;
			}
			float t = Mathf.Clamp01(_blinkColor.Evaluate(_currentTime));
			foreach (Light light in _lights)
			{
				light.color = Color.Lerp(Color.red, Color.black, t);
			}
		}
	}
}

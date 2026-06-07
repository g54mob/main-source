using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

namespace DV.Debugging
{
	public class EffectsTogglerDebug : SingletonBehaviour<EffectsTogglerDebug>
	{
		public enum EffectType
		{
			RainParticles = 0,
			Water = 1,
			WindowDropletsSimulation = 2,
			WindowDropletsRendering = 3
		}

		private const string SPACER = "   ";

		private Rect windowRect = new Rect(30f, 30f, 250f, 0f);

		private Vector2 scrollPosition;

		private bool[] effectStates;

		private Action<bool>[] events;

		private IEnumerable<(EffectType, string)> effects;

		private IEnumerable<(PropertyInfo, string)> boolParams;

		private IEnumerable<(PropertyInfo, string)> floatParams;

		private bool renderingOn = true;

		private bool paramsOn = true;

		public new static string AllowAutoCreate()
		{
			return "[EffectsTogglerDebug]";
		}

		protected override void Awake()
		{
			base.Awake();
			EffectType[] array = (EffectType[])Enum.GetValues(typeof(EffectType));
			effects = array.Select((EffectType element) => (element: element, "   " + StringUtils.BreakCamelCaseToSeparateWords(element.ToString())));
			effectStates = new bool[array.Length];
			events = new Action<bool>[array.Length];
			for (int num = 0; num < array.Length; num++)
			{
				SetEffectStatus(array[num], on: true);
			}
			_ = Globals.G.GameParams;
			boolParams = from prop in typeof(GameParams).GetProperties(BindingFlags.Instance | BindingFlags.Public)
				where prop.PropertyType == typeof(bool)
				select (prop: prop, "   " + StringUtils.BreakCamelCaseToSeparateWords(prop.Name));
			floatParams = from prop in typeof(GameParams).GetProperties(BindingFlags.Instance | BindingFlags.Public)
				where prop.PropertyType == typeof(float)
				select (prop: prop, "   " + StringUtils.BreakCamelCaseToSeparateWords(prop.Name));
			base.gameObject.SetActive(value: false);
		}

		public void ToggleEffectStatus(EffectType type)
		{
			SetEffectStatus(type, !GetEffectStatus(type));
		}

		public bool GetEffectStatus(EffectType type)
		{
			return effectStates[(int)type];
		}

		public void SetEffectStatus(EffectType type, bool on)
		{
			effectStates[(int)type] = on;
			events[(int)type]?.Invoke(on);
		}

		public void SubscribeChanged(EffectType type, Action<bool> action)
		{
			ref Action<bool> reference = ref events[(int)type];
			reference = (Action<bool>)Delegate.Combine(reference, action);
			events[(int)type]?.Invoke(GetEffectStatus(type));
		}

		public void UnsubscribeChanged(EffectType type, Action<bool> action)
		{
			ref Action<bool> reference = ref events[(int)type];
			reference = (Action<bool>)Delegate.Remove(reference, action);
		}

		private void Update()
		{
			windowRect = new Rect(Screen.width - 430, 30f, 250f, 0f);
		}

		private void OnGUI()
		{
			windowRect = GUILayout.Window(998, windowRect, Window, "");
		}

		private void Window(int id)
		{
			scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(400f), GUILayout.Height(Screen.height - 100));
			renderingOn = GUILayout.Toggle(renderingOn, "Rendering Features");
			if (renderingOn)
			{
				GUILayout.BeginHorizontal();
				if (GUILayout.Button("Enable all"))
				{
					for (int i = 0; i < effectStates.Length; i++)
					{
						SetEffectStatus((EffectType)i, on: true);
					}
				}
				if (GUILayout.Button("Disable all"))
				{
					for (int j = 0; j < effectStates.Length; j++)
					{
						SetEffectStatus((EffectType)j, on: false);
					}
				}
				GUILayout.EndHorizontal();
				foreach (var effect in effects)
				{
					bool effectStatus = GetEffectStatus(effect.Item1);
					bool flag = GUILayout.Toggle(effectStatus, effect.Item2);
					if (flag != effectStatus)
					{
						SetEffectStatus(effect.Item1, flag);
					}
				}
			}
			paramsOn = GUILayout.Toggle(paramsOn, "Game Params");
			if (paramsOn)
			{
				GameParams gameParams = Globals.G.GameParams;
				foreach (var boolParam in boolParams)
				{
					bool flag2 = (bool)boolParam.Item1.GetValue(gameParams);
					bool flag3 = GUILayout.Toggle(flag2, boolParam.Item2);
					if (flag3 != flag2 && boolParam.Item1.CanWrite)
					{
						boolParam.Item1.SetValue(gameParams, flag3);
					}
				}
				foreach (var floatParam in floatParams)
				{
					float num = (float)floatParam.Item1.GetValue(gameParams);
					GUILayout.BeginHorizontal();
					string s = GUILayout.TextArea(num.ToString());
					GUILayout.Label(floatParam.Item2);
					if (float.TryParse(s, out var result) && floatParam.Item1.CanWrite && result != num)
					{
						floatParam.Item1.SetValue(gameParams, result);
					}
					GUILayout.EndHorizontal();
				}
			}
			GUILayout.EndScrollView();
		}
	}
}

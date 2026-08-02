using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rhizomatic.ImUI
{
	public class ImUIBuilder
	{
		public float indent;

		public bool disabled;

		public const float DEFAULT_HEIGHT = 60f;

		private float lastIndent;

		private bool lastDisabled;

		private List<string> tabs;

		public ImUIManager manager { get; }

		public ImUIBuilder(ImUIManager manager)
		{
		}

		public void Reset()
		{
		}

		public void StashIndent(float newIndentChange)
		{
		}

		public void LoadIndent()
		{
		}

		public void WithIndent(Action render, int indent = 20)
		{
		}

		public void SetDisable(bool value)
		{
		}

		public void RestoreDisabled()
		{
		}

		public void Title(string label, params ViewParam[] viewParams)
		{
		}

		public void Label(string label, params ViewParam[] viewParams)
		{
		}

		public void LabelHeight(string label, params ViewParam[] viewParams)
		{
		}

		public int Number(int value, params ViewParam[] viewParams)
		{
			return 0;
		}

		public float Number(float value, params ViewParam[] viewParams)
		{
			return 0f;
		}

		public Vector3 Vector3(Vector3 value, params ViewParam[] viewParams)
		{
			return default(Vector3);
		}

		public string Text(string text, params ViewParam[] viewParams)
		{
			return null;
		}

		public string Textarea(string text, params ViewParam[] viewParams)
		{
			return null;
		}

		public bool Button(string label, params ViewParam[] viewParams)
		{
			return false;
		}

		public void Image(Sprite sprite, params ViewParam[] viewParams)
		{
		}

		public void Image(Texture texture, params ViewParam[] viewParams)
		{
		}

		public void Space(params ViewParam[] viewParams)
		{
		}

		public void Space(float height, params ViewParam[] viewParams)
		{
		}

		public int Slider(int value, int min, int max, params ViewParam[] viewParams)
		{
			return 0;
		}

		public float Slider(float value, float min, float max, params ViewParam[] viewParams)
		{
			return 0f;
		}

		public float SliderNumber(float value, float min, float max, params ViewParam[] viewParams)
		{
			return 0f;
		}

		public int SliderNumber(int value, int min, int max, params ViewParam[] viewParams)
		{
			return 0;
		}

		public bool Toggle(bool isOn, params ViewParam[] viewParams)
		{
			return false;
		}

		public int Dropdown(int value, string[] options, params ViewParam[] viewParams)
		{
			return 0;
		}

		public TEnum Dropdown<TEnum>(TEnum value, params ViewParam[] viewParams) where TEnum : Enum
		{
			return default(TEnum);
		}

		public int Dropdown(int value, params string[] options)
		{
			return 0;
		}

		public string Dropdown(string value, string[] options, params ViewParam[] viewParams)
		{
			return null;
		}

		public string Dropdown(string value, string[] values, string[] options, params ViewParam[] viewParams)
		{
			return null;
		}

		public Color Color(Color color, params ViewParam[] viewParams)
		{
			return default(Color);
		}

		public string Color(string color, params ViewParam[] viewParams)
		{
			return null;
		}

		public T LabelField<T>(string label, Func<ViewParam, T> render, params ViewParam[] viewParams)
		{
			return default(T);
		}

		public T LabelField<T>(string label, float height, Func<ViewParam, T> render, params ViewParam[] viewParams)
		{
			return default(T);
		}

		public int Slider(string label, int value, int min, int max, params ViewParam[] viewParams)
		{
			return 0;
		}

		public float Slider(string label, float value, float min, float max, params ViewParam[] viewParams)
		{
			return 0f;
		}

		public int SliderNumber(string label, int value, int min, int max, params ViewParam[] viewParams)
		{
			return 0;
		}

		public float SliderNumber(string label, float value, float min, float max, params ViewParam[] viewParams)
		{
			return 0f;
		}

		public bool Toggle(string label, bool isOn, params ViewParam[] viewParams)
		{
			return false;
		}

		public int Dropdown(string label, int value, string[] options, params ViewParam[] viewParams)
		{
			return 0;
		}

		public TEnum Dropdown<TEnum>(string label, TEnum value, params ViewParam[] viewParams) where TEnum : Enum
		{
			return default(TEnum);
		}

		public int Dropdown(string label, int value, params string[] options)
		{
			return 0;
		}

		public int Number(string label, int value, params ViewParam[] viewParams)
		{
			return 0;
		}

		public float Number(string label, float value, params ViewParam[] viewParams)
		{
			return 0f;
		}

		public string Text(string label, string text, params ViewParam[] viewParams)
		{
			return null;
		}

		public string Color(string label, string color, params ViewParam[] viewParams)
		{
			return null;
		}

		public Vector3 Vector3(string label, Vector3 value, params ViewParam[] viewParams)
		{
			return default(Vector3);
		}

		public CurveData CurveField(CurveData curve, params ViewParam[] viewParams)
		{
			return null;
		}

		public void EndLayout()
		{
		}

		public void BeginHorizontal(params ViewParam[] viewParams)
		{
		}

		public void BeginHorizontal(float height, params ViewParam[] viewParams)
		{
		}

		public void Tab(string title, Action content)
		{
		}

		public void Tab(string title, int indent, Action content)
		{
		}

		public void Tab(string tabName, string title, Action content)
		{
		}

		public void Tab(string tabName, string title, int _indent, Action content)
		{
		}

		public void Row(Action content)
		{
		}
	}
}

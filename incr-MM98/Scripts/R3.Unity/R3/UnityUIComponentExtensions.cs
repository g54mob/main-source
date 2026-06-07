using System;
using UnityEngine;
using UnityEngine.UI;

namespace R3
{
	public static class UnityUIComponentExtensions
	{
		public static IDisposable SubscribeToText(this Observable<string> source, Text text)
		{
			return source.Subscribe(text, delegate(string x, Text t)
			{
				t.text = x;
			});
		}

		public static IDisposable SubscribeToText<T>(this Observable<T> source, Text text)
		{
			return source.Subscribe(text, delegate(T x, Text t)
			{
				t.text = x.ToString();
			});
		}

		public static IDisposable SubscribeToText<T>(this Observable<T> source, Text text, Func<T, string> selector)
		{
			return source.Subscribe((text, selector), delegate(T x, (Text text, Func<T, string> selector) state)
			{
				state.text.text = state.selector(x);
			});
		}

		public static IDisposable SubscribeToInteractable(this Observable<bool> source, Selectable selectable)
		{
			return source.Subscribe(selectable, delegate(bool x, Selectable s)
			{
				s.interactable = x;
			});
		}

		public static Observable<Unit> OnClickAsObservable(this Button button)
		{
			return button.onClick.AsObservable(button.GetDestroyCancellationToken());
		}

		public static Observable<bool> OnValueChangedAsObservable(this Toggle toggle)
		{
			return Observable.Create(toggle, delegate(Observer<bool> observer, Toggle t)
			{
				observer.OnNext(t.isOn);
				return t.onValueChanged.AsObservable(t.GetDestroyCancellationToken()).Subscribe(observer);
			});
		}

		public static Observable<float> OnValueChangedAsObservable(this Scrollbar scrollbar)
		{
			return Observable.Create(scrollbar, delegate(Observer<float> observer, Scrollbar s)
			{
				observer.OnNext(s.value);
				return s.onValueChanged.AsObservable(s.GetDestroyCancellationToken()).Subscribe(observer);
			});
		}

		public static Observable<Vector2> OnValueChangedAsObservable(this ScrollRect scrollRect)
		{
			return Observable.Create(scrollRect, delegate(Observer<Vector2> observer, ScrollRect s)
			{
				observer.OnNext(s.normalizedPosition);
				return s.onValueChanged.AsObservable(s.GetDestroyCancellationToken()).Subscribe(observer);
			});
		}

		public static Observable<float> OnValueChangedAsObservable(this Slider slider)
		{
			return Observable.Create(slider, delegate(Observer<float> observer, Slider s)
			{
				observer.OnNext(s.value);
				return s.onValueChanged.AsObservable(s.GetDestroyCancellationToken()).Subscribe(observer);
			});
		}

		public static Observable<string> OnEndEditAsObservable(this InputField inputField)
		{
			return inputField.onEndEdit.AsObservable(inputField.GetDestroyCancellationToken());
		}

		public static Observable<string> OnValueChangedAsObservable(this InputField inputField)
		{
			return Observable.Create(inputField, delegate(Observer<string> observer, InputField i)
			{
				observer.OnNext(i.text);
				return i.onValueChanged.AsObservable(i.GetDestroyCancellationToken()).Subscribe(observer);
			});
		}

		public static Observable<int> OnValueChangedAsObservable(this Dropdown dropdown)
		{
			return Observable.Create(dropdown, delegate(Observer<int> observer, Dropdown d)
			{
				observer.OnNext(d.value);
				return d.onValueChanged.AsObservable(d.GetDestroyCancellationToken()).Subscribe(observer);
			});
		}
	}
}

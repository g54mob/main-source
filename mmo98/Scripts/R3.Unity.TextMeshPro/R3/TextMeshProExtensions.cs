using System;
using TMPro;
using UnityEngine;

namespace R3
{
	public static class TextMeshProExtensions
	{
		public static IDisposable SubscribeToText(this Observable<string> source, TMP_Text text)
		{
			return source.Subscribe(text, delegate(string x, TMP_Text t)
			{
				t.text = x;
			});
		}

		public static IDisposable SubscribeToText<T>(this Observable<T> source, TMP_Text text)
		{
			return source.Subscribe(text, delegate(T x, TMP_Text t)
			{
				t.text = x.ToString();
			});
		}

		public static IDisposable SubscribeToText<T>(this Observable<T> source, TMP_Text text, Func<T, string> selector)
		{
			return source.Subscribe((text, selector), delegate(T x, (TMP_Text text, Func<T, string> selector) state)
			{
				state.text.text = state.selector(x);
			});
		}

		public static Observable<string> OnEndEditAsObservable(this TMP_InputField inputField)
		{
			return inputField.onEndEdit.AsObservable(((MonoBehaviour)(object)inputField).GetDestroyCancellationToken());
		}

		public static Observable<string> OnValueChangedAsObservable(this TMP_InputField inputField)
		{
			return Observable.Create(inputField, delegate(Observer<string> observer, TMP_InputField i)
			{
				observer.OnNext(i.text);
				return i.onValueChanged.AsObservable(((MonoBehaviour)(object)i).GetDestroyCancellationToken()).Subscribe(observer);
			});
		}

		public static Observable<int> OnValueChangedAsObservable(this TMP_Dropdown dropdown)
		{
			return Observable.Create(dropdown, delegate(Observer<int> observer, TMP_Dropdown d)
			{
				observer.OnNext(d.value);
				return d.onValueChanged.AsObservable(((MonoBehaviour)(object)d).GetDestroyCancellationToken()).Subscribe(observer);
			});
		}
	}
}

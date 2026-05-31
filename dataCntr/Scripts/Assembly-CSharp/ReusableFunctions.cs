using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public static class ReusableFunctions
{
	[CompilerGenerated]
	private sealed class _003CDisableGameObjectWithDelay_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float time;

		public GameObject go;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CDisableGameObjectWithDelay_003Ed__6(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CImageScrollingUI_003Ed__3 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Sprite[] _sprites;

		public Image _image;

		private float _003Ctime_003E5__2;

		private float _003CcurrentTime_003E5__3;

		private int _003CcurrentImage_003E5__4;

		private int _003CnumberOfImages_003E5__5;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CImageScrollingUI_003Ed__3(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CNumberScrollingUI_003Ed__2 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TextMeshProUGUI _text;

		public int _endNumber;

		private int _003Ci_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CNumberScrollingUI_003Ed__2(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public static void DestroyChildren(this Transform root)
	{
	}

	public static bool IsBetweenRange(this float thisValue, float value1, float value2)
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003CNumberScrollingUI_003Ed__2))]
	public static IEnumerator NumberScrollingUI(TextMeshProUGUI _text, int _endNumber)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CImageScrollingUI_003Ed__3))]
	public static IEnumerator ImageScrollingUI(Sprite[] _sprites, Image _image)
	{
		return null;
	}

	public static void ChangeButtonNormalColor(Button button, Color color)
	{
	}

	public static int[] ShuffledArrayOfInts(int arrayLenght)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CDisableGameObjectWithDelay_003Ed__6))]
	public static IEnumerator DisableGameObjectWithDelay(GameObject go, float time)
	{
		return null;
	}

	public static int CalculateHowManyTimesIsNumberInIntArray(int numberToFind, int[] inArray)
	{
		return 0;
	}

	public static string[] SplitCsvLine(string line)
	{
		return null;
	}

	public static Color HexToColor(string hex)
	{
		return default(Color);
	}

	public static double CalculatePercentage(int total, int number)
	{
		return 0.0;
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using Dreamteck.Splines;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.Graphics;
using VampireSurvivors.UI;

namespace VampireSurvivors;

public class UISplineSpawner : MonoBehaviour
{
	private sealed class _003CDoSpawning_003Ed__12(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public UISplineSpawner _003C_003E4__this;

		private int _003Ccount_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0055: Expected I4, but got I8
			//IL_046c: Expected O, but got F4
			//IL_0431: Expected O, but got F4
			//IL_0094->IL03ca: Incompatible stack heights: 1 vs 0
			//IL_0099->IL0099: Incompatible stack heights: 1 vs 0
			//IL_03ca->IL045e: Incompatible stack heights: 1 vs 0
			//IL_03b1->IL0404: Incompatible stack heights: 11 vs 1
			UISplineSpawner uISplineSpawner = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003Ccount_003E5__2 = 0;
				goto IL_0099;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				bool flag = (object)_003C_003E4__this == null;
				if (uISplineSpawner._duration > uISplineSpawner._currentTime)
				{
					goto IL_0099;
				}
			}
			return false;
			IL_0099:
			bool flag2 = (object)_003C_003E4__this == null;
			if (uISplineSpawner._intervalTime > uISplineSpawner._interval)
			{
				bool flag3 = (object)uISplineSpawner._ContentToSpawn == null;
				GameObject gameObject = uISplineSpawner._ContentToSpawn.gameObject;
				GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject, uISplineSpawner._container);
				bool flag4 = (object)gameObject2 == null;
				UISplineFollower component = gameObject2.GetComponent<UISplineFollower>();
				RandomSpriteUI component2 = gameObject2.GetComponent<RandomSpriteUI>();
				int num = _003Ccount_003E5__2;
				bool flag5 = (object)component2 == null;
				Image component3 = component2.GetComponent<Image>();
				component2._image = component3;
				List<string> spriteNames = component2._SpriteNames;
				bool flag6 = component2._SpriteNames == null;
				bool flag7 = _003Ccount_003E5__2 >= spriteNames._size;
				string[] items = spriteNames._items;
				bool flag8 = spriteNames._items == null;
				Sprite unpackedSprite = SpriteManager.GetUnpackedSprite(items[num]);
				bool flag9 = (object)component2._image == null;
				component2._image.sprite = unpackedSprite;
				bool flag10 = (object)component == null;
				component.SetSpline(uISplineSpawner._spline);
				List<object> spawned = (List<object>)(object)uISplineSpawner._spawned;
				bool flag11 = uISplineSpawner._spawned == null;
				int version = spawned._version + 1;
				spawned._version = version;
				object[] items2 = spawned._items;
				bool flag12 = spawned._items == null;
				if (spawned._size >= items2.Length)
				{
					((List<object>)(object)uISplineSpawner._spawned).AddWithResize((object)component);
				}
				else
				{
					int size = spawned._size + 1;
					spawned._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				int loopCount = default(int);
				Ease ease = default(Ease);
				component.Play(uISplineSpawner._speed, uISplineSpawner._delay, shouldLoop: false, loopCount, ease);
				uISplineSpawner._intervalTime = 0f;
				int num2 = _003Ccount_003E5__2 + 1;
				_003Ccount_003E5__2 = num2;
			}
			object obj = Time.deltaTime;
			float num3 = (uISplineSpawner._currentTime = uISplineSpawner._intervalTime + uISplineSpawner._currentTime);
			object obj2 = Time.deltaTime;
			float intervalTime = num3 + uISplineSpawner._intervalTime;
			uISplineSpawner._intervalTime = intervalTime;
			_003C_003E2__current = null;
			_003C_003E1__state = 1;
			return true;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private UISplineFollower _ContentToSpawn;

	private SplineComputer _spline;

	private float _interval;

	private float _duration;

	private float _currentTime;

	private float _intervalTime;

	private float _speed;

	private float _delay;

	private RectTransform _container;

	private List<UISplineFollower> _spawned;

	public void SetContainer(RectTransform rTran)
	{
		_container = rTran;
	}

	public void StartSpawning(SplineComputer spline, float interval, float duration, float speed, float delay = 0f)
	{
		_spline = spline;
		float speed2 = default(float);
		_speed = speed2;
		float delay2 = default(float);
		_delay = delay2;
		_interval = interval;
		_duration = duration;
		_003CDoSpawning_003Ed__12 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator DoSpawning()
	{
		_003CDoSpawning_003Ed__12 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void OnDestroy()
	{
		Clear();
	}

	public void Clear()
	{
		//IL_0039->IL0125: Incompatible stack heights: 1 vs 0
		if (_spawned != null)
		{
			List<UISplineFollower>.Enumerator enumerator = default(List<UISplineFollower>.Enumerator);
			while (enumerator.MoveNext())
			{
				object obj = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rbx_v7 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rbx_v7 (System.Object)+10]");
				IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
				GameObject obj2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				UnityEngine.Object.Destroy(obj2, 0f);
			}
			List<UISplineFollower> spawned = _spawned;
			if (_spawned != null)
			{
				int version = spawned._version + 1;
				spawned._version = version;
				spawned._size = 0;
				if (spawned._size > 0)
				{
					Array.Clear(spawned._items, 0, spawned._size);
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	public UISplineSpawner()
	{
		List<UISplineFollower> spawned = new List<UISplineFollower>();
		_spawned = spawned;
	}
}

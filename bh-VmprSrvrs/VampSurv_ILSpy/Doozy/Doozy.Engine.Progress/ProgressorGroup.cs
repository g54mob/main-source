using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.Engine.Settings;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.Progress;

public class ProgressorGroup : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<Progressor, bool> _003C_003E9__20_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CRemoveAnyNullProgressors_003Eb__20_0(Progressor p)
		{
			if ((object)p != null)
			{
				bool flag = ((UnityEngine.Object)p).m_CachedPtr == (IntPtr)0;
				return !flag;
			}
			return false;
		}
	}

	public const float TOLERANCE = 0.001f;

	public bool DebugMode;

	public List<Progressor> Progressors;

	public ProgressEvent OnProgressChanged;

	public ProgressEvent OnInverseProgressChanged;

	private Sequence m_animationSequence;

	private float m_previousProgress;

	private float m_progress;

	public float Progress
	{
		get
		{
			return m_progress;
		}
		private set
		{
			//IL_0009: Invalid comparison between I4 and F4
			float num = default(float);
			if (!(0f > num) && num > 1f)
			{
				m_progress = 1f;
				OnProgressUpdated();
			}
			else
			{
				m_progress = 0f;
				OnProgressUpdated();
			}
		}
	}

	public float InverseProgress => 1f - m_progress;

	private bool DebugComponent
	{
		get
		{
			//IL_0063: Expected I4, but got O
			if (DebugMode)
			{
				return true;
			}
			DoozySettings instance = DoozySettings.Instance;
			if ((object)instance != null)
			{
				return instance.DebugProgressorGroup;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private void OnEnable()
	{
		RemoveAnyNullProgressors();
		UpdateProgress();
	}

	private void OnDisable()
	{
		RemoveAnyNullProgressors();
	}

	private void Update()
	{
		UpdateProgress();
		bool flag = m_previousProgress == m_progress;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000182C3116Dh\"");
		if (!flag)
		{
			OnProgressUpdated();
			m_previousProgress = m_progress;
		}
	}

	public void UpdateProgress()
	{
		//IL_0061: Expected F4, but got I4
		//IL_006a: Expected O, but got I4
		//IL_01f5: Expected F4, but got I4
		//IL_0337: Invalid comparison between I4 and F4
		//IL_0203: Expected F4, but got I4
		//IL_026d: Expected F4, but got I4
		//IL_0300: Expected O, but got I4
		//IL_01aa: Invalid comparison between I4 and F4
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Expected O, but got Unknown
		if (Progressors == null)
		{
			return;
		}
		List<Progressor> progressors = Progressors;
		bool flag = progressors._size < 0;
		if (progressors._size == 0)
		{
			return;
		}
		int num = progressors._size - 1;
		float num2 = 0f;
		object obj = 0;
		float num3;
		if (!flag)
		{
			object obj2;
			do
			{
				List<Progressor> progressors2 = Progressors;
				if (num < progressors2._size)
				{
					Progressor[] items = progressors2._items;
					Progressor progressor = items[num];
					bool flag2 = (nint)items[num] < 0;
					if ((object)items[num] != null)
					{
						flag2 = (nint)((UnityEngine.Object)progressor).m_CachedPtr < 0;
						if (((UnityEngine.Object)progressor).m_CachedPtr != (IntPtr)0)
						{
							obj++;
							Progressor progressor2 = Progressors.get_Item(num);
							flag2 = (nint)progressor2 < 0;
							float progress = progressor2.Progress;
							num2 += progress;
						}
					}
					num--;
					obj2 = !flag2;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				throw new NullReferenceException();
			}
			while (obj2 != null);
			if (obj != null)
			{
				num3 = num2 / (float)obj;
				if (!(0f > num3))
				{
					if (num3 > 1f)
					{
						num3 = 1f;
					}
					goto IL_030e;
				}
			}
		}
		num3 = 0f;
		goto IL_030e;
		IL_030e:
		if (0.001f > num3)
		{
			num3 = 0f;
		}
		else if (num3 > 0.999f)
		{
			num3 = 1f;
		}
		if (!(0f > num3))
		{
			if (num3 > 1f)
			{
				num3 = 1f;
			}
		}
		else
		{
			num3 = 0f;
		}
		m_progress = num3;
		OnProgressUpdated();
	}

	public float GetProgress(TargetProgress direction)
	{
		switch (direction)
		{
		case TargetProgress.Progress:
			return m_progress;
		case TargetProgress.InverseProgress:
			return 1f - m_progress;
		default:
		{
			TargetProgress targetProgress = default(TargetProgress);
			object actualValue = targetProgress;
			ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("direction", actualValue, null);
			throw ex;
		}
		}
	}

	private void RemoveAnyNullProgressors()
	{
		if (Progressors == null)
		{
			List<Progressor> progressors = new List<Progressor>();
			Progressors = progressors;
		}
		Func<Progressor, bool> predicate = _003C_003Ec._003C_003E9__20_0;
		if (_003C_003Ec._003C_003E9__20_0 == null)
		{
			predicate = (_003C_003Ec._003C_003E9__20_0 = delegate(Progressor p)
			{
				if ((object)p != null)
				{
					bool flag = ((UnityEngine.Object)p).m_CachedPtr == (IntPtr)0;
					return !flag;
				}
				return false;
			});
		}
		IEnumerable<Progressor> enumerable = Enumerable.Where(Progressors, predicate);
		if (enumerable != null)
		{
			List<object> progressors2 = new List<object>(enumerable);
			Progressors = (List<Progressor>)(object)progressors2;
			UpdateProgress();
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	private void OnProgressUpdated()
	{
		if (!DebugMode)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugProgressorGroup)
			{
				goto IL_0100;
			}
		}
		string[] array = new string[6];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		string text = GetName();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
		string text2 = System.Number.FormatSingle(m_progress, null, currentInfo);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		float value = 1f - m_progress;
		NumberFormatInfo currentInfo2 = NumberFormatInfo.CurrentInfo;
		string text3 = System.Number.FormatSingle(value, null, currentInfo2);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		string message = string.Concat(array);
		DDebug.Log(message, this);
		goto IL_0100;
		IL_0100:
		OnProgressChanged.Invoke(m_progress);
		float arg = 1f - m_progress;
		OnInverseProgressChanged.Invoke(arg);
	}

	private static ProgressorGroup AddToScene(bool selectGameObjectAfterCreation = false)
	{
		return DoozyUtils.AddToScene<ProgressorGroup>("Progressor Group", isSingleton: false, selectGameObjectAfterCreation);
	}

	public ProgressorGroup()
	{
		ProgressEvent onProgressChanged = new ProgressEvent();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180494DF0");
		OnProgressChanged = onProgressChanged;
		ProgressEvent onInverseProgressChanged = new ProgressEvent();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180494DF0");
		OnInverseProgressChanged = onInverseProgressChanged;
	}
}

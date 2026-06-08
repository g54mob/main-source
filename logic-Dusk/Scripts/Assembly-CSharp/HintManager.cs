using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class HintManager
{
	private static IHintState currentHintState;

	private static List<IHint> hintList;

	private static bool isBatchingHints;

	public static GameObject HintPanelGameObject { get; set; }

	public static GameObject HintBackgroundObject { get; set; }

	public static GameObject HintAttentionObject { get; private set; }

	public static GameObject HintAttentionRing1 { get; private set; }

	public static GameObject HintAttentionRing2 { get; private set; }

	public static GameObject HintAttentionRing3 { get; private set; }

	public static GameObject HintAttentionRing4 { get; private set; }

	public static GameObject HintAttentionRing5 { get; private set; }

	public static Text HintText { get; set; }

	public static Image HintBorder { get; set; }

	public static Vector3 OffScreenPosition { get; set; }

	public static Vector3 OnScreenPosition { get; set; }

	public static IHint currentHint { get; private set; }

	public static Color defaultRingColor { get; set; }

	public static void AddAttentionObject(GameObject attentionObject)
	{
		if (attentionObject != null)
		{
			HintAttentionObject = attentionObject;
			if (HintBorder != null)
			{
				defaultRingColor = HintBorder.color;
			}
			HintAttentionRing1 = attentionObject.transform.FindChild("Ring1").gameObject;
			HintAttentionRing2 = attentionObject.transform.FindChild("Ring2").gameObject;
			HintAttentionRing3 = attentionObject.transform.FindChild("Ring3").gameObject;
			HintAttentionRing4 = attentionObject.transform.FindChild("Ring4").gameObject;
			HintAttentionRing5 = attentionObject.transform.FindChild("Ring5").gameObject;
		}
	}

	public static void EnableAttention()
	{
		HintAttentionObject.SetActive(true);
		HintAttentionRing1.SetActive(true);
		HintAttentionRing2.SetActive(false);
		HintAttentionRing3.SetActive(false);
		HintAttentionRing4.SetActive(false);
		HintAttentionRing5.SetActive(false);
	}

	public static void SetRingAlpha(int ringIdx, float alpha)
	{
		GameObject gameObject = null;
		switch (ringIdx)
		{
		case 0:
			gameObject = HintAttentionRing1;
			break;
		case 1:
			gameObject = HintAttentionRing2;
			break;
		case 2:
			gameObject = HintAttentionRing3;
			break;
		case 3:
			gameObject = HintAttentionRing4;
			break;
		case 4:
			gameObject = HintAttentionRing5;
			break;
		}
		if (gameObject != null)
		{
			if (!gameObject.activeSelf)
			{
				gameObject.SetActive(true);
			}
			Color color = gameObject.GetComponent<Image>().color;
			color.a = alpha;
			gameObject.GetComponent<Image>().color = color;
		}
	}

	public static void BeginHintBatch()
	{
		isBatchingHints = true;
	}

	public static void EndHintBatch()
	{
		isBatchingHints = false;
	}

	public static void FlushHints()
	{
		if (hintList != null && hintList.Count > 0)
		{
			hintList.Clear();
		}
		if (currentHint != null)
		{
			currentHint.Terminate();
			currentHint = null;
		}
		if (currentHintState != null)
		{
			currentHintState = null;
		}
	}

	public static void PushHint(IHint hint)
	{
		PushHint(hint, false);
	}

	public static void PushHint(IHint hint, bool ignoreDuplicate)
	{
		PushHint(hint, ignoreDuplicate, false);
	}

	public static void PushHint(IHint hint, bool ignoreDuplicate, bool ignoreHintDisabled)
	{
		if (!GlobalSettings.IsTutorial && (ignoreHintDisabled || !GameSaveFile.Get("HNT_DISABLE", false)) && (currentHint == null || currentHint.GetType() != hint.GetType()))
		{
			PushGeneralHint(hint, ignoreDuplicate);
		}
	}

	public static void PushTutorialHint(IHint hint)
	{
		bool flag = currentHint != null;
		PushGeneralHint(hint, true);
		if (flag)
		{
			TryPopNextHint();
		}
	}

	private static void PushGeneralHint(IHint hint, bool ignoreDuplicate)
	{
		if (currentHint == null)
		{
			StartHint(hint);
			return;
		}
		bool flag = false;
		if (hintList == null)
		{
			hintList = new List<IHint>();
		}
		if (ignoreDuplicate)
		{
			int count = hintList.Count;
			for (int i = 0; i < count; i++)
			{
				IHint hint2 = hintList[i];
				if (hint2.GetType() == hint.GetType())
				{
					return;
				}
			}
		}
		if (hint.Priority > 0)
		{
			int count2 = hintList.Count;
			if (count2 > 0)
			{
				int num = count2;
				for (int j = 0; j < count2; j++)
				{
					if (hintList[j].Priority < hint.Priority)
					{
						num = 0;
						break;
					}
				}
				if (num < count2)
				{
					if (!isBatchingHints && num > 0)
					{
						hintList.Add(new SpacerHint(0.1f));
					}
					hintList.Insert(num, hint);
					flag = true;
				}
			}
		}
		if (!flag)
		{
			if (!isBatchingHints)
			{
				hintList.Add(new SpacerHint(0.1f));
			}
			hintList.Add(hint);
		}
	}

	private static void StartHint(IHint hint)
	{
		if (!(HintPanelGameObject == null))
		{
			if (hint != null)
			{
				currentHint = hint;
				currentHintState = currentHint.Start();
				currentHintState.Start();
				GameAudio.Play2DSFX(GameAudio.SoundEnum.Hint);
			}
			else
			{
				TryPopNextHint();
			}
		}
	}

	private static void TryPopNextHint()
	{
		if (hintList != null && hintList.Count > 0)
		{
			IHint hint = hintList[0];
			hintList.RemoveAt(0);
			if (hintList.Count == 0)
			{
				hintList = null;
			}
			StartHint(hint);
		}
		else
		{
			currentHint = null;
			currentHintState = null;
		}
	}

	public static void Update()
	{
		if (currentHint == null || currentHintState == null)
		{
			return;
		}
		currentHint.Update();
		if (currentHintState.Update())
		{
			currentHintState = currentHint.GetNextState();
			if (currentHintState == null)
			{
				TryPopNextHint();
			}
			else
			{
				currentHintState.Start();
			}
		}
	}

	public static bool HintCompleted(Type type)
	{
		bool flag = false;
		if (currentHint != null && currentHint.GetType() == type && !currentHint.IsCompleting)
		{
			if (!currentHint.CompleteTriggersNextStep)
			{
				if (!currentHint.OnlyAllowCompleteIfStarted || currentHint.HasStarted)
				{
					if (currentHintState != null)
					{
						currentHintState.Stop();
					}
					currentHintState = currentHint.Completed();
					if (currentHintState == null)
					{
						TryPopNextHint();
					}
					else
					{
						currentHintState.Start();
					}
				}
				else
				{
					HintCanceled(type);
				}
			}
			else
			{
				currentHintState = currentHint.GetNextState();
				if (currentHintState == null)
				{
					TryPopNextHint();
				}
				else
				{
					currentHintState.Start();
				}
			}
		}
		if (!flag && hintList != null)
		{
			int count = hintList.Count;
			for (int num = count - 1; num >= 0; num--)
			{
				IHint hint = hintList[num];
				if (hint.GetType() == type)
				{
					hintList[num].Completed();
					hintList.RemoveAt(num);
					if (num > 0 && hintList[num - 1].GetType() == typeof(SpacerHint))
					{
						hintList.RemoveAt(num - 1);
					}
					if (hintList.Count == 0)
					{
						hintList = null;
					}
					flag = true;
					break;
				}
			}
		}
		return flag;
	}

	public static void CancelAllHints()
	{
		if (currentHint != null)
		{
			if (currentHintState != null)
			{
				currentHintState.Stop();
			}
			currentHintState = currentHint.Terminate();
			if (currentHintState != null)
			{
				currentHintState.Start();
			}
			else
			{
				currentHint = null;
			}
		}
		if (hintList != null)
		{
			int count = hintList.Count;
			for (int num = count - 1; num >= 0; num--)
			{
				hintList.RemoveAt(num);
			}
		}
	}

	public static void HintCanceled(Type type)
	{
		bool flag = false;
		if (currentHint != null && currentHint.GetType() == type)
		{
			if (currentHintState != null)
			{
				currentHintState.Stop();
			}
			currentHintState = currentHint.Terminate();
			if (currentHintState == null)
			{
				TryPopNextHint();
			}
			else
			{
				currentHintState.Start();
			}
			flag = true;
		}
		if (flag || hintList == null)
		{
			return;
		}
		int count = hintList.Count;
		for (int num = count - 1; num >= 0; num--)
		{
			IHint hint = hintList[num];
			if (hint.GetType() == type)
			{
				hintList[num].Terminate();
				hintList.RemoveAt(num);
				if (num > 0 && hintList[num - 1].GetType() == typeof(SpacerHint))
				{
					hintList.RemoveAt(num - 1);
				}
				if (hintList.Count == 0)
				{
					hintList = null;
				}
				flag = true;
				break;
			}
		}
	}
}

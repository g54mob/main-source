using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MomentPhotographer : MonoBehaviour
{
	public enum State
	{
		Boot = 0,
		LoadingScene = 1,
		WaitingForPhoto = 2,
		Done = 3
	}

	public const int kPhotoW = 440;

	public const int kPhotoH = 320;

	public const int kAtlasW = 4096;

	public const int kAtlasH = 2048;

	public const int kAtlasNumPhotosX = 9;

	public const int kCaptureResMult = 2;

	private Stater<State> stater;

	private List<string> momentIds;

	private string curMomentId;

	public static void MakeAutoGo()
	{
		GameObject gameObject = new GameObject("MomentPhotographer");
		gameObject.hideFlags = HideFlags.DontSave;
		gameObject.AddComponent<MomentPhotographer>();
		Object.DontDestroyOnLoad(gameObject);
	}

	public static Rect GetUvRect(int momentIndex, int fitWidth = 440, int fitHeight = 320)
	{
		int num = momentIndex % 9;
		int num2 = momentIndex / 9;
		Rect rect = new Rect(num * 440, 2048 - (num2 + 1) * 320, 440f, 320f);
		Vector2 center = rect.center;
		float num3 = (float)fitWidth / (float)fitHeight;
		float num4 = 1.375f;
		if (num3 > num4)
		{
			rect.y = Mathf.FloorToInt(center.y - 0.5f * rect.width / num3);
			rect.height = Mathf.FloorToInt(rect.width / num3);
		}
		else
		{
			rect.x = Mathf.FloorToInt(center.x - 0.5f * rect.height * num3);
			rect.width = Mathf.FloorToInt(rect.height * num3);
		}
		return new Rect(rect.x / 4096f, rect.y / 2048f, rect.width / 4096f, rect.height / 2048f);
	}

	private void Start()
	{
		momentIds = new List<string>();
		string text = "d070";
		foreach (Story.Moment item in Story.it.IterateAllMoments())
		{
			if (!text.HasValue() || !(item.disaster.id != text))
			{
				momentIds.Add(item.id);
			}
		}
		stater = new Stater<State>("MomentPhotographer");
		Stater<State>.enableDebugLog = true;
		stater.AddState(State.Boot).SetDurations(0f, 0.1f, State.LoadingScene);
		stater.AddState(State.LoadingScene).AddFunc(StaterFunc.ENTER(delegate
		{
			if (momentIds.Count > 0)
			{
				curMomentId = momentIds[0];
				momentIds.RemoveAt(0);
				SceneManager.LoadScene(curMomentId, LoadSceneMode.Single);
			}
			else
			{
				stater.Go(State.Done);
			}
		})).AddFunc(StaterFunc.STEP(delegate
		{
			if (stater.stateTime > 1f)
			{
				MomentLogic momentLogic = Object.FindObjectOfType<MomentLogic>();
				if (momentLogic != null && momentLogic.isActiveAndEnabled && momentLogic.gameObject.scene.name == curMomentId)
				{
					momentLogic.GoMomentPhotoAuto();
					stater.Go(State.WaitingForPhoto);
				}
			}
		}));
		stater.AddState(State.WaitingForPhoto).AddFunc(StaterFunc.STEP(delegate
		{
			MomentLogic momentLogic = Object.FindObjectOfType<MomentLogic>();
			if (momentLogic != null && momentLogic.isMomentPhotoAutoDone)
			{
				stater.Go(State.LoadingScene);
			}
		}));
		stater.AddState(State.Done);
	}

	private void FixedUpdate()
	{
		stater.Step(1f / 60f);
	}

	public static void Prep(string momentId)
	{
	}

	public static void Snap(string momentId, OneBit oneBit)
	{
	}
}

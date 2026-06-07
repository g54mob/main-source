using System;
using System.Collections.Generic;
using NewGameplayScripts;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
	public class OnCursorChangedEventArgs : EventArgs
	{
		public CursorType cursorType;
	}

	public enum CursorType
	{
		Arrow = 0,
		Select = 1,
		Grab = 2
	}

	[Serializable]
	public class CursorImage
	{
		public CursorType cursorType;

		public Texture2D texture;

		public Vector2 offset;
	}

	[SerializeField]
	private List<CursorImage> cursorImageList;

	private CursorImage cursorImage;

	private bool canChange;

	private bool isGrabbing;

	public static CursorManager Instance { get; private set; }

	public event EventHandler<OnCursorChangedEventArgs> OnCursorChanged;

	private void Awake()
	{
		Instance = this;
		canChange = true;
		isGrabbing = false;
	}

	private void Start()
	{
		SetActiveCursorType(CursorType.Arrow);
		MovementSystem.Instance.OnStartGrabbing += MovementSystem_OnStartGrabbing;
		MovementSystem.Instance.OnStopGrabbing += MovementSystem_OnStopGrabbing;
	}

	private void MovementSystem_OnStartGrabbing(object sender, EventArgs e)
	{
		isGrabbing = true;
	}

	private void MovementSystem_OnStopGrabbing(object sender, EventArgs e)
	{
		isGrabbing = false;
	}

	private void OnDestroy()
	{
		MovementSystem.Instance.OnStartGrabbing -= MovementSystem_OnStartGrabbing;
		MovementSystem.Instance.OnStopGrabbing -= MovementSystem_OnStopGrabbing;
	}

	private void Update()
	{
		if (canChange && !InputManager.Instance.gamePause)
		{
			Cursor.SetCursor(cursorImage.texture, cursorImage.offset, CursorMode.Auto);
			canChange = false;
		}
	}

	public void SetActiveCursorType(CursorType cursorType)
	{
		if (!isGrabbing)
		{
			canChange = true;
			SetActiveCursorImage(GetCursorImage(cursorType));
			this.OnCursorChanged?.Invoke(this, new OnCursorChangedEventArgs
			{
				cursorType = cursorType
			});
		}
	}

	private CursorImage GetCursorImage(CursorType cursorType)
	{
		foreach (CursorImage cursorImage in cursorImageList)
		{
			if (cursorImage.cursorType == cursorType)
			{
				return cursorImage;
			}
		}
		return null;
	}

	private void SetActiveCursorImage(CursorImage cursorImage)
	{
		this.cursorImage = cursorImage;
	}
}

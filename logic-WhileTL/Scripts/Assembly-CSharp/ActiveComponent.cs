using App.Data;
using Aux;
using UnityEngine;

public class ActiveComponent : MonoBehaviour
{
	protected static bool _isGeneralInited = false;

	protected static ViewModel _viewModel;

	protected static Controller _controller;

	protected static View _view;

	protected static Program Program;

	protected static StaticData _staticData;

	protected static SoundSystem Sound;

	protected static History _history = new History();

	protected bool _isInstanceInited;

	protected bool _enabled = true;

	protected Vector2 fp = Vector2.zero;

	protected Vector2 lp = Vector2.zero;

	protected float dragDistance;

	private bool beganRegistered;

	protected static Model Model { get; private set; }

	public bool IsEnabled
	{
		get
		{
			if (_enabled)
			{
				return _isInstanceInited;
			}
			return false;
		}
	}

	public bool IsInited => _isInstanceInited;

	public static bool IsGeneralInited => _isGeneralInited;

	protected virtual void RightSwipe()
	{
	}

	protected virtual void LeftSwipe()
	{
	}

	protected virtual void UpSwipe()
	{
	}

	protected virtual void DownSwipe()
	{
	}

	protected virtual void Tap(Vector3 position)
	{
	}

	protected void CheckMobilInput()
	{
		if (Input.touchCount == 1)
		{
			Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began)
			{
				fp = touch.position;
				lp = touch.position;
				beganRegistered = true;
			}
			else if (touch.phase == TouchPhase.Ended && beganRegistered)
			{
				lp = touch.position;
				if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
				{
					if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
					{
						if (lp.x > fp.x)
						{
							RightSwipe();
						}
						else
						{
							LeftSwipe();
						}
					}
					else if (lp.y > fp.y)
					{
						UpSwipe();
					}
					else
					{
						DownSwipe();
					}
				}
				else
				{
					Vector3 position = Helper.TouchToWorldPoint(Input.GetTouch(0), Program.mainCam);
					Tap(position);
				}
			}
			if (touch.phase == TouchPhase.Ended)
			{
				beganRegistered = false;
			}
		}
		else
		{
			beganRegistered = false;
		}
	}

	protected void CheckJoyConInput()
	{
		if (Program.joyInput.hardAreaMoveStartX)
		{
			if (Program.joyInput.areaMoveDelta.x < 0f)
			{
				RightSwipe();
			}
			if (Program.joyInput.areaMoveDelta.x > 0f)
			{
				LeftSwipe();
			}
		}
	}

	protected virtual void OnInit()
	{
	}

	public static void ResetGeneralComponents()
	{
		_isGeneralInited = false;
		Model = null;
		_controller = null;
		_staticData = null;
		_viewModel = null;
	}

	public static void InitGeneralComponents(Model m, Controller c, ViewModel vm, StaticData sd, SoundSystem sound, Program program)
	{
		if (!_isGeneralInited)
		{
			Model = m;
			_controller = c;
			_staticData = sd;
			_viewModel = vm;
			Sound = sound;
			Program = program;
			_isGeneralInited = true;
		}
	}

	public virtual void Init()
	{
		if (!_isInstanceInited)
		{
			OnInit();
			_isInstanceInited = true;
		}
	}

	protected virtual void OnACEnabled()
	{
	}

	protected virtual void OnACDisabled()
	{
	}

	public virtual void Enable()
	{
		if (IsInited && !_enabled)
		{
			_enabled = true;
			OnACEnabled();
		}
	}

	public virtual void Disable()
	{
		if (IsInited && _enabled)
		{
			_enabled = false;
			OnACDisabled();
		}
	}
}

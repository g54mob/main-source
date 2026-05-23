using System;
using System.Collections.Generic;
using UnityEngine;

public class DebugDrawer
{
	public delegate void FrameCallback(DebugDrawer dd);

	public delegate void FrameCallback2(DebugDrawer dd, Rect spaceRect);

	private class CallbackInfo
	{
		public readonly bool world;

		public readonly Rect spaceRect;

		public readonly Rect screenRect;

		public readonly FrameCallback cb;

		public readonly FrameCallback2 cb2;

		public CallbackInfo(bool world_, Rect spaceRect_, Rect screenRect_, FrameCallback cb_, FrameCallback2 cb2_)
		{
			world = world_;
			spaceRect = spaceRect_;
			screenRect = screenRect_;
			cb = cb_;
			cb2 = cb2_;
		}
	}

	private static Material lineMaterial;

	public static readonly int screenWidth = 800;

	public static readonly int screenHeight = 450;

	public static readonly Vector3 screenSize = new Vector3(screenWidth, screenHeight);

	public static readonly Rect screenRect = new Rect(0f, 0f, screenWidth, screenHeight);

	private bool inBegin;

	private Camera worldCamera;

	private float screenToSpaceScale = 1f;

	private int lastRenderFrame = -1;

	private List<CallbackInfo> callbackInfos = new List<CallbackInfo>();

	private SortedDictionary<string, string> watch = new SortedDictionary<string, string>();

	private static DebugDrawer instance_;

	private static Rect nullRect = default(Rect);

	private string[] framerateDigitStrs = new string[10] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

	private Color framerateDigitsColor = Color.magenta;

	private Color framerateThresh240Color = Color.gray;

	private Color framerateThresh120Color = Color.gray;

	private Color framerateThresh90Color = Color.gray;

	private Color framerateThresh60Color = Color.green;

	private Color framerateThresh30Color = Color.gray;

	private Color framerateThresh00Color = Color.gray;

	private Color framerateLineColor = Color.magenta;

	private Color framerateBackColor = new Color(0f, 0f, 0f, 0.5f);

	private const byte kFirstLetter = 33;

	private const byte kLastLetter = 95;

	private static int[,,] letterCorners = new int[63, 7, 2]
	{
		{
			{ 1, 4 },
			{ 7, 7 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 3 },
			{ 1, 4 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 2 },
			{ 3, 5 },
			{ 0, 6 },
			{ 1, 7 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 2 },
			{ 2, 5 },
			{ 5, 3 },
			{ 3, 6 },
			{ 6, 8 },
			{ 1, 7 },
			{ 9, 9 }
		},
		{
			{ 0, 0 },
			{ 6, 2 },
			{ 8, 8 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 1 },
			{ 1, 6 },
			{ 6, 7 },
			{ 7, 0 },
			{ 7, 5 },
			{ 7, 8 },
			{ 9, 9 }
		},
		{
			{ 1, 4 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 1, 3 },
			{ 3, 7 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 1, 5 },
			{ 5, 7 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 8 },
			{ 2, 6 },
			{ 3, 5 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 3, 5 },
			{ 1, 7 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 4, 6 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 3, 5 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 7, 8 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 6, 2 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 2 },
			{ 2, 8 },
			{ 6, 8 },
			{ 0, 6 },
			{ 6, 2 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 1, 7 },
			{ 6, 8 },
			{ 0, 1 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 2 },
			{ 2, 5 },
			{ 5, 3 },
			{ 3, 6 },
			{ 6, 8 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 2 },
			{ 2, 8 },
			{ 8, 6 },
			{ 4, 5 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 3 },
			{ 3, 5 },
			{ 2, 8 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 2 },
			{ 0, 3 },
			{ 3, 5 },
			{ 8, 5 },
			{ 6, 8 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 2 },
			{ 0, 6 },
			{ 6, 8 },
			{ 8, 5 },
			{ 5, 3 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 2 },
			{ 2, 8 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 2 },
			{ 2, 8 },
			{ 8, 6 },
			{ 6, 0 },
			{ 3, 5 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 2 },
			{ 2, 8 },
			{ 8, 6 },
			{ 0, 3 },
			{ 3, 5 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 3, 1 },
			{ 6, 4 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 3, 1 },
			{ 6, 4 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 2, 3 },
			{ 3, 8 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 3, 4 },
			{ 6, 7 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 5 },
			{ 5, 6 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 2 },
			{ 2, 5 },
			{ 4, 5 },
			{ 4, 7 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 1, 5 },
			{ 5, 8 },
			{ 3, 6 },
			{ 3, 5 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 1, 5 },
			{ 5, 8 },
			{ 3, 6 },
			{ 3, 5 },
			{ 1, 3 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 2 },
			{ 2, 4 },
			{ 4, 8 },
			{ 8, 6 },
			{ 6, 0 },
			{ 3, 4 },
			{ 9, 9 }
		},
		{
			{ 0, 2 },
			{ 0, 6 },
			{ 6, 8 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 1 },
			{ 1, 5 },
			{ 5, 7 },
			{ 7, 6 },
			{ 6, 0 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 2 },
			{ 3, 4 },
			{ 6, 8 },
			{ 0, 6 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 2 },
			{ 3, 4 },
			{ 0, 6 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 2 },
			{ 0, 6 },
			{ 6, 8 },
			{ 8, 5 },
			{ 4, 5 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 6 },
			{ 3, 5 },
			{ 2, 8 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 2 },
			{ 1, 7 },
			{ 6, 8 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 2, 8 },
			{ 6, 8 },
			{ 3, 6 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 6 },
			{ 2, 3 },
			{ 3, 8 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 6 },
			{ 6, 8 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 6 },
			{ 0, 4 },
			{ 4, 2 },
			{ 2, 8 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 6 },
			{ 0, 8 },
			{ 2, 8 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 2 },
			{ 2, 8 },
			{ 6, 8 },
			{ 0, 6 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 6 },
			{ 0, 2 },
			{ 2, 5 },
			{ 3, 5 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 2 },
			{ 2, 8 },
			{ 6, 8 },
			{ 0, 6 },
			{ 4, 8 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 2 },
			{ 2, 3 },
			{ 3, 8 },
			{ 0, 6 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 2 },
			{ 0, 3 },
			{ 3, 5 },
			{ 5, 8 },
			{ 6, 8 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 2 },
			{ 1, 7 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 6 },
			{ 6, 8 },
			{ 2, 8 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 7 },
			{ 2, 7 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 6 },
			{ 6, 4 },
			{ 4, 8 },
			{ 8, 2 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 8 },
			{ 6, 2 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 4 },
			{ 4, 2 },
			{ 4, 7 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 2 },
			{ 2, 6 },
			{ 6, 8 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 0, 6 },
			{ 0, 1 },
			{ 6, 7 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 6, 8 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 2, 8 },
			{ 1, 2 },
			{ 7, 8 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 3, 1 },
			{ 1, 5 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		},
		{
			{ 6, 8 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 },
			{ 9, 9 }
		}
	};

	private static Vector3[] letterPoints = new Vector3[9]
	{
		new Vector3(0f, 1f),
		new Vector3(0.5f, 1f),
		new Vector3(1f, 1f),
		new Vector3(0f, 0.5f),
		new Vector3(0.5f, 0.5f),
		new Vector3(1f, 0.5f),
		new Vector3(0f, 0f),
		new Vector3(0.5f, 0f),
		new Vector3(1f, 0f)
	};

	public Vector3 cameraFacingNorm
	{
		get
		{
			return (!(worldCamera != null)) ? Vector3.forward : worldCamera.transform.forward;
		}
	}

	public static DebugDrawer instance
	{
		get
		{
			if (instance_ == null)
			{
				instance_ = new DebugDrawer();
				DebugManager.AddPreUpdateFuncs();
			}
			return instance_;
		}
	}

	private static bool enabled
	{
		get
		{
			return Debug.isDebugBuild;
		}
	}

	public static bool needsRender
	{
		get
		{
			return enabled && instance != null && (instance.watch.Count != 0 || instance.callbackInfos.Count != 0);
		}
	}

	private DebugDrawer()
	{
	}

	public static void Render(Camera worldCamera_, RenderTexture target = null)
	{
		if (enabled)
		{
			if (target != null)
			{
				RenderTexture active = RenderTexture.active;
				RenderTexture.active = target;
				instance._Render(worldCamera_);
				RenderTexture.active = active;
			}
			else
			{
				instance._Render(worldCamera_);
			}
		}
	}

	public static void DrawFrameRate(RingBuffer<int> fps, RenderTexture target = null)
	{
		if (target != null)
		{
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = target;
			instance._DrawFrameRate(fps);
			RenderTexture.active = active;
		}
		else
		{
			instance._DrawFrameRate(fps);
		}
	}

	private void _DrawFrameRate(RingBuffer<int> fps)
	{
		BeginScreen(screenRect, screenRect);
		float num = 240f;
		float num2 = 20f;
		float num3 = 8f;
		int num4 = fps.Get(0);
		int num5 = 1;
		for (int i = 0; i < 3; i++)
		{
			int num6 = num4 / num5 % 10;
			num5 *= 10;
			if (i > 0 && num6 == 0)
			{
				break;
			}
			DrawText(framerateDigitsColor, framerateDigitStrs[num6], new Vector3(screenRect.width - num2 - (float)i * (num3 + 2f), screenRect.height - num2 - num3 * 0.5f), num3, true);
		}
		float num7 = fps.maxLength;
		float num8 = 30f;
		float num9 = screenRect.width - num7 - num2 - (num3 + 2f) * 3f;
		float num10 = num9 + num7;
		float num11 = screenRect.height - num2;
		float num12 = num11 - num8;
		float y = Mathf.Lerp(num12, num11, 240f / num);
		float y2 = Mathf.Lerp(num12, num11, 120f / num);
		float y3 = Mathf.Lerp(num12, num11, 90f / num);
		float y4 = Mathf.Lerp(num12, num11, 60f / num);
		float y5 = Mathf.Lerp(num12, num11, 30f / num);
		float y6 = Mathf.Lerp(num12, num11, 0f / num);
		GL.Begin(7);
		GL.Color(framerateBackColor);
		GL.Vertex3(num9, num12, 0f);
		GL.Vertex3(num10, num12, 0f);
		GL.Vertex3(num10, num11, 0f);
		GL.Vertex3(num9, num11, 0f);
		GL.End();
		GL.Begin(1);
		GL.Color(framerateThresh240Color);
		GL.Vertex(new Vector2(num9, y));
		GL.Vertex(new Vector2(num10, y));
		GL.Color(framerateThresh120Color);
		GL.Vertex(new Vector2(num9, y2));
		GL.Vertex(new Vector2(num10, y2));
		GL.Color(framerateThresh90Color);
		GL.Vertex(new Vector2(num9, y3));
		GL.Vertex(new Vector2(num10, y3));
		GL.Color(framerateThresh60Color);
		GL.Vertex(new Vector2(num9, y4));
		GL.Vertex(new Vector2(num10, y4));
		GL.Color(framerateThresh30Color);
		GL.Vertex(new Vector2(num9, y5));
		GL.Vertex(new Vector2(num10, y5));
		GL.Color(framerateThresh00Color);
		GL.Vertex(new Vector2(num9, y6));
		GL.Vertex(new Vector2(num10, y6));
		GL.Color(framerateLineColor);
		Vector3 vector = Vector3.zero;
		for (int j = 0; j < fps.maxLength; j++)
		{
			int num13 = fps.Get(j);
			float t = (float)j / (float)fps.maxLength;
			Vector3 v = vector;
			vector = new Vector2(Mathf.Lerp(num10, num9, t), Mathf.Lerp(num12, num11, (float)num13 / num));
			if (j > 0)
			{
				GL.Vertex(v);
				GL.Vertex(vector);
			}
		}
		GL.End();
		End();
	}

	private void _Render(Camera worldCamera_)
	{
		if (!enabled)
		{
			return;
		}
		worldCamera = worldCamera_;
		int num = 0;
		foreach (CallbackInfo callbackInfo in callbackInfos)
		{
			if (callbackInfo.world)
			{
				num++;
				continue;
			}
			BeginScreen(callbackInfo.spaceRect, callbackInfo.screenRect);
			if (callbackInfo.cb != null)
			{
				callbackInfo.cb(this);
			}
			else if (callbackInfo.cb2 != null)
			{
				callbackInfo.cb2(this, callbackInfo.spaceRect);
			}
			End();
		}
		if (num != 0)
		{
			BeginWorld();
			foreach (CallbackInfo callbackInfo2 in callbackInfos)
			{
				if (callbackInfo2.world)
				{
					callbackInfo2.cb(this);
				}
			}
			End();
		}
		callbackInfos.Clear();
		if (watch.Count != 0)
		{
			string text = string.Empty;
			foreach (KeyValuePair<string, string> item in watch)
			{
				text = item.Key + " = " + item.Value + "\n" + text;
			}
			BeginScreen(screenRect, screenRect);
			DrawText(Color.magenta, text, new Vector3(10f, 10f), 8f, true);
			End();
		}
		lastRenderFrame = Time.frameCount;
	}

	public static void FlushIfNecessary()
	{
		if (enabled)
		{
			instance._FlushIfNecessary();
		}
	}

	public void _FlushIfNecessary()
	{
		if (enabled && lastRenderFrame < Time.frameCount - 1)
		{
			callbackInfos.Clear();
		}
	}

	public static void Screen(Rect spaceRect, Rect screenRect, FrameCallback cb)
	{
		if (enabled)
		{
			instance.callbackInfos.Add(new CallbackInfo(false, spaceRect, screenRect, cb, null));
		}
	}

	public static void Screen(Rect spaceRect, Rect screenRect, FrameCallback2 cb2)
	{
		if (enabled)
		{
			instance.callbackInfos.Add(new CallbackInfo(false, spaceRect, screenRect, null, cb2));
		}
	}

	public static void Screen(FrameCallback cb)
	{
		if (enabled)
		{
			instance.callbackInfos.Add(new CallbackInfo(false, screenRect, screenRect, cb, null));
		}
	}

	public static void World(FrameCallback cb)
	{
		if (enabled)
		{
			instance.callbackInfos.Add(new CallbackInfo(true, nullRect, nullRect, cb, null));
		}
	}

	public static void Watch(string name, object value)
	{
		if (enabled)
		{
			instance.AddWatch(name, value);
		}
	}

	private void AddWatch(string name, object value)
	{
		if (watch.ContainsKey(name))
		{
			watch[name] = value.ToString();
		}
		else
		{
			watch.Add(name, value.ToString());
		}
	}

	public void BeginScreen(Rect spaceRect, Rect screenRect)
	{
		Begin();
		Matrix4x4 matrix4x = Matrix4x4.Scale(new Vector3(1f / spaceRect.width, 1f / spaceRect.height, 1f)) * Matrix4x4.TRS(new Vector3(0f - spaceRect.x, 0f - spaceRect.y, 0f), Quaternion.identity, Vector3.one);
		Matrix4x4 matrix4x2 = Matrix4x4.TRS(new Vector3(screenRect.x, screenRect.y, 0f), Quaternion.identity, Vector3.one) * Matrix4x4.Scale(new Vector3(screenRect.width, screenRect.height, 1f));
		Matrix4x4 matrix4x3 = Matrix4x4.Ortho(0f, screenWidth, 0f, screenHeight, -1f, 100f);
		screenToSpaceScale = 1f / (1f / (spaceRect.xMax - spaceRect.xMin) * (screenRect.xMax - screenRect.xMin));
		GL.modelview = matrix4x3 * matrix4x2 * matrix4x;
		GL.LoadProjectionMatrix(Matrix4x4.identity);
	}

	public float ToSpace(float lengthInScreen)
	{
		return lengthInScreen * screenToSpaceScale;
	}

	private void BeginWorld()
	{
		Begin();
		if (worldCamera != null)
		{
			GL.modelview = worldCamera.worldToCameraMatrix;
			GL.LoadProjectionMatrix(worldCamera.projectionMatrix);
		}
		else
		{
			GL.modelview = Matrix4x4.identity;
			GL.LoadProjectionMatrix(Matrix4x4.identity);
		}
	}

	private void Begin()
	{
		if (lineMaterial == null)
		{
			Shader shader = Resources.Load<Shader>("Surfacing/DebugLine");
			lineMaterial = new Material(shader);
			lineMaterial.hideFlags = HideFlags.HideAndDontSave;
		}
		if (!inBegin)
		{
			GL.PushMatrix();
			GL.LoadIdentity();
			lineMaterial.SetPass(0);
		}
		inBegin = true;
	}

	private void End()
	{
		if (inBegin)
		{
			GL.PopMatrix();
		}
		inBegin = false;
	}

	public void FillRect(Color color, Rect rect)
	{
		GL.Begin(7);
		GL.Color(color);
		GL.Vertex3(rect.xMin, rect.yMin, 0f);
		GL.Vertex3(rect.xMax, rect.yMin, 0f);
		GL.Vertex3(rect.xMax, rect.yMax, 0f);
		GL.Vertex3(rect.xMin, rect.yMax, 0f);
		GL.End();
	}

	public void DrawCircle(Color color, Vector3 center, float radius, float angle0 = 0f, float angle1 = (float)Math.PI * 2f)
	{
		DrawCircle(color, center, radius, Vector3.forward, angle0, angle1);
	}

	public void DrawCircle(Color color, Vector3 center, float radius, Vector3 norm, float angle0 = 0f, float angle1 = (float)Math.PI * 2f)
	{
		Matrix4x4 matrix4x = Util.MakeDirMatrix(norm, center);
		GL.Begin(1);
		GL.Color(color);
		int num = 30;
		Vector3 point = new Vector3(0f, 0f, 0f);
		Vector3 point2 = new Vector3(0f, 0f, 0f);
		for (int i = 0; i <= num; i++)
		{
			float t = (float)i / (float)num;
			float f = Mathf.Lerp(angle0, angle1, t);
			point2.x = point.x;
			point2.y = point.y;
			point.x = radius * Mathf.Cos(f);
			point.y = radius * Mathf.Sin(f);
			if (i != 0)
			{
				GL.Vertex(matrix4x.MultiplyPoint(point));
				GL.Vertex(matrix4x.MultiplyPoint(point2));
			}
		}
		GL.End();
	}

	public void DrawCircle(Color color, Matrix4x4 mat, int numPoints)
	{
		GL.Begin(1);
		GL.Color(color);
		Vector3 vector = new Vector3(0f, 0f, 0f);
		Vector3 vector2 = new Vector3(0f, 0f, 0f);
		for (int i = 0; i <= numPoints; i++)
		{
			float num = (float)i / (float)numPoints;
			float f = num * 2f * (float)Math.PI;
			vector2 = vector;
			vector = mat.MultiplyPoint(new Vector3(Mathf.Cos(f), Mathf.Sin(f), 0f));
			if (i != 0)
			{
				GL.Vertex(vector);
				GL.Vertex(vector2);
			}
		}
		GL.End();
	}

	public void DrawLine(Color color, Vector3 p0, Vector3 p1)
	{
		GL.Begin(1);
		GL.Color(color);
		GL.Vertex(p0);
		GL.Vertex(p1);
		GL.End();
	}

	public void DrawArrow(Color color, Vector3 start, Vector3 end, float arrowSize = 0.25f)
	{
		Matrix4x4 matrix4x = Util.MakeDirMatrix((end - start).normalized, end);
		GL.Begin(1);
		GL.Color(color);
		GL.Vertex(start);
		GL.Vertex(end);
		GL.Vertex(end);
		GL.Vertex(matrix4x.MultiplyPoint(new Vector3(0f, arrowSize * 0.5f, 0f - arrowSize)));
		GL.Vertex(end);
		GL.Vertex(matrix4x.MultiplyPoint(new Vector3(0f, (0f - arrowSize) * 0.5f, 0f - arrowSize)));
		GL.End();
	}

	public void DrawAxis(Color color, Matrix4x4 m, float size = 0.25f)
	{
		Vector3 v = m.GetColumn(3);
		GL.Begin(1);
		GL.Color(Color.Lerp(color, Color.red, 0.5f));
		GL.Vertex(v);
		GL.Vertex(m.MultiplyPoint(size * Vector3.right));
		GL.Color(Color.Lerp(color, Color.green, 0.5f));
		GL.Vertex(v);
		GL.Vertex(m.MultiplyPoint(size * Vector3.up));
		GL.Color(Color.Lerp(color, Color.blue, 0.5f));
		GL.Vertex(v);
		GL.Vertex(m.MultiplyPoint(size * Vector3.forward));
		GL.End();
	}

	public void DrawText(Color color, string text, Vector3 center, float charHeight, bool alignLeft = false)
	{
		DrawText(color, text, center, Vector3.forward, charHeight, alignLeft);
	}

	public Vector2 GetTextSize(string text, float charHeight)
	{
		float num = charHeight * 0.8f;
		float num2 = charHeight * 0.3f;
		return new Vector2((float)text.Length * num + (float)Mathf.Max(0, text.Length - 1) * num2, charHeight);
	}

	public void DrawText(Color color, string text, Vector3 center, Vector3 norm, float charHeight, bool alignLeft = false)
	{
		text = text.ToUpper();
		float num = charHeight * 0.8f;
		float num2 = charHeight * 0.3f;
		Matrix4x4 m = Util.MakeDirMatrix(norm) * Matrix4x4.Scale(new Vector3(num, charHeight, 1f));
		Vector3 vector = m.GetColumn(0).normalized;
		Vector3 vector2 = center;
		if (!alignLeft)
		{
			vector2 -= vector * ((num + num2) * (float)text.Length / 2f);
		}
		vector2 -= 0.5f * m.GetY();
		GL.Begin(1);
		GL.Color(color);
		int num3 = 0;
		string text2 = text;
		foreach (char c in text2)
		{
			byte b = (byte)c;
			switch (b)
			{
			case 32:
				num3++;
				continue;
			case 10:
				vector2 += (charHeight + 2f) / charHeight * m.GetY();
				num3 = 0;
				continue;
			}
			b = Util.MinMax(b, (byte)33, (byte)95);
			int num4 = b - 33;
			for (int j = 0; j < letterCorners.GetLength(1) && letterCorners[num4, j, 0] != 9; j++)
			{
				m.SetColumn(3, (vector2 + vector * num3 * (num + num2)).ToVector4(1f));
				Vector3 v = m.MultiplyPoint(letterPoints[letterCorners[num4, j, 0]]);
				Vector3 v2 = m.MultiplyPoint(letterPoints[letterCorners[num4, j, 1]]);
				GL.Vertex(v);
				GL.Vertex(v2);
			}
			num3++;
		}
		GL.End();
	}

	public void DrawAnimationCurve(Color color, AnimationCurve animationCurve, int numPoints = 100)
	{
		if (animationCurve.length < 2)
		{
			return;
		}
		GL.Begin(1);
		GL.Color(color);
		Vector3 zero = Vector3.zero;
		Vector3 zero2 = Vector3.zero;
		for (int i = 0; i <= numPoints; i++)
		{
			float t = (float)i / (float)numPoints;
			float num = Mathf.Lerp(animationCurve.keys[0].time, animationCurve.keys[animationCurve.length - 1].time, t);
			zero = zero2;
			zero2.x = num;
			zero2.y = animationCurve.Evaluate(num);
			if (i != 0)
			{
				GL.Vertex(zero);
				GL.Vertex(zero2);
			}
		}
		GL.End();
		for (int j = 0; j < animationCurve.length; j++)
		{
			Keyframe keyframe = animationCurve.keys[j];
			DrawCircle(color, new Vector3(keyframe.time, keyframe.value), screenToSpaceScale * 3f);
		}
	}

	public void DrawHistory(Color color, Util.History history)
	{
		if (history.values.Count < 2)
		{
			return;
		}
		GL.Begin(1);
		GL.Color(color);
		Vector3 zero = Vector3.zero;
		Vector3 zero2 = Vector3.zero;
		for (int i = 0; i < history.values.Count; i++)
		{
			zero = zero2;
			zero2.x = i;
			zero2.y = history.values[i];
			if (i != 0)
			{
				GL.Vertex(zero);
				GL.Vertex(zero2);
			}
		}
		GL.End();
	}

	public void DrawBounds(Color color, Bounds bounds)
	{
		DrawBounds(color, bounds, Matrix4x4.identity);
	}

	public void DrawBounds(Color color, Bounds bounds, Matrix4x4 matrix)
	{
		Vector3 v = matrix.MultiplyPoint(new Vector3(bounds.min.x, bounds.min.y, bounds.min.z));
		Vector3 v2 = matrix.MultiplyPoint(new Vector3(bounds.min.x, bounds.min.y, bounds.max.z));
		Vector3 v3 = matrix.MultiplyPoint(new Vector3(bounds.max.x, bounds.min.y, bounds.max.z));
		Vector3 v4 = matrix.MultiplyPoint(new Vector3(bounds.max.x, bounds.min.y, bounds.min.z));
		Vector3 v5 = matrix.MultiplyPoint(new Vector3(bounds.min.x, bounds.max.y, bounds.min.z));
		Vector3 v6 = matrix.MultiplyPoint(new Vector3(bounds.min.x, bounds.max.y, bounds.max.z));
		Vector3 v7 = matrix.MultiplyPoint(new Vector3(bounds.max.x, bounds.max.y, bounds.max.z));
		Vector3 v8 = matrix.MultiplyPoint(new Vector3(bounds.max.x, bounds.max.y, bounds.min.z));
		GL.Begin(1);
		GL.Color(color);
		GL.Vertex(v);
		GL.Vertex(v2);
		GL.Vertex(v2);
		GL.Vertex(v3);
		GL.Vertex(v3);
		GL.Vertex(v4);
		GL.Vertex(v4);
		GL.Vertex(v);
		GL.Vertex(v5);
		GL.Vertex(v6);
		GL.Vertex(v6);
		GL.Vertex(v7);
		GL.Vertex(v7);
		GL.Vertex(v8);
		GL.Vertex(v8);
		GL.Vertex(v5);
		GL.Vertex(v);
		GL.Vertex(v5);
		GL.Vertex(v2);
		GL.Vertex(v6);
		GL.Vertex(v3);
		GL.Vertex(v7);
		GL.Vertex(v4);
		GL.Vertex(v8);
		GL.End();
	}

	public void DrawSphere(Color color, Matrix4x4 m)
	{
		DrawCircle(color, m, 16);
		DrawCircle(color, Util.MakeComponentMatrix(m.GetZ(), m.GetY(), -m.GetX(), m.GetT()), 16);
		DrawCircle(color, Util.MakeComponentMatrix(m.GetZ(), m.GetX(), m.GetY(), m.GetT()), 16);
	}
}

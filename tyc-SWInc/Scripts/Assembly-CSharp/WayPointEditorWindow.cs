using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WayPointEditorWindow : MonoBehaviour
{
	public class WayPoint
	{
		public Vector3 Position;

		public Quaternion Rotation;

		public float FOV;

		public float Time;
	}

	public GUIListView WayPointList;

	[NonSerialized]
	public int CurrentWayPoint;

	[NonSerialized]
	public float CurrentWayPointPos;

	public bool IsPlaying;

	public bool FreezeFrame;

	public GUIWindow Window;

	public static WayPointEditorWindow Instance;

	public void Bake()
	{
		ClearBakingState();
		Dictionary<WayPoint, float> dictionary = new Dictionary<WayPoint, float>();
		float num = 0f;
		foreach (WayPoint item in WayPointList.Items.OfType<WayPoint>())
		{
			dictionary[item] = num;
			num += item.Time;
		}
		Camera mainCam = CameraScript.Instance.mainCam;
		mainCam.transform.SetParent(null);
		ListenerScript audioListener = GetAudioListener();
		audioListener.transform.SetParent(mainCam.transform);
		audioListener.transform.localPosition = Vector3.zero;
		audioListener.transform.localRotation = Quaternion.identity;
		audioListener.enabled = false;
		Animation animation = mainCam.gameObject.AddComponent<Animation>();
		AnimationClip animationClip = new AnimationClip
		{
			legacy = true,
			wrapMode = WrapMode.Loop
		};
		Dictionary<string, Type> dictionary2 = new Dictionary<string, Type>
		{
			{
				"localPosition.x",
				typeof(Transform)
			},
			{
				"localPosition.y",
				typeof(Transform)
			},
			{
				"localPosition.z",
				typeof(Transform)
			},
			{
				"localRotation.x",
				typeof(Transform)
			},
			{
				"localRotation.y",
				typeof(Transform)
			},
			{
				"localRotation.z",
				typeof(Transform)
			},
			{
				"localRotation.w",
				typeof(Transform)
			},
			{
				"field of view",
				typeof(Camera)
			}
		};
		foreach (KeyValuePair<string, Func<WayPoint, float>> curve in new Dictionary<string, Func<WayPoint, float>>
		{
			{
				"localPosition.x",
				(WayPoint x) => x.Position.x
			},
			{
				"localPosition.y",
				(WayPoint x) => x.Position.y
			},
			{
				"localPosition.z",
				(WayPoint x) => x.Position.z
			},
			{
				"localRotation.x",
				(WayPoint x) => x.Rotation.x
			},
			{
				"localRotation.y",
				(WayPoint x) => x.Rotation.y
			},
			{
				"localRotation.z",
				(WayPoint x) => x.Rotation.z
			},
			{
				"localRotation.w",
				(WayPoint x) => x.Rotation.w
			},
			{
				"field of view",
				(WayPoint x) => x.FOV
			}
		})
		{
			Type type = dictionary2[curve.Key];
			AnimationCurve animationCurve = new AnimationCurve(dictionary.Select((KeyValuePair<WayPoint, float> x) => new Keyframe(x.Value, curve.Value(x.Key))).ToArray());
			for (int num2 = 0; num2 < dictionary.Count; num2++)
			{
				animationCurve.SmoothTangents(num2, 1f);
			}
			animationClip.SetCurve("", type, curve.Key, animationCurve);
		}
		animation.AddClip(animationClip, "BakeAnim");
		animation.Play("BakeAnim");
	}

	public void ToggleBake()
	{
		Animation component = CameraScript.Instance.mainCam.gameObject.GetComponent<Animation>();
		if (component != null)
		{
			if (component.isPlaying)
			{
				component.Stop();
			}
			else
			{
				component.Play("BakeAnim");
			}
		}
	}

	private ListenerScript GetAudioListener()
	{
		return CameraScript.Instance.GetComponentInChildren<ListenerScript>(true) ?? CameraScript.Instance.mainCam.GetComponentInChildren<ListenerScript>(true);
	}

	public void ClearBake()
	{
		ClearBakingState();
		ResetPos();
	}

	private void ClearBakingState()
	{
		ListenerScript audioListener = GetAudioListener();
		audioListener.transform.SetParent(CameraScript.Instance.transform);
		audioListener.enabled = true;
		UnityEngine.Object.DestroyImmediate(CameraScript.Instance.mainCam.gameObject.GetComponent<Animation>());
	}

	private void ResetPos()
	{
		Camera mainCam = CameraScript.Instance.mainCam;
		mainCam.transform.SetParent(CameraScript.Instance.transform);
		mainCam.transform.localPosition = Vector3.zero;
		mainCam.transform.localScale = Vector3.one;
		mainCam.transform.localRotation = Quaternion.identity;
	}

	private void LateUpdate()
	{
		if (FreezeFrame)
		{
			if (CurrentWayPoint < 0 || CurrentWayPoint > WayPointList.Items.Count - 1)
			{
				FreezeFrame = false;
				return;
			}
			Camera mainCam = CameraScript.Instance.mainCam;
			WayPoint wayPoint = (WayPoint)WayPointList.Items[CurrentWayPoint];
			mainCam.transform.position = wayPoint.Position;
			mainCam.transform.rotation = wayPoint.Rotation;
			mainCam.fieldOfView = wayPoint.FOV;
		}
		else
		{
			if (IsPlaying)
			{
				if (CurrentWayPoint < 0 || CurrentWayPoint > WayPointList.Items.Count - 1)
				{
					IsPlaying = false;
					return;
				}
				Camera mainCam2 = CameraScript.Instance.mainCam;
				WayPoint wayPoint2 = (WayPoint)WayPointList.Items[CurrentWayPoint];
				if (CurrentWayPoint == WayPointList.Items.Count - 1)
				{
					mainCam2.transform.position = wayPoint2.Position;
					mainCam2.transform.rotation = wayPoint2.Rotation;
					mainCam2.fieldOfView = wayPoint2.FOV;
				}
				else
				{
					CurrentWayPointPos += Time.deltaTime / wayPoint2.Time;
					if (CurrentWayPointPos >= 1f)
					{
						CurrentWayPoint++;
						CurrentWayPointPos %= 1f;
					}
					wayPoint2 = (WayPoint)WayPointList.Items[CurrentWayPoint];
					if (CurrentWayPoint == WayPointList.Items.Count - 1)
					{
						mainCam2.transform.position = wayPoint2.Position;
						mainCam2.transform.rotation = wayPoint2.Rotation;
						mainCam2.fieldOfView = wayPoint2.FOV;
					}
					else
					{
						WayPoint wayPoint3 = (WayPoint)WayPointList.Items[CurrentWayPoint + 1];
						mainCam2.transform.position = Vector3.Lerp(wayPoint2.Position, wayPoint3.Position, CurrentWayPointPos);
						mainCam2.transform.rotation = Quaternion.Lerp(wayPoint2.Rotation, wayPoint3.Rotation, CurrentWayPointPos);
						mainCam2.fieldOfView = Mathf.Lerp(wayPoint2.FOV, wayPoint3.FOV, CurrentWayPointPos);
					}
				}
			}
			if (IsPlaying)
			{
				if (Input.GetKeyDown(KeyCode.Backspace))
				{
					IsPlaying = false;
				}
			}
			else if (Input.GetKeyDown(KeyCode.Backspace))
			{
				Play();
			}
		}
		if (Input.GetKeyDown(KeyCode.KeypadMultiply) && WayPointList.Selected.Count > 0)
		{
			int num = WayPointList.Selected.First();
			if (CurrentWayPoint != num)
			{
				FreezeFrame = true;
				CurrentWayPoint = num;
			}
			else
			{
				FreezeFrame = !FreezeFrame;
			}
		}
		if (Input.GetKeyDown(KeyCode.KeypadPlus))
		{
			int num2 = WayPointList.Selected.First();
			if (num2 < WayPointList.Items.Count - 1)
			{
				object value = WayPointList.Items[num2];
				WayPointList.Items.RemoveAt(num2);
				WayPointList.Items.Insert(num2 + 1, value);
			}
		}
		if (Input.GetKeyDown(KeyCode.KeypadPlus))
		{
			int num3 = WayPointList.Selected.First();
			if (num3 > 0)
			{
				object value2 = WayPointList.Items[num3];
				WayPointList.Items.RemoveAt(num3);
				WayPointList.Items.Insert(num3 - 1, value2);
			}
		}
		if (Input.GetKeyDown(KeyCode.Return))
		{
			CapturePos(false);
		}
		if (Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			CapturePos(true);
		}
	}

	public void Play()
	{
		if (WayPointList.Items.Count > 0)
		{
			CurrentWayPoint = 0;
			CurrentWayPointPos = 0f;
			IsPlaying = true;
		}
	}

	private void Awake()
	{
		Instance = this;
	}

	private void OnDestroy()
	{
		Instance = null;
	}

	public void CapturePos(bool replace)
	{
		Vector3 position = CameraScript.Instance.mainCam.transform.position;
		Quaternion rotation = CameraScript.Instance.mainCam.transform.rotation;
		float fieldOfView = CameraScript.Instance.mainCam.fieldOfView;
		WayPoint value = new WayPoint
		{
			Position = position,
			Rotation = rotation,
			FOV = fieldOfView,
			Time = 1f
		};
		if (replace && WayPointList.Items.Count > 0)
		{
			WayPointList.Items.RemoveAt(CurrentWayPoint);
			WayPointList.Items.Insert(CurrentWayPoint, value);
		}
		else
		{
			WayPointList.Items.Add(value);
		}
	}
}

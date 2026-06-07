using UnityEngine;

namespace UltimateReplay
{
	public class ReplayControls : MonoBehaviour
	{
		private const float playPauseWidth = 24f;

		private const float playPauseHeight = 20f;

		private const float stateButtonWidth = 48f;

		private const float stateButtonHeight = 18f;

		private const float lookMultiplier = 300f;

		private static readonly Color normal = new Color(0.6f, 0.6f, 0.6f, 0.8f);

		private static readonly Color highlight = Color.white;

		private Camera freeCam;

		private Vector3 startPosition;

		private Quaternion startRotation;

		private Vector2 camRotation = Vector2.zero;

		private bool showSettings;

		private bool reversePlay;

		private Texture2D playTexture;

		private Texture2D pauseTexture;

		private Texture2D settingsTexture;

		private Texture2D whitePixel;

		private Texture2D recordTexture;

		private Texture2D playbackTexture;

		public bool allowPlaybackFreeCam = true;

		public float flySpeed = 8f;

		public float lookSpeed = 0.6f;

		public KeyCode liveModeShortcut = KeyCode.L;

		public KeyCode recordModeShortcut = KeyCode.R;

		public KeyCode playModeShortcut = KeyCode.P;

		public void Awake()
		{
			startPosition = base.transform.position;
			startRotation = base.transform.rotation;
			ReplayManager.ForceAwake();
			whitePixel = new Texture2D(1, 1);
			whitePixel.SetPixel(0, 0, Color.white);
			whitePixel.Apply();
			if (allowPlaybackFreeCam)
			{
				freeCam = GetComponent<Camera>();
				if (freeCam == null)
				{
					freeCam = base.gameObject.AddComponent<Camera>();
				}
				freeCam.enabled = false;
			}
		}

		public void Start()
		{
			playTexture = Resources.Load<Texture2D>("PlayIcon");
			pauseTexture = Resources.Load<Texture2D>("PauseIcon");
			settingsTexture = Resources.Load<Texture2D>("SettingsIcon");
			recordTexture = Resources.Load<Texture2D>("RecordIcon");
			playbackTexture = Resources.Load<Texture2D>("PlaybackIcon");
		}

		public void Update()
		{
			if (!allowPlaybackFreeCam || freeCam == null || !ReplayManager.IsReplaying)
			{
				return;
			}
			float num = (Input.GetKey(KeyCode.W) ? 1 : (Input.GetKey(KeyCode.S) ? (-1) : 0));
			float num2 = (Input.GetKey(KeyCode.A) ? (-1) : (Input.GetKey(KeyCode.D) ? 1 : 0));
			base.transform.Translate(Vector3.forward * flySpeed * num * Time.deltaTime);
			base.transform.Translate(Vector3.right * flySpeed * num2 * Time.deltaTime);
			if (Input.GetMouseButtonDown(1))
			{
				camRotation.y = base.transform.localRotation.eulerAngles.y;
				camRotation.x = base.transform.localRotation.eulerAngles.x;
				if (camRotation.y > 360f)
				{
					camRotation.y = 0f;
				}
			}
			if (Input.GetMouseButton(1))
			{
				float axis = Input.GetAxis("Mouse X");
				float num3 = 0f - Input.GetAxis("Mouse Y");
				camRotation.y += axis * lookSpeed * 300f * Time.deltaTime;
				camRotation.x += num3 * lookSpeed * 300f * Time.deltaTime;
				base.transform.rotation = Quaternion.Euler(camRotation.x, camRotation.y, 0f);
			}
		}

		public void OnGUI()
		{
			GUIStyle gUIStyle = new GUIStyle(GUI.skin.label);
			gUIStyle.fontStyle = FontStyle.Bold;
			GUILayout.BeginArea(new Rect(10f, 10f, Screen.width - 20, Screen.height - 20));
			GUILayout.BeginHorizontal();
			GUIStyle gUIStyle2 = new GUIStyle(GUI.skin.button);
			gUIStyle2.padding = new RectOffset(3, 3, 3, 3);
			gUIStyle2.margin = new RectOffset(-1, -1, 0, 0);
			GUI.color = ((!ReplayManager.IsRecording && !ReplayManager.IsReplaying) ? highlight : normal);
			if (GUILayout.Button(new GUIContent("Live", "Live mode"), gUIStyle2, GUILayout.Width(48f), GUILayout.Height(18f)) || IsReplayKeyPressed(liveModeShortcut))
			{
				ExitPlaybackFreeCam();
				ReplayGoLive();
			}
			GUI.color = (ReplayManager.IsRecording ? highlight : normal);
			if (GUILayout.Button(new GUIContent("Rec", recordTexture, "Begin recording"), gUIStyle2, GUILayout.Width(48f), GUILayout.Height(18f)) || IsReplayKeyPressed(recordModeShortcut))
			{
				ExitPlaybackFreeCam();
				ReplayManager.BeginRecording(cleanRecording: false);
			}
			GUI.color = (ReplayManager.IsReplaying ? highlight : normal);
			if (GUILayout.Button(new GUIContent("Play", playbackTexture, "Begin playback"), gUIStyle2, GUILayout.Width(48f), GUILayout.Height(18f)) || IsReplayKeyPressed(playModeShortcut))
			{
				if (allowPlaybackFreeCam)
				{
					EnterPlaybackFreeCam();
				}
				ReplayManager.BeginPlayback();
			}
			GUI.color = highlight;
			GUILayout.FlexibleSpace();
			if (ReplayManager.IsRecording)
			{
				string correctedTimeValueString = ReplayTime.GetCorrectedTimeValueString(ReplayManager.Target.Duration);
				GUILayout.Label($"Recording: {correctedTimeValueString}", gUIStyle);
				DrawGUILine(new Vector2(50f, 50f), new Vector2(80f, 50f));
				DrawGUILine(new Vector2(50f, 50f), new Vector2(50f, 80f));
				DrawGUILine(new Vector2(Screen.width - 80, 50f), new Vector2(Screen.width - 50, 50f));
				DrawGUILine(new Vector2(Screen.width - 50, 50f), new Vector2(Screen.width - 50, 80f));
				DrawGUILine(new Vector2(50f, Screen.height - 50), new Vector2(80f, Screen.height - 50));
				DrawGUILine(new Vector2(50f, Screen.height - 50), new Vector2(50f, Screen.height - 80));
				DrawGUILine(new Vector2(Screen.width - 80, Screen.height - 50), new Vector2(Screen.width - 50, Screen.height - 50));
				DrawGUILine(new Vector2(Screen.width - 50, Screen.height - 50), new Vector2(Screen.width - 50, Screen.height - 80));
			}
			if (ReplayManager.IsReplaying && allowPlaybackFreeCam && freeCam != null)
			{
				GUILayout.BeginVertical();
				GUILayout.Label("Free Cam Enabled", gUIStyle);
				GUI.color = new Color(0.3f, 0.3f, 0.3f);
				GUIStyle gUIStyle3 = new GUIStyle(GUI.skin.label);
				gUIStyle3.padding = new RectOffset(0, 0, -2, -2);
				gUIStyle3.fontSize = 10;
				gUIStyle3.alignment = TextAnchor.MiddleRight;
				GUILayout.Label("Free Move: WASD", gUIStyle3);
				GUILayout.Label("Free Look: RMB", gUIStyle3);
				GUI.color = Color.white;
				GUILayout.EndVertical();
			}
			GUILayout.EndHorizontal();
			GUILayout.FlexibleSpace();
			if (ReplayManager.IsReplaying)
			{
				GUILayout.BeginHorizontal();
				if (ReplayManager.IsPaused)
				{
					if (GUILayout.Button(playTexture, GUILayout.Width(24f), GUILayout.Height(20f)))
					{
						ReplayTime.TimeScale = (reversePlay ? (-1f) : 1f);
						ReplayManager.BeginPlayback(fromStart: false);
					}
				}
				else if (GUILayout.Button(pauseTexture, GUILayout.Width(24f), GUILayout.Height(20f)))
				{
					ReplayManager.PausePlayback();
				}
				GUILayout.BeginVertical();
				GUILayout.Space(10f);
				float currentPlaybackTimeNormalized = ReplayManager.CurrentPlaybackTimeNormalized;
				float num = GUILayout.HorizontalSlider(currentPlaybackTimeNormalized, 0f, 1f, GUILayout.Height(20f));
				if (currentPlaybackTimeNormalized != num)
				{
					ReplayManager.SetPlaybackFrameNormalized(num);
				}
				GUILayout.EndVertical();
				if (GUILayout.Button(new GUIContent(settingsTexture, "Open playback settings"), GUILayout.Width(24f), GUILayout.Height(20f)))
				{
					showSettings = !showSettings;
				}
				if (showSettings)
				{
					Rect area = new Rect(Screen.width - 160, Screen.height - 100, 140f, 50f);
					DrawGUISettings(area);
				}
				string correctedTimeValueString2 = ReplayTime.GetCorrectedTimeValueString(ReplayManager.CurrentPlaybackTime);
				string correctedTimeValueString3 = ReplayTime.GetCorrectedTimeValueString(ReplayManager.Target.Duration);
				GUILayout.Label($"{correctedTimeValueString2} / {correctedTimeValueString3}", GUI.skin.button, GUILayout.Width(75f));
				GUILayout.EndHorizontal();
			}
			GUILayout.EndArea();
		}

		private void DrawGUISettings(Rect area)
		{
			GUILayout.BeginArea(area, GUI.skin.box);
			GUILayout.BeginHorizontal();
			GUILayout.Label("Speed:", GUILayout.Width(55f));
			ReplayTime.TimeScale = GUILayout.HorizontalSlider(ReplayTime.TimeScale, 0f, 2f);
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal();
			GUILayout.Label("Reverse:", GUILayout.Width(55f));
			bool flag = GUILayout.Toggle(reversePlay, string.Empty);
			if (flag != reversePlay)
			{
				reversePlay = flag;
				if (ReplayManager.IsReplaying)
				{
					ReplayTime.TimeScale = (reversePlay ? (-1f) : 1f);
					ReplayManager.BeginPlayback(fromStart: false);
				}
			}
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
		}

		private void ReplayGoLive()
		{
			if (ReplayManager.IsRecording)
			{
				ReplayManager.StopRecording();
			}
			if (ReplayManager.IsReplaying)
			{
				ReplayManager.StopPlayback();
			}
		}

		private void EnterPlaybackFreeCam()
		{
			if (freeCam == null)
			{
				return;
			}
			Camera camera = null;
			Camera[] array = Object.FindObjectsOfType<Camera>();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].enabled)
				{
					camera = array[i];
					break;
				}
			}
			if (camera != null)
			{
				base.transform.position = camera.transform.position;
				base.transform.rotation = camera.transform.rotation;
			}
			freeCam.enabled = true;
		}

		private void ExitPlaybackFreeCam()
		{
			if (!(freeCam == null))
			{
				freeCam.enabled = false;
				base.transform.position = startPosition;
				base.transform.rotation = startRotation;
			}
		}

		private bool IsReplayKeyPressed(KeyCode key)
		{
			return Input.GetKey(key);
		}

		private void DrawGUILine(Vector2 start, Vector2 end)
		{
			float num = 2f;
			Vector2 vector = end - start;
			float num2 = 57.29578f * Mathf.Atan(vector.y / vector.x);
			if (vector.x < 0f)
			{
				num2 += 180f;
			}
			int num3 = (int)Mathf.Ceil(num / 2f);
			GUIUtility.RotateAroundPivot(num2, start);
			GUI.DrawTexture(new Rect(start.x, start.y - (float)num3, vector.magnitude, num), whitePixel);
			GUIUtility.RotateAroundPivot(0f - num2, start);
		}
	}
}

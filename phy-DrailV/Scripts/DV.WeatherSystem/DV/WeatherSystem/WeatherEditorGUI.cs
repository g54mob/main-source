using System;
using System.Collections.Generic;
using DV.Utils;
using UnityEngine;
using imColorPicker;

namespace DV.WeatherSystem
{
	public class WeatherEditorGUI : MonoBehaviour
	{
		private class ColorSwatchWithLabel
		{
			private string label;

			private readonly Func<WeatherSnapshot> CurrentSnapshotGetter;

			private readonly Func<Weather24hPresetSO> CurrentPresetGetter;

			private readonly Func<WeatherSnapshot, Color> AssetColorGetter;

			private readonly Action<WeatherSnapshot, Color> AssetColorSetter;

			private IMColorPicker colorPicker;

			private readonly Func<IMColorPicker> ColorPickerGetter;

			private readonly Action<IMColorPicker, string> ColorPickerSetter;

			public Color Value
			{
				get
				{
					return AssetColorGetter(CurrentSnapshotGetter());
				}
				set
				{
					AssetColorSetter(CurrentSnapshotGetter(), value);
				}
			}

			public ColorSwatchWithLabel(string label, Func<WeatherSnapshot> currentSnapshotGetter, Func<Weather24hPresetSO> currentPresetGetter, Func<WeatherSnapshot, Color> assetColorGetter, Action<WeatherSnapshot, Color> assetColorSetter, Func<IMColorPicker> colorPickerGetter, Action<IMColorPicker, string> colorPickerSetter)
			{
				this.label = label;
				CurrentSnapshotGetter = currentSnapshotGetter;
				CurrentPresetGetter = currentPresetGetter;
				AssetColorGetter = assetColorGetter;
				AssetColorSetter = assetColorSetter;
				ColorPickerGetter = colorPickerGetter;
				ColorPickerSetter = colorPickerSetter;
			}

			public bool Draw()
			{
				bool flag = false;
				using (new GUILayout.HorizontalScope())
				{
					flag = GUILayout.Button(label, GUI.skin.label, GUILayout.Width(110f));
					Color value = Value;
					flag |= ColorSwatch(value);
				}
				if (flag)
				{
					Event current = Event.current;
					if (current.button == 0)
					{
						colorPicker = new IMColorPicker(Value);
						ColorPickerSetter(colorPicker, label);
					}
					else if (current.button == 1)
					{
						if (current.modifiers == (EventModifiers.Shift | EventModifiers.Control))
						{
							Color currentValue = Value;
							CurrentPresetGetter().snapshots.ForEach(delegate(WeatherSnapshot snap)
							{
								AssetColorSetter(snap, currentValue);
							});
						}
						else
						{
							clipboardColor = Value;
						}
					}
					else if (current.button == 2)
					{
						Value = clipboardColor;
					}
				}
				if (colorPicker != null && ColorPickerGetter() == colorPicker)
				{
					Value = colorPicker.Color;
				}
				return flag;
			}
		}

		private const int LABEL_WIDTH = 110;

		private const int COLOR_SWATCH_WIDTH = 80;

		private const int MAIN_UI_WIDTH = 380;

		private const int TIME_TRACK_HEIGHT = 50;

		private const int WEATHER_GRID_CELL_SIZE = 100;

		private readonly string[] help = new string[32]
		{
			"Hidden (non-obvious) features:", " - Sliders:", "    - Ctrl + Shift + Right Click on label to copy value to all snapshots in preset", "    - tiny markings above slider show the current and target lerp values", "      based on the current time of day for current pair of snapshots", " - Tiny buttons in timeline at the bottom:", "    - left click to set time of day to that snapshot's start time", "    - right click & drag to change that snapshot's start time", " - Color swatches:", "    - right click to copy color value to \"clipboard\" (not system clipboard)",
			"    - middle click to paste copied color from \"clipboard\"", "    - \"clipboard\" value is displayed in the unlabeled swatch at the bottom", "    - Ctrl + Shift + Right Click to copy that color to all snapshots in preset", " - \"Copy\" button at the bottom:", "    - click to choose a snapshot to copy values from", "    - \"Paste\" button shows up when you move the time to a different snapshot", "    - pasting uses values at the moment of click, not at the moment of clicking \"Copy\"", "", "Glossary:", " - Preset - 24h period describing one day of same weather type (e.g. a cloudy day)",
			" - Snapshot - describes one instant in time of the 24h preset", "    - any moment in the day is described by blending all values of two snapshots,", "      first one before & first one after that moment", "    - moments after last snapshot work by blending between last & first snapshot", " - Weather Driver - describes the logic for scheduling of upcoming presets", "   and blending between current and next one", "", "Rules:", " 1. First snapshot's start time can't be changed, it must always be 0", " 2. Two snapshots can't have identical start time",
			" 3. Last snapshot's start time can't be 1 (can't be moved to the very end of the timeline) - this", "    comes from the rule 2 because end of timeline is the same as first snapshot"
		};

		public WeatherPresetManager manager;

		public WeatherDriver driver;

		private static GUIStyle colorSwatchStyle;

		private static GUIStyle grayTextStyle;

		private static Color clipboardColor;

		private GUIStyle boxStyle;

		private GUIStyle snapshotButtonNormalStyle;

		private GUIStyle snapshotButtonHighlightStyle;

		private bool needsRevalidate;

		private WeatherSnapshot snapshot;

		private WeatherSnapshot clipboardSnapshot;

		private int snapshotIndex;

		private int timeSliderID = -1;

		private IMColorPicker colorPicker;

		private string colorPickerLabel;

		private Weather24hPresetSO baseLowPreset;

		private float lastSetDirtyTime;

		private bool weatherGridDisplayed;

		private bool helpDisplayed;

		private Rect weatherGridRect = new Rect(480f, 0f, 0f, 0f);

		private Rect helpRect = new Rect(480f, 0f, 0f, 0f);

		private Rect forecastRect = new Rect(480f, 0f, 0f, 0f);

		private ColorSwatchWithLabel LightColorDay;

		private ColorSwatchWithLabel LightColorNight;

		private ColorSwatchWithLabel SkyColorDay;

		private ColorSwatchWithLabel SkyColorNight;

		private ColorSwatchWithLabel CloudColorDay;

		private ColorSwatchWithLabel CloudColorNight;

		private ColorSwatchWithLabel SunMeshColor;

		private ColorSwatchWithLabel MoonMeshColor;

		private ColorSwatchWithLabel SunRayColor;

		private ColorSwatchWithLabel MoonRayColor;

		private ColorSwatchWithLabel AmbientColor;

		private ColorSwatchWithLabel FogColor;

		private Vector2 scrollPosition;

		private int snapshotButtonDraggingId = -1;

		private Vector2 scrollPositionWarnings;

		private string lastFocusedTextField;

		private string lastFocusedValue;

		private void Awake()
		{
			colorSwatchStyle = new GUIStyle();
			colorSwatchStyle.normal.background = Texture2D.whiteTexture;
			grayTextStyle = new GUIStyle("label");
			grayTextStyle.normal.textColor = new Color(0.7f, 0.7f, 0.7f);
			boxStyle = new GUIStyle("Box");
			snapshotButtonNormalStyle = new GUIStyle("miniButton");
			snapshotButtonNormalStyle.normal.textColor = new Color(0.8f, 0.8f, 0.8f);
			snapshotButtonHighlightStyle = new GUIStyle("miniButton");
			snapshotButtonHighlightStyle.normal.textColor = Color.yellow;
			snapshotButtonHighlightStyle.fontStyle = FontStyle.Bold;
			if (driver == null)
			{
				Debug.LogError("Weather driver is not assigned");
			}
			InitializeSnapshotInterface();
		}

		private void OnGUI()
		{
			string text = "Weather Editor";
			if (manager == null)
			{
				GUILayout.Label("WeatherPresetManager reference not assigned.");
				return;
			}
			if (!manager.enabled)
			{
				GUILayout.Label("WeatherPresetManager is disabled.");
				return;
			}
			text = $"{manager.CurrentPreset.name} - {manager.DateTime} @ {manager.DayLengthInMinutes}m";
			MainWindow();
			GUILayout.Window(1, new Rect(0f, Screen.height - 50, Screen.width, 50f), TimeSliderWindow, text);
			if (Weather24hPresetSO.warnings.Count != 0)
			{
				GUILayout.Window(2, new Rect(380f, 0f, 380f, 140f), WarningsWindow, "Warnings and errors");
			}
			forecastRect = GUILayout.Window(3, forecastRect, WeatherForecastWindow, "Weather Forecast");
			if (helpDisplayed)
			{
				helpRect = GUILayout.Window(4, helpRect, HelpWindow, "Help");
			}
			if (Time.timeSinceLevelLoad - lastSetDirtyTime > 60f)
			{
				SetPackDirty();
			}
		}

		private void MainWindow()
		{
			using (new GUILayout.HorizontalScope())
			{
				using (new GUILayout.VerticalScope(boxStyle, GUILayout.Width(380f), GUILayout.Height(Screen.height - 50)))
				{
					using (new GUILayout.HorizontalScope())
					{
						if (GUILayout.Button("1"))
						{
							manager.DayLengthInMinutes.RealValue = 1f;
						}
						if (GUILayout.Button("3"))
						{
							manager.DayLengthInMinutes.RealValue = 3f;
						}
						if (GUILayout.Button("10"))
						{
							manager.DayLengthInMinutes.RealValue = 10f;
						}
						if (GUILayout.Button("30"))
						{
							manager.DayLengthInMinutes.RealValue = 30f;
						}
						if (GUILayout.Button("1h"))
						{
							manager.DayLengthInMinutes.RealValue = 60f;
						}
						if (GUILayout.Button("2h"))
						{
							manager.DayLengthInMinutes.RealValue = 120f;
						}
						if (GUILayout.Button("∞"))
						{
							manager.DayLengthInMinutes.RealValue = 9999f;
						}
					}
					using (new GUILayout.HorizontalScope(GUILayout.Width(380f)))
					{
						bool flag = baseLowPreset != null;
						if (!flag && GUILayout.Button("<", GUILayout.Width(20f)))
						{
							driver.ChangePreset(next: false);
						}
						GUILayout.Label("Current: <b>" + manager.CurrentPreset.name + "</b>" + (driver.IsPresetOverridden ? "*" : ""), GUI.skin.label);
						if (!flag && GUILayout.Button(">", GUILayout.Width(20f)))
						{
							driver.ChangePreset(next: true);
						}
						if (snapshot != null && driver.CurrentPreset != null)
						{
							bool hasHighZone = driver.CurrentPreset.HasHighZone;
							using (new GUILayout.HorizontalScope(GUILayout.Width(95f)))
							{
								if (flag)
								{
									GUILayout.Label("   Zone: HIGH   \n   (@ " + (int)(driver.GetLocalFogZoneFactor() * 100f) + "%)   ");
								}
								else
								{
									GUILayout.Label("   Zone: LOW   \n   (@ " + (int)(driver.GetLocalFogZoneFactor() * 100f) + "%)   ");
								}
							}
							using (new GUILayout.HorizontalScope(GUILayout.Width(95f)))
							{
								if (!flag)
								{
									if (hasHighZone)
									{
										if (GUILayout.Button("Switch to HIGH"))
										{
											baseLowPreset = driver.CurrentPreset;
											driver.SetPreset(driver.CurrentPreset.highZoneVariant);
										}
									}
									else
									{
										GUILayout.Label("   (no high pack)");
									}
								}
								else if (GUILayout.Button("Switch to LOW"))
								{
									driver.SetPreset(baseLowPreset);
									baseLowPreset = null;
								}
							}
						}
					}
					if (driver.IsPresetOverridden)
					{
						using (new GUILayout.HorizontalScope(GUILayout.Width(380f)))
						{
							if (GUILayout.Button("Clear override"))
							{
								driver.SetPreset(null);
								baseLowPreset = null;
							}
							GUILayout.Label(" *");
						}
					}
					if ((GUIUtility.hotControl == 0 && GUIUtility.keyboardControl == 0) || GUIUtility.hotControl == timeSliderID)
					{
						var (weatherSnapshot, num) = manager.CurrentPreset.GetSnapshotForTime(manager.timeOfDay);
						if (weatherSnapshot != snapshot)
						{
							colorPicker = null;
							lastFocusedTextField = (lastFocusedValue = null);
							GUIUtility.keyboardControl = 0;
						}
						snapshot = weatherSnapshot;
						snapshotIndex = num;
					}
					if (snapshot == null)
					{
						(WeatherSnapshot snapshot, int index) snapshotForTime = manager.CurrentPreset.GetSnapshotForTime(manager.timeOfDay);
						WeatherSnapshot item = snapshotForTime.snapshot;
						int item2 = snapshotForTime.index;
						snapshot = item;
						snapshotIndex = item2;
					}
					using (GUILayout.ScrollViewScope scrollViewScope = new GUILayout.ScrollViewScope(scrollPosition))
					{
						scrollPosition = scrollViewScope.scrollPosition;
						DrawSnapshotInterface();
					}
				}
				if (colorPicker != null)
				{
					using (new GUILayout.VerticalScope())
					{
						GUILayout.FlexibleSpace();
						GUILayout.Label(colorPickerLabel);
						using (new GUILayout.HorizontalScope())
						{
							colorPicker.DrawColorPicker();
							using (new GUILayout.VerticalScope())
							{
								if (GUILayout.Button("X"))
								{
									colorPicker = null;
								}
								if (GUILayout.Button("C"))
								{
									clipboardColor = colorPicker.Color;
								}
								if (GUILayout.Button("P"))
								{
									colorPicker.Color = clipboardColor;
								}
							}
						}
					}
				}
			}
			if (needsRevalidate && GUIUtility.hotControl == 0)
			{
				needsRevalidate = false;
				manager.CurrentPreset.ValidateSnapshots();
				SetPackDirty();
			}
		}

		private void TimeSliderWindow(int id)
		{
			float num = 10f;
			float num2 = 20f;
			float height = 16f;
			float y = 10f;
			using (new GUILayout.HorizontalScope())
			{
				List<WeatherSnapshot> snapshots = manager.CurrentPreset.snapshots;
				for (int i = 0; i < snapshots.Count; i++)
				{
					WeatherSnapshot weatherSnapshot = snapshots[i];
					GUIStyle style = ((weatherSnapshot == snapshot) ? snapshotButtonHighlightStyle : snapshotButtonNormalStyle);
					Rect position = new Rect(num + ((float)Screen.width - 2f * num - num2) * weatherSnapshot.startTime, y, num2, height);
					Event current = Event.current;
					int num3 = GUIUtility.GetControlID(FocusType.Passive) + 1;
					if (GUI.Button(position, i.ToString(), style) && current.button == 0)
					{
						manager.SetTimeOfDay(weatherSnapshot.startTime + float.Epsilon);
					}
					Rect rect = new Rect(position.x - 40f, position.y - 40f, position.width + 80f, position.height + 80f);
					if ((snapshotButtonDraggingId == -1 || snapshotButtonDraggingId == num3) && GUIUtility.hotControl == num3 && rect.Contains(current.mousePosition) && current.button == 1 && i != 0)
					{
						float value = (current.mousePosition.x - num - num2 / 2f) / ((float)Screen.width - 2f * num - num2);
						value = Mathf.Clamp(value, 0.01f, 0.99f);
						needsRevalidate |= value != weatherSnapshot.startTime;
						weatherSnapshot.startTime = value;
						snapshotButtonDraggingId = num3;
					}
				}
				if (GUIUtility.hotControl == 0)
				{
					snapshotButtonDraggingId = -1;
				}
			}
			timeSliderID = GUIUtility.GetControlID(FocusType.Passive) + 1;
			float num4 = GUILayout.HorizontalSlider(manager.timeOfDay, 0f, 1f);
			if (num4 != manager.timeOfDay)
			{
				manager.SetTimeOfDay(num4);
			}
			using (new GUILayout.HorizontalScope())
			{
				float y2 = 28f;
				float width = 4f;
				float height2 = 20f;
				for (int j = 0; j <= 24; j++)
				{
					float num5 = (float)j / 24f;
					string text = ((j % 6 == 0) ? "|" : ((j % 3 == 0) ? "ˡ" : "ˈ"));
					GUI.Label(new Rect(num + ((float)Screen.width - 2f * num) * num5, y2, width, height2), text);
				}
			}
		}

		private void WarningsWindow(int id)
		{
			using (GUILayout.ScrollViewScope scrollViewScope = new GUILayout.ScrollViewScope(scrollPositionWarnings))
			{
				scrollPositionWarnings = scrollViewScope.scrollPosition;
				foreach (string warning in Weather24hPresetSO.warnings)
				{
					GUILayout.Label(warning);
				}
				if (GUILayout.Button("Clear"))
				{
					Weather24hPresetSO.warnings.Clear();
				}
				int index = manager.CurrentPreset.snapshots.Count - 1;
				if (Mathf.Approximately(manager.CurrentPreset.snapshots[index].startTime, 1f) && GUILayout.Button("Delete invalid last snapshot"))
				{
					Weather24hPresetSO.warnings.Clear();
					manager.CurrentPreset.RemoveSnapshot(index);
				}
			}
		}

		private void HelpWindow(int id)
		{
			GUI.DragWindow(new Rect(0f, 0f, 10000f, 20f));
			using (new GUILayout.VerticalScope(GUILayout.Width(550f)))
			{
				string[] array = help;
				for (int i = 0; i < array.Length; i++)
				{
					GUILayout.Label(array[i]);
				}
				if (GUILayout.Button("Close"))
				{
					helpDisplayed = false;
				}
			}
		}

		private void InitializeSnapshotInterface()
		{
			Func<WeatherSnapshot> currentSnapshotGetter = () => snapshot;
			Func<Weather24hPresetSO> currentPresetGetter = () => manager.CurrentPreset;
			LightColorDay = new ColorSwatchWithLabel("Light color (day)", currentSnapshotGetter, currentPresetGetter, (WeatherSnapshot s) => s.lightColorDay, delegate(WeatherSnapshot s, Color c)
			{
				s.lightColorDay = c;
			}, GetColorPicker, SetColorPicker);
			LightColorNight = new ColorSwatchWithLabel("Light color (night)", currentSnapshotGetter, currentPresetGetter, (WeatherSnapshot s) => s.lightColorNight, delegate(WeatherSnapshot s, Color c)
			{
				s.lightColorNight = c;
			}, GetColorPicker, SetColorPicker);
			SkyColorDay = new ColorSwatchWithLabel("Sky (day)", currentSnapshotGetter, currentPresetGetter, (WeatherSnapshot s) => s.skyColorDay, delegate(WeatherSnapshot s, Color c)
			{
				s.skyColorDay = c;
			}, GetColorPicker, SetColorPicker);
			SkyColorNight = new ColorSwatchWithLabel("Sky (night)", currentSnapshotGetter, currentPresetGetter, (WeatherSnapshot s) => s.skyColorNight, delegate(WeatherSnapshot s, Color c)
			{
				s.skyColorNight = c;
			}, GetColorPicker, SetColorPicker);
			CloudColorDay = new ColorSwatchWithLabel("Cloud (day)", currentSnapshotGetter, currentPresetGetter, (WeatherSnapshot s) => s.cloudColorDay, delegate(WeatherSnapshot s, Color c)
			{
				s.cloudColorDay = c;
			}, GetColorPicker, SetColorPicker);
			CloudColorNight = new ColorSwatchWithLabel("Cloud (night)", currentSnapshotGetter, currentPresetGetter, (WeatherSnapshot s) => s.cloudColorNight, delegate(WeatherSnapshot s, Color c)
			{
				s.cloudColorNight = c;
			}, GetColorPicker, SetColorPicker);
			SunMeshColor = new ColorSwatchWithLabel("Sun mesh", currentSnapshotGetter, currentPresetGetter, (WeatherSnapshot s) => s.sunMeshColor, delegate(WeatherSnapshot s, Color c)
			{
				s.sunMeshColor = c;
			}, GetColorPicker, SetColorPicker);
			MoonMeshColor = new ColorSwatchWithLabel("Moon mesh", currentSnapshotGetter, currentPresetGetter, (WeatherSnapshot s) => s.moonMeshColor, delegate(WeatherSnapshot s, Color c)
			{
				s.moonMeshColor = c;
			}, GetColorPicker, SetColorPicker);
			SunRayColor = new ColorSwatchWithLabel("Sun ray", currentSnapshotGetter, currentPresetGetter, (WeatherSnapshot s) => s.sunRayColor, delegate(WeatherSnapshot s, Color c)
			{
				s.sunRayColor = c;
			}, GetColorPicker, SetColorPicker);
			MoonRayColor = new ColorSwatchWithLabel("Moon ray", currentSnapshotGetter, currentPresetGetter, (WeatherSnapshot s) => s.moonRayColor, delegate(WeatherSnapshot s, Color c)
			{
				s.moonRayColor = c;
			}, GetColorPicker, SetColorPicker);
			AmbientColor = new ColorSwatchWithLabel("Ambient", currentSnapshotGetter, currentPresetGetter, (WeatherSnapshot s) => s.ambientColor, delegate(WeatherSnapshot s, Color c)
			{
				s.ambientColor = c;
			}, GetColorPicker, SetColorPicker);
			FogColor = new ColorSwatchWithLabel("Fog", currentSnapshotGetter, currentPresetGetter, (WeatherSnapshot s) => s.fogColor, delegate(WeatherSnapshot s, Color c)
			{
				s.fogColor = c;
			}, GetColorPicker, SetColorPicker);
			IMColorPicker GetColorPicker()
			{
				return colorPicker;
			}
			void SetColorPicker(IMColorPicker cp, string l)
			{
				colorPicker = cp;
				colorPickerLabel = l;
			}
		}

		private void DrawSnapshotInterface()
		{
			GUILayout.Label($"Snapshot index: {snapshotIndex}, start hour: {Mathf.Lerp(0f, 24f, snapshot.startTime)}");
			WeatherSnapshot currentSnapshot = snapshot;
			WeatherSnapshot neighborSnapshot = manager.CurrentPreset.GetNeighborSnapshot(snapshotIndex, next: true);
			WeatherSnapshot lerpedSnapshot = manager.LerpedSnapshot;
			Slider("Rayleigh", 0f, 5f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.rayleigh, delegate(WeatherSnapshot s, float v)
			{
				s.rayleigh = v;
			});
			Slider("Mie", 0f, 5f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.mie, delegate(WeatherSnapshot s, float v)
			{
				s.mie = v;
			});
			Slider("Brightness", 0f, 2f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.brightness, delegate(WeatherSnapshot s, float v)
			{
				s.brightness = v;
			});
			Slider("Contrast", 0f, 2f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.contrast, delegate(WeatherSnapshot s, float v)
			{
				s.contrast = v;
			});
			Slider("Directionality", 0f, 1f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.directionality, delegate(WeatherSnapshot s, float v)
			{
				s.directionality = v;
			});
			Slider("Fogginess", 0f, 1f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.fogginess, delegate(WeatherSnapshot s, float v)
			{
				s.fogginess = v;
			});
			Slider("Fog Height Bias", 0f, 1000f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.fogHeightBias, delegate(WeatherSnapshot s, float v)
			{
				s.fogHeightBias = v;
			});
			Slider("Fog Density", 0f, 1f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.fogDensity, delegate(WeatherSnapshot s, float v)
			{
				s.fogDensity = v;
			});
			Slider("Fog Distance Density", 0f, 1f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.fogDistanceDensity, delegate(WeatherSnapshot s, float v)
			{
				s.fogDistanceDensity = v;
			});
			Slider("Fog Height Density", 0f, 1f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.fogHeightDensity, delegate(WeatherSnapshot s, float v)
			{
				s.fogHeightDensity = v;
			});
			Slider("Fog Height", 0f, 1000f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.fogHeight, delegate(WeatherSnapshot s, float v)
			{
				s.fogHeight = v;
			});
			Slider("Cloud Size", 0f, 3f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.cloudSize, delegate(WeatherSnapshot s, float v)
			{
				s.cloudSize = v;
			});
			Slider("Cloud Opacity", 0f, 1f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.cloudOpacity, delegate(WeatherSnapshot s, float v)
			{
				s.cloudOpacity = v;
			});
			Slider("Cloud Coverage", 0f, 1f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.cloudCoverage, delegate(WeatherSnapshot s, float v)
			{
				s.cloudCoverage = v;
			});
			Slider("Cloud Sharpness", 0f, 1f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.cloudSharpness, delegate(WeatherSnapshot s, float v)
			{
				s.cloudSharpness = v;
			});
			Slider("Cloud Coloring", 0f, 1f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.cloudColoring, delegate(WeatherSnapshot s, float v)
			{
				s.cloudColoring = v;
			});
			Slider("Cloud Atten.", 0f, 1f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.cloudAttenuation, delegate(WeatherSnapshot s, float v)
			{
				s.cloudAttenuation = v;
			});
			Slider("Cloud Saturation", 0f, 1f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.cloudSaturation, delegate(WeatherSnapshot s, float v)
			{
				s.cloudSaturation = v;
			});
			Slider("Cloud Scattering", 0f, 1f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.cloudScattering, delegate(WeatherSnapshot s, float v)
			{
				s.cloudScattering = v;
			});
			Slider("Cloud Brightness", 0f, 2f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.cloudBrightness, delegate(WeatherSnapshot s, float v)
			{
				s.cloudBrightness = v;
			});
			Slider("Light Intensity", 0f, 2f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.lightIntensity, delegate(WeatherSnapshot s, float v)
			{
				s.lightIntensity = v;
			});
			Slider("Shafts Intensity", 0f, 2f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.shaftsIntensity, delegate(WeatherSnapshot s, float v)
			{
				s.shaftsIntensity = v;
			});
			Slider("Shadow Strength", 0f, 2f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.shadowStrength, delegate(WeatherSnapshot s, float v)
			{
				s.shadowStrength = v;
			});
			Slider("Ambient Mult", 0f, 3f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.ambientMult, delegate(WeatherSnapshot s, float v)
			{
				s.ambientMult = v;
			});
			Slider("Sky Amb. Intens.", 0f, 8f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.skyIntensity, delegate(WeatherSnapshot s, float v)
			{
				s.skyIntensity = v;
			});
			Slider("Equator Amb. Int.", 0f, 8f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.equatorIntensity, delegate(WeatherSnapshot s, float v)
			{
				s.equatorIntensity = v;
			});
			Slider("Ground Amb. Int.", 0f, 8f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.groundIntensity, delegate(WeatherSnapshot s, float v)
			{
				s.groundIntensity = v;
			});
			Slider("Reflection Mult", 0f, 1f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.reflectionMult, delegate(WeatherSnapshot s, float v)
			{
				s.reflectionMult = v;
			});
			Slider("Sun Mesh Bright.", 0f, 2f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.sunMeshBrightness, delegate(WeatherSnapshot s, float v)
			{
				s.sunMeshBrightness = v;
			});
			Slider("Sun Mesh Contr.", 0f, 2f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.sunMeshContrast, delegate(WeatherSnapshot s, float v)
			{
				s.sunMeshContrast = v;
			});
			Slider("Moon Mesh Bright.", 0f, 2f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.moonMeshBrightness, delegate(WeatherSnapshot s, float v)
			{
				s.moonMeshBrightness = v;
			});
			Slider("Moon Mesh Contr.", 0f, 4f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.moonMeshContrast, delegate(WeatherSnapshot s, float v)
			{
				s.moonMeshContrast = v;
			});
			Slider("Moon Halo Size", 0f, 1f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.moonHaloSize, delegate(WeatherSnapshot s, float v)
			{
				s.moonHaloSize = v;
			});
			Slider("Moon Halo Bright.", 0f, 2f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.moonHaloBrightness, delegate(WeatherSnapshot s, float v)
			{
				s.moonHaloBrightness = v;
			});
			Slider("Stars Size", 0f, 2f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.starsSize, delegate(WeatherSnapshot s, float v)
			{
				s.starsSize = v;
			});
			Slider("Stars Brightness", 0f, 2f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.starsBrightness, delegate(WeatherSnapshot s, float v)
			{
				s.starsBrightness = v;
			});
			Slider("Eye Adap. Min", -10f, 10f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.eyeAdaptationMin, delegate(WeatherSnapshot s, float v)
			{
				s.eyeAdaptationMin = v;
			});
			Slider("Eye Adap. Max", -10f, 10f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.eyeAdaptationMax, delegate(WeatherSnapshot s, float v)
			{
				s.eyeAdaptationMax = v;
			});
			Slider("Wetness", 0f, 1f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.wetness, delegate(WeatherSnapshot s, float v)
			{
				s.wetness = v;
			});
			Slider("Rain Strength", 0f, 1f, currentSnapshot, neighborSnapshot, lerpedSnapshot, (WeatherSnapshot s) => s.rainStrength, delegate(WeatherSnapshot s, float v)
			{
				s.rainStrength = v;
			});
			LightColorDay.Draw();
			LightColorNight.Draw();
			SkyColorDay.Draw();
			SkyColorNight.Draw();
			CloudColorDay.Draw();
			CloudColorNight.Draw();
			SunMeshColor.Draw();
			MoonMeshColor.Draw();
			SunRayColor.Draw();
			MoonRayColor.Draw();
			AmbientColor.Draw();
			FogColor.Draw();
			GUILayout.Space(10f);
			ColorSwatch(clipboardColor);
			GUILayout.Space(20f);
			if (snapshotIndex == 0)
			{
				GUILayout.Label("Start time", GUILayout.Width(100f));
			}
			else if (Slider("Start time", 0f, 1f, snapshot, null, null, (WeatherSnapshot s) => s.startTime, delegate(WeatherSnapshot s, float v)
			{
				s.startTime = v;
			}))
			{
				needsRevalidate = true;
			}
			using (new GUILayout.HorizontalScope())
			{
				if (GUILayout.Button("+", GUILayout.Width(30f)))
				{
					manager.CurrentPreset.InsertSnapshot(manager.timeOfDay);
				}
				if (snapshotIndex != 0 && GUILayout.Button("-", GUILayout.Width(30f)))
				{
					manager.CurrentPreset.RemoveSnapshot(snapshotIndex);
				}
				if (GUILayout.Button("Copy"))
				{
					clipboardSnapshot = snapshot;
				}
				if (clipboardSnapshot != null && clipboardSnapshot != snapshot && GUILayout.Button($"Paste from {clipboardSnapshot.startTime}"))
				{
					snapshot.CopyFrom(clipboardSnapshot);
				}
				GUILayout.FlexibleSpace();
				driver.showVisualization = GUILayout.Toggle(driver.showVisualization, "Point visualization", GUILayout.Width(130f));
				GUILayout.FlexibleSpace();
				if (GUILayout.Button("?", GUILayout.Width(30f)))
				{
					helpDisplayed = !helpDisplayed;
				}
			}
		}

		private void WeatherForecastWindow(int id)
		{
			if (SingletonBehaviour<WeatherForecaster>.Instance == null)
			{
				return;
			}
			List<WeatherForecastItem> interpretedData = SingletonBehaviour<WeatherForecaster>.Instance.interpretedData;
			if (interpretedData.Count == 0)
			{
				return;
			}
			GUI.DragWindow(new Rect(0f, 0f, 10000f, 20f));
			using (new GUILayout.VerticalScope(GUILayout.Width(250f)))
			{
				WeatherForecastItem? weatherForecastItem = null;
				float managedDateTime = driver.ManagedDateTime;
				for (int i = 0; i < interpretedData.Count; i++)
				{
					WeatherForecastItem value = interpretedData[i];
					int num;
					if (value.firstSampleTimestamp <= managedDateTime)
					{
						num = ((managedDateTime < value.firstSampleTimestamp + value.sampledDataDuration) ? 1 : 0);
						if (num != 0)
						{
							weatherForecastItem = value;
						}
					}
					else
					{
						num = 0;
					}
					GUIStyle style = ((num != 0) ? snapshotButtonHighlightStyle : snapshotButtonNormalStyle);
					GUILayout.Label($"{value.hourStart} - {value.hourEnd}: {value.iconType}", style);
				}
				GUILayout.Space(10f);
				if (weatherForecastItem.HasValue)
				{
					GUILayout.Label("Averages:");
					WeatherForecastItem value2 = weatherForecastItem.Value;
					Sl("Rain", value2.averageRain);
					Sl("Cloudiness", value2.averageCloudiness);
					Sl("Thunder", value2.averageThunder);
					Sl("Fog", value2.averageFog);
				}
				else
				{
					GUILayout.Label("No forecast data for current time");
				}
			}
			void Sl(string label, float num2)
			{
				using (new GUILayout.HorizontalScope())
				{
					GUILayout.Label($"{label}: {Mathf.Round(num2)}", GUI.skin.label, GUILayout.Width(110f));
					GUILayout.HorizontalSlider(num2, 0f, 100f);
				}
			}
		}

		private void SetPackDirty()
		{
			lastSetDirtyTime = Time.timeSinceLevelLoad;
		}

		private bool Slider(string label, float min, float max, WeatherSnapshot currentSnapshot, WeatherSnapshot nextSnapshot, WeatherSnapshot lerpSnapshot, Func<WeatherSnapshot, float> Getter, Action<WeatherSnapshot, float> Setter, float textMultiplier = 1f)
		{
			bool result = false;
			Rect lastRect;
			using (new GUILayout.HorizontalScope())
			{
				bool num = GUILayout.Button(label, GUI.skin.label, GUILayout.Width(110f));
				Event current = Event.current;
				if (num && current.modifiers == (EventModifiers.Shift | EventModifiers.Control))
				{
					float currentValue = Getter(currentSnapshot);
					manager.CurrentPreset.snapshots.ForEach(delegate(WeatherSnapshot snap)
					{
						Setter(snap, currentValue);
					});
				}
				float num2 = GUILayout.HorizontalSlider(Getter(currentSnapshot), min, max);
				lastRect = GUILayoutUtility.GetLastRect();
				result = num2 != Getter(currentSnapshot);
				Setter(currentSnapshot, num2);
				string text = ((lastFocusedTextField == label) ? lastFocusedValue : (Getter(currentSnapshot) * textMultiplier).ToString());
				GUI.SetNextControlName(label);
				text = GUILayout.TextField(text, GUILayout.Width(40f));
				if (GUI.GetNameOfFocusedControl() == label)
				{
					lastFocusedTextField = label;
					lastFocusedValue = text;
				}
				else if (lastFocusedTextField == label)
				{
					lastFocusedTextField = (lastFocusedValue = null);
					GUIUtility.keyboardControl = 0;
				}
				if (float.TryParse(text, out var result2))
				{
					result2 /= textMultiplier;
					if (result2 != Getter(currentSnapshot))
					{
						result = true;
					}
					Setter(currentSnapshot, result2);
				}
			}
			if (lerpSnapshot != null)
			{
				GUI.Label(new Rect(lastRect.x + lastRect.width * Mathf.InverseLerp(min, max, Getter(lerpSnapshot)), lastRect.y - 2f, 6f, 4f), "|", grayTextStyle);
			}
			if (nextSnapshot != null)
			{
				GUI.Label(new Rect(lastRect.x + lastRect.width * Mathf.InverseLerp(min, max, Getter(nextSnapshot)), lastRect.y - 2f, 6f, 4f), "▌", grayTextStyle);
			}
			return result;
		}

		private static bool ColorSwatch(Color c)
		{
			bool flag = false;
			using (new GUILayout.VerticalScope())
			{
				Color backgroundColor = GUI.backgroundColor;
				GUI.backgroundColor = new Color(c.r, c.g, c.b);
				flag = GUILayout.Button("", colorSwatchStyle, GUILayout.Width(80f), GUILayout.Height(15f));
				GUILayout.Space(1f);
				float a = c.a;
				GUI.backgroundColor = new Color(a, a, a);
				GUILayout.Label("", colorSwatchStyle, GUILayout.Width(80f), GUILayout.Height(2f));
				GUI.backgroundColor = backgroundColor;
				return flag;
			}
		}
	}
}

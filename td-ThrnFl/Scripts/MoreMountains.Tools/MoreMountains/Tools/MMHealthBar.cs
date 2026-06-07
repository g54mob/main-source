using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MoreMountains.Tools
{
	[AddComponentMenu("More Mountains/Tools/GUI/MMHealthBar")]
	public class MMHealthBar : MonoBehaviour
	{
		public enum HealthBarTypes
		{
			Prefab = 0,
			Drawn = 1,
			Existing = 2
		}

		public enum TimeScales
		{
			UnscaledTime = 0,
			Time = 1
		}

		[MMInformation("Add this component to an object and it'll add a healthbar next to it to reflect its health level in real time. You can decide here whether the health bar should be drawn automatically or use a prefab.", MMInformationAttribute.InformationType.Info, false)]
		[Tooltip("whether the healthbar uses a prefab or is drawn automatically")]
		public HealthBarTypes HealthBarType = HealthBarTypes.Drawn;

		[Tooltip("defines whether the bar will work on scaled or unscaled time (whether or not it'll keep moving if time is slowed down for example)")]
		public TimeScales TimeScale;

		[Header("Select a Prefab")]
		[MMInformation("Select a prefab with a progress bar script on it. There is one example of such a prefab in Common/Prefabs/GUI.", MMInformationAttribute.InformationType.Info, false)]
		[Tooltip("the prefab to use as the health bar")]
		public MMProgressBar HealthBarPrefab;

		[Header("Existing MMProgressBar")]
		[Tooltip("the MMProgressBar this health bar should update")]
		public MMProgressBar TargetProgressBar;

		[Header("Drawn Healthbar Settings ")]
		[MMInformation("Set the size (in world units), padding, back and front colors of the healthbar.", MMInformationAttribute.InformationType.Info, false)]
		[Tooltip("if the healthbar is drawn, its size in world units")]
		public Vector2 Size = new Vector2(1f, 0.2f);

		[Tooltip("if the healthbar is drawn, the padding to apply to the foreground, in world units")]
		public Vector2 BackgroundPadding = new Vector2(0.01f, 0.01f);

		[Tooltip("the rotation to apply to the MMHealthBarContainer when drawing it")]
		public Vector3 InitialRotationAngles;

		[Tooltip("if the healthbar is drawn, the color of its foreground")]
		public Gradient ForegroundColor = new Gradient
		{
			colorKeys = new GradientColorKey[2]
			{
				new GradientColorKey(MMColors.BestRed, 0f),
				new GradientColorKey(MMColors.BestRed, 1f)
			},
			alphaKeys = new GradientAlphaKey[2]
			{
				new GradientAlphaKey(1f, 0f),
				new GradientAlphaKey(1f, 1f)
			}
		};

		[Tooltip("if the healthbar is drawn, the color of its delayed bar")]
		public Gradient DelayedColor = new Gradient
		{
			colorKeys = new GradientColorKey[2]
			{
				new GradientColorKey(MMColors.Orange, 0f),
				new GradientColorKey(MMColors.Orange, 1f)
			},
			alphaKeys = new GradientAlphaKey[2]
			{
				new GradientAlphaKey(1f, 0f),
				new GradientAlphaKey(1f, 1f)
			}
		};

		[Tooltip("if the healthbar is drawn, the color of its border")]
		public Gradient BorderColor = new Gradient
		{
			colorKeys = new GradientColorKey[2]
			{
				new GradientColorKey(MMColors.AntiqueWhite, 0f),
				new GradientColorKey(MMColors.AntiqueWhite, 1f)
			},
			alphaKeys = new GradientAlphaKey[2]
			{
				new GradientAlphaKey(1f, 0f),
				new GradientAlphaKey(1f, 1f)
			}
		};

		[Tooltip("if the healthbar is drawn, the color of its background")]
		public Gradient BackgroundColor = new Gradient
		{
			colorKeys = new GradientColorKey[2]
			{
				new GradientColorKey(MMColors.Black, 0f),
				new GradientColorKey(MMColors.Black, 1f)
			},
			alphaKeys = new GradientAlphaKey[2]
			{
				new GradientAlphaKey(1f, 0f),
				new GradientAlphaKey(1f, 1f)
			}
		};

		[Tooltip("the name of the sorting layer to put this health bar on")]
		public string SortingLayerName = "UI";

		[Tooltip("the delay to apply to the delayed bar if drawn")]
		public float Delay = 0.5f;

		[Tooltip("whether or not the front bar should lerp")]
		public bool LerpFrontBar = true;

		[Tooltip("the speed at which the front bar lerps")]
		public float LerpFrontBarSpeed = 15f;

		[Tooltip("whether or not the delayed bar should lerp")]
		public bool LerpDelayedBar = true;

		[Tooltip("the speed at which the delayed bar lerps")]
		public float LerpDelayedBarSpeed = 15f;

		[Tooltip("if this is true, bumps the scale of the healthbar when its value changes")]
		public bool BumpScaleOnChange = true;

		[Tooltip("the duration of the bump animation")]
		public float BumpDuration = 0.2f;

		[Tooltip("the animation curve to map the bump animation on")]
		public AnimationCurve BumpAnimationCurve = AnimationCurve.Constant(0f, 1f, 1f);

		[Tooltip("the mode the bar should follow the target in")]
		public MMFollowTarget.UpdateModes FollowTargetMode = MMFollowTarget.UpdateModes.LateUpdate;

		[Tooltip("if this is true, the drawn health bar will be nested below the MMHealthBar")]
		public bool NestDrawnHealthBar;

		[Tooltip("if this is true, a MMBillboard component will be added to the progress bar to make sure it always looks towards the camera")]
		public bool Billboard;

		[Header("Death")]
		[Tooltip("a gameobject (usually a particle system) to instantiate when the healthbar reaches zero")]
		public GameObject InstantiatedOnDeath;

		[Header("Offset")]
		[MMInformation("Set the offset (in world units), relative to the object's center, to which the health bar will be displayed.", MMInformationAttribute.InformationType.Info, false)]
		[Tooltip("the offset to apply to the healthbar compared to the object's center")]
		public Vector3 HealthBarOffset = new Vector3(0f, 1f, 0f);

		[Header("Display")]
		[MMInformation("Here you can define whether or not the healthbar should always be visible. If not, you can set here how long after a hit it'll remain visible.", MMInformationAttribute.InformationType.Info, false)]
		[Tooltip("whether or not the bar should be permanently displayed")]
		public bool AlwaysVisible = true;

		[Tooltip("the duration (in seconds) during which to display the bar")]
		public float DisplayDurationOnHit = 1f;

		[Tooltip("if this is set to true the bar will hide itself when it reaches zero")]
		public bool HideBarAtZero = true;

		[Tooltip("the delay (in seconds) after which to hide the bar")]
		public float HideBarAtZeroDelay = 1f;

		protected MMProgressBar _progressBar;

		protected MMFollowTarget _followTransform;

		protected float _lastShowTimestamp;

		protected bool _showBar;

		protected Image _backgroundImage;

		protected Image _borderImage;

		protected Image _foregroundImage;

		protected Image _delayedImage;

		protected bool _finalHideStarted;

		protected virtual void Awake()
		{
			Initialization();
		}

		protected void OnEnable()
		{
			_finalHideStarted = false;
			if (!AlwaysVisible && _progressBar != null)
			{
				_progressBar.gameObject.SetActive(value: false);
			}
		}

		public virtual void Initialization()
		{
			_finalHideStarted = false;
			if (_progressBar != null)
			{
				_progressBar.gameObject.SetActive(AlwaysVisible);
				return;
			}
			switch (HealthBarType)
			{
			case HealthBarTypes.Prefab:
				if (HealthBarPrefab == null)
				{
					Debug.LogWarning(base.name + " : the HealthBar has no prefab associated to it, nothing will be displayed.");
					return;
				}
				_progressBar = Object.Instantiate(HealthBarPrefab, base.transform.position + HealthBarOffset, base.transform.rotation);
				SceneManager.MoveGameObjectToScene(_progressBar.gameObject, base.gameObject.scene);
				_progressBar.transform.SetParent(base.transform);
				_progressBar.gameObject.name = "HealthBar";
				break;
			case HealthBarTypes.Drawn:
				DrawHealthBar();
				UpdateDrawnColors();
				break;
			case HealthBarTypes.Existing:
				_progressBar = TargetProgressBar;
				break;
			}
			if (!AlwaysVisible)
			{
				_progressBar.gameObject.SetActive(value: false);
			}
			if (_progressBar != null)
			{
				_progressBar.SetBar(100f, 0f, 100f);
			}
		}

		protected virtual void DrawHealthBar()
		{
			GameObject gameObject = new GameObject();
			SceneManager.MoveGameObjectToScene(gameObject, base.gameObject.scene);
			gameObject.name = "HealthBar|" + base.gameObject.name;
			if (NestDrawnHealthBar)
			{
				gameObject.transform.SetParent(base.transform);
			}
			_progressBar = gameObject.AddComponent<MMProgressBar>();
			_followTransform = gameObject.AddComponent<MMFollowTarget>();
			_followTransform.Offset = HealthBarOffset;
			_followTransform.Target = base.transform;
			_followTransform.FollowRotation = false;
			_followTransform.InterpolatePosition = false;
			_followTransform.InterpolateRotation = false;
			_followTransform.UpdateMode = FollowTargetMode;
			Canvas canvas = gameObject.AddComponent<Canvas>();
			canvas.renderMode = RenderMode.WorldSpace;
			canvas.transform.localScale = Vector3.one;
			canvas.GetComponent<RectTransform>().sizeDelta = Size;
			if (!string.IsNullOrEmpty(SortingLayerName))
			{
				canvas.sortingLayerName = SortingLayerName;
			}
			GameObject gameObject2 = new GameObject();
			gameObject2.transform.SetParent(gameObject.transform);
			gameObject2.name = "MMProgressBarContainer";
			gameObject2.transform.localScale = Vector3.one;
			GameObject gameObject3 = new GameObject();
			gameObject3.transform.SetParent(gameObject2.transform);
			gameObject3.name = "HealthBar Border";
			_borderImage = gameObject3.AddComponent<Image>();
			_borderImage.transform.position = Vector3.zero;
			_borderImage.transform.localScale = Vector3.one;
			_borderImage.GetComponent<RectTransform>().sizeDelta = Size;
			_borderImage.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
			GameObject gameObject4 = new GameObject();
			gameObject4.transform.SetParent(gameObject2.transform);
			gameObject4.name = "HealthBar Background";
			_backgroundImage = gameObject4.AddComponent<Image>();
			_backgroundImage.transform.position = Vector3.zero;
			_backgroundImage.transform.localScale = Vector3.one;
			_backgroundImage.GetComponent<RectTransform>().sizeDelta = Size - BackgroundPadding * 2f;
			_backgroundImage.GetComponent<RectTransform>().anchoredPosition = -_backgroundImage.GetComponent<RectTransform>().sizeDelta / 2f;
			_backgroundImage.GetComponent<RectTransform>().pivot = Vector2.zero;
			GameObject gameObject5 = new GameObject();
			gameObject5.transform.SetParent(gameObject2.transform);
			gameObject5.name = "HealthBar Delayed Foreground";
			_delayedImage = gameObject5.AddComponent<Image>();
			_delayedImage.transform.position = Vector3.zero;
			_delayedImage.transform.localScale = Vector3.one;
			_delayedImage.GetComponent<RectTransform>().sizeDelta = Size - BackgroundPadding * 2f;
			_delayedImage.GetComponent<RectTransform>().anchoredPosition = -_delayedImage.GetComponent<RectTransform>().sizeDelta / 2f;
			_delayedImage.GetComponent<RectTransform>().pivot = Vector2.zero;
			GameObject gameObject6 = new GameObject();
			gameObject6.transform.SetParent(gameObject2.transform);
			gameObject6.name = "HealthBar Foreground";
			_foregroundImage = gameObject6.AddComponent<Image>();
			_foregroundImage.transform.position = Vector3.zero;
			_foregroundImage.transform.localScale = Vector3.one;
			_foregroundImage.color = ForegroundColor.Evaluate(1f);
			_foregroundImage.GetComponent<RectTransform>().sizeDelta = Size - BackgroundPadding * 2f;
			_foregroundImage.GetComponent<RectTransform>().anchoredPosition = -_foregroundImage.GetComponent<RectTransform>().sizeDelta / 2f;
			_foregroundImage.GetComponent<RectTransform>().pivot = Vector2.zero;
			if (Billboard)
			{
				_progressBar.gameObject.AddComponent<MMBillboard>();
			}
			_progressBar.LerpDecreasingDelayedBar = LerpDelayedBar;
			_progressBar.LerpForegroundBar = LerpFrontBar;
			_progressBar.LerpDecreasingDelayedBarSpeed = LerpDelayedBarSpeed;
			_progressBar.LerpForegroundBarSpeedIncreasing = LerpFrontBarSpeed;
			_progressBar.ForegroundBar = _foregroundImage.transform;
			_progressBar.DelayedBarDecreasing = _delayedImage.transform;
			_progressBar.DecreasingDelay = Delay;
			_progressBar.BumpScaleOnChange = BumpScaleOnChange;
			_progressBar.BumpDuration = BumpDuration;
			_progressBar.BumpScaleAnimationCurve = BumpAnimationCurve;
			_progressBar.TimeScale = ((TimeScale == TimeScales.Time) ? MMProgressBar.TimeScales.Time : MMProgressBar.TimeScales.UnscaledTime);
			gameObject2.transform.localEulerAngles = InitialRotationAngles;
			_progressBar.Initialization();
		}

		protected virtual void Update()
		{
			if (_progressBar == null || _finalHideStarted)
			{
				return;
			}
			UpdateDrawnColors();
			if (AlwaysVisible)
			{
				return;
			}
			if (_showBar)
			{
				_progressBar.gameObject.SetActive(value: true);
				if (((TimeScale == TimeScales.UnscaledTime) ? Time.unscaledTime : Time.time) - _lastShowTimestamp > DisplayDurationOnHit)
				{
					_showBar = false;
				}
			}
			else
			{
				_progressBar.gameObject.SetActive(value: false);
			}
		}

		protected virtual IEnumerator FinalHideBar()
		{
			_finalHideStarted = true;
			if (InstantiatedOnDeath != null)
			{
				SceneManager.MoveGameObjectToScene(Object.Instantiate(InstantiatedOnDeath, base.transform.position + HealthBarOffset, base.transform.rotation).gameObject, base.gameObject.scene);
			}
			if (HideBarAtZeroDelay == 0f)
			{
				_showBar = false;
				_progressBar.gameObject.SetActive(value: false);
				yield return null;
			}
			else
			{
				_progressBar.HideBar(HideBarAtZeroDelay);
			}
		}

		protected virtual void UpdateDrawnColors()
		{
			if (HealthBarType == HealthBarTypes.Drawn && !_progressBar.Bumping)
			{
				if (_borderImage != null)
				{
					_borderImage.color = BorderColor.Evaluate(_progressBar.BarProgress);
				}
				if (_backgroundImage != null)
				{
					_backgroundImage.color = BackgroundColor.Evaluate(_progressBar.BarProgress);
				}
				if (_delayedImage != null)
				{
					_delayedImage.color = DelayedColor.Evaluate(_progressBar.BarProgress);
				}
				if (_foregroundImage != null)
				{
					_foregroundImage.color = ForegroundColor.Evaluate(_progressBar.BarProgress);
				}
			}
		}

		public virtual void UpdateBar(float currentHealth, float minHealth, float maxHealth, bool show)
		{
			if (!AlwaysVisible && show)
			{
				_showBar = true;
				_lastShowTimestamp = ((TimeScale == TimeScales.UnscaledTime) ? Time.unscaledTime : Time.time);
			}
			if (_progressBar != null)
			{
				_progressBar.UpdateBar(currentHealth, minHealth, maxHealth);
				if (HideBarAtZero && _progressBar.BarTarget <= 0f)
				{
					StartCoroutine(FinalHideBar());
				}
				if (BumpScaleOnChange)
				{
					_progressBar.Bump();
				}
			}
		}
	}
}

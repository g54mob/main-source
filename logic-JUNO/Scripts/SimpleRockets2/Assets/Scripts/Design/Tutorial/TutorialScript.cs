using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Packages.SocialPlatforms.Achievements;
using Assets.Scripts.Design.Tutorial.Steps;
using Assets.Scripts.Input;
using Assets.Scripts.State;
using Assets.Scripts.Ui;
using ModApi;
using ModApi.Audio;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Design;
using ModApi.Ui;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Design.Tutorial
{
	public class TutorialScript : MonoBehaviour
	{
		public delegate void TutorialDelegate(TutorialScript tutorial);

		public delegate void TutorialStepDelegate(TutorialScript tutorial, TutorialStep step);

		private class HighlightTarget
		{
			public Vector2 Padding { get; set; }

			public ScrollRect ScrollRect { get; set; }

			public RectTransform Target { get; set; }
		}

		private string _craftDesignId;

		private CraftData _currentStepCraftData;

		private XElement _currentStepCraftXml;

		private int _fingerToolStep;

		private bool _firstFrame;

		private Color _highlightColor;

		private HighlightTarget _highlightTarget;

		private float _highlightTime;

		private string _lastAccomplishment;

		private int _step;

		private TutorialPanelScript _tutorialPanel;

		public string CraftDesignId
		{
			get
			{
				return _craftDesignId;
			}
			set
			{
				_craftDesignId = value;
				_currentStepCraftXml = null;
				_currentStepCraftData = null;
			}
		}

		public CraftData CurrentStepCraftData
		{
			get
			{
				if (_currentStepCraftData == null)
				{
					_currentStepCraftData = Game.Instance.CraftLoader.LoadCraftImmediate(CurrentStepCraftXml);
				}
				return _currentStepCraftData;
			}
		}

		public int? DebugStartStep { get; set; }

		public Vector3 DefaultCameraOffset { get; set; }

		public DesignerScript DesignerScript { get; set; }

		public IDesignerUi DesignerUi => DesignerScript.DesignerUi;

		public bool HasFingerToolBeenIntroduced { get; set; }

		public bool IsComplete { get; private set; }

		public bool IsHighlightOffscreen => _tutorialPanel.IsHighlightOffscreen;

		public TutorialStep LastStep => Steps.Last();

		public bool LoadAllParts { get; set; }

		public List<int> LoadedPartIds { get; private set; } = new List<int>();

		public List<int> LoadedSymmetricPartIds { get; private set; } = new List<int>();

		public Material SolidPartMaterial { get; set; }

		public List<TutorialStep> Steps { get; private set; } = new List<TutorialStep>();

		public Material TargetPartMaterial { get; set; }

		public DesignerTutorial Tutorial { get; set; }

		private TutorialStep CurrentStep => Steps[_step];

		private XElement CurrentStepCraftXml
		{
			get
			{
				if (_currentStepCraftXml == null)
				{
					_currentStepCraftXml = Game.Instance.CraftDesigns.GetCraftDesign(CraftDesignId);
				}
				return _currentStepCraftXml;
			}
		}

		public event TutorialDelegate Complete;

		public event TutorialStepDelegate StepLoaded;

		public void Accomplishment(string name, float delay = 0f)
		{
			if (_lastAccomplishment != name)
			{
				_lastAccomplishment = name;
				PlayAccomplishmentSound(delay);
			}
		}

		public void CompleteTutorial()
		{
			IsComplete = true;
			this.Complete?.Invoke(this);
			RecordTutorialAnalyticsEvent(completed: true);
		}

		public void DisableUiHighlight()
		{
			_highlightTarget = null;
		}

		public void DisplayError(string message)
		{
			_tutorialPanel.DisplayError(ProcessStringWithMobileAlternative(message));
		}

		public void DisplayInstructionText(string text)
		{
			_tutorialPanel.InstructionText = ProcessStringWithMobileAlternative(text);
		}

		public void DisplayStepText(string text)
		{
			_tutorialPanel.StepText = ProcessStringWithMobileAlternative(text);
		}

		public void ExitTutorial()
		{
			CurrentStep?.End();
			DisplayInstructionText(string.Empty);
			DisableUiHighlight();
			IsComplete = _step >= Steps.Count - 1;
			this.Complete?.Invoke(this);
			RecordTutorialAnalyticsEvent(completed: false);
			UnityEngine.Object.Destroy(base.gameObject);
			if (Game.Instance.GameState.Career.IsStock && !IsComplete)
			{
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.TutorialCareerDeclined);
			}
		}

		public PartData GetCraftPart(int partId)
		{
			return DesignerScript.CraftScript.Data.Assembly.GetPartById(partId);
		}

		public DesignerPart GetDesignerPart(string name)
		{
			foreach (DesignerPart part in DesignerUi.Flyouts.PartList.Transform.GetComponentInChildren<PartListPanelScript>().DesignerParts.Parts)
			{
				if (part.Name == name && !part.IsSubassembly)
				{
					return part;
				}
			}
			return null;
		}

		public int GetPartId(string partName)
		{
			List<PartData> list = CurrentStepCraftData.Assembly.Parts.Where((PartData x) => x.Name == partName).ToList();
			if (list.Count == 1)
			{
				return list[0].Id;
			}
			base.gameObject.SetActive(value: false);
			throw new Exception($"Part name '{partName}' resulted in {list.Count} matches, but only one match is allowed.");
		}

		public bool HighlightUiElement(string name, Vector2 padding, bool highlightEvenIfInactive = false)
		{
			string[] array = name.Split(new char[1] { '/' });
			GameObject gameObject = DesignerUi.Transform.gameObject;
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				gameObject = Utilities.FindFirstGameObjectMyselfOrChildren(array2[i], gameObject, highlightEvenIfInactive);
			}
			return HighlightUiElement(gameObject, padding, highlightEvenIfInactive);
		}

		public bool HighlightUiElement(GameObject gameObject, Vector2 padding, bool highlightEvenIfInactive)
		{
			if (gameObject != null && (gameObject.activeInHierarchy || highlightEvenIfInactive))
			{
				_highlightTarget = new HighlightTarget
				{
					Target = gameObject.GetComponent<RectTransform>(),
					Padding = padding
				};
				_highlightTarget.ScrollRect = _highlightTarget.Target.GetComponentInParent<ScrollRect>();
				return true;
			}
			_highlightTarget = null;
			return false;
		}

		public void NextStep(bool playSound = false)
		{
			if (_step < Steps.Count - 1)
			{
				CurrentStep.End();
				DisplayInstructionText(string.Empty);
				DisableUiHighlight();
				_step++;
				LoadStep(_step);
				if (playSound)
				{
					PlayAccomplishmentSound(0f);
				}
				_lastAccomplishment = null;
			}
			else
			{
				CompleteTutorial();
			}
		}

		public AddFuselageStep QueueAddFuselagePartStep(int partId, string designerPartName, bool updatePosition, string stepText)
		{
			AddFuselageStep addFuselageStep = new AddFuselageStep(partId, this, designerPartName, updatePosition);
			QueueStep(addFuselageStep, stepText);
			LoadedPartIds.Add(partId);
			return addFuselageStep;
		}

		public AddPartStep QueueAddPartStep(int partId, string designerPartName, string stepText)
		{
			AddPartStep addPartStep = new AddPartStep(partId, this, designerPartName);
			addPartStep.StepText = stepText;
			QueueStep(addPartStep, stepText);
			LoadedPartIds.Add(partId);
			return addPartStep;
		}

		public T QueueStep<T>(T step, string stepText) where T : TutorialStep
		{
			if (LoadedPartIds != null)
			{
				step.LoadedPartIds.AddRange(LoadedPartIds);
			}
			else
			{
				step.LoadAllParts = true;
			}
			step.CraftXml = CurrentStepCraftXml;
			step.StepText = stepText;
			step.LoadAllParts = LoadAllParts;
			step.LoadedSymmetricPartIds.AddRange(LoadedSymmetricPartIds);
			step.CameraFocusOffset = DefaultCameraOffset;
			Steps.Add(step);
			return step;
		}

		public void RestartStep()
		{
			LoadStep(_step);
		}

		public void ShowPanelType(TutorialPanelScript.TutorialPanelType panelType)
		{
			_tutorialPanel.ShowPanel(panelType);
		}

		public void SkipStep()
		{
			if (_step < Steps.Count)
			{
				Steps[_step].Skip();
			}
			NextStep(playSound: true);
		}

		public void StartTutorial()
		{
			DesignerUi.FingerTool.Enabled = false;
			GameObject gameObject = UiUtilities.CreateUiGameObject("TutorialPanel", base.transform);
			_tutorialPanel = gameObject.AddComponent<TutorialPanelScript>();
			_tutorialPanel.TutorialScript = this;
			Game.Instance.UserInterface.BuildUserInterfaceFromResource("Ui/Xml/Design/TutorialPanel", _tutorialPanel, delegate(IXmlLayoutController x)
			{
				_tutorialPanel.OnLayoutRebuilt((XmlLayout)x.XmlLayout);
			});
			Material original = Game.Instance.ResourceLoader.LoadMaterial("Craft/Parts/Materials/DesignerTutorialTargetPart");
			TargetPartMaterial = UnityEngine.Object.Instantiate(original);
			original = Game.Instance.ResourceLoader.LoadMaterial("Craft/Parts/Materials/DesignerTutorialSolidPart");
			SolidPartMaterial = UnityEngine.Object.Instantiate(original);
			_step = (Application.isEditor ? DebugStartStep : ((int?)null)).GetValueOrDefault();
			LoadStep(_step);
		}

		protected virtual void OnDestroy()
		{
			if (!IsComplete)
			{
				RecordTutorialAnalyticsEvent(completed: false);
			}
		}

		private static void PlayAccomplishmentSound(float delay)
		{
			Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Design.TutorialStep, null, AudioLibrary.Design.TutorialStep.DefaultVolume, delay);
		}

		private static string ProcessStringWithMobileAlternative(string s)
		{
			bool isMobileBuild = Device.IsMobileBuild;
			while (true)
			{
				int num = s.IndexOf("[");
				int num2 = s.IndexOf("]");
				if (num < 0 || num2 < 0)
				{
					break;
				}
				string text = s.Substring(num, num2 - num + 1);
				string[] array = text.Trim('[', ']').Split(new char[1] { '|' });
				if (array.Length == 2)
				{
					s = s.Replace(text, isMobileBuild ? array[1] : array[0]);
				}
			}
			return s;
		}

		private void AnimateHighlightColors()
		{
			_highlightTime += Time.deltaTime;
			float t = (Mathf.Sin(_highlightTime * 10f) + 1f) / 2f;
			Color color = Color.Lerp(new Color32(0, byte.MaxValue, 0, 128), new Color32(0, byte.MaxValue, 0, 32), t);
			TargetPartMaterial.color = color;
			Color gamma = Constants.Colors.Primary.Gamma;
			gamma *= 0.7f;
			color = Color.Lerp(Constants.Colors.Primary.Gamma, gamma, t);
			SolidPartMaterial.color = color;
			float num = (Mathf.Sin(_highlightTime * 5f) + 1f) / 2f;
			float num2 = 0.25f;
			float a = num2 + (1f - num2) * num;
			_highlightColor = new Color(0f, 1f, 0f, a);
		}

		private void LateUpdate()
		{
			if (DebugInput.GetKeyDown(KeyCode.X))
			{
				_tutorialPanel.gameObject.SetActive(value: false);
				base.gameObject.SetActive(value: false);
				DesignerScript.OnTutorialComplete(this);
			}
			if (!_firstFrame)
			{
				_firstFrame = true;
				DesignerScript.ShowMessage(string.Empty);
			}
			if (DebugInput.GetKeyDown(KeyCode.K))
			{
				Debug.LogFormat("Current Part Position: {0}", Utilities.Vector3ToString(DesignerScript.SelectedPart.Transform.position));
			}
			if (DesignerScript.CraftScript != null)
			{
				CurrentStep.Update();
				AnimateHighlightColors();
				if (_highlightTarget != null)
				{
					StartCoroutine(UpdateHighlight(_highlightTarget));
				}
				else
				{
					_tutorialPanel.DisableHighlight();
				}
			}
		}

		private void LoadStep(int stepIndex)
		{
			TutorialStep tutorialStep = Steps[stepIndex];
			tutorialStep.LoadStep();
			ShowPanelType(tutorialStep.PanelType);
			_tutorialPanel.UpdateStepNumberText(_step + 1, Steps.Count, tutorialStep.CanSkip);
			this.StepLoaded?.Invoke(this, tutorialStep);
		}

		private void RecordTutorialAnalyticsEvent(bool completed)
		{
			if (Game.Instance.Analytics.Enabled)
			{
				try
				{
					FlightStateData flightStateData = Game.Instance.GameState.LoadFlightStateData();
					Dictionary<string, object> eventData = new Dictionary<string, object>
					{
						{
							"TutorialId",
							Tutorial.GetType()?.Name ?? string.Empty
						},
						{ "TutorialCompleted", completed },
						{ "TutorialStepIndex", _step },
						{
							"PlaytimeInSeconds",
							(int)(Game.Instance.Analytics.SceneTimeTracker?.TimeInScene ?? 0.0)
						},
						{
							"CareerPlaytimeInMinutes",
							(int)((flightStateData?.TotalFlightTimeInRealtimeSeconds ?? 0.0) / 60.0)
						}
					};
					Game.Instance.Analytics.LogEvent("TutorialAttempt", eventData);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		private IEnumerator UpdateHighlight(HighlightTarget target)
		{
			yield return new WaitForEndOfFrame();
			RectTransform component = _tutorialPanel.GetComponent<RectTransform>();
			Vector2[] array = new Vector2[4];
			UiUtilities.GetRectCornersInLocalSpace(target.Target, component, array, null);
			Vector2 vector = (array[0] + array[2]) / 2f;
			Vector2 vector2 = array[2] - array[0];
			if (vector2.x > 2f && vector2.y > 2f)
			{
				_tutorialPanel.EnableHighlight(vector, (int)Mathf.Abs(vector2.x + target.Padding.x), (int)Mathf.Abs(vector2.y + target.Padding.y), _highlightColor, target.ScrollRect);
			}
			else
			{
				_tutorialPanel.DisableHighlight();
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Packages.SocialPlatforms.Achievements;
using Assets.Scripts.Career.Contracts;
using Assets.Scripts.Career.Research;
using Assets.Scripts.Input;
using Assets.Scripts.Menu.ListView;
using Assets.Scripts.Menu.ListView.Career;
using Assets.Scripts.State;
using Assets.Scripts.Ui;
using ModApi.Ui;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Menu.Tutorial
{
	public class MenuTutorialPanelScript : TutorialPanelBaseScript
	{
		private const string CarsId = "droolover";

		private const string RocketsId = "rockets";

		public static int CareerDialogStep { get; private set; }

		public static bool IsTutorialComplete
		{
			get
			{
				return Game.Instance.GameState.MenuTutorialComplete;
			}
			private set
			{
				Game.Instance.GameState.MenuTutorialComplete = value;
			}
		}

		public GameMenuScript GameMenu { get; set; }

		private static int CareerDialogIntroStep { get; set; }

		public static MenuTutorialPanelScript ShowTutorial()
		{
			CareerState career = Game.Instance.GameState.Career;
			if (career != null && career.IsStock && !IsTutorialComplete)
			{
				GameObject gameObject = UiUtilities.CreateUiGameObject("TutorialPanel", Game.Instance.UserInterface.Transform);
				MenuTutorialPanelScript tutorialPanel = gameObject.AddComponent<MenuTutorialPanelScript>();
				Game.Instance.UserInterface.BuildUserInterfaceFromResource("Ui/Xml/Menu/MenuTutorialPanel", tutorialPanel, delegate(IXmlLayoutController x)
				{
					tutorialPanel.OnLayoutRebuilt((XmlLayout)x.XmlLayout);
				});
				return tutorialPanel;
			}
			return null;
		}

		public override void CloseTutorial()
		{
			base.CloseTutorial();
			RecordTutorialAnalyticsEvent(IsTutorialComplete);
			if (IsTutorialComplete)
			{
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.TutorialCareerIntro);
			}
			IsTutorialComplete = true;
		}

		public override void OnLayoutRebuilt(XmlLayout xmlLayout)
		{
			base.OnLayoutRebuilt(xmlLayout);
			if (Game.InMenuScene)
			{
				base.Panel.AddClass("scene-menu");
			}
			else if (Game.InTechTreeScene)
			{
				base.Panel.AddClass("scene-tech-tree");
			}
		}

		protected override void LateUpdate()
		{
			base.LateUpdate();
			if (Game.IsCareer)
			{
				CareerState career = Game.Instance.GameState.Career;
				if (Game.InMenuScene)
				{
					UpdateMenu(career);
				}
				else if (Game.InTechTreeScene)
				{
					UpdateTechTree(career);
				}
			}
			if (DebugInput.GetKeyDown(KeyCode.F5))
			{
				UnityEngine.Object.Destroy(base.gameObject);
				ShowTutorial();
			}
		}

		private static bool IsTechFinished(CareerState career)
		{
			if (career.TechTree.GetNode("crew").Researched && career.TechTree.GetNode("common").Researched)
			{
				if (!career.TechTree.GetNode("droolover").Researched)
				{
					return career.TechTree.GetNode("rockets").Researched;
				}
				return true;
			}
			return false;
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
							GetType().Name
						},
						{ "TutorialCompleted", completed },
						{ "TutorialStepIndex", CareerDialogStep },
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

		private void UpdateMenu(CareerState career)
		{
			DisableButton();
			DisableHighlight();
			GameMenu.HideWhatsNewPanel();
			CareerDialogScript careerDialogScript = UnityEngine.Object.FindObjectOfType<CareerDialogScript>();
			if (careerDialogScript != null)
			{
				base.transform.SetSiblingIndex(careerDialogScript.transform.GetSiblingIndex() + 1);
			}
			if (IsTechFinished(career))
			{
				if (careerDialogScript != null)
				{
					base.Panel.AddClass("scene-menu-career");
					if (CareerDialogStep == 0)
					{
						if (careerDialogScript.SelectedViewId == "contracts")
						{
							base.StepText = "This is where you will find contracts. By completing them, you will get money necessary to launch new crafts, and better launch locations. You can see your currently available funds at the top of the screen.";
							EnableButton(delegate
							{
								CareerDialogStep++;
							});
						}
						else
						{
							base.StepText = "Click on the Contracts tab.";
							HighlightUiElement("Career.Tab.Contracts", Vector2.zero);
						}
					}
					else if (CareerDialogStep == 1)
					{
						if (careerDialogScript.SelectedViewId == "milestones")
						{
							base.StepText = "In order to use my patents, I need you to prove that you deserve it. For this, I have set up these Milestones. By reaching them, you will earn Tech Points which you can use to unlock new technology in the Tech Tree. You can see how many Tech Points you have at the top of the screen.";
							EnableButton(delegate
							{
								CareerDialogStep++;
							});
						}
						else
						{
							base.StepText = "Click on the Milestones tab.";
							HighlightUiElement("Career.Tab.Milestones", Vector2.zero);
						}
					}
					else if (CareerDialogStep == 2)
					{
						if (careerDialogScript.SelectedViewId == "exploration")
						{
							ListViewItemScript listViewItemScript = careerDialogScript.Exploration.Items.Where((ListViewItemScript x) => x.Title == "Droo").FirstOrDefault();
							if (!(listViewItemScript != null))
							{
								return;
							}
							if (listViewItemScript.Selected)
							{
								base.StepText = "Here are the landmarks you can visit and additional milestones you can do in each Celestial Body. You can click them to see more details.";
								EnableButton(delegate
								{
									CareerDialogStep++;
								});
								return;
							}
							base.StepText = "Here you can find the exploration related milestones. Click on Droo.";
							if (listViewItemScript.VisibleInScrollView)
							{
								HighlightUiElement("EXPLORATION.Droo", new Vector2(0f, 0f));
							}
						}
						else
						{
							base.StepText = "Click on the Exploration tab.";
							HighlightUiElement("Career.Tab.Exploration", Vector2.zero);
						}
					}
					else
					{
						if (CareerDialogStep != 3)
						{
							return;
						}
						if (careerDialogScript.SelectedViewId == "contracts")
						{
							Contract contract = career.Contracts.All.Where((Contract x) => x.Id == "Vertical-Shot" || x.Id == "The-Jump").FirstOrDefault();
							if (contract != null && !contract.IsClosed)
							{
								if (contract.Status == ContractStatus.Generated)
								{
									IsTutorialComplete = true;
									base.StepText = "Select the " + contract.Name + " contract and then click Start Tutorial to accept this contract and begin a designer tutorial.";
									ListViewItemScript listViewItemScript2 = careerDialogScript.Contracts.Items.Where((ListViewItemScript x) => x.Title == contract.Name).FirstOrDefault();
									if (listViewItemScript2 != null && !listViewItemScript2.Selected)
									{
										HighlightUiElement("CONTRACTS." + listViewItemScript2.Title, new Vector2(0f, 0f));
									}
								}
								else if (contract.Status == ContractStatus.Active)
								{
									base.StepText = "Fantastic! I highly recommend doing the tutorial for this contract. Otherwise, you can click Build in the bottom left to enter the designer to start building your craft. Click Okay and get started! Good luck!";
									IsTutorialComplete = true;
									EnableButton(delegate
									{
										CloseTutorial();
									});
								}
							}
							else
							{
								CloseTutorial();
							}
						}
						else
						{
							base.StepText = "Let's go back to Contracts and accept a contract. It's time to start your career!";
							HighlightUiElement("Career.Tab.Contracts", Vector2.zero);
						}
					}
				}
				else
				{
					base.StepText = "Open the Career dialog.";
					HighlightUiElement("CareerButton", new Vector2(-90f, 0f));
				}
			}
			else if (CareerDialogIntroStep == 0)
			{
				base.StepText = "Congratulations on starting your own aerospace company! It's a tough business, but with my connections I can help you succeed. Please, allow me to introduce myself: I am Algernon Fizzlebottom.";
				EnableButton(delegate
				{
					CareerDialogIntroStep++;
				}, highlight: false);
			}
			else
			{
				HighlightUiElement("TechTreeButton", new Vector2(-90f, 0f));
				base.StepText = "I have recently inherited my grandfather's research company and I own many technology patents. I don't have time to chase the stars myself, so I have decided to offer incentives to new aerospace companies to help them get started. Let's go to the Tech Tree and see what I can offer you.";
			}
		}

		private void UpdateTechTree(CareerState career)
		{
			DisableButton();
			if (!IsTechFinished(career))
			{
				TechNode node = career.TechTree.GetNode("crew");
				TechNode node2 = career.TechTree.GetNode("common");
				if (!node.Researched)
				{
					base.StepText = "Welcome to the Tech Tree. Click on '" + node.Name + "' to see what technologies it contains and then click Unlock. This one won't cost any Tech Points, so it is a great bargain.";
					return;
				}
				if (!node2.Researched)
				{
					base.StepText = "Fantastic! Now unlock '" + node2.Name + "'. It is also free.";
					return;
				}
				TechNode node3 = career.TechTree.GetNode("droolover");
				TechNode node4 = career.TechTree.GetNode("rockets");
				base.StepText = "Now it is up to you to choose your path. Do you want to start with '" + node4.Name + "' and build rockets or start with '" + node3.Name + "' and build cars and planes? You only have enough Tech Points for one, so choose wisely!";
			}
			else
			{
				HighlightUiElement("ExitTechTreeButton", new Vector2(4f, 4f));
				base.StepText = "You don't have access to any more technologies for now, so let me show you how to get more Tech Points. Click the back button at the top left to exit the Tech Tree.";
			}
		}
	}
}

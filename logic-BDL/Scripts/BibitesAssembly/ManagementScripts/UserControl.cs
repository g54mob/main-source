using System;
using System.Collections.Generic;
using System.Linq;
using PropertiesScripts;
using ScriptHelpers;
using SimulationScripts;
using SimulationScripts.BibiteScripts;
using UnityEngine;
using UnityEngine.Events;

namespace ManagementScripts
{
	public class UserControl : MonoBehaviour
	{
		public static UserControl Instance;

		private EscapableAction bibiteSelectedAction;

		public GameObject autoPanner;

		public GameObject mainUI;

		public TimeController timev;

		private TargetableObject targetable;

		public GameObject target;

		[NonSerialized]
		public UnityEvent<GameObject> onTargetChange = new UnityEvent<GameObject>();

		public Action toRepeatOnDeath;

		public static bool AllowControl = true;

		public static List<string> KeyboardControlBlockStack = new List<string>();

		public static bool AllowKeyboardControl => KeyboardControlBlockStack.Count < 1;

		public static void ClearBlockStack()
		{
			KeyboardControlBlockStack.Clear();
		}

		public static void SetKeyboardBlockFromSource(string source, bool block)
		{
			if (block && !KeyboardControlBlockStack.Contains(source))
			{
				KeyboardControlBlockStack.Add(source);
			}
			else if (!block && KeyboardControlBlockStack.Contains(source))
			{
				KeyboardControlBlockStack.Remove(source);
			}
		}

		private void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			else
			{
				UnityEngine.Object.Destroy(this);
			}
			bibiteSelectedAction = new EscapableAction(delegate
			{
				SelectTarget(null);
			});
			TargetableObject.CanInvoke = true;
		}

		private void Update()
		{
			if (!AllowControl || !AllowKeyboardControl)
			{
				return;
			}
			if (Input.GetKeyDown(KeyCode.H))
			{
				mainUI.SetActive(!mainUI.activeSelf);
			}
			if (Input.GetKeyDown(KeyCode.Space))
			{
				timev.TogglePauseGame();
			}
			if (Input.GetKeyDown(KeyCode.K))
			{
				SelectTarget(autoPanner);
			}
			if (Input.GetKeyDown(KeyCode.Z))
			{
				SelectTarget(ZoneManager.instance.zones.RandomElement().gameObject);
			}
			int nBibite = WorldObjectsSpawner.Instance.nBibite;
			if (nBibite > 0 && Input.GetKeyDown(KeyCode.R))
			{
				SelectRandomBibite();
			}
			if (nBibite > 0 && Input.GetKeyDown(KeyCode.G))
			{
				SelectHighGenBibite();
			}
			if (Input.GetKeyDown(KeyCode.O))
			{
				SelectOldestBibite();
			}
			if (Input.GetKeyDown(KeyCode.E))
			{
				SelectRandomEgg();
			}
			if (!ChallengeManager.isChallenge)
			{
				if (Input.GetKeyDown(KeyCode.F5))
				{
					SaveController.Instance.QuickSave();
				}
				if (Input.GetKeyDown(KeyCode.Insert))
				{
					GUIManager.Instance.LayEggIfBibite();
				}
				if (Input.GetKeyDown(KeyCode.Delete))
				{
					GUIManager.Instance.TryKillTarget();
				}
			}
		}

		private void SelectRandomBibite()
		{
			SelectTarget(WorldObjectsSpawner.Instance.allBibites.Where((GameObject g) => !g.GetComponent<BibiteBody>().dying).RandomElement());
			if (Input.GetKey(KeyCode.LeftControl))
			{
				toRepeatOnDeath = SelectRandomBibite;
			}
		}

		private void SelectOldestBibite()
		{
			GameObject newTarget = WorldObjectsSpawner.Instance.allBibites.Where((GameObject g) => !g.GetComponent<BibiteBody>().dying).MaxBy((GameObject b) => b.GetComponent<InternalClock>().timeAlive);
			SelectTarget(newTarget);
			if (Input.GetKey(KeyCode.LeftControl))
			{
				toRepeatOnDeath = SelectOldestBibite;
			}
		}

		private void SelectHighGenBibite()
		{
			GameObject newTarget = WorldObjectsSpawner.Instance.allBibites.Where((GameObject g) => !g.GetComponent<BibiteBody>().dying).MaxBy((GameObject b) => b.GetComponent<BibiteGenes>().generation);
			SelectTarget(newTarget);
			if (Input.GetKey(KeyCode.LeftControl))
			{
				toRepeatOnDeath = SelectHighGenBibite;
			}
		}

		private void SelectRandomEgg()
		{
			List<EggHatching> list = (from g in WorldObjectsSpawner.Instance.allEggs
				select g.GetComponent<EggHatching>() into g
				where !g.aborting
				select g).ToList();
			if (list.Count >= 1)
			{
				SelectTarget(list.RandomElement().gameObject);
			}
		}

		public void SelectClosestEntity()
		{
			float num = float.MaxValue;
			Vector3 position = CameraManager.instance.transform.position;
			position.z = 0f;
			GameObject newTarget = null;
			foreach (Transform item in WorldObjectsSpawner.Instance.bibiteHolder.transform)
			{
				float sqrMagnitude = (item.position - position).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					newTarget = item.gameObject;
				}
			}
			foreach (Transform item2 in WorldObjectsSpawner.Instance.colorKillerHolder.transform)
			{
				float sqrMagnitude2 = (item2.position - position).sqrMagnitude;
				if (sqrMagnitude2 < num)
				{
					num = sqrMagnitude2;
					newTarget = item2.gameObject;
				}
			}
			SelectTarget(newTarget);
		}

		public void SelectTarget(GameObject newTarget)
		{
			if (target == newTarget)
			{
				return;
			}
			if (newTarget != null)
			{
				TargetableObject component = newTarget.GetComponent<TargetableObject>();
				if (component == null)
				{
					return;
				}
				ClearTargetListener();
				component.onDestroy.AddListener(TargetDied);
				targetable = component;
				if (target == null)
				{
					UINavigationManager.AddEscapableToStack(bibiteSelectedAction);
				}
			}
			else
			{
				toRepeatOnDeath = null;
				UINavigationManager.RemoveEscapableFromStack(bibiteSelectedAction);
			}
			target = newTarget;
			onTargetChange.Invoke(newTarget);
		}

		public void SelectRandomBibiteOfTag(string tagName)
		{
			List<GameObject> list = (from a in WorldObjectsSpawner.Instance.bibiteHolder.GetAllChilds()
				orderby UnityEngine.Random.value
				select a).ToList();
			if (tagName == "Untagged")
			{
				tagName = "";
			}
			if (Input.GetKey(KeyCode.LeftControl))
			{
				toRepeatOnDeath = delegate
				{
					SelectRandomBibiteOfTag(tagName);
				};
			}
			foreach (GameObject item in list)
			{
				if (!(item.GetComponent<BibiteGenes>().speciesTag != tagName))
				{
					SelectTarget(item);
					break;
				}
			}
		}

		public void SelectRandomBibiteOfSpecies(Species species)
		{
			if (species == null)
			{
				return;
			}
			if (species.bibites.Count > 0)
			{
				SelectTarget(species.bibites.RandomElement().gameObject);
			}
			else if (species.eggs.Count > 0)
			{
				SelectTarget(species.eggs.RandomElement().gameObject);
			}
			if (Input.GetKey(KeyCode.LeftControl))
			{
				toRepeatOnDeath = delegate
				{
					SelectRandomBibiteOfSpecies(species);
				};
			}
		}

		private void TargetDied()
		{
			if (toRepeatOnDeath == null)
			{
				if (target != null)
				{
					EggHatching component = target.GetComponent<EggHatching>();
					if (component != null && component.newBornBody != null)
					{
						SelectTarget(component.newBornBody.gameObject);
						return;
					}
				}
				ClearTarget();
			}
			else
			{
				toRepeatOnDeath();
			}
		}

		private void ClearTarget()
		{
			ClearTargetListener();
			SelectTarget(null);
		}

		private void ClearTargetListener()
		{
			if (!(targetable == null))
			{
				targetable.onDestroy.RemoveListener(TargetDied);
				targetable = null;
			}
		}

		public bool CompareTarget(GameObject GO)
		{
			return GO == target;
		}

		private void OnApplicationQuit()
		{
			TargetableObject.CanInvoke = false;
		}
	}
}

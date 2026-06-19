using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DevCmdLine.UI
{
	internal class DevCmdOptionsManagerUI : MonoBehaviour
	{
		public RectTransform container;

		public GameObject template;

		public Transform optionsContainer;

		public GridLayoutGroup gridGroup;

		private List<DevCmdOptionUI> _uis = new List<DevCmdOptionUI>();

		private List<DevCmdOptionUIBase> _options = new List<DevCmdOptionUIBase>();

		private DevCmdOptionUIBase _activeOption;

		private List<object> _contexts = new List<object>();

		private List<DevCmdSubOption> _subOptions;

		private Selectable _onLeft;

		private void Awake()
		{
			template.SetActive(value: false);
		}

		public void SetInitials(Selectable onLeft)
		{
			for (int i = 0; i < _uis.Count; i++)
			{
				_uis[i].gameObject.SetActive(value: false);
			}
			_contexts.Clear();
			_subOptions = null;
			_activeOption = null;
			_onLeft = onLeft;
			int num = 0;
			for (int j = 0; j < optionsContainer.transform.childCount; j++)
			{
				GameObject gameObject = optionsContainer.transform.GetChild(j).gameObject;
				if (gameObject == null || !gameObject.activeInHierarchy)
				{
					continue;
				}
				DevCmdOptionUIBase component = gameObject.GetComponent<DevCmdOptionUIBase>();
				if (component == null)
				{
					Debug.LogWarning("Initial option does not implement IDevConsoleOptionUI", gameObject);
					continue;
				}
				_options.Add(component);
				if (component.TryGetInitial(out var optionStr, out var isEnd))
				{
					if (num == _uis.Count)
					{
						GameObject gameObject2 = Object.Instantiate(template);
						gameObject2.transform.SetParent(container);
						gameObject2.transform.localPosition = Vector3.zero;
						gameObject2.transform.localScale = Vector3.one;
						gameObject2.transform.localRotation = Quaternion.identity;
						gameObject2.transform.SetSiblingIndex(_uis.Count);
						_uis.Add(gameObject2.GetComponent<DevCmdOptionUI>());
					}
					DevCmdOptionUI devCmdOptionUI = _uis[num];
					devCmdOptionUI.gameObject.SetActive(value: true);
					if (isEnd)
					{
						devCmdOptionUI.Set(optionStr + " [END]", OnInitialEndSelected, _options.Count - 1);
					}
					else
					{
						devCmdOptionUI.Set(optionStr, OnInitialOptionSelected, _options.Count - 1);
					}
					num++;
				}
			}
			SetNavigation(onLeft);
		}

		public GameObject GetFirstOption()
		{
			return _uis[0].gameObject;
		}

		private void OnInitialOptionSelected(int index)
		{
			_subOptions = (_activeOption = _options[index]).Selected(_contexts);
			SetSubOptions();
		}

		private void OnInitialEndSelected(int index)
		{
			DevCmdOptionUIBase devCmdOptionUIBase = _options[index];
			string cmd = devCmdOptionUIBase.ConstructCmd(_contexts);
			if (devCmdOptionUIBase.closeOnExecution)
			{
				DevCmdConsole.CloseConsoleWithCallback();
			}
			DevCmdManager.RunCommand(cmd);
		}

		private void OnSubOptionSelected(int index)
		{
			DevCmdSubOption devCmdSubOption = _subOptions[index];
			_contexts.Add(devCmdSubOption.context);
			_subOptions = _activeOption.Selected(_contexts);
			SetSubOptions();
		}

		private void OnSubOptionEndSelected(int index)
		{
			DevCmdSubOption devCmdSubOption = _subOptions[index];
			_contexts.Add(devCmdSubOption.context);
			DevCmdManager.RunCommand(_activeOption.ConstructCmd(_contexts));
			_contexts.RemoveAt(_contexts.Count - 1);
		}

		private void SetSubOptions()
		{
			for (int i = 0; i < _uis.Count; i++)
			{
				_uis[i].gameObject.SetActive(value: false);
			}
			while (_uis.Count < _subOptions.Count + 1)
			{
				GameObject gameObject = Object.Instantiate(template);
				gameObject.transform.SetParent(container);
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localRotation = Quaternion.identity;
				gameObject.transform.SetSiblingIndex(_uis.Count);
				_uis.Add(gameObject.GetComponent<DevCmdOptionUI>());
			}
			for (int j = 0; j < _subOptions.Count; j++)
			{
				DevCmdSubOption devCmdSubOption = _subOptions[j];
				DevCmdOptionUI devCmdOptionUI = _uis[j];
				devCmdOptionUI.gameObject.SetActive(value: true);
				if (devCmdSubOption.isEnd)
				{
					devCmdOptionUI.Set(devCmdSubOption.text + " [END]", OnSubOptionEndSelected, j);
				}
				else
				{
					devCmdOptionUI.Set(devCmdSubOption.text, OnSubOptionSelected, j);
				}
			}
			DevCmdOptionUI devCmdOptionUI2 = _uis[_subOptions.Count];
			devCmdOptionUI2.gameObject.SetActive(value: true);
			devCmdOptionUI2.Set("Back", GoBack, -1);
			SetNavigation(_onLeft);
			EventSystem.current.SetSelectedGameObject(_uis[0].gameObject);
		}

		public void GoBack()
		{
			GoBack(-1);
		}

		private void GoBack(int throwaway)
		{
			if (_contexts.Count == 0)
			{
				SetInitials(_onLeft);
				EventSystem.current.SetSelectedGameObject(_uis[0].gameObject);
			}
			else
			{
				_contexts.RemoveAt(_contexts.Count - 1);
				_subOptions = _activeOption.Selected(_contexts);
				SetSubOptions();
			}
		}

		private void SetNavigation(Selectable onLeft)
		{
			int constraintCount = gridGroup.constraintCount;
			for (int i = 0; i < _uis.Count; i++)
			{
				int num = i / constraintCount;
				int num2 = i % constraintCount;
				Navigation navigation = new Navigation
				{
					mode = Navigation.Mode.Explicit
				};
				if (num == 0)
				{
					navigation.selectOnLeft = onLeft;
				}
				else
				{
					navigation.selectOnLeft = _uis[(num - 1) * constraintCount + num2].GetComponent<Selectable>();
				}
				if (num2 == 0)
				{
					navigation.selectOnUp = null;
				}
				else
				{
					navigation.selectOnUp = _uis[num * constraintCount + (num2 - 1)].GetComponent<Selectable>();
				}
				int num3 = (num + 1) * constraintCount + num2;
				if (num3 < _uis.Count)
				{
					navigation.selectOnRight = _uis[num3].GetComponent<Selectable>();
				}
				else
				{
					navigation.selectOnRight = null;
				}
				int num4 = num * constraintCount + num2 + 1;
				if (num2 + 1 < constraintCount && num4 < _uis.Count)
				{
					navigation.selectOnDown = _uis[num4].GetComponent<Selectable>();
				}
				else
				{
					navigation.selectOnDown = null;
				}
				_uis[i].GetComponent<Selectable>().navigation = navigation;
			}
		}
	}
}

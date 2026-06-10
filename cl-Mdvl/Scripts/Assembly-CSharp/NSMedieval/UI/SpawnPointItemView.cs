using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.View.UI;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class SpawnPointItemView : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text positionText;

		[SerializeField]
		private TMP_Dropdown pointTypeDropDown;

		[SerializeField]
		private TMP_InputField setInput;

		[SerializeField]
		private SoundButton selectButton;

		[SerializeField]
		private GameObject selectedObject;

		private SpawnPoint spawnPoint;

		private Dictionary<SpawnPointType, int> indexOfType;

		private SpawnPointType selectedType;

		private Action<SpawnPoint> selectPointAction;

		private Action<SpawnPoint> typeChangedAction;

		private void Awake()
		{
			selectButton.onClick.AddListener(OnSelected);
			indexOfType = new Dictionary<SpawnPointType, int>();
			setInput.onValueChanged.RemoveAllListeners();
			setInput.onEndEdit.AddListener(OnSetChanged);
			SetupType();
		}

		private void OnDestroy()
		{
			selectPointAction = null;
			typeChangedAction = null;
		}

		public void Setup(SpawnPoint spawnPoint, Action<SpawnPoint> selectPointAction, Action<SpawnPoint> typeChangedAction)
		{
			this.spawnPoint = spawnPoint;
			this.selectPointAction = selectPointAction;
			this.typeChangedAction = typeChangedAction;
			positionText.text = $"X:{spawnPoint.Position.x} Y:{spawnPoint.Position.y} Z:{spawnPoint.Position.z}";
			setInput.text = this.spawnPoint.SetIndex.ToString();
			pointTypeDropDown.SetValueWithoutNotify(indexOfType[spawnPoint.Type]);
		}

		public void SetSelected(bool selected)
		{
			selectedObject.SetActive(selected);
		}

		public void SetPosition(Vec3Int position)
		{
			positionText.text = $"X:{position.x} Y:{position.y} Z:{position.z}";
		}

		private void SetupType()
		{
			pointTypeDropDown.onValueChanged.RemoveAllListeners();
			pointTypeDropDown.ClearOptions();
			pointTypeDropDown.AddOptions(GetTypes());
			pointTypeDropDown.onValueChanged.AddListener(OnTypeChanged);
			selectedType = indexOfType.FirstOrDefault().Key;
			SpawnPointType spawnPointType = selectedType;
			if (spawnPointType != SpawnPointType.None && indexOfType != null && indexOfType.ContainsKey(spawnPointType))
			{
				pointTypeDropDown.SetValueWithoutNotify(indexOfType[spawnPointType]);
			}
		}

		private List<TMP_Dropdown.OptionData> GetTypes()
		{
			indexOfType.Clear();
			List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
			int num = 0;
			foreach (SpawnPointType value in Enum.GetValues(typeof(SpawnPointType)))
			{
				if (value != SpawnPointType.None)
				{
					indexOfType.Add(value, num++);
					list.Add(new TMP_Dropdown.OptionData(value.ToString()));
				}
			}
			return list;
		}

		private void OnTypeChanged(int index)
		{
			if (index != -1)
			{
				SpawnPointType type = (selectedType = indexOfType.FirstOrDefault((KeyValuePair<SpawnPointType, int> item) => item.Value == index).Key);
				spawnPoint.Type = type;
				typeChangedAction?.Invoke(spawnPoint);
			}
		}

		private void OnSetChanged(string value)
		{
			int num = int.Parse(value);
			if (num < 0)
			{
				spawnPoint.SetIndex = 0;
				setInput.text = "0";
			}
			else
			{
				spawnPoint.SetIndex = num;
			}
		}

		private void OnSelected()
		{
			selectPointAction?.Invoke(spawnPoint);
		}
	}
}

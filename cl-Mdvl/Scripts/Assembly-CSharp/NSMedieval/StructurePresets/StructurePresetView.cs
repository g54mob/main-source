using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.UI;
using TMPro;
using UnityEngine;

namespace NSMedieval.StructurePresets
{
	public class StructurePresetView : PopupView
	{
		[SerializeField]
		private SoundButton saveButton;

		[SerializeField]
		private SoundButton selectButton;

		[SerializeField]
		private SoundButton placeButton;

		[SerializeField]
		private SoundButton deleteButton;

		[SerializeField]
		private SoundButton deleteAllButton;

		[SerializeField]
		private TMP_InputField nameInput;

		[SerializeField]
		private LayoutGroupView groupsParent;

		[SerializeField]
		private SoundButton closeButton;

		[SerializeField]
		private GameObject presetPrefab;

		private List<GameObject> presets = new List<GameObject>();
	}
}

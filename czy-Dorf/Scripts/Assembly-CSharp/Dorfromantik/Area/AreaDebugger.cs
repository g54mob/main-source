using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Dorfromantik.Area
{
	public class AreaDebugger : MonoBehaviour
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Func<AreaSlot, bool> _003C_003E9__9_0;

			public static Func<AreaSlot, bool> _003C_003E9__9_1;

			internal bool _003CDisplayGridPosForAllAreaSlots_003Eb__9_0(AreaSlot x)
			{
				return x != null;
			}

			internal bool _003CDisplayGridPosForAllAreaSlots_003Eb__9_1(AreaSlot x)
			{
				return x != null;
			}
		}

		[SerializeField]
		private AreaManager areaManager;

		private List<Area> previewAreas;

		private PreviewAreaGenerator previewAreaGenerator;

		private AreaGenerator areaGenerator;

		[SerializeField]
		private TextMeshPro textPrefab;

		private void Start()
		{
			previewAreaGenerator = areaManager.GetComponent<PreviewAreaGenerator>();
			areaGenerator = areaManager.GetComponent<AreaGenerator>();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Keypad0))
			{
				Debug.Log("Nothing to debug.");
			}
			if (Input.GetKeyDown(KeyCode.Keypad1))
			{
				areaManager.CreatePreviewAreas(null);
				ColorizePreviewAreasRandomly();
			}
			if (Input.GetKeyDown(KeyCode.Keypad2))
			{
				DisplayGridPosForAllAreaSlots();
			}
			if (Input.GetKeyDown(KeyCode.Keypad4))
			{
				DisplayAreaNames();
			}
		}

		private void ColorizeSegments()
		{
			foreach (KeyValuePair<AreaSlot, List<AreaSlot>> item in previewAreaGenerator.segmentByEdgeAreaSlot)
			{
				Material sharedMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"))
				{
					color = UnityEngine.Random.ColorHSV()
				};
				foreach (AreaSlot item2 in item.Value)
				{
					item2.GetComponentInChildren<Renderer>().sharedMaterial = sharedMaterial;
				}
			}
		}

		private void ColorizePreviewAreasRandomly()
		{
			foreach (Area localPreviewArea in areaManager.LocalPreviewAreas)
			{
				Material sharedMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"))
				{
					color = UnityEngine.Random.ColorHSV()
				};
				foreach (AreaSlot areaSlot in localPreviewArea.AreaSlots)
				{
					areaSlot.GetComponentInChildren<Renderer>().sharedMaterial = sharedMaterial;
				}
			}
		}

		private void DisplayGridPosForAllAreaSlots()
		{
			foreach (AreaSlot item in Enumerable.Where(areaManager.GlobalPlayableArea.AreaSlots, (AreaSlot x) => x != null))
			{
				UnityEngine.Object.Instantiate(textPrefab, item.transform).text = item.GridPos.ToString();
			}
			foreach (AreaSlot item2 in Enumerable.Where(areaManager.GlobalPreviewArea.AreaSlots, (AreaSlot x) => x != null))
			{
				UnityEngine.Object.Instantiate(textPrefab, item2.transform).text = item2.GridPos.ToString();
			}
		}

		private void DisplayAreaNames()
		{
			if (areaManager.LocalPreviewAreas.Count <= 0)
			{
				return;
			}
			foreach (Area localPreviewArea in areaManager.LocalPreviewAreas)
			{
				AreaSlot areaSlot = Enumerable.FirstOrDefault(localPreviewArea.AreaSlots);
				TextMeshPro textMeshPro = UnityEngine.Object.Instantiate(textPrefab, areaSlot.transform);
				textMeshPro.text = Enumerable.Last(localPreviewArea.name).ToString();
				textMeshPro.fontSize = 120f;
			}
		}
	}
}

using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Jet
{
	public class JetEngineShroudScript : PartModifierScript
	{
		private JetEngineData _jetEngine;

		private bool _materialDirty;

		private Transform _rearHalf;

		private string _shroudId;

		private GameObject _subPartShroud;

		public JetEngineShroudData Data { get; set; }

		public CraftEngineType EngineType => CraftEngineType.Jet;

		public void OnModifiersCreated()
		{
		}

		public void UpdateStyles()
		{
			LoadShroud(Data.ShroudPrefab);
			_subPartShroud.transform.localScale = Data.Radius * new Vector3(0.978f, 0.978f, Data.Length);
			if (base.PartScript.LoadContext == CraftLoadContext.Designer)
			{
				base.PartScript.AttachPointScripts[1].transform.localPosition = new Vector3(0f, Data.Radius * 1.15f, 0f);
			}
			if (_materialDirty)
			{
				_materialDirty = false;
				base.PartScript.PartMaterialScript.InitializeMaterial();
			}
		}

		protected virtual void OnDestroy()
		{
			base.PartScript.Aircraft.OnAircraftStructureChanged -= OnCraftStructureChanged;
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();
			UpdateStyles();
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			base.RegisterUpdateMethods(in registrar);
			registrar.RegisterStart(FlightStart, CraftUpdateFlags.FlightDefault);
			registrar.RegisterUpdate(FlightUpdate, CraftUpdateFlags.FlightUnpaused);
		}

		private void DestroySubPart(GameObject subPart)
		{
			if (subPart != null)
			{
				MeshRenderer[] componentsInChildren = subPart.GetComponentsInChildren<MeshRenderer>();
				foreach (MeshRenderer renderer in componentsInChildren)
				{
					base.PartScript.PartMaterialScript.RemoveRenderer(renderer, destroy: true);
				}
				Object.DestroyImmediate(subPart);
			}
		}

		private void FlightStart(in CraftUpdateFrameData frame)
		{
			base.PartScript.Aircraft.OnAircraftStructureChanged += OnCraftStructureChanged;
			OnCraftStructureChanged();
			_rearHalf = Utilities.FindFirstGameObjectMyselfOrChildren("Rear", _subPartShroud)?.transform;
		}

		private void FlightUpdate(in CraftUpdateFrameData frame)
		{
			if (_jetEngine != null && _rearHalf != null)
			{
				_rearHalf.localPosition = Vector3.Lerp(Vector3.zero, new Vector3(0f, 0f, -0.4f), _jetEngine.Script.BrakeValue);
			}
		}

		private void LoadShroud(JetEnginePrefabs.ShroudPrefab shroudPrefab)
		{
			if (_shroudId != shroudPrefab.Id)
			{
				base.PartScript.EditorColliders.Clear();
				_shroudId = shroudPrefab.Id;
				DestroySubPart(_subPartShroud);
				_subPartShroud = LoadSubPart(shroudPrefab.prefab, base.transform);
				_subPartShroud.name = shroudPrefab.name;
				GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren("Front", _subPartShroud);
				if (gameObject != null)
				{
					gameObject.transform.localPosition = new Vector3(0f, 0f, 0.5f);
				}
				EnabledScript[] componentsInChildren = GetComponentsInChildren<EnabledScript>(includeInactive: true);
				foreach (EnabledScript enabledScript in componentsInChildren)
				{
					enabledScript.gameObject.SetActive(enabledScript.EnabledInDesigner == Game.Instance.SceneManager.InDesigner);
				}
			}
		}

		private GameObject LoadSubPart(GameObject prefab, Transform parent)
		{
			_materialDirty = true;
			GameObject gameObject = Object.Instantiate(prefab, parent);
			gameObject.layer = parent.gameObject.layer;
			gameObject.transform.localPosition = Vector3.zero;
			MeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer renderer in componentsInChildren)
			{
				base.PartScript.PartMaterialScript.AddRenderer(renderer, excludeFromCombine: true);
			}
			return gameObject;
		}

		private void OnCraftStructureChanged()
		{
			_jetEngine = Data.FindConnectedEngine();
		}
	}
}

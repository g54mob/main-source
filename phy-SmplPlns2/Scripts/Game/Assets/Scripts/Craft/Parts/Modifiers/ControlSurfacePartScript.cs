using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.MeshGen;
using Assets.Scripts.Craft.Parts.Events;
using Assets.Scripts.Craft.Wings;
using Assets.Scripts.Craft.Wings.ControlSurfaces;
using Assets.Scripts.Craft.Wings.Runtime;
using Assets.Scripts.Design;
using Cysharp.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class ControlSurfacePartScript : PartModifierScript
	{
		private ControlSurface _controlSurface;

		private ControlSurfacePartData _data;

		private InputWingSlice[] _dummySlices;

		private ControlSurface[] _dummySurfaceArray;

		private Vector3[] _dummySurfaceUVs;

		private bool _isAttachedToWing;

		private ProceduralPartMeshRenderer[] _renderers;

		private bool _readyToGenerate;

		public JWingScript ConnectedWing { get; private set; }

		public ControlSurface ControlSurface => _controlSurface;

		public ControlSurfacePartData Data => _data;

		public bool IsAttachedToWing
		{
			get
			{
				return _isAttachedToWing;
			}
			private set
			{
				if (_isAttachedToWing != value)
				{
					_isAttachedToWing = value;
					UpdateDummyMesh();
				}
			}
		}

		public JWingScript LastGeneratedWing { get; set; }

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			plan.Register(this, OnUpdateConnected, PreStartInitializationFlags.Default, 501);
			plan.Register(this, OnGenerateDummyMesh, PreStartInitializationFlags.Default, 504);
		}

		public ProceduralPartMeshRenderer[] GetRenderers(int num)
		{
			return _renderers = _renderers.Resize(num, (int i) => new ProceduralPartMeshRenderer(base.PartScript, $"Mesh-{i}", base.LoadContext, makeSubmeshes: true, null, null, excludeFromCombine: true), JWingScript.DestroyMeshColliders);
		}

		public void InitStyle(string style)
		{
			_controlSurface = ControlSurface.GetStyle(style);
		}

		public void OnDragEnd()
		{
			DesignerScript designerScript = Designer.Instance.DesignerScript;
			bool flag = false;
			if (ConnectedWing != null)
			{
				_data.UpdateDummyWingParams(ConnectedWing.Data);
				if (designerScript.IsConcealed(ConnectedWing.PartScript))
				{
					flag = true;
				}
			}
			bool flag2 = designerScript.IsConcealed(base.PartScript);
			if (flag && !flag2)
			{
				designerScript.AddPartToConcealedCollection(base.PartScript);
			}
			else if (!flag && flag2)
			{
				designerScript.RemovePartFromConcealedCollection(base.PartScript);
			}
		}

		protected void OnDestroy()
		{
			MeshCollider[] componentsInChildren = GetComponentsInChildren<MeshCollider>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				UnityEngine.Object.Destroy(componentsInChildren[i].sharedMesh);
			}
			if (_renderers != null)
			{
				ProceduralPartMeshRenderer[] renderers = _renderers;
				for (int i = 0; i < renderers.Length; i++)
				{
					renderers[i].Dispose();
				}
			}
			if (_data != null)
			{
				_data.OnDataChanged -= OnDataChanged;
			}
			base.PartScript.PartConnectionChanged -= UpdateConnectedWing;
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();
			_data = (ControlSurfacePartData)base.PartModifier;
			_data.OnDataChanged += OnDataChanged;
			base.PartScript.PartConnectionChanged += UpdateConnectedWing;
		}

		private void GenerateDummyWing(bool lastChance = false)
		{
			try
			{
				if (_dummySlices == null)
				{
					_dummySlices = new InputWingSlice[2];
					_dummySlices[0] = new InputWingSlice
					{
						Airfoil = "NACA0012",
						ChordSamples = 20,
						ColliderSamples = 8,
						IsSmoothJoin = true,
						Position = 0f,
						UseScale = true,
						UseOffset = true
					};
					_dummySlices[1] = new InputWingSlice
					{
						ChordSamples = 20,
						ColliderSamples = 8,
						IsSmoothJoin = true,
						UseOffset = true,
						UseScale = true
					};
				}
				_dummySlices[0].Scale = _data.DummyWingScale.x;
				_dummySlices[1].Scale = _data.DummyWingScale.y;
				_dummySlices[0].Offset = _data.DummyWingOffset.x;
				_dummySlices[1].Offset = _data.DummyWingOffset.y;
				_data.DummyControlSurface.CopySettingsTo(_controlSurface);
				_controlSurface.Range = new float2(0f, _data.DummyWingSpan);
				_dummySlices[1].Position = _data.DummyWingSpan;
				if (_dummySurfaceArray == null)
				{
					_dummySurfaceArray = new ControlSurface[1];
				}
				Data.ResetToDummyCS();
				_dummySurfaceArray[0] = _controlSurface;
				if (_dummySurfaceUVs == null)
				{
					_dummySurfaceUVs = new Vector3[1];
				}
				_dummySurfaceUVs[0] = new Vector3(base.PartScript.PartMaterialScript.MaterialIdPrimary, 0f, base.PartScript.Part.Id);
				WingBuilderInput input = new WingBuilderInput
				{
					parent = base.transform,
					inputSlices = _dummySlices,
					surfaces = _dummySurfaceArray,
					WingtipStyle = null,
					ControlSurfaceUVs = _dummySurfaceUVs,
					HideMainMesh = true,
					flipped = _data.IsFlipped,
					ThrowOnValidationFail = true,
					getPartMeshRenderers = (int num, int? _) => GetRenderers(num)
				};
				WingBuildOutput output;
				try
				{
					output = WingBuilder.Generate(input);
				}
				catch (ControlSurfaceValidationException ex)
				{
					if (lastChance)
					{
						Debug.LogError("Control surface dummy wing failed to generate on last chance");
						return;
					}
					Debug.LogWarning(ex.Message);
					Debug.LogWarning("Dummy control surface failed validation, resetting to defaults");
					Data.ControlSurface.ResetShape();
					Data.UpdateDummyWingParams(null);
					ControlSurface.UpdateClone(ref _controlSurface, Data.ControlSurface);
					GenerateDummyWing(lastChance: true);
					return;
				}
				UpdateColliders(in output);
				base.PartScript.PartMaterialScript.OnThemeUpdated();
				Assembly.CreateEditorCollidersForPartScript(base.PartScript);
				LastGeneratedWing = null;
			}
			catch (Exception arg)
			{
				Debug.LogError($"Error when generating dummy mesh for control surface (part ID {base.PartScript.Part.Id}): {arg}");
			}
		}

		private void OnDataChanged(ControlSurfacePartData data)
		{
			ControlSurface.UpdateClone(ref _controlSurface, data.ControlSurface);
			base.PartScript.PartMaterialScript.OnMeshChanged();
			UpdateDummyMesh();
		}

		private UniTask OnGenerateDummyMesh(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			_readyToGenerate = true;
			OnDataChanged(Data);
			return UniTask.CompletedTask;
		}

		private UniTask OnUpdateConnected(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			UpdateConnectedWing(this, null);
			return UniTask.CompletedTask;
		}

		private void UpdateColliders(in WingBuildOutput output)
		{
			MeshCollider meshCollider = null;
			for (int i = 1; i < output.Colliders.Length; i++)
			{
				List<ColliderInfo> list = output.Colliders[i];
				if (list != null && list.Count > 0)
				{
					meshCollider = list[0].Collider;
					break;
				}
			}
			base.PartScript.PrimaryPartCollider = meshCollider;
			for (int j = 1; j < output.Colliders.Length; j++)
			{
				List<ColliderInfo> list2 = output.Colliders[j];
				if (list2 == null)
				{
					continue;
				}
				foreach (ColliderInfo item in list2)
				{
					MeshCollider collider = item.Collider;
					bool flag = collider == meshCollider;
					PartColliderScript component;
					bool flag2 = collider.TryGetComponent<PartColliderScript>(out component);
					if (!flag2 || component.IsPrimary != flag)
					{
						if (flag2)
						{
							UnityEngine.Object.Destroy(component);
						}
						component = (flag ? PartColliderScript.AddAsPrimary(collider.gameObject) : collider.gameObject.AddComponent<PartColliderScript>());
						component.ExcludeFromDragModel = true;
					}
				}
			}
		}

		private void UpdateConnectedWing(object sender, PartConnectionChangedEventArgs e)
		{
			PartData part = base.PartScript.Part;
			bool flag = false;
			if (IsAttachedToWing)
			{
				_ = ConnectedWing;
			}
			for (int i = 0; i < part.PartConnections.Count; i++)
			{
				PartConnection partConnection = part.PartConnections[i];
				if (!flag)
				{
					JWingScript modifier = partConnection.GetOtherPart(part).PartScript.GetModifier<JWingScript>();
					if ((object)modifier != null)
					{
						ConnectedWing = modifier;
						flag = true;
						continue;
					}
				}
				partConnection.DestroyConnection(isSymmetryOperation: false, destroySymmetricConnections: false, raiseConnectionChangedEvents: false);
				i--;
			}
			if (!flag)
			{
				ConnectedWing = null;
			}
			IsAttachedToWing = flag;
		}

		private void UpdateDummyMesh()
		{
			if (base.LoadContext == CraftLoadContext.Designer && !IsAttachedToWing && _readyToGenerate)
			{
				GenerateDummyWing();
			}
		}
	}
}

using System.Linq;
using Assets.Scripts.Craft.Parts.Events;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class TransparencyScript : PartModifierScript
	{
		private static class ShaderPropertyIds
		{
			public static readonly int Alpha = Shader.PropertyToID("_Alpha");

			public static readonly int WaterHeight = Shader.PropertyToID("_WaterHeight");
		}

		private static Material _hiddenMaterial;

		private Material _designerCustomMaterial;

		private Color? _designerSelectionColour;

		private bool _isDestroyed;

		private bool _isHollow;

		private Material _mainMaterial;

		private Material _materialNoZwrite;

		private MeshRenderer _renderer;

		public bool IsHollow
		{
			get
			{
				return _isHollow;
			}
			set
			{
				if (_isHollow != value)
				{
					_isHollow = value;
					UpdateFaceVisibility();
				}
			}
		}

		public ulong LevelVisibilityMask
		{
			get
			{
				ulong num = ulong.MaxValue;
				TransparencyData modifier = Modifier;
				if (modifier.HideFront)
				{
					num &= 0xFFFFFFFFFFFFFFFDuL;
				}
				if (modifier.HideBack)
				{
					num &= 0xFFFFFFFFFFFFFFFBuL;
				}
				if (_isHollow && modifier.HideInside)
				{
					num &= 0xFFFFFFFFFFFFFFF7uL;
				}
				return num;
			}
		}

		public ulong SecondaryMaterialLevelMask
		{
			get
			{
				ulong num = 0uL;
				TransparencyData modifier = Modifier;
				if (_isHollow && !modifier.HideInside)
				{
					num |= 8;
				}
				return num;
			}
		}

		public TransparencyData Modifier { get; set; }

		public MeshRenderer Renderer
		{
			get
			{
				if (_renderer == null)
				{
					_renderer = GetComponent<MeshRenderer>();
				}
				return _renderer;
			}
			set
			{
				_renderer = value;
			}
		}

		public void AssignMaterials()
		{
			if (!(_renderer == null))
			{
				PartMaterialScriptUpdate(null, new PartMaterialScript.MaterialUpdateEventArgs(_designerSelectionColour, null));
			}
		}

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart, PreStartInitializationFlags.Default, 519);
		}

		public void OnPaintedInDesigner(object sender, PartMaterialScript.PaintedEventArgs args)
		{
			UpdateMaterialParameters();
		}

		public void UpdateMaterialParameters()
		{
			if ((object)_mainMaterial != null)
			{
				_mainMaterial.SetFloat(ShaderPropertyIds.Alpha, Modifier.Opacity);
			}
			if ((object)_materialNoZwrite != null)
			{
				_materialNoZwrite.SetFloat(ShaderPropertyIds.Alpha, Modifier.Opacity);
			}
		}

		protected virtual void OnDestroy()
		{
			_isDestroyed = true;
			ThemeScript theme = base.PartScript.Aircraft.Theme;
			if (_mainMaterial != null)
			{
				theme.ReleaseTransparentPartMaterialInstance(_mainMaterial);
				_mainMaterial = null;
			}
			if (_materialNoZwrite != null)
			{
				theme.ReleaseTransparentPartMaterialInstance(_materialNoZwrite);
				_materialNoZwrite = null;
			}
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				base.PartScript.PartConnectionChanged -= OnPartConnectionChanged;
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterLateUpdate(OnLateUpdate, CraftUpdateFlags.FlightDefault);
		}

		private void AutoDetectFaceVisiblity(bool forceUpdate = false, bool scanConnected = true, bool updateConnected = false)
		{
			if (Modifier.Fuselage == null || !Modifier.ProcessFaceConnectivity)
			{
				return;
			}
			if (Modifier.OverrideHide)
			{
				if (forceUpdate)
				{
					UpdateFaceVisibility();
				}
				return;
			}
			if (scanConnected)
			{
				Modifier.DetectConnected(force: true);
			}
			if (updateConnected)
			{
				UpdateConnected(Modifier.ConnectedBack);
				UpdateConnected(Modifier.ConnectedFront);
			}
			bool flag = Modifier.ConnectedFront != null && Modifier.Fuselage != null && Modifier.ConnectedFront.Fuselage != null && Modifier.Fuselage.ShapeMatches(Modifier.ConnectedFront.Fuselage, thisFront: true, Modifier.ConnectedFrontToFront);
			bool num = Modifier.HideFront != flag;
			Modifier.HideFront = flag;
			flag = Modifier.ConnectedBack != null && Modifier.Fuselage != null && Modifier.ConnectedBack.Fuselage != null && Modifier.Fuselage.ShapeMatches(Modifier.ConnectedBack.Fuselage, thisFront: false, Modifier.ConnectedBackToFront);
			bool num2 = num || Modifier.HideBack != flag;
			Modifier.HideBack = flag;
			if ((num2 || forceUpdate) && Modifier.IsTransparent)
			{
				PartMaterialScriptUpdate(null, new PartMaterialScript.MaterialUpdateEventArgs(_designerSelectionColour, null));
			}
			void UpdateConnected(TransparencyData connection)
			{
				PartScript partScript = connection?.Part.PartScript;
				if (partScript != null)
				{
					TransparencyScript modifier = partScript.GetModifier<TransparencyScript>();
					if (modifier != null)
					{
						modifier.AutoDetectFaceVisiblity(forceUpdate: false, scanConnected);
					}
				}
			}
		}

		private Material GetMaterial(bool zwrite)
		{
			if (_isDestroyed)
			{
				return null;
			}
			ref Material reference = ref zwrite ? ref _mainMaterial : ref _materialNoZwrite;
			if ((object)reference == null)
			{
				reference = base.PartScript.Aircraft.Theme.RequestTransparentPartMaterialInstance(zwrite);
				reference.SetFloat(ShaderPropertyIds.Alpha, Modifier.Opacity);
				reference.SetFloat(ShaderPropertyIds.WaterHeight, float.MinValue);
			}
			return reference;
		}

		private void OnLateUpdate(in CraftUpdateFrameData frame)
		{
			float value = GameWorld.Instance.FloatingOriginSeaLevel ?? (-10000f);
			if ((object)_mainMaterial != null)
			{
				_mainMaterial.SetFloat(ShaderPropertyIds.WaterHeight, value);
			}
			if ((object)_materialNoZwrite != null)
			{
				_materialNoZwrite.SetFloat(ShaderPropertyIds.WaterHeight, value);
			}
		}

		private void OnPartConnectionChanged(object sender, PartConnectionChangedEventArgs e)
		{
			AutoDetectFaceVisiblity();
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			if (loadContext == CraftLoadContext.Flight && !Modifier.IsTransparent)
			{
				if (Modifier.ProcessFaceConnectivity)
				{
					AutoDetectFaceVisiblity(forceUpdate: true, scanConnected: false);
				}
				base.enabled = false;
				return UniTask.CompletedTask;
			}
			_renderer = GetComponent<MeshRenderer>();
			if (_renderer == null)
			{
				_renderer = GetComponentInChildren<MeshRenderer>();
			}
			_isHollow = Modifier.Fuselage?.IsHollow ?? false;
			if (_hiddenMaterial == null)
			{
				_hiddenMaterial = Game.Instance.ResourceLoader.LoadSharedMaterial("Common/Materials/DoNothingMaterial");
			}
			UpdateMaterialParameters();
			if (loadContext == CraftLoadContext.Designer)
			{
				base.PartScript.PartMaterialScript.CustomMaterialUpdateCallback += PartMaterialScriptUpdate;
				base.PartScript.PartMaterialScript.OnPaintedInDesigner += OnPaintedInDesigner;
				Modifier.OnOpacityChanged += UpdateMaterialParameters;
				if (Modifier.Fuselage != null)
				{
					base.PartScript.PartConnectionChanged += OnPartConnectionChanged;
					Modifier.Fuselage.OnMeshRegenerated += delegate
					{
						AutoDetectFaceVisiblity();
					};
					if (Modifier.Fuselage is JFuselageData jFuselageData)
					{
						jFuselageData.OnGlassStateChanged += delegate
						{
							AutoDetectFaceVisiblity(forceUpdate: true, scanConnected: true, updateConnected: true);
						};
					}
				}
			}
			if (Modifier.Fuselage != null)
			{
				AutoDetectFaceVisiblity(forceUpdate: true, scanConnected: false);
			}
			return UniTask.CompletedTask;
		}

		private void PartMaterialScriptUpdate(object sender, PartMaterialScript.MaterialUpdateEventArgs args)
		{
			Color? color = (_designerSelectionColour = args.Color);
			args.EnableOutlineEffect = true;
			PartMaterialScript partMaterialScript = base.PartScript.PartMaterialScript;
			if (partMaterialScript.IsHidden || partMaterialScript.IsDisconnected || (bool)partMaterialScript.OverrideMaterial || (bool)partMaterialScript.CustomMaterial)
			{
				args.SetMaterialsNormally = true;
			}
			else if (base.PartScript.PartMaterialScript.IsHidden)
			{
				if (_designerCustomMaterial == null)
				{
					_designerCustomMaterial = Object.Instantiate(Game.Instance.ResourceLoader.LoadSharedMaterial("Designer/Materials/DesignerPartHidden"));
				}
				_designerCustomMaterial.color = color.Value;
				SetMaterial(_designerCustomMaterial);
			}
			else if (Modifier.IsTransparent)
			{
				UpdateFaceVisibility();
			}
			else
			{
				args.SetMaterialsNormally = true;
			}
		}

		private void SetMaterial(Material material)
		{
			if (_renderer == null || !_renderer.TryGetComponent<MeshFilter>(out var component))
			{
				return;
			}
			PartMaterialScript.RendererMaterialMap rendererMaterialMap = base.PartScript.PartMaterialScript.RendererMaps.FirstOrDefault((PartMaterialScript.RendererMaterialMap rm) => rm.Renderer == Renderer);
			int[] array = rendererMaterialMap?.SubmeshToLevelMap;
			int subMeshCount = component.sharedMesh.subMeshCount;
			Material[] array2 = new Material[subMeshCount];
			ulong levelVisibilityMask = LevelVisibilityMask;
			ulong secondaryMaterialLevelMask = SecondaryMaterialLevelMask;
			for (int num = 0; num < subMeshCount; num++)
			{
				Material material2;
				if (array != null && num >= array.Length)
				{
					material2 = _hiddenMaterial;
				}
				else
				{
					int num2 = ((array != null) ? array[num] : num);
					material2 = ((((ulong)(1L << num2) & levelVisibilityMask) != 0L) ? ((((ulong)(1L << num2) & secondaryMaterialLevelMask) == 0L) ? material : GetMaterial(zwrite: false)) : _hiddenMaterial);
				}
				array2[num] = material2;
			}
			Renderer.sharedMaterials = array2;
			if (rendererMaterialMap != null)
			{
				rendererMaterialMap.OriginalMaterials = array2;
			}
		}

		private void UpdateFaceVisibility()
		{
			if (Modifier.IsTransparent)
			{
				Material material = GetMaterial(IsHollow);
				SetMaterial(material);
			}
		}
	}
}

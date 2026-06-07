using System;
using Assets.Scripts.Craft.Events;
using Assets.Scripts.Craft.Parts.Modifiers.Animations;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Utils;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class CanopyScript : PartModifierScript
	{
		private static class ShaderPropertyIds
		{
			public static readonly int Alpha = Shader.PropertyToID("_Alpha");

			public static readonly int WaterHeight = Shader.PropertyToID("_WaterHeight");
		}

		private static Material _hiddenMaterial;

		private PartModifierGenericAnimationScript _animationScript;

		private Transform _dragPositionWhenOpen;

		private Material _insideMat;

		private Material _outsideMat;

		private MeshRenderer _renderer;

		public CanopyData Modifier { get; set; }

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart);
		}

		public void UpdateMaterialParameters()
		{
			UpdateMaterial(_insideMat);
			UpdateMaterial(_outsideMat);
		}

		protected virtual void OnDestroy()
		{
			ThemeScript theme = base.PartScript.Aircraft.Theme;
			theme.ReleaseTransparentPartMaterialInstance(_insideMat);
			theme.ReleaseTransparentPartMaterialInstance(_outsideMat);
			Modifier.OnOpacityChanged -= UpdateMaterialParameters;
			Modifier.OnShowInsideChanged -= UpdateInsideMaterial;
			if ((object)_animationScript != null)
			{
				int animationActivationGroup = Modifier.AnimationActivationGroup;
				ref Action<ActivationGroupStateChangedEventArgs> reference = ref base.Controls.ActivationGroupChanged[animationActivationGroup];
				reference = (Action<ActivationGroupStateChangedEventArgs>)Delegate.Remove(reference, new Action<ActivationGroupStateChangedEventArgs>(OnAnimationActivationGroupChanged));
			}
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();
			_renderer = base.transform.Find(Modifier.MeshPath)?.GetComponent<MeshRenderer>();
			_insideMat = base.PartScript.Aircraft.Theme.RequestTransparentPartMaterialInstance(zwrite: false);
			_outsideMat = base.PartScript.Aircraft.Theme.RequestTransparentPartMaterialInstance(zwrite: true);
			if (Modifier.HasAnimation && Modifier.AnimationActivationGroup > 0 && base.LoadContext == CraftLoadContext.Flight)
			{
				_animationScript = base.transform.Find(Modifier.AnimationPath)?.GetComponent<PartModifierGenericAnimationScript>();
				_animationScript.Audio = base.transform.GetComponent<AudioSource>();
				_dragPositionWhenOpen = Utilities.FindFirstGameObjectMyselfOrChildren("DragPositionWhenOpen", base.gameObject)?.transform;
			}
			if (_renderer != null)
			{
				_renderer.shadowCastingMode = ShadowCastingMode.Off;
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterLateUpdate(OnLateUpdate, CraftUpdateFlags.FlightDefault);
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightLocalUnpaused);
		}

		private void OnAnimationActivationGroupChanged(ActivationGroupStateChangedEventArgs e)
		{
			if (this != null && base.gameObject.activeInHierarchy)
			{
				_animationScript.Animate(e.ActivationGroupState ? 1 : 0, Modifier.AnimationSpeed);
			}
		}

		private void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			if ((object)_animationScript != null && (object)_dragPositionWhenOpen != null)
			{
				float animationState = _animationScript.AnimationState;
				float num = Modifier.DragWhenOpen * animationState;
				if (num > 0f)
				{
					base.PartScript.Body.DragPhysics.AddFrameDrag(PartDrag.DragDirection.Forward, num, _dragPositionWhenOpen.position);
				}
			}
		}

		private void OnLateUpdate(in CraftUpdateFrameData frame)
		{
			float value = GameWorld.Instance.FloatingOriginSeaLevel ?? float.NegativeInfinity;
			_insideMat.SetFloat(ShaderPropertyIds.WaterHeight, value);
			_outsideMat.SetFloat(ShaderPropertyIds.WaterHeight, value);
		}

		private void OnPaintedInDesigner(object sender, PartMaterialScript.PaintedEventArgs e)
		{
			UpdateMaterialParameters();
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			UpdateMaterialParameters();
			if (_hiddenMaterial == null)
			{
				_hiddenMaterial = Game.Instance.ResourceLoader.LoadSharedMaterial("Common/Materials/DoNothingMaterial");
			}
			if (loadContext != CraftLoadContext.Flight)
			{
				_insideMat.SetFloat(ShaderPropertyIds.WaterHeight, float.NegativeInfinity);
				_outsideMat.SetFloat(ShaderPropertyIds.WaterHeight, float.NegativeInfinity);
				if (loadContext == CraftLoadContext.Designer)
				{
					base.PartScript.PartMaterialScript.OnPaintedInDesigner += OnPaintedInDesigner;
					Modifier.OnOpacityChanged += UpdateMaterialParameters;
					Modifier.OnShowInsideChanged += UpdateInsideMaterial;
				}
			}
			Material[] array = new Material[_renderer.sharedMaterials.Length];
			for (int i = 0; i < array.Length; i++)
			{
				if (i == Modifier.InsideSubmesh)
				{
					array[i] = (Modifier.ShowInside ? _insideMat : _hiddenMaterial);
				}
				else
				{
					array[i] = _outsideMat;
				}
				if ((object)_animationScript != null)
				{
					_animationScript.Initialize();
					int animationActivationGroup = Modifier.AnimationActivationGroup;
					_animationScript.AnimationState = (base.Controls.GetActivationState(animationActivationGroup) ? 1 : 0);
					ref Action<ActivationGroupStateChangedEventArgs> reference = ref base.Controls.ActivationGroupChanged[animationActivationGroup];
					reference = (Action<ActivationGroupStateChangedEventArgs>)Delegate.Combine(reference, new Action<ActivationGroupStateChangedEventArgs>(OnAnimationActivationGroupChanged));
				}
				_renderer.sharedMaterials = array;
			}
			return UniTask.CompletedTask;
		}

		private void UpdateInsideMaterial()
		{
			Material[] sharedMaterials = _renderer.sharedMaterials;
			sharedMaterials[Modifier.InsideSubmesh] = (Modifier.ShowInside ? _insideMat : _hiddenMaterial);
			_renderer.sharedMaterials = sharedMaterials;
		}

		private void UpdateMaterial(Material material)
		{
			material.SetFloat(ShaderPropertyIds.Alpha, Modifier.Opacity);
		}
	}
}

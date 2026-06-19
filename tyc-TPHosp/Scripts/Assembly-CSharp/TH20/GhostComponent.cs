using System;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class GhostComponent : EntityTickComponent
	{
		private class CanSeeGhostParam
		{
			public Vector3 StaffPosition;

			public Vector3 GhostPosition;

			public bool Detected;
		}

		private const string _colorPropName = "_Color";

		private CanSeeGhostParam _canSeeGhostParam = new CanSeeGhostParam();

		[SerializeField]
		private StaffRequired _staffRequired;

		[SerializeField]
		private bool _invulnerable;

		[SerializeField]
		private float _fadeRate = 1f;

		[SerializeField]
		private float _transparency = 0.75f;

		private Character _ghost;

		private GhostDefinition _definition;

		private bool _visible;

		private bool _captured;

		private float _alpha;

		private float _timeSpawned;

		private float _timeStartedHaunting;

		private float _timeToHaunt;

		private float _timeToDropEctoplasm;

		private DisableSelectionComponent _disableSelectionComponent;

		private DisableHighlightComponent _disableHighlightComponent;

		[DontSave]
		private List<Material[]> _oldMaterials;

		[DontSave]
		private List<Material[]> _newMaterials;

		public Job Job { get; set; }

		public StaffRequired StaffRequired => _staffRequired;

		public bool Visible => _visible;

		public bool Invulnerable => _invulnerable;

		protected override Type ValidEntityType()
		{
			return typeof(Character);
		}

		protected GhostComponent()
		{
			_alpha = 0f;
			_visible = true;
			_oldMaterials = new List<Material[]>();
			_newMaterials = new List<Material[]>();
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_ghost = GetOwner<Character>();
			_definition = _ghost.GetDefinition<GhostDefinition>();
			_ghost.SetBehaviour(_definition._behaviourIdle);
			_timeSpawned = GameTime.time;
			_timeToDropEctoplasm = _definition.GetEctoplasmDropTime();
			StartHaunting();
			SetupVisuals();
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			SetupVisuals();
		}

		public override void Destroy()
		{
			RestoreMaterials();
			_ghost.Level.CharacterEvents.OnGhostDestroyed.InvokeSafe(_ghost);
			base.Destroy();
		}

		public override void LateTick()
		{
			base.LateTick();
			_alpha = Mathf.Clamp01(_alpha + (_visible ? _fadeRate : (0f - _fadeRate)) * Time.deltaTime);
			foreach (Material[] newMaterial in _newMaterials)
			{
				foreach (Material material in newMaterial)
				{
					if (material != null && material.HasProperty("_Color"))
					{
						Color color = material.color;
						color.a = _alpha * _transparency;
						material.color = color;
					}
				}
			}
			UpdateRoomUsing();
			if (!_captured)
			{
				if (!_visible && _alpha <= 0f && !_ghost.NavPath.IsNavigating())
				{
					StartHaunting();
				}
				if (_visible && GameTime.time - _timeStartedHaunting >= _timeToHaunt)
				{
					StopHaunting();
				}
				UpdateEctoplasm();
				if (!_visible && _alpha <= 0f && GameTime.time - _timeSpawned >= _definition.LifeSpan)
				{
					_ghost.Level.CharacterEvents.OnDestroyCharacter.InvokeSafe(_ghost);
				}
			}
		}

		private void UpdateRoomUsing()
		{
			Room roomUsing = _ghost.RoomUsing;
			if (roomUsing != null && !roomUsing.Definition.IsHospitalOrBay)
			{
				Vector3 result;
				if (_visible)
				{
					StopHaunting();
				}
				else if (_alpha <= 0f && RoomAlgorithms.FindNearestFreeTile(roomUsing.FloorPlan.HospitalMap.FloorPlan, _ghost.Position, out result))
				{
					result += RandomUtils.RandomXZVector(-0.5f, 0.5f);
					_ghost.Position = result;
					_ghost.NavPath.Warp(result);
				}
			}
			if (roomUsing == null || roomUsing.FloorPlan.HospitalMap.FloorPlan.TileCount < 16)
			{
				_ghost.Level.CharacterEvents.OnDestroyCharacter.InvokeSafe(_ghost);
			}
		}

		private void UpdateEctoplasm()
		{
			if (!_visible)
			{
				return;
			}
			_timeToDropEctoplasm -= Time.deltaTime;
			if (_timeToDropEctoplasm <= 0f)
			{
				_timeToDropEctoplasm += _definition.GetEctoplasmDropTime();
				if (_ghost.RoomUsing != null)
				{
					RoomItemAlgorithms.SpawnItem(_definition.EctoplasmItem.Instance, _ghost.Position, 0.5f, _ghost.RotationY, _ghost.Level, _ghost.RoomUsing);
				}
			}
		}

		public void BeginCapture()
		{
			_visible = true;
			_captured = true;
		}

		public void EndCapture()
		{
			_captured = false;
		}

		private void StartHaunting()
		{
			_visible = true;
			_timeStartedHaunting = GameTime.time;
			_timeToHaunt = RandomUtils.GlobalRandomInstance.NextFloat(_definition.HauntTimeMin, _definition.HauntTimeMax);
			_ghost.Animator.SetBool("Visible", _visible);
			_ghost.BehaviorTree.SetVariable("Haunt", new SharedBool
			{
				Value = true
			});
			if (_disableSelectionComponent != null)
			{
				_disableSelectionComponent.Destroy();
				_disableSelectionComponent = null;
			}
			if (_disableHighlightComponent != null)
			{
				_disableHighlightComponent.Destroy();
				_disableHighlightComponent = null;
			}
		}

		private void StopHaunting()
		{
			_visible = false;
			_ghost.Animator.SetBool("Visible", _visible);
			_ghost.BehaviorTree.SetVariable("Haunt", new SharedBool
			{
				Value = false
			});
			_disableSelectionComponent = _ghost.AddComponent<DisableSelectionComponent>();
			_disableHighlightComponent = _ghost.AddComponent<DisableHighlightComponent>();
			InWorldMenuObject activeMenu = _ghost.GetActiveMenu();
			if (activeMenu != null)
			{
				activeMenu.CloseMenu();
			}
		}

		public bool CanSeeGhost(Staff staff)
		{
			if (_ghost.RoomUsing != staff.RoomUsing)
			{
				return false;
			}
			if (_visible)
			{
				return true;
			}
			_canSeeGhostParam.Detected = false;
			_canSeeGhostParam.GhostPosition = _ghost.Position;
			_canSeeGhostParam.StaffPosition = staff.Position;
			if (staff.ModifiersComponent != null)
			{
				staff.ModifiersComponent.IterateModifiersOfType(_canSeeGhostParam, delegate(CanSeeGhostParam param, CharacterModifierGhostbuster ghostbuster)
				{
					float num = ghostbuster.DetectionRadius * ghostbuster.DetectionRadius;
					if (_canSeeGhostParam.StaffPosition.SquareDistance2D(param.GhostPosition) < num)
					{
						param.Detected = true;
					}
				});
			}
			return _canSeeGhostParam.Detected;
		}

		private void SetupVisuals()
		{
			_ghost.GameObject.AddComponent<GhostAnimEventListener>();
			MeshUtils.GetGameObjectMaterials(_ghost.GameObject, ref _oldMaterials);
			foreach (Material[] oldMaterial in _oldMaterials)
			{
				List<Material> list = new List<Material>(oldMaterial.Length);
				Material[] array = oldMaterial;
				foreach (Material material in array)
				{
					if (material == null)
					{
						list.Add(null);
						continue;
					}
					Material material2 = new Material(material);
					if (material2.HasProperty("_Color"))
					{
						if (TH20Standard.IsTH20Standard(material2))
						{
							TH20Standard.SetBlendMode(material2, TH20Standard.BlendMode.Fade);
						}
						Color color = material2.color;
						color.a = _alpha * _transparency;
						material2.color = color;
					}
					list.Add(material2);
				}
				_newMaterials.Add(list.ToArray());
			}
			MeshUtils.SetGameObjectMaterials(_ghost.GameObject, ref _newMaterials);
		}

		private void RestoreMaterials()
		{
			if (_oldMaterials == null || _newMaterials == null)
			{
				return;
			}
			MeshUtils.SetGameObjectMaterials(_ghost.GameObject, ref _oldMaterials);
			foreach (Material[] newMaterial in _newMaterials)
			{
				foreach (Material material in newMaterial)
				{
					if (material != null)
					{
						UnityEngine.Object.Destroy(material);
					}
				}
			}
		}
	}
}

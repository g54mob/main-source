using Assets.Scripts.Craft.Parts.Modifiers.Fuselage;
using Assets.Scripts.Tools;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class CargoBayScript : PartModifierScript<CargoBayData>, IDesignerUpdate, IGameLoopItem, IFlightUpdate
	{
		private LoopingAudioScript _audio;

		private GameObject _baseColliders;

		private GameObject _baseMesh;

		private CargoBayDoorScript[] _doors;

		private FuselageScript _fuselage;

		private float _openAmount;

		private bool _updateCraftWhenDoneAnimating;

		public float OpenAmount => _openAmount;

		void IDesignerUpdate.DesignerUpdate(in DesignerFrameData frame)
		{
			CommonUpdate(frame.DeltaTime);
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			base.Data.Open = base.Data.Part.Activated;
			CommonUpdate((float)frame.DeltaTimeWorld);
		}

		public override void OnActivated()
		{
			base.OnActivated();
		}

		public override void OnModifiersCreated()
		{
			base.OnModifiersCreated();
			CommonStart();
			if (PartViewerScript.TakingPictures)
			{
				float doors = 0.75f;
				if (!base.Data.PartPropertiesEnabled)
				{
					doors = (base.Data.StartOpen ? 1 : 0);
				}
				SetDoors(doors);
			}
		}

		public void SetDoors(float openAmount)
		{
			CargoBayDoorScript[] doors = _doors;
			for (int i = 0; i < doors.Length; i++)
			{
				doors[i].SetOpenAmount(openAmount);
			}
		}

		public void UpdateDoorsInDesigner(bool immediate)
		{
			UpdateHinges();
			if (immediate)
			{
				if (base.Data.StartOpen || base.Data.Open)
				{
					_openAmount = 1f;
				}
				else
				{
					_openAmount = 0f;
				}
				SetDoors(_openAmount);
			}
		}

		public void UpdateHinges()
		{
			CargoBayDoorScript[] doors = _doors;
			foreach (CargoBayDoorScript door in doors)
			{
				UpdateDoorHinge(door, _fuselage.Data);
			}
		}

		public void UpdateRotators()
		{
			SetDoors(0f);
			CommonStart();
			SetDoors(_openAmount);
		}

		protected virtual void Start()
		{
			if (Game.InFlightScene)
			{
				FlightStart();
			}
			else
			{
				DesignerStart();
			}
		}

		private void CommonStart()
		{
			_doors = base.gameObject.GetComponentsInChildren<CargoBayDoorScript>();
			CargoBayDoorScript[] doors = _doors;
			for (int i = 0; i < doors.Length; i++)
			{
				doors[i].Initialize(this);
			}
			Transform transform = base.transform.Find("BaseColliders");
			Transform transform2 = base.transform.GetChild(base.transform.childCount - 1)?.Find("Base");
			if (transform != null && transform2 != null)
			{
				_baseColliders = transform.gameObject;
				_baseMesh = transform2.gameObject;
				if (Game.InFlightScene)
				{
					if (!base.Data.HasBase)
					{
						Object.DestroyImmediate(_baseColliders);
						Object.DestroyImmediate(_baseMesh);
						Collider componentInChildren = base.gameObject.GetComponentInChildren<Collider>();
						if (componentInChildren != null)
						{
							componentInChildren.gameObject.AddComponent<PartColliderScript>().IsPrimary = true;
						}
						base.PartScript.InitializeColliders();
						base.PartScript.PartMaterialScript.UpdateRenderers();
					}
				}
				else
				{
					_baseColliders.SetActive(base.Data.HasBase);
					_baseMesh.SetActive(base.Data.HasBase);
				}
			}
			_fuselage = base.PartScript.GetModifier<FuselageScript>();
			UpdateHinges();
		}

		private void CommonUpdate(float elapsedTime)
		{
			float num = 0f;
			if (base.Data.Open)
			{
				num = 1f;
			}
			float f = num - _openAmount;
			if (Mathf.Abs(f) > 0f)
			{
				float step = Mathf.Sign(f) * base.Data.OpenSpeed * 0.25f * elapsedTime;
				_openAmount = Utilities.StepTowards(_openAmount, step, num);
				_openAmount = Mathf.Clamp01(_openAmount);
				SetDoors(_openAmount);
				_updateCraftWhenDoneAnimating = true;
			}
			else if (_updateCraftWhenDoneAnimating)
			{
				_updateCraftWhenDoneAnimating = false;
				base.PartScript.CraftScript.InitiateDragRecalculation();
			}
			if (_audio != null)
			{
				bool flag = Mathf.Abs(f) > 0.01f;
				_audio.UpdateLoopAudio(flag ? base.Data.SoundVolume : 0f);
			}
		}

		private void DesignerStart()
		{
			UpdateDoorsInDesigner(immediate: true);
			_fuselage.MeshesUpdated += OnFuselageMeshesUpdated;
		}

		private void FlightStart()
		{
			if (base.Data.StartOpen)
			{
				base.Data.StartOpen = false;
				base.Data.Part.Activated = true;
				base.Data.Open = true;
			}
			_openAmount = (base.Data.Open ? 1f : 0f);
			SetDoors(_openAmount);
			if (base.Data.SoundVolume > 0f)
			{
				_audio = base.PartScript.Transform.GetComponentInChildren<LoopingAudioScript>(includeInactive: true);
			}
		}

		private void OnFuselageMeshesUpdated(FuselageScript fuselageScript)
		{
			CommonStart();
			SetDoors(_openAmount);
			CommonUpdate(0f);
		}

		private void UpdateDoorHinge(CargoBayDoorScript door, FuselageData fuselage)
		{
			float angle = base.Data.OpenAngle * ((door.Side > 0f) ? 1f : base.Data.OpenAngleSecondary);
			Vector2 topScale = fuselage.TopScale;
			Vector2 bottomScale = fuselage.BottomScale;
			Vector3 rotationAxis;
			Vector3 a;
			switch (base.Data.HingeStyle)
			{
			case "Sideways":
			{
				Vector3 vector = -fuselage.Offset;
				Vector3 offset = fuselage.Offset;
				offset.y = Mathf.Lerp(offset.y, vector.y, 0.5f * fuselage.Deformations.y);
				offset.x += door.Side * topScale.x;
				vector.x += door.Side * bottomScale.x;
				rotationAxis = (0f - door.Side) * (offset - vector).normalized;
				a = new Vector3(door.Side, -0.5f * fuselage.Deformations.y, 0f);
				break;
			}
			case "Clamshell":
				a = new Vector3(0f, -1f, -1f);
				rotationAxis = new Vector3(-1f, 0f, 0f);
				break;
			case "Sliding":
				a = new Vector3(0f, 0f, 0.05f);
				rotationAxis = new Vector3(0f, 0f - door.Side, 0f);
				break;
			default:
				door.UpdateHinge(Vector3.zero, Vector3.zero, angle, custom: true);
				return;
			}
			Vector2 vector2 = Vector2.Lerp(bottomScale, topScale, (a.y + 1f) * 0.5f);
			vector2.x *= 1f - 0.5f * Mathf.Lerp(fuselage.Deformations.z, fuselage.Deformations.x, (a.y + 1f) * 0.5f);
			Vector3 localPosition = Vector3.Scale(a, new Vector3(vector2.x, fuselage.Offset.y, vector2.y));
			door.UpdateHinge(rotationAxis, localPosition, angle);
		}
	}
}

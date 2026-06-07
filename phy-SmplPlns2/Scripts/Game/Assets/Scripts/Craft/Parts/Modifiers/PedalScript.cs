using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers.Character;
using Assets.Scripts.Design;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class PedalScript : PartModifierScript
	{
		private const float DisplayRotationSpeed = 100f;

		private const float DisplayTime = 2f;

		private float _currentAngle;

		private PedalData _data;

		private IInputController _input;

		private GameObject _pedal;

		private Transform _pivot;

		private Transform _poseRoot;

		private PedalPrefabs.PedalPrefab _prefab;

		private bool _scheduledPoseMatch;

		private float _timeAtDisplayAngle;

		public PedalData Data => _data;

		public float ZeroAngle { get; set; }

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart);
		}

		public void Initialize(PedalData data)
		{
			_data = data;
		}

		public void SetupPrefab(PedalPrefabs.PedalPrefab prefab)
		{
			base.PartScript.PartMaterialScript.ClearRenderers(destroy: true);
			base.PartScript.EditorColliders.Clear();
			_poseRoot.SetParent(base.transform);
			if (_pedal != null)
			{
				Object.Destroy(_pedal);
			}
			_prefab = prefab;
			GameObject pedal = Object.Instantiate(prefab.prefab, Vector3.zero, Quaternion.identity, new InstantiateParameters
			{
				parent = base.transform,
				worldSpace = false
			});
			_pedal = pedal;
			PartColliderScript[] componentsInChildren = _pedal.GetComponentsInChildren<PartColliderScript>();
			PartColliderScript[] array = componentsInChildren;
			foreach (PartColliderScript partColliderScript in array)
			{
				base.PartScript.EditorColliders.Add(new EditorCollider(partColliderScript.Collider, base.PartScript, partColliderScript));
			}
			PartColliderScript partColliderScript2 = componentsInChildren.FirstOrDefault((PartColliderScript x) => x.IsPrimary);
			if (partColliderScript2 != null)
			{
				base.PartScript.PrimaryPartCollider = partColliderScript2.Collider;
			}
			MeshRenderer[] componentsInChildren2 = _pedal.GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer renderer in componentsInChildren2)
			{
				base.PartScript.PartMaterialScript.AddRenderer(renderer);
			}
			base.PartScript.PartMaterialScript.InitializeMaterial();
			try
			{
				_pivot = Utilities.FindGameObjectRelativeTo(_pedal, prefab.pivotPath)?.transform;
				_currentAngle = _data.ZeroAngle;
				_pivot.localEulerAngles = new Vector3(_currentAngle, 0f, 0f);
			}
			catch
			{
				Debug.LogError($"Could not find pedal-#{Data.Part.Id} pivot: {prefab.pivotPath}");
			}
			_scheduledPoseMatch = true;
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();
			_poseRoot = Utilities.FindGameObjectRelativeTo(base.gameObject, "PoseRoot")?.transform;
			SetupPrefab(Data.PedalPrefab);
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightDefault | CraftUpdateFlags.DesignerScene);
		}

		private void MatchPose()
		{
			Transform transform = Utilities.FindGameObjectRelativeTo(_pedal, _prefab.poseRoot)?.transform;
			_poseRoot.SetParent(transform.parent);
			_poseRoot.SetLocalPositionAndRotation(transform.localPosition, transform.localRotation);
			for (int i = 0; i < _poseRoot.childCount; i++)
			{
				Transform child = transform.GetChild(i);
				Transform child2 = _poseRoot.GetChild(i);
				IKTargetScript component = child2.GetComponent<IKTargetScript>();
				child2.SetLocalPositionAndRotation(child.localPosition + ((component == null) ? Vector3.zero : component.Data.Offset), child.localRotation);
			}
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			base.PartScript.GetModifiers<InputControllerScript>();
			_input = GetInputController(_data.Input);
			return UniTask.CompletedTask;
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			if (_scheduledPoseMatch)
			{
				_scheduledPoseMatch = false;
				MatchPose();
			}
			float num = _data.ZeroAngle;
			if (_input != null && frame.CraftLoadContext == CraftLoadContext.Flight)
			{
				num = Mathf.LerpAngle(_data.ZeroAngle, _data.FullAngle, Mathf.Abs(_input.Value));
			}
			if (frame.CraftLoadContext == CraftLoadContext.Designer)
			{
				num = _data.DisplayTargetAngle ?? num;
				num = Mathf.MoveTowardsAngle(_currentAngle, num, frame.DeltaTimeUnscaled * 100f);
				if (Mathf.Approximately(_currentAngle, num))
				{
					_timeAtDisplayAngle += frame.DeltaTimeUnscaled;
					if (_timeAtDisplayAngle >= 2f)
					{
						_data.DisplayTargetAngle = null;
					}
				}
				else
				{
					_timeAtDisplayAngle = 0f;
				}
			}
			if (_pivot != null)
			{
				_currentAngle = num;
				_pivot.localEulerAngles = new Vector3(num, 0f, 0f);
			}
		}
	}
}

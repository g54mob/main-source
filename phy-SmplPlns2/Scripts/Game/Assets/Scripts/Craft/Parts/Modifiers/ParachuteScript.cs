using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Audio;
using Assets.Scripts.Design;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class ParachuteScript : PartModifierScript, IPartCollisionHandler
	{
		private const float ParachuteNormalSize = 6f;

		private Func<bool> _activateFunc;

		private float? _autoDetachTime;

		private Transform _chute;

		private Rigidbody _chuteBody;

		private GameObject _chutePackage;

		private GameObject _chutePackageMesh;

		private SphereCollider _collider;

		private bool _dead;

		private bool _deployed;

		private bool _detached;

		private float _detachTimer;

		private List<Transform> _doors = new List<Transform>();

		private float _doorSpeed = 10f;

		private float _doorTime;

		private float _dragPercentage;

		private float _inflateTime;

		private bool _jammed;

		private SpringJoint _joint;

		private bool _openDoors;

		private PhysicsMaterial _parachutePhysicsMaterial;

		public ParachuteData Parachute { get; set; }

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart);
		}

		public void DeployParachute()
		{
			if (!_deployed)
			{
				_deployed = true;
				_openDoors = true;
				_collider = _chutePackage.AddComponent<SphereCollider>();
				_collider.radius = 0.1f;
				_collider.material = _parachutePhysicsMaterial;
				_collider.gameObject.AddComponent<SkipCollisionHandlerPartColliderScript>();
				_chuteBody = _chutePackage.AddComponent<Rigidbody>();
				_chuteBody.mass = 0.005f;
				_chuteBody.angularDamping = 10f;
				_chuteBody.maxDepenetrationVelocity = 1f;
				_chuteBody.linearDamping = 0f;
				_joint = _chutePackage.AddComponent<SpringJoint>();
				_joint.minDistance = 0f;
				_joint.maxDistance = Parachute.Scale * 6f;
				_joint.connectedBody = base.PartScript.Body.RigidBody.PhysxRigidBody;
				_joint.enableCollision = true;
				_chuteBody.AddForce(base.PartScript.transform.up * 10f);
				_inflateTime = 0f;
				_chute.localScale = new Vector3(0f, 0f, 0f);
				_chute.gameObject.SetActive(value: true);
				AudioManager.PlaySound(AudioStore.ParachuteAudio, base.PartScript.transform.position, AudioStore.ParachuteAudio.DefaultVolume, UnityEngine.Random.Range(0f, 0.2f));
			}
		}

		public void Initialize()
		{
			base.PartScript.Aircraft.VelocitySet += OnVelocitySet;
			_chute = Utilities.FindFirstGameObjectMyselfOrChildren("Chute", base.PartScript.gameObject).transform;
			_chute.rotation = Quaternion.Euler(-90f, 0f, 0f);
			_chute.localScale = Vector3.one * Parachute.Scale;
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				if (Parachute.Style == "V. Striped")
				{
					LoadChuteMesh("ParachuteStripedVertical");
				}
				else if (Parachute.Style == "H. Striped")
				{
					LoadChuteMesh("ParachuteStripedHorizontal");
				}
				else
				{
					LoadChuteMesh("ParachuteCheckered");
				}
				_activateFunc = base.PartScript.Aircraft.Controls.GetActivatorGetter(Parachute.ActivationGroup, base.PartScript);
			}
		}

		bool IPartCollisionHandler.OnCollision(PartScript partScript, Collision collision, in ContactPoint contactPoint)
		{
			return true;
		}

		public override void OnDamageLevelIncreased(PartDamageLevel level, float lastDamage, Vector3 lastDamagePosition, Vector3 lastDamageDirection)
		{
			if (level <= PartDamageLevel.Light)
			{
				return;
			}
			float value = UnityEngine.Random.value;
			if (!_deployed)
			{
				if (value < 0.3f)
				{
					_jammed = true;
				}
				else if (value < 8f)
				{
					_autoDetachTime = UnityEngine.Random.value * 2f;
				}
			}
			else if (!_detached)
			{
				DetachNextFrame();
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightUnpaused);
			registrar.RegisterUpdate(OnUpdateFlight, CraftUpdateFlags.FlightUnpaused);
			registrar.RegisterUpdate(OnUpdateDesigner, CraftUpdateFlags.DesignerDefault);
		}

		private void AnimateDoors(float deltaTime)
		{
			if (_openDoors)
			{
				_doorTime += deltaTime * _doorSpeed;
			}
			else
			{
				_doorTime -= deltaTime * _doorSpeed;
			}
			_doorTime = Mathf.Clamp01(_doorTime);
			float num = _doorTime * 70f;
			for (int i = 0; i < _doors.Count; i++)
			{
				Vector3 eulerAngles = _doors[i].localRotation.eulerAngles;
				eulerAngles.z = 0f - num;
				_doors[i].localRotation = Quaternion.Euler(eulerAngles);
			}
		}

		private void AnimateInflation()
		{
			Vector3 vector = _chutePackage.transform.position - base.PartScript.transform.position;
			float magnitude = vector.magnitude;
			Vector3 vector2 = base.PartScript.Body.RigidBody.velocity - base.PartScript.Aircraft.WindVelocity;
			float magnitude2 = vector2.magnitude;
			if (magnitude > 0f && magnitude2 > 0f)
			{
				_dragPercentage = 0f - Vector3.Dot(vector2 / magnitude2, vector / magnitude);
				if (_dragPercentage < 0f)
				{
					_dragPercentage = 0f;
				}
			}
			else
			{
				_dragPercentage = 0f;
			}
			float num = magnitude / 6f;
			if (num > 0.2f)
			{
				_chutePackageMesh.SetActive(value: false);
			}
			num = Mathf.Clamp(num, 0f, Parachute.Scale);
			Vector3 normalized = new Vector3(-1f, -0.5f, 0f).normalized;
			_chute.rotation = Quaternion.LookRotation(vector.normalized, normalized);
			_chute.localScale = new Vector3(num, num, num);
			_collider.radius = num;
		}

		private void ApplyDrag(float drag)
		{
			if (drag > 0f)
			{
				Vector3 position = base.transform.position;
				base.PartScript.Body.DragPhysics.AddFrameDrag(PartDrag.DragDirection.Forward, drag, position);
				base.PartScript.Body.DragPhysics.AddFrameDrag(PartDrag.DragDirection.Backward, drag, position);
				base.PartScript.Body.DragPhysics.AddFrameDrag(PartDrag.DragDirection.Upward, drag, position);
				base.PartScript.Body.DragPhysics.AddFrameDrag(PartDrag.DragDirection.Downward, drag, position);
				base.PartScript.Body.DragPhysics.AddFrameDrag(PartDrag.DragDirection.Leftward, drag, position);
				base.PartScript.Body.DragPhysics.AddFrameDrag(PartDrag.DragDirection.Rightward, drag, position);
			}
		}

		private void DetachNextFrame()
		{
			StartCoroutine(DetachNextFrameCoroutine());
		}

		private IEnumerator DetachNextFrameCoroutine()
		{
			yield return null;
			if (_deployed && !_detached)
			{
				DetachParachute();
			}
		}

		private void DetachParachute()
		{
			_detached = true;
			if (base.PartScript.Body.Joints.Count > 0)
			{
				BodyJoint bodyJoint = base.PartScript.Body.Joints[0];
				if (bodyJoint != null && !bodyJoint.PartConnection.IsDestroyed)
				{
					bodyJoint.Break(playSound: false);
					bodyJoint.BodyA.RigidBody.WakeUp();
					bodyJoint.BodyB.RigidBody.WakeUp();
				}
				base.PartScript.Aircraft.AircraftStructureChanged();
			}
		}

		private void KillParachute()
		{
			_dead = true;
			if (_joint != null)
			{
				UnityEngine.Object.Destroy(_joint);
				_joint = null;
			}
			base.PartScript.gameObject.SetActive(value: false);
		}

		private void LoadChuteMesh(string name)
		{
			Transform parent = Utilities.FindFirstGameObjectMyselfOrChildren("ChuteMeshParent", base.PartScript.gameObject).transform;
			GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load("Craft/Parts/Parachutes/" + name)) as GameObject;
			gameObject.transform.SetParent(parent, worldPositionStays: false);
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localScale = Vector3.one;
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.name = name;
			PartMaterialScript.RendererMaterialMap rendererMap = base.PartScript.PartMaterialScript.AddRenderer(gameObject.GetComponent<MeshRenderer>());
			base.PartScript.PartMaterialScript.InitializeMaterial(rendererMap);
		}

		private void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			if (!_detached && _deployed)
			{
				_inflateTime += frame.DeltaTime;
				if (_autoDetachTime.HasValue && _inflateTime >= _autoDetachTime.Value)
				{
					DetachNextFrame();
				}
				_joint.minDistance = Mathf.Clamp01(_inflateTime * 5f) * 0.75f * 6f * Parachute.Scale;
				float drag = Mathf.Clamp01(_inflateTime * 2f) * Parachute.Drag * Parachute.Scale * _dragPercentage;
				ApplyDrag(drag);
				_chuteBody.AddForce(Vector3.forward * 0.001f);
				_chuteBody.AddForce(-(_chuteBody.linearVelocity - base.PartScript.Aircraft.WindVelocity) * 0.01f);
			}
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			_doors.Add(Utilities.FindFirstGameObjectMyselfOrChildren("ChuteBaseDoor1", base.PartScript.gameObject).transform);
			_doors.Add(Utilities.FindFirstGameObjectMyselfOrChildren("ChuteBaseDoor2", base.PartScript.gameObject).transform);
			_doors.Add(Utilities.FindFirstGameObjectMyselfOrChildren("ChuteBaseDoor3", base.PartScript.gameObject).transform);
			_doors.Add(Utilities.FindFirstGameObjectMyselfOrChildren("ChuteBaseDoor4", base.PartScript.gameObject).transform);
			_chutePackage = Utilities.FindFirstGameObjectMyselfOrChildren("ChutePackage", base.PartScript.gameObject);
			_chutePackageMesh = Utilities.FindFirstGameObjectMyselfOrChildren("ChutePackageMesh", base.PartScript.gameObject);
			_chute.gameObject.SetActive(value: false);
			_parachutePhysicsMaterial = Resources.Load("Physics/ParachutePhysicsMaterial") as PhysicsMaterial;
			return UniTask.CompletedTask;
		}

		private void OnUpdateDesigner(in CraftUpdateFrameData frame)
		{
			_doorSpeed = 1f;
			AnimateDoors(Time.unscaledDeltaTime);
			if (Designer.Instance != null && Designer.Instance.Tools.IsColorToolSelected)
			{
				_openDoors = true;
			}
			else
			{
				_openDoors = false;
			}
		}

		private void OnUpdateFlight(in CraftUpdateFrameData frame)
		{
			bool flag = _activateFunc();
			if (!_deployed)
			{
				if (flag && !_jammed)
				{
					DeployParachute();
				}
			}
			else if (!flag && !_detached)
			{
				DetachParachute();
			}
			if (_deployed)
			{
				AnimateDoors(frame.DeltaTime);
				AnimateInflation();
			}
			if (_detached && !_dead)
			{
				_detachTimer += frame.DeltaTime;
				if (_detachTimer > 10f)
				{
					KillParachute();
				}
			}
		}

		private void OnVelocitySet(Vector3 velocity)
		{
			if (_chuteBody != null)
			{
				_chuteBody.linearVelocity = velocity;
			}
		}
	}
}
